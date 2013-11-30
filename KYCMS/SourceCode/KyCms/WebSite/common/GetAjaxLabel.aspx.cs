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

public partial class common_GetAjaxLabel : System.Web.UI.Page
{
    B_Create CreateBll = new B_Create();
    protected void Page_Load(object sender, EventArgs e)
    {
        string _paramStr = string.Empty;
        int _currId = 0;
        string _type = string.Empty;

        if (!string.IsNullOrEmpty(Request.Form["paramstr"])&&!string.IsNullOrEmpty(Request.Form["currid"])&&!string.IsNullOrEmpty(Request.Form["type"]))
        {
            try
            {
                _paramStr = Request.Form["paramstr"];
                _currId = int.Parse(Request.Form["currid"]);
                _type = Request.Form["type"];
                ResponseValue(_paramStr,_currId,_type);
            }
            catch { }
        }
    }

    private void ResponseValue(string paramStr, int currId, string type)
    {
        if (type.ToLower() == "ch" || type.ToLower() == "col")
        {
            if (type.ToLower() == "ch")
                Response.Write(CreateBll.Ch_GetInfoList_Ajax(paramStr, currId));
            else
                Response.Write(CreateBll.Col_GetInfoList_Ajax(paramStr, currId));
        }
    }
}
