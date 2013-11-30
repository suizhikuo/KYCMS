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

public partial class system_infomodel_CustomFormPreView : System.Web.UI.Page
{
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    protected int CustomFormId = 0;
    protected B_CustomForm BCustomForm = new B_CustomForm();
    protected M_CustomForm MCustomForm = new M_CustomForm();
    protected B_InfoModel BInfoModel = new B_InfoModel();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(33);
        CustomFormId = int.Parse(Request.QueryString["CustomFormId"]);

        if (!Page.IsPostBack)
        {
            //绑定自定义字段
            DataTable dt1 = new DataTable();
            dt1 = BCustomFormField.GetList(CustomFormId);
            Repeater1.DataSource = dt1;
            Repeater1.DataBind();

            dt1.Clear();
            dt1.Dispose();

            MCustomForm=BCustomForm.GetModel(CustomFormId);

            FilePicPath.Text = MCustomForm.UploadPath + "|" + MCustomForm.UploadSize.ToString();
        }
    }

    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description, null);
    }
}
