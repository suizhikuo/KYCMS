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

public partial class system_WebMessage_WebMessageList : System.Web.UI.Page
{
    private B_WebMessage bll = new B_WebMessage();
    private M_WebMessage model = new M_WebMessage();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_Admin AdminBll = new B_Admin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminGroupBll.Power_Judge(47);
            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string TypeId = Request.QueryString["TypeId"];
        string WhereStr = "";
        string SearchId = Request.QueryString["SearchId"];
        string KeyWord = Function.UrlDecode(Request.QueryString["KeyWord"]);

        if (SearchId == null)
        {
            SearchId = "";
        }

        if (SearchId == "")
        {
            if (TypeId == null || TypeId == "")
            {
                TypeId = "1";
            }

            #region 条件判断
            if (TypeId == "1")
            {
                Label1.Text = "短消息管理";
                WhereStr = " where (AllUser=1 or SendId=0)";
            }

            if (TypeId == "2")
            {
                Label1.Text = "我的短消息";
                M_LoginAdmin loginModel = AdminBll.GetLoginModel();
                WhereStr = " where SendId=0 and SendName='" + loginModel.AdminName.ToString() + "'";
            }

            if (TypeId == "3")
            {
                Label1.Text = "批量删除短消息";
                WhereStr = " where ReceiverDel=1 and SendDel=1";
            }
            #endregion
        }
        else
        {
            if (SearchId == "1" || SearchId == "0")
            {
                Label1.Text = "主题中含有 <font color=red>" + KeyWord + "</font> 的短消息";
                WhereStr = " where Title like '%" + KeyWord + "%' and SendId=0";
            }

            if (SearchId == "2")
            {
                Label1.Text = "内容中含有 <font color=red>" + KeyWord + "</font> 的短消息";
                WhereStr = " where Content like '%" + KeyWord + "%' and SendId=0";
            }

            if (SearchId == "3")
            {
                Label1.Text = "发件为 <font color=red>" + KeyWord + "</font> 的短消息";
                WhereStr = " where SendName like '%" + KeyWord + "%' and SendId=0";
            }

            if (SearchId == "4")
            {
                Label1.Text = "收件人为 <font color=red>" + KeyWord + "</font> 的短消息";
                WhereStr = " where ReceiverName like '%" + KeyWord + "%' and SendId=0";
            }
        }

        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }

        DataSet ds = bll.GetList(int.Parse(P), Pager.PageSize, WhereStr);
        Repeater1.DataSource = ds.Tables[0].DefaultView;

        //DataTable dt = bll.GetList(P, Pager.PageSize, WhereStr);
        //Repeater1.DataSource = dt;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.Repeater1.Items.Count > 0)
        {
            for (int i = 0; i < this.Repeater1.Items.Count; i++)
            {
                if (((CheckBox)this.Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    bll.Delete(int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("CID")).Text.ToString()));
                }
            }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>无任何信息可删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        this.DataBaseList();
    }

    /// <summary>
    /// 删除单一记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            bll.Delete(id);

            DataBaseList();
        }
    }

    public string GetIsRead(string IsRead)
    {
        string sGetIsRead = "";

        if (IsRead == "0")
        {
            sGetIsRead = "<font color=red><b>×</b></font>";
        }
        else
        {
            sGetIsRead = "<font color='#009933'><b>√</b></font>";
        }

        return sGetIsRead;
    }

    //搜索
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sSearchId = SearchId.SelectedValue;
        string sKeyWord = KeyWord.Text;

        Response.Redirect("WebMessageList.aspx?SearchId=" + sSearchId + "&KeyWord=" + Function.UrlEncode(sKeyWord) + "");
        Response.End();
    }
}
