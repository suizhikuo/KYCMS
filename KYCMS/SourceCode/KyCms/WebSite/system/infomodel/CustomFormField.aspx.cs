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

public partial class system_infomodel_CustomFormField : System.Web.UI.Page
{
    protected int CustomFormId = 0;
    protected int FieldId = 0;
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

        if (!string.IsNullOrEmpty(Request.QueryString["FieldId"]))
        {
            try
            {
                FieldId = int.Parse(Request.QueryString["FieldId"]);
            }
            catch { }
        }
        
        MCustomForm = BCustomForm.GetModel(CustomFormId);

        if (!Page.IsPostBack)
        {

            if (CustomFormId != 0)
            {
                if (MCustomForm == null)
                {
                    Function.ShowSysMsg(0, "<li>表单不存在或已经被删除</li><li><a href='infomodel/CustomFormList.aspx'>返回表单管理列表</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段管理列表</a></li>");
                }
            }

            if (FieldId != 0)
            {
                MCustomFormField = BCustomFormField.GetModel(FieldId);

                if (MCustomFormField == null)
                {
                    Function.ShowSysMsg(0, "<li>该字段不存在或已经被删除</li><li><a href='infomodel/CustomFormList.aspx'>返回表单管理列表</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段管理列表</a></li>");
                }

                GetShow();
                Name.Enabled = false;
                Type.Enabled = false;
                Button1.Text = " 确认修改 ";
            }

            FormName.Text = MCustomForm.FormName;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //验证判断
        GetIsOk();

        string MyName = Name.Text;
        string MyAlias = Function.HtmlEncode(Alias.Text);
        string MyDescription = Function.HtmlEncode(Description.Text);
        bool MyIsNotNull = bool.Parse(IsNotNull.SelectedValue);
        bool MyIsList = bool.Parse(IsList.SelectedValue);
        bool MyIsUserInsert = bool.Parse(IsUserInsert.SelectedValue);
        bool MyIsSearchForm = bool.Parse(IsSearchForm.SelectedValue);
        string FieldType = "nvarchar";
        string DefaultValue = "";

        string MyType = Type.SelectedValue;
        string MyContent = "";

        switch (MyType)
        {
            case "TextType":
                MyContent = "TitleSize=" + TitleSize.Text + ",IsPassword=" + IsPassword.Text + ",DefaultValue=" + TextType_DefaultValue.Text + "";
                FieldType = "nvarchar";
                break;
            case "MultipleTextType":
                MyContent = "Width=" + MultipleTextType_Width.Text + ",Height=" + MultipleTextType_Height.Text + "";
                FieldType = "ntext";
                break;
            case "MultipleHtmlType":
                MyContent = "Width=" + MultipleHtmlType_Width.Text + ",Height=" + MultipleHtmlType_Height.Text + ",IsEditor=" + IsEditor.SelectedValue + "";
                FieldType = "ntext";
                break;
            case "RadioType":
                MyContent = "" + RadioType_Type.SelectedValue + "=" + Function.HtmlEncode(RadioType_Content.Text.Trim()).Replace(" ", "").Replace("\r\n", "|") + ",Property=" + RadioType_Property.Text + ",Default=" + RadioType_Default.Text + "";
                FieldType = "nvarchar";
                DefaultValue = RadioType_Default.Text;
                break;
            case "ListBoxType":
                MyContent = "" + ListBoxType_Type.SelectedValue + "=" + Function.HtmlEncode(ListBoxType_Content.Text.Trim()).Replace(" ", "").Replace("\r\n", "|") + "";
                FieldType = "ntext";
                break;
            case "NumberType":
                MyContent = "TitleSize=" + NumberType_TitleSize.Text + ",DefaultValue=" + NumberType_DefaultValue.Text + "";
                FieldType = "int";
                break;
            default:
                MyContent = "";
                break;
        }

        MCustomFormField.CustomFormId = CustomFormId;
        MCustomFormField.Name = MyName;
        MCustomFormField.Alias = MyAlias;
        //MModelField.Tips = MyTips;
        MCustomFormField.Description = MyDescription;
        MCustomFormField.IsNotNull = MyIsNotNull;
        MCustomFormField.IsSearchForm = MyIsSearchForm;
        MCustomFormField.Type = MyType;
        MCustomFormField.Content = MyContent;
        MCustomFormField.IsNotNull = MyIsNotNull;
        MCustomFormField.IsList = MyIsList;
        MCustomFormField.IsUserInsert = MyIsUserInsert;
        MCustomFormField.AddDate = DateTime.Now;

        if (FieldId == 0)
        {
            if (BModelField.IsNotField(MCustomForm.TableName, MyName))
            {
                BCustomFormField.Add(MCustomFormField);   //记录字段表

                BModelField.AddField(MCustomForm.TableName, MyName, FieldType, DefaultValue);  //增加字段

                Function.ShowSysMsg(1, "<li>成功添加字段" + MyName + "</li><li><a href='infomodel/CustomFormField.aspx?CustomFormId=" + CustomFormId + "'>继续添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }
            else
            {
                Function.ShowSysMsg(0, "<li>该字段已经存在</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }
        }
        else
        {
            if (MyType == "RadioType")
            {
                BModelField.UpdateFieldDefault(MCustomForm.TableName, MyName, DefaultValue);
            }
            MCustomFormField.FieldId = FieldId;
            BCustomFormField.Update(MCustomFormField);
            Function.ShowSysMsg(1, "<li>成功修改字段" + MyName + "</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }
    }

    private void GetIsOk()
    {
        string MyName = Name.Text;
        string MyAlias = Alias.Text;
        string MyType = Type.SelectedValue;

        if (MyName == "")
        {
            Function.ShowSysMsg(0, "<li>字段名称不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (!Function.CheckLetterAndNumber(MyName))
        {
            Function.ShowSysMsg(0, "<li>字段名只能够是数字、字母和下划线组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        if (MyAlias == "")
        {
            Function.ShowSysMsg(0, "<li>字段别名不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
        }

        #region TextType
        if (MyType == "TextType")
        {
            if (TitleSize.Text == "")
            {
                Function.ShowSysMsg(0, "<li>文本框长度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }

            if (!Function.CheckNumber(TitleSize.Text))
            {
                Function.ShowSysMsg(0, "<li>文本框长度只能够为数字！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }
        }
        #endregion

        #region MultipleTextType
        if (MyType == "MultipleTextType")
        {
            if (MultipleTextType_Width.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的宽度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleTextType_Width.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的宽度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }

            if (MultipleTextType_Height.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的高度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleTextType_Height.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的高度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }
        }
        #endregion

        #region MultipleHtmlType
        if (MyType == "MultipleHtmlType")
        {
            if (MultipleHtmlType_Width.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的宽度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleHtmlType_Width.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的宽度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }

            if (MultipleHtmlType_Height.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的高度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleHtmlType_Height.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的高度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }
        }
        #endregion

        #region RadioType
        if (MyType == "RadioType")
        {
            if (RadioType_Content.Text == "")
            {
                Function.ShowSysMsg(0, "<li>分行键入每个选项不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }
        }
        #endregion

        #region ListBoxType
        if (MyType == "ListBoxType")
        {
            if (ListBoxType_Content.Text == "")
            {
                Function.ShowSysMsg(0, "<li>分行键入每个选项不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/CustomFormFieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/CustomFormList.aspx'>返回表单管理</a></li>");
            }
        }
        #endregion

        #region NumberType
        if (MyType == "NumberType")
        {
            if (NumberType_TitleSize.Text == "")
            {
                Function.ShowSysMsg(0, "<li>文本框长度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(NumberType_TitleSize.Text))
            {
                Function.ShowSysMsg(0, "<li>文本框长度只能够为数字！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?CustomFormId=" + CustomFormId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?CustomFormId=" + CustomFormId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion
    }

    private void GetShow()
    {
        MCustomFormField = BCustomFormField.GetModel(FieldId);

        Name.Text = MCustomFormField.Name;
        Alias.Text = MCustomFormField.Alias;
        Description.Text = MCustomFormField.Description;
        IsNotNull.SelectedValue = MCustomFormField.IsNotNull.ToString();
        IsList.SelectedValue = MCustomFormField.IsList.ToString();
        IsUserInsert.SelectedValue = MCustomFormField.IsUserInsert.ToString();
        IsSearchForm.SelectedValue = MCustomFormField.IsSearchForm.ToString();

        string MyType = MCustomFormField.Type;
        string MyContent = MCustomFormField.Content;

        Type.SelectedValue = MyType;

        if (MyType == "TextType")
        {
            TitleSize.Text = BModelField.GetFieldContent(MyContent, 0, 1);
            IsPassword.SelectedValue = BModelField.GetFieldContent(MyContent, 1, 1);
            TextType_DefaultValue.Text = BModelField.GetFieldContent(MyContent, 2, 1);
        }

        if (MyType == "MultipleTextType")
        {
            MultipleTextType_Width.Text = BModelField.GetFieldContent(MyContent, 0, 1);
            MultipleTextType_Height.Text = BModelField.GetFieldContent(MyContent, 1, 1);
        }

        if (MyType == "MultipleHtmlType")
        {
            MultipleHtmlType_Width.Text = BModelField.GetFieldContent(MyContent, 0, 1);
            MultipleHtmlType_Height.Text = BModelField.GetFieldContent(MyContent, 1, 1);
            IsEditor.SelectedValue = BModelField.GetFieldContent(MyContent, 2, 1);
        }

        if (MyType == "RadioType")
        {
            RadioType_Content.Text = Function.Decode(BModelField.GetFieldContent(MyContent, 0, 1).Replace("|", "<br>"));
            RadioType_Type.SelectedValue = BModelField.GetFieldContent(MyContent, 0, 0);
            RadioType_Property.SelectedValue = BModelField.GetFieldContent(MyContent, 1, 1).ToString();
            RadioType_Default.Text = BModelField.GetFieldContent(MyContent, 2, 1).ToString();
        }

        if (MyType == "ListBoxType")
        {
            ListBoxType_Content.Text = Function.Decode(BModelField.GetFieldContent(MyContent, 0, 1).Replace("|", "<br>"));
            ListBoxType_Type.SelectedValue = BModelField.GetFieldContent(MyContent, 0, 0);
        }

        if (MyType == "NumberType")
        {
            NumberType_TitleSize.Text = BModelField.GetFieldContent(MyContent, 0, 1);
            NumberType_DefaultValue.Text = BModelField.GetFieldContent(MyContent, 1, 1);
        }
    }
}
