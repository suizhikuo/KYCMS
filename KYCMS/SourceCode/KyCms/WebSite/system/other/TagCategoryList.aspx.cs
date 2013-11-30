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

public partial class System_Tag_TagCategoryList : System.Web.UI.Page
{
    protected B_TagCategroy Bll = new B_TagCategroy();
    protected B_PowerGroup GroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        LitMsg.Text = "";
        if (!IsPostBack)
        {
            GroupBll.Power_Judge(28); 
            Bind();
        }
    }

    private void Bind()
    {
        DataTable dt = Bll.GetList();
        string[] key = {"TagCategoryId"};
        gvTagCategory.DataKeyNames = key;
        gvTagCategory.DataSource = dt;
        gvTagCategory.DataBind();
    }

    protected void gvTagCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTagCategory.EditIndex = e.NewEditIndex;
        Bind();
    }
    protected void gvTagCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTagCategory.EditIndex = -1;
        Bind();
    }
    protected void gvTagCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        M_TagCategory model = new M_TagCategory();
        int tagCategoryId = (int)gvTagCategory.DataKeys[e.RowIndex].Value;
        TextBox txtName = gvTagCategory.Rows[e.RowIndex].FindControl("txtName") as TextBox;
        string name = txtName.Text.Trim();
        TextBox txtDesc = gvTagCategory.Rows[e.RowIndex].FindControl("txtDesc") as TextBox;
        string desc = txtDesc.Text.Trim();
        if(name.Length==0||name.Length>20)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('Tag类别名称必须填写');</script>";
            return;
        }
        if(desc.Length>100)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('Tag类别描述不能超过100个字');</script>";
            return;
        }
        model.TagCategoryId = tagCategoryId;
        model.Name = name;
        model.Desc = desc;
        Bll.Update(model);
        gvTagCategory.EditIndex = -1;
        Bind();
    }
    protected void gvTagCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int tagCategoryId = (int)gvTagCategory.DataKeys[e.RowIndex].Value;
        Bll.Delete(tagCategoryId);
        gvTagCategory.EditIndex = -1;
        Bind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        M_TagCategory model = new M_TagCategory();
        int tagCategoryId = 0;
        string name = txtName.Text.Trim();
        string desc = txtDesc.Text.Trim();
        if (name.Length == 0 || name.Length > 20)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('Tag类别名称必须填写');</script>";
            return;
        }
        if (desc.Length > 100)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('Tag类别描述不能超过100个字');</script>";
            return;
        }
        model.TagCategoryId = tagCategoryId;
        model.Name = name;
        model.Desc = desc;
        Bll.Add(model);
        
        txtName.Text = "";
        txtDesc.Text = "";
        gvTagCategory.EditIndex = -1;
        Bind();
    }
    protected void gvTagCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver","this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onMouseOut","this.className='tdbg'");
        }
    }
}
