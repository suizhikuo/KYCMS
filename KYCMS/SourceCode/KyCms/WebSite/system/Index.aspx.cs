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

public partial class System_Index : System.Web.UI.Page
{
    protected B_Admin AdminBll = new B_Admin();
    protected M_LoginAdmin Model = null;
    protected M_Admin AdminModel = null;
    protected B_SiteInfo SiteBll = new B_SiteInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        M_Site siteModel = SiteBll.GetSiteModel();
        string titleStr = siteModel.SiteName == string.Empty ? "KYCMS" : siteModel.SiteName;
        Header.Title = titleStr + "管理后台";
     }
}
