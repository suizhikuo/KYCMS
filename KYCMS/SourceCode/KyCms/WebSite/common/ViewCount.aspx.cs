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

public partial class common_ViewCount : System.Web.UI.Page
{
    B_SiteCount Bll = new B_SiteCount();
    protected void Page_Load(object sender, EventArgs e)
    {
        Bll.AddDayCount();
        Bll.AddWeekCount();
        Bll.AddMonthCount();
        Bll.AddYearCount();
    }
}
