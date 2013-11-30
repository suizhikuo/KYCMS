using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ky.BLL;
using Ky.Model;
using Ky.SQLServerDAL;
using Ky.Common;
using System.IO;

public partial class user_space_UploadPic : System.Web.UI.Page
{
    B_UserPhoto PhotoBll = new B_UserPhoto();
    B_UserAlbum AlbumBll = new B_UserAlbum();
    M_UserAlbum AlbumModel = new M_UserAlbum();
    M_UserPhoto PhotoModel = new M_UserPhoto();
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    string txtPhoto = "";
    int AlbumId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        B_UserSpace.IsActive(UserModel.UserID, 1);
        if (!string.IsNullOrEmpty(Request.QueryString["AlbumId"]))
        {
            AlbumId = int.Parse(Request.QueryString["AlbumId"]);
        }
        if (!IsPostBack)
        {
            ddlAlbumBind();
        }
    }
    protected void ddlAlbumBind()
    {
        int recordCount = 0;
        DataTable dt = AlbumBll.GetUserAlbumByUserId(UserModel.UserID, 1, 1000, ref recordCount);
        ddlAlbum.DataTextField = "AlbumName";
        ddlAlbum.DataValueField = "Id";
        ddlAlbum.DataSource = dt.DefaultView;
        ddlAlbum.DataBind();
        ddlAlbum.Items.Insert(0, new ListItem("请选择相册", "-1"));
        if (AlbumId > 0)
            ddlAlbum.SelectedValue = AlbumId.ToString();
    }
    protected void btnPublish_Click(object sender, EventArgs e)
    {
        //PhotoModel.PhotoId
        bool flag = false;
        for (int i = 1; i <= int.Parse(txtPhotoNum.Text); i++)
        {
            txtPhoto = Request.Form["nmph" + i];
            if (txtPhoto != "")
                flag = true;
        }
        if (!flag)
        {
            Function.ShowMsg(0, "<li>未上传任何照片!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        PhotoModel.AlbumId = int.Parse(ddlAlbum.SelectedValue);
        PhotoModel.FileName = txtPhotoName.Text.Trim();
        PhotoModel.Description = txtDescription.Text.Trim();
        PhotoModel.PostTime = DateTime.Now.ToString();
        PhotoModel.UserId = UserModel.UserID;
        PhotoModel.UserName = UserModel.LogName;
        PhotoModel.VisitNum = 0;
        AlbumModel = AlbumBll.GetAlbumById(int.Parse(ddlAlbum.SelectedValue), UserModel.UserID);
        AlbumModel.Id = int.Parse(ddlAlbum.SelectedValue);
        for (int i = 1; i <= int.Parse(txtPhotoNum.Text); i++)
        {
            txtPhoto = Request.Form["nmph" + i];
            if (txtPhoto != "")
            {
                PhotoModel.FilePath = Request.Form["nmph" + i];
                AlbumModel.ImgCount += 1;
                string filepath = Param.SiteRootPath + "/user/upload/" + PhotoModel.FilePath;
                FileInfo fl = new FileInfo(filepath);
                PhotoModel.FileSize = Convert.ToInt32(fl.Length);
                PhotoBll.AddPhoto(PhotoModel);
                AlbumBll.UpdateAlbum(AlbumModel);
            }
        }
        Function.ShowMsg(1, "<li>照片上传成功!</li><li><a href='space/UploadPic.aspx?AlbumId=" + AlbumId + "'>继续上传</a></li><li><a href='space/ShowPhoto.aspx?AlbumId=" + AlbumId + "'>返回照片列表</a></li><li><a href='space/AlbumManage.aspx'>返回相册列表</a></li>");
    }
}
