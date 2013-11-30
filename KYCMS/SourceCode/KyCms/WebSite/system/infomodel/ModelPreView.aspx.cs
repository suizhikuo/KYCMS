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
using Ky.BLL;
using Ky.Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class system_infomodel_ModelPreView : System.Web.UI.Page
{
    protected int ModelId = 0;
    B_Channel ChannelBll = new B_Channel();
    protected B_Column ColumnBll = new B_Column();
    B_Admin AdminBll = new B_Admin();
    M_LoginAdmin AdminModel = null;
    protected M_Channel ChannelModel = null;
    protected M_Column ColumnModel = null;
    protected M_Site SiteModel = new M_Site();
    protected B_SiteInfo SiteBll = new B_SiteInfo();
    B_Create CreateBll = new B_Create();
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected M_Admin AdminUserModel = null;
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_InfoModel BInfoModel = new B_InfoModel();
    private M_InfoModel MInfoModel = new M_InfoModel();
    protected string TableName = "";
    protected B_ModelField BModelField = new B_ModelField();
    private B_InfoModel InfoModelBll = new B_InfoModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        AdminModel = AdminBll.GetLoginModel();
        AdminUserModel = AdminBll.GetModel(AdminModel.UserId);

        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }

        M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);

        if (!Page.IsPostBack)
        {
            txtTemplatePath.Attributes.Add("readonly", "");


            litNav.Text = "<a href=\"ModelList.aspx\">模型列表<a> >> <a href=\"FieldList.aspx?ModelId=" + ModelId + "\">字段列表</a> >> " + infoModel.ModelName + "预览";

            //绑定自定义字段
            ModelHtml.Text = infoModel.ModelHtml;
            //DataTable dt1 = new DataTable();
            //dt1 = BModelField.GetList(ModelId);
            //Repeater1.DataSource = dt1;
            //Repeater1.DataBind();

            //dt1.Clear();
            //dt1.Dispose();

            FilePicPath.Text = MInfoModel.UploadPath;

            TableName = MInfoModel.TableName;

            //BindSpeacil();
            BindGroup();
        }
    }

    #region 绑定用户组
    private void BindGroup()
    {
        B_UserGroup groupBll = new B_UserGroup();
        DataTable dt = groupBll.ManageList("");
        chkBoxGroupIdStr.DataTextField = "UserGroupName";
        chkBoxGroupIdStr.DataValueField = "UserGroupId";
        chkBoxGroupIdStr.DataSource = dt;
        chkBoxGroupIdStr.DataBind();

        dt.Clear();
        dt.Dispose();
    }
    #endregion

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
