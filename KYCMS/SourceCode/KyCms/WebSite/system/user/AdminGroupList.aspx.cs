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

public partial class system_user_AdminGroupList : System.Web.UI.Page
{
    B_Group GroupBll = new B_Group();
    private B_PowerGroup Bpowergroup = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        litMsg.Text = string.Empty;
        if (!IsPostBack)
        {

            //权限判断
            Bpowergroup.Power_Judge(15);

            BindAdminGroup();
        }
    }
    private void BindAdminGroup()
    {
        repAdminGroup.DataSource =  GroupBll.GetAdminList();
        repAdminGroup.DataBind();
    }
    protected string GetAdminGroupUserCount(object grouId)
    {
        if (grouId == null || grouId.ToString() == string.Empty)
        {
            return string.Empty;
        }
        else
        {
            return GroupBll.GetAdminGroupUserCount((int)grouId).ToString();
        }
    }
    protected string GetIsSystem(object isSystem)
    {
        if (isSystem == null || isSystem.ToString() == string.Empty)
        {
            return "否";
        }
        else
        {
            int flag = (int)isSystem;
            return flag == 0 ? "否" : "是";
        }
    }

    public bool GetIsSystem(int System)
    {
        if (System == 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void repAdminGroup_Delete(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            LinkButton setDisable = e.Item.FindControl("lnkbtnDelete") as LinkButton;
            setDisable.Attributes.Add("onclick", "return confirm('确认删除?')");

            int groupId = Convert.ToInt32(e.CommandArgument);
            int userCount = 0;
            userCount = GroupBll.GetAdminGroupUserCount(groupId);
            if (userCount > 0)
            {
                litMsg.Text = "<script>alert('该管理员组还存在成员，不能删除该组');</script>";
                return;
            }
            int flag = GroupBll.Delete(groupId);
            if (flag == 0)
            {
                litMsg.Text = "<script>alert('该管理员组为系统组，不能删除');</script>";
                return;
            }
            else
            {
                BindAdminGroup();
            }
         }
    }
}
