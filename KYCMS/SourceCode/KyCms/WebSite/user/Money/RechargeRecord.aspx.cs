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

public partial class user_RechargeRecord : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    M_User model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model = UserBll.GetCookie();
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        int total = 0;
        rptRecord.DataSource = UserBll.RechargeRecord(model.UserID, Pager.PageSize, Pager.CurrentPageIndex, ref total);
        rptRecord.DataBind();
        Pager.RecordCount = total;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);

    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }
}
