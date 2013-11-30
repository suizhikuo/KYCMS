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
using Ky.Model;
using Ky.Common;

public partial class System_InfoList : System.Web.UI.Page
{
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    B_Channel ChannelBll = new B_Channel();
    B_Column ColumnBll = new B_Column();
    B_Admin AdminBll = new B_Admin();
    B_Create CreateBll = new B_Create();
    B_Anomaly AnomalyBll = new B_Anomaly();
    M_Anomaly AnomalyModel = new M_Anomaly();

    M_Admin AdminModel = null;
    public int ChId = 0;
    public int ColumnId = 0;
    public string FieldName = "";
    public string Keyword = "";
    public string Status = "-99";
    public int UserType = -1;

    public string AuditingLevel = "0";
    protected M_Channel ChannelModel = null;
    protected M_Column ColumnModel = null;
    protected B_PowerGroup PowerGroupBll = new B_PowerGroup();
    B_SiteInfo SiteBll = new B_SiteInfo();
    M_Site SiteModel = null;

    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        M_LoginAdmin loginAdminModel = AdminBll.GetLoginModel();
        AdminModel = AdminBll.GetModel(loginAdminModel.UserId);
        SiteModel = SiteBll.GetSiteModel();

        #region 频道，模型，栏目参数检验
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        ChannelModel = ChannelBll.GetChannel(ChId);
        if (ChannelModel == null)
        {
            Function.ShowSysMsg(0, "<li>所属频道不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        InfoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
        if (InfoModel == null)
        {
            Function.ShowSysMsg(0, "<li>所属模型不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColumnId = int.Parse(Request.QueryString["ColId"]);
            }
            catch { }
        }
        ColumnModel = ColumnBll.GetColumn(ColumnId);
        if (ColumnId != 0 && ColumnModel == null)
        {
            Function.ShowSysMsg(0, "<li>所属栏目不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        #endregion

        SetNav();
        AuditingLevel = PowerGroupBll.Power_Auditing(ChId, AdminModel.GroupId);
        SetBtnStatus();

        #region 获取搜索字段
        if (!string.IsNullOrEmpty(Request.QueryString["FieldName"]))
        {
            FieldName = Request.QueryString["FieldName"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Keyword"]))
        {
            Keyword = Request.QueryString["Keyword"].Trim();
            if (!IsPostBack)
            {
                txtKeyword.Text = Keyword;
            }
        }
        #endregion

        #region 设置审核参数
        if (!string.IsNullOrEmpty(Request.QueryString["Status"]))
        {
            string status = Request.QueryString["Status"].ToLower();
            if (status == "no")
            {
                switch (AuditingLevel)
                {
                    default: Status = "-99"; break;
                    case "1": Status = "0"; break;
                    case "2": Status = "0,1"; break;
                    case "3": Status = "0,1,2"; break;
                }
            }
            else
            {
                Status = "3";
            }
        }
        #endregion

        #region 设置投稿参数
        if (!string.IsNullOrEmpty(Request.QueryString["UserType"]))
        {
            try
            {
                UserType = int.Parse(Request.QueryString["UserType"]);
            }
            catch { }
        }
        #endregion

        if (!IsPostBack)
        {
            InitProperty();
            BindColumn();
            BindChannel();
            Bind();
            ddlsortName.Items[0].Text = ChannelModel.TypeName + "标题";
            if (gvInfoList.Rows.Count > 0)
                gvInfoList.HeaderRow.Cells[1].Text = ChannelModel.TypeName + "标题";
        }

    }
    #endregion

    #region 导航设置
    private void SetNav()
    {

        hyperGetAll.NavigateUrl = "InfoList.aspx?ChId=" + ChId;
        hyperPass.NavigateUrl = "InfoList.aspx?ChId=" + ChId + "&ColId=" + ColumnId + "&Status=yes";
        hyperNoPass.NavigateUrl = "InfoList.aspx?ChId=" + ChId + "&ColId=" + ColumnId + "&Status=no";
        hyperUserType.NavigateUrl = "InfoList.aspx?ChId=" + ChId + "&ColId=" + ColumnId + "&UserType=0";
        string colUrlStr = string.Empty;
        if (ColumnId != 0)
            colUrlStr = "&ColId=" + ColumnId;
        switch (ChannelModel.ModelType)
        {
            default: hyperSetInfo.NavigateUrl = "AddInfo.aspx?ChId=" + ChId + colUrlStr; break;
            case 1: hyperSetInfo.NavigateUrl = "SetArticle.aspx?ChId=" + ChId + colUrlStr; break;
            case 2: hyperSetInfo.NavigateUrl = "SetImage.aspx?ChId=" + ChId + colUrlStr; break;
            case 3: hyperSetInfo.NavigateUrl = "SetDownLoad.aspx?ChId=" + ChId + colUrlStr; break;
        }
        litNav.Text = " <a href='ColumnList.aspx?ChId=" + ChId + "'>" + ChannelModel.ChName + "</a>";
        if (ColumnModel != null)
        {
            litNav.Text += " &gt;&gt; <a href='InfoList.aspx?ChId=" + ChId + "&ColId=" + ColumnModel.ColId + "'>" + ColumnModel.ColName
   + "</a>";
        }
        litNav.Text += " &gt;&gt " + ChannelModel.TypeName + "列表";
    }
    #endregion

    #region 设置操作按钮状态及文字
    protected void SetBtnStatus()
    {
        btnCreateSelectInfo.Text = "生成选中" + ChannelModel.TypeName;
        btnCreateColumn.Text = "生成本栏目所有" + ChannelModel.TypeName;
        if (!PowerGroupBll.Power_Column(40, AdminModel.GroupId))
        {
            dvDeleteTotal.Visible = false;
        }

        if (!PowerGroupBll.Power_Column(42, AdminModel.GroupId))
        {
            dvMassMove.Visible = false;
        }
        if (!PowerGroupBll.Power_Column(43, AdminModel.GroupId))
        {
            dvMassSet.Visible = false;
        }
        if (!PowerGroupBll.Power_Column(7, AdminModel.GroupId) || !SiteModel.IsStaticType || !ChannelModel.IsStaticType)
        {
            dvCreateSelectInfo.Visible = false;
            dvCreateColumn.Visible = false;
        }
        if (ColumnId == 0)
            dvCreateColumn.Visible = false;
        switch (AuditingLevel)
        {
            default: dvAudit.Visible = false; break;
            case "1": btnAudit.Text = "初审通过"; break;
            case "2": btnAudit.Text = "二审通过"; break;
            case "3": btnAudit.Text = "终审通过"; break;
        }
    }
    #endregion

    #region 字段初始化
    private void InitProperty()
    {
        ViewState["Property"] = string.Empty;
        ViewState["PropertyType"] = string.Empty;
        ViewState["PropertyValue"] = string.Empty;
    }
    #endregion

    #region 绑定内容数据
    public void Bind()
    {
        string tableName = InfoModel.TableName;
        string colIdStr = ColumnBll.GetChildIdByColumnId(ColumnId);
        string fieldName = FieldName;
        string keyword = Keyword.Replace("'", "''");
        string status = Status;
        string property = ViewState["Property"].ToString();
        string propertyType = ViewState["PropertyType"].ToString();
        string propertyValue = ViewState["PropertyValue"].ToString();
        int userType = UserType;
        int recordCount = 0;
        DataTable dt = InfoOperBll.GetInfoList(tableName, fieldName, keyword, ChId, colIdStr, status, property, propertyType, propertyValue, userType, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        gvInfoList.DataSource = dt;
        gvInfoList.DataBind();
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}{3}{4} 每页{5}{3}", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, ChannelModel.TypeUnit, ChannelModel.TypeName, AspNetPager.PageSize);
    }
    #endregion

    #region 界面转换函数

    #region  定义内容属性的方法
    public string ChangePropertyDisplay(object isTop, object isRecommend, object isFocus, object hitCount, object isSideShow, object titleType)
    {
        StringBuilder _returnDisplay = new StringBuilder();
        if (Convert.ToBoolean(isTop))
            _returnDisplay.Append("<font color=red>顶</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToBoolean(isRecommend))
            _returnDisplay.Append("<font color=blue>荐</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToBoolean(isFocus))
            _returnDisplay.Append("<font color=gray>焦</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (int.Parse(hitCount.ToString()) >= ChannelModel.MiniHitCount)
            _returnDisplay.Append("<font color=red>热</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToBoolean(isSideShow))
            _returnDisplay.Append("<font color=blue>幻</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
        if (Convert.ToInt32(titleType) == 2)
            _returnDisplay.Append("<font color=red>图</font> ");
        else
            _returnDisplay.Append("&nbsp;&nbsp;");
        return _returnDisplay.ToString();
    }
    #endregion

    #region  定义审核状态的方法
    public string ChangeStatus(object Status)
    {
        StringBuilder _sb = new StringBuilder();
        if (Convert.ToInt32(Status) == -2)
            _sb.Append("未被采纳");
        if (Convert.ToInt32(Status) == -1)
            _sb.Append("草稿");
        if (Convert.ToInt32(Status) == 0)
            _sb.Append("待审");
        if (Convert.ToInt32(Status) == 1)
            _sb.Append("初审通过");
        if (Convert.ToInt32(Status) == 2)
            _sb.Append("二审通过");
        if (Convert.ToInt32(Status) == 3)
            _sb.Append("终审通过");
        return _sb.ToString();
    }

    #endregion

    #region 定义内容标题
    public string InfoTitle(object ColName, object Title, object colId, object Id, object uName)
    {
        StringBuilder _returnResult = new StringBuilder();
        _returnResult.Append("<a href='InfoList.aspx?ChId=" + ChId + "&ColId=" + colId + "'>[<font color='#FF0000'>" + ColName.ToString() + "</font>]</a>");
        _returnResult.Append("<a href='../preview/PreInfo.aspx?Id=" + Id + "&ModelId=" + ChannelModel.ModelType + "' target='_black' title=\"标题：" + Function.HtmlEncode(Title) + "\r\n录入者：" + Function.HtmlEncode(uName) + "" + "\">" + Function.HtmlEncode(Title.ToString()) + "</a>");
        return _returnResult.ToString();
    }
    #endregion

    #region GridView 的CSS样式设置
    protected void gvInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //鼠标移上去背景颜色变化 数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
        }
    }
    #endregion

    #region 退稿文字
    public string ExitInfoText(object status, object userType)
    {
        if (int.Parse(AuditingLevel) >= ChannelModel.VerifyType && int.Parse(AuditingLevel) > 0)
        {
            string temp = string.Empty;
            if (status.ToString() == "-2" || status.ToString() == "3" || userType.ToString() == "True")
                temp = string.Empty;
            else
                temp = "退稿";
            return temp;
        }
        else
        {
            return string.Empty;
        }
    }
    #endregion

    #region  设置是否为固顶
    public string SetIsTopText(object isTop)
    {
        string temp = string.Empty;
        if (Convert.ToBoolean(isTop))
            temp = "解顶";
        else
            temp = "置顶";
        return temp;
    }
    public string SetIsTopCA(string obj)
    {
        return obj;
    }
    #endregion

    #region  设置是否为推荐
    public string SetIsRecommendText(object isRecommend)
    {
        string temp = string.Empty;
        if (Convert.ToBoolean(isRecommend))
            temp = "取消推荐";
        else
            temp = "设为推荐";
        return temp;
    }
    public string SetIsRecommendCA(string obj)
    {
        return obj;
    }
    #endregion

    #endregion

    #region 删除内容到回收站
    protected void gvInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gvInfoList.DataKeys[e.RowIndex].Value);
        DataRow dr = InfoOperBll.GetInfo(InfoModel.TableName, id);
        if (dr == null)
            return;
        int chId = ChId;
        int colId = (int)dr["ColId"];
        PowerGroupBll.Power_Judge(chId, colId, 4, "<li>对不起 ，你没有删除该" + ChannelModel.TypeName + "的权限</li>");
        InfoOperBll.DeleteInfoToRecycle(id.ToString(), InfoModel.TableName);
        Bind();
    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        string idStr = GetSelectIdStr();
        if (idStr == string.Empty)
        {
            Function.ShowSysMsg(0, "<li>请选择需要删除的内容项</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        InfoOperBll.DeleteInfoToRecycle(idStr, InfoModel.TableName);
        Bind();
    }
    #endregion

    #region 翻页操作
    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        Bind();
    }
    #endregion

    #region 频道跳转
    protected void BindChannel()
    {
        DataView dv = ChannelBll.GetList(false);
        ddlChannel.DataTextField = "ChName";
        ddlChannel.DataValueField = "ChId";
        ddlChannel.DataSource = dv;
        ddlChannel.DataBind();
        ddlChannel.Items.Insert(0, new ListItem("请选择频道", "0"));
        dv.Dispose();
    }
    #endregion

    #region 属性筛选功能
    protected void ShowSearchResult(object sender, EventArgs e)
    {
        InitProperty();
        switch (Convert.ToString(((LinkButton)sender).ID))
        {
            default:
            case "lkBtnIsTop": ViewState["Property"] = "istop"; ViewState["PropertyType"] = "="; ViewState["PropertyValue"] = "1"; break;
            case "lkBtnIsRecommend": ViewState["Property"] = "isrecommend"; ViewState["PropertyType"] = "="; ViewState["PropertyValue"] = "1"; ; break;
            case "lkBtnIsFocus": ViewState["Property"] = "isfocus"; ViewState["PropertyType"] = "="; ViewState["PropertyValue"] = "1"; break;
            case "lkBtnIsHot": ViewState["Property"] = "hitcount"; ViewState["PropertyType"] = ">="; ViewState["PropertyValue"] = ChannelModel.MiniHitCount; break;
            case "lkBtnIsSideShow": ViewState["Property"] = "issideshow"; ViewState["PropertyType"] = "="; ViewState["PropertyValue"] = "1"; break;
            case "lkBtnIsImg": ViewState["Property"] = "titletype"; ViewState["PropertyType"] = "="; ViewState["PropertyValue"] = "2"; break;
        }
        Bind();
    }
    #endregion

    #region  根据频道ID获取栏目ID,栏目.名参数为频道ID
    public void BindColumn()
    {
        DataTable dt = ColumnBll.GetFormatListItemByChannelId(ChId);
        ddlColId.DataTextField = "ColName";
        ddlColId.DataValueField = "ColId";
        ddlColId.DataSource = dt;
        ddlColId.DataBind();
        ddlColId.Items.Insert(0, new ListItem("所有栏目", "0"));
        if (ColumnId > 0)
        {
            try
            {
                ddlColId.SelectedValue = ColumnId.ToString();
            }
            catch { }
        }
    }
    #endregion

    #region 单行操作
    protected void gvInfoList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "setIsTop")
        {
            string temp = e.CommandArgument.ToString();
            string[] array = temp.Split('|');
            int id = int.Parse(array[1]);
            if (array[0] == "False")
                InfoOperBll.SetProperty(InfoModel.TableName, "istop", "1", id);
            else
                InfoOperBll.SetProperty(InfoModel.TableName, "istop", "0", id);
        }
        if (e.CommandName == "setIsRecommend")
        {
            string temp = e.CommandArgument.ToString();
            string[] array = temp.Split('|');
            int id = int.Parse(array[1]);
            if (array[0] == "False")
                InfoOperBll.SetProperty(InfoModel.TableName, "isrecommend", "1", id);
            else
                InfoOperBll.SetProperty(InfoModel.TableName, "isrecommend", "0", id);
        }
        if (e.CommandName == "ExitInfo")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            InfoOperBll.Cancel(InfoModel.TableName, id);
        }

        if(e.CommandName=="Anomaly")
        {
            int id = int.Parse(e.CommandArgument.ToString().Split('┃')[0]);
            string title = e.CommandArgument.ToString().Split('┃')[1].ToString();
            string colName = string.Empty;

            ColumnModel = ColumnBll.GetColumn(ColumnId);
            colName = ColumnModel.ColName;

            AnomalyModel.InfoId = id;
            AnomalyModel.ChId = ChId;
            AnomalyModel.ColName = colName;
            AnomalyModel.Title = title;
            if(AnomalyBll.CheckHas(ChId,id))
            {
                bool result = AnomalyBll.Add(AnomalyModel);
                if(result)
                    Response.Write("<script>alert('设置成功');</script>");
                else
                    Response.Write("<script>alert('设置失败');</script>");
            }
            else
                Response.Write("<script>alert('此条记录已设置为不规则了');</script>");
        }
        Bind();
    }
    #endregion

    #region 搜索
    protected void btnGoSearch_Click(object sender, EventArgs e)
    {
        string colId = ddlColId.SelectedValue;
        string fieldName = ddlsortName.SelectedValue;
        string keyword = txtKeyword.Text.Trim();
        if (colId != "0")
        {
            Response.Redirect("InfoList.aspx?ChId=" + ChId + "&ColId=" + colId + "&FieldName=" + fieldName + "&Keyword=" + keyword);
        }
        else
        {
            Response.Redirect("InfoList.aspx?ChId=" + ChId + "&FieldName=" + fieldName + "&Keyword=" + keyword);
        }
    }
    #endregion

    #region 内容审核
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        string idStr = GetSelectIdStr();
        if (idStr.Length == 0)
        {
            Function.ShowSysMsg(0, "<li>请选择需要审核的" + ChannelModel.TypeName + "</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        int auditingLevel = int.Parse(AuditingLevel);
        const int finillyStatus = 3;
        if (auditingLevel >= ChannelModel.VerifyType && ((auditingLevel == 1 || auditingLevel == 2 || auditingLevel == 3)))
            InfoOperBll.Auditing(InfoModel.TableName, idStr, finillyStatus);
        else
            InfoOperBll.Auditing(InfoModel.TableName, idStr, auditingLevel);
        Bind();
    }
    #endregion

    #region 取得批量选择的ID
    private string GetSelectIdStr()
    {
        string idStr = string.Empty;
        foreach (GridViewRow row in gvInfoList.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkBoxChooseInfo");
            if (cb.Checked)
            {
                idStr += gvInfoList.DataKeys[row.RowIndex].Value.ToString() + ",";
            }
        }
        if (idStr.EndsWith(","))
        {
            idStr = idStr.Substring(0, idStr.Length - 1);
        }
        return idStr;
    }
    #endregion

    //批量移动
    protected void btnMassMove_Click(object sender, EventArgs e)
    {
        string idStr = GetSelectIdStr();
        Response.Redirect("MassMoveInfo.aspx?idStr=" + idStr + "&ChId=" + ChId + "&ColId=" + ColumnId);
    }

    //批量设置
    protected void btnMassSet_Click(object sender, EventArgs e)
    {
        string idStr = GetSelectIdStr();
        Response.Redirect("MassSetInfo.aspx?IdStr=" + idStr + "&ChId=" + ChId + "&ColId=" + ColumnId);
    }

    //生成本栏目所有内容
    protected void btnCreateColumn_Click(object sender, EventArgs e)
    {
        if (ColumnId == 0)
        {
            Function.ShowSysMsg(0, "<li>该功能只能在栏目内容列表时使用</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        if (!ChannelModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>所属频道没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        Session["newscolumnid"] = ColumnId;
        Response.Redirect("../create/createing.aspx?type=newscolumn");
    }

    //生成选中内容
    protected void btnCreateSelectInfo_Click(object sender, EventArgs e)
    {
        string idStr = GetSelectIdStr();
        if (idStr == "")
        {
            Function.ShowSysMsg(0, "<li>请选择生成项</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }

        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        if (!ChannelModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>所属频道没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        Session["CreateInfoIdStr"] = idStr;
        Response.Redirect("../create/createing.aspx?type=info&modelId=" + ChannelModel.ModelType);
    }
    protected void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        int chId = int.Parse(ddlChannel.SelectedValue);
        if (chId == 0)
        {
            return;
        }
        int modelType = ChannelBll.GetChannel(chId).ModelType;
        switch (modelType)
        {
            default:
            case 1:
                Response.Redirect("~/system/info/InfoList.aspx?ChId=" + chId);
                break;
        }
    }

    #region 获取修改的Url
    protected string GetInfoUrl(object id, object colid)
    {
        int modelId = ChannelModel.ModelType;
        switch (modelId)
        {
            default:
                return "UpdateInfo.aspx?ChId=" + ChId + "&ColId=" + colid + "&Id=" + id;
            case 1:
                return "SetArticle.aspx?ChId=" + ChId + "&ColId=" + colid + "&Id=" + id;
            case 2:
                return "SetImage.aspx?ChId=" + ChId + "&ColId=" + colid + "&Id=" + id;
            case 3:
                return "SetDownLoad.aspx?ChId=" + ChId + "&ColId=" + colid + "&Id=" + id;
        }
    }
    #endregion
}
