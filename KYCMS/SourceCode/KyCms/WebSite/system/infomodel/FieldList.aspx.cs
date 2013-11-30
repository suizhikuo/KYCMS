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

public partial class system_infomodel_FieldList : System.Web.UI.Page
{
    private B_ModelField BModelField = new B_ModelField();
    protected int ModelId = 0;
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private M_ModelField MModelField = new M_ModelField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();

    private M_InfoModel MInfoModel = new M_InfoModel();
    private B_InfoModel BInfoModel = new B_InfoModel();

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
        }

        if (!Page.IsPostBack)
        {
            M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);

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

            RepSystemModel.DataSource = BModelField.GetSysteFieldList();
            RepSystemModel.DataBind();

            DataList();


        }
    }

    private void DataList()
    {
        RepModelField.DataSource = BModelField.GetList(ModelId);
        RepModelField.DataBind();
    }

    protected void RepModelField_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);
        if (e.CommandName == "Delete")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());
            MModelField = BModelField.GetModel(FieldId);

            

            if (MModelField.Type == "ErLinkageType")
            {
                BModelField.DelField(infoModel.TableName, BModelField.GetFieldContent(MModelField.Content, 2, 1));
                BModelField.DelField(infoModel.TableName, BModelField.GetFieldContent(MModelField.Content, 2, 1) + "_Id");
                BModelField.DelField(infoModel.TableName, MModelField.Name+"_Id");
            }

            //if (MModelField.Type == "SanLinkageType")
            //{
            //    BModelField.DelField(infoModel.TableName, BModelField.GetFieldContent(MModelField.Content, 2, 1));
            //    BModelField.DelField(infoModel.TableName, BModelField.GetFieldContent(MModelField.Content, 4, 1));
            //}
            BModelField.Del(FieldId);
            BModelField.DelField(infoModel.TableName, MModelField.Name);
        }

        if (e.CommandName == "UpMove")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());

            BModelField.MoveField(ModelId, FieldId, "UpMove");
        }

        if (e.CommandName == "DownMove")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());

            BModelField.MoveField(ModelId, FieldId, "DownMove");
        }

        #region 自动生成
        if (!infoModel.IsHtml)
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
        }
        DataList();
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
