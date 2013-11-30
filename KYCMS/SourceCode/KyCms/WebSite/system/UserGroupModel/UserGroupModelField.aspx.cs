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

public partial class system_UserGroupModel_UserGroupModelField : System.Web.UI.Page
{
    protected int ModelId = 0;
    protected int FieldId = 0;
    private B_ModelField BModelField = new B_ModelField();

    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();

    private B_UserGroupModelField BUserGroupModelField = new B_UserGroupModelField();
    private M_UserGroupModelField MUserGroupModelField = new M_UserGroupModelField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_Dictionary BDictionary = new B_Dictionary();
    private M_Dictionary MDictionary = new M_Dictionary();


    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(49);

        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
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

        MUserGroupModel = BUserGroupModel.GetModel(ModelId);

        if (!Page.IsPostBack)
        {

            if (ModelId != 0)
            {
                if (MUserGroupModel == null)
                {
                    Function.ShowSysMsg(0, "<li>用户注册模型不存在或已经被删除</li><li><a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理列表</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段管理列表</a></li>");
                }
            }

            if (FieldId != 0)
            {
                MUserGroupModelField = BUserGroupModelField.GetModel(FieldId);

                if (MUserGroupModelField == null)
                {
                    Function.ShowSysMsg(0, "<li>该字段不存在或已经被删除</li><li><a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理列表</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段管理列表</a></li>");
                }

                GetShow();
                Name.Enabled = false;
                Type.Enabled = false;
                Button1.Text = " 确认修改 ";
            }

            ModelName.Text = MUserGroupModel.Name;
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
            case "ErLinkageType":
                MyContent = "YiId=" + ErLinkage_Value.Text + ",Er_Alias=" + ErLinkage_Er_Alias.Text + ",Er_Name=" + ErLinkage_Er_Name.Text + "";
                FieldType = "nvarchar";
                break;
            default:
                MyContent = "";
                break;
        }

        MUserGroupModelField.ModelId = ModelId;
        MUserGroupModelField.Name = MyName;
        MUserGroupModelField.Alias = MyAlias;
        //MModelField.Tips = MyTips;
        MUserGroupModelField.Description = MyDescription;
        MUserGroupModelField.IsNotNull = MyIsNotNull;
        MUserGroupModelField.IsSearchForm = MyIsSearchForm;
        MUserGroupModelField.Type = MyType;
        MUserGroupModelField.Content = MyContent;
        MUserGroupModelField.IsNotNull = MyIsNotNull;
        MUserGroupModelField.IsList = MyIsList;
        MUserGroupModelField.IsUserInsert = MyIsUserInsert;
        MUserGroupModelField.AddDate = DateTime.Now;

        if (FieldId == 0)
        {
            if (BModelField.IsNotField(MUserGroupModel.TableName, MyName))
            {
                if (MyType == "ErLinkageType")
                {
                    if (BModelField.IsNotField(MUserGroupModel.TableName, ErLinkage_Er_Name.Text.Trim()))
                    {
                        BModelField.AddField(MUserGroupModel.TableName, ErLinkage_Er_Name.Text.Trim() + "_Id", "int", DefaultValue);  //增加字段
                        BModelField.AddField(MUserGroupModel.TableName, ErLinkage_Er_Name.Text.Trim(), FieldType, DefaultValue);  //增加字段
                        BModelField.AddField(MUserGroupModel.TableName, MyName + "_Id", "int", DefaultValue);  //增加字段
                    }
                    else
                    {
                        Function.ShowSysMsg(0, "<li>二级联动中有字段已经存在</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
                    }
                }

                BUserGroupModelField.Add(MUserGroupModelField);   //记录字段表
                BModelField.AddField(MUserGroupModel.TableName, MyName, FieldType, DefaultValue);  //增加字段

                if (!MUserGroupModel.IsHtml)
                {
                    DataTable dt = new DataTable();
                    dt = BUserGroupModelField.GetIsUserList(ModelId);
                    StringBuilder sb = new StringBuilder();
                    string MorePicType = "";

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Type"].ToString() == "MorePicType")
                            {
                                MorePicType = "(<span id=\"txt_" + dt.Rows[i]["Name"].ToString() + "_count\" style=\"color:Red;\">0</span>)";
                            }

                            if (i == dt.Rows.Count - 1)
                            {
                                sb.Append("<tr>\r\n<td align=\"right\" class=\"bqleft\">" + dt.Rows[i]["Alias"].ToString().Trim() + "" + MorePicType + "：</td>\r\n<td class=\"bqright\">" + GetShowStyle(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["IsNotNull"].ToString(), dt.Rows[i]["Type"].ToString(), dt.Rows[i]["Content"].ToString(), dt.Rows[i]["Description"].ToString()) + "</td>\r\n</tr>");
                            }
                            else
                            {
                                sb.Append("<tr>\r\n<td align=\"right\" class=\"bqleft\">" + dt.Rows[i]["Alias"].ToString().Trim() + "" + MorePicType + "：</td>\r\n<td class=\"bqright\">" + GetShowStyle(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["IsNotNull"].ToString(), dt.Rows[i]["Type"].ToString(), dt.Rows[i]["Content"].ToString(), dt.Rows[i]["Description"].ToString()) + "</td>\r\n</tr>\r\n");
                            }
                            MorePicType = "";
                        }
                    }

                    MUserGroupModel.Id = ModelId;
                    MUserGroupModel.ModelHtml = sb.ToString();

                    BUserGroupModel.UpdateModelHtml(MUserGroupModel);

                    Function.ShowSysMsg(1, "<li>成功添加字段" + MyName + "</li><li><a href='UserGroupModel/UserGroupModelField.aspx?ModelId=" + ModelId + "'>继续添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
                }
                else 
                {
                    Function.ShowSysMsg(1, "<li>成功添加字段" + MyName + "</li><li>添加字段后，需要重新生成模型字段Html</li><li><a href='UserGroupModel/UserGroupModelField.aspx?ModelId=" + ModelId + "'>继续添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
                }
            }
            else
            {
                Function.ShowSysMsg(0, "<li>该字段已经存在</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
        }
        else
        {
            if (MyType == "RadioType")
            {
                BModelField.UpdateFieldDefault(MUserGroupModel.TableName, MyName, DefaultValue);
            }
            MUserGroupModelField.FieldId = FieldId;
            BUserGroupModelField.Update(MUserGroupModelField);

            if (!MUserGroupModel.IsHtml)
            {
                DataTable dt = new DataTable();
                dt = BUserGroupModelField.GetIsUserList(ModelId);
                StringBuilder sb = new StringBuilder();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == dt.Rows.Count - 1)
                        {
                            sb.Append("<tr>\r\n<td align=\"right\" class=\"bqleft\">" + dt.Rows[i]["Alias"].ToString().Trim() + "：</td>\r\n<td class=\"bqright\">" + GetShowStyle(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["IsNotNull"].ToString(), dt.Rows[i]["Type"].ToString(), dt.Rows[i]["Content"].ToString(), dt.Rows[i]["Description"].ToString()) + "</td>\r\n</tr>");
                        }
                        else
                        {
                            sb.Append("<tr>\r\n<td align=\"right\" class=\"bqleft\">" + dt.Rows[i]["Alias"].ToString().Trim() + "：</td>\r\n<td class=\"bqright\">" + GetShowStyle(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["IsNotNull"].ToString(), dt.Rows[i]["Type"].ToString(), dt.Rows[i]["Content"].ToString(), dt.Rows[i]["Description"].ToString()) + "</td>\r\n</tr>\r\n");
                        }
                    }
                }

                MUserGroupModel.Id = ModelId;
                MUserGroupModel.ModelHtml = sb.ToString();

                BUserGroupModel.UpdateModelHtml(MUserGroupModel);

                Function.ShowSysMsg(1, "<li>成功修改字段" + MyName + "</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
            else
            {
                Function.ShowSysMsg(1, "<li>成功修改字段" + MyName + "</li><li>修改字段后，需要重新生成模型字段Html</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
        }
    }

    private void GetIsOk()
    {
        string MyName = Name.Text;
        string MyAlias = Alias.Text;
        string MyType = Type.SelectedValue;

        if (MyName == "")
        {
            Function.ShowSysMsg(0, "<li>字段名称不能够为空！</li><li><a href='javascript:window.history.back()'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
        }

        if (!Function.CheckLetterAndNumber(MyName))
        {
            Function.ShowSysMsg(0, "<li>字段名只能够是数字、字母和下划线组成！</li><li><a href='javascript:window.history.back()'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
        }

        if (MyAlias == "")
        {
            Function.ShowSysMsg(0, "<li>字段别名不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
        }

        #region TextType
        if (MyType == "TextType")
        {
            if (TitleSize.Text == "")
            {
                Function.ShowSysMsg(0, "<li>文本框长度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }

            if (!Function.CheckNumber(TitleSize.Text))
            {
                Function.ShowSysMsg(0, "<li>文本框长度只能够为数字！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
        }
        #endregion

        #region MultipleTextType
        if (MyType == "MultipleTextType")
        {
            if (MultipleTextType_Width.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的宽度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleTextType_Width.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的宽度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }

            if (MultipleTextType_Height.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的高度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleTextType_Height.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的高度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
        }
        #endregion

        #region MultipleHtmlType
        if (MyType == "MultipleHtmlType")
        {
            if (MultipleHtmlType_Width.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的宽度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleHtmlType_Width.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的宽度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }

            if (MultipleHtmlType_Height.Text == "")
            {
                Function.ShowSysMsg(0, "<li>显示的高度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }

            if (!Function.CheckNumber(MultipleHtmlType_Height.Text))
            {
                Function.ShowSysMsg(0, "<li>显示的高度只能够由数字组成！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
        }
        #endregion

        #region RadioType
        if (MyType == "RadioType")
        {
            if (RadioType_Content.Text == "")
            {
                Function.ShowSysMsg(0, "<li>分行键入每个选项不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
        }
        #endregion

        #region ListBoxType
        if (MyType == "ListBoxType")
        {
            if (ListBoxType_Content.Text == "")
            {
                Function.ShowSysMsg(0, "<li>分行键入每个选项不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
            }
        }
        #endregion

        #region NumberType
        if (MyType == "NumberType")
        {
            if (NumberType_TitleSize.Text == "")
            {
                Function.ShowSysMsg(0, "<li>文本框长度不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/ModelList.aspx'>返回模型管理</a></li>");
            }

            if (!Function.CheckNumber(NumberType_TitleSize.Text))
            {
                Function.ShowSysMsg(0, "<li>文本框长度只能够为数字！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li><li><a href='UserGroupModel/AddModelField.aspx?ModelId=" + ModelId + "'>重新添加字段</a> <a href='UserGroupModel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/ModelList.aspx'>返回模型管理</a></li>");
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

    private void GetShow()
    {
        MUserGroupModelField = BUserGroupModelField.GetModel(FieldId);

        Name.Text = MUserGroupModelField.Name;
        Alias.Text = MUserGroupModelField.Alias;
        Description.Text = MUserGroupModelField.Description;
        IsNotNull.SelectedValue = MUserGroupModelField.IsNotNull.ToString();
        IsList.SelectedValue = MUserGroupModelField.IsList.ToString();
        IsUserInsert.SelectedValue = MUserGroupModelField.IsUserInsert.ToString();
        IsSearchForm.SelectedValue = MUserGroupModelField.IsSearchForm.ToString();

        string MyType = MUserGroupModelField.Type;
        string MyContent = MUserGroupModelField.Content;

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
