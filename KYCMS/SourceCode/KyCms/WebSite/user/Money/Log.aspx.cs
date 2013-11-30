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

public partial class user_Log : System.Web.UI.Page
{
    B_UserLog bll = new B_UserLog();
    int userId = 0;
    B_User user = new B_User();
    M_User model;
    protected void Page_Load(object sender, EventArgs e)
    {
        LitMsg.Text = "";
        model = user.GetCookie();
        userId = model.UserID;
        if (!IsPostBack)
        {
            ViewState["Filter"] = "UserId=" + userId.ToString();
            BindData();
        }
    }

    void BindData()
    {
        if (userId != 0)
        {
            string whereStr = "UserId=" + userId.ToString();
            if (ViewState["Filter"] != null)
            {
                whereStr = ViewState["Filter"].ToString();
            }
            int total = 0;
            rptLog.DataSource = bll.ListLog(whereStr, Pager.PageSize, Pager.CurrentPageIndex, ref total);
            rptLog.DataBind();
            Pager.RecordCount = total;
            Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        }
    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    protected string SetModel(object type)
    {
        string name = "";
        if (type != null)
        {
            string modelType = type.ToString();
            switch (modelType)
            {
                case "1":
                    name = "文章";
                    break;
                case "2":
                    name = "";
                    break;
                case "3":
                    name = "";
                    break;
                default:
                    name = "";
                    break;
            }
        }
        return name;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string startDate;
        string endDate;
        try
        {
            startDate = DateTime.Parse(txtStartDate.Text).ToShortDateString();
            endDate = DateTime.Parse(txtEndDate.Text).ToShortDateString();
        }
        catch
        {
            LitMsg.Text = "<script type='text/javascript'>alert('输入的日期格式不正确,请检查')</script>";
            return;
        }
        ViewState["Filter"] = "UserId=" + model.UserID.ToString() + " and AddTime>='" + startDate + "' and AddTime<='" + endDate + "'";
        BindData();
    }
}