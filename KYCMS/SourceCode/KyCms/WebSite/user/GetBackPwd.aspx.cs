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
using System.Text;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

/// <summary>
/// 这个页面不能禁用ViewState
/// </summary>
public partial class user_GetBackPwd : System.Web.UI.Page
{
    B_User bll = new B_User();
    B_Create CreateBll = new B_Create();
    string IndexUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        IndexUrl = CreateBll.GetIndexUrl();
        hylnkIndex.NavigateUrl = IndexUrl;
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
    protected void btnInputName_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
        {
            M_User model = bll.GetUser(txtUserName.Text);
            if (model != null)
            {
                if (model.Question == "")
                {
                    Function.ShowMsg(0, "<li>您没有设置密码保护，无法使用该功能！</li><li><a href='Reg.aspx'>重新注册账户</a></li><li><a href='"+IndexUrl+"'>返回网站首页</a></li>");
                }
                MultiView1.ActiveViewIndex = 1;
                lbQuestion.Text = Function.HtmlEncode(model.Question);
            }
            else
            {
                //无此用户
                Function.ShowMsg(0, "<li>无此用户</li><li><a href='Reg.aspx'>注册一个新帐户</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
            }
        }
        else
        {
            //请输入用户
            Function.ShowMsg(0, "<li>请输入用户名!</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
    }
    protected void btnQuestion_Click(object sender, EventArgs e)
    {
        M_User model = bll.GetUser(txtUserName.Text);
        if (model != null)
        {
            if (Function.MD5Encrypt(txtAnswer.Text.Trim()) == model.Answer)
            {
                B_SiteInfo site = new B_SiteInfo();
                M_Site siteModel = site.GetSiteModel();
                //产生随机密码
                //更新数据库
                string Pwd = Function.GetRndNum(8);
                string newPwd = Function.MD5Encrypt(Pwd);
                bll.ModifyPwd(model.UserID, newPwd);

                if (siteModel != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(txtUserName.Text + ",您好!您在本站 (");
                    sb.Append(siteModel.SiteName + ")");
                    sb.Append("使用了找回密码功能.这是您的新密码:");
                    sb.Append(Pwd);
                    sb.Append("祝您健康愉快!");
                    sb.Append(siteModel.SiteName);
                    sb.Append(DateTime.Now);
                    try
                    {
                        B_SendMail mail = new B_SendMail(siteModel.EmailServerAddress, model.Email, txtUserName.Text + "您好!这是您的新密码", sb.ToString(), true, System.Text.Encoding.UTF8);
                        mail.Send();
                        Function.ShowMsg(1, "<li>恭喜！找回密码成功。您的新密码已经发送到您的邮箱，请注意查收！</li><li><a href='Login.aspx'>登录</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                    }
                    catch
                    {
                        Function.ShowMsg(1, "<li>恭喜！找回密码成功。这是您的新密码："+Pwd+"</li><li><a href='Login.aspx'>登录</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                    }

                }
            }
            else
            {
                Function.ShowMsg(0, "<li>对不起，您的答案不正确！</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }
        else
        {
            //无此用户            
            Function.ShowMsg(0, "<li>无此用户</li><li><a href='Reg.aspx'>注册一个新帐户</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
        }
    }
}
