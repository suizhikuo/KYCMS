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

public partial class user_info_ShowInfoCustomForm : System.Web.UI.Page
{
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    protected int CustomFormId = 0;
    protected B_CustomForm BCustomForm = new B_CustomForm();
    protected M_CustomForm MCustomForm = new M_CustomForm();
    protected B_InfoModel BInfoModel = new B_InfoModel();
    protected int Id = 0;
    private DataRow dr;
    private B_InfoOper BInfoOper = new B_InfoOper();
    private DataTable dtInfo;
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

        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }

        MCustomForm = BCustomForm.GetModel(CustomFormId);

        dtInfo = BCustomFormField.GetList(CustomFormId);

        dr = BInfoOper.GetInfo(MCustomForm.TableName, Id);

        if (!Page.IsPostBack)
        {
            CustomFormName.Text = MCustomForm.FormName;

            //绑定自定义字段
            Repeater1.DataSource = dtInfo;
            Repeater1.DataBind();

            dtInfo.Clear();
            dtInfo.Dispose();

            MCustomForm=BCustomForm.GetModel(CustomFormId);

            FilePicPath.Text = MCustomForm.UploadPath;
        }
    }

    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description, dr);
    }
}
