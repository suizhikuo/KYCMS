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
using Ky.Common;

public partial class system_Feedback : System.Web.UI.Page
{
    B_Feedback feedback = new B_Feedback();
    B_Admin admin = new B_Admin();
    int FID = 0;
    B_PowerGroup power = new B_PowerGroup();
    B_Dictionary dicBll = new B_Dictionary();
    const int cid = 8;
    protected void Page_Load(object sender, EventArgs e)
    {
        power.Power_Judge(38);
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            FID = Function.CheckNumber(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 0;
            if (!IsPostBack)
            {
                BindData();
                BindCategory();
            }
        }
    }

    void BindData()
    {
        DataSet data = feedback.GetFeedback(FID);
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
            LitIp.Text = subject.Rows[0]["Ip"].ToString();
            for (int i = 0; i < 3; i++)
            {
                if (subject.Rows[0]["state"].ToString() == rblState.Items[i].Value)
                { rblState.SelectedIndex = i; break; }
            }
            LitCategory.Text = dicBll.GetModel(int.Parse(subject.Rows[0]["categoryId"].ToString())).DicName;            
        }
        else
        { Function.ShowSysMsg(0, "<li>没有获取到数据</li><li><a href='other/FeedbackList.aspx'>返回问答列表</a></li>"); }

        rptFeedback.DataSource = reply;
        rptFeedback.DataBind();
    }

    /// <summary>
    /// 绑定分类
    /// </summary>
    void BindCategory()
    {
        ddlCategory.DataSource = dicBll.FormatCategory(cid);
        ddlCategory.DataTextField = "DicName";
        ddlCategory.DataValueField = "DicId";
        ddlCategory.DataBind();
    }

    protected void btnSetState_Click(object sender, EventArgs e)
    {
        if (FID != 0)
        {
            feedback.UpdateState(FID,0, int.Parse(rblState.SelectedValue));
            Response.Redirect("FeedbackList.aspx"); 
        }
    }

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
    protected void btnSetTrans_Click(object sender, EventArgs e)
    {
        if (FID != 0)
        {
            feedback.UpdateState(FID, 1, int.Parse(ddlCategory.SelectedValue));
            Response.Redirect("FeedbackList.aspx"); 
        }
    }

    protected void rptFeedback_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            feedback.Delete(Convert.ToInt32(e.CommandArgument));
            BindData();
        }
    }
}
