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

public partial class common_SelectViewer : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    protected string ControlId = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ControlId"]))
        {
            ControlId = Request.QueryString["ControlId"];
        }
        else
        {
            litMsg.Visible = true;
            litMsg.Text = "<script>alert('非法操作');window.close();</script>";
            return;

        }
        if(!IsPostBack)
        {
            ViewState["LogName"]=string.Empty;
            BindUserGroup();
        }
    }
    void BindUserGroup()
    {
        int recordCount = 0;
        string logName = ViewState["LogName"].ToString();
        RepUserList.DataSource = UserBll.GetUserList(0, 0, logName, 0, 0, "userid", AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        RepUserList.DataBind();
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize);
    }
    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        BindUserGroup();
    }
    public string GetIsLock(object isLock)
    {
        if (Convert.ToBoolean(isLock))
            return "锁定";
        else
            return "正常";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim().Length == 0)
        {
            ViewState["LogName"] =string.Empty;
            BindUserGroup();
        }
        else
        {
            string logName = txtUserName.Text.Trim();
            ViewState["LogName"] = logName;
            BindUserGroup();
        }
    }
}
