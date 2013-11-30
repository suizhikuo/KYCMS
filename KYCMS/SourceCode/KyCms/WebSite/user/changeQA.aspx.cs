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


public partial class user_changeQA : System.Web.UI.Page
{
    M_User model = new M_User();
    B_User bll = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        model = bll.GetUser(bll.GetCookie().LogName);
        if (model != null)
        {
            lbQuestion.Text = Server.HtmlEncode(model.Question);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    /// <summary>
    /// 修改密码保护
    /// </summary>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (Function.MD5Encrypt(txtAnswer.Text.Trim()) == model.Answer)
        {
            if (txtNewQuestion.Text.Trim() == "")
            {
                Function.ShowMsg(0, "<li>请输入新的提示问题</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }

            if (txtNewAnswer.Text.Trim() == "")
            {
                Function.ShowMsg(0, "<li>请输入新的提示问题答案</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }

            bll.ModifyQuestion(model.UserID, txtNewQuestion.Text.Trim(), Function.MD5Encrypt(txtNewAnswer.Text.Trim()));

            Function.ShowMsg(1, "<li>修改密码保护成功</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        else
        {
            Function.ShowMsg(0, "<li>对不起,您的回答错误</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
    }
}
