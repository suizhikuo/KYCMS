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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class sys_template_Login : System.Web.UI.Page
{
    protected B_User UserBll = new B_User();
    protected M_User UserModel = null;
    protected bool IsLogin = false;
    protected string ApplicationPath = Param.ApplicationRootPath;
    protected string LabelUserName = "";
    protected bool isValidate = false;
    protected bool LoginModel = true;
    B_SiteInfo siteInfo = new B_SiteInfo();
    B_User userBll = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["loginModel"] != null && Request.QueryString["loginModel"].Length != 0)
        {
            if (Request.QueryString["loginModel"].ToString() == "vertical")
                LoginModel = true;
            if (Request.QueryString["loginModel"].ToString() == "horizontal")
                LoginModel = false;
        }
        Response.Cache.SetNoStore();
        IsLogin = UserBll.IsLogin();
        M_Site siteModel = siteInfo.GetSiteModel();
        isValidate = siteModel.IsLoginValidate;
        if (IsLogin)
        {
            M_User loginUserModel = UserBll.GetCookie();
            UserModel = UserBll.GetUser(loginUserModel.LogName);
            LabelUserName = UserModel.LogName;
        }

        AjaxPro.Utility.RegisterTypeForAjax(typeof(sys_template_Login));

    }

    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
    public string AjaxCheckLogin(string UserName, string PassWord, string CookieType, string validate)
    {
        string MyAjaxCheckLogin="";
        //string MyPassWord = Function.MD5Encrypt(PassWord);
        M_Site siteModel = siteInfo.GetSiteModel();
        M_User model = userBll.GetUser(UserName);

        if (siteModel.IsLoginValidate)
        {
            string validateCode = string.Empty;
            if (Session["ValidateCode"] == null)
            {
                MyAjaxCheckLogin = "你在登陆页面停留的时间过长，验证码已失效";
                return MyAjaxCheckLogin;
            }
            validateCode = Session["ValidateCode"].ToString();
            //验证码错误
            if (validateCode.ToLower() != validate.ToLower())
            {
                MyAjaxCheckLogin = "验证码错误";
                return MyAjaxCheckLogin;
            }        
        }
        if (model != null && siteModel != null)
        {
            //用户被锁定
            if (model.IsLock == true)
            {
                MyAjaxCheckLogin = "对不起,您已经被系统锁定,不能登录.请联系您的系统管理员.(如果您是新注册用户,那么您需要先激活帐号)";
                return MyAjaxCheckLogin;
            }

            //用户还在禁止登录时间内
            if (model.ErrorTime > DateTime.Now)
            {
                MyAjaxCheckLogin = "对不起,您已经登录错误 " + siteModel.LogErrorNum + " 次,将被系统禁止登录 " + siteModel.DisabledLoginTime + " 分钟.";
                return MyAjaxCheckLogin;
            }
            else
            {
                //用户登录
                bool flag = userBll.Login(UserName, PassWord);
                if (flag)
                {
                    #region
                    System.Web.HttpCookie cookie = new System.Web.HttpCookie("User");
                    cookie["uId"] = model.UserID.ToString();
                    cookie["logN"] = model.LogName;
                    cookie["pd"] = model.UserPwd;
                    //cookie.Expires = DateTime.Now.AddDays(1);
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                  
                    //更新登录信息
                    string lastLoginIp = string.Empty;
                    if(System.Web.HttpContext.Current.Request.UserHostAddress!=null)
                    {
                         lastLoginIp = System.Web.HttpContext.Current.Request.UserHostAddress;
                    }
                    model.LastLoginIP = System.Web.HttpContext.Current.Request.UserHostAddress;
                    DateTime oldLoginTime = model.LastLoginTime;
                    DateTime currLoginTime = DateTime.Now;

                    userBll.LoginSuccess(model.UserID, lastLoginIp, currLoginTime);
                    if (oldLoginTime.Date != currLoginTime.Date)
                    {
                        B_Money moneyBll = new B_Money();
                        moneyBll.Integral(siteModel.LoginScore, model.UserID);
                    }               
                    return "True";
                    #endregion
                }
                else
                {
                    if (model.ErrorNum >= siteModel.LogErrorNum)
                    {
                        DateTime errorTime = DateTime.Now.AddMinutes(siteModel.DisabledLoginTime);
                        userBll.LoginFailOnErrorNum(model.UserID, errorTime);
                    }
                    else
                    {
                        userBll.LoginFailError(model.UserID);
                    }
                    MyAjaxCheckLogin = "对不起,登录失败!请检查您的用户名和密码";
                }
            }
        }
        else
        {
            MyAjaxCheckLogin = "对不起,此用户不存在!";
        }

        return MyAjaxCheckLogin;
    }

    [AjaxPro.AjaxMethod]
    public string AjaxLouOut(string Str)
    {
        System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["User"];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Parse("1900-01-01");
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        return "True";
    }
}
