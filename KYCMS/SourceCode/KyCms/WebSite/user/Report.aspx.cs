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

public partial class user_Common_Report : System.Web.UI.Page
{
    protected B_User UserBll = new B_User();
    protected B_Report ReportBll = new B_Report();
    protected string Url = string.Empty;
    protected M_User UserLoginModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!UserBll.IsLogin())
        {
            Tab1.Visible = false;
            Tab2.Visible = true;
            return;
        }
        Tab2.Visible = false;
        UserLoginModel = UserBll.GetCookie();
        if (!string.IsNullOrEmpty(Request.QueryString["Url"]))
        {
            Url = Request.QueryString["Url"];
            LbAddress.Text = Url;
        }
        else
        {
            Response.Write("<script>alert('举报地址获取错误');window.close();</script>");
            Response.End();
            return;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        M_Report reportModel = new M_Report();
        if (txtContent.Text.Length > 500)
        {
            litMsg.Text = "● 举报内容不能超过500个字";
            return;
        }
        reportModel.Content = txtContent.Text;
        reportModel.Url = Url;
        reportModel.UserId = UserLoginModel.UserID;
        reportModel.UserName = UserLoginModel.LogName;
        reportModel.IsComplete = 0;
        reportModel.AddTime = DateTime.Now;
        ReportBll.Add(reportModel);
        Response.Write("<script>alert('感谢您对我们的支持');window.opener=null;window.close();</script>");
    }
}
