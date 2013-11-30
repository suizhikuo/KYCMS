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
using System.Text;
using Ky.Model;
using Ky.Common;

public partial class system_infomodel_ModeldFieldHtml : System.Web.UI.Page
{
    private B_ModelField BModelField = new B_ModelField();
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    protected int ModelId;
    private M_InfoModel MInfoModel = new M_InfoModel();
    private B_InfoModel BInfoModel = new B_InfoModel();

    protected void Page_Load(object sender, EventArgs e)
    {
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
            MInfoModel = BInfoModel.GetModel(ModelId);
            txtModelHtml.Text = MInfoModel.ModelHtml;

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

                SysModelHtml.Text = sb.ToString();
            }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        MInfoModel.ModelId = ModelId;
        MInfoModel.ModelHtml = txtModelHtml.Text;

        BInfoModel.UpdateModelHtml(MInfoModel);

        Function.ShowSysMsg(1, "<li>成功添加自定义样式</li><li><a href='infomodel/FieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='infomodel/ModelList.aspx'>返回模型管理</a></li>");
    }
}
