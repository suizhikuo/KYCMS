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
using Ky.SQLServerDAL;
using Ky.Common;
public partial class user_space_MessageManage : System.Web.UI.Page
{
    M_UserMessage UserMessageModel = new M_UserMessage();
    B_UserMessage UserMessageBll = new B_UserMessage();

    string UserName = string.Empty;
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        litMsg.Text = string.Empty;
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        B_UserSpace.IsActive(UserModel.UserID, 1);
        if(!IsPostBack)
        {
            Bind();
        }
    }
    protected void Bind()
    {
        int recordCount=0;
        DataTable dt = UserMessageBll.GetMessageByUserId(UserModel.UserID, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条留言 每页显示{3}条", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize);
        if(dt.Rows.Count<=0)
        {
            lbMsg.Text = "暂无留言!";
            return;
        }
        gvMsg.DataSource = dt;
        gvMsg.DataBind();
    }
    protected void gvMsg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
            //e.Row.Attributes.Add("Style", "cursor='pointer'");
           // e.Row.Attributes.Add("onclick","javascript:alert(123)");
        }
    }
    protected void gvMsg_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gvMsg.DataKeys[e.RowIndex].Value);
        UserMessageBll.DeleteMessage(id.ToString(), UserModel.UserID);
        Bind();
    }
    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        string idStr = string.Empty;
        foreach(GridViewRow rowview in gvMsg.Rows)
        {
            CheckBox _cb = (CheckBox)rowview.Cells[1].FindControl("chkBoxSel");
            bool ischecked = _cb.Checked;
            if (ischecked)
               idStr += gvMsg.DataKeys[rowview.RowIndex].Value.ToString() + ",";
        }
        if(idStr==string.Empty)
        {
            litMsg.Text = "<script>alert('请选择删除项');</script>";
            return;
        }
        if (idStr.EndsWith(","))
            idStr = idStr.Substring(0, idStr.Length - 1);

        UserMessageBll.DeleteMessage(idStr, UserModel.UserID);
        Bind();
    }
    protected string IsResume(object flag)
    {
            if (Convert.ToBoolean(flag))
            return "<font color=red> (已回复)</font>";
        else
            return "";
    }
    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        Bind();
    }
}

