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

public partial class System_AddAdmin : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    B_Group GroupBll = new B_Group();
    private M_Admin AdminModel = new M_Admin();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    public int GroupID = 0;
    public int UserId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(14);
        if (Request.QueryString["UserId"] != null)
        {
            UserId = Function.CheckNumber(Request.QueryString["UserId"]) ? int.Parse(Request.QueryString["UserId"]) : 0;
            if (!IsPostBack)
            { BindOnUpdate(); }
        }
        if (!Page.IsPostBack)
        {
            BindAdminGroup();
        }
    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
        CheckInput();
        AdminModel.GroupName = DDlistGroup.SelectedItem.Text;
        AdminModel.GroupId = int.Parse(DDlistGroup.SelectedValue);
        AdminModel.LoginName = txtAdminLoginID.Text;
        AdminModel.UserName = txtAdminName.Text;
        AdminModel.AllowMultiLogin = bool.Parse(AllowMultiLogin.SelectedValue);

        if(AdminModel.UserName.Trim().Length==0)
            Function.ShowSysMsg(0, "<li>管理员名称不能为空</li>");
        if (txtAdminPWD.Text.Trim().Length<6||txtAdminPWD.Text.Trim().Length>18)
        {
            Function.ShowSysMsg(0, "<li>密码最少为6位，最大为18位</li>");
        }

        AdminModel.Password = Function.MD5Encrypt(txtAdminPWD.Text);

            
        if (UserId == 0)
        {
            AdminBll.Add(AdminModel);
            Function.ShowSysMsg(1, "<li>添加管理员成功!</li><li><a href='user/AdminList.aspx'>管理员列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        else
        {
            AdminModel.UserId = UserId;
            AdminBll.UpdateInfo(AdminModel);
            Function.ShowSysMsg(1, "<li>修改管理员成功!</li><li><a href='user/AdminList.aspx'>管理员列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
    }

    private void BindAdminGroup()
    {
        DataTable dt = GroupBll.GetAdminList();
        DDlistGroup.DataSource = dt;
        DDlistGroup.DataTextField = "PowerName";
        DDlistGroup.DataValueField = "PowerId";
        DDlistGroup.DataBind();
    }

    private void BindOnUpdate()
    {
        AdminModel = AdminBll.GetModel(UserId);
        if (AdminModel != null)
        {
            lbInfo.Text = "如果不修改密码，请留空";
            txtAdminLoginID.Text = AdminModel.LoginName;
            txtAdminName.Text = AdminModel.UserName;
            DDlistGroup.SelectedValue = AdminModel.GroupId.ToString();
            AllowMultiLogin.SelectedValue = AdminModel.AllowMultiLogin.ToString();
        }
        else
        { Function.ShowSysMsg(0,"<li>无此用户</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
    }

    void CheckInput()
    {
        if (txtAdminLoginID.Text.Trim() == "")
        {
            Function.ShowSysMsg(0,"<li>登录名不能为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtAdminPWD.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>密码不能为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtAdminPWD.Text.Length>18 || txtAdminPWD.Text.Length<6)
        {
            Function.ShowSysMsg(0, "<li>密码长度为6-18位。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtAdminPWD.Text != txtAdminPWDAG.Text)
        {
            Function.ShowSysMsg(0, "<li>两次输入的密码不一致，请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (UserId == 0)
        {
            B_KyCommon kycomm = new B_KyCommon();
            if (kycomm.CheckHas(txtAdminLoginID.Text, "LoginName", "KyAdmin"))
            {
                Function.ShowSysMsg(0, "<li>对不起，此登录名已存在，请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }
    }
}
