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
using Ky.Model;
using Ky.BLL.CommonModel;
using Ky.BLL;
using Ky.Common;

public partial class system_infomodel_UpdateFormField : System.Web.UI.Page
{
    private B_CustomForm BCustomForm = new B_CustomForm();
    private M_CustomForm MCustomForm = new M_CustomForm();
    protected B_InfoModel BInfoModel = new B_InfoModel();

    protected int CustomFormId = 0;
    protected int Id = 0;
    protected string FieldName = "";

    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    private M_CustomFormField MCustomFormField = new M_CustomFormField();
    private DataRow drinfo;
    private DataTable dtInfo;
    private B_InfoOper BInfoOper = new B_InfoOper();
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(33);
        Response.Cache.SetNoStore();

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

        drinfo = BInfoOper.GetInfo(MCustomForm.TableName, Id);

        FieldName = Request.QueryString["FieldName"];

        if (!Page.IsPostBack)
        {

            MCustomFormField = BCustomFormField.GetModel(CustomFormId, FieldName);
            FormName.Text = MCustomForm.FormName;

            Alias.Text = "" + MCustomFormField.Alias + "：";
            ShowStyle.Text = GetShowStyle(MCustomFormField.Name, MCustomFormField.IsNotNull.ToString(), MCustomFormField.Type, MCustomFormField.Content, MCustomFormField.Description);
        }
    }

    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description, drinfo);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //验证
        GetIsOk();

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
        dt.Columns.Add(new DataColumn("FieldValue", typeof(string)));

        DataRow dr0 = dt.NewRow();
        dr0[0] = "Id";
        dr0[1] = Id;
        dt.Rows.Add(dr0);

        DataRow dr1 = dt.NewRow();
        dr1[0] = FieldName;
        dr1[1] = Request.Form["txt_" + FieldName];
        dt.Rows.Add(dr1);

        //修改信息
        BInfoModel.UpdateInfoModel(dt, MCustomForm.TableName);

        Response.Write("<script language=javascript>alert('成功修改');window.dialogArguments.location.reload();window.close();</script>");
        Response.End();

    }

    private void GetIsOk()
    {
        dtInfo = BCustomFormField.GetList(CustomFormId);

        //验证自定义字段
        if (dtInfo.Rows.Count > 0)
        {
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (dtInfo.Rows[i]["Name"].ToString() == FieldName && dtInfo.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (Request.Form["txt_" + FieldName] == "")
                    {
                        Response.Write("<li>" + dtInfo.Rows[i]["Alias"].ToString() + "不能够为空！</li><li><input type='button' onclick='window.close()' class='btn' value='关闭本页重新修改'>");
                        Response.End();
                    }
                }
            }
        }
    }
}
