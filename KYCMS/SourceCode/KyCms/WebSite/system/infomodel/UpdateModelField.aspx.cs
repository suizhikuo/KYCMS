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
using System.Text;

public partial class system_infomodel_UpdateModelField : System.Web.UI.Page
{
    protected int ModelId = 0;
    protected int FieldId = 0;
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private M_ModelField MModelField = new M_ModelField();
    private B_ModelField BModelField = new B_ModelField();
    private M_InfoModel infoModel = new M_InfoModel();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private M_InfoModel MInfoModel = new M_InfoModel();
    private B_InfoModel BInfoModel = new B_InfoModel();
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_Dictionary BDictionary = new B_Dictionary();
    private M_Dictionary MDictionary = new M_Dictionary();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(35);
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }

            try
            {
                FieldId = int.Parse(Request.QueryString["FieldId"]);
            }
            catch { }
        }

        infoModel = InfoModelBll.GetModel(ModelId);

        if (!Page.IsPostBack)
        {

            if (ModelId != 0)
            {

                if (infoModel == null)
                {
                    Function.ShowSysMsg(0, "<li>模型不存在或已经被删除</li><li><a href='infomodel/ModelList.aspx'>返回模型管理列表</a></li>");
                }

                if (infoModel.IsSystem)
                {
                    Function.ShowSysMsg(0, "<li>系统模型不允许列出字段</li><li><a href='infomodel/ModelList.aspx'>返回模型管理列表</a></li>");
                }
            }

            ModelName.Text = infoModel.ModelName;
            ErLinkage_Value.Attributes.Add("readonly", "");
            ErLinkage_Value_Show.Attributes.Add("readonly", "");
            SanLinkage_Value.Attributes.Add("readonly", "");

            GetShow();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //验证判断
        GetIsOk();

        string MyName = Name.Text;
        string MyAlias = Alias.Text;
        string MyDescription = Description.Text;
        bool MyIsNotNull = bool.Parse(IsNotNull.SelectedValue);
        bool MyIsSearchForm = bool.Parse(IsSearchForm.SelectedValue);
        string DefaultValue = "";

        string MyType = Type.SelectedValue;
        string MyContent = "";

        switch (MyType)
        {
            case "TextType":
                MyContent = "TitleSize=" + TitleSize.Text + ",IsPassword=" + IsPassword.Text + ",DefaultValue=" + TextType_DefaultValue.Text + "";
                break;
            case "MultipleTextType":
                MyContent = "Width=" + MultipleTextType_Width.Text + ",Height=" + MultipleTextType_Height.Text + "";

                break;
            case "MultipleHtmlType":
                MyContent = "Width=" + MultipleHtmlType_Width.Text + ",Height=" + MultipleHtmlType_Height.Text + ",IsEditor=" + IsEditor.SelectedValue + "";
                break;
            case "RadioType":
                MyContent = "" + RadioType_Type.SelectedValue + "=" + Function.HtmlEncode(RadioType_Content.Text.Trim()).Replace(" ","").Replace("\r\n", "|") + ",Property=" + RadioType_Property.Text + ",Default=" + RadioType_Default.Text + "";

                DefaultValue = RadioType_Default.Text;
                //修改默认值
                BModelField.UpdateFieldDefault(infoModel.TableName, MyName, DefaultValue);
                break;
            case "ListBoxType":
                MyContent = "" + ListBoxType_Type.SelectedValue + "=" + Function.HtmlEncode(ListBoxType_Content.Text.Trim()).Replace(" ", "").Replace("\r\n", "|") + "";
                break;
            case "NumberType":
                MyContent = "TitleSize=" + NumberType_TitleSize.Text + ",DefaultValue=" + NumberType_DefaultValue.Text + "";
                break;
            case "ErLinkageType":
                MyContent = "YiId=" + ErLinkage_Value.Text + ",Er_Alias=" + ErLinkage_Er_Alias.Text + ",Er_Name=" + ErLinkage_Er_Name.Text + "";
                break;
            case "SanLinkageType":
                MyContent = "YiId=" + SanLinkage_Value.Text + ", Er_Alias=" + SanLinkage_Er_Alias.Text + ",Er_Name=" + SanLinkage_Er_Name.Text + ",San_Alias=" + SanLinkage_San_Alias.Text + ",San_Name=" + SanLinkage_San_Name.Text + "";
                break;
            default:
                MyContent = "";
                break;
        }

        MModelField.FieldId = FieldId;
        MModelField.Alias = MyAlias;
        MModelField.ModelId = ModelId;
        MModelField.Description = MyDescription;
        MModelField.IsNotNull = MyIsNotNull;
        MModelField.IsSearchForm = MyIsSearchForm;
        MModelField.Content = MyContent;
        MModelField.AddDate = DateTime.Now;

        BModelField.Update(MModelField);   //记录字段表

        if (!infoModel.IsHtml)  //自动生成
        {
            DataTable dt = new DataTable();
            dt = BModelField.GetList(ModelId);
            StringBuilder sb = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == dt.Rows.Count - 1)
                    {
                        sb.Append("<tr>\r\n<td align=\"right\" class=\"bqleft\">" + dt.Rows[i]["Alias"].ToString() + "：</td>\r\n<td class=\"bqright\">" + GetShowStyle(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["IsNotNull"].ToString(), dt.Rows[i]["Type"].ToString(), dt.Rows[i]["Content"].ToString(), dt.Rows[i]["Description"].ToString()) + "</td>\r\n</tr>");
                    }
                    else
                    {
                        sb.Append("<tr>\r\n<td align=\"right\" class=\"bqleft\">" + dt.Rows[i]["Alias"].ToString() + "：</td>\r\n<td class=\"bqright\">" + GetShowStyle(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["IsNotNull"].ToString(), dt.Rows[i]["Type"].ToString(), dt.Rows[i]["Content"].ToString(), dt.Rows[i]["Description"].ToString()) + "</td>\r\n</tr>\r\n");
                    }
                }
            }

            MInfoModel.ModelId = ModelId;
            MInfoModel.ModelHtml = sb.ToString();

            BInfoModel.UpdateModelHtml(MInfoModel);

            Function.ShowSysMsg(1, "<li>成功编辑字段" + MyName + "</li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>继续添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
        }
        else
        {
            Function.ShowSysMsg(1, "<li>成功编辑字段" + MyName + "</li><li>你开启了手动编辑录入界面，修改字段后需要<a href='infomodel/ModeldFieldHtml.aspx?ModelId=" + ModelId + "'>重新生成字段静态Html代码</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>继续添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
        }
    }

    private void GetShow()
    {
        MModelField = BModelField.GetModel(FieldId);

        Name.Text = MModelField.Name;
        Alias.Text = MModelField.Alias;
        Description.Text = MModelField.Description;
        IsNotNull.SelectedValue = MModelField.IsNotNull.ToString();
        IsSearchForm.SelectedValue = MModelField.IsSearchForm.ToString();

        string MyType = MModelField.Type;
        string MyContent = MModelField.Content;

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

        if (MyType == "ErLinkageType")
        {
            ErLinkage_Value.Text = BModelField.GetFieldContent(MyContent, 0, 1);
            MDictionary = BDictionary.GetModel(int.Parse(BModelField.GetFieldContent(MyContent, 0, 1)));
            ErLinkage_Value_Show.Text = MDictionary.DicName;
            ErLinkage_Er_Alias.Text = BModelField.GetFieldContent(MyContent, 1, 1);
            ErLinkage_Er_Name.Text = BModelField.GetFieldContent(MyContent, 2, 1);
        }

        if (MyType == "SanLinkageType")
        {
            SanLinkage_Value.Text = BModelField.GetFieldContent(MyContent, 0, 1);
            SanLinkage_Er_Alias.Text = BModelField.GetFieldContent(MyContent, 1, 1);
            SanLinkage_Er_Name.Text = BModelField.GetFieldContent(MyContent, 2, 1);
            SanLinkage_San_Alias.Text = BModelField.GetFieldContent(MyContent, 3, 1);
            SanLinkage_San_Name.Text = BModelField.GetFieldContent(MyContent, 4, 1);
        }
    }

    private void GetIsOk()
    {
        string MyName = Name.Text;
        string MyAlias = Alias.Text;
        string MyType = Type.SelectedValue;

        if (MyName == "")
        {
            Function.ShowSysMsg(0, "<li>字段名称不能够为空</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
        }

        if (!Function.CheckLetterAndNumber(MyName))
        {
            Function.ShowSysMsg(0, "<li>字段名只能够是数字、字母和下划线组成</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
        }

        if (MyAlias == "")
        {
            Function.ShowSysMsg(0, "<li>字段别名不能够为空</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
        }

        #region TextType
        if (MyType == "TextType")
        {
            if (TitleSize.Text == "")
            {
                Function.ShowSysMsg(0, "<li>文本框长度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(TitleSize.Text))
            {
                Function.ShowSysMsg(0, "<li>文本框长度只能够为数字！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion

        #region MultipleTextType
        if (MyType == "MultipleTextType")
        {
            if (MultipleTextType_Width.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的宽度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleTextType_Width.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的宽度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (MultipleTextType_Height.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的高度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleTextType_Height.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的高度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion

        #region MultipleHtmlType
        if (MyType == "MultipleHtmlType")
        {
            if (MultipleHtmlType_Width.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的宽度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleHtmlType_Width.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的宽度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (MultipleHtmlType_Height.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的高度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleHtmlType_Height.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的高度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion

        #region RadioType
        if (MyType == "RadioType")
        {
            if (RadioType_Content.Text == "")
            {
                Function.ShowSysMsg(0, "<li>分行键入每个选项不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion

        #region ListBoxType
        if (MyType == "ListBoxType")
        {
            if (ListBoxType_Content.Text == "")
            {
                Function.ShowSysMsg(0, "<li>分行键入每个选项不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion

        #region NumberType
        if (MyType == "NumberType")
        {
            if (NumberType_TitleSize.Text == "")
            {
                Function.ShowSysMsg(0, "<li>文本框长度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(NumberType_TitleSize.Text))
            {
                Function.ShowSysMsg(0, "<li>文本框长度只能够为数字！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion

        #region ErLinkageType
        if (MyType == "ErLinkageType")
        {
            if (ErLinkage_Value.Text == "")
            {
                Function.ShowSysMsg(0, "<li>请指定一级类别！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (ErLinkage_Er_Alias.Text.Trim() == "")
            {
                Function.ShowSysMsg(0, "<li>二级分类字段别名不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (ErLinkage_Er_Name.Text.Trim() == "")
            {
                Function.ShowSysMsg(0, "<li>二级分类字段名不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckLetterAndNumber(ErLinkage_Er_Name.Text.Trim()))
            {
                Function.ShowSysMsg(0, "<li>二级分类字段名只能够是数字、字母和下划线组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (ErLinkage_Er_Name.Text.Trim() == MyName.Trim())
            {
                Function.ShowSysMsg(0, "<li>二级分类字段名称重复！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='infomodel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
            }
        }
        #endregion
    }
    
    /// <summary>
    /// 返回样式
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Type"></param>
    /// <param name="Content"></param>
    /// <param name="Description"></param>
    /// <returns></returns>
    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description, null);
    }
}
