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

public partial class user_Friend_ShowPic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        B_User User = new B_User();
        User.CheckIsLogin();
        string qryStr = Request.QueryString["path"];
        if (!string.IsNullOrEmpty(qryStr))
        {
            img.ImageUrl = Param.ApplicationRootPath + "/Upload/User/" + Function.UrlDecode(qryStr);
        }
    }
}
