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

public partial class system_UserGroupModel_UserGroupModelFieldList : System.Web.UI.Page
{
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    protected int ModelId = 0;
    private B_ModelField BModelField = new B_ModelField();

    private B_UserGroupModelField BUserGroupModelField = new B_UserGroupModelField();
    private M_UserGroupModelField MUserGroupModelField = new M_UserGroupModelField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();

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

            if (ModelId != 0)
            {
                if (MUserGroupModel == null)
                {
                    Function.ShowSysMsg(0, "<li>用户注册模型不存在或已经被删除</li><li><a href='UserGroupModel/UserGroupModelList.aspx'>返回用户注册模型管理列表</a></li>");
                }
            }

            ModelName.Text = MUserGroupModel.Name;

            RepSystemModel.DataSource = BUserGroupModel.GetSysteFieldList();
            RepSystemModel.DataBind();
            DataList();
        }
    }

    private void DataList()
    {
        RepUserGroupModelField.DataSource = BUserGroupModelField.GetList(ModelId);
        RepUserGroupModelField.DataBind();
    }

    protected void RepUserGroupModelField_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());
            MUserGroupModelField = BUserGroupModelField.GetModel(FieldId);
            MUserGroupModel = BUserGroupModel.GetModel(ModelId);

            if (MUserGroupModelField.Type == "ErLinkageType")
            {
                BModelField.DelField(MUserGroupModel.TableName, BModelField.GetFieldContent(MUserGroupModelField.Content, 2, 1));
                BModelField.DelField(MUserGroupModel.TableName, BModelField.GetFieldContent(MUserGroupModelField.Content, 2, 1) + "_Id");
                BModelField.DelField(MUserGroupModel.TableName, MUserGroupModelField.Name + "_Id");
            }


            BUserGroupModelField.Del(FieldId);
            BModelField.DelField(MUserGroupModel.TableName, MUserGroupModelField.Name);

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
            }

            DataList();
        }

        if (e.CommandName == "UpMove")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());

            BUserGroupModelField.MoveField(ModelId, FieldId, "UpMove");

            DataList();
        }

        if (e.CommandName == "DownMove")
        {
            int FieldId = int.Parse(e.CommandArgument.ToString());

            BUserGroupModelField.MoveField(ModelId, FieldId, "DownMove");

            DataList();
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
