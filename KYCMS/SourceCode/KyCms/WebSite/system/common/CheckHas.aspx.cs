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

public partial class system_common_CheckHas : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string input = string.Empty;
        string fileldName = string.Empty;
        string tableName = string.Empty;
        if(!string.IsNullOrEmpty(Request.Form["Input"]))
        {
            input = Request.Form["Input"];
        }
         if(!string.IsNullOrEmpty(Request.Form["FileldName"]))
        {
            fileldName = Request.Form["FileldName"];
        }
         if(!string.IsNullOrEmpty(Request.Form["TableName"]))
        {
            tableName = Request.Form["TableName"];
        }
        if(fileldName==string.Empty||tableName==string.Empty)
        {
            return;
        }
        B_KyCommon kycommonBll = new B_KyCommon();
        if (kycommonBll.CheckHas(input, fileldName, tableName))
        {
            Response.Write("1");
        }
        else
        {
            Response.Write("0");
        }
    }
}
