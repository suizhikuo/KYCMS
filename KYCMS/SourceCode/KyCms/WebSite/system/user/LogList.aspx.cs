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

public partial class System_user_LogList : System.Web.UI.Page
{
    B_Log LogBll = new B_Log();
    B_Admin AdminBll = new B_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        litMsg.Text = string.Empty;
        if (!IsPostBack)
        {
            ViewState["LogType"] = 0;
            ViewState["UserName"] = "";
            ViewState["StartTime"] = "";
            ViewState["EndTime"] = "";
            Bind();
        }
        
    }

    private void Bind()
    {
        LogType logType = (LogType)Convert.ToInt32(ViewState["LogType"]);
        string userName = ViewState["UserName"].ToString();
        string startTime = ViewState["StartTime"].ToString();
        try
        {
            startTime = Convert.ToDateTime(startTime).ToString("yyyy-MM-dd");
        }
        catch
        {
            startTime = string.Empty;
        }
        string endTime = ViewState["EndTime"].ToString();
        try
        {
            endTime = Convert.ToDateTime(endTime).AddDays(1).ToString("yyyy-MM-dd");
        }
        catch
        {
            endTime = string.Empty;
        }
        int recordCount = 0;
        DataTable dt = LogBll.GetList(logType,userName,startTime,endTime,Pager.CurrentPageIndex, Pager.PageSize, ref recordCount);
        repLog.DataSource = dt;
        repLog.DataBind();
        Pager.RecordCount = recordCount;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        
    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        Bind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["LogType"] = ddlLogType.SelectedValue;
        ViewState["UserName"] = txtUserName.Text.Trim().Replace("'","''");
        if (txtStartTime.Text.Trim().Length != 0)
        {
            try
            {
                DateTime startTime = DateTime.Parse(txtStartTime.Text.Trim());
                ViewState["StartTime"] = startTime;
            }
            catch 
            {
                litMsg.Text = "<script type='text/javascript'>alert('起始日期的格式不正确，请参照2006-01-01');</script>";
                return;
            }
        }
        else
        {
             ViewState["StartTime"] = "";
        }

         if (txtEndTime.Text.Trim().Length != 0)
        {
            try
            {
                DateTime endTime = DateTime.Parse(txtEndTime.Text.Trim());
                ViewState["EndTime"] = endTime;
            }
            catch 
            {
                litMsg.Text = "<script type='text/javascript'>alert('截止日期的格式不正确，请参照2006-01-01');</script>";
                return;
            }
        }
        else
        {
             ViewState["EndTime"] = "";
        }
        Bind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        int dayCount = 0;
        if (!Function.CheckNumberNotZero(txtDayCount.Text.Trim()))
        {
            litMsg.Text = "<script type='text/javascript'>alert('清理日志的天数必须为整正数');</script>";
            return;
        }
        try
        {
            dayCount = int.Parse(txtDayCount.Text.Trim());
        }
        catch 
        { }
       
        dayCount = dayCount*-1;
        DateTime logTime = DateTime.Now.AddDays(dayCount);
        LogBll.Delete(logTime);
        Pager.CurrentPageIndex = 1;
        Bind();
    }
}
