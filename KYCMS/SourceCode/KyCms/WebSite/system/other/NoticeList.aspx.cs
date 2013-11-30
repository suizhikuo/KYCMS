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

public partial class system_other_NoticeList : System.Web.UI.Page
{
    private B_Notice BNotice = new B_Notice();
    private M_Notice model = new M_Notice();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_Admin AdminBll = new B_Admin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminGroupBll.Power_Judge(46);
            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string UserId = Request.QueryString["UserId"];
        string TypeId = Request.QueryString["TypeId"];
        string WhereStr = "";

        if (UserId == null)
        {
            UserId = "0";
        }

        if (TypeId == null)
        {
            TypeId = "2";
        }

        if (UserId == "-1")
        {
            M_LoginAdmin model = AdminBll.GetLoginModel();
            UserId = model.UserId.ToString();
        }

        #region 条件判断
        if(TypeId=="1")
        {
            Label1.Text = "所有公告";
            WhereStr=" where Title like '%%'";
        }

        if(TypeId=="2")
        {
            Label1.Text = "审核通过";
            WhereStr = " where IsState='审核通过' and datediff(day,OverdueDate,getdate())<=0";
        }

        if(TypeId=="3")
        {
            Label1.Text = "草稿";
            WhereStr = " where IsState='草稿'";
        }

        if(TypeId=="4")
        {
            Label1.Text = "我发的公告";
            WhereStr=" where UserId="+UserId+"";
        }

        if(TypeId=="5")
        {
            Label1.Text = "过期公告";
            WhereStr=" where datediff(day,OverdueDate,getdate())>0";
        }
        #endregion


        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }
        DataSet ds = BNotice.GetList(int.Parse(P), Pager.PageSize, WhereStr);
        Repeater1.DataSource = ds.Tables[0].DefaultView;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0];
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    /// <summary>
    /// 删除选种记录
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
                    BNotice.Delete(int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("CID")).Text.ToString()));
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
            BNotice.Delete(id);

            DataBaseList();
        }

        if (e.CommandName == "IsState")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BNotice.UpdateIsState(id);

            DataBaseList();
        }
    }

    public string GetIsState(string IsState)
    {
        if (IsState == "草稿")
        {
            return "审核通过";
        }
        else
        {
            return "取消审核";
        }
    }
}
