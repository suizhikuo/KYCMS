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
using Ky.BLL.CommonModel;
using Ky.SQLServerDAL;
public partial class System_AddStyleType : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_InfoModel InfoModelBll = new B_InfoModel();
    protected static string SkipPageUrl = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(10);
        if(!IsPostBack)
        {
            SkipPageUrl = Request.ServerVariables["HTTP_REFERER"].ToString();

            if (Request.QueryString["styleCategoryId"] == null)
            {
                BindStyleCategory();
            }
            else
            {
                int styleCategoryId;
                btnSave.Text = "修改样式";
                btnReset.Visible = false;
                styleCategoryId = int.Parse(Request.QueryString["styleCategoryId"].ToString());
                BindStyleCategory();

                B_StyleCategory bll = new B_StyleCategory();
                M_StyleCategory model = bll.GetUpdateData(styleCategoryId);
                int parentId = model.ParentID;
                for (int i = 0; i < dropType.Items.Count;i++)
                {
                    if (dropType.Items[i].Value.ToString() == parentId.ToString())
                        dropType.Items[i].Selected = true;
                    if (dropType.Items[i].Value.ToString() == Request.QueryString["styleCategoryId"].ToString())
                        dropType.Items[i].Enabled = false;
                }
                DataTable dt = bll.GetListItemByStyleId();
                DataView dv = dt.DefaultView;
                dv.RowFilter = "ParentID=" + Request.QueryString["styleCategoryId"].ToString() + "";
                for (int j = 0; j < dropType.Items.Count; j++)
                {
                    for (int j1 = 0; j1 < dv.Count; j1++)
                    {
                        if (dropType.Items[j].Value == dv[j1]["styleCategoryId"].ToString())
                        {
                            dropType.Items[j].Enabled = false;
                        }
                    }
                }

                txtStyleTypeName.Text = model.Name;
                txtExplain.Text = model.Desc;
            }
            
        }
    }

    private void BindStyleCategory()
    {
        dropType.Items.Clear();
        dropType.Items.Add(new ListItem("新建一级样式", "0"));
        B_StyleCategory bll = new B_StyleCategory();
        DataTable dt = bll.GetListItemByStyleId();
        foreach (DataRow dr in dt.Rows)
        {
            string colname = dr["Name"].ToString();
            int colid = Convert.ToInt32(dr["StyleCategoryID"].ToString());
            int depth = int.Parse(dr["Depth"].ToString());
            for (int i = 0; i < depth; i++)
            {
                colname = "├┄" + colname;
            }
            dropType.Items.Add(new ListItem(colname, colid.ToString()));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //try
        //{
            M_StyleCategory model = new M_StyleCategory();
            model.Name = txtStyleTypeName.Text.Trim();
            model.ParentID = int.Parse(dropType.SelectedValue.ToString());
            model.Desc = txtExplain.Text.Trim();
            B_StyleCategory b_styleCategory = new B_StyleCategory();
            B_KyCommon bllCom = new B_KyCommon();
            bool flag = false;
            flag = bllCom.CheckHas(model.Name, "Name", "KyStyleCategory");
            if (btnSave.Text == "修改样式")
            {
                    model.StyleCategoryID = int.Parse(Request.QueryString["styleCategoryId"].ToString());
                    b_styleCategory.Update(model);
                    Response.Redirect(SkipPageUrl);
            }
            else
            {
                if (!flag)
                {
                    b_styleCategory.Add(model);
                    Response.Redirect(SkipPageUrl);
                }
                else
                    Response.Write("<script>alert('此样式名称已存在')</script>");
            }            
        //}
        //catch
        //{
        //    Response.Write("文件出错!!!");
        //}
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddStyleType.aspx");
    }
    protected void ddlRedirectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(ddlRedirectPage.SelectedValue.ToString());
    }
}
