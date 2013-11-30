using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class User_Recharge : System.Web.UI.Page
{
    B_User user = new B_User();
    M_User model = new M_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        user.CheckIsLogin();
        LitMsg.Text = "";
    }

    /// <summary>
    /// 充值
    /// </summary>
    protected void btnCharge_Click(object sender, EventArgs e)
    {
        model = user.GetCookie();
        if (Function.MD5Encrypt(txtUserPwd.Text) == model.UserPwd)
        {
            int flag = user.Recharge(model.UserID, txtCardAccount.Text, txtCardPwd.Text);
            switch (flag)
            {
                case 1:
                    Function.ShowMsg(1, "<li>充值成功</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    break;
                case 2:
                    Function.ShowMsg(0, "<li>对不起,卡已失效</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");

                    break;
                case 3:
                    Function.ShowMsg(0, "<li>对不起,卡已过期</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    break;
                case 4:
                    Function.ShowMsg(0, "<li>对不起,卡号和密码不匹配</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    break;
                default:
                    break;
            }
        }
        else
        {
            Function.ShowMsg(0, "<li>对不起,您输入的登录密码错误</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
    }
}

