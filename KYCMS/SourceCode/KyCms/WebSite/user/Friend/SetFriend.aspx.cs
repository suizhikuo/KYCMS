using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class User_Friend_SetFriend : System.Web.UI.Page
{
    B_User user = new B_User();
    int userId = 0;
    int groupId = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        LitMsg.Text = "";
        userId = user.GetCookie().UserID;
        if (Request.QueryString["gid"] != null)
        {
            try
            { groupId = int.Parse(Request.QueryString["gid"]); }
            catch { groupId = 1; }
            ViewState["Filter"] = " KyUserFriend.UserId=" + userId.ToString() + " and FriendGroupId=" + groupId.ToString();
        }
        BindGroup();
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindGroup()
    {
        pnlGroup.Controls.Clear();
        DataTable dt = user.ListFriendGroup(userId);
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label group = new Label();
                StringBuilder sb = new StringBuilder();
                sb.Append("<a href=\"SetFriend.aspx?gid=");
                sb.Append(dt.Rows[i]["FriendGroupId"].ToString());
                sb.Append("\">");
                sb.Append(dt.Rows[i]["FriendGroupName"].ToString());
                sb.Append("</a>(");
                sb.Append(user.CountFriendGroupMember((int)dt.Rows[i]["FriendGroupId"], userId).ToString());
                sb.Append(") | ");
                group.Text = sb.ToString();
                pnlGroup.Controls.Add(group);
            }
            Literal addFriend = new Literal();
            addFriend.Text = "<a href='javascript:IsDisplay(\"AddNewFriend\");' >添加好友</a>";
            pnlGroup.Controls.Add(addFriend);
            if (!IsPostBack)
            {
                ddlUserGroup.DataSource = dt;
                ddlUserGroup.DataTextField = "FriendGroupName";
                ddlUserGroup.DataValueField = "FriendGroupId";
                ddlUserGroup.DataBind();
            }
        }
    }

    void BindData()
    {
        string whereStr = " KyUserFriend.UserId=" + userId.ToString()+" and FriendGroupId!=2";
        if (ViewState["Filter"] != null)
        {
            whereStr = ViewState["Filter"].ToString();
        }
        int total=0;
        rptFriendList.DataSource = user.ListGroupMember(whereStr,Pager.PageSize, Pager.CurrentPageIndex, ref total);
        rptFriendList.DataBind();
        Pager.RecordCount = total;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    /// <summary>
    /// 列入黑名单
    /// </summary>
    protected void rptFriendList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        
        if (e.CommandName == "SetBlack")
        {            
            user.SetFriend(id, OperateType.Disable);
            ViewState["Filter"] = " KyUserFriend.UserId=" + userId.ToString() + " and FriendGroupId!=2";
            BindData();
            BindGroup();
        }
        if (e.CommandName == "Delete")
        {
            user.DeleteFriend(id);
            BindData();
            BindGroup();
        }
    }

    protected void rptFriendList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton delBlackBtn = (LinkButton)e.Item.FindControl("lnkbtnDelete");            
            if (groupId == 2)
            {
                LinkButton setBlackBtn = (LinkButton)e.Item.FindControl("lnkbtnSet");
                setBlackBtn.Visible = false;
                delBlackBtn.Attributes.Add("onclick", "return confirm('是否把该用户从黑名单中删除?')");
            }
            else
            {
                delBlackBtn.Attributes.Add("onclick", "return confirm('是否删除此好友?');");
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim() == "")
        {
            Function.ShowMsg(0, "<li>请输入对方名称</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtUserName.Text.Trim() == user.GetCookie().LogName)
        {
            Function.ShowMsg(0, "<li>对不起，您不能添加自己为好友</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        int flag = user.AddFriend(user.GetCookie().UserID, txtUserName.Text, int.Parse(ddlUserGroup.SelectedValue));
        txtUserName.Text = "";
        ViewState["Filter"] = " KyUserFriend.UserId=" + userId.ToString()+" and FriendGroupId!=2";
        BindData();
        if (flag == 1)
        {
            Function.ShowMsg(0, "<li>对不起,您已经添加了这位好友了</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (flag == 2)
        {
            Function.ShowMsg(0, "<li>对不起,您请求的好友不存在!</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (flag == 3)
        {
            Response.Redirect("SetFriend.aspx");
        }      
        
    }
}

