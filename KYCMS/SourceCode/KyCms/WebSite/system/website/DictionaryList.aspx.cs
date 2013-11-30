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
using System.Text;
using Ky.BLL;
using Ky.Common;
using Ky.Model;

public partial class system_website_DictionaryList : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Dictionary DicBll = new B_Dictionary();
    int Id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string qryId = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(qryId) && Function.CheckInteger(qryId))
        {
            Id = int.Parse(qryId);
        }
        if (!IsPostBack)
        {
            AdminGroupBll.Power_Judge(12);
            BindData();
            ddlBind();
            GetParentId(Id);
        }
    }

    /// <summary>
    /// 绑定字典到字典列表
    /// </summary>
    void BindData()
    {
        DataTable data = Id == 0 ? DicBll.GetParents() : DicBll.GetDictionary(Id);
        gvDictionary.DataSource = data;
        gvDictionary.DataBind();
    }

    /// <summary>
    /// 绑定字典到下拉列表
    /// </summary>
    void ddlBind()
    {
        ddlDictionary.DataSource = DicBll.FormatCategory(Id, true);
        ddlDictionary.DataTextField = "DicName";
        ddlDictionary.DataValueField = "DicId";
        ddlDictionary.DataBind();
        if (Id == 0)
        { ddlDictionary.Items.Insert(0, new ListItem("顶级字典", "0")); }
    }

    string Str = "";

    void GetParentId(int id)
    {
        M_Dictionary model = DicBll.GetModel(id);
        if (model != null)
        {
            if (id == Id)
            {
                Str = " >> "+model.DicName;
                GetParentId(model.ParentId);
            }
            else
            {
                Str = " >> " + "<a href='?id=" + model.Id + "'>" + model.DicName + "</a>" + Str;

                if (model.ParentId > 0)
                {
                    GetParentId(model.ParentId);
                }
            }
        }
        LitNav.Text = Str;
    }

    /// <summary>
    /// 所属字典
    /// </summary>
    protected string SetParentName(object pid)
    {
        string returnStr = "";
        if (pid != null)
        {
            int P = Convert.ToInt32(pid);
            if (P == 0)
                returnStr = "顶级字典";
            else
            {
                M_Dictionary model = DicBll.GetModel(Convert.ToInt32(pid));
                if (model != null)
                    returnStr = model.DicName;
            }
        }
        return returnStr;
    }

    /// <summary>
    /// 编辑
    /// </summary>
    protected void gvDictionary_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDictionary.EditIndex = e.NewEditIndex;
        BindData();
    }
    /// <summary>
    /// 修改
    /// </summary>
    protected void gvDictionary_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtName = gvDictionary.Rows[e.RowIndex].FindControl("txtName") as TextBox;
        TextBox txtSort = gvDictionary.Rows[e.RowIndex].FindControl("txtSort") as TextBox;
        if (string.IsNullOrEmpty(txtName.Text))
        { Function.ShowSysMsg(0, "<li>请输入字典名称</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
        if (string.IsNullOrEmpty(txtSort.Text))
        { Function.ShowSysMsg(0, "<li>请输入排序值</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
        if (!Function.CheckNumber(txtSort.Text))
        { Function.ShowSysMsg(0, "<li>排序值应该是数字，请重新设置</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
        M_Dictionary model = DicBll.GetModel((int)gvDictionary.DataKeys[e.RowIndex].Value);
        model.DicName = txtName.Text;
        model.Sort = int.Parse(txtSort.Text);
        DicBll.Update(model);
        gvDictionary.EditIndex = -1;
        BindData();
        ddlBind();
    }
    /// <summary>
    /// 取消编辑
    /// </summary>
    protected void gvDictionary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDictionary.EditIndex = -1;
        BindData();
    }
    /// <summary>
    /// 删除
    /// </summary>
    protected void gvDictionary_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int key = (int)gvDictionary.DataKeys[e.RowIndex].Value;
        DicBll.Delete(key);
        BindData();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvDictionary.Rows.Count; i++)
        {
            CheckBox chkBox = gvDictionary.Rows[i].FindControl("chkBox") as CheckBox;
            if (chkBox != null && chkBox.Checked)
            {
                int key = Convert.ToInt32(gvDictionary.DataKeys[i].Value);
                DicBll.Delete(key);
            }
        }
        BindData();
    }

    /// <summary>
    /// 设置是否显示图片及是否加超链接
    /// </summary>
    protected void gvDictionary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
            StringBuilder sbName = new StringBuilder();
            Literal litName = e.Row.FindControl("LitDicName") as Literal;
            if (litName != null)
            {
                if (DicBll.GetDictionary(Convert.ToInt32(gvDictionary.DataKeys[e.Row.RowIndex].Value)).Rows.Count > 0)
                {
                    sbName.Append("<img src=\"../../images/has.gif\" alt=\"有子字典\" />");
                    sbName.Append("<a href=\"?id=");
                    sbName.Append(gvDictionary.DataKeys[e.Row.RowIndex].Value);
                    sbName.Append("\">");
                    sbName.Append(litName.Text);
                    sbName.Append("</a>");
                    litName.Text = sbName.ToString();
                }
            }
        }
    }

    /// <summary>
    /// 新增字典
    /// </summary>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNewName.Text))
        {
            Function.ShowSysMsg(0, "<li>请输入字典名称</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (string.IsNullOrEmpty(txtNewSort.Text))
        {
            Function.ShowSysMsg(0, "<li>请输入排序值</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (!Function.CheckNumber(txtNewSort.Text))
        {
            Function.ShowSysMsg(0, "<li>您输入的排序值不正确，请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        M_Dictionary model = new M_Dictionary();
        model.DicName = txtNewName.Text;
        model.ParentId = int.Parse(ddlDictionary.SelectedValue);
        model.Sort = int.Parse(txtNewSort.Text);
        DicBll.Add(model);
        Id = int.Parse(ddlDictionary.SelectedValue);
        BindData();
        ddlBind();
        txtNewName.Text = txtNewSort.Text = "";
    }
}
