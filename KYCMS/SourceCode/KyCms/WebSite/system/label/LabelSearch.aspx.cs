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

public partial class system_label_LabelSearch : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6);
        if (!IsPostBack)
        {
            StyleBind();
        }
    }

    #region 绑定标签分类表中ParentId所对应的数据
    private void StyleBind()
    {
        string labelName;
        labelName = "%" + Request.QueryString["labelName"].ToString() + "%";
        int recordCount = 0;
        LabelContentBind(labelName, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, ref recordCount);
        AspNetPager1.RecordCount = recordCount;
        AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", AspNetPager1.CurrentPageIndex, AspNetPager1.PageCount, AspNetPager1.RecordCount, AspNetPager1.PageSize);
    }
    #endregion

    #region 绑定标签内容中LbCategoryId所对应的记录
    private void LabelContentBind(string labelName, int cursorPage, int pageSize, ref int recordCount)
    {
        B_LabelContent bll = new B_LabelContent();
        repLabelContent.DataSource = bll.GetLbCategoryNameList(labelName, cursorPage, pageSize, ref recordCount);
        repLabelContent.DataBind();
    }
    #endregion 

    #region 下拉列表框页面跳转
    protected void ddlRedirectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(ddlRedirectPage.SelectedValue.ToString());
    }
    #endregion


    #region 删除标签内容表中id所对应的记录
    protected void repLabelContent_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        B_LabelContent bll = new B_LabelContent();
        if (e.CommandName == "Delete")
        {
            Label lblLabelCategoryId = e.Item.FindControl("lblLabelCategoryId") as Label;
            bll.Delete(lblLabelCategoryId.Text.ToString());
        }
        StyleBind();
    }
    #endregion


    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        StyleBind();
    }

    protected void btnGoSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("LabelSearch.aspx");
    }
    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        B_LabelContent bll = new B_LabelContent();
        string strLabelCategoryId = string.Empty;
        foreach (RepeaterItem rowview in repLabelContent.Items)
        {

            CheckBox _cb = rowview.FindControl("CheckBox1") as CheckBox;
            bool isChecked = _cb.Checked;
            Label lblid = rowview.FindControl("lblLabelCategoryId") as Label;
            if (isChecked)
            {
                strLabelCategoryId += lblid.Text + ",";
            }
        }
        if (strLabelCategoryId.EndsWith(","))
        {
            strLabelCategoryId = strLabelCategoryId.Substring(0, strLabelCategoryId.Length - 1);
        }
        bll.Delete(strLabelCategoryId.ToString());
        StyleBind();
    }
}
