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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;

public partial class system_PreInfo : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    B_Column ColumnBll = new B_Column();
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_Create CreateBll = new B_Create();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    int Id = 0;
    int P = 1;
    int ModelId = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

        AdminBll.CheckMulitLogin();
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
                ModelId = int.Parse(Request.QueryString["ModelId"].ToString());
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                P = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
        M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);
        if (infoModel == null)
        {
            Function.ShowSysMsg(0,"<li>所属模型不存在或已经被删除</li>");
            return;
        }
        string tableName = infoModel.TableName;
        if (tableName.Length == 0)
        {
            Function.ShowSysMsg(0, "<li>所属模型不存在或已经被删除</li>");
            return;
        }

        DataRow dr = CreateBll.GetInfoById(tableName,Id);
        if (dr == null)
        {
            Function.ShowSysMsg(0, "<li>所预览的内容不存在或已经被删除</li>");
            return;
        }
        int chid = (int)dr["chid"];
        int colid = (int)dr["colid"];
    
        AdminGroupBll.Power_Judge(chid, colid, 1, "<li>对不起，你没有查看该内容的权限</li>");
        int pageSize = 0;
        if (ModelId == 1 && (dr["outerurl"].ToString()).Length != 0)
        {
            Response.Redirect(dr["outerurl"].ToString());
            return;
        }
        pageSize = CreateBll.TotalContentPageNumber(dr);
        Response.Write(CreateBll.GetInfo(dr, P,  pageSize));
    }
}
