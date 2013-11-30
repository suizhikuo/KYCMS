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

public partial class system_other_Preview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["categoryId"] != null && Function.CheckInteger(Request.QueryString["categoryId"]))
        {
            LitJS.Text = "<script type=\"text/javascript\" src=\"../../push/"+Request.QueryString["categoryId"]+".js\"></script>";   
        }
    }
}
