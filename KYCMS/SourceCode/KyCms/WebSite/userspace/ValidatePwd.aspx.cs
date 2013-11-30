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
using Ky.Common;
using Ky.Model;
public partial class userspace_ValidatePwd : System.Web.UI.Page
{
    B_UserSpace SpaceBll = new B_UserSpace();
    M_UserSpace SpaceModel = null;
    protected string UserName = string.Empty;
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    int OptionId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (!string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            UserName = Request.QueryString["UserName"];
        }
        UserModel = UserBll.GetUser(UserName);
        if (UserModel == null)
        {
            Function.ShowMsg(0, "<li>用户空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li><li><a href='javascript:window.close();'>关闭窗口</a></li>");
        }
        B_UserSpace.IsActive(UserModel.UserID, 2);
        if (Request.Cookies["SpacePwd"] != null)
        {
            if (Request.Cookies["SpacePwd"]["UserId"] != UserModel.UserID.ToString())
            {
                Response.Cookies["SpacePwd"].Expires = DateTime.Now.AddDays(-1);
            }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["OptionId"]))
        {
            OptionId = Convert.ToInt32(Request.QueryString["OptionId"]);
        }
        if (OptionId <=0)
        {
            Function.ShowMsg(0, "<li>用户空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li><li><a href='javascript:window.close();'>关闭窗口</a></li>");
        }
        if(!IsPostBack)
        {
            if (OptionId == 1)
                divSpacePwd.Visible = true;
            else if (OptionId == 2)
                divIsFriend.Visible = true;
        }
    }
    protected void btnPwdOk_Click(object sender, EventArgs e)
    {
        SpaceModel = SpaceBll.GetUserSpaceById(UserModel.UserID);
        if (txtspacePwd.Text.Trim() != SpaceModel.Password)
        {
            Function.ShowMsg(0, "<li>密码输入错误</li><li><a href='javascript:history.back()'>重新输入</a></li><li><a href='javascript:window.close();'>关闭窗口</a></li>");
        }
        else
        {
            HttpContext.Current.Response.Cookies["SpacePwd"]["pwd"] = txtspacePwd.Text.Trim();
            HttpContext.Current.Response.Cookies["SpacePwd"]["UserId"] = UserModel.UserID.ToString();
            HttpContext.Current.Response.Cookies["SpacePwd"]["LogId"] = UserBll.GetCookie().UserID.ToString();
            //Cookies有效期10分钟
            Response.Cookies["SpacePwd"].Expires = DateTime.Now.AddMinutes(10);
            Response.Redirect("MyInfoList.aspx?UserName="+UserName);
        }
    }

}
