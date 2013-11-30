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
using Ky.BLL.CommonModel;
using Ky.Common;
using Ky.Model;

public partial class system_UserGroupModel_UserGroupModelList : System.Web.UI.Page
{
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    private B_UserGroupModelField BUserGroupModelField = new B_UserGroupModelField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(49);
        if (!Page.IsPostBack)
        {
            GetAll();
        }
    }

    private void GetAll()
    {
        DataTable dt = new DataTable();
        dt = BUserGroupModel.GetAll();
        RepUserGroupModel.DataSource = dt;
        RepUserGroupModel.DataBind();
        dt.Clear();
        dt.Dispose();
    }

    protected void repUserGroupModel_Delete(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int Id = Convert.ToInt32(e.CommandArgument);

            //判断该表单下是否存在自定义字段
            DataTable dt = BUserGroupModelField.GetList(Id);
            if (dt.Rows.Count > 0)
            {
                Function.ShowSysMsg(0, "<li>该表单下还存在自定义字段，不能够删除!</li><li><a href='UserGroupModel/UserGroupModelList.aspx'>返回表单管理列表</a></li>");
            }
            else
            {
                BUserGroupModel.Delete(Id);
            }

            dt.Clear();
            dt.Dispose();

            GetAll();
        }
    }

    public string GetUserGroup(string UserGroupId)
    {
        if (UserGroupId == "0")
        {
            return "<a href='../user/GroupList.aspx' title='点击设置用户组'><font color=red>还未设置用户组</font></a>";
        }
        else
        {
            B_UserGroup bll=new B_UserGroup();
            M_UserGroup model = bll.GetModel(int.Parse(UserGroupId));

            if (model == null)
            {
                return "<font color=green>该用户组不存在或被删除</font>";
            }
            else
            {
                return model.UserGroupName;
            }
        }
    }
}
