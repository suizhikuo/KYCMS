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
using Ky.BLL;

public partial class system_UserGroupModel_ModeldFieldHtml : System.Web.UI.Page
{
    private B_ModelField BModelField = new B_ModelField();
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    protected int ModelId;
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    private B_UserGroupModelField BUserGroupModelField = new B_UserGroupModelField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

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

        if (!Page.IsPostBack)
        {
            MUserGroupModel = BUserGroupModel.GetModel(ModelId);
            txtModelHtml.Text = MUserGroupModel.ModelHtml;

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
        MUserGroupModel.Id = ModelId;
        MUserGroupModel.ModelHtml = txtModelHtml.Text;

        BUserGroupModel.UpdateModelHtml(MUserGroupModel);

        Function.ShowSysMsg(1, "<li>成功添加用户注册模型自定义样式</li><li><a href='UserGroupModel/UserGroupModelFieldList.aspx?ModelId=" + ModelId + "'>返回字段列表</a> <a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理</a></li>");
    }
}
