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

public partial class common_AddReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        bool reviewIsCheck = false;
        B_Review bll = new B_Review();
        B_SiteInfo SiteBll = new B_SiteInfo();
        B_User bllUser = new B_User();
        M_Review model = new M_Review();
        M_User userModel = null;
        if (Request.Form["txtIsLogin"] == "False")
        {
            if (Request.Form["btnSubmit"] == "登录")
            {
                bool flaglogin = true;
                string msgBox = string.Empty;
                if (Request.Form["UserName"].ToString().Trim() == "")
                {
                    flaglogin = false;
                    msgBox = "<script>alert('用户名必须填写');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                }
                else if (Request.Form["userPwd"].ToString().Trim() == "")
                {
                    flaglogin = false;
                    msgBox = "<script>alert('密码必须填写');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                }
                if (flaglogin)
                {


                    ltMsg.Text = "";
                    string logName = "";
                    string pwd = "";
                    string cookieType = "";


                    logName = Function.UrlDecode(Request.Form["UserName"].ToString());
                    pwd = Function.MD5Encrypt(Request.Form["userPwd"].ToString());
                    cookieType = "No";

                    if ((!string.IsNullOrEmpty(logName)) && (!string.IsNullOrEmpty(pwd)))
                    {
                        B_SiteInfo siteInfo = new B_SiteInfo();
                        M_Site siteModel = siteInfo.GetSiteModel();
                        M_User modelLogin = bllUser.GetUser(logName);
                        if (modelLogin != null && siteModel != null)
                        {

                                //用户登录
                                bool flag = bllUser.Login(logName, pwd);
                                if (flag && (!string.IsNullOrEmpty(cookieType)))
                                {
                                    HttpCookie cookie = new HttpCookie("User");
                                    cookie["uId"] = modelLogin.UserID.ToString();
                                    cookie["logN"] = modelLogin.LogName;
                                    cookie["pd"] = modelLogin.UserPwd;
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
                                    Response.Cookies.Add(cookie);

                                    string lastLoginIP = string.Empty;
                                    if (Request.UserHostAddress != null)
                                    {
                                        lastLoginIP = Request.UserHostAddress;
                                    }
                                    DateTime currLoginTime = DateTime.Now;
                                    DateTime oldLoginTime = modelLogin.LastLoginTime;
                                    bllUser.LoginSuccess(modelLogin.UserID, lastLoginIP, currLoginTime);
                                    if (oldLoginTime.Date != currLoginTime.Date)
                                    {
                                        B_Money moneyBll = new B_Money();
                                        moneyBll.Integral(siteModel.LoginScore, modelLogin.UserID);
                                    }                     

                                   
                                    msgBox = "<script>alert('登录成功');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                                }
                                else
                                {
                                    msgBox = "<script>alert('登录失败');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                                }
                        }
                        else
                        {
                            msgBox = "<script>alert('登录失败');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                        }
                    }
                }
                    ltMsg.Text = msgBox;
            }
            else
            {
                if (Request.Form["hidNoName"].ToString() == "False")
                {
                    ltMsg.Text = "<script>alert('本系统设置了不允许匿名评论，请先登录');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                }
                else
                {
                    //根据栏目的设置,对论评论审核进行初始化
                    if (Request.Form["hidColCommentSet"].ToString() == "True")
                        reviewIsCheck = false;
                    else
                        reviewIsCheck = true;

                    string validateCode = string.Empty;
                    string flag = Request.Form["hidValidate"];
                    if (flag == "True")
                    {
                        if (Session["ValidateCode"] == null)
                        {
                            Response.Write("<script language='javascript'>alert('你在登陆页面停留的时间过长，验证码已经失效');window.history.back();</script>");
                            Response.End();
                        }
                        //验证码错误
                        validateCode = Session["ValidateCode"].ToString().ToLower();
                        if (validateCode.ToLower() != Request.Form["txtValidate"].ToString().Trim().ToLower())
                        {
                            Response.Write("<script language='javascript'>alert('验证码错误');window.history.back();</script>");
                            Response.End();
                        }
                    }


                    if (bllUser.IsLogin())
                    {
                        M_User loginUserModel = bllUser.GetCookie();
                        userModel = bllUser.GetUser(loginUserModel.LogName);
                    }

                    model.ModelType = int.Parse(Request.Form["hidModeType"].ToString());
                    model.InfoId = Request.Form["hidNewsId"].ToString();

                    if (Request.Form["hidUserGroupViewIsCheck"] == "True" && bllUser.IsLogin())
                        reviewIsCheck = true;
                    model.IsCheck = reviewIsCheck;

                    model.ReviewTitle = "";                                    //评论标题

                    model.IsArgue = false;
                    model.IsSquare = 3;

                    model.BrarNum = 0;
                    model.FightNum = 0;

                    model.IsElite = false;
                    model.ReviewContent = SiteBll.GetFiltering(Request.Form["txtContent"].ToString());           //评论内容
                    model.ReviewTime = DateTime.Now;                                                       //评论时间
                    if (bllUser.IsLogin())                                             //是否是登录用户
                        model.UserNum = userModel.UserID.ToString();
                    else
                        model.UserNum = "0";
                    model.ReviewIP = Request.UserHostAddress;     //评论用户的IP

                    if (bll.Add(model))
                    {
                        if (!reviewIsCheck)
                            ltMsg.Text = "<script>alert('评论成功，将在审核后显示出来');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                        else
                            ltMsg.Text = "<script>window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                    }
                }
            }
        }
        else
        {
            if (Request.Form["hidNoName"].ToString() == "False")
            {
                ltMsg.Text = "<script>alert('本系统设置了不允许匿名评论，请先登录');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
            }
            else
            {
                //根据栏目的设置,对论评论审核进行初始化
                if (Request.Form["hidColCommentSet"].ToString() == "True")
                    reviewIsCheck = false;
                else
                    reviewIsCheck = true;

                string validateCode = string.Empty;
                string flag = Request.Form["hidValidate"];
                if (flag == "True")
                {
                    if (Session["ValidateCode"] == null)
                    {
                        Response.Write("<script language='javascript'>alert('你在登陆页面停留的时间过长，验证码已经失效');window.history.back();</script>");
                        Response.End();
                    }
                    //验证码错误
                    validateCode = Session["ValidateCode"].ToString().ToLower();
                    if (validateCode.ToLower() != Request.Form["txtValidate"].ToString().Trim().ToLower())
                    {
                        Response.Write("<script language='javascript'>alert('验证码错误');window.history.back();</script>");
                        Response.End();
                    }
                }


                if (bllUser.IsLogin())
                {
                    M_User loginUserModel = bllUser.GetCookie();
                    userModel = bllUser.GetUser(loginUserModel.LogName);
                }

                model.ModelType = int.Parse(Request.Form["hidModeType"].ToString());
                model.InfoId = Request.Form["hidNewsId"].ToString();
                if (Request.Form["hidUserGroupViewIsCheck"] == "True" && bllUser.IsLogin())
                    reviewIsCheck = true;
                model.IsCheck = reviewIsCheck;

                model.ReviewTitle = "";                                    //评论标题

                model.IsArgue = false;
                model.IsSquare = 3;

                model.BrarNum = 0;
                model.FightNum = 0;

                model.IsElite = false;
                model.ReviewContent = SiteBll.GetFiltering(Request.Form["txtContent"].ToString());           //评论内容
                model.ReviewTime = DateTime.Now;                                                       //评论时间
                if (bllUser.IsLogin())                                             //是否是登录用户
                    model.UserNum = userModel.UserID.ToString();
                else
                    model.UserNum = "0";
                model.ReviewIP = Request.UserHostAddress;     //评论用户的IP

                if (bll.Add(model))
                {
                    if (!reviewIsCheck)
                        ltMsg.Text = "<script>alert('评论成功，将在审核后显示出来');window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                    else
                        ltMsg.Text = "<script>window.location.href('" + Request.UrlReferrer.ToString() + "');</script>";
                }
            }
        }
    }
}
