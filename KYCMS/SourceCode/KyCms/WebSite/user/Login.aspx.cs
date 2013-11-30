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
using Ky.Model;

public partial class Users_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        string refer = "Main.aspx";
        B_SiteInfo siteBll = new B_SiteInfo();
        if (siteBll.GetSiteModel().IsLoginValidate)
        {
            TrValidCode.Visible = true;
            imgCode.Visible = true;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
        {
            refer = Request.QueryString["ReturnUrl"].ToString();
        }
        btnLogin.PostBackUrl = "DoLogin.aspx?ReturnUrl=" + Server.UrlEncode(refer);
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
    }
}
