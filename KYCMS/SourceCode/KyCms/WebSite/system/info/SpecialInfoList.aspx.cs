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
using System.Text;

public partial class System_Info_SpeacilInfoList : System.Web.UI.Page
{
    B_Special SpeacilBll = new B_Special();
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_InfoOper InfoOperBll = new B_InfoOper();

    M_Special SpeacilModel = null;
    int SId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["SId"]))
        {
            try
            {
                SId = int.Parse(Request.QueryString["SId"]);
            }
            catch { }
        }
        SpeacilModel = SpeacilBll.GetSpecial(SId);
        if (SId <= 0 || SpeacilModel == null)
        {
            Response.Write("<script type='text/javascript'>alert('所选专题不存在或已经被删除');history.back();</script>");
            Response.End();
            return;
        }
        litSpeacilName.Text = SpeacilModel.SpecialCName+"的内容列表";
        if (!IsPostBack)
        {
            SetDataSource();
            Bind();
        }
    }

    private void SetDataSource()
    {
        DataTable modelDt = InfoModelBll.GetList();
        ViewState["ModelDt"] = modelDt;
        modelDt.Dispose();
        string tableNameStr = string.Empty;
        foreach (DataRow dr in modelDt.Rows)
        {
            tableNameStr += "[" + dr["TableName"] + "],";
        }
        if (tableNameStr == string.Empty)
            return;
        if (tableNameStr.Length > 0 && tableNameStr.EndsWith(","))
        {
            tableNameStr = tableNameStr.Substring(0, tableNameStr.Length - 1);
        }
        DataTable specialDt = InfoOperBll.GetSpecialInfoList(tableNameStr, SId);
        ViewState["SpecialDt"] = specialDt;
        specialDt.Dispose();
    }

    private void Bind()
    {
        DataTable specialDt = (DataTable)ViewState["SpecialDt"];
        DataTable bindDt = specialDt.Clone();
        bindDt.Rows.Clear();
        int pageIndex = Pager.CurrentPageIndex;
        int pageSize = Pager.PageSize;
        int startIndex = (pageIndex-1)*pageSize;
        int endIndex = pageIndex * pageSize;
        for (int i = startIndex; i <= endIndex && i < specialDt.Rows.Count; i++)
        {
            DataRow dr = bindDt.NewRow();
            dr["modelid"] = specialDt.Rows[i]["modelid"];
            dr["modelname"] = specialDt.Rows[i]["modelname"];
            dr["id"] = specialDt.Rows[i]["id"];
            dr["Title"] = specialDt.Rows[i]["Title"];
            dr["titletype"] = specialDt.Rows[i]["titletype"];
            dr["colid"] = specialDt.Rows[i]["colid"];
            dr["uname"] = specialDt.Rows[i]["uname"];
            dr["usertype"] = specialDt.Rows[i]["usertype"];
            dr["hitcount"] = specialDt.Rows[i]["hitcount"];
            dr["issideshow"] = specialDt.Rows[i]["issideshow"];
            dr["istop"] = specialDt.Rows[i]["istop"];
            dr["isrecommend"] = specialDt.Rows[i]["isrecommend"];
            dr["isfocus"] = specialDt.Rows[i]["isfocus"];
            dr["status"] = specialDt.Rows[i]["status"];

            bindDt.Rows.Add(dr);
        }
        RepSpecial.DataSource = bindDt;
        RepSpecial.DataBind();
        specialDt.Dispose();
        bindDt.Dispose();
        Pager.RecordCount = specialDt.Rows.Count;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }
    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        Bind();
    }

    protected string GetPropertyName(object titleType, object IsTop, object IsRecommend, object IsFocus, object IsSideShow)
    {
        StringBuilder _returnDisplay = new StringBuilder();
        /*判断每个属性*/
        if ((int)(titleType)==2)
            _returnDisplay.Append("<font color=red>图</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToBoolean(IsTop))
            _returnDisplay.Append("<font color=red>顶</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToBoolean(IsRecommend))
            _returnDisplay.Append("<font color=blue>荐</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToBoolean(IsFocus))
            _returnDisplay.Append("<font color=gray>焦</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToBoolean(IsSideShow))
            _returnDisplay.Append("<font color=blue>幻</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;");
        /*返回显示*/
        return _returnDisplay.ToString();
    }

    protected string GetStatusName(object status)
    {
        if(status!=null&&status.ToString()!="")
        {
            int tmpStatus = Convert.ToInt32(status);
            switch(tmpStatus)
            {
                case -2:return "未被采纳";
                case -1:return "草稿";
                case 0:return "待审";
                case 1:return "初审通过";
                case 2:return "二审通过";
                case 3:return "终审通过";
                default: return "";
            }
        }
        else
        {
            return "";
        }
    }
}
