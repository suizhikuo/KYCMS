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

public partial class system_PreChannel : System.Web.UI.Page
{
    protected B_Channel ChannelBll = new B_Channel();
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup GroupBll = new B_PowerGroup();
    int ChId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        M_Channel channelModel = ChannelBll.GetChannel(ChId);
        if (channelModel == null)
        {
            Function.ShowSysMsg(0, "<li>对不起，你所访问的页面不存在</li>");
            return;
        }
        GroupBll.Power_Judge(36);
        B_Create bll = new B_Create();
        Response.Write(bll.GetChannelPage(ChId));
    }
}
