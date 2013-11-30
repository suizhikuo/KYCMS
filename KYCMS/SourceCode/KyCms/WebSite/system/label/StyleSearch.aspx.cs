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
using Ky.Model;

public partial class system_label_StyleSearch : System.Web.UI.Page
{
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6);
        StyleBind();
    }
    #region 绑定标签分类表中ParentId所对应的数据
    private void StyleBind()
    {
        string labelName;
        labelName = "%" + Request.QueryString["styleName"].ToString() + "%";
        int recordCount = 0;
        LabelContentBind(labelName, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, ref recordCount);
        AspNetPager1.RecordCount = recordCount;
        AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", AspNetPager1.CurrentPageIndex, AspNetPager1.PageCount, AspNetPager1.RecordCount, AspNetPager1.PageSize);
    }
    #endregion

    #region 绑定标签内容中LbCategoryId所对应的记录
    private void LabelContentBind(string labelName, int cursorPage, int pageSize, ref int recordCount)
    {
        B_Style bll = new B_Style();
        repLabelContent.DataSource = bll.GetStyleNameList(labelName, cursorPage, pageSize, ref recordCount);
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
        Label lbId = e.Item.FindControl("lbStyleId") as Label;
        int styleId = int.Parse(lbId.Text);
        B_Style bll_style = new B_Style();
        bll_style.Delete(styleId);
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

    public string Get_Model_Name(object id)
    {
        if (id != null)
        {
            //string chName = B_SiteInfo.GetModelNameById(int.Parse(id.ToString()));
            M_InfoModel infoModel = InfoModelBll.GetModel((int)id);
            if (infoModel == null)
                return "通用标签";
            return infoModel.ModelName;

        }
        else
        {
            return "";
        }
    }
}
