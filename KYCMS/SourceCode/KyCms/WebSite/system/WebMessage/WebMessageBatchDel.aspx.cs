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

public partial class system_WebMessage_WebMessageBatchDel : System.Web.UI.Page
{
    private B_WebMessage bll = new B_WebMessage();
    private M_WebMessage model = new M_WebMessage();
    private B_User buser = new B_User();
    private M_User muser = new M_User();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminGroupBll.Power_Judge(47);
            Table1.Visible = true;
            Table2.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sAllUser = AllUser.Text;
        DataTable dt = new DataTable();

        for (int i = 0; i < Function.GetSplit(sAllUser, "|").Length; i++)
        {
            muser = buser.GetUser(Function.GetSplit(sAllUser, "|")[i]);            

            if (muser.UserID != 0)
            {
                dt = bll.GetList(" where ReceiverId=" + muser.UserID + "");

                if (dt.Rows.Count > 0)
                {
                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        bll.Delete(int.Parse(dt.Rows[d]["WMId"].ToString()));
                    }
                }
            }
        }

        Label1.Text = dt.Rows.Count.ToString();

        dt.Clear();
        dt.Dispose();

        Table1.Visible = false;
        Table2.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string sDropDownList1 = DropDownList1.SelectedValue;
        DataTable dt = new DataTable();

        if (sDropDownList1 == "0")
        {
            dt = bll.GetList("");
        }
        else
        {
            dt = bll.GetList(" WHERE (DATEDIFF(day, AddDate, GETDATE()) >= " + sDropDownList1 + ")");
        }

        if (dt.Rows.Count > 0)
        {
            for (int d = 0; d < dt.Rows.Count; d++)
            {
                bll.Delete(int.Parse(dt.Rows[d]["WMId"].ToString()));
            }
        }

        Label1.Text = dt.Rows.Count.ToString();

        dt.Clear();
        dt.Dispose();

        Table1.Visible = false;
        Table2.Visible = true;
    }
}
