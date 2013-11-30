using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ky.BLL;
using Ky.Model;
using Ky.Common;


public partial class user_DoLogin : System.Web.UI.Page
{
    B_User userBll = new B_User();
    B_Create CreateBll = new B_Create();
    protected string ReferUrl = "Main.aspx";
    B_SiteInfo siteBll = new B_SiteInfo();
    string IndexUrl = "";

    B_BBSUser bbsUserBll = new B_BBSUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        IndexUrl = CreateBll.GetIndexUrl();
        string logName = ""; 
        string pwd = ""; 
        string cookieType = ""; 
        string valideCode = "";
        if (Request.Form["txtUserName"] != null && Request.Form["txtPwd"] != null && Request.Form["rbCookie"] != null)
        {
            logName = Function.UrlDecode(Request.Form["txtUserName"].ToString());
            //pwd = Function.MD5Encrypt(Request.Form["txtPwd"].ToString());
            pwd = Request.Form["txtPwd"];
            cookieType = Request.Form["rbCookie"].ToString();
        }
        if (siteBll.GetSiteModel().IsLoginValidate)
        {
            if (Request.Form["txtValidateCode"] == null)
            {
                Function.ShowMsg(0, "<li>请输入验证码</li><li><a href='login.aspx'>重新登录</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
            }
            else
            {
                valideCode = Request.Form["txtValidateCode"].ToString().ToLower();
            }
            if (valideCode != Session["ValidateCode"].ToString())
            {
                Function.ShowMsg(0, "<li>对不起,输入的验证码错误.请重新输入</li><li><a href='login.aspx'>重新登录</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
            }
        }
        
        if ((!string.IsNullOrEmpty(logName)) && (!string.IsNullOrEmpty(pwd)))
        {
            B_SiteInfo siteInfo = new B_SiteInfo();
            M_Site siteModel = siteInfo.GetSiteModel();
            M_User model = userBll.GetUser(logName);
            if (model != null && siteModel != null)
            {
                //用户被锁定
                if (model.IsLock == true)
                {
                    Function.ShowMsg(0, "<li>对不起,您已经被锁定,不能登录.</li><li>如果您是新注册用户,您可能需要先激活帐号</li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                }
                if (model.Status == 0)
                {
                    Function.ShowMsg(0, "<li>对不起,您还未通过管理员认证,不能登录.</li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                }
                //用户还在禁止登录时间内
                if (model.ErrorTime > DateTime.Now)
                {
                    Function.ShowMsg(0, "<li>对不起,您已经登录错误 " + siteModel.LogErrorNum + " 次,将被禁止登录 " + siteModel.DisabledLoginTime + " 分钟.</li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                }
                else
                {
                    //用户登录
                    bool flag = userBll.Login(logName, pwd);
                    if (flag && (!string.IsNullOrEmpty(cookieType)))
                    {
                        HttpCookie cookie = new HttpCookie("User");                        
                        cookie["uId"] = model.UserID.ToString();
                        cookie["logN"] = Function.UrlEncode(model.LogName);
                        cookie["pd"] = model.UserPwd;
                        switch (cookieType)
                        {
                            case "onehour":
                                cookie.Expires = DateTime.Now.AddHours(1);
                                break;
                            case "oneday":
                                cookie.Expires = DateTime.Now.AddDays(1);
                                break;
                            case "oneweek":
                                cookie.Expires = DateTime.Now.AddDays(7);
                                break;
                            case "onemounth":
                                cookie.Expires = DateTime.Now.AddMonths(1);
                                break;
                            case "oneyear":
                                cookie.Expires = DateTime.Now.AddYears(1);
                                break;
                            case "No":
                            default:
                                break;
                        }
                        cookie.Domain = WebConfigurationManager.AppSettings["KYCMS_CookieDomain"];
                        Response.Cookies.Add(cookie);
                        string bbsCookieValue = bbsUserBll.GetUserCookie(Request.Form["txtUserName"],Request.Form["txtPwd"]);
                        bbsUserBll.WriteUserCookie(bbsCookieValue);
                        lbUserName.Text = logName;
                        if (Request.UrlReferrer != null)
                        {
                            ReferUrl = Request.UrlReferrer.ToString();
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                        {
                            ReferUrl = Request.QueryString["ReturnUrl"].ToString();
                        }


                        //设置自动转向
                        HtmlMeta meta = new HtmlMeta();
                        meta.HttpEquiv = "Refresh";
                        meta.Content = "3;url=" + Server.UrlDecode(ReferUrl);
                        Header.Controls.Add(meta);
                        hyMain.NavigateUrl = "Main.aspx";
                        hyRefer.NavigateUrl = ReferUrl;
                        hyRefer.Text = ReferUrl;
                        hyIndex.NavigateUrl = IndexUrl;

                        //更新登录信息
                        string lastLoginIP = string.Empty;
                        if(Request.UserHostAddress!=null)
                        {
                            lastLoginIP = Request.UserHostAddress;
                        }
                        DateTime currLoginTime = DateTime.Now;
                        DateTime oldLoginTime = model.LastLoginTime;
                        userBll.LoginSuccess(model.UserID, lastLoginIP, currLoginTime);
                        if (oldLoginTime.Date != currLoginTime.Date)
                        {
                            B_Money moneyBll = new B_Money();
                            moneyBll.Integral(siteModel.LoginScore, model.UserID);
                        }                        
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
                            Function.ShowMsg(0, "<li>对不起,您已经登录错误 " + siteModel.LogErrorNum + " 次,将被禁止登录 " + siteModel.DisabledLoginTime + " 分钟.</li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                        }
                        // 修改次数
                        else
                        {
                            userBll.LoginFailError(model.UserID);
                            Function.ShowMsg(0, "<li>对不起,登录失败!请检查您的用户名和密码.</li><li><a href='Login.aspx'>重新登录</a>(您还有" + (siteModel.LogErrorNum - model.ErrorNum) + "次机会)</li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                        }
                    }
                }
            }

            //用户不存在
            else
            {
                Function.ShowMsg(0,"<li>对不起,此用户不存在</li><li><a href='Reg.aspx'>注册新用户</a></li><li><a href='Login.aspx'>重新登录</a></li>");
            }
        }

        //post过来的数据不合法
        else
        {            
            Response.Redirect("Login.aspx");
        }
    }

}
