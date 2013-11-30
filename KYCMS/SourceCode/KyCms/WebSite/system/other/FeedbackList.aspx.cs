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

public partial class system_FeedbackList : System.Web.UI.Page
{
    B_Feedback feedback = new B_Feedback();
    B_Admin admin = new B_Admin();
    B_Dictionary dictionary = new B_Dictionary();
    string whereStr = "parentId=0";
    B_PowerGroup power = new B_PowerGroup();
    const int cid = 8;
    protected void Page_Load(object sender, EventArgs e)
    {
        power.Power_Judge(38);
        if (!IsPostBack)
        {
            BindData();
            ddlBind();
        }
    }

    void BindData()
    {        
        if (ViewState["Filter"] != null)
        {
            whereStr = ViewState["Filter"].ToString();
        }
        DataSet data = feedback.GetList(Pager.PageSize, Pager.CurrentPageIndex, whereStr);
        rptFeedback.DataSource = data.Tables[0];
        rptFeedback.DataBind();
        Pager.RecordCount = Convert.ToInt32(data.Tables[1].Rows[0][0]);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    /// <summary>
    /// 绑定下拉列表
    /// </summary>
    void ddlBind()
    {
        ddlCategoryHeader.DataSource = ddlCategory.DataSource = dictionary.FormatCategory(cid);
        ddlCategoryHeader.DataTextField = ddlCategory.DataTextField = "DicName";
        ddlCategoryHeader.DataValueField = ddlCategory.DataValueField = "DicId";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("所有分类", "-1"));
        ddlCategoryHeader.DataBind();
        ddlCategoryHeader.Items.Insert(0, new ListItem("所有分类", "-1"));
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    protected void rptFeedback_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            feedback.Delete(id);
            BindData();
        }
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
                lastDate.Text = data.Rows[data.Rows.Count - 1]["replyDate"].ToString();
            }
            else
            { lastAuthor.Text = lastDate.Text = "-"; }
        }
    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptFeedback.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rptFeedback.Items[i].FindControl("chkBox");
            if (chk.Checked)
            {
                Label id = (Label)rptFeedback.Items[i].FindControl("lbId");
                feedback.Delete(int.Parse(id.Text));
            }
        }
        BindData();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string filter = "parentId=0";
        if (ddlCategory.SelectedValue != "-1")
        {
            filter += " and categoryId=" + ddlCategory.SelectedValue;
        }
        if (ddlState.SelectedValue != "-1")
        {
            filter += " and state=" + ddlState.SelectedValue;
        }
        if (txtSearch.Text != "")
        {
            filter += " and title like '%" + txtSearch.Text.Replace("'","''") + "%'";
        }        
        ViewState["Filter"] = filter;
        BindData();
    }
    protected void lnkbtnAll_Click(object sender, EventArgs e)
    {
        ViewState["Filter"] = "parentId=0";
        BindData();
    }
    protected void ddlStateHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateHeader.SelectedValue != "-1")
        {
            ViewState["Filter"] = "parentId=0 and state=" + ddlStateHeader.SelectedValue;
            BindData();
        }
    }
    protected void ddlCategoryHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategoryHeader.SelectedValue != "-1")
        {
            ViewState["Filter"] = "parentId=0 and categoryId=" + ddlCategoryHeader.SelectedValue;
            BindData();
        }
    }

    protected string SetState(object state)
    {
        string returnStr = "";
        if (state != null)
        {
            switch (state.ToString())
            {
                case "0":
                    returnStr = "问答中";
                    break;
                case "1":
                    returnStr = "已完成";
                    break;
                case "2":
                    returnStr = "锁定";
                    break;
            }
        }
        return returnStr;
    }

    protected string SetCategory(object cid)
    {
        string returnStr = "无分类";
        if (cid != null)
        {
            M_Dictionary model = dictionary.GetModel(Convert.ToInt32(cid));
            if (model != null)
            {
                returnStr = model.DicName;
            }
        }
        return returnStr;
    }

}
