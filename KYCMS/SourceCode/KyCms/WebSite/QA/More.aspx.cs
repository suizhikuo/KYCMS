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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class QA_More : System.Web.UI.Page
{   
    string whereStr = "parentId=0";
    B_Feedback feedback = new B_Feedback();
    B_User userBll = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        string qryAuthor = Request.QueryString["author"];
        string qryState = Request.QueryString["state"];
        if (!string.IsNullOrEmpty(qryAuthor))
        {
            string decodeAuthor = Function.UrlDecode(qryAuthor).Replace("'", "''");
            whereStr = " parentId<>0 and author='" + decodeAuthor + "'";
        }
        if (!string.IsNullOrEmpty(qryState))
        {
            string state = "0";
            if (qryState == "1")
            { state = "1"; }
            whereStr = " parentId=0 and state=" + state;
        }
        else
        { Response.Redirect("Index.aspx"); }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    void BindData()
    {
        DataSet data = feedback.GetList(Pager.PageSize,Pager.CurrentPageIndex,whereStr);
        DataTable content = data.Tables[0];
        DataTable count = data.Tables[1];
        rptContent.DataSource = content;
        rptContent.DataBind();
        Pager.RecordCount = Convert.ToInt32(data.Tables[1].Rows[0][0]);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }
}
