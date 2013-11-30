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
public partial class userspace_LoginInfo : System.Web.UI.Page
{
    protected B_User userBll = new B_User();
    protected M_User userModel = null;

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}
