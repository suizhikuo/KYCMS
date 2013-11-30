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
using System.Text;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class QA_List : System.Web.UI.Page
{
    B_Feedback feedback = new B_Feedback();
    B_Dictionary dictionary = new B_Dictionary();
    B_Create createBll = new B_Create();
    B_User userBll = new B_User();
    int cid = 5;
    string whereStr = "parentId=0";
    bool IsZero = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        hylnk.NavigateUrl = createBll.GetIndexUrl();
        hyAll.CssClass = "Feedback_Selected";
        string qryCategoryId = Request.QueryString["cid"];
        string qryState = Request.QueryString["state"];
        string qryTitle = Request.QueryString["title"];
        string qryHigh = Request.QueryString["high"];
        string qryZero = Request.QueryString["zero"];
        if (!string.IsNullOrEmpty(qryCategoryId))
        {
            cid = int.Parse(qryCategoryId);
        }
        M_Dictionary dicModel = dictionary.GetModel(cid);
        if (dicModel == null)
        { Response.Redirect("Index.aspx"); }
        else
        {
            whereStr += " and categoryId=" + cid;
            hyEd.NavigateUrl += "&cid=" + cid;
            hyIng.NavigateUrl += "&cid=" + cid;
            hyZero.NavigateUrl += "&cid=" + cid;
            hyHigh.NavigateUrl += "&cid=" + cid;
            hyAll.NavigateUrl = "?&cid=" + cid;
        }
        if (!string.IsNullOrEmpty(qryState))
        {
            if (qryState == "1")
            { hyEd.CssClass = "Feedback_Selected";}
            else if (qryState == "0")
            { hyIng.CssClass = "Feedback_Selected"; }
            else { qryState = "0"; }
            hyAll.CssClass = "";
            whereStr += " and [state]=" + qryState;
        }
        if (!string.IsNullOrEmpty(qryTitle))
        {
            string decodeStr = Function.UrlDecode(qryTitle);
            whereStr += " and [title] like '%" + decodeStr.Replace("'", "''") + "%'";
        }
        if (!string.IsNullOrEmpty(qryHigh))
        {
            whereStr += " and state=0 and reward>=" + (Function.CheckInteger(qryHigh) ? int.Parse(qryHigh) : 20);
            hyHigh.CssClass = "Feedback_Selected";
            hyAll.CssClass = "";
        }
        if (!string.IsNullOrEmpty(qryZero))
        {
            if (qryZero.ToLower() == "true")
            {
                IsZero = true;
            }
            hyZero.CssClass = "Feedback_Selected";
            hyAll.CssClass = "";
        }
        if (!IsPostBack)
        {
            BindData(whereStr);
            ddlBind();
            BindCategory();
        }
    }

    /// <summary>
    /// 绑定内容
    /// </summary>
    void BindData(string whereStr)
    {
        DataSet data = feedback.GetList(Pager.PageSize, Pager.CurrentPageIndex, whereStr);
        rptING.DataSource = data.Tables[0];
        rptING.DataBind();
        if (Convert.ToInt32(data.Tables[1].Rows[0][0]) == 0)
        { TrNoContent.Visible = true; }
        Pager.RecordCount = Convert.ToInt32(data.Tables[1].Rows[0][0]);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        //快到期的问题
        DataSet endDate = feedback.GetList(10, 1, "parentId=0 and categoryId=" + cid + " and state=0 and datediff(day,getdate(),enddate)=2");
        rptEndDate.DataSource = endDate.Tables[0];
        rptEndDate.DataBind();
        if (Convert.ToInt32(endDate.Tables[1].Rows[0][0]) == 0)
        { TrEndDate.Visible = true; }
    }

    /// <summary>
    /// 绑定分类
    /// </summary>
    /// 当一个字典为问答的顶级字典，并且下面没有子字典的时候，
    /// 使DataList中的链接为他本身
    void BindCategory()
    {
        DataTable topData = dictionary.GetDictionary(cid);
        if (topData.Rows.Count == 0)
        {
            M_Dictionary dicModel = dictionary.GetModel(cid);
            int pid = dicModel.ParentId;
            if (pid == 5)
            {
                topData = new DataTable();
                topData.Columns.Add("Id", typeof(int));
                topData.Columns.Add("DicName", typeof(string));
                DataRow row = topData.NewRow();
                row[0] = dicModel.Id;
                row[1] = dicModel.DicName;
                topData.Rows.Add(row);
                listCategory.DataSource = topData;
                listCategory.DataBind();
            }
            else
            {
                cid = pid;
                BindCategory();
            }
        }
        else
        {
            listCategory.DataSource = topData;
            listCategory.DataBind();
        }
    }

    /// <summary>
    /// 绑定下拉列表
    /// </summary>
    void ddlBind()
    {
        ddlCategory.DataSource = dictionary.FormatCategory(8);
        ddlCategory.DataTextField = "DicName";
        ddlCategory.DataValueField = "DicId";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("请选择分类", "-1"));
    }

    /// <summary>
    /// 统计回答数，设置状态
    /// </summary>
    protected void rptING_DataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal litId = e.Item.FindControl("LitReplyCount") as Literal;
            Literal litDate = e.Item.FindControl("LitPostDate") as Literal;
            Literal litImg = e.Item.FindControl("LitSetImg") as Literal;
            Image img = e.Item.FindControl("imgState") as Image;
            if (litId != null)
            {
                DataSet data = feedback.GetFeedback(int.Parse(litId.Text));
                int replyCount = data.Tables[1].Rows.Count;
                litId.Text = replyCount.ToString();
                litDate.Text = data.Tables[0].Rows[0]["replyDate"].ToString();
                int state = Convert.ToInt32(data.Tables[0].Rows[0]["State"]);
                img.ImageUrl = (state == 1 || state == 2) ? Param.ApplicationRootPath + "/images/ed.gif" : Param.ApplicationRootPath + "/images/ing.gif";
                int reward = Convert.ToInt32(data.Tables[0].Rows[0]["reward"]);
                StringBuilder sbImg = new StringBuilder();
                if (reward > 0)
                {
                    sbImg.Append("<img src='");
                    sbImg.Append(Param.ApplicationRootPath);
                    sbImg.Append("/images/reward.gif' alt='悬赏分");
                    sbImg.Append(reward);
                    sbImg.Append("'/><span style='color:red'> ");
                    sbImg.Append(reward);
                    sbImg.Append("</span>");
                }
                litImg.Text = sbImg.ToString();
                //当需要显示零回答的问答时，隐藏回答数大于0的问答
                if (IsZero && replyCount > 0)
                { e.Item.Visible = false; }
            }
        }
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData(whereStr);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string filter = "";
        if (ddlCategory.SelectedValue != "-1")
        {
            filter += "&cid=" + ddlCategory.SelectedValue;
        }
        if (ddlState.SelectedValue != "-1")
        {
            if (ddlState.SelectedValue == "1")
            {
                filter += "&state=1";
            }
            if (ddlState.SelectedValue == "0")
            {
                filter += "&state=0";
            }
            else
            { filter += "&state=0"; }
        }
        if (txtSearch.Text != "")
        {
            filter += "&title=" + Function.UrlEncode(txtSearch.Text);
        }
        Response.Redirect("List.aspx?" + filter);
    }

    /// <summary>
    /// 创建分类链接和分类问答统计
    /// </summary>
    protected void listCategory_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal cat = e.Item.FindControl("LitCategory") as Literal;
            if (cat != null)
            {
                int key = Convert.ToInt32(listCategory.DataKeys[e.Item.ItemIndex]);
                M_Dictionary dicModel = dictionary.GetModel(key);
                cat.Text = "<a href='List.aspx?cid=" + key + "'>" + dicModel.DicName + "</a> (" + feedback.GetList(1, 1, "categoryId=" + dicModel.Id).Tables[1].Rows[0][0] + ")";
            }
        }
        if (e.Item.ItemType == ListItemType.Header)
        {
            Literal litHeader = e.Item.FindControl("LitHeaderName") as Literal;
            if (litHeader != null)
            {
                litHeader.Text = dictionary.GetModel(cid).DicName;
            }
        }
    }
}
