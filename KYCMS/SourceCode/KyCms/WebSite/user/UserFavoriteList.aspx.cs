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

public partial class user_UserFavoriteList : System.Web.UI.Page
{
    private B_UserFavorite buserfavorite = new B_UserFavorite();
    private M_User muser = new M_User();
    private B_User buser = new B_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            buser.CheckIsLogin();

            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string P = Request.QueryString["p"];

        muser = buser.GetCookie();

        if (P == "" || P == null)
        {
            P = "1";
        }
        DataSet ds = buserfavorite.GetList(int.Parse(P), Pager.PageSize, " where UserId=" + muser.UserID + "");
        Repeater1.DataSource = ds.Tables[0].DefaultView;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0];
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.Repeater1.Items.Count > 0)
        {
            for (int i = 0; i < this.Repeater1.Items.Count; i++)
            {
                if (((CheckBox)this.Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    buserfavorite.Delete(int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("CID")).Text.ToString()));
                }
            }
        }
        else
        {
            base.Response.Write("<script language=javascript>alert('无任何信息！');</script>");
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
            buserfavorite.Delete(id);

            DataBaseList();
        }
    }
}
