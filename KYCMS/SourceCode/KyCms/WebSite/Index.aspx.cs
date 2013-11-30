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

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        B_Create bll = new B_Create();
        string url = bll.GetIndexUrl();
        if (url.ToLower().Trim().IndexOf(".htm") != -1 || url.ToLower().Trim().IndexOf(".html") != -1 || url.ToLower().Trim().IndexOf(".shtml") != -1)
        {
            Response.Redirect(url);
            return;
        }
        Response.Write(bll.GetIndexPage());
        
    }
}
