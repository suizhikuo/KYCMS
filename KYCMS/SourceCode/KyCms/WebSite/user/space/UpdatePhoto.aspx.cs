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
public partial class user_space_UpdatePhoto : System.Web.UI.Page
{
    B_UserPhoto PhotoBll = new B_UserPhoto();
    B_UserAlbum AlbumBll = new B_UserAlbum();
    M_UserAlbum AlbumModel = new M_UserAlbum();
    M_UserPhoto PhotoModel = new M_UserPhoto();
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    int PhotoId = 0;
    int AlbumId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        B_UserSpace.IsActive(UserModel.UserID, 1);
        if (!string.IsNullOrEmpty(Request.QueryString["PhotoId"]))
        {
            try
            {
                PhotoId = Convert.ToInt32(Request.QueryString["PhotoId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["AlbumId"]))
        {
            try
            {
                AlbumId = Convert.ToInt32(Request.QueryString["AlbumId"]);
            }
            catch { }
        }
        if (PhotoId <= 0)
        {
            Function.ShowMsg(0,"<li>此照片不存在，或已经被删除</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        PhotoModel = PhotoBll.GetPhotoByPhotoId(PhotoId);
         //if (txtPhoto.Text.Trim() != "")
            imgView.ImageUrl = Param.ApplicationRootPath + "/user/upload/" + "" + txtPhoto.Text.Trim();

       if (!IsPostBack)
        {
            ddlAlbumBind();
            ShowInfo(PhotoId);
        }
    }
    protected void ddlAlbumBind()
    {
        int recordCount = 0;
        DataTable dt = AlbumBll.GetUserAlbumByUserId(UserModel.UserID,1,1000,ref recordCount);
        ddlAlbum.DataTextField = "AlbumName";
        ddlAlbum.DataValueField = "Id";
        ddlAlbum.DataSource = dt.DefaultView;
        ddlAlbum.DataBind();
        ddlAlbum.Items.Insert(0, new ListItem("请选择相册", "-1"));
        ddlAlbum.SelectedValue = AlbumId.ToString();
    }
    protected void ShowInfo(int PhotoId)
    {
         PhotoModel=PhotoBll.GetPhotoByPhotoId(PhotoId);
         txtPhotoName.Text = PhotoModel.FileName;
         txtDescription.Text = PhotoModel.Description;
         txtPhoto.Text = PhotoModel.FilePath;
         txtPhoto.Text = PhotoModel.FilePath;
         imgView.ImageUrl = Param.ApplicationRootPath + "/user/upload/" + "" + txtPhoto.Text.Trim();

    }
    protected void btnPublish_Click(object sender, EventArgs e)
    {
        PhotoModel.PhotoId = PhotoId;
        PhotoModel.AlbumId = int.Parse(ddlAlbum.SelectedValue);
        PhotoModel.FileName = txtPhotoName.Text.Trim();
        PhotoModel.Description = txtDescription.Text.Trim();
        PhotoModel.PostTime = DateTime.Now.ToString();
        PhotoModel.UserId = UserModel.UserID;
        PhotoModel.UserName = UserModel.LogName;
        PhotoModel.FilePath = txtPhoto.Text.Trim();
        PhotoBll.UpdatePhoto(PhotoModel);
        Response.Redirect("ShowPhoto.aspx?AlbumId=" + int.Parse(ddlAlbum.SelectedValue));
    }
}
