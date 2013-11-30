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

public partial class system_news_RecycleChnl : System.Web.UI.Page
{
    B_InfoOper Bll = new B_InfoOper();
    B_Channel chlBll = new B_Channel();
    B_Admin admin = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {        
        AdminGroupBll.Power_Judge(37);
        LitRecycleNav.Text = Bll.BuildLinkString();
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        int total = 0;
        DataTable data = Bll.GetRecycleInfoList("", 1, Pager.CurrentPageIndex, Pager.PageSize, ref total);
        if (data != null)
        {
            gvChnl.DataSource = data;
            gvChnl.DataBind();
            Pager.RecordCount = total;
            Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        }        
    }
    protected void gvChnl_RowDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //
        }
    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gv_RowCommand(object sender, RepeaterCommandEventArgs e)
    {
        int key = int.Parse(e.CommandArgument.ToString());

        if (e.CommandName == "Del")
        {
            chlBll.CompleteDelete(key);
            BindData();
            chlBll.ClearCache();
        }
        if (e.CommandName == "Restore")
        {
            Bll.RestoreRecycle("", 1, key);
            BindData();
            chlBll.ClearCache();
            Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();</script>");
        }
    }

    protected void btnDeleteSelectd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvChnl.Items.Count; i++)
        {
            CheckBox chk = gvChnl.Items[i].FindControl("chkBox") as CheckBox;
            if (chk != null && chk.Checked)
            {
                Literal lb = gvChnl.Items[i].FindControl("lbId") as Literal;
                chlBll.CompleteDelete(int.Parse(lb.Text));
            }
        }
        BindData();
    }
}
