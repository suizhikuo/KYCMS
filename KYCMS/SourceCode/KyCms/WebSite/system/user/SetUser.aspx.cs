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
using System.Text.RegularExpressions;
using System.IO;
using Ky.BLL.CommonModel;
using System.Text;

public partial class System_user_SetUser : System.Web.UI.Page
{
    private B_User userbll = new B_User();
    private B_UserGroup usergroupbll = new B_UserGroup();
    private M_User model = new M_User();
    B_Dictionary dictionary = new B_Dictionary();
    int userId = 0;
    B_PowerGroup power = new B_PowerGroup();
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    protected int TypeId = 0;
    B_KyCommon kycomm = new B_KyCommon();
    private DataTable dtIsUser;
    private B_UserGroupModelField BUserGroupModelField = new B_UserGroupModelField();
    private M_UserGroupModelField MUserGroupModelField = new M_UserGroupModelField();
    protected B_InfoModel BInfoModel = new B_InfoModel();
    protected B_InfoOper BInfoOper = new B_InfoOper();
    protected B_ModelField BModelField = new B_ModelField();

    B_BBSUser bbsUserBll = new B_BBSUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        B_Admin admin = new B_Admin();
        admin.CheckMulitLogin();
        AjaxPro.Utility.RegisterTypeForAjax(typeof(System_user_SetUser));

        if (!string.IsNullOrEmpty(Request.QueryString["TypeId"]))
        {
            try
            {
                TypeId = int.Parse(Request.QueryString["TypeId"]);
            }
            catch { }
        }

        if (!IsPostBack)
        {
            BindddlistGroup();
        }
        //用户模型数据
        MUserGroupModel = BUserGroupModel.GetModel(TypeId);
        ModelHtml.Text = MUserGroupModel.ModelHtml;

        RepUserGroupModel.DataSource = BUserGroupModel.GetAll();
        RepUserGroupModel.DataBind();

        ModelName.Text = MUserGroupModel.Name;

        dtIsUser = BUserGroupModelField.GetIsUserList(TypeId);

        if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != "")
        {
            userId = Function.CheckNumber(Request.QueryString["uid"]) ? int.Parse(Request.QueryString["uid"]) : 0;
            if (!IsPostBack)
            {
                ShowUser();
            }
        }

        //管理员新增用户
        //自动选择用户组为注册会员组
        if (userId == 0)
        {
        }
        //修改用户
        else
        {
            DivCnfmPwd.Visible = false;
            txtLogName.Enabled = false;
            lbDot.Visible = false;
        }
    }

    private void BindddlistGroup()
    {
        ddlistGroup.DataSource = usergroupbll.ManageList(" where TypeId=" + TypeId + "");
        ddlistGroup.DataTextField = "UserGroupName";
        ddlistGroup.DataValueField = "UserGroupId";
        ddlistGroup.DataBind();
    }

    /// <summary>
    /// 在修改用户信息时绑定数据
    /// </summary>
    void ShowUser()
    {
        M_User updateModel = userbll.GetUser(userId);
        if (updateModel != null)
        {
            txtLogName.Text = updateModel.LogName;
            txtEmail.Text = updateModel.Email;
            txtQuestion.Text = updateModel.Question;
            for (int i = 0; i < ddlistGroup.Items.Count; i++)
            {
                if (updateModel.GroupID.ToString() == ddlistGroup.Items[i].Value)
                {
                    ddlistGroup.SelectedIndex = i;
                    break;
                }
            }
            btnOk.Text = " 修 改 ";
        }
        else
        {
            Function.ShowSysMsg(0, "<li>没有符合要求的数据</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        CheckInput();

        //修改用户信息
        if (userId != 0)
        {
            //判断权限
            power.Power_Judge(18);

            if (txtPwd.Text != "")
            {
                userbll.ModifyPwd(userId, Function.MD5Encrypt(txtPwd.Text));

                string logName = userbll.GetUser(userId).LogName;
                bbsUserBll.UpdatePwd(logName, txtPwd.Text);
            }

            if (txtAnswer.Text != "")
            {
                userbll.ModifyQuestion(userId, txtQuestion.Text, Function.MD5Encrypt(txtAnswer.Text));
            }

            userbll.ModifyOtherBasicInfo(userId, txtEmail.Text, int.Parse(ddlistGroup.SelectedItem.Value), int.Parse(txtSecret.SelectedValue));
        }
        else
        {
            model.LogName = txtLogName.Text;
            model.Email = txtEmail.Text;
            model.TypeId = TypeId;
            model.GroupID = int.Parse(ddlistGroup.SelectedItem.Value);
            model.Secret = int.Parse(txtSecret.SelectedValue);
            model.Question = txtQuestion.Text;
            model.Answer = Function.MD5Encrypt(txtAnswer.Text);
            model.UserPwd = Function.MD5Encrypt(txtPwd.Text);
            model.RegTime = DateTime.Now;
            model.ConfirmRegCode = Guid.NewGuid().ToString();
            B_UserGroup userGroupBll = new B_UserGroup();
            M_UserGroup userGroupModel = userGroupBll.GetModel(int.Parse(ddlistGroup.SelectedValue));
            string userStatus = userGroupBll.Power_UserGroup("Status", 0, userGroupModel.GroupPower);
            model.Status = int.Parse(userStatus);
            //判断权限        
            power.Power_Judge(16);

            userId = userbll.Reg(model);
        }


        //自定义字段
        //定义DataTable
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
        dt.Columns.Add(new DataColumn("FieldValue", typeof(string)));

        #region 系统默认字段
        if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != "")
        {
            DataRow dr0 = dt.NewRow();
            dr0[0] = "Id";
            dr0[1] = BInfoOper.GetUserInfo(MUserGroupModel.TableName, userId)["Id"];
            dt.Rows.Add(dr0);
        }

        DataRow dr1 = dt.NewRow();
        dr1[0] = "UId";
        dr1[1] = userId;
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

        if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != "")
        {
            //修改信息
            BInfoModel.UpdateInfoModel(dt, MUserGroupModel.TableName);

            Function.ShowSysMsg(1, "<li>修改成功</li><li><a href='user/UserList.aspx?TypeId=" + TypeId + "'>返回" + MUserGroupModel.Name + "列表</a></li>");
        }
        else
        {
            //添加
            BInfoModel.AddInfoModel(dt, MUserGroupModel.TableName);
            string bbsCookieStr = string.Empty;
            bbsCookieStr = bbsUserBll.BBS_User_Reg(model.LogName, txtCnfmPwd.Text, model.Email, true);

            Function.ShowSysMsg(1, "<li>添加成功</li><li><a href='user/UserList.aspx?TypeId=" + TypeId + "'>返回" + MUserGroupModel.Name + "列表</a></li>");
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
        if (ddlistGroup.Items.Count == 0)
        {
            Function.ShowMsg(0, "<li>对不起，该会员类型还未指定用户组，无法添加用户</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        bool flag = kycomm.CheckHas(txtLogName.Text, "LogName", "KyUsers");
        bool chkEmail = kycomm.CheckHas(txtEmail.Text, "Email", "KyUsers");
        if (Encoding.Default.GetBytes(txtLogName.Text.Trim()).Length < 4 || Encoding.Default.GetBytes(txtLogName.Text.Trim()).Length > 20)
        {
            Function.ShowSysMsg(0, "<li>对不起，用户名长度应该介于 4-20 位</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }

        if (userId == 0)
        {
            if (flag)
            {
                Function.ShowSysMsg(0, "<li>对不起，您输入的用户名已存在</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            flag = bbsUserBll.BBS_User_CheckIsExists(txtLogName.Text);
            if (flag)
            {
                Function.ShowMsg(0, "<li>对不起，您输入的用户名已存在</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }
        if (userId == 0)
        {
            if (txtPwd.Text.Trim().Length < 6 || txtPwd.Text.Trim().Length > 20)
            {
                Function.ShowSysMsg(0, "<li>对不起，密码长度应该介于 6-20 位</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            if (txtCnfmPwd.Text.Trim() != txtPwd.Text.Trim())
            {
                Function.ShowSysMsg(0, "<li>对不起，您两次输入的密码不一致</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            if (txtAnswer.Text == "")
            {
                Function.ShowSysMsg(0, "<li>对不起，密码提示答案不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }
        if (txtQuestion.Text == "")
        {
            Function.ShowSysMsg(0, "<li>对不起，密码提示问题不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtEmail.Text.Trim() == "" || r.IsMatch(txtEmail.Text.Trim()) == false)
        {
            Function.ShowSysMsg(0, "<li>对不起，您输入的Email无效</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }

        if (userId == 0)
        {
            if (chkEmail)
            {
                Function.ShowSysMsg(0, "<li>对不起，您输入的Email已存在</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
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
                        Function.ShowSysMsg(0, "<li>" + dtIsUser.Rows[i]["Alias"].ToString() + "不能够为空</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }

                if (dtIsUser.Rows[i]["Type"].ToString() == "NumberType")
                {
                    if (Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()] != "")
                    {
                        if (!Function.CheckNumber(Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()]))
                        {
                            Function.ShowSysMsg(0, "<li>" + dtIsUser.Rows[i]["Alias"].ToString() + "只能够是数字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                        }
                    }
                }
            }
        }
    }

    [AjaxPro.AjaxMethod]
    public DataSet GetModelHtmlValue(string TypeId, string UserId)
    {
        MUserGroupModel = BUserGroupModel.GetModel(int.Parse(TypeId));
        DataTable dt = new DataTable();
        DataRow dr = BInfoOper.GetUserInfo(MUserGroupModel.TableName, int.Parse(UserId));
        dt = dr.Table.Copy();
        dt.Clear();
        dt.ImportRow(dr);
        dt.TableName = "DrInfo";

        DataSet ds = new DataSet();
        try
        {
            ds.Tables.Add(BUserGroupModelField.GetList(int.Parse(TypeId)).Copy());
            ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

        return ds;
    }
}
