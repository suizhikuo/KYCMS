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
using Ky.Model;
using Ky.SQLServerDAL;
using Ky.BLL;
using Ky.Common;

public partial class user_space_CreateAlbum : System.Web.UI.Page
{

    B_Dictionary DictionaryBll = new B_Dictionary();
    B_UserAlbum AlbumBll = new B_UserAlbum();
    M_UserAlbum AlbumModel = new M_UserAlbum();
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    int ImgCount = 0;
    int Id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        B_UserSpace.IsActive(UserModel.UserID, 1);
        txtLogo.Attributes.Add("readonly","");
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            Id = int.Parse(Request.QueryString["Id"]);
        }
        if (!IsPostBack)
        {
            AlbumBind();
            if (Id > 0)
                ShowAlbum(Id);
        }
    }
    protected void AlbumBind()
    {
        ddlAlbumCate.DataSource = DictionaryBll.FormatCategory(66);
        ddlAlbumCate.DataTextField =  "DicName";
        ddlAlbumCate.DataValueField = "DicValue";
        ddlAlbumCate.DataBind();
    }
    protected void btnSaveAs_Click(object sender, EventArgs e)
    {
        AlbumModel.Id = Id;
        AlbumModel.AlbumName = txtAlbumName.Text.Trim();
        AlbumModel.AlbumCate = ddlAlbumCate.SelectedValue;
        AlbumModel.AlbumDescription = txtAlbumDescription.Text.Trim();
        AlbumModel.ImgCount = ImgCount;
        AlbumModel.Logo = txtLogo.Text.Trim();
        AlbumModel.IsOpened = int.Parse(ddlIsOpened.SelectedValue);
        AlbumModel.AlbumPassword = AlbumModel.IsOpened != 0 ? "" : txtAlbumPassword.Text.Trim();
        AlbumModel.AddTime = DateTime.Now.ToString();
        AlbumModel.UserId = UserModel.UserID;
        AlbumModel.UserName = UserModel.LogName;
        if (Id <= 0)
        {
            AlbumBll.AddAlbum(AlbumModel);
           Function.ShowMsg(1, "<li>相册创建成功</li><li><a href='javascript:window.location.href=\"space/CreateAlbum.aspx\"'>继续创建</a></li><li><a href='javascript:window.location.href=\"space/AlbumManage.aspx\"'>返回相册首页</a></li>");
        }
        else
        {
            AlbumBll.UpdateAlbum(AlbumModel);
            Function.ShowMsg(1, "<li>相册修改成功</li><li><a href='javascript:history.back()'>重新修改</a></li><li><a href='javascript:window.location.href=\"space/AlbumManage.aspx\"'>返回相册首页</a></li>");
        }
    }
    protected void ShowAlbum(int Id)
    {
        AlbumModel = AlbumBll.GetAlbumById(Id,UserModel.UserID);
        if (AlbumModel == null)
            return;
        txtAlbumName.Text = AlbumModel.AlbumName;
        ImgCount = AlbumModel.ImgCount;
        ddlAlbumCate.SelectedValue = AlbumModel.AlbumCate;
        txtAlbumDescription.Text = AlbumModel.AlbumDescription;
        txtLogo.Text = AlbumModel.Logo;
        ddlIsOpened.SelectedValue = AlbumModel.IsOpened.ToString();
        txtAlbumPassword.Text = AlbumModel.AlbumPassword;
        btnSaveAs.Text = "保存修改";
    }

}
