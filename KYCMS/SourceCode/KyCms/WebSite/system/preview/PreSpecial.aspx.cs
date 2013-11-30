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

public partial class system_PreSpecial : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    B_Special SpecialBll = new B_Special();
    B_PowerGroup AdminGroupBll = new B_PowerGroup(); 
    int SpId = 0;
    int PageIndex = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        if (!string.IsNullOrEmpty(Request.QueryString["SpId"]))
        {
            try
            {
                SpId = int.Parse(Request.QueryString["SpId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                PageIndex = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
        M_Special specialModel = SpId <= 0 ? null : SpecialBll.GetSpecial(SpId);

        if (specialModel == null || specialModel.IsDeleted)
        {
            Function.ShowSysMsg(0, "<li>对不起，你所访问的页面不存在</li>");
            return;
        }
        if (specialModel.IsLock)
        {
            Function.ShowSysMsg(0, "<li>该专题已被管理员锁定</li>");
        }
        AdminGroupBll.Power_Judge(3);
        B_Create bll = new B_Create();
        Response.Write(bll.GetSpecialPage(SpId, PageIndex));
    }
}
