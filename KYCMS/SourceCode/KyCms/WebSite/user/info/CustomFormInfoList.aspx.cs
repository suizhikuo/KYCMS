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
using System.Text;
using Ky.BLL;
using Ky.BLL.CommonModel;
using Ky.Common;
using Ky.Model;

public partial class user_info_CustomFormInfoList : System.Web.UI.Page
{
    private B_InfoOper BInfoOper = new B_InfoOper();
    protected int CustomFormId = 0;
    private M_CustomForm MCustomForm = new M_CustomForm();
    private B_CustomForm BCustomForm = new B_CustomForm();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    private M_CustomFormField MCustomFormField = new M_CustomFormField();
    private DataRow drInfo;
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_User buser = new B_User();
    private M_User muser = new M_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(33);
        muser = buser.GetCookie();

        if (!string.IsNullOrEmpty(Request.QueryString["CustomFormId"]))
        {
            try
            {
                CustomFormId = int.Parse(Request.QueryString["CustomFormId"]);
            }
            catch { }
        }

        MCustomForm = BCustomForm.GetModel(CustomFormId);

        if (MCustomForm == null)
        {
            Function.ShowMsg(0, "<li>表单不存在或已经被删除</li><li><a href='welcome.aspx'>返回表单管理列表</a></li>");
        }

        if (!Page.IsPostBack)
        {
            CustomFormName.Text = MCustomForm.FormName;
            GetAll();
        }
    }

    private void GetAll()
    {
        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }

        string strWhere = " where UId=" + muser.UserID + "";

        DataSet ds = BInfoOper.GetCustomTableList(MCustomForm.TableName, int.Parse(P), Pager.PageSize, strWhere);
        CustomTableRep.DataSource = ds.Tables[0].DefaultView;
        CustomTableRep.DataBind();

        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    protected void CustomTableRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = BCustomFormField.GetTitleList(CustomFormId);

        if (e.Item.ItemType == ListItemType.Header)
        {
            //列举出所有的字段当头部 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<td>"+dt.Rows[i]["Alias"].ToString()+"</td>");
            }
            (e.Item.FindControl("lit_head") as Literal).Text = sb.ToString();
        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
        {
            //行ID
            int Id = int.Parse((e.Item.FindControl("CustomFormFieldId") as Label).Text);
            drInfo = BInfoOper.GetInfo(MCustomForm.TableName, Id);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<td>" + Function.Encode(drInfo["" + dt.Rows[i]["Name"].ToString() + ""].ToString()) + "</td>");
            }
            (e.Item.FindControl("lit_item") as Literal).Text = sb.ToString();
        }
    }
}
