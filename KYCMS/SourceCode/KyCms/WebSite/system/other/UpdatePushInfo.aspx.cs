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

public partial class system_other_UpdatePushInfo : System.Web.UI.Page
{
    B_Ad AdBll = new B_Ad();
    B_Create CreateBll = new B_Create();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["adid"] != null && Request.QueryString["ReturnUrl"] != null)
        {
            int adid = Function.CheckNumber(Request.QueryString["adid"]) ? int.Parse(Request.QueryString["adid"]) : 0;
            M_Ad model = AdBll.GetModel(adid);
            if (model != null)
            {
                model.HitCount += 1;
                AdBll.Update(model);
            }
            string refer = Request.QueryString["ReturnUrl"].ToString() != "" ? Request.QueryString["ReturnUrl"] : CreateBll.GetIndexUrl();
            Response.Redirect(refer);
        }
    }
}
