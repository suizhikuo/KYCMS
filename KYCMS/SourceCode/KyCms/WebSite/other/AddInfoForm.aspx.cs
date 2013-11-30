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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class other_AddInfoForm : System.Web.UI.Page
{
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    protected int CustomFormId = 0;
    protected B_CustomForm BCustomForm = new B_CustomForm();
    protected M_CustomForm MCustomForm = new M_CustomForm();
    protected B_InfoModel BInfoModel = new B_InfoModel();
    private DataTable dtIsUser;
    private B_User BUser = new B_User();
    private B_Money BMoney = new B_Money();

    protected void Page_Load(object sender, EventArgs e)
    {
        CustomFormId = int.Parse(Request.QueryString["CustomFormId"]);
        dtIsUser = BCustomFormField.GetIsUserList(CustomFormId);
        MCustomForm = BCustomForm.GetModel(CustomFormId);

        if (!Page.IsPostBack)
        {
            //验证
            GetIsOk();

            if (MCustomForm.IsValidate)
            {
                string validateCode = string.Empty;
                if (Session["ValidateCode"] == null)
                {
                    Function.ShowMsg(0, "<li>你在页面停留的时间过长，验证码已经失效</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }

                validateCode = Session["ValidateCode"].ToString();
                //验证码错误
                if (validateCode != Request.Form["txtValidate"].Trim().ToLower())
                {
                    Function.ShowMsg(0, "<li>验证码错误</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
            }

            int sUId = 0;
            string sUName = "匿名用户";

            if (BUser.IsLogin())
            {
                sUId = BUser.GetCookie().UserID;
                sUName = BUser.GetUser(BUser.GetCookie().UserID).LogName;
            }

            //只允许提交一次
            if (MCustomForm.IsSubmitNum)
            {
                //判断是否多次提交
                if (!Function.ReadTempCookies("CustomForm_" + CustomFormId, CustomFormId.ToString()))
                {
                    Function.SaveTempCookies("CustomForm_" + CustomFormId, CustomFormId.ToString());
                }
                else
                {  
                    Function.ShowMsg(0, "<li>" + MCustomForm.FormName + "设置用户只能够提交一次数据</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
            }

            //金币
            if (sUId != 0)
            {
                B_User buser = new B_User();
                M_User muser = buser.GetUser(sUId);

                if (muser.YellowBoy + MCustomForm.Money < 0)
                {
                    Function.ShowMsg(0, "<li>你剩余的金币不足，无法提交该表单</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
                else
                {
                    BMoney.YellowBoy(MCustomForm.Money, sUId);
                }
            }

            string TableName = MCustomForm.TableName;

            //定义DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
            dt.Columns.Add(new DataColumn("FieldValue", typeof(string)));

            #region 系统默认字段
            DataRow dr1 = dt.NewRow();
            dr1[0] = "UId";
            dr1[1] = sUId;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2[0] = "UName";
            dr2[1] = sUName;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3[0] = "Ip";
            dr3[1] = Request.ServerVariables["REMOTE_ADDR"];
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4[0] = "AddTime";
            dr4[1] = DateTime.Now.ToString();
            dt.Rows.Add(dr4);

            #endregion

            //以下是自动添加字段获得值
            for (int i = 0; i < dtIsUser.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = dtIsUser.Rows[i]["Name"].ToString();

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

            //添加信息
            BInfoModel.AddInfoModel(dt, TableName);

            Function.ShowMsg(1, "<li>成功提交信息</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");

            dtIsUser.Clear();
            dtIsUser.Dispose();
        }
    }

    private void GetIsOk()
    {
        //时间限制
        if (MCustomForm.IsUnlockTime)
        {
            if (DateTime.Parse(MCustomForm.StartTime.ToShortDateString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Function.ShowMsg(0, "<li>" + MCustomForm.FormName + "启用了时间限制，还不能使用" + MCustomForm.FormName + "</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }

            if (DateTime.Parse(MCustomForm.EndTime.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Function.ShowMsg(0, "<li>" + MCustomForm.FormName + "启用了时间限制，目前已经过期</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }

        //用户组权限
        if (MCustomForm.UserGroup != "|")
        {
            if (!BUser.IsLogin())
            {
                Function.ShowMsg(0, "<li>请登陆后使用" + MCustomForm.FormName + "功能</li><li><a href='" + Param.ApplicationRootPath + "/user/Login.aspx'>登陆</a> <a href='javascript:window.history.back(-1)'>返回上一步</a></li>");

            }
            else
            {
                if (MCustomForm.UserGroup.IndexOf("|" + BUser.GetUser(BUser.GetCookie().UserID).GroupID + "|") == -1)
                {
                    Function.ShowMsg(0, "<li>你所在的用户组无权使用" + MCustomForm.FormName + "功能</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
            }
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

                if (dtIsUser.Rows[i]["Type"].ToString() == "NumberType")
                {
                    if (!Function.CheckNumber(Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()]))
                    {
                        Function.ShowMsg(0, "<li>" + dtIsUser.Rows[i]["Alias"].ToString() + "只能够是数字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }
            }
        }
    }
}
