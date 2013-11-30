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
public partial class userspace_Album : System.Web.UI.UserControl
{
    B_UserAlbum AlbumBll = new B_UserAlbum();
    M_UserAlbum AlbumModel = new M_UserAlbum();
    B_UserPhoto PhotoBll = new B_UserPhoto();
    M_UserPhoto PhotoModel = new M_UserPhoto();
    protected string UserName = string.Empty;
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    protected int AlbumId = 0;
    protected string PwdStr = "";
    protected int UId = 0;
    protected string picPath = "";
    protected bool UIdflag = false;
    protected bool UNameflag = false;
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["UId"]) && !string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            UId = Convert.ToInt32(Request.QueryString["UId"]);
            UserName = Convert.ToString(Request.QueryString["UserName"]);
            if (UserBll.GetUser(UserName) != null && UserBll.GetUser(UId) != null)
            {
                if (UId != UserBll.GetUser(UserName).UserID)
                {
                    Function.ShowMsg(0, "<li>空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
                }
                else
                    UIdflag = true;
            }
            else
            {
                if (UserBll.GetUser(UId) == null)
                    UNameflag = true;
                else if(UserBll.GetUser(UserName) == null)
                    UIdflag=true;
                else
                    Function.ShowMsg(0, "<li>空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
            }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["UId"]) && string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            UId = Convert.ToInt32(Request.QueryString["UId"]);
            UIdflag = true;
        }
        else if (string.IsNullOrEmpty(Request.QueryString["UId"]) && !string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            UserName = Convert.ToString(Request.QueryString["UserName"]);
            UNameflag = true;
        }

        if (UIdflag)
        {
            UserModel = UserBll.GetUser(UId);
            picPath = "../";
        }
        else if (UNameflag)
            UserModel = UserBll.GetUser(UserName);
        
        if (UserModel == null)
            Function.ShowMsg(0, "<li>空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");

        if (!string.IsNullOrEmpty(Request.QueryString["AlbumId"]))
        {
            AlbumId = Convert.ToInt32(Request.QueryString["AlbumId"]);
        }
        B_UserSpace.IsActive(UserModel.UserID, 2);
        B_UserSpace spaceBll = new B_UserSpace();
        M_UserSpace spaceModel = spaceBll.GetUserSpaceById(UserModel.UserID);
        Page.Title = spaceModel.SpaceName + "--相册/照片列表";
        if (!IsPostBack)
        {
            repAblumBind();
            if (AlbumId > 0)
            {
                AlbumModel = AlbumBll.GetAlbumById(AlbumId, UserModel.UserID);
                PwdStr = AlbumModel.AlbumPassword;
                if (AlbumModel == null)
                    Function.ShowMsg(0, "<li>用户相册参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
                string whereStr = "KyUserFriend.UserId=" + UserModel.UserID.ToString() + " and FriendGroupId!=2";
                int total = 0;
                DataTable dt = UserBll.ListGroupMember(whereStr, 1000, 1, ref total);
                if (!UserBll.IsLogin())
                {
                    if (AlbumModel.IsOpened == 2)
                    {
                        IsFriend.Visible = true; divPage.Visible = false;
                    }
                    else if (AlbumModel.IsOpened == 0)
                    {
                        if (HttpContext.Current.Request.Cookies["AlbumPwd" + AlbumId.ToString()] != null)
                        {
                            if (HttpContext.Current.Request.Cookies["AlbumPwd" + AlbumId.ToString()].Value != AlbumId.ToString())
                            {
                                ShowPwd.Visible = true;
                                divPage.Visible = false;
                            }
                            else { repPhotoBind(); }
                        }
                        else
                        { ShowPwd.Visible = true; divPage.Visible = false; }
                    }
                    else
                    {
                        repPhotoBind();
                    }
                }
                else
                {
                    if (AlbumModel.IsOpened == 0 && UserBll.GetCookie().UserID != UserModel.UserID)
                    {
                        if (HttpContext.Current.Request.Cookies["AlbumPwd" + AlbumId.ToString()] != null)
                        {
                            if (HttpContext.Current.Request.Cookies["AlbumPwd" + AlbumId.ToString()].Value != AlbumId.ToString())
                            {
                                ShowPwd.Visible = true; divPage.Visible = false;
                            }
                            else { repPhotoBind(); }
                        }
                        else
                        { ShowPwd.Visible = true; divPage.Visible = false; }
                    }
                    else if (AlbumModel.IsOpened == 2 && UserBll.GetCookie().UserID != UserModel.UserID)
                    {
                        bool flag = false;
                        if (dt.Rows.Count <= 0)
                            flag = false;
                        else
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (UserBll.GetCookie().UserID == int.Parse(dt.Rows[i]["FriendId"].ToString()))
                                    flag = true;
                            }
                        }
                        if (!flag)
                        { IsFriend.Visible = true; divPage.Visible = false; }
                        else
                        { repPhotoBind(); ShowPwd.Visible = false; IsFriend.Visible = false; }
                    }
                    else { repPhotoBind(); }
                }

            }
        }

        AjaxPro.Utility.RegisterTypeForAjax(typeof(userspace_Album));
    }
    //Album
    protected void repAblumBind()
    {
        int recordCount = 0;
        DataTable dt = AlbumBll.GetUserAlbumByUserId(UserModel.UserID, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, ref recordCount);
        if (dt.Rows.Count <= 0)
        {
            Label1.Visible = true;
            ShowAlbumPage.Visible = false;
            return;
        }
        repAlbumManage.DataSource = dt;
        repAlbumManage.DataBind();
        AspNetPager1.RecordCount = recordCount;
        AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}个相册 每页显示{3}个", AspNetPager1.CurrentPageIndex, AspNetPager1.PageCount, AspNetPager1.RecordCount, AspNetPager1.PageSize);
    }
    protected void repAlbumManage_ItemDataCreate(object sender, RepeaterItemEventArgs e)
    {
        int i = e.Item.ItemIndex + 1;
        Repeater temp_Repeater = (Repeater)sender;
        if (i % 4 == 0 && i != temp_Repeater.Items.Count)
        {
            e.Item.Controls.Add(new LiteralControl("</tr><tr>"));
        }
    }
    protected string ShowImgPath(object path)
    {
        if (path.ToString() == "")
            return "~/userspace/skin/images/xc.jpg";
        else
            return Param.ApplicationRootPath + "/user/upload/" + path.ToString();
    }
    protected string IsOpened(object isOpened)
    {
        if (Convert.ToInt32(isOpened) == 0)
            return "加密";
        else if (Convert.ToInt32(isOpened) == 1)
            return "公开";
        else
            return "仅好友";
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        repAblumBind();
    }

    //Photo
    protected void repPhotoBind()
    {
        int recordCount = 0;
        DataTable dt = PhotoBll.GetUserPhotoById(AlbumId, UserModel.UserID, AspNetPager2.CurrentPageIndex, AspNetPager2.PageSize, ref recordCount);
        repPhoto.DataSource = dt;
        repPhoto.DataBind();
        AspNetPager2.RecordCount = recordCount;
        AspNetPager2.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}张照片 每页显示{3}张", AspNetPager2.CurrentPageIndex, AspNetPager2.PageCount, AspNetPager2.RecordCount, AspNetPager2.PageSize);
    }
    protected void repPhoto_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int recordCount = 0;
        DataTable dt = PhotoBll.GetUserPhotoById(AlbumId, UserModel.UserID, AspNetPager2.CurrentPageIndex, AspNetPager2.PageSize, ref recordCount);
        repPhoto.DataSource = dt;
        Div1.Visible = true;
        lbRepTitle.Text = AlbumModel.AlbumName;
        if (e.Item.ItemType == ListItemType.Footer)
        {
            AlbumModel = AlbumBll.GetAlbumById(AlbumId, UserModel.UserID);
            if (dt.Rows.Count <= 0)
            {
                divIsHave.Attributes.Add("style","display:block");
                divPage.Visible = false;
            }
        }
    }
    protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager2.CurrentPageIndex = e.NewPageIndex;
        repPhotoBind();
    }



    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
    public string btnCheckPwd_UId(string Pwd, string albumId, string uId)
    {
        UserModel = UserBll.GetUser(Convert.ToInt32(uId));
        AlbumModel = AlbumBll.GetAlbumById(Convert.ToInt32(albumId), UserModel.UserID);
        if (AlbumModel.AlbumPassword != Pwd)
        {
            return "False";
        }
        else
        {
            HttpContext.Current.Response.Cookies["AlbumPwd" + albumId.ToString()].Value = albumId;
            return "True";
        }
    }

    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
    public string btnCheckPwd_UName(string Pwd, string albumId, string userName)
    {
        UserModel = UserBll.GetUser(userName);
        AlbumModel = AlbumBll.GetAlbumById(Convert.ToInt32(albumId), UserModel.UserID);
        if (AlbumModel.AlbumPassword != Pwd)
        {
            return "False";
        }
        else
        {
            HttpContext.Current.Response.Cookies["AlbumPwd" + albumId.ToString()].Value = albumId;
            return "True";
        }
    }

}
