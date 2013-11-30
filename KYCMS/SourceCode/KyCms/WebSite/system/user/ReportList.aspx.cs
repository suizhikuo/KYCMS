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


public partial class system_other_ReportList : System.Web.UI.Page
{
    protected B_Report ReportBll = new B_Report();
    protected int P = 1;
    protected int Type = -1;
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                P = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
        {
            try
            {
                Type = int.Parse(Request.QueryString["Type"]);
            }
            catch { }
        }
        if (!IsPostBack)
        {
            AdminGroupBll.Power_Judge(32);
            Bind();
        }
    }
    private void Bind()
    {
        string whereStr = "1=1";
        if (Type == 0)
        {
            whereStr = "IsComplete=0";
        }else if(Type==1)
            whereStr = "IsComplete=1";
        else if(Type==2)
            whereStr = "IsComplete=2";
        int recordCount = 0;
        DataTable dt = ReportBll.GetList(P, Pager.PageSize, whereStr, ref recordCount);
        repReport.DataSource = dt;
        repReport.DataBind();
        Pager.RecordCount = recordCount;
        Pager.CurrentPageIndex = P;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    protected string GetStatus(object isComplete)
    {
        if (isComplete != null && isComplete.ToString() != string.Empty)
        {
            switch ((int)isComplete)
            {
                default:
                case 0: return "未处理";
                case 1: return "已处理";
                case 2: return "已关闭";
            }
        }
        else
        {
            return "";
        }
    }

    protected void repReport_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        int reportId = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "set")
        {
            ReportBll.SetStatus(reportId, 1);
        }
        else if (e.CommandName == "close")
        {
            ReportBll.SetStatus(reportId, 2);
        }
        else if (e.CommandName == "delete")
        {
            ReportBll.Delete(reportId);
        }
        Bind();
    }

    protected bool GetEnabled(object isComplete)
    {
        if (isComplete != null && isComplete.ToString() != string.Empty)
        {
            if ((int)isComplete == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < repReport.Items.Count; i++)
        {
            Literal ltId = (Literal)repReport.Items[i].FindControl("litId");
            int reportId = int.Parse(ltId.Text);
            CheckBox cb = (CheckBox)repReport.Items[i].FindControl("chk");
            if (cb.Checked)
            {
                ReportBll.Delete(reportId);
            }
        }
        Bind();
    }
}
