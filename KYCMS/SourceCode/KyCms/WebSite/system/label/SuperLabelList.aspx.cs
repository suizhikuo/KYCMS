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
using Ky.BLL.CommonModel;
using Ky.Common;
using Ky.Model;
using Ky.BLL;

public partial class system_label_SuperLabelList : System.Web.UI.Page
{
    private B_SuperLabel BSuperLabel = new B_SuperLabel();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(9);
        if (!Page.IsPostBack)
        {
            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }

        DataSet ds = BSuperLabel.GetList(int.Parse(P), Pager.PageSize);
        Repeater1.DataSource = ds.Tables[0].DefaultView;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    /// <summary>
    /// 删除单一记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BSuperLabel.Delete(id);

            DataBaseList();
        }
    }
}
