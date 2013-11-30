using System;
using System.Data;
using System.Web.UI.WebControls;
using Ky.BLL;
using Ky.Common;
using Ky.Model;

public partial class System_user_Card : System.Web.UI.Page
{    
    B_Card card = new B_Card();
    B_Admin admin = new B_Admin();
    B_PowerGroup power = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        power.Power_Judge(5);
        
        if (!IsPostBack)
        {
            ViewState["SortStr"] = "IsUsed asc,OverdueDate desc";
            BindCards();            
        }
    }

    /// <summary>
    /// 从DB中获取数据
    /// </summary>
    /// <returns>数据</returns>
    void BindCards()
    {
        int total = 0;

        DataSet _data;
        string whereStr = "";
        string sortStr = "";
        if(ViewState["WhereStr"] !=null)
        {
            whereStr = ViewState["WhereStr"].ToString();
        }
        if (ViewState["SortStr"] != null)
        {
            sortStr = ViewState["SortStr"].ToString();
        }

        _data = card.GetCards(Pager.PageSize, Pager.CurrentPageIndex, whereStr);
        total = (int)(_data.Tables["Total"].Rows[0][0]);
        DataView dv = _data.Tables[0].DefaultView;        
        dv.Sort = sortStr;
        gvCardList.DataSource = dv;
        gvCardList.DataBind();
        Pager.RecordCount = total;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    /// <summary>
    /// 设置样式
    /// </summary>
    protected void gvCardList_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label used = (Label)e.Row.FindControl("lbIsUsed");
            used.Text = used.Text == "False" ? "否" : "是";
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");

            Label overdueString = e.Row.Cells[6].Controls[1] as Label;

            DateTime overdueDate = DateTime.Parse(overdueString.Text);
            if (overdueDate < DateTime.Now.Date)
            {
                overdueString.Text = overdueString.Text + "<span style='color:Red'>(已过期)</span>";
            }
        }
    }

    /// <summary>
    /// 删除一张卡
    /// </summary>
    protected void gvCardList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string key = (string)gvCardList.DataKeys[e.RowIndex].Value;
        card.Delete(key);
        BindCards();
    }

    /// <summary>
    /// 所有未消费卡
    /// </summary>
    protected void lnkbtnUnused_Click(object sender, EventArgs e)
    {
        ViewState["WhereStr"] = "IsUsed=0";
        ViewState["SortStr"] = "OverdueDate desc";
        BindCards();
    }

    /// <summary>
    /// 所有已消费的卡
    /// </summary>
    protected void lnkbtnUsed_Click(object sender, EventArgs e)
    {
        ViewState["WhereStr"] = "IsUsed=1";
        ViewState["SortStr"] = "OverdueDate desc";
        BindCards();
    }
    /// <summary>
    /// 所有已过期的卡
    /// </summary>
    protected void lnkbtnOverdue_Click(object sender, EventArgs e)
    {
        ViewState["WhereStr"] = "OverdueDate<'" + DateTime.Now.ToShortDateString() + "'";
        ViewState["SortStr"] = "IsUsed asc";
        BindCards();
    }

    /// <summary>
    /// 查看所有卡
    /// </summary>
    protected void lnkbtnAll_Click(object sender, EventArgs e)
    {
        ViewState["WhereStr"] = "";
        ViewState["SortStr"] = "IsUsed asc,OverdueDate desc";
        BindCards();
    } 

    /// <summary>
    /// 查看卡信息
    /// </summary>
    protected string ViewCard(object cardAccount)
    {
        if (cardAccount != null && cardAccount.ToString() != "")
        {
            return "SetCard.aspx?action=view&key="+Function.UrlEncode(cardAccount.ToString());
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteSelectd_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvCardList.Rows.Count; i++)
        {
            CheckBox chk = gvCardList.Rows[i].FindControl("chkBox") as CheckBox;
            if (chk != null && chk.Checked)
            {
                card.Delete(gvCardList.DataKeys[i].Value.ToString());
            }
        }
        BindCards();       
    }

    /// <summary>
    /// 查看所有卡列表
    /// </summary>
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (txtPageSize.Text.Trim() != "")
        {
            try
            {
                Pager.PageSize = int.Parse(txtPageSize.Text);
            }
            catch
            {
                LitMsg.Text = "<script type='text/javascript'>alert('输入条数格式不正确')</script>";
            }
            BindCards();
        }
    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindCards();
    }
}
