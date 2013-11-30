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
using Ky.Common;
using Ky.Model;

public partial class System_Delete_ColumNavigati : System.Web.UI.Page
{

    B_Channel ChannelBll = new B_Channel();
    B_Column ColumnBll = new B_Column();
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    public int ChId = 0;
    public int ModleType = 0;
    protected M_Channel ChannelModel = null;
    protected string Url = string.Empty;


    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        if (Request.QueryString["ChId"] != null && Request.QueryString["ChId"] != "")
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        ChannelModel = ChannelBll.GetChannel(ChId);
        if (ChId <= 0 || ChannelModel == null)
        {
            Response.Write("<script type='text/javascript'>alert('频道参数错误');history.back();</script>");
            Response.End();
            return;
        }
        litNav.Text = ChannelModel.ChName;
        hyperInfo.Text = "添加" + ChannelModel.TypeName;
        switch (ChannelModel.ModelType)
        {
            default:
                hyperInfo.NavigateUrl = "AddInfo.aspx?ChId=" + ChId;
                Url = "AddInfo.aspx";
                break;
            case 1:
                hyperInfo.NavigateUrl = "SetArticle.aspx?ChId=" + ChId;
                Url = "SetArticle.aspx";
                break;
            case 2:
                hyperInfo.NavigateUrl = "SetImage.aspx?ChId=" + ChId;
                Url = "SetImage.aspx";
                break;
            case 3:
                hyperInfo.NavigateUrl = "SetDownLoad.aspx?ChId="+ChId;
                Url = "SetDownLoad.aspx";
                break;
        }
        if (!IsPostBack)
        {
            BindColumn();
            BindChildColumn();
        }
    }
    #endregion


    #region 父栏目repeaterItemCommand事件，进行修改，添加，删除操作
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ItemIndex = e.Item.ItemIndex;
        Label lb = (Label)repColumn.Items[ItemIndex].FindControl("lblColParentId");
        Label lbColumnId = (Label)repColumn.Items[ItemIndex].FindControl("lblColID");
        int colId = int.Parse(lbColumnId.Text);
        if (e.CommandName == "DeleteOne")
        {
            AdminGroupBll.Power_Judge(36);
            string IdStr = ColumnBll.GetChildIdByColumnId(colId);
            ColumnBll.Delete(colId,ChId, IdStr);
            Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();location.href('ColumnList.aspx?ChId=" + ChId + "');</script>");

        }

        if (e.CommandName == "emblme")
        {
            LinkButton lkb = (LinkButton)repColumn.Items[ItemIndex].FindControl("linkbtnChar");
            Repeater dl2 = (Repeater)repColumn.Items[ItemIndex].FindControl("repChildColumn");
            if (lkb.Text == "+")
            {

                dl2.Visible = true;
                lkb.Text = "-";
            }
            else
            {
                if (lkb.Text == "-")
                {
                    dl2.Visible = false;
                    lkb.Text = "+";
                }
            }
        }
    }
    #endregion

    #region 子栏目repeaterItemCommand事件，进行修改，添加，删除操作
    protected void repChidColumn_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lbColId = (Label)e.Item.FindControl("lblColIDZi");
        int colId = int.Parse(lbColId.Text);
        if (e.CommandName == "DeleteTwo")
        {
            AdminGroupBll.Power_Judge(36);
            string IdStr = ColumnBll.GetChildIdByColumnId(colId);
            ColumnBll.Delete(colId,ChId, IdStr);
            Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();location.href('ColumnList.aspx?ChId=" + ChId + "');</script>");
        }
    }
    #endregion

    #region 替换栏目状态
    public string GetIsOpened(object isOpened)
    {
        if (isOpened != null && isOpened.ToString() != string.Empty)
        {
            bool flag = (bool)isOpened;
            return flag ? "开放" : "认证";
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region 绑定一级栏目
    public void BindColumn()
    {
        repColumn.DataSource = ColumnBll.GetFirstColumnByChannelId(ChId);
        repColumn.DataBind();
    }
    #endregion

    #region 绑定二级栏目
    public void BindChildColumn()
    {
        for (int i = 0; i < repColumn.Items.Count; i++)
        {
            DataTable dt1 = new DataTable();

            dt1.Columns.Add("ColId", typeof(string));
            dt1.Columns.Add("ColName", typeof(string));
            dt1.Columns.Add("Description", typeof(string));
            dt1.Columns.Add("ColParentId", typeof(string));
            dt1.Columns.Add("IsOpened", typeof(bool));
            dt1.Columns.Add("Sort", typeof(int));
            Label lbColumnId = (Label)repColumn.Items[i].FindControl("lblColID");
            Repeater repChildColumn = (Repeater)repColumn.Items[i].FindControl("repChildColumn");
            LinkButton lnkBtn = (LinkButton)repColumn.Items[i].FindControl("linkbtnChar");
            DataTable dt2 = ClassFication(lbColumnId.Text, ".", dt1);
            repChildColumn.DataSource = dt2.DefaultView;
            repChildColumn.DataBind();
            lnkBtn.Text = dt2.Rows.Count > 0 ? "-" : "&nbsp;";
        }
    }
    #endregion

    #region 分类方法
    /// <summary>
    /// 分类代码
    /// </summary>
    /// <param name="colid">栏目ID</param>
    /// <param name="emblem">标示符</param>
    /// <param name="dt">数据表</param>     
    public DataTable ClassFication(string colid, string emblem, DataTable dt)
    {
        DataView dv = ColumnBll.GetChildColumn(Int32.Parse(colid));//查询所有指定父类的子类

        for (int i = 0; i < dv.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr["ColId"] = dv[i]["ColId"].ToString();
            dr["ColName"] = emblem + "├┈ " + dv[i]["ColName"];
            dr["Description"] = dv[i]["Description"];
            dr["IsOpened"] = dv[i]["IsOpened"];
            dr["Sort"] = dv[i]["Sort"];
            dt.Rows.Add(dr);
            if (ColumnBll.GetChildColumn(Int32.Parse(dv[i]["ColId"].ToString())).Count > 0)
            {
                string emblemTwo = emblem;
                emblemTwo += "..";
                dt = ClassFication(dv[i]["ColId"].ToString(), emblemTwo, dt);
            }
        }
        return dt;
    }
    #endregion

}
