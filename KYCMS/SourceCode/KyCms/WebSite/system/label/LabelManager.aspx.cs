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
using System.Text.RegularExpressions;

public partial class System_Label_LabelManager : System.Web.UI.Page
{

    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Style bll = new B_Style();
    protected int parentId=0;
    #region 页面加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6);
        if (!IsPostBack)
        {
            StyleBind();
        }
    }
    #endregion


    #region 绑定标签分类表中ParentId所对应的数据
    private void StyleBind()
    {
        int lbCategoryId;
        B_LbCategory bll = new B_LbCategory();
        if (Request.QueryString["parentId"] == null)
        {
            parentId = 0;
            lbCategoryId = 0;
        }
        else
        {
            parentId = int.Parse(Request.QueryString["parentId"].ToString());
            lbCategoryId = int.Parse(Request.QueryString["lbCategoryId"].ToString());
        }
        repStyle.DataSource = bll.GetLabelCategoryList(parentId);
        repStyle.DataBind();
        int recordCount = 0;
        LabelContentBind(lbCategoryId, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, ref recordCount);
        AspNetPager1.RecordCount = recordCount;
        AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", AspNetPager1.CurrentPageIndex, AspNetPager1.PageCount, AspNetPager1.RecordCount, AspNetPager1.PageSize);
    }
    #endregion

    
    #region 绑定标签内容中LbCategoryId所对应的记录
    private void LabelContentBind(int labelCagegoryId, int cursorPage, int pageSize, ref int recordCount)
    {
        B_LabelContent bll = new B_LabelContent();
        repLabelContent.DataSource = bll.GetLbCategoryIdList(labelCagegoryId,cursorPage,pageSize,ref recordCount);
        repLabelContent.DataBind();
    }
    #endregion 


    #region 下拉列表框页面跳转
    protected void ddlRedirectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(ddlRedirectPage.SelectedValue.ToString());
    }
    #endregion

    protected void repLabelContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lnkBtn = e.Item.FindControl("linkbtnDelete") as LinkButton;
            if (lnkBtn.Enabled != false)
            {
                lnkBtn.Attributes.Add("onclick", "return confirm('你确定要删除吗？')");
            }
        }
    }

    #region 删除标签分类表中id所对应的记录
    protected void repStyle_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        HiddenField hddenLbCategoryId = e.Item.FindControl("hiddenLbCategoryId") as HiddenField;
        B_LbCategory bll = new B_LbCategory();
        if (hddenLbCategoryId.Value.ToString() != "1")
        {
            bll.Delete(int.Parse(hddenLbCategoryId.Value.ToString()));
            StyleBind();
        }
        else
        {
            Response.Write("<script>alert('不能删除系统定义的标签类别')</script>");
        }
    }
    #endregion


    #region 删除标签内容表中id所对应的记录
    protected void repLabelContent_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        B_LabelContent bll = new B_LabelContent();
        if(e.CommandName=="Delete")
        {
            Label lblLabelCategoryId = e.Item.FindControl("lblLabelCategoryId") as Label;
            bll.Delete(lblLabelCategoryId.Text.ToString());        
        }
        if (e.CommandName == "DeleteAll")
        {
            string strLabelCategoryId = string.Empty;
            foreach (RepeaterItem rowview in repLabelContent.Items)
            {
                CheckBox _cb = rowview.FindControl("CheckBox1") as CheckBox;
                bool isChecked = _cb.Checked;
                Label lblid = rowview.FindControl("lblLabelCategoryId") as Label;
                if (isChecked)
                {
                    strLabelCategoryId +=  lblid.Text+ ",";
                }
            }
            if (strLabelCategoryId.EndsWith(","))
            {
                strLabelCategoryId = strLabelCategoryId.Substring(0, strLabelCategoryId.Length - 1);
            }
            if (strLabelCategoryId == string.Empty || strLabelCategoryId.Trim().Length == 0)
            {
                Function.ShowSysMsg(0, "<li>请选择要删除标签所对应的复选框</li><li><a href='javascript:history.back()'>返回上一页</a></li>");  
            }
            else
                bll.Delete(strLabelCategoryId.ToString());
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
        Response.Redirect("LabelSearch.aspx?labelName=" + txtKeyword.Text.ToString());
    }

    public string ModifyStyle(object paramStr)
    {
        string listStyle = string.Empty;
        string modelId = string.Empty;
        GetParamValue(paramStr.ToString(), "liststyle", ref listStyle);
        GetParamValue(paramStr.ToString(), "modelid", ref modelId);
        if (listStyle != string.Empty && modelId != string.Empty)
        {
            DataTable dt = bll.GetStyleList(bll.StyleIDGetStylegoryId(int.Parse(listStyle.ToString())));
            DataRow[] dr = dt.Select("StyleId=" + int.Parse(listStyle.ToString()));
            if (dr.Length == 0)
            {
                return string.Empty;
            }
            else
                return "<a href=\"SetStyle.aspx?StyleId=" + listStyle + "&modelId=" + modelId + "\">修改样式</a> | ";
        }
        else
        {
            return "";
        }
    }

    #region 取得对应函数所需参数的值
    private void GetParamValue(string paramStr, string paramName, ref string paramValue)
    {
        MatchCollection mc = Regex.Matches(paramStr, @"{\$Ky.*?\b" + paramName + @"=""(.*?)"".*?/}", RegexOptions.IgnoreCase);
        if (mc.Count > 0 && mc[0].Groups.Count > 1 && mc[0].Groups[1].Value != "")
        {
            paramValue = mc[0].Groups[1].Value.ToLower();
        }
    }
    #endregion
}
