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

public partial class system_collection_SuperiorManger : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Superior SuperiorBll = new B_Superior();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        if (!IsPostBack)
        {
            SuperiorBind();
        }
    }

    #region 绑定采集
    private void SuperiorBind()
    {
        repSuperior.DataSource =SuperiorBll.GetList();
        repSuperior.DataBind();
    }
    #endregion

    protected void repSuperior_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        HiddenField hidSuperior = e.Item.FindControl("hidSuperiorId") as HiddenField;
        SuperiorBll.Delete(int.Parse(hidSuperior.Value));
        SuperiorBind();
    }
}
