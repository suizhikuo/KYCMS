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
using Ky.Common;

public partial class system_collection_CollectionAddressManager : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_CollectionAddress CollectionAddressBll = new B_CollectionAddress();
    B_Collection CollectionBll = new B_Collection();
    int recordCount = 0;
    public static bool state = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        if(!IsPostBack)
        {
            BindCollection();
            PageBind();
        }
    }

    private void PageBind()
    {
        int collid = 0;
        if (ddlCollection.SelectedValue != null && ddlCollection.SelectedValue.Length != 0)
        {
            collid = int.Parse(ddlCollection.SelectedValue);
        }
        BindCollectionAddress(collid, state, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, ref recordCount);
        AspNetPager1.RecordCount = recordCount;
        AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", AspNetPager1.CurrentPageIndex, AspNetPager1.PageCount, AspNetPager1.RecordCount, AspNetPager1.PageSize);
    }

    private void BindCollectionAddress(int collid,bool state,int pageIndex,int pagesize,ref int recordCount)
    {
        DataTable dt = CollectionAddressBll.GetCollIdByList(collid, state, pageIndex, pagesize, ref recordCount);
        repCollectionAddress.DataSource = dt;
        repCollectionAddress.DataBind();
    }

    private void BindCollection()
    {
        ddlCollection.DataSource = CollectionBll.GetList();
        ddlCollection.DataTextField = "ObjectName";
        ddlCollection.DataValueField = "Id";
        ddlCollection.DataBind();
    }

    protected void ddlCollection_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageBind();
    }
    protected void linkBtnSecceed_Click(object sender, EventArgs e)
    {
        state = true;
        PageBind();
    }
    protected void linkBtnBaulk_Click(object sender, EventArgs e)
    {
        state = false;
        PageBind();
        PageBind();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        PageBind();
    }

    public string StateStr(object obj)
    {
        if (obj.ToString() == "True")
            return "采集成功";
        else
            return "采集失败";
    }
    protected void btnDelSecceed_Click(object sender, EventArgs e)
    {
         int collid = int.Parse(ddlCollection.SelectedValue);
         if (CollectionAddressBll.DeleteCollId(collid, true))
         {
             PageBind();
             Function.ShowSysMsg(1, "<li>删除成功</li><li><a href='collection/CollectionAddressManager.aspx'>返回上一页</a></li>");
         }
         else
         {
             PageBind();
             Function.ShowSysMsg(0, "<li>删除失败</li><li><a href='collection/CollectionAddressManager.aspx'>返回上一页</a></li>");
         }
    }
    protected void btnDelBaulk_Click(object sender, EventArgs e)
    {
        int collid = int.Parse(ddlCollection.SelectedValue);
        if (CollectionAddressBll.DeleteCollId(collid, false))
        {
            PageBind();
            Function.ShowSysMsg(1, "<li>删除成功</li><li><a href='collection/CollectionAddressManager.aspx'>返回上一页</a></li>");
        }
        else
        {
            PageBind();
            Function.ShowSysMsg(0, "<li>删除失败</li><li><a href='collection/CollectionAddressManager.aspx'>返回上一页</a></li>");
        }
    }
    protected void linBtnkCollection_Click(object sender, EventArgs e)
    {
         int collid = int.Parse(ddlCollection.SelectedValue);
        Response.Redirect("Collection.aspx?id="+collid+"&type=collection");
    }
}
