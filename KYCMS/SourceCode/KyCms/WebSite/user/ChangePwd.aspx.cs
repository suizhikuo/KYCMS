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
using Ky.Common;
using Ky.Model;

public partial class Users_ChangePwd : System.Web.UI.Page
{
    B_User user = new B_User();
    M_User model = null;
    B_BBSUser bbsUserBll = new B_BBSUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        model = user.GetUser(user.GetCookie().LogName);
        txtUserName.Text = model.LogName;
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (model != null)
        {
            string pwd = Function.MD5Encrypt(txtPwd.Text);
            if (txtPwd.Text=="")
            {
                Function.ShowMsg(0, "<li>对不起，原始密码不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }

            if (model.UserPwd == pwd)
            {
                if (txtNewpwd.Text.Length < 6 || txtNewpwd.Text.Length > 20)
                {
                    Function.ShowMsg(0,"<li>对不起，新密码长度应介于6-20位字符</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                }
                if (txtNewpwd.Text != txtConfirmPwd.Text)
                {
                    Function.ShowMsg(0, "<li>对不起，两次输入的新密码不一致</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                }
                string newPwd = Function.MD5Encrypt(txtConfirmPwd.Text);
                user.ModifyPwd(model.UserID, newPwd);
                bbsUserBll.UpdatePwd(model.LogName, txtConfirmPwd.Text);
                //user.ExpireCookie();
                Function.ShowMsg(1, "<li>修改密码成功</li><li><a href='Login.aspx'>重新登录</a></li><li><a href='welcome.aspx'>返回用户后台首页</a></li>");
            }
            else
            {
                Function.ShowMsg(0, "<li>对不起，原密码错误</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }
    }
}
