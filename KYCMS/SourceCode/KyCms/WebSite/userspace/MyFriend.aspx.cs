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
public partial class userspace_MyFriend : System.Web.UI.Page
{
   protected string UserName = string.Empty;
    protected B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            UserName = Request.QueryString["UserName"];
        }
        UserModel = UserBll.GetUser(UserName);
        if (UserModel == null)
        {
            Function.ShowMsg(0, "<li>用户空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a>");
        }
        B_UserSpace.IsActive(UserModel.UserID, 2);
        B_UserSpace spaceBll = new B_UserSpace();
        M_UserSpace spaceModel = spaceBll.GetUserSpaceById(UserModel.UserID);
        Page.Title = spaceModel.SpaceName + "--我的好友列表";

        if (!IsPostBack)
        {
            repFriendBind();
        }
    }
    protected void repFriendBind()
    {
        string whereStr = "KyUserFriend.UserId=" + UserModel.UserID.ToString() + " and FriendGroupId!=2";
        int total = 0;
        DataTable dt = UserBll.ListGroupMember(whereStr, 10, 1, ref total);
        if (dt.Rows.Count <= 0)
        {
            Label2.Text = "暂无好友!";
            return;
        }
        repFriend.DataSource = dt;
        repFriend.DataBind();
    }
    protected void btnSetFriend_Click(object sender, EventArgs e)
    {
        if (!UserBll.IsLogin())
            Function.ShowMsg(0, "<li>你还未登录!</li><li>请先<a href='../user/login.aspx' target='_blank'>登录</a></li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        foreach (RepeaterItem item in repFriend.Items)
        {
            Label lbFriendName = (Label)item.FindControl("lbFriendName");
            if (UserBll.GetCookie().LogName == lbFriendName.Text.Trim())
                Function.ShowMsg(0, "<li>对不起，你不能添加自己为好友!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
            int flag = UserBll.AddFriend(UserBll.GetCookie().UserID, lbFriendName.Text.Trim(), 1);
            if (flag == 1)
                Function.ShowMsg(0, "<li>对不起,该用户已经是你的好友了!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
            else if (flag == 2)
                Function.ShowMsg(0, "<li>对不起,您添加的好友不存在!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
            else
                Function.ShowMsg(1, "<li>好友添加成功!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }

    }
}
