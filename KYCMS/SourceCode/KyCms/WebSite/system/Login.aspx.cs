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
using System.Net;

public partial class System_Login : System.Web.UI.Page
{
    B_Admin Bll = new B_Admin();
    protected bool IsOpenRZM = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        B_SiteInfo bll = new B_SiteInfo();
        M_Site model = bll.GetSiteModel();
        if (model != null)
        {
            IsOpenRZM = model.IsOpenRZM;
        }
    }

   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
            string validateCode = string.Empty;
            if (Session["ValidateCode"] == null)
            {
                Function.ShowSysMsg(0, "<li>你在登陆页面停留的时间过长，验证码已失效</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }
            validateCode = Session["ValidateCode"].ToString();
            //验证码错误
            if (validateCode != txtValidate.Text.Trim().ToLower())
            {
                Function.ShowSysMsg(0, "<li>验证码错误</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }

            if (IsOpenRZM&&Param.RzmNumber != txtAdminRzm.Text.Trim())
            {
                Function.ShowSysMsg(0, "<li>管理员认证码错误</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }

            
            string userName = txtAdminName.Text.Trim();
            string userPass = Function.MD5Encrypt(txtAdminPass.Text.Trim());
            M_Admin model = Bll.GetModel(userName, userPass);
            if (model == null)
            {
                Function.ShowSysMsg(0, "<li>用户名和密码错误</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }
            else
            {
               Bll.SetLoginState(model);
            }
       
    }
}
