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

public partial class system_collection_PreCode : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
    }
}
