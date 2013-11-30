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

public partial class user_Friend_FriendGroup : System.Web.UI.Page
{
    B_User bll = new B_User();
    M_User userModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        LitMsg.Text = "";
        userModel = bll.GetCookie();
        if (!IsPostBack)
        {
            gvBind();
        }
    }

    void gvBind()
    {
        gvGroupList.DataSource = bll.ListFriendGroup(userModel.UserID);
        gvGroupList.DataBind();
    }

    /// <summary>
    /// 添加好友分组
    /// </summary>
    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtGroupName.Text.Trim()))
        {
            Function.ShowMsg(0,"<li>请输入分组名称!</li>");
        }
        bll.AddFriendGroup(txtGroupName.Text.ToString(), bll.GetCookie().UserID);
        txtGroupName.Text = "";
        gvBind();
    }
    protected void gvGroupList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label groupId = (Label)e.Row.FindControl("lbId");
            int num = bll.CountFriendGroupMember(int.Parse(groupId.Text),userModel.UserID);
            Label lbNum = (Label)e.Row.FindControl("lbGroupMember");
            lbNum.Text = num.ToString();
            Label isUserId = (Label)e.Row.FindControl("lbUserId");
            if (isUserId.Text == "0")
            {
                LinkButton edit = (LinkButton)e.Row.FindControl("lnkbtnEdit");
                LinkButton del = (LinkButton)e.Row.FindControl("lnkbtnDel");
                edit.Visible = false;
                del.Visible = false;
            }

            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
        }
    }
    protected void gvGroupList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtName = (TextBox)gvGroupList.Rows[e.RowIndex].FindControl("txtGroupName");
        int key = (int)gvGroupList.DataKeys[e.RowIndex].Value;
        if (txtName.Text.Trim() != "")
        {
            bll.UpdateFriendGroup(key, txtName.Text);            
        }
        gvGroupList.EditIndex = -1;
        gvBind();
    }
    protected void gvGroupList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGroupList.EditIndex = e.NewEditIndex;
        gvBind();
    }
    protected void gvGroupList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int key = (int)gvGroupList.DataKeys[e.RowIndex].Value;
        bll.DeleteFriendGroup(key);
        gvBind();
    }
    protected void gvGroupList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGroupList.EditIndex = -1;
        gvBind();
    }
}
