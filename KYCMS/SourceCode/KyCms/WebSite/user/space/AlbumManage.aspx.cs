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

public partial class user_space_AlbumManage : System.Web.UI.Page
{
    B_UserAlbum AlbumBll = new B_UserAlbum();
    M_UserAlbum AlbumModel = new M_UserAlbum();
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    int I = 0;
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
            repBind();
        }
    }
    protected void repBind()
    {
        int recordCount = 0;
        DataTable dt = AlbumBll.GetUserAlbumByUserId(UserModel.UserID, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        repAlbumManage.DataSource = dt;
        repAlbumManage.DataBind();
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}个相册 每页显示{3}个", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize);
    }
    protected void repAlbumManage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int recordCount = 0;
        DataTable dt = AlbumBll.GetUserAlbumByUserId(UserModel.UserID, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        repAlbumManage.DataSource = dt;
        if (dt.Rows.Count <= 0 && e.Item.ItemType == ListItemType.Footer)
        {
            Literal litMsg = (Literal)e.Item.FindControl("litMsg");
            litMsg.Text = "您还没有相册<a href='CreateAlbum.aspx'>立即创建</a>！";
        }
        if (I % 5 == 0)
        {
            e.Item.Controls.Add(new LiteralControl("</tr><tr>"));
        }
        I++;
    }
    //删除
    protected void repAlbumManage_ItemDelete(object sender, RepeaterCommandEventArgs e)
    {
        HiddenField Id = (HiddenField)e.Item.FindControl("hfId");
        AlbumBll.DeleteAlbum(Convert.ToInt32(Id.Value),UserModel.UserID);
        repBind();
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
    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        repBind();
    }

}
