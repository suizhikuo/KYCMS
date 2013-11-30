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
using Ky.SQLServerDAL;
using Ky.BLL;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class user_space_RegSpace : System.Web.UI.Page
{
    M_UserSpace UserSpaceModel = new M_UserSpace();
    B_UserSpace UserSpaceBll = new B_UserSpace();
    int Id = 0;
    B_User UserBll = new B_User();
    protected M_User UserModel = new M_User();
    B_Dictionary DictionaryBll = new B_Dictionary();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        }
        UserSpaceModel = UserSpaceBll.GetUserSpaceById(UserModel.UserID);
        if (UserSpaceModel != null)
        {
            Id = UserSpaceModel.Id;
            Label1.Text = Label2.Text = "修改";
            btnSaveCate.Text = "修 改";
        }

        if (!IsPostBack)
        {
            txtSpaceName.Text = UserModel.LogName;
            TemplateBind();
            if (Id > 0)
                ShowInfo(Id);
            if (UserModel.TypeId != 1)
                tbody.Attributes.Add("style", "display:none");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        M_UserSpace userSpaceModel = new M_UserSpace();
        userSpaceModel.Id = Id;
        userSpaceModel.SpaceName = txtSpaceName.Text.Trim();
        userSpaceModel.SpaceDescription = txtSpaceDescription.Text.Trim();
        userSpaceModel.UserId = UserModel.UserID;
        userSpaceModel.UserName = UserModel.LogName;
        userSpaceModel.AddTime = DateTime.Now.ToString();
        userSpaceModel.PrevPower = Convert.ToInt32(rdBtnPower.SelectedValue);
        userSpaceModel.Password = txtPassword.Text.Trim();
        userSpaceModel.TemplateId = Convert.ToInt32(ddlTemplateId.SelectedValue);
        userSpaceModel.UserType = UserModel.TypeId;
        if (Id == 0)
        {
            UserSpaceBll.RegSpace(userSpaceModel);
            Function.ShowMsg(1, "<li>空间激活成功!</li><li><a href='../user/welcome.aspx'>返回用户后台首页!</a></li>");
        }
        else
        {
            UserSpaceBll.UpdateSpace(userSpaceModel);
            Function.ShowMsg(1, "<li>空间信息修改成功!</li><li><a href='../user/welcome.aspx'>返回用户后台首页!</a></li>");
        }
    }
    protected void ShowInfo(int Id)
    {
        UserSpaceModel = UserSpaceBll.GetUserSpaceById(UserModel.UserID);
        if (UserSpaceModel == null)
            return;
        txtSpaceName.Text = UserSpaceModel.SpaceName;
        txtSpaceDescription.Text = UserSpaceModel.SpaceDescription;
        rdBtnPower.SelectedValue = UserSpaceModel.PrevPower.ToString();
        txtPassword.Text = UserSpaceModel.Password;
        ddlTemplateId.SelectedValue = UserSpaceModel.TemplateId.ToString();
    }
    protected void TemplateBind()
    {
        
        B_UserGroupModel userGroupModelBll = new B_UserGroupModel();
        M_UserGroupModel userGroupModel =  userGroupModelBll.GetModel(UserModel.TypeId);
        if (userGroupModel.SpaceTypeId == 1)
            ddlTemplateId.DataSource = DictionaryBll.FormatCategory(17);
        else if (userGroupModel.SpaceTypeId == 2)
            ddlTemplateId.DataSource = DictionaryBll.FormatCategory(25);
        ddlTemplateId.DataTextField = "DicName";
        ddlTemplateId.DataValueField = "DicId";
        ddlTemplateId.DataBind();

    }
}
