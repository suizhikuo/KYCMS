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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class userspace_SignOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        B_User user = new B_User();

        user.ExpireCookie();

        B_Create createBll = new B_Create();
        Response.Write("<script>history.back();</script>");
    }
}
