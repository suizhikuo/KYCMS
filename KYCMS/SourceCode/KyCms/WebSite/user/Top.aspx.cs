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
public partial class user_Top : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    M_User UserModel = null;
    protected string UserName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        UserModel = UserBll.GetCookie();
        UserName = UserModel.LogName;
    }
}
