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
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class system_infomodel_CustomForm : System.Web.UI.Page
{
    private B_User buser = new B_User();
    private M_User muser = new M_User();
    private B_UserGroup busergroup = new B_UserGroup();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_CustomForm BCustomForm = new B_CustomForm();
    private M_CustomForm MCustomForm = new M_CustomForm();
    private B_InfoModel BInfoModel = new B_InfoModel();
    protected int CustomFormId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(33);

        if (!string.IsNullOrEmpty(Request.QueryString["CustomFormId"]))
        {
            try
            {
                CustomFormId = int.Parse(Request.QueryString["CustomFormId"]);
            }
            catch { }
        }

        if (!Page.IsPostBack)
        {
            UserGroupList.DataSource = busergroup.ManageList("order by UserGroupId desc");
            UserGroupList.DataTextField = "UserGroupName";
            UserGroupList.DataValueField = "UserGroupId";
            UserGroupList.DataBind();

            txtStartTime.Attributes["Readonly"] = "true";
            txtStartTime.Text = DateTime.Now.ToShortDateString();

            txtEndTime.Attributes["Readonly"] = "true";
            txtEndTime.Text = DateTime.Now.AddDays(1).ToShortDateString();

            if (CustomFormId != 0)
            {
                Literal1.Text = "修改";
                txtTableName.Enabled = false;
                GetModel();
            }
        }
    }

    private void GetModel()
    {
        MCustomForm = BCustomForm.GetModel(CustomFormId);

        txtShowForm.SelectedValue = MCustomForm.ShowForm.ToString();
        txtFormName.Text=MCustomForm.FormName;
        txtTableName.Text = MCustomForm.TableName.Replace("Ky_Form_", "");
        txtUploadPath.Text=MCustomForm.UploadPath;
        txtFormDesc.Text=MCustomForm.FormDesc;
        txtIsUnlockTime.SelectedValue=MCustomForm.IsUnlockTime.ToString();
        txtStartTime.Text=MCustomForm.StartTime.ToShortDateString();
        txtEndTime.Text = MCustomForm.EndTime.ToShortDateString();
        txtUploadSize.Text = MCustomForm.UploadSize.ToString();

        if (UserGroupList.Items.Count > 0)
        {
            for (int i = 0; i < UserGroupList.Items.Count; i++)
            {
                if(MCustomForm.UserGroup.IndexOf("|"+UserGroupList.Items[i].Value+"|")!=-1)
                {
                    UserGroupList.Items[i].Selected = true;
                }
            }
        }
        txtIsSubmitNum.SelectedValue=MCustomForm.IsSubmitNum.ToString();
        txtMoney.Text=MCustomForm.Money.ToString();
        txtIsValidate.SelectedValue=MCustomForm.IsValidate.ToString();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //验证表单
        GetValidateForm();

        string TableName = "Ky_Form_" + txtTableName.Text;

        //检查表名是否存在
        #region
        if (CustomFormId == 0)
        {
            if (!BInfoModel.CheckTableValidate(TableName))
            {
                Function.ShowSysMsg(0, "<li>该表名已经存在,请另外输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li> <li><a href='infomodel/CustomFormList.aspx'>返回表单管理</a> <a href='infomodel/AddCustomForm.aspx'>重新添加表单</a></li>");
            }
        }
        #endregion

        MCustomForm.ShowForm = int.Parse(txtShowForm.SelectedValue);
        MCustomForm.FormName = txtFormName.Text;
        MCustomForm.TableName = TableName;
        MCustomForm.UploadPath = txtUploadPath.Text;
        MCustomForm.FormDesc = txtFormDesc.Text;
        MCustomForm.IsUnlockTime = bool.Parse(txtIsUnlockTime.SelectedValue);
        MCustomForm.StartTime = DateTime.Parse(txtStartTime.Text);
        MCustomForm.EndTime = DateTime.Parse(txtEndTime.Text);
        MCustomForm.UploadSize = int.Parse(txtUploadSize.Text);

        string sUserGroupList = "|";
        //这里绑定用户组
        if (UserGroupList.Items.Count > 0)
        {
            for (int i = 0; i < UserGroupList.Items.Count; i++)
            {
                if (UserGroupList.Items[i].Selected == true)
                {
                    sUserGroupList += UserGroupList.Items[i].Value.ToString()+"|";
                }
            }
        }

        MCustomForm.UserGroup = sUserGroupList;
        MCustomForm.IsSubmitNum = bool.Parse(txtIsSubmitNum.SelectedValue);
        MCustomForm.Money = int.Parse(txtMoney.Text);
        MCustomForm.IsValidate = bool.Parse(txtIsValidate.SelectedValue);
        MCustomForm.AddTime = DateTime.Now;

        if (CustomFormId != 0)
        {
            MCustomForm.CustomFormId = CustomFormId;
            BCustomForm.Update(MCustomForm);

            Function.ShowSysMsg(1, "<li>成功修改表单</li><li><a href='infomodel/CustomFormList.aspx'>返回表单管理</a> <a href='infomodel/CustomForm.aspx?CustomFormId=" + CustomFormId + "'>重新修改表单</a></li>");
        }
        else
        {
            BCustomForm.Add(MCustomForm);
            Function.ShowSysMsg(1, "<li>成功新增表单</li><li><a href='infomodel/CustomFormList.aspx'>返回表单管理</a> <a href='infomodel/CustomForm.aspx'>继续添加表单</a></li>");
        }

        Response.End();
    }

    private void GetValidateForm()
    {
        if (txtFormName.Text == "")
        {
            Function.ShowSysMsg(0, "<li>表单名称不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (txtTableName.Text == "")
        {
            Function.ShowSysMsg(0, "<li>表名不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (!Function.CheckLetterAndNumber(txtTableName.Text))
        {
            Function.ShowSysMsg(0, "<li>表名只能够是英文或者数字组成</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (txtUploadPath.Text == "")
        {
            Function.ShowSysMsg(0, "<li>上传附件目录不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (!Function.CheckLetterAndNumber(txtUploadPath.Text))
        {
            Function.ShowSysMsg(0, "<li>上传附件目录只能够是英文或者数字组成</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (!Function.CheckNumber(txtUploadSize.Text))
        {
            Function.ShowSysMsg(0, "<li>上传文件大小只能够是数字</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (txtMoney.Text == "")
        {
            Function.ShowSysMsg(0, "<li>金币设置不能够为空</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (!Function.CheckInteger(txtMoney.Text))
        {
            Function.ShowSysMsg(0, "<li>金币设置只能够为数字</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }
    }
}
