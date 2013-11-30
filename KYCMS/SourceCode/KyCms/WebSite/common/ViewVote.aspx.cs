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

public partial class common_ViewVote : System.Web.UI.Page
{
    B_Vote bll = new B_Vote();
    int vid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["vid"]))
            {
                if (Function.CheckNumber(Request.QueryString["vid"]))
                {
                    vid = int.Parse(Request.QueryString["vid"]);
                    BindData(vid);
                }
            }
        }
    }

    void BindData(int vid)
    {
        for (int i = 0; i < 3; i++)
        {
            HtmlTable tables = Page.FindControl("Table" + i) as HtmlTable;
            tables.Visible = false;
        }
        DataTable dt = bll.GetSubject(vid);
        if (dt != null && dt.Rows.Count > 0)
        {
            int SUM = 0;
            int TOTAL = 0;
            lbTitle.Text = Function.HtmlEncode(dt.Rows[0]["Subject"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlTable showTable = Page.FindControl("Table" + i) as HtmlTable;
                showTable.Visible = true;
                int I = i + 1;
                Label title = (Label)Page.FindControl("lbVoteTitle" + I);
                title.Text = dt.Rows[i]["VoteTitle"].ToString();
                for (int k = 1; k <= 6; k++)
                {
                    TOTAL += int.Parse(dt.Rows[i]["ItemNum" + k].ToString());
                }
                SUM += TOTAL;
                Label lbTotal = (Label)Page.FindControl("lbTotal" + I);
                lbTotal.Text = TOTAL.ToString();

                for (int m = 1; m <= 6; m++)
                {

                    if (string.IsNullOrEmpty(dt.Rows[i]["ItemTitle" + m].ToString()))
                    {
                        HtmlTableRow hideRow = Page.FindControl("tr" + I + m) as HtmlTableRow;
                        hideRow.Visible = false;
                    }
                    else
                    {
                        Label item = (Label)Page.FindControl("lbItem" + I + m);
                        item.Text = Function.HtmlEncode(dt.Rows[i]["ItemTitle" + m].ToString());
                        Label num = (Label)Page.FindControl("lbItem" + I + m + "num");
                        Image img = (Image)Page.FindControl("Image" + I + m);
                        Label bfb = (Label)Page.FindControl("lbItemBFB" + I + m);

                        num.Text = dt.Rows[i]["ItemNum" + m].ToString();

                        double width;
                        if (TOTAL > 0)
                        {
                            width = Math.Round(((double.Parse(dt.Rows[i]["ItemNum" + m].ToString())) / double.Parse(TOTAL.ToString())), 4);
                        }
                        else
                        {
                            width = 0.0;
                        }

                        bfb.Text = width * 100 + "%";//显示百分比

                        img.Width = new Unit(bfb.Text);
                        img.Height = new Unit(7);
                        img.ImageUrl = Param.ApplicationRootPath + "/system/images/ico/vote.gif";
                    }
                }
                TOTAL = 0;
                lbSum.Text = SUM.ToString();
            }
        }
        else
        {
            LitMsg.Text = "<script type='text/javascript'>alert('未能获取到数据')</script>";
            return;
        }
    }
}
