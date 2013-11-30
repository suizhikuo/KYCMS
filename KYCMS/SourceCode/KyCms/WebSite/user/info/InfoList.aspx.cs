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
using System.Text;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class User_Info_InfoList : System.Web.UI.Page
{
    B_InfoOper InfoOperBll = new B_InfoOper();
    string FieldName = string.Empty;
    string Keyword = string.Empty;
    int UserCateId = -1;
    string Status = "-99";
    B_User UserBll = new B_User();
    B_UserGroup UserGroupBll = new B_UserGroup();
    M_UserGroup UserGroupModel = null;
    M_User LoginModel = null;
    M_User UserModel = null;

    protected int ChId = 0;
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    B_Channel ChannelBll = new B_Channel();
    protected M_Channel ChannelModel = null;

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        lbMessageBox.Text = "";
        UserBll.CheckIsLogin();
        LoginModel = UserBll.GetCookie();
        UserModel = UserBll.GetUser(LoginModel.UserID);
        UserGroupModel = UserGroupBll.GetModel(UserModel.GroupID);
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
            return;
        }
        InfoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
        if (InfoModel == null)
        {
            return;
        }
        hylnkSetInfo.Text = "添加" + ChannelModel.TypeName;
        switch (InfoModel.ModelId)
        {
            default:
                hylnkSetInfo.NavigateUrl = "AddInfo.aspx?ChId=" + ChId;
                break;
            case 1:
                hylnkSetInfo.NavigateUrl = "SetArticle.aspx?ChId=" + ChId;
                break;
            case 2:
                hylnkSetInfo.NavigateUrl = "SetImage.aspx?ChId=" + ChId;
                break;
            case 3:
                hylnkSetInfo.NavigateUrl = "SetDownLoad.aspx?ChId=" + ChId;
                break;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Status"]))
        {
            string statusText = Request.QueryString["Status"].ToLower();
            if (statusText == "all" || statusText == string.Empty)
            {
                Status = "-99";
            }
            else if (statusText == "rec")
            {
                Status = "-1";
            }
            else if (statusText == "wait")
            {
                Status = "0,1,2";
            }
            else if (statusText == "yes")
            {
                Status = "3";
            }
            else if (statusText == "no")
            {
                Status = "-2";
            }
        }

        if (!string.IsNullOrEmpty(Request.QueryString["UserCateId"]))
        {
            try
            {
                UserCateId = int.Parse(Request.QueryString["UserCateId"]);
            }
            catch { }
        }

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

        if (!IsPostBack)
        {
            InitProperty();
            Bind();
            BindUserCate();
            ddlsortName.Items[0].Text = ChannelModel.TypeName + "标题";
            if (gvInfoList.Rows.Count > 0)
                gvInfoList.HeaderRow.Cells[2].Text = ChannelModel.TypeName + "标题";
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

    #region 绑定数据
    public void Bind()
    {
        string tableName = InfoModel.TableName;
        int chId = ChId;
        string fieldName = FieldName;
        string keyword = Keyword;
        int userId = UserModel.UserID;
        string status = Status;
        string property = ViewState["Property"].ToString();
        string propertyType = ViewState["PropertyType"].ToString();
        string propertyValue = ViewState["PropertyValue"].ToString();
        int userCateId = UserCateId;
        int recordCount = 0;
        DataTable dt = InfoOperBll.GetUserInfoList(tableName, userId, fieldName, keyword, chId, "0", status, property, propertyType, propertyValue, userCateId, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        gvInfoList.DataSource = dt.DefaultView;
        gvInfoList.DataBind();
        dt.Dispose();
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}{4}{5} 每页{3}{4}", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize, ChannelModel.TypeUnit, ChannelModel.TypeName);

    }
    #endregion

    public string InfoTitle(object Title, object titleType)
    {
        StringBuilder _returnResult = new StringBuilder();
        if (Convert.ToInt32(titleType) == 2)
            _returnResult.Append("<img src='../images/skin/default/img.gif' alt='图片' border=0 />");
        else
            _returnResult.Append("<img src='../images/skin/default/folder_1.gif' alt='文本' border=0 />");
        _returnResult.Append(Function.HtmlEncode(Title.ToString()));
        return _returnResult.ToString();
    }


    #region GridView 的CSS样式设置
    protected void gvInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //鼠标移上去背景颜色变化
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
        }
    }
    #endregion

    #region  定义内容属性的方法
    //public string ChangePropertyDisplay(object isTop, object isRecommend, object isFocus, object hitCount, object isSideShow, object titleType, object miniHitCount)
    //{
    //    StringBuilder _returnDisplay = new StringBuilder();
    //    if (Convert.ToBoolean(isTop))
    //        _returnDisplay.Append("<font color=red>顶</font> ");
    //    else
    //        _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
    //    if (Convert.ToBoolean(isRecommend))
    //        _returnDisplay.Append("<font color=blue>荐</font> ");
    //    else
    //        _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
    //    if (Convert.ToBoolean(isFocus))
    //        _returnDisplay.Append("<font color=gray>焦</font> ");
    //    else
    //        _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
    //    if (int.Parse(hitCount.ToString()) >= (int)miniHitCount)
    //        _returnDisplay.Append("<font color=red>热</font> ");
    //    else
    //        _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
    //    if (Convert.ToBoolean(isSideShow))
    //        _returnDisplay.Append("<font color=blue>幻</font> ");
    //    else
    //        _returnDisplay.Append("&nbsp;&nbsp;&nbsp;");
    //    if (Convert.ToInt32(titleType) == 2)
    //        _returnDisplay.Append("<font color=red>图</font> ");
    //    else
    //        _returnDisplay.Append("&nbsp;&nbsp;");
    //    return _returnDisplay.ToString();
    //}
    #endregion

    #region  定义审核状态的方法
    public string ChangeStatus(object Status)
    {
        StringBuilder _sb = new StringBuilder();
        /*分别判断数据库中字段的值*/
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
        /*返回显示*/
        return _sb.ToString();
    }
    #endregion

    #region 单项删除到回收站
    protected void gvInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gvInfoList.DataKeys[e.RowIndex].Value);
        InfoOperBll.UserDeleteInfo(id.ToString(), InfoModel.TableName, UserModel.UserID);
        Bind();
    }
    #endregion

    #region 批量删除到回收站
    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        string idStr = string.Empty;
        foreach (GridViewRow rowview in gvInfoList.Rows)
        {
            CheckBox _cb = (CheckBox)rowview.Cells[1].FindControl("chkBoxChooseInfo");
            bool isChecked = _cb.Checked;
            if (isChecked)
            {
                idStr += gvInfoList.DataKeys[rowview.RowIndex].Value.ToString() + ",";
            }
        }
        if (idStr == string.Empty)
        {
            lbMessageBox.Visible = true;
            lbMessageBox.Text = "<script> alert('请选择删除项');</script>";
            return;
        }

        if (idStr.EndsWith(","))
        {
            idStr = idStr.Substring(0, idStr.Length - 1);
        }
        InfoOperBll.UserDeleteInfo(idStr, InfoModel.TableName, UserModel.UserID);
        lbMessageBox.Visible = true;
        lbMessageBox.Text = "<script> alert('批量删除成功');</script>";
        Bind();
    }
    #endregion

    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        Bind();
    }

    #region 关键字搜索
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string fieldName = ddlsortName.SelectedValue;
        int userCateId = int.Parse(ddlUserCate.SelectedValue.Trim());
        string keyword = txtKeyword.Text.Trim().Replace("'", "''");
        Response.Redirect("InfoList.aspx?ChId=" + ChId + "&UserCateId=" + userCateId + "&FieldName=" + fieldName + "&Keyword=" + keyword);
    }
    #endregion

    #region  绑定会员专栏
    public void BindUserCate()
    {
        DataTable dt = UserBll.GetUserCateList(UserModel.UserID, 0);
        ddlUserCate.DataTextField = "CateName";
        ddlUserCate.DataValueField = "UserCateId";
        ddlUserCate.DataSource = dt;
        ddlUserCate.DataBind();
        dt.Dispose();
        ddlUserCate.Items.Insert(0, new ListItem("所有专栏", "-1"));
    }
    #endregion

    public string IsAllowUpdate(object status, object id, object chId, object colId)
    {
        string formatStr = string.Empty;
        int currStatus = (int)status;
        if (currStatus == -1 || currStatus == -2 || currStatus == 0)
        {
            switch (InfoModel.ModelId)
            {
                default:
                    formatStr = "<a href='UpdateInfo.aspx?Id=" + id + "&ChId=" + chId + "&ColId=" + colId + "'>修改</a>";
                    break;
                case 1:
                    formatStr = "<a href='SetArticle.aspx?Id=" + id + "&ChId=" + chId + "&ColId=" + colId + "'>修改</a>";
                    break;
                case 2:
                    formatStr = "<a href='SetImage.aspx?Id=" + id + "&ChId=" + chId + "&ColId=" + colId + "'>修改</a>";
                    break;
                case 3:
                    formatStr = "<a href='SetDownLoad.aspx?Id=" + id + "&ChId=" + chId + "&ColId=" + colId + "'>修改</a>";
                    break;
            }
        }
        return formatStr;
    }

    protected void gvInfoList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UserPublished")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            InfoOperBll.SetPublish(InfoModel.TableName, id, UserModel.UserID);
        }
        Bind();
    }
    public bool GetDeleteAndPublishStatus(object status)
    {
        if ((int)status == -1 || (int)status == -2)
            return true;
        else
            return false;
    }
}
