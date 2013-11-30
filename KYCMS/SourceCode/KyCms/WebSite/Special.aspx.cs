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

public partial class Special : System.Web.UI.Page
{
    int SpId = 0;
    int PageIndex = 1;
    B_Special SpecialBll = new B_Special();
    protected void Page_Load(object sender, EventArgs e)
    {
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
            Function.ShowMsg(0, "<li>对不起，你所访问的内容不存在或已经被删除</li>");
        }
        if (specialModel.IsLock)
        {
            Function.ShowMsg(0, "<li>该专题已被管理员锁定</li>");
        }
        B_Create bll = new B_Create();
        string url = bll.GetSpecialUrl(SpId, PageIndex);
        if (url.ToLower().Trim().IndexOf(".htm") != -1 || url.ToLower().Trim().IndexOf(".html") != -1 || url.ToLower().Trim().IndexOf(".shtml") != -1)
        {
            Response.Redirect(url);
            return;
        }
        Response.Write(bll.GetSpecialPage(SpId, PageIndex));
    }
}
