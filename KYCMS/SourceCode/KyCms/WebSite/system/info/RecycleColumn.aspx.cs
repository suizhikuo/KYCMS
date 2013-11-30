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

public partial class system_news_RecycleCol : System.Web.UI.Page
{
    B_InfoOper Bll = new B_InfoOper();
    B_Column colBll = new B_Column();
    B_Admin admin = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Channel channel = new B_Channel();
    protected void Page_Load(object sender, EventArgs e)
    {                
        AdminGroupBll.Power_Judge(37);
        LitRecycleNav.Text = Bll.BuildLinkString();
        LitMsg.Text = "";
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        int total = 0;
        DataTable data = Bll.GetRecycleInfoList("", 2, Pager.CurrentPageIndex, Pager.PageSize, ref total);
        if (data != null)
        {
            gvCol.DataSource = data;
            gvCol.DataBind();
            Pager.RecordCount = total;
            Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        }       
    }
    protected void gvCol_RowDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType ==  ListItemType.AlternatingItem||e.Item.ItemType ==  ListItemType.Item)
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
        string[] args = e.CommandArgument.ToString().Split('|');
        int key = int.Parse(args[0]);       

        if (e.CommandName == "Del")
        {
            colBll.CompleteDelete(key);
            BindData();
            colBll.ClearCache();
        }

        if (e.CommandName == "Restore")
        {
            int chid = int.Parse(args[1]);
            int colParentId = int.Parse(args[2]);
            M_Channel channelModel = channel.GetChannel(chid,1);
            if (channelModel != null)
            {
                Function.ShowSysMsg(0, "<li>此栏目所属频道尚未还原,请先还原该频道(ID=" + chid + ").</li><li><a href='info/RecycleChannel.aspx'>频道回收站</a></li><li><a href='javascript:window.history.back(-1);'>返回上一步</a></li>");
            }
            if (colParentId != 0)
            {
                M_Column parentColumn = colBll.GetColumn(colParentId);
                if (parentColumn == null || parentColumn.IsDeleted)
                {
                    Function.ShowSysMsg(0, "<li>此栏目所属父栏目尚未还原,请先还原父栏目(ID=" + colParentId + ").<li><li><a href='javascript:window.history.back(-1);'>返回上一步</a></li>");
                }
            }

            Bll.RestoreRecycle("", 2, key);
            BindData();
            colBll.ClearCache();
            Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();</script>");
        }
    }
    protected void btnDeleteSelectd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvCol.Items.Count; i++)
        {
            CheckBox chk = gvCol.Items[i].FindControl("chkBox") as CheckBox;
            if (chk != null && chk.Checked)
            {
                Literal lb = gvCol.Items[i].FindControl("lbId") as Literal;
                colBll.CompleteDelete(int.Parse(lb.Text));
            }
        }
        BindData();
    }
}
