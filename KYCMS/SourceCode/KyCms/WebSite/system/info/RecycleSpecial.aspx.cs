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
using Ky.BLL.CommonModel;
using Ky.Common;
public partial class system_news_RecycleSpeacil : System.Web.UI.Page
{
    B_InfoOper Bll = new B_InfoOper();
    B_Admin admin = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Special spclBll = new B_Special();
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
        DataTable data = Bll.GetRecycleInfoList("", 3, Pager.CurrentPageIndex, Pager.PageSize, ref total);
        if (data != null)
        {
            gvSpcl.DataSource = data;
            gvSpcl.DataBind();
            Pager.RecordCount = total;
            Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        }       
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvSpcl_RowDataBound(object sender,RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //
        }
    }
    protected void gv_RowCommand(object sender, RepeaterCommandEventArgs e)
    {
        string[] keys = e.CommandArgument.ToString().Split('|');
        int key = int.Parse(keys[0]);        

        if (e.CommandName == "Del")
        {
            spclBll.DeleteComplete(key);
            BindData();
        }
        if (e.CommandName == "Restore")
        {
            int parentId = int.Parse(keys[1]);
            if (parentId != 0)
            {
                B_Special sBll = new B_Special();
                M_Special sModel = sBll.GetSpecial(parentId);
                if (sModel != null && sModel.IsDeleted)
                {
                    Function.ShowSysMsg(0, "<li>父专题尚未还原，请先还原父专题(ID=" + parentId + ").</li><li><a href='javascript:window.history.back(-1);'>返回上一步</a></li>");
                }
            }
            Bll.RestoreRecycle("", 3, key);
            BindData();
        }
    }
    protected void btnDeleteSelectd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvSpcl.Items.Count; i++)
        {
            CheckBox chk = gvSpcl.Items[i].FindControl("chkBox") as CheckBox;
            if (chk != null && chk.Checked)
            {
                Literal lb = gvSpcl.Items[i].FindControl("lbId") as Literal;
                spclBll.DeleteComplete(int.Parse(lb.Text));
            }
        }
        BindData();
    }
}
