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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;
using Ky.BLL;

public partial class system_infomodel_CustomFormFieldList : System.Web.UI.Page
{
    protected int CustomFormId = 0;
    private B_ModelField BModelField = new B_ModelField();

    private B_CustomForm BCustomForm = new B_CustomForm();
    private M_CustomForm MCustomForm = new M_CustomForm();

    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    private M_CustomFormField MCustomFormField = new M_CustomFormField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

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
            MCustomForm = BCustomForm.GetModel(CustomFormId);

            if (CustomFormId != 0)
            {

                if (MCustomForm == null)
                {
                    Function.ShowSysMsg(0, "<li>表单不存在或已经被删除</li><li><a href='infomodel/CustomFormList.aspx'>返回表单管理列表</a></li>");
                }
            }

            FormName.Text = MCustomForm.FormName;

            DataList();
        }
    }

    private void DataList()
    {
        RepCustomFormField.DataSource = BCustomFormField.GetList(CustomFormId);
        RepCustomFormField.DataBind();
    }

    protected void RepCustomFormField_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());
            MCustomFormField = BCustomFormField.GetModel(FieldId);

            MCustomForm = BCustomForm.GetModel(CustomFormId);

            BCustomFormField.Del(FieldId);
            BModelField.DelField(MCustomForm.TableName, MCustomFormField.Name);

            DataList();
        }

        if (e.CommandName == "UpMove")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());

            BCustomFormField.MoveField(CustomFormId, FieldId, "UpMove");

            DataList();
        }

        if (e.CommandName == "DownMove")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());

            BCustomFormField.MoveField(CustomFormId, FieldId, "DownMove");

            DataList();
        }
    }
}
