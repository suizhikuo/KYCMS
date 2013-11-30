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
using Ky.BLL;

public partial class system_infomodel_CustomFormList : System.Web.UI.Page
{
    private B_CustomForm BCustomForm = new B_CustomForm();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(33);

        if (!Page.IsPostBack)
        {
            GetAll();
        }
    }

    private void GetAll()
    { 
       DataTable dt = new DataTable();
       dt=BCustomForm.GetAll();
       RepCustomForm.DataSource = dt;
       RepCustomForm.DataBind();
       dt.Clear();
       dt.Dispose();
    }

    protected void repCustomForm_Delete(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int Id = Convert.ToInt32(e.CommandArgument);

            //判断该表单下是否存在自定义字段
            DataTable dt=BCustomFormField.GetList(Id);
            if (dt.Rows.Count > 0)
            {
                Function.ShowSysMsg(0, "<li>该表单下还存在自定义字段，不能够删除!</li><li><a href='infomodel/CustomFormList.aspx'>返回表单管理列表</a></li>");
            }
            else
            {
                BCustomForm.Delete(Id);
            }

            dt.Clear();
            dt.Dispose();

            GetAll();
        }
    }
}
