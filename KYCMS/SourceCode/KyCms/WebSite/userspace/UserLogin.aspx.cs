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
public partial class userspace_UserLogin : System.Web.UI.Page
{
    protected B_User userBll = new B_User();
    B_Create CreateBll = new B_Create();
    string IndexUrl = "";
    B_SiteInfo siteBll = new B_SiteInfo();
    string logName = "";
    string pwd = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        IndexUrl = CreateBll.GetIndexUrl();
        Response.Cache.SetNoStore();

        if (siteBll.GetSiteModel().IsLoginValidate)
        {
            TrValidCode.Visible = true;
            imgCode.Visible = true;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string valideCode = "";
        lbMsg.Text = "";
        if (Request.Form["txtUserName"] != null && Request.Form["txtPwd"] != null)
        {
            logName = Function.UrlDecode(Request.Form["txtUserName"].ToString());
            pwd = Function.MD5Encrypt(Request.Form["txtPwd"].ToString());
        }
        if (siteBll.GetSiteModel().IsLoginValidate)
        {
            if (Request.Form["txtValidateCode"] == null)
            {
                lbMsg.Text = "<script>alert('请输入验证码')</script>";
                return;
            }
            else
            {
                valideCode = Request.Form["txtValidateCode"].ToString().ToLower();
            }
            if (Session["ValidateCode"] != null)
            {
                if (valideCode != Session["ValidateCode"].ToString())
                {
                    lbMsg.Text = "<script>alert('对不起,输入的验证码错误.请重新输入');</script>";
                    imgCode.ImageUrl = "~/common/Code.aspx";
                }
            }
            else
            {
                lbMsg.Text = "<script>alert('对不起,您在本页停留时间太长,请退出');hiddenIframe();</script>";
            }
        }
        B_SiteInfo siteInfo = new B_SiteInfo();
        M_Site siteModel = siteInfo.GetSiteModel();
        M_User model = userBll.GetUser(logName);
        if (model != null && siteModel != null)
        {
            //用户被锁定
            if (model.IsLock == true)
            {
                lbMsg.Text = "<script>alert('对不起,您已经被锁定,不能登录.')</script>";
                return;
            }
            //用户还在禁止登录时间内
            if (model.ErrorTime > DateTime.Now)
            {
                lbMsg.Text = "<script>alert('对不起,您已经登录错误 " + siteModel.LogErrorNum + " 次,将被禁止登录 " + siteModel.DisabledLoginTime + " 分钟.')</script>";
                return;
            }
            else
            {
                //用户登录
                bool flag = userBll.Login(logName, pwd);
                if (flag)
                {
                    HttpCookie cookie = new HttpCookie("User");
                    cookie["uId"] = model.UserID.ToString();
                    cookie["logN"] = model.LogName;
                    cookie["pd"] = model.UserPwd;
                    //cookie过期时间20分钟
                    cookie.Expires = DateTime.Now.AddMinutes(20);
                    Response.Cookies.Add(cookie);

                    //更新登录信息
                    string lastLoginIP = string.Empty;
                    if (Request.UserHostAddress != null)
                    {
                        lastLoginIP = Request.UserHostAddress;
                    }
                    DateTime currLoginTime = DateTime.Now;
                    DateTime oldLoginTime = model.LastLoginTime;
                    userBll.LoginSuccess(model.UserID, lastLoginIP, currLoginTime);
                    if (currLoginTime.Date != oldLoginTime.Date)
                    {
                        B_Money moneyBll = new B_Money();
                        moneyBll.Integral(siteModel.LoginScore, model.UserID);
                    }
                    //lbMsg.Text = "<script>hiddenIframe();parent.divLoginInfo.innerHTML=\"" + userBll.GetCookie().LogName + " 您好！┆<a href='../user/main.aspx' target='_blank' target='_blank'>发表文章</a>┆<a href='SignOut.aspx'>安全退出</a>\";</script>";
                    lbMsg.Text = "<script>hiddenIframe();parent.location.reload()</script>";
                }

                //登录失败
                //检查错误次数,如果达到设定次数,
                //则更新禁止登录时间
                else
                {
                    //修改时间
                    if (model.ErrorNum >= (siteModel.LogErrorNum - 1))
                    {
                        DateTime errorTime = DateTime.Now.AddMinutes(siteModel.DisabledLoginTime);
                        userBll.LoginFailOnErrorNum(model.UserID, errorTime);
                        lbMsg.Text = "<script>alert('对不起,您已经登录错误 " + siteModel.LogErrorNum + " 次,将被禁止登录 " + siteModel.DisabledLoginTime + " 分钟.')</script>";
                        return;
                    }
                    // 修改次数
                    else
                    {
                        userBll.LoginFailError(model.UserID);
                        lbMsg.Text = "<script>alert('对不起,登录失败!请检查您的用户名和密码.')</script>";
                        return;
                    }
                }
            }
        }

        //用户不存在
        else
        {
            lbMsg.Text = "<script>alert('对不起,此用户不存在')</script>";
            return;
        }

    }
}
