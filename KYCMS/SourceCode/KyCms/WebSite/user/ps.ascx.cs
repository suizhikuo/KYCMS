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

public partial class ps : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string js = "function chkPs(ipt){var msg = document.getElementById(\"msg\");if(ipt.length == 0){msg.style.backgroundColor=\"#E0E0E0\";msg.innerHTML=\"密码强度\";return;}if(ipt.length<=6){msg.style.backgroundColor=\"#FFC8D9\";msg.innerHTML = \"<span style='color:#AA0033'>低</span>\";}else{var patt1= (ipt.search(/[a-zA-Z]/)!=-1) ? 1 : 0;var patt2= (ipt.search(/[0-9]/)!=-1) ? 1 : 0;var patt3= (ipt.search(/[^A-Za-z0-9_]/)!=-1) ? 1 : 0;var flag=patt1+patt2+patt3;if(flag==1){msg.style.backgroundColor=\"#FFC8D9\";msg.innerHTML = \"<span style='color:#AA0033'>低</span>\";}else if(flag==2){msg.style.backgroundColor=\"#6699cc\";msg.innerHTML = \"<span style='color:#FFF'>中</span>\";}else if(flag==3){msg.style.backgroundColor=\"#8FFB84\";msg.innerHTML = \"<span style='color:#009900'>高</span>\";}}}";
        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "chkPs", js, true);
    }
}
