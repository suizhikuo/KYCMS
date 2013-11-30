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
using Ky.Common;
using Ky.Model;
using System.Text.RegularExpressions;

public partial class system_infomodel_CopyModelTable : System.Web.UI.Page
{
    private M_InfoModel MInfoModel = new M_InfoModel();
    private B_InfoModel BInfoModel = new B_InfoModel();
    protected int ModelId = 0;
    private B_ModelField BModelField = new B_ModelField();
    private M_ModelField MModelField = new M_ModelField();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }

        MInfoModel = BInfoModel.GetModel(ModelId);
        ModelName.Text = MInfoModel.ModelName;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string tableName = ModelTable.Text.Trim();
        if (tableName == string.Empty)
        {
            Response.Write("<script language=javascript>alert('表名称必须填写');window.close();</script>");
            Response.End();
        }
        string patt = "^[a-zA-Z0-9]+$";
        if (!Regex.IsMatch(tableName, patt, RegexOptions.IgnoreCase))
        {
            Response.Write("<script language=javascript>alert('表名称必须由字母或数字组成');window.close();</script>");
            Response.End();
        }

        M_InfoModel infoModel = new M_InfoModel();
        infoModel.ModelName = MInfoModel.ModelName;
        infoModel.ModelDesc = MInfoModel.ModelDesc;
        infoModel.TableName = "Ky_U_" + tableName;
        infoModel.UploadPath = MInfoModel.UploadPath;
        infoModel.UploadSize = MInfoModel.UploadSize;
        infoModel.ModelHtml = MInfoModel.ModelHtml;

        bool isValidate = BInfoModel.CheckTableValidate(infoModel.TableName);
        if (!isValidate)
        {
            Response.Write("<script language=javascript>alert('所设置的表名已经存在');window.close();</script>");
            Response.End();
        }
        int NewModelId = BInfoModel.Add(infoModel);

        string FieldType = "nvarchar";
        string DefaultValue = "";
        DataTable dt = BModelField.GetList(ModelId);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["Type"].ToString())
                {
                    case "TextType":
                        FieldType = "nvarchar";
                        break;
                    case "MultipleTextType":
                        FieldType = "ntext";
                        break;
                    case "MultipleHtmlType":
                        FieldType = "ntext";
                        break;
                    case "RadioType":
                        FieldType = "nvarchar";
                        DefaultValue = BModelField.GetFieldContent(dt.Rows[i]["Content"].ToString(), 2, 1).ToString();
                        break;
                    case "ListBoxType":
                        FieldType = "nvarchar";
                        break;
                    case "NumberType":
                        FieldType = "nvarchar";
                        break;
                    default:
                        break;
                }

                MModelField.ModelId = NewModelId;
                MModelField.Name = dt.Rows[i]["Name"].ToString();
                MModelField.Alias = dt.Rows[i]["Alias"].ToString();
                //MModelField.Tips = MyTips;
                MModelField.Description = dt.Rows[i]["Description"].ToString();
                MModelField.IsNotNull = bool.Parse(dt.Rows[i]["IsNotNull"].ToString());
                MModelField.IsSearchForm = bool.Parse(dt.Rows[i]["IsSearchForm"].ToString());
                MModelField.Type = dt.Rows[i]["Type"].ToString();
                MModelField.Content = dt.Rows[i]["Content"].ToString();
                MModelField.AddDate = DateTime.Now;

                if (BModelField.IsNotField(infoModel.TableName, dt.Rows[i]["Name"].ToString()))
                {
                    BModelField.Add(MModelField);   //记录字段表
                    BModelField.AddField(infoModel.TableName, dt.Rows[i]["Name"].ToString(), FieldType, DefaultValue);  //增加字段
                }
                else
                {
                    Function.ShowSysMsg(0, "<li>该字段已经存在</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
            }
        }

        dt.Clear();
        dt.Dispose();

        Response.Write("<script language=javascript>alert('成功复制" + MInfoModel.ModelName + "');window.dialogArguments.location.reload();window.close();</script>");
        Response.End();
    }
}
