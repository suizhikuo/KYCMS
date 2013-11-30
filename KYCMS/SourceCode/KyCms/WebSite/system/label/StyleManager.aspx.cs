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


public partial class System_Label_StyleManager : System.Web.UI.Page
{
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(10);
        if (!IsPostBack)
        {            
            ModelBind();    //绑定模型

            int parentId;
            if (Request.QueryString["parentId"] == null)
            {
                parentId = 0;
            }
            else
            {
                try
                {
                    parentId = int.Parse(Request.QueryString["parentId"]);
                }
                catch
                {
                    parentId = 0;
                }

            }
            StyleCategory(parentId);
        }
        else
        {

        }
    }

    private void StyleCategory(int parentId)
    {
        DataTable dt;
        int styleCategoryId;
        B_Style bll = new B_Style();
        dt = bll.StyleCategory_GetList(parentId);
        repStyleCategory.DataSource = dt;
        repStyleCategory.DataBind();
        if (Request.QueryString["parentId"] == null)
        {
            styleCategoryId = 0;
        }
        else
        {
            try
            {
                styleCategoryId = int.Parse(Request.QueryString["parentId"]);
            }
            catch
            {
                styleCategoryId = 0;
            }
        }
        StyleBind(styleCategoryId);
    }

    /// <summary>
    /// 绑定样式的值
    /// </summary>
    private void StyleBind(int styleId)
    {
        B_Style bll_Style = new B_Style();
        repStyle.DataSource = bll_Style.GetStyleList(styleId);
        repStyle.DataBind();
    }

    //获得模型列表
    private void ModelBind()
    {
        repModelList.DataSource = InfoModelBll.GetList();
        repModelList.DataBind();
    }

    public string Get_Model_Name(object id)
    {
        if (id != null)
        {
            //string chName = B_SiteInfo.GetModelNameById(int.Parse(id.ToString()));
           M_InfoModel infoModel=InfoModelBll.GetModel((int)id);
           if (infoModel == null)
               return "通用标签";
           return infoModel.ModelName;

        }
        else
        {
            return "";
        }
    }

    protected void ddlRedirectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(ddlRedirectPage.SelectedValue.ToString());
    }

    protected void repStyle_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        Label lbId = e.Item.FindControl("lbStyleId") as Label;
        int styleId = int.Parse(lbId.Text);
        B_Style bll_style = new B_Style();
        bll_style.Delete(styleId);
        if (Request.QueryString["parentId"] == null || Request.QueryString["parentId"].ToString().Length==0)
            StyleBind(0);
        else
            StyleBind(int.Parse(Request.QueryString["parentId"]));
    }
    protected void repStyleCategory_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {

        HiddenField hidden = (HiddenField)e.Item.FindControl("StyleCategoryId");
        B_StyleCategory bll = new B_StyleCategory();
        bll.Delete(int.Parse(hidden.Value.ToString()));
        StyleCategory(0);
    }
    protected void btnGoSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("StyleSearch.aspx?styleName=" + txtKeyword.Text.ToString());
    }
}
