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

public partial class common_GetDownCount : System.Web.UI.Page
{
    B_DownLoad DownLoadBll = new B_DownLoad();
    int Id = 0;
    int Type = 0;
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["type"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["id"]);
                Type = int.Parse(Request.QueryString["type"]);
            }
            catch 
            {
                Response.Write("document.write('" + count + "')");
                return;
            }
            count = DownLoadBll.GetDownCount(Id, Type); 
            Response.Write("document.write('" + count + "')"); 
        }
        else
        {
            Response.Write("document.write('" + count + "')"); 
        }
    }
}
