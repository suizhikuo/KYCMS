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
using Ky.BLL.CommonModel;
using Ky.Common;
using Ky.Model;

public partial class system_UserGroupModel_UserGroupModel : System.Web.UI.Page
{
    protected int Id=0;
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    private M_CustomForm MCustomForm = new M_CustomForm();
    private B_InfoModel BInfoModel = new B_InfoModel();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(49);

        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }

        if (!Page.IsPostBack)
        {
            if (Id != 0)
            {
                Literal1.Text = "修改";
                txtTableName.Enabled = false;
                GetModel();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //验证表单
        GetValidateForm();

        string TableName = "Ky_User_" + txtTableName.Text;

        //检查表名是否存在
        #region
        if (Id == 0)
        {
            if (!BInfoModel.CheckTableValidate(TableName))
            {
                Function.ShowSysMsg(0, "<li>该表名已经存在,请另外输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li> <li><a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a> <a href='UserGroupModel/UserGroupModel.aspx'>重新添加用户注册模型</a></li>");
            }
        }
        #endregion

        MUserGroupModel.Name = txtName.Text;
        MUserGroupModel.TableName = TableName;
        MUserGroupModel.Content = txtContent.Text;
        MUserGroupModel.AddTime = DateTime.Now;
        MUserGroupModel.IsValidate = bool.Parse(txtIsValidate.SelectedValue);
        MUserGroupModel.IsHtml=bool.Parse(IsHtml.SelectedValue);
        MUserGroupModel.SpaceTypeId = int.Parse(SpaceTypeId.SelectedValue);

        if (Id != 0)
        {
            MUserGroupModel.Id = Id;
            BUserGroupModel.Update(MUserGroupModel);

            Function.ShowSysMsg(1, "<li>成功修改用户注册模型</li><li><a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a> <a href='UserGroupModel/UserGroupModel.aspx?Id=" + Id + "'>重新修改用户注册模型</a></li>");
        }
        else
        {
            MUserGroupModel.ModelHtml = "";
            MUserGroupModel.UserGroupId = 0;
            BUserGroupModel.Add(MUserGroupModel);
            Function.ShowSysMsg(1, "<li>成功新增用户注册模型</li><li><a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a> <a href='UserGroupModel/UserGroupModel.aspx'>继续添加用户注册模型</a></li>");
        }
    }

    private void GetValidateForm()
    {
        if (txtName.Text == "")
        {
            Function.ShowSysMsg(0, "<li>用户组名称不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
        }

        if (txtTableName.Text == "")
        {
            Function.ShowSysMsg(0, "<li>表名不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
        }

        if (!Function.CheckLetterAndNumber(txtTableName.Text))
        {
            Function.ShowSysMsg(0, "<li>表名只能够是英文、数字或者下划线组成</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
        }
    }

    private void GetModel()
    {
        MUserGroupModel = BUserGroupModel.GetModel(Id);

        txtName.Text = MUserGroupModel.Name;
        txtTableName.Text = MUserGroupModel.TableName.Replace("Ky_User_", "");
        txtContent.Text = MUserGroupModel.Content;
        txtIsValidate.SelectedValue = MUserGroupModel.IsValidate.ToString();
        IsHtml.SelectedValue = MUserGroupModel.IsHtml.ToString();
        SpaceTypeId.SelectedValue = MUserGroupModel.SpaceTypeId.ToString();
    }
}
