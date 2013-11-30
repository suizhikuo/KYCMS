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
using Ky.Model;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class System_user_UserList : System.Web.UI.Page
{
    private B_User userbll = new B_User();
    private M_User muser = new M_User();
    private B_UserGroup usergroupbll = new B_UserGroup();
    string typeFilter = string.Empty;
    protected int TypeId = -1;
    protected B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    protected M_UserGroupModel MUserGroupModel = new M_UserGroupModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["TypeId"]))
        {
            try
            {
                TypeId = int.Parse(Request.QueryString["TypeId"]);
            }
            catch { }
        }

        MUserGroupModel = BUserGroupModel.GetModel(TypeId);

        B_PowerGroup power = new B_PowerGroup();
        power.Power_Judge(2);
        LitUserType.Text = "" + MUserGroupModel.Name + "列表";

        if (!IsPostBack)
        {
            BindUserGroup(" where TypeId=" + TypeId + "");

            RepUserGroupModel.DataSource = BUserGroupModel.GetAll();
            RepUserGroupModel.DataBind();

            BindRepaterUserList("");
        }
    }

    /// <summary>
    /// 绑定用户组列表
    /// </summary>
    void BindUserGroup(string filter)
    {
        ddlUserGroup.DataSource = usergroupbll.ManageList(filter);
        ddlUserGroup.DataTextField = "UserGroupName";
        ddlUserGroup.DataValueField = "UserGroupId";
        ddlUserGroup.DataBind();
        ddlUserGroup.Items.Insert(0, new ListItem("所有用户", "0"));
    }

    private void BindRepaterUserList(string sortStr)
    {
        string Order="";
        if (Request.QueryString["Order"] == "" || Request.QueryString["Order"] == null)
        {
            Order = "userid";
        }
        else
        {
            Order = Request.QueryString["Order"];
        }
        int recordCount = 0;
        string sddlUserGroup = ddlUserGroup.SelectedValue;
        string sddlLastLoginTime = ddlLastLoginTime.SelectedValue;
        string userName = txtSearchUserName.Text;

        DataView dv = userbll.GetUserList(int.Parse(sddlUserGroup), int.Parse(sddlLastLoginTime), userName, TypeId, -1, Order, Pager.CurrentPageIndex, Pager.PageSize, ref recordCount).DefaultView;
        if (sortStr != "")
        {
            dv.Sort = sortStr; 
        }
        RepUserList.DataSource = dv;
        RepUserList.DataBind();
        Pager.RecordCount = recordCount;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    protected void RepUserList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if (e.CommandName == "Lock")
        {
            //修改用户锁定状态
            int eventArg = int.Parse(e.CommandArgument.ToString());
            M_User model = userbll.GetUser(eventArg);
            userbll.SetUserLockStatus(eventArg, !model.IsLock);
        }
        if (e.CommandName == "Delete")
        {
            //删除用户
            int eventArg = int.Parse(e.CommandArgument.ToString());
            userbll.Delete(eventArg);
        }
        if (e.CommandName == "status")
        {
            string[] eventArgArray = e.CommandArgument.ToString().Split(',');
            int userId = int.Parse(eventArgArray[0]);
            int status = int.Parse(eventArgArray[1]);
            if (status == 0)
            {
                userbll.UpdateUserStatus(userId, 1);
            }
        }
        BindRepaterUserList("");
    }

    /// <summary>
    /// 搜索用户
    /// </summary>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindRepaterUserList("");
    }

    /// <summary>
    /// 批量删除用户
    /// </summary>
    protected void btnDeleteMore_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < RepUserList.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)RepUserList.Items[i].FindControl("cboxSelect");
            if (chk.Checked)
            {
                Literal id = (Literal)RepUserList.Items[i].FindControl("LitId");
                userbll.Delete(int.Parse(id.Text));
            }
        }
        if (ddlUserGroup.SelectedValue == "-1")
        {
            BindRepaterUserList("");
        }
        else
        {
            BindRepaterUserList("");
        }
    }

    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindRepaterUserList("");
    }
}

