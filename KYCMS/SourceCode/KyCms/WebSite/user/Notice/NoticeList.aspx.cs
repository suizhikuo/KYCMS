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

public partial class user_Notice_NoticeList : System.Web.UI.Page
{
    private B_Notice BNotice = new B_Notice();
    private M_Notice model = new M_Notice();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataBaseList();
        }
    }

    private void DataBaseList()
    {

        string WhereStr = " where IsState='审核通过' and datediff(day,OverdueDate,getdate())<=0";

        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }
        DataSet ds = BNotice.GetList(int.Parse(P), Pager.PageSize, WhereStr);
        Repeater1.DataSource = ds.Tables[0].DefaultView;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0];
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }
}
