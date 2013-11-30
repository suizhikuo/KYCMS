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

public partial class system_SignOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        B_Admin admin = new B_Admin();
        M_LoginAdmin loginModel = admin.GetLoginModel();
        if (loginModel != null)
        {
            M_Admin model = admin.GetModel(loginModel.UserId);
            model.LastLogoutTime = DateTime.Now;
            admin.UpdateInfo(model);
        }
        admin.ClearCookie();
        Response.Redirect("~/system/Login.aspx");
    }
}
