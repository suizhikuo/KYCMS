using System;
using System.Data;
using System.Data.SqlClient;
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

public partial class GroupManage : System.Web.UI.Page
{
    #region 保护类型变量
    B_Admin AdminBll = new B_Admin();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    #endregion

    #region 公有变量
    public int GroupId = 0;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(14);

        if(Request.QueryString["GroupId"] != null && Request.QueryString["GroupId"] != "")
        {
            try
            {
                GroupId = Int32.Parse(Request.QueryString["GroupId"]);
            }
            catch
            {}
            
        }
        if (!IsPostBack)
        {
            if (GroupId == 0)
            {
                BindGridView();
            }
            else
            {
                BindGridViewByGroupID();
            }
        }
    }
    #endregion

    #region 绑定GridView
    private void BindGridView()
    {
        DataTable dt = AdminBll.GetAdminList();
        GridViewAdminList.DataSource = dt.DefaultView;
        GridViewAdminList.DataBind();
    }
    #endregion

    #region 通过组ID绑定GridView
    private void BindGridViewByGroupID()
    {
        DataTable dt = AdminBll.GetAdminByGroupID(GroupId);
        GridViewAdminList.DataSource = dt.DefaultView;
        GridViewAdminList.DataBind();
    }

    #endregion

    #region GridViewRow的Css样式设置
    protected void GridViewAdminList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //鼠标移上去背景颜色变化 数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
        }
    }
    #endregion

    #region RowCommand事件
    protected void GridViewAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteOne")
        {
            int _id = Int32.Parse(e.CommandArgument.ToString());
            AdminBll.Delete(_id);
            BindGridView();
        }
    }
    #endregion

    #region 转换字段
    public string createAllowMultiLogin(object Container)
    {
        string AllowMultiLogin = DataBinder.Eval(Container, "AllowMultiLogin").ToString();
        if (AllowMultiLogin == "True")
        {
            return "允许多人登陆";
        }
        else
        {
            return "不允许多人登陆";
        }
    }
    #endregion

    #region 分页事件
    protected void GridViewAdminList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewAdminList.PageIndex = e.NewPageIndex;
        BindGridView();
    }
    #endregion
}
