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

public partial class system_Switch : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckIsLogin();
    }
}
