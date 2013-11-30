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
using System.Text.RegularExpressions;
using Ky.Common;

public partial class System_ColumnManage : System.Web.UI.Page
{

    protected B_Column ColumnBll = new B_Column();
    protected B_Channel ChannelBll = new B_Channel();
    protected M_Channel ChannelModel = null;
    B_Admin AdminBll = new B_Admin();
    protected B_UserGroup GroupBll = new B_UserGroup();
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected int ChId = 0;
    protected int ColumnId = 0;
    protected int ChildColId = 0;
    protected string ColIdStr = string.Empty;


    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(36);
        litMsg.Text = string.Empty;
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }catch{}
        }
        ChannelModel = ChId != 0 ? ChannelBll.GetChannel(ChId) : null;
        if (ChannelModel == null)
        {
            Function.ShowSysMsg(0, "<li>频道参数错误</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        hyperColumnNav.NavigateUrl = "ColumnList.aspx?ChId=" + ChannelModel.ChId;
        hyperColumnNav.Text = "[" + ChannelModel.ChName + "] 栏目管理";
        
        if(!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColumnId = int.Parse(Request.QueryString["ColId"]);
            }catch{}
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ChildColId"]))
        {
            try
            {
                ChildColId = int.Parse(Request.QueryString["ChildColId"]);
            }
            catch { }
        }
        txtColumnTemplatePath.Attributes.Add("readonly", "readonly");
        txtInfoTemplatePath.Attributes.Add("readonly", "readonly");
        txtCommentTemplatePath.Attributes.Add("readonly", "readonly");
        AjaxPro.Utility.RegisterTypeForAjax(typeof(System_ColumnManage));
        if (!IsPostBack)
        {
            BindColumn();
            BindGroup();
            txtColumnTemplatePath.Text = ChannelModel.ColumnTemplatePath;
            txtInfoTemplatePath.Text = ChannelModel.InfoTemplatePath;
            txtCommentTemplatePath.Text = ChannelModel.CommentTemplatePath;
            rblColumnPageType.SelectedValue = ChannelModel.ColumnPageType.ToString();
            rblInfoPageType.SelectedValue = ChannelModel.InfoPageType.ToString();
            try
            {
                ddlColumn.SelectedValue = ChildColId.ToString();
            }
            catch { }
            if (ColumnId != 0)
            {
                ShowInfo();
                litNav.Text = "修改栏目";
            }
            else
            {
                litNav.Text = "添加栏目";
                
            }
        }

    }
    #endregion

    [AjaxPro.AjaxMethod]
    public string GetPinYin(string colName)
    {
        if (ColumnId == 0)
            return Function.ConvertPinYin(colName);
        else
            return string.Empty;
    }


    public void BindGroup()
    {

        DataTable dt = GroupBll.ManageList("");
        cblGroupIdStr1.DataValueField = "UserGroupId";
        cblGroupIdStr1.DataTextField = "UserGroupName";
        cblGroupIdStr1.DataSource = dt;
        cblGroupIdStr1.DataBind();
        cblGroupIdStr2.DataValueField = "UserGroupId";
        cblGroupIdStr2.DataTextField = "UserGroupName";
        cblGroupIdStr2.DataSource = dt;
        cblGroupIdStr2.DataBind();
        cblGroupIdStr3.DataValueField = "UserGroupId";
        cblGroupIdStr3.DataTextField = "UserGroupName";
        cblGroupIdStr3.DataSource = dt;
        cblGroupIdStr3.DataBind();
    }


    private void BindColumn()
    {
        ddlColumn.DataTextField = "ColName";
        ddlColumn.DataValueField = "ColId";
        DataTable dt = ColumnBll.GetFormatListItemByChannelId(ChId);
        ddlColumn.DataSource = dt;
        ddlColumn.DataBind();
        ddlColumn.Items.Insert(0,new ListItem("作为一级栏目","0"));
    }

    private void ShowInfo()
    {
        M_Column model = ColumnBll.GetColumn(ColumnId);
        if (model == null)
        {
            Function.ShowSysMsg(0, "<li>所选栏目不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        litColIdStr.Text = "|"+ColumnBll.GetChildIdByColumnId(ColumnId).Replace(",","|")+"|";
        try
        {
            ddlColumn.SelectedValue = model.ColParentId.ToString();
        }
        catch { }
        txtColName.Text = model.ColName;
        txtColDirName.Text = model.ColDirName;
        txtColDirName.Enabled = false;
        if(model.IsOuterColumn)
        {
            rbIsOuterColumn1.Checked=true;
        }
        else
        {
            rbIsOuterColumn0.Checked=true;
        }
        txtOuterColumnUrl.Text = model.OuterColumnUrl;
        txtColumnTemplatePath.Text = model.ColumnTemplatePath;
        txtInfoTemplatePath.Text = model.InfoTemplatePath;
        txtCommentTemplatePath.Text = model.CommentTemplatePath;
        txtColumnImgPath.Text = model.ColumnImgPath;
        txtDescription.Text = model.Description;

        rblIsAllowAddInfo.SelectedValue = model.IsAllowAddInfo.ToString();
        txtSort.Text = model.Sort.ToString();
        rblIsAllowComment.SelectedValue = model.IsAllowComment.ToString();
        rblIsCheckComment.SelectedValue = model.IsCheckComment.ToString();
        txtKeyword.Text = model.Keyword;
        txtContent.Text = model.Content;
        rblIsOpened.SelectedValue = model.IsOpened.ToString();
        for (int i = 0; i < cblGroupIdStr1.Items.Count; i++)
        {
            int groupId = int.Parse(cblGroupIdStr1.Items[i].Value);
            M_UserGroup userGroupModel = GroupBll.GetModel(groupId);
            string power = userGroupModel.ColumnPower;
            if (GroupBll.Power_ColumnPower(ChId, ColumnId, power, 1))
            {
                cblGroupIdStr1.Items[i].Selected = true;
            }
            if (GroupBll.Power_ColumnPower(ChId, ColumnId, power, 2))
            {
                cblGroupIdStr2.Items[i].Selected = true;
            }
            if (GroupBll.Power_ColumnPower(ChId, ColumnId, power, 3))
            {
                cblGroupIdStr3.Items[i].Selected = true;
            }
        }
           
        txtScoreReward.Text = model.ScoreReward.ToString();
        txtPointCount.Text = model.PointCount.ToString();
        switch (model.ChargeType)
        {
            default:
            case 1: rbChargeType1.Checked = true; break;
            case 2: rbChargeType2.Checked = true; break;
            case 3: rbChargeType3.Checked = true; break;
            case 4: rbChargeType4.Checked = true; break;
            case 5: rbChargeType5.Checked = true; break;
            case 6: rbChargeType6.Checked = true; break;
        }
        txtChargeHourCount.Text = model.ChargeHourCount.ToString();
        txtChargeViewCount.Text = model.ChargeViewCount.ToString();

        rblColumnPageType.SelectedValue = model.ColumnPageType.ToString();
        rblInfoPageType.SelectedValue = model.InfoPageType.ToString();


    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        M_Column model = new M_Column();
        model.ChId = ChId;
        model.ColId = ColumnId;
        if (litColIdStr.Text.IndexOf("|" + ddlColumn.SelectedValue + "|") != -1)
        {
            Function.ShowSysMsg(0, "<li>所属栏目不能为当前栏目或子栏目</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.ColParentId = int.Parse(ddlColumn.SelectedValue);
        if (txtColName.Text.Trim().Length == 0)
        {
            Function.ShowSysMsg(0, "<li>栏目中文名必须填写</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
       
        model.ColName = txtColName.Text.Trim();
       
        string dirName = txtColDirName.Text.Trim();
        if (!Regex.IsMatch(dirName, @"^[a-zA-Z][0-9a-zA-Z]*$"))
        {
            Function.ShowSysMsg(0, "<li>栏目英文名必须以字母开头，必须是字母和数字组成</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.ColDirName = dirName;
        if (ColumnId == 0)
        {
            B_KyCommon kyCommonBll = new B_KyCommon();
            bool flag = kyCommonBll.CheckHas(dirName, "ColDirName", "KyColumn");
            if (flag)
            {
                Function.ShowSysMsg(0, "<li>栏目英文名已经存在</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }
        if(model.IsOuterColumn&&txtOuterColumnUrl.Text.Trim().Length==0)
        {
            Function.ShowSysMsg(0, "<li>设置栏目为外部栏目，外部链接地址必须填写</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.IsOuterColumn = rbIsOuterColumn0.Checked ? false : true;
        model.OuterColumnUrl = model.IsOuterColumn ? txtOuterColumnUrl.Text.Trim() : "";
        if (txtColumnTemplatePath.Text.Trim().Length == 0)
        {
            Function.ShowSysMsg(0, "<li>栏目页模板必须选择</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.ColumnTemplatePath = txtColumnTemplatePath.Text.Trim();
        if (txtInfoTemplatePath.Text.Trim().Length == 0)
        {
            Function.ShowSysMsg(0, "<li>内容页模板必须选择</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.InfoTemplatePath = txtInfoTemplatePath.Text.Trim();
        if (txtCommentTemplatePath.Text.Trim().Length == 0)
        {
            Function.ShowSysMsg(0, "<li>评论页模板必须选择</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.CommentTemplatePath = txtCommentTemplatePath.Text.Trim();
        if (txtDescription.Text.Trim().Length > 255)
        {
            Function.ShowSysMsg(0, "<li>栏目描述不能超过255个字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.ColumnImgPath = txtColumnImgPath.Text.Trim();
        model.Description = txtDescription.Text.Trim();

        model.IsAllowAddInfo = bool.Parse(rblIsAllowAddInfo.SelectedValue);
        if (!Function.CheckNumber(txtSort.Text.Trim()))
        {
            Function.ShowSysMsg(0, "<li>栏目排序编号必须是0或整正数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.Sort = int.Parse(txtSort.Text.Trim());
        model.IsAllowComment = bool.Parse(rblIsAllowComment.SelectedValue);
        model.IsCheckComment = bool.Parse(rblIsCheckComment.SelectedValue);
        if (txtKeyword.Text.Trim().Length > 100)
        {
            Function.ShowSysMsg(0, "<li>栏目META关键词不能超过100个字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.Keyword = txtKeyword.Text.Trim();
        if (txtContent.Text.Trim().Length > 300)
        {
            Function.ShowSysMsg(0, "<li>栏目META网页描述不能超过300个字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.Content = txtContent.Text.Trim();
        model.IsOpened = bool.Parse(rblIsOpened.SelectedValue);
        model.GroupIdStr = string.Empty;

        if (!Function.CheckNumber(txtScoreReward.Text.Trim()))
        {
            Function.ShowSysMsg(0, "<li>积分奖励必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.ScoreReward = int.Parse(txtScoreReward.Text.Trim());
        if (!Function.CheckNumber(txtPointCount.Text.Trim()))
        {
            Function.ShowSysMsg(0, "<li>收费点数必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        model.PointCount = int.Parse(txtPointCount.Text.Trim());
        if(rbChargeType1.Checked)
        {
            model.ChargeType = 1;
        }
        else if (rbChargeType2.Checked)
        {
            model.ChargeType = 2;
            if (!Function.CheckNumber(txtChargeHourCount.Text.Trim()))
            {
                Function.ShowSysMsg(0, "<li>重复收费时间必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            model.ChargeHourCount = int.Parse(txtChargeHourCount.Text.Trim());
        }
        else if (rbChargeType3.Checked)
        {
            model.ChargeType = 3;
            if (!Function.CheckNumber(txtChargeViewCount.Text.Trim()))
            {
                Function.ShowSysMsg(0, "<li>重复收费浏览次数必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            model.ChargeViewCount = int.Parse(txtChargeViewCount.Text.Trim());
        }
        else if(rbChargeType4.Checked)
        {
            model.ChargeType = 4;
            if (!Function.CheckNumber(txtChargeHourCount.Text.Trim()))
            {
                Function.ShowSysMsg(0, "<li>重复收费时间必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            model.ChargeHourCount = int.Parse(txtChargeHourCount.Text.Trim());
            if (!Function.CheckNumber(txtChargeViewCount.Text.Trim()))
            {
                Function.ShowSysMsg(0, "<li>重复收费浏览次数必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            model.ChargeViewCount = int.Parse(txtChargeViewCount.Text.Trim());      
        }
        else if (rbChargeType5.Checked)
        {
            model.ChargeType = 5;
            if (!Function.CheckNumber(txtChargeHourCount.Text.Trim()))
            {
                Function.ShowSysMsg(0, "<li>重复收费时间必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            model.ChargeHourCount = int.Parse(txtChargeHourCount.Text.Trim());
            if (!Function.CheckNumber(txtChargeViewCount.Text.Trim()))
            {
                Function.ShowSysMsg(0, "<li>重复收费浏览次数必须是0或正整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            model.ChargeViewCount = int.Parse(txtChargeViewCount.Text.Trim());
        }
        else
        {
            model.ChargeType = 6;
        }


        model.ColumnPageType = int.Parse(rblColumnPageType.SelectedValue);
        model.InfoPageType = int.Parse(rblInfoPageType.SelectedValue);
        model.IsDeleted = false;
        model.AddTime = DateTime.Now;
        model.InfoTableName = string.Empty;
        int currColId = 0;
        if (ColumnId > 0)
        {
            currColId = ColumnBll.Update(model);  
        }
        else
        {
            currColId = ColumnBll.Add(model);
        }
        for (int i = 0; i < cblGroupIdStr1.Items.Count; i++)
        {
            int groupId = int.Parse(cblGroupIdStr1.Items[i].Value);
            M_UserGroup userGroupModel = GroupBll.GetModel(groupId);
            string power = userGroupModel.ColumnPower;
            int a = cblGroupIdStr1.Items[i].Selected ? 1 : 0;
            int b = cblGroupIdStr2.Items[i].Selected ? 1 : 0;
            int c = cblGroupIdStr3.Items[i].Selected ? 1 : 0;

            power = GroupBll.ColumnPower_ColumnPower(ChId, currColId, power, a, b, c);

            userGroupModel.ColumnPower = power;
            GroupBll.Update(userGroupModel);
        }
        Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();location.href('ColumnList.aspx?ChId=" + ChId + "');</script>");
    }
}
