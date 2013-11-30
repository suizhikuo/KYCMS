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
using Ky.BLL.CommonModel;

public partial class system_user_GroupList : System.Web.UI.Page
{
    private B_UserGroup BUserGroup = new B_UserGroup();
    private M_UserGroup MUserGroup = new M_UserGroup();
    private B_User BUser = new B_User();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminGroupBll.Power_Judge(13);

            //用户注册模型
            RepUserGroupModel.DataSource = BUserGroupModel.GetAll();
            RepUserGroupModel.DataBind();

            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }

        DataSet ds = BUserGroup.GetList(int.Parse(P), Pager.PageSize, "");
        Repeater1.DataSource = ds.Tables[0].DefaultView;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
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

    /// <summary>
    /// 删除单一记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BUserGroup.Delete(id);

            DataBaseList();
        }

        if (e.CommandName == "DefaultGroup")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            MUserGroup = BUserGroup.GetModel(id);

            M_UserGroupModel model = BUserGroupModel.GetModel(MUserGroup.TypeId);

            BUserGroupModel.UpdateUserGroupId(MUserGroup.TypeId, id);

            Function.ShowSysMsg(1, "<li>成功设置默认注册组</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='user/GroupList.aspx'>返回模型管理列表</a></li>");
        }
    }

    public string GetTypeId(int TypeId)
    {
        M_UserGroupModel model = BUserGroupModel.GetModel(TypeId);
        if (model == null)
        {
            return "<font color=red>该用户注册模型已经被删除</font>";
        }
        else
        {
            return model.Name;
        }
    }

    /// <summary>
    /// 返回用户组人数
    /// </summary>
    /// <param name="UserGroupId"></param>
    /// <returns></returns>
    public string GetUserGroupNum(int UserGroupId)
    {
        return BUser.GetUserCount(0,UserGroupId).ToString();
    }
}
