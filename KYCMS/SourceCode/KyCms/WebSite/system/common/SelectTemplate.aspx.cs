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

public partial class System_common_SelectTemplate : System.Web.UI.Page
{
    public string ControlId = string.Empty;
    public string StartPath = string.Empty;
    protected B_Admin AdminBll = new B_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        if (Request.QueryString["ControlId"] != null && Request.QueryString["ControlId"] != "")
        {
            ControlId = Request.QueryString["ControlId"];
        }
        if (Request.QueryString["StartPath"] != null && Request.QueryString["StartPath"] != "")
        {
            StartPath = Request.QueryString["StartPath"];
        }
        if (ControlId != "" && StartPath != "")
        {
            ControlId = Function.UrlEncode(ControlId);
            StartPath = Function.UrlEncode(StartPath);
        }
        else
        {
            Response.Write("<script>alert('参数获取不正确');window.opener=null;window.close();</script>");
        }
    }
}
