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

public partial class user_Notice_ShowNotice : System.Web.UI.Page
{
    private B_Notice BNotice = new B_Notice();
    private M_Notice model = new M_Notice();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string NoticeId = Request.QueryString["NoticeId"];

            if (NoticeId == null)
            {
                NoticeId = "";
            }

            if (NoticeId != "")
            {
                model = BNotice.Show(int.Parse(NoticeId));

                Label1.Text = model.Title;
                Label2.Text = model.Content;
                Label5.Text = model.OverdueDate.ToShortDateString();
                Label4.Text = model.AddDate.ToShortDateString();
                Label3.Text = model.UserName;
            }
            else
            {
                Response.Redirect("NoticeList.aspx");
                Response.End();
            }
        }
    }
}
