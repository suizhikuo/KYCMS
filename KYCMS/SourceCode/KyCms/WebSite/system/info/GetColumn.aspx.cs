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

public partial class system_news_GetColumn : System.Web.UI.Page
{
    protected int ColId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(Request.Form["ColId"]))
        {
            try
            {
                ColId = int.Parse(Request.Form["ColId"]);
            }
            catch { }
        }
        B_Column columnBll = new B_Column();
        M_Column columnModle = ColId == 0 ? null : columnBll.GetColumn(ColId);
        if (columnModle == null)
        {
            return;
        }
        Response.Write(columnModle.InfoPageType + "$" + columnModle.InfoTemplatePath + "$" + columnModle.ChargeType + "$" + columnModle.ChargeHourCount + "$" + columnModle.ChargeViewCount+"$"+columnModle.PointCount+"$"+columnModle.IsAllowComment);
    }
}
