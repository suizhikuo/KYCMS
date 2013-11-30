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
using Ky.Model;
using Ky.BLL;
using System.Text.RegularExpressions;
using Ky.Common;
using System.Text;
using System.IO;
using Ky.BLL.CommonModel;

public partial class user_Reg : System.Web.UI.Page
{
    B_User Bll = new B_User();
    B_KyCommon kycomm = new B_KyCommon();
    B_SiteInfo site = new B_SiteInfo();
    M_Site siteModel;
    B_Create getIndexBll = new B_Create();
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    string IndexUrl = "main.aspx";
    protected int TypeId = 0;
    private DataTable dtIsUser;
    private B_UserGroupModelField BUserGroupModelField = new B_UserGroupModelField();
    private M_UserGroupModelField MUserGroupModelField = new M_UserGroupModelField();
    protected B_InfoModel BInfoModel = new B_InfoModel();

    B_BBSUser bbsUserBll = new B_BBSUser();
    string returnUrl = string.Empty;
    public string returnUrl1 = string.Empty;
    public string returnUrl2 = string.Empty;
    protected B_ModelField BModelField = new B_ModelField();

    protected void Page_Load(object sender, EventArgs e)
    {
        siteModel = site.GetSiteModel();
        IndexUrl = getIndexBll.GetIndexUrl();
        hylnkIndex.NavigateUrl = IndexUrl;
        if (siteModel != null && siteModel.IsAllowRegsite == false)
        {
            Function.ShowMsg(0,"<li>对不起,本站暂时关闭了新用户注册.</li><li><a href='"+IndexUrl+"'>返回首页</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(user_Reg));
        if (!string.IsNullOrEmpty(Request.QueryString["returnurl"]))
        {
            returnUrl = Request.QueryString["returnurl"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["TypeId"]))
        {
            OnNull.Visible = false;
            try
            {
                TypeId = int.Parse(Request.QueryString["TypeId"]);
            }
            catch { }
        }
        else
        {
            if (returnUrl != string.Empty)
            {
                returnUrl1 = "&returnurl=" + Function.Encode(returnUrl);
            }
            rptGroup.DataSource = BUserGroupModel.GetAll();
            rptGroup.DataBind();
            OnCommon.Visible = false;
        }
       
        dtIsUser = BUserGroupModelField.GetIsUserList(TypeId);
        MUserGroupModel = BUserGroupModel.GetModel(TypeId);

        if (!Page.IsPostBack)
        {
            if (MUserGroupModel != null)
            {
                ModelHtml.Text = MUserGroupModel.ModelHtml;

                //判断该用户组模型是否设置了用户组
                if (MUserGroupModel.UserGroupId == 0)
                {
                    Function.ShowMsg(0, "<li>对不起，该会员类型还未指定用户组，目前无法注册</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                }

                if (MUserGroupModel.IsValidate)
                {
                    Code.Visible = true;
                }
                else
                {
                    Code.Visible = false;
                }
            }
        }
    }
    
    /// <summary>
    /// 用户注册
    /// </summary>
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
      
       
        if (IsValid && siteModel != null)
        {
            //验证
            CheckInput();

            M_User model = new M_User();
            model.LogName = txtUsername.Text;
            model.Email = txtEmail.Text;
            model.UserPwd = Function.MD5Encrypt(txtCnfmPwd.Text);
            model.Question = txtQuestion.Text;
            model.Answer = Function.MD5Encrypt(txtAnswer.Text);
            model.RegTime = DateTime.Now;
            model.Secret = 1;//部分公开
            model.ErrorTime = DateTime.Parse("2000/01/01");
            model.ErrorNum = 0;
            model.GroupID = MUserGroupModel.UserGroupId;
            model.TypeId = TypeId;

            if (siteModel.IsTestEmail == true)
            {
                model.IsLock = true;
            }
            else
            {
                model.IsLock = false;
            }

            B_UserGroup userGroupBll = new B_UserGroup();
            M_UserGroup userGroupModel = userGroupBll.GetModel(MUserGroupModel.UserGroupId);
            string userStatus = userGroupBll.Power_UserGroup("Status", 0, userGroupModel.GroupPower);
            model.Status = int.Parse(userStatus);

            string confirmCode = Guid.NewGuid().ToString();
            model.ConfirmRegCode = confirmCode;
            model.Integral = siteModel.LoginScore;
            model.LastLoginTime = DateTime.Now;
            int uid = Bll.Reg(model);

            

            //自定义字段
            //定义DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
            dt.Columns.Add(new DataColumn("FieldValue", typeof(string)));

            #region 系统默认字段
            DataRow dr1 = dt.NewRow();
            dr1[0] = "UId";
            dr1[1] = uid;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2[0] = "AddTime";
            dr2[1] = DateTime.Now.ToString();
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3[0] = "UpdateTime";
            dr3[1] = DateTime.Now.ToString();
            dt.Rows.Add(dr3);
            #endregion

            //以下是自动添加字段获得值
            for (int i = 0; i < dtIsUser.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = dtIsUser.Rows[i]["Name"].ToString();

                //联动获取数据开始
                //二级联动
                if (dtIsUser.Rows[i]["Type"].ToString() == "ErLinkageType")
                {
                    dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()];
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = dtIsUser.Rows[i]["Name"].ToString() + "_Id";
                    dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + "_Id"];
                    dt.Rows.Add(dr);

                    string SmallName = BModelField.GetFieldContent(dtIsUser.Rows[i]["Content"].ToString(), 2, 1);
                    dr = dt.NewRow();
                    dr[0] = SmallName;
                    dr[1] = Request.Form["txt_" + SmallName];
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = SmallName + "_Id";
                    dr[1] = Request.Form["txt_" + SmallName + "_Id"];
                    dt.Rows.Add(dr);
                }
                else
                {
                    switch (dtIsUser.Rows[i]["Type"].ToString())
                    {
                        case "ListBoxType":
                            if (Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""] == "" || Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""] == null)
                            {
                                dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""];
                            }
                            else
                            {
                                dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""].Replace(" ", "").ToString();
                            }
                            break;
                        case "MultipleTextType":
                            dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""];
                            break;
                        default:
                            dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""];
                            break;
                    }
                    dt.Rows.Add(dr);
                }
            }

            //添加信息
            BInfoModel.AddInfoModel(dt, MUserGroupModel.TableName);

            string bbsCookieStr = string.Empty;
            bbsCookieStr = bbsUserBll.BBS_User_Reg(model.LogName, txtCnfmPwd.Text, model.Email, true);
          
            if (uid > 0)
            {
                //如果是被已注册用户推荐过来的.那么验证推荐用户是否存在
                //如果存在
                //则给推荐者加上系统设置的推广积分
                if (siteModel.IsOpenInvite && Request.QueryString["recmd_uid"] != null && Function.CheckNumberNotZero(Request.QueryString["recmd_uid"]))
                {
                    int recmd_uid = int.Parse(Request.QueryString["recmd_uid"].ToString());
                    Bll.AddCmdUserIntegral(recmd_uid);
                }
                if (siteModel.IsTestEmail == true)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(txtUsername.Text + "，您好！");
                    sb.AppendLine("感谢您注册为 " + siteModel.SiteName + " 的用户。");
                    sb.AppendLine("您只需点击下面的链接即可激活您的帐号：");
                    sb.Append("<a href='");
                    string url = "";
                    if (siteModel.Domain.EndsWith("/"))
                    {
                        url = siteModel.Domain + "user/activate.aspx?uid=" + uid + "&code=" + confirmCode;
                    }
                    else
                    {
                        url = siteModel.Domain + "/user/activate.aspx?uid=" + uid + "&code=" + confirmCode;
                    }
                    sb.Append(url);
                    sb.Append("'>");
                    sb.Append(url);
                    sb.Append("</a><br />");
                    sb.AppendLine("(如果您无法点击上面的链接，请将链接地址手工粘贴到浏览器地址栏后访问！)<br />");
                    sb.AppendLine("祝您健康愉快！<br />");
                    sb.AppendLine(siteModel.SiteName);
                    sb.AppendLine(DateTime.Now.ToShortDateString());
                    sb.AppendLine("<hr />");
                    sb.AppendLine("此邮件为系统自动发送，请勿回复。");
                    string body = sb.ToString();
                    try
                    {
                        B_SendMail mail = new B_SendMail(siteModel.EmailServerUserName.Trim(), txtEmail.Text, txtUsername.Text + "，您好！请激活您的账户。", body, true, System.Text.Encoding.UTF8);
                        mail.Send();
                        Function.ShowMsg(1, "<li>"+txtUsername.Text+"，恭喜，注册成功！一封包含您帐号激活信息的邮件已发送到您的邮箱，请按邮件内的提示激活您的帐号</li><li><a href='main.aspx'>登录用户中心</a></li><li><a href='"+IndexUrl+"'>返回网站首页</a></li>");
                    }
                    catch
                    {
                        Function.ShowMsg(1, "<li>" + txtUsername.Text + "，恭喜，注册成功！点击下面的链接立即激活您的帐号</li><li><a href='"+url+"'>激活帐号</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                    }
                }
                else
                {
                    if (model.Status == 1)
                    {
                        HttpCookie cookie = new HttpCookie("User");
                        cookie["uId"] = uid.ToString();
                        cookie["logN"] = Function.UrlEncode(txtUsername.Text);
                        cookie["pd"] = Function.MD5Encrypt(txtCnfmPwd.Text);
                        Response.Cookies.Add(cookie);
                        if (bbsCookieStr.Length != 0)
                        {
                            bbsUserBll.WriteUserCookie(bbsCookieStr);
                        }
                        if (returnUrl != string.Empty)
                        {
                            returnUrl2 = "<li><a href='" + returnUrl + "'>返回来源页面</a></li>";
                        }
                        Function.ShowMsg(1, "<li>" + txtUsername.Text + "，恭喜，注册成功！请选择您需要的操作</li>" + returnUrl2 + "<li><a href='main.aspx'>登录用户中心</a></li><li><a href='" + IndexUrl + "'>返回网站首页</a></li>");
                    }
                    else
                    {
                        Function.ShowMsg(1, "<li>" + txtUsername.Text + "，恭喜，注册成功！</li><li><a href='main.aspx'>登录用户中心</a></li>");
                    }


                }
            }
            else
            {
                Function.ShowMsg(0, "<li>对不起，注册失败！请稍后再试</li><li><a href='"+IndexUrl+"'>返回网站首页</a></li>");
            }
        }
    }
    

    /// <summary>
    /// 检查用户输入
    /// </summary>
    public void CheckInput()
    {
        string patt = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        string namePatt = "^[0-9a-zA-Z_]{6,20}$";
        Regex r = new Regex(patt, RegexOptions.IgnoreCase);
        Regex name = new Regex(namePatt, RegexOptions.IgnoreCase);

        bool flag = kycomm.CheckHas(txtUsername.Text, "LogName", "KyUsers");
        bool chkEmail = kycomm.CheckHas(txtEmail.Text, "Email", "KyUsers");
        if (MUserGroupModel.IsValidate)
        {
            if (txtCode.Text.Trim() == "" || txtCode.Text.ToLower() != Session["ValidateCode"].ToString())
            {
                Session["ValidateCode"] = null;
                txtCode.Text = "";
                Function.ShowMsg(0, "<li>对不起，验证码错误。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }
        if (!chkAgrement.Checked)
        {
            Function.ShowMsg(0, "<li>对不起，您必须同意了注册协议才能注册</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if(Encoding.Default.GetBytes(txtUsername.Text.Trim()).Length<4||Encoding.Default.GetBytes(txtUsername.Text.Trim()).Length>20)
        {
            Function.ShowMsg(0, "<li>对不起，用户名长度应该介于 4-20 个字节</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtPwd.Text.Trim().Length < 6 || txtPwd.Text.Trim().Length > 20)
        {
            Function.ShowMsg(0, "<li>对不起，密码长度应该介于 6-20 位</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtCnfmPwd.Text.Trim() != txtPwd.Text.Trim())
        {
            Function.ShowMsg(0, "<li>对不起，您两次输入的密码不一致</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtQuestion.Text == "")
        {
            Function.ShowMsg(0, "<li>对不起，密码提示问题不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if(txtAnswer.Text=="")
        {
            Function.ShowMsg(0, "<li>对不起，密码提示答案不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtEmail.Text.Trim() == "" || r.IsMatch(txtEmail.Text.Trim()) == false)
        {
            Function.ShowMsg(0, "<li>对不起，您输入的Email无效</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (flag)
        {
            Function.ShowMsg(0, "<li>对不起，您输入的用户名已存在</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (chkEmail)
        {
            Function.ShowMsg(0, "<li>对不起，您输入的Email已存在</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        flag = bbsUserBll.BBS_User_CheckIsExists(txtUsername.Text);
        if (flag)
        {
            Function.ShowMsg(0, "<li>对不起，您输入的用户名已存在</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }

        //验证自定义字段
        if (dtIsUser.Rows.Count > 0)
        {
            for (int i = 0; i < dtIsUser.Rows.Count; i++)
            {
                if (dtIsUser.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()] == "" || Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()] == null)
                    {
                        Function.ShowMsg(0, "<li>" + dtIsUser.Rows[i]["Alias"].ToString() + "不能够为空</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }

                if (dtIsUser.Rows[i]["Type"].ToString() == "NumberType" && dtIsUser.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (!Function.CheckNumber(Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()]))
                    {
                        Function.ShowMsg(0, "<li>" + dtIsUser.Rows[i]["Alias"].ToString() + "只能够是数字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }
            }
        }
    }

    [AjaxPro.AjaxMethod]
    public string CheckUserName(string UserName)
    {
        if (kycomm.CheckHas(UserName, "LogName", "KyUsers"))
        {
            return " 对不起，该用户名已经存在，请另外输入";
        }
        else
        {
            return "恭喜您，该用户名可以注册";
        }
    }
}
