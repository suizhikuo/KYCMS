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

public partial class common_ReadUserInfo : System.Web.UI.Page
{
    protected B_User bll = new B_User();
    protected DataRow dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(common_ReadUserInfo));
    }

    [AjaxPro.AjaxMethod]
    public DataTable ReadUserInfo(string str)
    {
        if (bll.GetCookie() == null)
        {
            return null;
        }
        else
        {
            int UserId = bll.GetCookie().UserID;
            
            DataTable dt = new DataTable();
            try
            {
                dr = bll.GetUserAllInfo(UserId);
                dt = dr.Table.Copy();
                dt.Clear();
                dt.ImportRow(dr);
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }          
            return dt;
        }
    }
}
