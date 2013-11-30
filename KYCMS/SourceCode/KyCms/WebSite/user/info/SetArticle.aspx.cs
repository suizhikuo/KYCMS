using System;
using System.Data;
using System.Configuration;
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
using Ky.BLL.CommonModel;

public partial class User_Info_SetArticle : System.Web.UI.Page
{
    protected int Id = 0;
    protected int ChId = 0;
    protected int ColId = 0;
    M_Article ArticleModel = new M_Article();
    M_Column ColumnModel = null;
    protected M_Channel ChannelModel = null;
    protected M_UserGroup UserGroupModel = null;
    M_User UserModel = new M_User();
    B_Article ArticleBll = new B_Article();
    B_Channel ChannelBll = new B_Channel();
    B_User UserBll = new B_User();
    protected B_UserGroup UserGroupBll = new B_UserGroup();
    B_SiteInfo SiteBll = new B_SiteInfo();
    protected M_Site SiteModel = null;
    protected B_Column ColumnBll = new B_Column();
    M_InfoModel InfoModel = null;
    B_InfoModel InfoModelBll = new B_InfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        litMsg.Text = "";
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        UserGroupModel = UserGroupBll.GetModel(UserModel.GroupID);

        SiteModel = SiteBll.GetSiteModel();
        if (SiteModel == null)
            Function.ShowMsg(0, "<li>全站参数获取错误</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            ChId = int.Parse(Request.QueryString["ChId"]);
        }
        ChannelModel = ChId <= 0 ? null : ChannelBll.GetChannel(ChId);
        if (ChannelModel == null || ChId <= 0 || ChannelModel.ModelType != 1)
            Function.ShowMsg(0, "<li>频道参数错误</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        if (!UserGroupBll.Power_ColumnPower(ChId, 0, UserGroupModel.ColumnPower, 3))
            Function.ShowMsg(0, "<li>本频道没有添加" + ChannelModel.TypeName + "的权限</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        if (!ColumnBll.ChkHasColumnByChId(ChId))
            Function.ShowMsg(0, "<li>本频道下没有栏目，不能添加" + ChannelModel.TypeName + "</li><li><a href='javascript:history.back()'>返回上一级</a></li>");

        M_InfoModel infoModel = new M_InfoModel();
        B_InfoModel infoModelBll = new B_InfoModel();
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            ColId = Convert.ToInt32(Request.QueryString["ColId"]);
        }
        ColumnModel = ColId <= 0 ? null : ColumnBll.GetColumn(ColId);
        if (ColId > 0 && ColumnModel == null)
            Function.ShowMsg(0, "<li>所选栏目不存在或已经被删除</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
         InfoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
         FilePicPath.Text = InfoModel.UploadPath + "|" + InfoModel.UploadSize.ToString();
      if (!IsPostBack)
        {
            UserCateBound();
            if (Id > 0)
            {
                ShowInfo(Id);
            }
        }
    }


    #region 设置稿件信息
    protected void btnAddCateSave_Click(object sender, EventArgs e)
    {
        bool checkForm = CheckValidate();
        if (checkForm)
        {
            if (Id > 0)
            {
                ArticleModel = ArticleBll.GetArticle(Id);
            }
            ArticleModel.Id = Id;
            ArticleModel.ShortContent = SiteBll.GetFiltering(txtShortContent.Text.Trim());
            ArticleModel.ColId = Int32.Parse(Request.Form["ddlColId"].ToString());
            ArticleModel.Title = txtTitle.Text.Trim();
            ArticleModel.LongTitle = txtTitle.Text.Trim();
            ArticleModel.UserCateId = Convert.ToInt32(ddlUserCate.SelectedValue.Trim());
            #region 关键字
            string tagIdStr = string.Empty;
            string nameStr = txtTagNameStr.Text.Trim();
            if (nameStr.Length != 0)
            {
                if (nameStr.StartsWith("|"))
                    nameStr = nameStr.Substring(1, nameStr.Length - 1);
                if (nameStr.EndsWith("|"))
                    nameStr = nameStr.Substring(0, nameStr.Length - 1);
                B_Tag tagBll = new B_Tag();
                DataRow dr = tagBll.AddTagStr(nameStr, ChannelModel.ModelType, UserBll.GetCookie().UserID, UserBll.GetCookie().LogName);
                if (dr != null)
                {
                    tagIdStr = "|" + dr[0] + "|";
                    nameStr = "|" + dr[1] + "|";
                }
                else
                {
                    tagIdStr = "";
                    nameStr = "";
                }
            }
            ArticleModel.TagIdStr = tagIdStr;
            ArticleModel.TagNameStr = nameStr;
            #endregion
            //保存状态Status
            if (((Button)sender).ID == "btnSaveCaoGao")
            {
                ArticleModel.Status = -1;
            }
            else if (((Button)sender).ID == "btnAddCateSave")
            {
                if (ChannelModel != null)
                {
                    if (ChannelModel.VerifyType == 0)
                    {
                        ArticleModel.Status = 3;
                    }
                }
                else
                {
                    ArticleModel.Status = 0;
                }
            }
            ArticleModel.Author = txtAuthor.Text.Trim();
            ArticleModel.Source = txtSource.Text.Trim();
            ArticleModel.ShortContent = SiteBll.GetFiltering(txtShortContent.Text.Trim());
            //录入者ID ，通过传值得到
            ArticleModel.UId = UserModel.UserID;
            //录入者用户名，通过传值得到
            ArticleModel.UName = UserModel.LogName;
            ArticleModel.UserType = 0;
            ArticleModel.TitleType = 1;

            ArticleModel.Content = SiteBll.GetFiltering(txtContent.Value);
            ArticleModel.Content = ArticleModel.Content.Replace(@"<div style=""page-break-after: always""><span style=""display: none"">&nbsp;</span></div>", "{Ky:PAGE}");
            ArticleModel.PointCount = Convert.ToInt32(txtPoint.Text.Trim());
            ArticleModel.AddTime = DateTime.Now;
            ArticleModel.UpdateTime = DateTime.Now;
            ArticleModel.ExpireTime = Convert.ToDateTime("9999-01-01");
            ArticleModel.ViewEndTime = DateTime.Now.AddDays(10).ToString();
            ArticleModel.IsOpened = Convert.ToInt32(hfIsOpened.Value);
            #region 继承栏目相关设置
            if (Id <= 0)
            {
                if (!string.IsNullOrEmpty(Request.Form["ddlColId"]) && Request.Form["ddlColId"] != "-1")
                {
                    ColumnModel = ColumnBll.GetColumn(int.Parse(Request.Form["ddlColId"].ToString()));
                    ArticleModel.TemplatePath = ColumnModel.InfoTemplatePath;
                    ArticleModel.PageType = ColumnModel.InfoPageType;
                    ArticleModel.ChargeType = ColumnModel.ChargeType;
                    ArticleModel.ChargeHourCount = ColumnModel.ChargeHourCount;
                    ArticleModel.ChargeViewCount = ColumnModel.ChargeViewCount;
                    ArticleModel.IsAllowComment = ColumnModel.IsAllowComment;
                }
                // ArticleModel.HitCount = 0;
            }
            #endregion
            //保存
            if (Id > 0)
                ArticleBll.Update(ArticleModel);
            else
            {
                ArticleBll.Add(ArticleModel);
                    #region 增加积分
                //如果频道不需要审核,添加积分
                if (ChannelModel.VerifyType == 0)
                {
                    if (UserModel == null)
                        return;
                    if (UserGroupBll == null)
                        return;
                    string scale = UserGroupBll.Power_UserGroup("Contribute", 0, UserGroupModel.GroupPower);
                    int score = int.Parse(scale) * ColumnModel.ScoreReward;
                    B_Money moneyBll = new B_Money();
                    moneyBll.Integral(score, UserModel.UserID);
                }
                    #endregion
            }
            Response.Redirect("InfoList.aspx?ChId=" + ChId + "&ColId=" + ArticleModel.ColId);
        }
    }
    #endregion

    #region 根据稿件编号获取稿件信息
    private void ShowInfo(int articleId)
    {
        ArticleModel = ArticleBll.GetArticle(articleId);
        hfIsOpened.Value = ArticleModel.IsOpened.ToString();
        if (ArticleModel == null)
            Function.ShowMsg(0, "<li>所选" + ChannelModel.TypeName + "不存在或已经被删除</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        if (ArticleModel.Status == 1 || ArticleModel.Status == 2 || ArticleModel.Status == 3)
            Function.ShowMsg(0, "<li>你没有修改此稿件的权限</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        txtTitle.Text = ArticleModel.Title.Trim();
        txtAuthor.Text = ArticleModel.Author.Trim();
        txtSource.Text = ArticleModel.Source.Trim();
        string tagNameStr = ArticleModel.TagNameStr;
        if (tagNameStr != string.Empty && tagNameStr.StartsWith("|") && tagNameStr.EndsWith("|"))
        {
            tagNameStr = tagNameStr.Substring(0, tagNameStr.Length - 1);
            tagNameStr = tagNameStr.Substring(1, tagNameStr.Length - 1);
        }
        txtTagNameStr.Text = tagNameStr;
        ddlUserCate.SelectedValue = ArticleModel.UserCateId.ToString();
        txtShortContent.Text = ArticleModel.ShortContent.Trim();
        B_ConvertImage convertBll = new B_ConvertImage(SiteModel.Domain, InfoModel.UploadPath);
        txtContent.Value = convertBll.ConvertContent(ArticleModel.Content);
        txtContent.Value = txtContent.Value.Replace("{Ky:PAGE}", @"<div style=""page-break-after: always""><span style=""display: none"">&nbsp;</span></div>");

        txtPoint.Text = ArticleModel.PointCount.ToString().Trim();
        btnAddCateSave.Visible = false;
        btnSaveCaoGao.Visible = false;
        btnUpdate.Visible = true;
    }
    #endregion

    #region 绑定专栏列表
    private void UserCateBound()
    {
        B_User userBll = new B_User();
        DataTable dt = userBll.GetUserCateList(UserModel.UserID, ChannelModel.ModelType);
        ddlUserCate.DataTextField = "CateName";
        ddlUserCate.DataValueField = "UserCateId";
        ddlUserCate.DataSource = dt;
        ddlUserCate.DataBind();
        ddlUserCate.Items.Insert(0, new ListItem("请选择专栏", "-1"));
    }
    #endregion

    #region  验证文本框输入是否合法
    private bool CheckValidate()
    {
        const string numPattern = @"\d+$";

        if (txtTitle.Text.Trim() == "")
        {
            litMsg.Text = "<script>alert('稿件标题必须填写');</script>";
            return false;
        }
        if (Request.Form["ddlColId"].ToString() == "-1")
        {
            litMsg.Text = "<script>alert('请选择栏目');</script>";
            return false;
        }
        //稿件内容
        if (txtContent.Value.Trim() == "")
        {
            litMsg.Text = "<script>alert('稿件内容必须填写');</script>";
            return false;
        }
        //阅读收取金币数
        if (txtPoint.Text.Trim() == "")
        {
            litMsg.Text = "<script>alert('阅读收取金币数必须填写');</script>";
            return false;
        }
        if (Regex.IsMatch(txtPoint.Text.Trim(), numPattern))
        {
            if (int.Parse(txtPoint.Text.Trim()) < 0)
            {
                litMsg.Text = "<script>alert('请输入正确的阅读收取金币数');</script>";
                return false;
            }
        }
        return true;
    }
    #endregion

}
