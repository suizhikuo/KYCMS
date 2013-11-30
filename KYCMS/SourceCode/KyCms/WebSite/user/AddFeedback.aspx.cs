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

public partial class user_AddFeedback : System.Web.UI.Page
{
    B_User user = new B_User();
    M_User userModel;
    B_Dictionary DicBll = new B_Dictionary();
    B_Feedback feedback = new B_Feedback();
    B_Money moneyBll = new B_Money();
    const int cid = 8;
    protected void Page_Load(object sender, EventArgs e)
    {
        userModel = user.GetUser(user.GetCookie().LogName);
        LitUserIntergral.Text = userModel.Integral.ToString();
        if (!IsPostBack)
        {
            BindCategory();
        }
    }
    void BindCategory()
    {
        lsbCategory.DataSource = DicBll.FormatCategory(cid);
        lsbCategory.DataTextField = "DicName";
        lsbCategory.DataValueField = "DicId";
        lsbCategory.DataBind();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (userModel != null)
        {
            if (txtTitle.Text.Trim() == "")
            {
                Function.ShowMsg(0, "<li>对不起,请输入问答标题</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            if (lsbCategory.SelectedValue == "")
            {
                Function.ShowMsg(0, "<li>对不起，请选择分类</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            M_Feedback model = new M_Feedback();
            int rewardNum = int.Parse(ddlReward.SelectedValue);
            if (userModel.Integral >= rewardNum)
            {
                model.Reward = rewardNum;
            }
            else
            { Function.ShowMsg(0, "<li>您的积分不够，不能设置为 "+rewardNum+" 的悬赏分</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
            model.ParentId = 0;
            model.ReplyDate = DateTime.Now;
            model.State = 0;
            model.Title = txtTitle.Text;
            model.Author = userModel.LogName;
            B_SiteInfo siteBll = new B_SiteInfo();        
            model.Content = siteBll.GetFiltering(txtContent.Text);
            model.Ip = Request.UserHostAddress;
            model.EndDate = DateTime.Now.AddDays(14);
            model.CategoryId = int.Parse(lsbCategory.SelectedValue);            
            feedback.Add(model);
            rewardNum = rewardNum * -1;
            moneyBll.Integral(rewardNum, userModel.LogName);
            Response.Redirect("MyFeedback.aspx");
        }
    }
}
