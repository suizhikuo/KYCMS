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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;

public partial class common_Linkage : System.Web.UI.UserControl
{
    protected B_Dictionary BDictionary = new B_Dictionary();

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(common_Linkage));
    }

    [AjaxPro.AjaxMethod]
    public DataSet GetLinkageDs(string ParentId, string SelName)
    {
        DataTable dt = BDictionary.GetDictionary(int.Parse(ParentId));
        dt.TableName = "Table0";

        DataTable dt1 = new DataTable();
        dt1.TableName = "Table1";
        dt1.Columns.Add(new DataColumn("SelName", typeof(string)));
        
        DataRow dr = dt1.NewRow();
        dr[0] = SelName;
        dt1.Rows.Add(dr);


        DataSet ds = new DataSet();
        ds.Tables.Add(dt.Copy());
        ds.Tables.Add(dt1.Copy());

        return ds;
    }
}
