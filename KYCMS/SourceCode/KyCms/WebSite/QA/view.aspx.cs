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
using System.Text;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class QA_View : System.Web.UI.Page
{    
    int FId = 0;
    protected string ReturnUrl = "";
    B_Create createBll = new B_Create();
    B_Feedback feedback = new B_Feedback();
    B_User userBll = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        hylnk.NavigateUrl = createBll.GetIndexUrl();
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            FId = Function.CheckNumber(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 0;
            if (!IsPostBack)
            {
                BindData();
            }
            ReturnUrl = Function.UrlEncode(Request.Url.AbsoluteUri);
        }
    }

    void BindData()
    {
        //如果用户已登录,则显示回复框
        //否则显示登录提示
        if (userBll.IsLogin())
        {
            replyPanel.Visible = true;
        }
        else
        { TrLogin.Visible = true; }
        DataSet data = feedback.GetFeedback(FId);
        DataTable subject = data.Tables[0];
        DataTable reply = data.Tables[1];
        if (subject.Rows.Count > 0)
        {
            LitReward.Text = subject.Rows[0]["reward"].ToString();
            LitContent.Text = Function.HtmlEncode(subject.Rows[0]["content"].ToString());
            LitPostDate.Text = subject.Rows[0]["replyDate"].ToString();
            LitPostTitle.Text = subject.Rows[0]["title"].ToString();
            LitPostAuthorGroup.Text = SetUserGroup(subject.Rows[0]["author"]);
            LitPostAuthor.Text = subject.Rows[0]["author"].ToString();
            switch (subject.Rows[0]["state"].ToString())
            {
                case "0":
                    LitState.Text = "问答中";
                    break;
                case "1":
                    LitState.Text = "已完成";
                    break;
                case "2":
                    LitState.Text = "锁定";
                    break;
            }
            imgState.ImageUrl = Param.ApplicationRootPath + "/images/ing.gif";
            if (subject.Rows[0]["state"].ToString() == "1" || subject.Rows[0]["state"].ToString() == "2")
            {
                imgState.ImageUrl = Param.ApplicationRootPath + "/images/ed.gif";
                replyPanel.Visible = false;
                TrLogin.Visible = false;
                TrLock.Visible = true;
            }
        }
        else
        { Function.ShowMsg(0,"<li>没有获取到数据</li><li><a href='../QA/List.aspx'>返回问答列表</a></li>"); }

        rptFeedback.DataSource = reply;
        rptFeedback.DataBind();
    }

    protected void rptFeedbackDataBound(object sender, RepeaterItemEventArgs e)
    {
        
    }

    /// <summary>
    /// 当得分大于0时才显示得分图片
    /// </summary>
    protected string SetScroing(object scroing)
    {
        string returnStr = "";
        if (scroing != null)
        {
            if (Convert.ToInt32(scroing) > 0)
            {
                returnStr = "<img src='../images/reward.gif' /> " + scroing;
            }
            else
                returnStr = scroing.ToString();
        }
        return returnStr;
    }

    /// <summary>
    /// 设置用户组
    /// </summary>
    protected string SetUserGroup(object author)
    {
        string userType = "";
        if (author != null)
        {
            B_User userBll = new B_User();
            M_User userModel = userBll.GetUser(author.ToString());
            B_UserGroup userGroupBll = new B_UserGroup();
            DataTable dt = userGroupBll.ManageList("");
            if (dt.Rows.Count > 0 && userModel != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["UserGroupId"].ToString() == userModel.GroupID.ToString())
                    {
                        userType = dt.Rows[i]["UserGroupName"].ToString();
                        break;
                    }
                }
            }
        }
        else
        {
            userType = "游客";
        }
        return userType;
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (FId != 0)
        {
            if (txtReply.Text.Trim() == "")
            {
                Function.ShowMsg(0, "<li>回复内容不能为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            M_Feedback model = new M_Feedback();
            B_SiteInfo siteBll = new B_SiteInfo();
            model.Content = siteBll.GetFiltering(txtReply.Text);
            model.ParentId = FId;
            model.EndDate = model.ReplyDate = DateTime.Now;
            model.Ip = Request.UserHostAddress;
            model.Author = userBll.GetCookie().LogName;
            model.Title = "";
            model.CategoryId = Convert.ToInt32(feedback.GetFeedback(FId).Tables[0].Rows[0]["CategoryId"]);
            model.State = 0;
            feedback.Add(model);
            txtReply.Text = "";
            BindData();
        }
    }
}
