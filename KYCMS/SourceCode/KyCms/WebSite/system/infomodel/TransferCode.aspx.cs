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
using Ky.Common;
using Ky.Model;
using Ky.BLL;

public partial class system_infomodel_TransferCode : System.Web.UI.Page
{
    private B_CustomForm BCustomForm = new B_CustomForm();
    private M_CustomForm MCustomForm = new M_CustomForm();
    protected int CustomFormId = 0;
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private DataTable dtIsUser;
    private B_CustomFormField BCustomFormField = new B_CustomFormField();

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

        dtIsUser = BCustomFormField.GetIsUserList(CustomFormId);
        MCustomForm = BCustomForm.GetModel(CustomFormId);

        //判断是否有字段
        if (dtIsUser.Rows.Count < 1)
        {
            Response.Write("<script>alert('该表单下还没有添加字段，不能够调用');window.close();</script>");
            Response.End();
        }


        //判断是否起用了时间限制
        if (MCustomForm.IsUnlockTime)
        {
            if (DateTime.Parse(MCustomForm.StartTime.ToShortDateString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Response.Write("<script>alert('" + MCustomForm.FormName + "启用了时间限制，还不能使用" + MCustomForm.FormName + "');window.close();</script>");
                Response.End();
            }

            if (DateTime.Parse(MCustomForm.EndTime.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Response.Write("<script>alert('" + MCustomForm.FormName + "启用了时间限制，目前已经过期');window.close();</script>");
                Response.End();
            }
        }

        dtIsUser.Clear();
        dtIsUser.Dispose();

        if (!Page.IsPostBack)
        {
            FormName.Text = MCustomForm.FormName;
            TextBox1.Text = "<script language=\"javascript\" src=\"" + Param.ApplicationRootPath + "/other/CustomForm.aspx?CustomFormId=" + CustomFormId + "\" type=\"text/javascript\"></script>";
        }
    }
}
