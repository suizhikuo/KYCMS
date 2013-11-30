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

public partial class Channel : System.Web.UI.Page
{
    protected B_Channel ChannelBll = new B_Channel();
    protected B_User UserBll = new B_User();
    protected B_UserGroup GroupBll = new B_UserGroup();
    int ChId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        M_Channel channelModel = ChannelBll.GetChannel(ChId);
        if (channelModel == null||channelModel.IsDeleted)
        {
            Function.ShowMsg(0,"<li>对不起，你所访问的页面不存在或已经被删除</li>");
            return;
        }
        bool isChDisabled = channelModel.IsDisabled;
        if (isChDisabled)
        {
            Function.ShowMsg(0,"<li>该频道已经被管理员禁用</li>");
            return;
        }

        B_Create bll = new B_Create();
        string url = bll.GetChannelUrl(ChId);
        if (url.ToLower().Trim().IndexOf(".htm") != -1 || url.ToLower().Trim().IndexOf(".html") != -1 || url.ToLower().Trim().IndexOf(".shtml") != -1)
        {
            Response.Redirect(url);
            return;
        }

        if (channelModel.IsOpened)
        {
            Response.Write(bll.GetChannelPage(ChId));
        }
        else
        {
            M_User logModel = UserBll.GetCookie();
            M_User userModel = UserBll.GetUser(logModel.LogName);
            M_UserGroup groupModel = GroupBll.GetModel(userModel.GroupID);
            if (GroupBll.Power_ColumnPower(ChId, 0, groupModel.ColumnPower, 2))
            {
                Response.Write(bll.GetChannelPage(ChId));
            }
            else
            {

                Function.ShowMsg(0,"<li>您所在的用户组无法访问该内容,请联系系统管理员</li>");
                return;
              
            }
        }
    }
}
