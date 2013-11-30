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

public partial class system_info_SinglePageUrl : System.Web.UI.Page
{
    private B_SinglePage BSinglePage = new B_SinglePage();
    private M_SinglePage MsinglePage = new M_SinglePage();
    protected int SingleId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["SingleId"]))
            {
                try
                {
                    SingleId = int.Parse(Request.QueryString["SingleId"]);
                }
                catch { }
            }

            MsinglePage = BSinglePage.GetModel(SingleId);

            if (!Page.IsPostBack)
            {
                FormName.Text = MsinglePage.Name;
                TextBox1.Text = "<a href=\"" + Param.ApplicationRootPath + "" + MsinglePage.FolderPath + "" + MsinglePage.FileName + "" + MsinglePage.FileExtend + "\" target=\"_blank\">" + MsinglePage.Name + "</a>";
            }
        }
    }
}
