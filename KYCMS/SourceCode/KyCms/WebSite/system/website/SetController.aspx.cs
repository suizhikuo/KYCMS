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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class System_website_SetController : System.Web.UI.Page
{
    int UserId = 0;
    B_Controller Bll = new B_Controller();
    B_Admin AdminBll = new B_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {  
        AdminBll.CheckMulitLogin();
        M_LoginAdmin model = AdminBll.GetLoginModel();
        UserId = model.UserId;
        LitMsg.Text = string.Empty;
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        DataTable dt = Bll.GetList(UserId);
        string[] pk = { "ControllerId" };
        gvController.DataKeyNames = pk;
        gvController.DataSource = dt;
        gvController.DataBind();
    }
    protected void btnSetDefault_Click(object sender, EventArgs e)
    {
        Bll.SetDefault(UserId);
        Bind();
    }
    protected void gvController_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvController.EditIndex = e.NewEditIndex;
        Bind();
    }
    protected void gvController_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvController.EditIndex = -1;
        Bind();
    }
    protected void gvController_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int controllerId = (int)gvController.DataKeys[e.RowIndex].Value;
        TextBox ctxtControllerName = gvController.Rows[e.RowIndex].Cells[0].Controls[0] as TextBox;
        string controllerName = ctxtControllerName.Text.Trim();
        if (controllerName.Length == 0||controllerName.Length>50)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('链接名称必须填写');</script>";
            return;
        }
        TextBox ctxtLinkURI = gvController.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
        string linkURI = ctxtLinkURI.Text.Trim();
        if (linkURI.Length == 0 || controllerName.Length > 255)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('链接指向必须填写');</script>";
            return;
        }
        TextBox ctxtOrderNum = gvController.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox;
        int orderNum = 0;
        if (!Function.CheckNumber(ctxtOrderNum.Text.Trim()))
        {
            LitMsg.Text = "<script type='text/javascript'>alert('排序必须为非负整数');</script>";
            return;
        }
        orderNum = int.Parse(ctxtOrderNum.Text.Trim());
       
        M_Controller model = new M_Controller();
        model.ControllerId = controllerId;
        model.ControllerName = controllerName;
        model.LinkURI = linkURI;
        model.OrderNum = orderNum;
        model.UserId = UserId;
        Bll.Update(model);
        gvController.EditIndex = -1;
        Bind();
    }
    protected void gvController_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int controllerId = (int)gvController.DataKeys[e.RowIndex].Value;
        Bll.Delete(controllerId, UserId);
        gvController.EditIndex = -1;
        Bind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string controllerName = txtControllerName.Text.Trim();
        if (controllerName.Length == 0)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('链接名称必须填写');</script>";
            return;
        }
        string linkURI = txtLinkURI.Text.Trim();
        if (linkURI.Length == 0)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('链接指向必须填写');</script>";
            return;
        }
        int orderNum = 0;
         if (!Function.CheckNumber(txtOrderNum.Text.Trim()))
        {
            LitMsg.Text = "<script type='text/javascript'>alert('排序必须为非负整数');</script>";
            return;
        }
        orderNum = int.Parse(txtOrderNum.Text.Trim());

        M_Controller model = new M_Controller();
        model.ControllerId = 0;
        model.ControllerName = controllerName;
        model.LinkURI = linkURI;
        model.OrderNum = orderNum;
        model.UserId = UserId;
        Bll.Add(model);
        txtControllerName.Text = "";
        txtLinkURI.Text = "";
        txtOrderNum.Text = "";
        gvController.EditIndex = -1;
        Bind();
    }
    protected void gvController_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onMouseOut", "this.className='tdbg'");
        }
    }
}
