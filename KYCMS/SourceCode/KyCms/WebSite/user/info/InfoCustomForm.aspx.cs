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

public partial class user_info_InfoCustomForm : System.Web.UI.Page
{
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    protected int CustomFormId = 0;
    protected B_CustomForm BCustomForm = new B_CustomForm();
    protected M_CustomForm MCustomForm = new M_CustomForm();
    protected B_InfoModel BInfoModel = new B_InfoModel();
    private B_InfoOper BInfoOper = new B_InfoOper();
    private DataTable dtInfo;
    private B_User BUser = new B_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["CustomFormId"]))
        {
            try
            {
                CustomFormId = int.Parse(Request.QueryString["CustomFormId"]);
            }
            catch { }
        }

        MCustomForm = BCustomForm.GetModel(CustomFormId);
        dtInfo = BCustomFormField.GetIsUserList(CustomFormId);

        if (!Page.IsPostBack)
        {
            //权限验证
            GetPowerValidate();

            CustomFormName.Text = MCustomForm.FormName;

            //绑定自定义字段
            Repeater1.DataSource = dtInfo;
            Repeater1.DataBind();

            dtInfo.Clear();
            dtInfo.Dispose();

            FilePicPath.Text = MCustomForm.UploadPath + "|" + MCustomForm.UploadSize.ToString();

            if (MCustomForm.IsValidate)
            {
                FormTr1.Visible = true;
            }
        }
    }

    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description, null);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //验证
        GetIsOk();

        MCustomForm = BCustomForm.GetModel(CustomFormId);
        string TableName = MCustomForm.TableName;

        int sUId = 0;
        string sUName = "匿名用户";

        if (BUser.IsLogin())
        {
            sUId = BUser.GetCookie().UserID;
            sUName = BUser.GetUser(BUser.GetCookie().UserID).LogName;
        }

        if (MCustomForm.UserGroup != "|")
        {
            //只允许提交一次
            if (MCustomForm.IsSubmitNum)
            {
                DataTable dt1 = new DataTable();
                dt1 = BCustomForm.GetFormSubmitNum(MCustomForm.TableName, sUId);
                if (dt1.Rows.Count > 0)
                {
                    Function.ShowMsg(0, "<li>" + MCustomForm.FormName + "设置用户只能够提交一次数据</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
                dt1.Clear();
                dt1.Dispose();
            }
        }


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
        for (int i = 0; i < dtInfo.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = dtInfo.Rows[i]["Name"].ToString();

            switch (dtInfo.Rows[i]["Type"].ToString())
            {
                case "ListBoxType":
                    if (Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""] == "" || Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""] == null)
                    {
                        dr[1] = Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""];
                    }
                    else
                    {
                        dr[1] = Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""].Replace(" ", "").ToString();
                    }
                    break;
                case "MultipleTextType":
                    dr[1] = Function.Encode(Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""]);
                    break;
                default:
                    dr[1] = Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""];
                    break;
            }
            dt.Rows.Add(dr);
        }

        //添加信息
        BInfoModel.AddInfoModel(dt, TableName);
        dtInfo.Clear();
        dtInfo.Dispose();
        Function.ShowMsg(1, "<li>成功添加！</li><li><a href='info/InfoCustomForm.aspx?CustomFormId=" + CustomFormId + "'>返回发布页面</a></li>");


    }

    private void GetIsOk()
    {
        if (MCustomForm.IsValidate)
        {
            string validateCode = string.Empty;
            if (Session["ValidateCode"] == null)
            {
                Function.ShowMsg(0, "<li>你在页面停留的时间过长，验证码已经失效</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }

            validateCode = Session["ValidateCode"].ToString();
            //验证码错误
            if (validateCode != Request.Form["txtValidate"].Trim())
            {
                Function.ShowMsg(0, "<li>验证码错误</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }

        //验证自定义字段
        if (dtInfo.Rows.Count > 0)
        {
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (dtInfo.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString()] == "" || Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString()] == null)
                    {
                        Function.ShowMsg(0, "<li>" + dtInfo.Rows[i]["Alias"].ToString() + "不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }
            }
        }
    }

    private void GetPowerValidate()
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
    }
}
