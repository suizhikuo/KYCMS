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
using Ky.SQLServerDAL;
using System.Data.SqlClient;

public partial class System_Label_GetStyleContent : System.Web.UI.Page
{
    int StyleId = 0;
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(10);
        Response.Cache.SetNoStore();
        if (Request.QueryString["StyleId"] != null && Request.QueryString["StyleId"] != "")
        {
            try
            {
                StyleId = int.Parse(Request.QueryString["StyleId"]);
            }
            catch{}
        }
        if(StyleId==0)
        {
            return;
        }
        B_Style bll = new B_Style();
        DataTable dt = bll.GetStyleList(bll.StyleIDGetStylegoryId(StyleId));
        DataRow[] dr = dt.Select("StyleId=" + StyleId);
        if (dr.Length == 0)
        {
            return;
        }
        Response.Write(dr[0]["Content"].ToString());
        //

    }
}
