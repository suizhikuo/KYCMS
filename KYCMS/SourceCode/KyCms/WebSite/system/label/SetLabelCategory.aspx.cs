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
using Ky.Model;
using Ky.BLL;
public partial class System_AddLabelType : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected static string SkipPageUrl = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6);
        if(!IsPostBack)
        {
            SkipPageUrl = Request.ServerVariables["HTTP_REFERER"].ToString();

            if (Request.QueryString["lbCategoryId"] == null)
            {
                BindStyleCategory();
            }
            else
            {
                BindStyleCategory();
                btnSave.Text = "修改类别";
                btnReset.Visible = false;
                B_LbCategory bll = new B_LbCategory();
                if (Request.QueryString["lbCategoryId"].ToString() == "1")
                {
                    dropLabelType.Enabled = false;
                }
                for (int i = 0; i < dropLabelType.Items.Count;i++ )
                {
                    if(dropLabelType.Items[i].Value==Request.QueryString["parentId"].ToString())
                    {
                        dropLabelType.Items[i].Selected = true;
                    }

                    if (dropLabelType.Items[i].Value == Request.QueryString["lbCategoryId"].ToString())
                    {
                        dropLabelType.Items[i].Enabled = false;
                    }

                    DataTable dt = bll.GetListItemByLabelId();
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "ParentID=" + Request.QueryString["lbCategoryId"].ToString() + "";
                    for (int j = 0; j < dropLabelType.Items.Count; j++)
                    {
                        for (int j1 = 0; j1 < dv.Count; j1++)
                        {
                            if (dropLabelType.Items[j].Value == dv[j1]["lbCategoryId"].ToString())
                            {
                                dropLabelType.Items[j].Enabled = false;
                            }
                        }
                    }
                }
                M_LbCategory model = bll.GetLabeCategoryIdData(int.Parse(Request.QueryString["lbCategoryId"].ToString()));
                txtLabelTypeName.Text = model.Name;
                txtExplain.Text = model.Desc;
            }
        }
    }
    private void BindStyleCategory()
    {
        dropLabelType.Items.Clear();
        dropLabelType.Items.Add(new ListItem("新建一级样式", "0"));
        B_LbCategory bll = new B_LbCategory();
        DataTable dt = bll.GetListItemByLabelId();
        foreach (DataRow dr in dt.Rows)
        {
            string colname = dr["Name"].ToString();
            int colid = Convert.ToInt32(dr["LbCategoryID"].ToString());
            int depth = int.Parse(dr["Depth"].ToString());
            for (int i = 0; i < depth; i++)
            {
                colname = "├┄" + colname;
            }
            dropLabelType.Items.Add(new ListItem(colname, colid.ToString()));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            M_LbCategory m_LbCategory = new M_LbCategory();
            m_LbCategory.Name = txtLabelTypeName.Text.Trim();
            m_LbCategory.ParentID = int.Parse(dropLabelType.SelectedValue.ToString());
            m_LbCategory.Desc = txtExplain.Text.Trim();
            B_LbCategory b_Lbcategory = new B_LbCategory();
            B_KyCommon bllCom = new B_KyCommon();
            bool flag = false;
            flag = bllCom.CheckHas(m_LbCategory.Name, "Name", "KyLbCategory");
            if (btnSave.Text == "修改类别")
            {
                m_LbCategory.LbCategoryID=int.Parse(Request.QueryString["lbCategoryId"].ToString());
                B_LbCategory bll = new B_LbCategory();
                bll.Update(m_LbCategory);
                Response.Redirect(SkipPageUrl);
            }
            else
            {
                if (!flag)
                {
                    b_Lbcategory.Add(m_LbCategory);
                    Response.Redirect(SkipPageUrl);
                }
                else
                    Response.Write("<script>alert('己存在此标签名称')</script>");
            }
            
        }
        catch
        {
            Response.Write("<script>alert('操作有误')</script>");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SetLabelCategory.aspx");
    }
    protected void ddlRedirectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(ddlRedirectPage.SelectedValue.ToString());
    }
}
