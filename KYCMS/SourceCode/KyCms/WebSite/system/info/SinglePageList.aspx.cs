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

public partial class system_info_SinglePageList : System.Web.UI.Page
{
    private B_SinglePage BSinglePage = new B_SinglePage();
    private M_SinglePage MsinglePage = new M_SinglePage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }

        DataSet ds = BSinglePage.GetList(int.Parse(P), Pager.PageSize);
        Repeater1.DataSource = ds.Tables[0].DefaultView;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
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
            BSinglePage.Delete(id);

            DataBaseList();
        }

        if (e.CommandName == "Create")
        {
            B_Create bcreatebll = new B_Create();
            int id = int.Parse(e.CommandArgument.ToString());

            if (bcreatebll.CreateSinglePage(id))
            {
                Response.Redirect("../Msg.aspx?Flag=1&Code=" + Function.UrlEncode("<li>生成单页信息成功!</li><li><a href='info/SinglePageList.aspx'>返回单页列表</a></li>") + "");
                Response.End();
            }
            else
            {
                Response.Redirect("../Msg.aspx?Flag=0&Code=" + Function.UrlEncode("<li>生成单页信息失败!</li><li><a href='info/SinglePageList.aspx'>返回单页列表</a></li>") + "");
                Response.End();
            }
        }
    }
}
