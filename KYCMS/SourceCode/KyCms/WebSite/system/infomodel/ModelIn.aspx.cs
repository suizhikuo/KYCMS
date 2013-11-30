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
using System.Xml;
using Ky.Common;
using System.IO;
using System.Text;

public partial class system_infomodel_ModelIn : System.Web.UI.Page
{
    private M_InfoModel model = new M_InfoModel();
    private B_InfoModel bll = new B_InfoModel();
    string DirName = Param.SiteRootPath + @"\" + Param.ConfDirName;
    private DataTable dt = new DataTable();
    private M_ModelField modelfield = new M_ModelField();
    private B_ModelField bllfield = new B_ModelField();
    protected string filePath;

    protected void Page_Load(object sender, EventArgs e)
    {
        filePath = DirName + @"\Ky_Model.xml";

        if (!File.Exists(filePath))
        {
            Function.ShowSysMsg(0, "<li>很抱歉，你站点目录下不存在可以导入的内容模型文件</li><li>请手动拷贝内容模型文件到站点目录/conf/Ky_Model.xml</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
        }

        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            dt = ds.Tables["Table0"];
        }
        catch
        {
            Function.ShowSysMsg(0, "<li>读取内容模型文件失败</li><li>请确认需要导入的内容模型文件符合我们的规则</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
        }

        if (!Page.IsPostBack)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0, p = 1; i < dt.Rows.Count; i++, p++)
                {
                    MyModel.Items.Add(new ListItem(dt.Rows[i]["ModelName"].ToString(), dt.Rows[i]["ModelId"].ToString()));
                }
            }
            else
            {
                MyModel.Items.Add(new ListItem("无任何内容模型", "0"));
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder sbTable = new StringBuilder();

        if (MyModel.Items.Count > 0)
        {
            int ModelId;

            for (int i = 0; i < MyModel.Items.Count; i++)
            {
                if (MyModel.Items[i].Selected == true)
                {
                    if (MyModel.Items[i].Value == "0")
                    {
                        Function.ShowSysMsg(0, "<li>请选择一个有内容模型</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
                    }
                    else
                    {
                        ModelId = int.Parse(MyModel.Items[i].Value);
                        DataRow[] drNew = dt.Select("ModelId='" + ModelId + "'");

                        model.ModelId = 0;
                        model.ModelName = drNew[0]["ModelName"].ToString();
                        model.ModelDesc = drNew[0]["ModelDesc"].ToString();
                        model.TableName = drNew[0]["TableName"].ToString();
                        model.UploadPath = drNew[0]["UploadPath"].ToString();
                        model.UploadSize = int.Parse(drNew[0]["UploadSize"].ToString());
                        model.ModelHtml = drNew[0]["ModelHtml"].ToString();
                        model.IsHtml = bool.Parse(drNew[0]["IsHtml"].ToString());
                        //model.ModelSort = int.Parse(drNew[0]["ModelSort"].ToString());

                        bool isValidate = bll.CheckTableValidate(drNew[0]["TableName"].ToString());

                        if (!isValidate)
                        {
                            sbTable.Append("<li><font color=red>" + drNew[0]["TableName"].ToString() + "表名已经存在，导入失败</font></li>");
                        }
                        else
                        {
                            sbTable.Append("<li>" + drNew[0]["TableName"].ToString() + "表成功导入</li>");
                            int MyModelId = bll.Add(model);

                            DataSet ds = new DataSet();
                            ds.ReadXml(filePath);

                            DataRow[] dr = ds.Tables["Table1"].Select("ModelId='" + ModelId + "'", "OrderId");

                            int intRow = dr.Length;
                            string FieldType = "nvarchar";
                            string DefaultValue = "";

                            for (int ii = 0; ii < intRow; ii++)
                            {
                                switch (dr[ii]["Type"].ToString())
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
                                        DefaultValue = bllfield.GetFieldContent(dr[ii]["Content"].ToString(), 2, 1).ToString();
                                        break;
                                    case "ListBoxType":
                                        FieldType = "ntext";
                                        break;
                                    case "NumberType":
                                        FieldType = "int";
                                        break;
                                    case "ErLinkageType":
                                        FieldType = "nvarchar";
                                        bllfield.AddField(drNew[0]["TableName"].ToString(), dr[ii]["Name"].ToString() + "_Id", "int", "");  //增加字段
                                        bllfield.AddField(drNew[0]["TableName"].ToString(), bllfield.GetFieldContent(dr[ii]["Content"].ToString(), 2, 1).ToString(), "nvarchar", "");  //增加字段
                                        bllfield.AddField(drNew[0]["TableName"].ToString(), bllfield.GetFieldContent(dr[ii]["Content"].ToString(), 2, 1).ToString() + "_Id", "int", "");  //增加字段
                                        break;
                                    default:
                                        FieldType = "nvarchar";
                                        break;
                                }

                                modelfield.ModelId = MyModelId;
                                modelfield.Name = dr[ii]["Name"].ToString();
                                modelfield.Alias = dr[ii]["Alias"].ToString();
                                modelfield.Description = dr[ii]["Description"].ToString();
                                modelfield.IsNotNull = bool.Parse(dr[ii]["IsNotNull"].ToString());
                                modelfield.IsSearchForm = bool.Parse(dr[ii]["IsSearchForm"].ToString());
                                modelfield.Type = dr[ii]["Type"].ToString();
                                modelfield.Content = dr[ii]["Content"].ToString();
                                modelfield.AddDate = DateTime.Now;

                                if (bllfield.IsNotField(drNew[0]["TableName"].ToString(), dr[ii]["Name"].ToString()))
                                {
                                    bllfield.Add(modelfield);   //记录字段表
                                    bllfield.AddField(drNew[0]["TableName"].ToString(), dr[ii]["Name"].ToString(), FieldType, DefaultValue);  //增加字段
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>请选择一个有效内容模型</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
        }

        dt.Clear();
        dt.Dispose();

        Function.ShowSysMsg(1, "" + sbTable.ToString() + "<li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
    }
}
