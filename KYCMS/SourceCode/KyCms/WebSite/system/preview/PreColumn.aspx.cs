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
using Ky.Common;

public partial class system_PreColumn : System.Web.UI.Page
{
    int ColId = 0;
    int P = 1;
    B_Column ColumnBll = new B_Column();
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup AdmimGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColId = int.Parse(Request.QueryString["ColId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                P = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
        M_Column columnModel = ColumnBll.GetColumn(ColId);
        if (columnModel == null || columnModel.IsDeleted)
        {
            Function.ShowSysMsg(0, "<li>对不起，你所访问的页面不存在</li>");
            return;
        }
        AdmimGroupBll.Power_Judge(36);
        B_Create bll = new B_Create();
        Response.Write(bll.GetColumnPage(ColId, P));
    }
}
