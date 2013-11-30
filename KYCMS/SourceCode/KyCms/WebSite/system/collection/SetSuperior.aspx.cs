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
using Ky.BLL;
using Ky.Common;

public partial class system_collection_SuperiorSet : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_Superior SuperiorBll = new B_Superior();
    private M_Superior SuperiorM = new M_Superior();
    private B_KyCommon CommonBll = new B_KyCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"].Length != 0)
            {
                int id = int.Parse(Request.QueryString["id"]);
                SuperiorM = SuperiorBll.GetIdBySuperior(id);
                txtSuperiorName.Text = SuperiorM.Name;
                txtStartCode.Text = SuperiorM.StartCode;
                txtEndCode.Text = SuperiorM.EndCode;
                btnAdd.Text = "修改";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SuperiorM.Name = txtSuperiorName.Text;
        SuperiorM.StartCode = txtStartCode.Text;
        SuperiorM.EndCode = txtEndCode.Text;

        if (btnAdd.Text != "修改")
        {
            if (CommonBll.CheckHas(SuperiorM.Name, "Name", "KySuperior"))
            {
                Function.ShowSysMsg(0, "<li>此高级过滤规则已存在</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
                return;
            }
            SuperiorBll.Add(SuperiorM);
        }
        else
        {
            int id = int.Parse(Request.QueryString["id"]);
            SuperiorM.id = id;
            SuperiorBll.Update(SuperiorM);
        }
        Response.Redirect("SuperiorManger.aspx");

    }
}
