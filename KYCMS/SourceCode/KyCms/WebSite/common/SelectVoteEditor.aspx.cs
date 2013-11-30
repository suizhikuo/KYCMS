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
using System.Text.RegularExpressions;

public partial class common_SelectVoteEditor : System.Web.UI.Page
{
    private B_LabelContent bll = new B_LabelContent();
    protected int page = 1;
    private B_Create BCreate = new B_Create();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = bll.GetLabelList();

        DataTable dt1 = new DataTable();

        dt1.Columns.Add(new DataColumn("LabelName", typeof(string)));

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Regex.IsMatch(dt.Rows[i]["Content"].ToString(), @"\bid=[""|'']vote[""|'']", RegexOptions.IgnoreCase))
                {
                    DataRow dr = dt1.NewRow();
                    dr[0] = dt.Rows[i]["Name"].ToString();
                    dt1.Rows.Add(dr);
                }
            }
        }

        dt.Clear();
        dt.Dispose();

        if (!string.IsNullOrEmpty(Request.QueryString["page"]))
        {
            try
            {
                page = int.Parse(Request.QueryString["page"]);
            }
            catch { }
        }

        #region 分页
        int PageSize = 33;
        int DtCount = dt1.Rows.Count;

        string MyLitPage = "";
        int TatalPage;

        if (DtCount % PageSize == 0)
        {
            TatalPage = DtCount / PageSize;
        }
        else
        {
            TatalPage = (DtCount / PageSize) + 1;
        }

        MyLitPage += "<table align=\"center\" cellpadding=\"2\"><tr><td>总记录：" + DtCount + "条</td><td>每页：" + PageSize + "条</td><td>当前：" + page + "/" + TatalPage + "</td>";

        if (page == 1)
        {
            MyLitPage += "<td>首页</td>";
        }
        else
        {
            MyLitPage += "<td><a href=\"SelectVoteEditor.aspx?page=1\">首页</a></td>";
        }

        if (page > 1)
        {
            MyLitPage += "<td><a href=\"SelectVoteEditor.aspx?page=" + (page - 1) + "\">上一页</a></td>";
        }
        else
        {
            MyLitPage += "<td>上一页</td>";
        }

        if (page == (TatalPage))
        {
            MyLitPage += "<td>下一页</td><td>尾页</td>";
        }
        else
        {
            MyLitPage += "<td><a href=\"SelectVoteEditor.aspx?page=" + (page + 1) + "\">下一页</a><td><a href=\"SelectVoteEditor.aspx?page=" + TatalPage + "\">尾页</a></td></td>";
        }

        MyLitPage += "</tr></table>";

        Lit_Page.Text = MyLitPage;

        DataList1.DataSource = BCreate.GetPagedTable(dt1, page, PageSize);
        DataList1.DataBind();
        #endregion

        dt1.Clear();
        dt1.Dispose();

    }
}
