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

public partial class user_Feedback : System.Web.UI.Page
{
    B_Feedback feedback = new B_Feedback();
    B_User user = new B_User();
    int FId = 0;
    DataTable dt = null;
    B_Money money = new B_Money();
    M_User userModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        userModel = user.GetCookie();
        string qryId = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(qryId) && Function.CheckInteger(qryId))
        {
            FId = int.Parse(qryId);
            if (!IsPostBack)
            { BindData(); }
        }
    }

    void BindData()
    {
        DataSet data = feedback.GetFeedback(FId);
        DataTable subject = data.Tables[0];
        DataTable reply = data.Tables[1];
        if (subject.Rows.Count > 0)
        {
            LitAddReward.Text = LitReward.Text = subject.Rows[0]["reward"].ToString();
            LitContent.Text = Function.HtmlEncode(subject.Rows[0]["content"].ToString());
            LitPostDate.Text = subject.Rows[0]["replyDate"].ToString();
            LitPostTitle.Text = subject.Rows[0]["title"].ToString();
            LitPostAuthorGroup.Text = SetUserGroup(subject.Rows[0]["author"]);
            if (subject.Rows[0]["state"].ToString() == "1" || subject.Rows[0]["state"].ToString() == "2")
            {
                replyPanel.Visible = false;
                btnEnd.Visible = false;
            }
        }

        rptFeedback.DataSource = reply;
        rptFeedback.DataBind();
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
            model.Author = user.GetCookie().LogName;
            model.Title = "";
            model.CategoryId = Convert.ToInt32(feedback.GetFeedback(FId).Tables[0].Rows[0]["CategoryId"]);
            model.State = 0;
            feedback.Add(model);
            txtReply.Text = "";
            Response.Redirect("MyFeedback.aspx");
        }
    }
    /// <summary>
    /// 设置用户组
    /// </summary>
    /// <param name="author">用户名</param>
    /// <returns></returns>
    protected string SetUserGroup(object author)
    {
        string userType = "";
        if (author != null)
        {
            M_User userModel = user.GetUser(author.ToString());
            if (userModel != null)
            {
                B_UserGroup userGroupBll = new B_UserGroup();
                DataTable dt = userGroupBll.ManageList("");
                if (dt.Rows.Count > 0)
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
        }
        return userType;
    }

    /// <summary>
    /// 结贴
    /// </summary>
    protected void btnEnd_Click(object sender, EventArgs e)
    {
        feedback.UpdateState(FId, 0, 1);
        replyPanel.Visible = false;
        btnEnd.Visible = false;
        DataTable data = feedback.GetReplyers(FId, userModel.LogName);
        if (data.Rows.Count > 0)
        {
            rptIntegral.DataSource = data;
            rptIntegral.DataBind();
            UserTable.Visible = true;
        }
        //当悬赏分为 0  时，隐藏加分列表
        if (LitAddReward.Text == "0")
        {
            UserTable.Visible = false;
        }
    }

    /// <summary>
    /// 给回复者加分
    /// </summary>
    protected void btnOver_Click(object sender, EventArgs e)
    {
        int sum = 0;
        int itemCount = rptIntegral.Items.Count;
        int[] rs = new int[itemCount];//分数
        string[] names = new string[itemCount];//回复者用户名
        int[] ids = new int[itemCount];//回复ID
        for (int m = 0; m < itemCount; m++)
        {
            TextBox txt = rptIntegral.Items[m].FindControl("txtIntegral") as TextBox;
            Literal author = rptIntegral.Items[m].FindControl("LitReplyAuthor") as Literal;
            Literal litId = rptIntegral.Items[m].FindControl("LitReplyId") as Literal;
            if (author != null && txt != null && litId != null)
            {
                int integral = 0;
                if (!string.IsNullOrEmpty(txt.Text))
                {
                    if (Function.CheckInteger(txt.Text))
                    {
                        integral = int.Parse(txt.Text);
                    }
                    else { Function.ShowMsg(0, "<li>您输入的分数不正确，请重新设置</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>"); }
                }
                if (integral >= 0)
                {
                    int id = int.Parse(litId.Text);
                    rs[m] = integral;
                    names[m] = author.Text;
                    ids[m] = id;
                    sum += integral;
                }
                else
                { Function.ShowMsg(0, "<li>不能打负分，请重新设置</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>"); }
            }
        }
        if (sum <= int.Parse(LitAddReward.Text))
        {
            for (int i = 0; i < itemCount; i++)
            {
                //给用户帐户加上积分
                money.Integral(rs[i], names[i]);
                //更新Feedback表的得分
                feedback.UpdateState(ids[i], 2, rs[i]);
            }
            Response.Redirect("MyFeedback.aspx");
        }
        else
        { Function.ShowMsg(0, "<li>您的悬赏分数不足，请重新设置</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>"); }
    }
}
