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

public partial class Column : System.Web.UI.Page
{
    B_Column ColumnBll = new B_Column();
    B_Channel ChannelBll = new B_Channel();
    protected B_User UserBll = new B_User();
    protected B_UserGroup GroupBll = new B_UserGroup();
    int ColId = 0;
    int P = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColId = int.Parse(Request.QueryString["ColId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                P = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
        M_Column columnModel = ColumnBll.GetColumn(ColId);
        if (columnModel == null || columnModel.IsDeleted)
        {
            Function.ShowMsg(0,"<li>对不起，你所访问的页面不存在或已经被删除</li>");
            return;
        }
        M_Channel channelModel = ChannelBll.GetChannel(columnModel.ChId);
        if (channelModel == null || channelModel.IsDeleted)
        {
            Function.ShowMsg(0,"<li>所属频道不存在或已经被删除</li>");
            return;
        }
        bool isChDisabled = channelModel.IsDisabled;
        if (isChDisabled)
        {
            Function.ShowMsg(0,"<li>该频道已经被管理员禁用</li>");
            return;
        }
        B_Create bll = new B_Create();
        string url = bll.GetColumnUrl(ColId, 1);
        if (url.ToLower().Trim().IndexOf(".htm") != -1 || url.ToLower().Trim().IndexOf(".html") != -1 || url.ToLower().Trim().IndexOf(".shtml") != -1)
        {
            Response.Redirect(url);
            return;
        }
        if (columnModel.IsOpened)
        {
            Response.Write(bll.GetColumnPage(ColId, P));
        }
        else
        {
            M_User logModel = UserBll.GetCookie();
            M_User userModel = UserBll.GetUser(logModel.LogName);
            M_UserGroup groupModel = GroupBll.GetModel(userModel.GroupID);
            if (GroupBll.Power_ColumnPower(columnModel.ChId, ColId, groupModel.ColumnPower, 2))
            {
                Response.Write(bll.GetColumnPage(ColId, P));
            }
            else
            {
                Function.ShowMsg(0,"<li>您所在的用户组无法访问该内容,请联系系统管理员</li>");
                return;
            }
        }

        
    }
}
