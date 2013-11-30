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

public partial class system_infomodel_UpdateInfoCustomForm : System.Web.UI.Page
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        //验证
        GetIsOk();

        MCustomForm = BCustomForm.GetModel(CustomFormId);
        string TableName = MCustomForm.TableName;

        //定义DataTable
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
        dt.Columns.Add(new DataColumn("FieldValue", typeof(string)));

        #region 系统默认字段
        DataRow dr0 = dt.NewRow();
        dr0[0] = "Id";
        dr0[1] = Id;
        dt.Rows.Add(dr0);

        DataRow dr1 = dt.NewRow();
        dr1[0] = "UId";
        dr1[1] = "0";
        dt.Rows.Add(dr1);

        DataRow dr2 = dt.NewRow();
        dr2[0] = "UName";
        dr2[1] = "匿名用户";
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3[0] = "Ip";
        dr3[1] = Request.ServerVariables["REMOTE_ADDR"];
        dt.Rows.Add(dr3);

        DataRow dr4 = dt.NewRow();
        dr4[0] = "AddTime";
        dr4[1] = DateTime.Now.ToString();
        dt.Rows.Add(dr4);

        #endregion

        //以下是自动添加字段获得值
        for (int i = 0; i < dtInfo.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = dtInfo.Rows[i]["Name"].ToString();

            switch (dtInfo.Rows[i]["Type"].ToString())
            {
                case "ListBoxType":
                    if (Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""] == "" || Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""] == null)
                    {
                        dr[1] = Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""];
                    }
                    else
                    {
                        dr[1] = Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""].Replace(" ", "").ToString();
                    }
                    break;
                case "MultipleTextType":
                    dr[1] = Function.Encode(Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""]);
                    break;
                default:
                    dr[1] = Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString() + ""];
                    break;
            }
            dt.Rows.Add(dr);
        }

        //添加信息
        BInfoModel.UpdateInfoModel(dt, TableName);
        dtInfo.Clear();
        dtInfo.Dispose();
        Function.ShowSysMsg(1, "<li>成功修改！</li><li><a href='infomodel/UpdateInfoCustomForm.aspx?CustomFormId=" + CustomFormId + "&Id=" + Id + "'>重新修改</a> <a href='infomodel/CustomFormInfoList.aspx?CustomFormId=" + CustomFormId + "'>返回" + MCustomForm.FormName + "列表</a></li>");


    }

    private void GetIsOk()
    {
        //验证自定义字段
        if (dtInfo.Rows.Count > 0)
        {
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                if (dtInfo.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString()] == "" || Request.Form["txt_" + dtInfo.Rows[i]["Name"].ToString()] == null)
                    {
                        Function.ShowSysMsg(0, "<li>" + dtInfo.Rows[i]["Alias"].ToString() + "不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='infomodel/CustomFormInfoList.aspx?CustomFormId=" + CustomFormId + "'>返回" + MCustomForm.FormName + "列表</a></li>");
                    }
                }
            }
        }
    }
}
