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
using Ky.BLL;
using Ky.BLL.CommonModel;

public partial class user_Left : System.Web.UI.Page
{
    B_Channel ChannelBll = new B_Channel();
    B_UserGroup UserGroupBll = new B_UserGroup();
    B_User UserBll = new B_User();
    M_User LoginModel = null;
    M_User UserModel = null;
    M_UserGroup UserGroupModel = null;
    private B_CustomForm BCustomForm = new B_CustomForm();
    private B_Review BReview = new B_Review();
    private B_InfoOper InfoOperBll = new B_InfoOper();
    private B_InfoModel InfoModelBll = new B_InfoModel();
    B_WebMessage MessageBll = new B_WebMessage();
    B_Feedback FeedBll = new B_Feedback();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断用户信息是否合法
        LoginModel = UserBll.GetCookie();
        UserModel = UserBll.GetUser(LoginModel.UserID);
        if (UserModel == null)
        { Response.Redirect("Login.aspx"); }

        UserGroupModel = UserGroupBll.GetModel(UserModel.GroupID);
        int UserId = UserModel.UserID;
        //say hello
        int time = DateTime.Now.ToLocalTime().Hour;
        string prefix = "";
        if (time > 0 && time <= 5)
        { prefix = "凌晨"; }
        else if (time > 5 && time <= 12)
        { prefix = "上午"; }
        else if (time > 12 && time <= 18)
        { prefix = "下午"; }
        else if (time > 18 && time <= 24)
        { prefix = "晚上"; }
        lbHello.Text = prefix+"好，"+UserModel.LogName;
        //是否显示密码保护提示
        if (string.IsNullOrEmpty(UserModel.Question))
        {
            lbRed.Text = "<li>&nbsp;您尚未设置密码保护&nbsp;<a href=\"changeQA.aspx\" target=\"ContentIframe\">[设置]</a></li>";
            redInfo.Visible = true;
        }
        //获取未读短消息
        int msgNum = Convert.ToInt32(MessageBll.GetList(1, 100000, "where IsSend=1 and ReceiverDel=0 and IsRead=0 and ReceiverId='" + UserModel.UserID + "'").Tables[1].Rows[0][0]);
        if (msgNum > 0)
        {
            lbBlue.Text += "<li>&nbsp;您有 " + msgNum + " 条未读短消息&nbsp;<a href=\"Message/MessageList.aspx?TypeId=1\" target=\"ContentIframe\">[读取]</a></li>";
        }
        int feedNum = Convert.ToInt32(FeedBll.GetList(1000000, 1, "author='"+UserModel.LogName+"' and [EndDate]<=getDate() and state=0").Tables[1].Rows[0][0]);
        if (feedNum > 0)
        {
            lbBlue.Text += "<li>&nbsp;您有 " + feedNum + " 条到期问答&nbsp;<a href=\"MyFeedback.aspx\" target=\"ContentIframe\">[查看]</a></li>";
        }
        //显示提示框
        if (lbBlue.Text != "")
        { blueInfo.Visible = true; }
        if (!IsPostBack)
        {
            GroupName.Text = UserGroupModel.UserGroupName;
            lbLoingTime.Text = UserModel.LastLoginTime.ToShortDateString();
            lbLoginIp.Text = UserModel.LastLoginIP;
            YellowBoy.Text = UserModel.YellowBoy.ToString();
            Integral.Text = UserModel.Integral.ToString();
            Label3.Text = BReview.ReviewList(0, 0, "where UserNum=" + UserId + "").Tables[1].Rows[0][0].ToString();
            Label4.Text = BReview.ReviewList(0, 0, "where UserNum=" + UserId + " and IsCheck=0").Tables[1].Rows[0][0].ToString();
            int publishInfoSumCount = 0;
            int waitInfoSumCount = 0;
            DataTable modelDt = InfoModelBll.GetList();
            foreach (DataRow dr in modelDt.Rows)
            {
                int waitInfoCount = 0;
                int publishInfoCount = 0;
                string tableName = dr["TableName"].ToString();
                InfoOperBll.GetUserInfoList(tableName, UserId, "", "", 0, "0", "-2,0,1,2,3", "", "", "", -1, 1, 5, ref publishInfoCount);
                InfoOperBll.GetUserInfoList(tableName, UserId, "", "", 0, "0", "0", "", "", "", -1, 1, 0, ref waitInfoCount);
                publishInfoSumCount += publishInfoCount;
                waitInfoSumCount += waitInfoCount;
            }
            Label1.Text = publishInfoSumCount.ToString();
            Label2.Text = waitInfoSumCount.ToString();
        }
    }
}
