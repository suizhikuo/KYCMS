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


public partial class user_space_ResumeMsg : System.Web.UI.Page
{
    M_UserMessage UserMessageModel = new M_UserMessage();
    B_UserMessage UserMessageBll = new B_UserMessage();
    B_User UserBll = new B_User();
    int Id = 0;
    string option = "";
    M_User UserModel = new M_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        litMsg.Text = string.Empty;
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        B_UserSpace.IsActive(UserModel.UserID, 1);
        if(!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        }
        if (Id <= 0)
        {
            Function.ShowMsg(0, "<li>留言编号错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        if (!string.IsNullOrEmpty(Request.QueryString["option"]))
        {
            option = Request.QueryString["option"];
        }
        if(option!="look" && option!="resume" || option=="")
        {
            Function.ShowMsg(0, "<li>参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        if(!IsPostBack)
        {
                DataRow dr = UserMessageBll.GetMessageById(Id, UserModel.UserID);
                 lbTitle.Text = Function.HtmlEncode(dr["Title"].ToString());
                 txtContent.Text = dr["Content"].ToString();
                 txtResumeContent.Text = dr["ResumeContent"].ToString();
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (txtResumeContent.Text.Length == 0)
        {
            Function.ShowMsg(0, "<li>请输入回复内容</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        else
        {
            UserMessageModel.ResumeContent = txtResumeContent.Text.Trim();
            UserMessageModel.Id = Id;
            UserMessageModel.UserId = UserModel.UserID;
            UserMessageModel.ResumeTime = DateTime.Now.ToString();
            UserMessageBll.ResumeMessage(UserMessageModel);
            Function.ShowMsg(1, "<li>回复成功</li><li><a href='javascript:history.back();'>重新回复</a></li><li><a href='javascript:window.location.href=\"space/MessageManage.aspx\"'>返回列表</a></li>");
        }
    }
}
