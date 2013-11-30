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
using Ky.Common;
using Ky.Model;
public partial class system_news_Vote : System.Web.UI.Page
{
    B_Vote bll = new B_Vote();
    B_VoteCategory cateBll = new B_VoteCategory();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(11);
        if (!IsPostBack)
        {            
            BindVote();
            BindCate();
        }
    }

    /// <summary>
    /// 绑定所有投票
    /// </summary>
    void BindVote(string whereStr)
    {
        int total=0;
        DataTable dt = bll.GetSubjects(Pager.PageSize, Pager.CurrentPageIndex, whereStr, ref total);
        rptVote.DataSource = dt;
        rptVote.DataBind();
        Pager.RecordCount = total;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    void BindVote()
    {
        BindVote("");
    }

    void BindCate()
    {
        ddlCategory.DataSource = cateBll.GetList();
        ddlCategory.DataTextField = "Name";
        ddlCategory.DataValueField = "CategoryId";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("请选择...", "0"));
    }

    protected string SetCategoryName(object name)
    {
        string returnStr = "";
        if (name != null)
        {
            if (name.ToString() == "")
                returnStr = "<span style='color:red'>无</span>";
            else
                returnStr = name.ToString();
        }
        return returnStr;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteSelectd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptVote.Items.Count; i++)
        {
            CheckBox chk = rptVote.Items[i].FindControl("chkBox") as CheckBox;
            if (chk != null && chk.Checked)
            {
                Literal lb = (Literal)rptVote.Items[i].FindControl("lbId");
                bll.Delete(int.Parse(lb.Text));
            }
        }
        BindVote();
    }

    /// <summary>
    /// 删除单条记录
    /// </summary>
    protected void rptVote_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            bll.Delete(id);
            BindVote();
        }
    }

    protected string SetDate(object endDate)
    {
        if (endDate != null)
        {
            DateTime end = (DateTime)endDate;
            if (end < DateTime.Now)
            {
                return  end.ToShortDateString() + "<span style='color:Red'>(已过期)</span>";
            }
            else
            {
                return end.ToShortDateString();
            }
        }
        else
        {
            return "";
        }
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindVote();
    }
    protected void lnkbtnOverdue_Click(object sender, EventArgs e)
    {
        BindVote("EndDate<'" + DateTime.Now.Date + "'");
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVote("KyVoteSubject.CategoryId=" + ddlCategory.SelectedValue);
    }
}
