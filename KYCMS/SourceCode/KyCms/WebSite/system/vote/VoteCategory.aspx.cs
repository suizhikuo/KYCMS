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
using Ky.Common;
public partial class system_news_VoteCategory : System.Web.UI.Page
{
    B_VoteCategory bll = new B_VoteCategory();
    M_VoteCategory model = new M_VoteCategory();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(11);
        if (!IsPostBack)
        {      
            BindCate();
        }
    }

    /// <summary>
    /// 绑定分类
    /// </summary>
    void BindCate()
    {
        gvCate.DataSource = bll.GetList();
        gvCate.DataBind();
    }

    /// <summary>
    /// 新增分类
    /// </summary>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>分类名称不能为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        
        model.Name = txtName.Text.Trim();
        bll.Add(model);
        txtName.Text = "";
        BindCate();
    }

    /// <summary>
    /// 设置鼠标样式
    /// </summary>
    protected void gvCate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbg'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
        }
    }

    /// <summary>
    /// 修改
    /// </summary>
    protected void gvCate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtName = (TextBox)gvCate.Rows[e.RowIndex].FindControl("txtNewName");
        if (txtName.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>分类名称不能为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        model.Name = txtName.Text.Trim();
        model.CategoryId = int.Parse(gvCate.DataKeys[e.RowIndex].Value.ToString());
        bll.Update(model);
        gvCate.EditIndex = -1;
        BindCate();
    }

    /// <summary>
    /// 编辑
    /// </summary>
    protected void gvCate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCate.EditIndex = e.NewEditIndex;
        BindCate();
    }

    /// <summary>
    /// 取消编辑
    /// </summary>
    protected void gvCate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCate.EditIndex = -1;
        BindCate();
    }

    /// <summary>
    /// 删除
    /// </summary>
    protected void gvCate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = int.Parse(gvCate.DataKeys[e.RowIndex].Value.ToString());
        bll.Delete(id);
        BindCate();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvCate.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvCate.Rows[i].FindControl("chkBox");
            if (chk.Checked)
            {
                bll.Delete(Convert.ToInt32(gvCate.DataKeys[i].Value));
            }
        }
        BindCate();
    }
}
