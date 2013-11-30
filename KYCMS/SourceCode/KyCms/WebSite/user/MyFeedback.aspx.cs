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

public partial class user_MyFeedback : System.Web.UI.Page
{
    B_Feedback feedback = new B_Feedback();
    B_User user = new B_User();
    M_User model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model = user.GetCookie();
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        DataSet data = feedback.GetList(Pager.PageSize, Pager.CurrentPageIndex, "author='"+model.LogName+"' and parentId=0");
        rptFeedback.DataSource = data.Tables[0];
        rptFeedback.DataBind();
        Pager.RecordCount = Convert.ToInt32(data.Tables[1].Rows[0][0]);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    protected void rptFeedback_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int id = 0;
            Literal count = e.Item.FindControl("LitReplyCount") as Literal;
            Literal lastAuthor = e.Item.FindControl("LitLastAuthor") as Literal;
            Literal lastDate = e.Item.FindControl("LitLastDate") as Literal;
            id = int.Parse(count.Text);
            DataTable data = feedback.GetFeedback(id).Tables[1];
            count.Text = data.Rows.Count.ToString();
            if (data.Rows.Count > 0)
            {
                lastAuthor.Text = data.Rows[data.Rows.Count - 1]["author"].ToString();
                lastDate.Text = Convert.ToDateTime(data.Rows[data.Rows.Count - 1]["replyDate"]).ToShortDateString();
            }
            else
            { lastAuthor.Text = lastDate.Text = "-"; }
        }
    }

    protected string SetState(object state)
    {
        string returnStr = "";
        if (state != null)
        {
            switch (state.ToString())
            {
                case "0": returnStr = "问答中";
                    break;
                case "1": returnStr = "已完成";
                    break;
                case "2": returnStr = "锁定";
                    break;
            }
        }
        return returnStr;
    }
}
