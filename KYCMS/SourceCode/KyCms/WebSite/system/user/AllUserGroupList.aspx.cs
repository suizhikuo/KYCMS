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

public partial class system_user_AllUserGroupList : System.Web.UI.Page
{
    private B_User userbll = new B_User();
    private M_User muser = new M_User();
    private B_UserGroup usergroupbll = new B_UserGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string GroupId = Request.QueryString["id"];
        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }
        int recordCount = 0;
        DataTable dt = userbll.GetUserList(int.Parse(GroupId), 0, "", 0, -1, "userid", int.Parse(P), Pager.PageSize, ref recordCount);

        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        Pager.RecordCount = recordCount;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    #region 替换字符传(会员状态)
    public string GetIsLock(object isLock)
    {
        string Islockstring = "";
        if (isLock.ToString() == "True")
        {
            Islockstring = "锁定";
        }
        else if (isLock.ToString() == "False")
        {
            Islockstring = "正常";
        }
        return Islockstring;
    }
    #endregion
}
