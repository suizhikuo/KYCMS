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
using System.Text.RegularExpressions;


public partial class System_Add_KyChanel : System.Web.UI.Page
{
    int ChId = 0;
    int ChType = 0;
    B_Admin AdminBll = new B_Admin();
    B_UserGroup GroupBll = new B_UserGroup();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_Dictionary DicBll = new B_Dictionary();
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(36);
        litMsg.Text = string.Empty;
        txtTemplatePath.Attributes.Add("readonly","readonly");
        txtColumnTemplatePath.Attributes.Add("readonly", "readonly");
        txtInfoTemplatePath.Attributes.Add("readonly", "readonly");
        txtCommentTemplatePath.Attributes.Add("readonly", "readonly");
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ChType"]))
        {
            try
            {
                ChType = int.Parse(Request.QueryString["ChType"]);
            }
            catch { }
        }
        M_Dictionary dicModel = DicBll.GetModel(ChType);
        string dicName = string.Empty;
        if (dicModel == null)
        {
            dicName = "其他";
        }
        else
        {
            dicName = dicModel.DicName;
        }
        if (!Page.IsPostBack)
        {
            BindModelType();
            BindGroup();
            
            if (ChId != 0)
            {
                ShowInfo();
                litNav.Text = "[" + dicName + "]修改频道";
            }
            else
            {
                litNav.Text = "[" + dicName + "]添加频道";
            }
        }
    }
    #endregion



    private void BindModelType()
    {
        DataTable dt = InfoModelBll.GetList();
        ddlModelType.DataTextField = "modelname";
        ddlModelType.DataValueField = "modelid";
        ddlModelType.DataSource = dt;
        ddlModelType.DataBind();
        dt.Dispose();

    }


    #region 绑定用户组
    public void BindGroup()
    {
        cblGroupIdStr.DataValueField = "UserGroupId";
        cblGroupIdStr.DataTextField = "UserGroupName";
        cblGroupIdStr.DataSource = GroupBll.ManageList("");
        cblGroupIdStr.DataBind();
    }
    #endregion

    #region 修改或删除
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        B_Channel channelBll = new B_Channel();
        M_Channel model = new M_Channel();
        if (txtChName.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('频道名称必须填写')</script>";
            return;
        }
        model.ChId = ChId;
        model.ChName = txtChName.Text.Trim();
        model.ChType = ChType;
        model.ModelType = int.Parse(ddlModelType.SelectedValue);
        
        string dirName = txtDirName.Text.Trim();
        if (!Regex.IsMatch(dirName, @"^[a-zA-Z][0-9a-zA-Z]*$"))
        {
            litMsg.Text = "<script>alert('频道（目录）英文名必须以字母开头，必须是字母和数字组成')</script>";
            return;
        }
        model.DirName = dirName;
        if (ChId == 0)
        {
            B_KyCommon commonBll = new B_KyCommon();
            bool flag = commonBll.CheckHas(model.DirName, "DirName", "KyChannel");
            if (flag)
            {
                litMsg.Text = "<script>alert('频道英文名已经存在')</script>";
                return;
            }
        }
        if (txtTypeName.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('项目名称必须填写')</script>";
            return;
        }
        model.TypeName = txtTypeName.Text.Trim();
        if (txtTypeUnit.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('项目单位必须填写')</script>";
            return;
        }
        model.TypeUnit = txtTypeUnit.Text.Trim();
        if (rdIsChildSite2.Checked)
        {
            model.IsChildSite = true;
        }
        else
        {
            model.IsChildSite = false;
        }
        if (model.IsChildSite && txtChildSiteUrl.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('设置该频道为分站，分站地址必须填写')</script>";
            return;
        }
        model.ChildSiteUrl = model.IsChildSite ? txtChildSiteUrl.Text.Trim() : "";
        if (txtDescription.Text.Trim().Length > 255)
        {
            litMsg.Text = "<script>alert('网站描述不能超过255个字')</script>";
            return;
        }
        model.Description = txtDescription.Text.Trim();

        if (string.IsNullOrEmpty(Request.Form["txtTemplatePath"].Trim()))
        {
            litMsg.Text = "<script>alert('频道模板必须选择')</script>";
            return;
        }
        model.TemplatePath = Request.Form["txtTemplatePath"].Trim();
        if (string.IsNullOrEmpty(Request.Form["txtColumnTemplatePath"].Trim()))
        {
            litMsg.Text = "<script>alert('栏目页模板必须选择')</script>";
            return;
        }
        model.ColumnTemplatePath = Request.Form["txtColumnTemplatePath"].Trim();
        if (string.IsNullOrEmpty(Request.Form["txtInfoTemplatePath"].Trim()))
        {
            litMsg.Text = "<script>alert('内容页模板必须选择')</script>";
            return;
        }
        model.InfoTemplatePath = Request.Form["txtInfoTemplatePath"].Trim();
        if (string.IsNullOrEmpty(Request.Form["txtCommentTemplatePath"].Trim()))
        {
            litMsg.Text = "<script>alert('评论页模板必须选择')</script>";
            return;
        }
        model.CommentTemplatePath = Request.Form["txtCommentTemplatePath"].Trim();
        model.Keyword = txtKeyword.Text.Trim();
        if (txtContent.Text.Trim().Length > 300)
        {
            litMsg.Text = "<script>alert('META网页描述不能超过300个字')</script>";
            return;
        }
        model.Content = txtContent.Text.Trim();
        model.IsDisabled = bool.Parse(rblIsDisabled.SelectedValue);
        model.IsOpenLink = bool.Parse(rblIsOpenLink.SelectedValue);
        string miniHitCount = txtMiniHitCount.Text.Trim();
        if (!Function.CheckNumber(miniHitCount))
        {
            litMsg.Text = "<script>alert('热点点击数最小值必须是0或正整数')</script>";
            return;
        }
        model.MiniHitCount = int.Parse(miniHitCount);
        model.IsOpened = bool.Parse(rblIsOpened.SelectedValue);
        model.GroupIdStr = "";
        string columnPower = string.Empty;
        string power = string.Empty;
      
        model.VerifyType = int.Parse(ddlVerifyType.SelectedValue);
        if (txtNotice1.Text.Trim().Length > 500)
        {
            litMsg.Text = "<script>alert('退稿时通知信息内容不能超过500个字')</script>";
            return;
        }
        model.Notice1 = txtNotice1.Text.Trim();
        if (txtNotice2.Text.Trim().Length > 500)
        {
            litMsg.Text = "<script>alert('采纳时通知信息内容不能超过500个字')</script>";
            return;
        }
        model.Notice2 = txtNotice2.Text.Trim();
        model.IsStaticType = bool.Parse(rblIsStaticType.SelectedValue);
        model.ColumnSortType = int.Parse(ddlColumnSortType.SelectedValue);
        model.InfoSortType = int.Parse(ddlInfoSortType.SelectedValue);
        model.FileNameType = int.Parse(ddlFileNameType.SelectedValue);
        model.ChannelPageType = int.Parse(rblChannelPageType.SelectedValue);
        model.ColumnPageType = int.Parse(rblColumnPageType.SelectedValue);
        model.InfoPageType = int.Parse(rblInfoPageType.SelectedValue);

        model.IsDeleted = false;
        string sort = txtSort.Text.Trim();
        if (!Function.CheckNumber(sort))
        {
            litMsg.Text = "<script>alert('频道排序编号必须是0或正整数')</script>";
            return;
        }
        model.Sort = int.Parse(sort);
        model.AddTime = DateTime.Now;
        int currChId = 0;
        if (ChId == 0)
        {
            currChId = channelBll.Add(model);
        }
        else
        {
            currChId = channelBll.Update(model);
        }
        foreach (ListItem li in cblGroupIdStr.Items)
        {
            int groupId = int.Parse(li.Value);
            M_UserGroup userGroupModel = GroupBll.GetModel(groupId);
            power = userGroupModel.ColumnPower;
            int a = GroupBll.Power_ColumnPower(currChId, 0, power, 1) ? 1 : 0;
            int c = GroupBll.Power_ColumnPower(currChId, 0, power, 3) ? 1 : 0;
            if (li.Selected)
                power = GroupBll.ColumnPower_ColumnPower(currChId, 0, power, a, 1, c);
            else
                power = GroupBll.ColumnPower_ColumnPower(currChId, 0, power, a, 0, c);
            userGroupModel.ColumnPower = power;
            GroupBll.Update(userGroupModel);
        }
        Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();location.href('ChannelList.aspx');</script>");
    }
    #endregion

    #region 显示信息
    public void ShowInfo()
    {
        B_Channel channelBll = new B_Channel();
        M_Channel model = channelBll.GetChannel(ChId);
        if (model == null)
        {
            Response.Write("<script type='text/javascript'>alert('所选频道不存在或已经被删除');history.back();</script>");
            Response.End();
            return;
        }
        txtChName.Text = model.ChName;
        try
        {
            ddlModelType.SelectedValue = model.ModelType.ToString();
        }
        catch { }
        ddlModelType.Enabled = false;
        txtDirName.Text = model.DirName;
        txtDirName.Enabled = false;
        txtTypeName.Text = model.TypeName;
        txtTypeUnit.Text = model.TypeUnit;
        if (model.IsChildSite)
        {
            rdIsChildSite2.Checked = true;
        }
        else
        {
            rdIsChildSite1.Checked = true;
        }
        txtChildSiteUrl.Text = model.ChildSiteUrl;
        txtDescription.Text = model.Description;
        txtTemplatePath.Text = model.TemplatePath;
        txtColumnTemplatePath.Text = model.ColumnTemplatePath;
        txtInfoTemplatePath.Text = model.InfoTemplatePath;
        txtCommentTemplatePath.Text = model.CommentTemplatePath;
        txtKeyword.Text = model.Keyword;
        txtContent.Text = model.Content;
        rblIsDisabled.SelectedValue = model.IsDisabled.ToString();
        rblIsOpenLink.SelectedValue = model.IsOpenLink.ToString();
        txtMiniHitCount.Text = model.MiniHitCount.ToString();
        rblIsOpened.SelectedValue = model.IsOpened.ToString();
        foreach (ListItem li in cblGroupIdStr.Items)
        {
            int groupId = int.Parse(li.Value);
            M_UserGroup userGroupModel = GroupBll.GetModel(groupId);
            string power = userGroupModel.ColumnPower;
            if (GroupBll.Power_ColumnPower(ChId, 0, power, 2))
            {
                li.Selected = true;
            }
        }
        ddlVerifyType.SelectedValue = model.VerifyType.ToString();
        txtNotice1.Text = model.Notice1;
        txtNotice2.Text = model.Notice2;
        rblIsStaticType.SelectedValue = model.IsStaticType.ToString();
        ddlColumnSortType.SelectedValue = model.ColumnSortType.ToString();
        ddlInfoSortType.SelectedValue = model.InfoSortType.ToString();
        ddlFileNameType.SelectedValue = model.FileNameType.ToString();
        rblChannelPageType.SelectedValue = model.ChannelPageType.ToString();
        rblColumnPageType.SelectedValue = model.ColumnPageType.ToString();
        rblInfoPageType.SelectedValue = model.InfoPageType.ToString();
        txtSort.Text = model.Sort.ToString();
    }
    #endregion
 
}
