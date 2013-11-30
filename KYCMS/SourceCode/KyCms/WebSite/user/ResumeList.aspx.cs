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

public partial class user_ResumeList : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserModel = UserBll.GetUser(UserBll.GetCookie().UserID);
        if (UserModel == null)
        { Response.Redirect("Login.aspx"); }
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        DataSet data = UserBll.ListResume(Pager.PageSize, Pager.CurrentPageIndex, "UserType=1 and UnitId=" + UserModel.UserID);
        rptHireInfo.DataSource = data.Tables[0];
        rptHireInfo.DataBind();
        Pager.RecordCount = Convert.ToInt32(data.Tables[1].Rows[0][0]);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    protected void rptHireInfo_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            UserBll.DeleteResume(int.Parse(e.CommandArgument.ToString()));
            BindData();
        }
    }

    /// <summary>
    /// 获取用户的简历在简历表中的Id
    /// </summary>
    /// <param name="hireId">应聘者与企业关系表中的数据编号</param>
    /// <returns></returns>
    protected string GetResumeId(object hireId)
    {
        string returnStr = "0";
        if (hireId != null)
        {
            DataTable dt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, "select Max(Ky_U_Job.Id) from Ky_U_job join KyHireInfo on Ky_U_Job.Uid=KyHireInfo.Uid where KyHireInfo.[id]=" + hireId.ToString(), null);
            returnStr = dt.Rows[0][0].ToString();
        }
        return returnStr;
    }

}
