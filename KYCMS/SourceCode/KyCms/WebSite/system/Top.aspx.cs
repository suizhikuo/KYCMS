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
using System.Text;
using Ky.Model;

public partial class System_Top : System.Web.UI.Page
{
    protected string MyControllerStr = string.Empty;

    B_Admin AdminBll = new B_Admin();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        AdminBll.CheckIsLogin();
        AjaxPro.Utility.RegisterTypeForAjax(typeof(System_Top));
       
    }

    [AjaxPro.AjaxMethod]
    public void ClearCache(string str)
    {

        B_Create createBll = new B_Create();
        B_Channel channelBll = new B_Channel();
        B_Column columnBll = new B_Column();
        channelBll.ClearCache();
        columnBll.ClearCache();
        createBll.ClearHashTable();
        GC.Collect();
    }
}
