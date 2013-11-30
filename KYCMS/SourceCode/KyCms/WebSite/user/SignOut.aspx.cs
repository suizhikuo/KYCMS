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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class user_SignOut : System.Web.UI.Page
{
    B_BBSUser bbsUserBll = new B_BBSUser();
    string returnUrl = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //更新在线状态（最好是放到 Session_End 里面去执行）
        Response.Cache.SetNoStore();
        B_User user = new B_User();
        M_User userModel = user.GetCookie(); 
        
        B_Create createBll = new B_Create();
        bbsUserBll.LoginOut(userModel.LogName);

        user.ExpireCookie();
        bbsUserBll.ClearUserCookie();
         if (!string.IsNullOrEmpty(Request.QueryString["returnurl"]))
        {
            returnUrl = Request.QueryString["returnurl"];
        }
        if (returnUrl != string.Empty)
        {
            Response.Redirect(returnUrl);
        }
        Response.Redirect(createBll.GetIndexUrl());
    }
}
