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
using Ky.Model;
using Ky.Common;
using Ky.BLL.CommonModel;


public partial class system_info_RecycleInfo : System.Web.UI.Page
{
    
    int modelId = 0;
    string tableName = "";

    B_InfoOper Bll=new B_InfoOper();
    B_InfoModel infoModelBll=new B_InfoModel();
    B_Column columnBll = new B_Column();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(37);
        LitRecycleNav.Text = Bll.BuildLinkString();
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            modelId = Function.CheckNumber(Request.QueryString["ModelId"]) ? int.Parse(Request.QueryString["ModelId"]) : 0;
        }

        M_InfoModel infoModel = infoModelBll.GetModel(modelId);
        if (infoModel == null)
        {
            Function.ShowSysMsg(0, "<li>此模型不存在</li><li><a href='javascript:window.history.back(-1);'>返回上一步</a></li>");
        }

        LitModelName.Text = infoModel.ModelName;
        tableName = infoModel.TableName;

        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        int total = 0;       
        DataTable data = Bll.GetRecycleInfoList(tableName,4,Pager.CurrentPageIndex, Pager.PageSize, ref total);
        if (data != null)
        {
            rptRecycle.DataSource = data;
            rptRecycle.DataBind();
            Pager.RecordCount = total;
            Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        }        
    }

    protected void rptRecycleItemCommand(object sender,RepeaterCommandEventArgs e)
    {
        string[] args = e.CommandArgument.ToString().Split('|');
        int Id = int.Parse(args[0]);
        int ColId = int.Parse(args[1]);
        if (e.CommandName == "Restore")
        {
            M_Column colModel = columnBll.GetColumn(ColId);
            if (colModel == null || colModel.IsDeleted)
            {
                Function.ShowSysMsg(0, "<li>此项所属栏目尚未还原,请先还原该栏目(ID=" + ColId + ").</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            Bll.RestoreRecycle(tableName, 4, Id);  
            BindData();
        }
        if (e.CommandName == "Delete")
        {
            Bll.CompleteDeleteInfo(tableName, Id);
            BindData();
        }        
    }


    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    //批量删除
    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptRecycle.Items.Count; i++)
        {
            CheckBox chkBox = rptRecycle.Items[i].FindControl("chkBox") as CheckBox;
            if (chkBox.Checked)
            {
                Literal litId = rptRecycle.Items[i].FindControl("LitId") as Literal;
                Bll.CompleteDeleteInfo(tableName, int.Parse(litId.Text));
            }
        }
        BindData();
    }
}
