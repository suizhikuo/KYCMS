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
using Ky.BLL.CommonModel;
using Ky.Model;

public partial class user_SetMessage : System.Web.UI.Page
{
    protected B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    M_UserMessage UserMessageModel = new M_UserMessage();
    B_UserMessage UserMessageBll = new B_UserMessage();
    int UserId = 0;
    string AnounName = "";
    string Title = "";
    string Content = "";
    string HomePage = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(Request.QueryString["UserId"]))
        {
            UserId = Convert.ToInt32(Request.QueryString["UserId"]);
        }
        UserModel=UserBll.GetUser(UserId);
        if(UserModel==null)
             Function.ShowMsg(0, "<li>用户ID参数错误</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
         if (!string.IsNullOrEmpty(Request.Form["AnounName"]))
        {
            AnounName = Request.Form["AnounName"];
        }
        if (!string.IsNullOrEmpty(Request.Form["Title"]))
        {
            Title = Request.Form["Title"];
        }
        if (!string.IsNullOrEmpty(Request.Form["Content"]))
        {
            Content = Request.Form["Content"];
        }
        if(Content=="")
            Function.ShowMsg(0, "<li>留言内容不能为空</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        Response.End();
        if (!string.IsNullOrEmpty(Request.Form["HomePage"]))
        {
            HomePage = Request.Form["HomePage"];
        }

        //添加留言
        UserMessageModel.Title = Title;
        UserMessageModel.Content = Content;
        if (UserBll.IsLogin())
            UserMessageModel.UserId = UserModel.UserID;
        else
            UserMessageModel.UserId = 0;
        UserMessageModel.AnounName = AnounName;
        UserMessageModel.HomePage = HomePage;
        UserMessageModel.ResumeContent = "";
        UserMessageModel.IsPrivacy = false;
        UserMessageModel.IsResume = false;
        UserMessageModel.PostTime = DateTime.Now.ToString();
        UserMessageBll.AddMessage(UserMessageModel);
        if (UserId == 0)
            Function.ShowMsg(1, "<li>留言成功</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
    }
}
