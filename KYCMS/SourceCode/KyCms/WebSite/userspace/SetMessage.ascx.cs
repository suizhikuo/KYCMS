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
public partial class userspace_SetMessage : System.Web.UI.UserControl
{
    protected B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    M_UserMessage UserMessageModel = new M_UserMessage();
    B_UserMessage UserMessageBll = new B_UserMessage();
    protected int UId = 0;
    protected string UserName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        litMsg.Text = "";
        if (!string.IsNullOrEmpty(Request.QueryString["UId"]))
        {
            UId = Convert.ToInt32(Request.QueryString["UId"]);
        }
        UserModel = UserBll.GetUser(UId);
        if (UserModel == null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["UserName"]))
            {
                UserName = Convert.ToString(Request.QueryString["UserName"]);
            }
            UserModel = UserBll.GetUser(UserName);
        }
        if (UserBll.IsLogin())
        {
            txtAnounName.Value = UserBll.GetCookie().LogName;
        }
        if (!IsPostBack)
        {
            repMsgBind();
        }

        AjaxPro.Utility.RegisterTypeForAjax(typeof(userspace_SetMessage));
    }

    protected void repMsgBind()
    {
        int recordCount = 0;
        DataTable dt = UserMessageBll.GetMessageByUserId(UserModel.UserID, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        if (dt.Rows.Count <= 0)
        {
            Label1.Text = "<font color=blue>暂无留言! </font>"; return;
        }
        repMsg.DataSource = dt;
        repMsg.DataBind();
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条留言 每页显示{3}条", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize);
    }
    protected string ResmueContent(object flag, object resumeContent, object resumeTime)
    {
        if (Convert.ToBoolean(flag))
            return "<div style='background-color:#E8F0F1; padding:5px;  color:#f00; border:1px #ccc solid;word-break:break-all' class='resumeBg' >Space主人 于 " + resumeTime.ToString() + " 回复到:<br />" + Function.HtmlEncode(resumeContent.ToString()).Replace("\r\n", "<br/>").Replace(" ", "&nbsp;&nbsp;") + "</div>";
        else
            return "";
    }
    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        repMsgBind();
    }
    protected string GetContent(object s)
    {
        if (s != null && s.ToString() != string.Empty)
        {
            return Function.HtmlEncode(s).Replace("\r\n", "<br/>").Replace(" ", "&nbsp;&nbsp;");
        }
        else
        {
            return string.Empty;
        }
    }

    //添加留言

    [AjaxPro.AjaxMethod()]
    public string SetMessage(string title, string homePage, string anounName, string content, string uId, string uName)
    {
        int uid = Convert.ToInt32(uId);
        int userId = 0;
        if (UserBll.GetUser(uid) == null)
        {
            if (UserBll.GetUser(uName) == null)
                userId = 0;
            else
                userId = UserBll.GetUser(uName).UserID;
        }
        else
            userId = UserBll.GetUser(uid).UserID;
        UserMessageModel.UserId = userId;
        UserMessageModel.Title = title;
        UserMessageModel.Content = content;
        UserMessageModel.AnounName = anounName;
        UserMessageModel.HomePage = homePage;
        UserMessageModel.ResumeContent = "";
        UserMessageModel.IsPrivacy = false;
        UserMessageModel.IsResume = false;
        UserMessageModel.PostTime = DateTime.Now.ToString();
        UserMessageBll.AddMessage(UserMessageModel);
        return "留言成功";
    }

}
