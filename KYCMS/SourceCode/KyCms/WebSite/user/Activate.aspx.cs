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

public partial class user_Activate : System.Web.UI.Page
{
    string IndexUrl = "";
    B_Create CreateBll = new B_Create();
    B_User Bll = new B_User();
    M_User Model = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        IndexUrl=CreateBll.GetIndexUrl();
        hylnkIndex.NavigateUrl = IndexUrl;
        if (Request.QueryString["uid"] != null && Request.QueryString["code"] != null)
        {
            int userId = Function.CheckInteger(Request.QueryString["uid"]) ? int.Parse(Request.QueryString["uid"]) : 0;
            Model = Bll.GetUser(userId);
            if (Model != null)
            {
                if (Request.QueryString["code"] == Model.ConfirmRegCode)
                {
                    Bll.SetUserLockStatus(userId, false);
                    Bll.UpdateRegCode(userId, Guid.NewGuid().ToString());
                    Function.ShowMsg(1, "<li>"+Model.LogName+"，恭喜，您的帐号已成功激活！</li><li><a href='Main.aspx'>登录用户中心</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                }
                else
                {
                    Function.ShowMsg(0, "<li>激活帐号失败！原因：参数不匹配</li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                }
            }
            else
            {
                Function.ShowMsg(0, "<li>激活帐号失败！原因：无效的参数</li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
            }
        }
    }
}
