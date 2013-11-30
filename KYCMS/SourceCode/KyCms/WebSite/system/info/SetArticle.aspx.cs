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
using Ky.SQLServerDAL;
using Ky.Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class InfoManage_SetArticle : System.Web.UI.Page
{
    protected int ArticleId = 0;
    protected int ChannelId = 0;
    protected int ColumnId = 0;
    B_Channel ChannelBll = new B_Channel();
    protected B_Column ColumnBll = new B_Column();
    B_Admin AdminBll = new B_Admin();
    M_LoginAdmin AdminModel = null;
    protected M_Channel ChannelModel = null;
    protected M_Column ColumnModel = null;
    protected M_Site SiteModel = new M_Site();
    protected M_InfoSite InfoSiteModel = null;
    protected B_SiteInfo SiteBll = new B_SiteInfo();
    B_Create CreateBll = new B_Create();
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected M_Admin AdminUserModel = null;
    protected int HistoryTime = 0;
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        AdminModel = AdminBll.GetLoginModel();
        AdminUserModel = AdminBll.GetModel(AdminModel.UserId);

        litMsg.Text = "";
        SiteModel = SiteBll.GetSiteModel();
        InfoSiteModel = SiteBll.GetInfoModel();
        if (SiteModel == null)
        {
            Function.ShowSysMsg(0, "<li>全站参数获取错误</li>");
        }
        txtTemplatePath.Attributes.Add("readonly", "");
        txtUpdateDateTime.Attributes.Add("readonly", "");
        txtHeaderColor.Attributes.Add("readonly", "");
        txtViewer.Attributes.Add("readonly", "");
        HistoryTime = InfoSiteModel.HistoryTime;
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChannelId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        if (!ColumnBll.ChkHasColumnByChId(ChannelId))
        {
            Function.ShowSysMsg(0, "<li>本频道下没有栏目，不能添加信息</li><li>建议您先添加栏目</li><li><a href='info/SetColumn.aspx?ChId=" + ChannelId + "'>添加栏目</a> <a href='info/ColumnList.aspx?ChId=" + ChannelId + "'>栏目管理</a></li>");
        }
        ChannelModel = ChannelId <= 0 ? null : ChannelBll.GetChannel(ChannelId);
        if (ChannelModel == null || ChannelModel.ModelType != 1)
        {
            Function.ShowSysMsg(0, "<li>频道参数错误</li>");
        }
        //保存路径
        InfoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
        FilePicPath.Text = InfoModel.UploadPath + "|" + InfoModel.UploadSize.ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColumnId = int.Parse(Request.QueryString["ColId"]);
            }
            catch { }
        }
        ColumnModel = ColumnId <= 0 ? null : ColumnBll.GetColumn(ColumnId);
        if (ColumnId > 0 && ColumnModel == null)
        {
            Function.ShowSysMsg(0, "<li>所选栏目不存在或已经被删除</li>");
        }


        if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
        {
            try
            {
                ArticleId = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (ArticleId > 0 && !AdminGroupBll.Power_Channel(ChannelId, ColumnId, AdminUserModel.GroupId, 3))
        {
            Function.ShowSysMsg(0, "<li>你没有该栏目下的修改权限</li>");
        }
        if (!IsPostBack)
        {
            txtUpdateDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (HistoryTime == 0)
            {
                txtExpireTime.Text = "9999-01-01";
            }
            else
            {
                txtExpireTime.Text = DateTime.Now.AddDays(HistoryTime).ToString("yyyy-MM-dd");
            }
            for (int i = 0; i <= 20; i++)
            {
                ddlHeaderSize.Items.Add(new ListItem(i + "px", i + "px"));
                ddlHeaderSize.SelectedValue = "12px";
            }
            if (ArticleId > 0)
                litNav.Text = "<a href='ColumnList.aspx?Chid=" + ChannelId + "'>" + ChannelModel.ChName + "</a> &gt;&gt; 修改" + ChannelModel.TypeName;
            else
                litNav.Text = "<a href='ColumnList.aspx?Chid=" + ChannelId + "'>" + ChannelModel.ChName + "</a> &gt;&gt; 添加" + ChannelModel.TypeName;
            BindSpeacil();
            BindGroup();
            if (ArticleId > 0)
            {
                ShowInfo(ArticleId);
            }
        }
    }

    #region 绑定用户组
    private void BindGroup()
    {
        B_UserGroup groupBll = new B_UserGroup();
        DataTable dt = groupBll.ManageList("");
        chkBoxGroupIdStr.DataTextField = "UserGroupName";
        chkBoxGroupIdStr.DataValueField = "UserGroupId";
        chkBoxGroupIdStr.DataSource = dt;
        chkBoxGroupIdStr.DataBind();
    }
    #endregion

    #region 根据文章编号获取文章信息
    private void ShowInfo(int ArticleId)
    {
        #region 文章基本信息修改
        B_Article ArticleBll = new B_Article();
        M_Article Articlemodel = ArticleBll.GetArticle(ArticleId);
        if (Articlemodel == null || Articlemodel.Status == -1)
        {
            Function.ShowSysMsg(0, "<li>所选文章不存在或已经被删除</li>");
        }
        txtAuthor.Text = Articlemodel.Author;
        //重复收费方式
        switch (Articlemodel.ChargeType)
        {
            case 1:
                rdBtnChargeType1.Checked = true;
                break;
            case 2:
                txtChargeHourCount.Text = Articlemodel.ChargeHourCount.ToString();
                rdBtnChargeType2.Checked = true;
                break;
            case 3:
                rdBtnChargeType3.Checked = true;
                txtChargeViewCount.Text = Articlemodel.ChargeViewCount.ToString();
                break;
            case 4:
                txtChargeHourCount.Text = Articlemodel.ChargeHourCount.ToString();
                txtChargeViewCount.Text = Articlemodel.ChargeViewCount.ToString();
                rdBtnChargeType4.Checked = true;
                break;
            case 5:
                txtChargeHourCount.Text = Articlemodel.ChargeHourCount.ToString();
                txtChargeViewCount.Text = Articlemodel.ChargeViewCount.ToString();
                rdBtnChargeType5.Checked = true;
                break;
            case 6:
                rdBtnChargeType6.Checked = true;
                break;
        }
        B_ConvertImage convertBll = new B_ConvertImage(SiteModel.Domain, InfoModel.UploadPath);
        txtContent.Value = convertBll.ConvertContent(Articlemodel.Content);
        txtContent.Value = txtContent.Value.Replace("{Ky:PAGE}", @"<div style=""page-break-after: always""><span style=""display: none"">&nbsp;</span></div>");

        rdBtnPageType.SelectedValue = Articlemodel.PageType.ToString();
        txtUpdateDateTime.Text = DateTime.Now.ToString();

        //添加时间
        txtAddTime.Text = Articlemodel.AddTime.ToString();
        txtExpireTime.Text = Articlemodel.ExpireTime.ToString("yyyy-MM-dd");

        if (Articlemodel.ViewEndTime != "")
            txtViewEndTime.Text = Convert.ToDateTime(Articlemodel.ViewEndTime).ToString("yyyy-MM-dd");

        rdBtnIsOpened.SelectedValue = Articlemodel.IsOpened.ToString();
        foreach (ListItem li in chkBoxGroupIdStr.Items)
        {
            if (Articlemodel.GroupIdStr.IndexOf("|" + li.Value + "|") != -1)
                li.Selected = true;
        }
        txtHitCount.Text = Articlemodel.HitCount.ToString();
        txtOuterUrl.Text = Articlemodel.OuterUrl;
        if (txtOuterUrl.Text.Trim() != string.Empty)
        {
            rbOuter.Checked = true;
        }
        chkBoxIsAllowComment.Checked = Articlemodel.IsAllowComment;

        chkBoxIsFocus.Checked = Articlemodel.IsFocus;
        chkBoxIsHeader.Checked = Articlemodel.IsHeader;
        chkBoxIsIrregular.Checked = Articlemodel.IsIrregular;
        chkBoxIsRecommend.Checked = Articlemodel.IsRecommend;
        IsShowCommentLink.Checked = Articlemodel.IsShowCommentLink;
        chkBoxIsSideShow.Checked = Articlemodel.IsSideShow;
        chkBoxIsTop.Checked = Articlemodel.IsTop;
        txtPointCount.Text = Articlemodel.PointCount.ToString();
        txtShortContent.Text = Articlemodel.ShortContent;
        txtSource.Text = Articlemodel.Source;
        try
        {
            ddlStarLevel.SelectedValue = Articlemodel.StarLevel.ToString();
        }
        catch { }
        //关键字
        string tagNameStr = string.Empty;
        tagNameStr = Articlemodel.TagNameStr;
        //Response.End();
        if (!string.IsNullOrEmpty(tagNameStr))
        {
            if (tagNameStr.StartsWith("|") && tagNameStr.EndsWith("|"))
            {
                tagNameStr = tagNameStr.Substring(0, tagNameStr.Length - 1);
                tagNameStr = tagNameStr.Substring(1, tagNameStr.Length - 1);
            }
        }
        tagNameStr = tagNameStr.Replace("|", " ");
        txtTagNameStr.Text = tagNameStr;
        txtTemplatePath.Text = Articlemodel.TemplatePath;
        txtTitle.Text = Articlemodel.Title;
        txtLongTitle.Text = Articlemodel.LongTitle;
        txtTitleColor.Text = Articlemodel.TitleColor.ToString();
        ddlTitleFontType.SelectedValue = Articlemodel.TitleFontType.ToString();
        switch (int.Parse(Articlemodel.TitleType.ToString()))
        {
            case 1:
                rbComm.Checked = true;
                break;
            case 2:
                rbImg.Checked = true;
                txtTitleImgPath.Text = Articlemodel.TitleImgPath;
                break;
        }
        //文章所属专题
        string[] arraySpecialIdStr = Articlemodel.SpecialIdStr.Split('|');
        for (int i = 0; i < arraySpecialIdStr.Length; i++)
        {
            for (int j = 0; j < lBoxTopicIdStr.Items.Count; j++)
            {
                if (lBoxTopicIdStr.Items[j].Value == arraySpecialIdStr[i])
                {
                    lBoxTopicIdStr.Items[j].Selected = true;
                }
            }
        }

        //签收用户
        string viewUName = Articlemodel.ViewUName;
        if (viewUName != string.Empty && viewUName.StartsWith("|") && viewUName.EndsWith("|"))
        {
            viewUName = viewUName.Substring(0, viewUName.Length - 1);
            viewUName = viewUName.Substring(1, viewUName.Length - 1);
            txtViewer.Text = viewUName;
        }
        txtViewer.Text = viewUName;
        //头条文章属性设置
        if (Articlemodel.HeaderFont.Length != 0)
        {
            string[] headerArray = Articlemodel.HeaderFont.Split('|');
            txtHeaderFont.Text = headerArray[0];
            ddlHeaderProPerty.SelectedValue = headerArray[1];
            ddlHeaderSize.SelectedValue = headerArray[2];
            txtHeaderColor.Text = headerArray[3];
        }
        txtHeaderImgPath.Value = Articlemodel.HeaderImgPath;
        #endregion

        btnAddNewsSave.Text = "确定修改";
    }
    #endregion

    #region 设置文章信息及保存
    protected void AddNewsBtn_Click(object sender, EventArgs e)
    {
        bool checkForm = CheckValidate();
        if (checkForm)
        {
            M_Article Articlemodel = new M_Article();
            Articlemodel.Id = ArticleId;
            #region 所有情况下
            Articlemodel.Author = txtAuthor.Text.Trim();
            if (!string.IsNullOrEmpty(Request.Form["ddlColId"]))
                Articlemodel.ColId = int.Parse(Request.Form["ddlColId"]);

            //添加时间
            if (txtAddTime.Text.Trim().Length != 0)
            {
                if (Function.IsDate(txtAddTime.Text.Trim().ToString()))
                    Articlemodel.AddTime = DateTime.Parse(txtAddTime.Text.Trim().ToString());
                else
                    Function.ShowSysMsg(0, "<li>你输入的日期格式不对</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            else
                Articlemodel.AddTime = DateTime.Now;

            Articlemodel.ExpireTime = Convert.ToDateTime(txtExpireTime.Text.Trim());
            Articlemodel.ViewEndTime = txtViewEndTime.Text.Trim();
            Articlemodel.UpdateTime = DateTime.Now;
            Articlemodel.ShortContent = SiteBll.GetFiltering(txtShortContent.Text.Trim());
            Articlemodel.Source = txtSource.Text.Trim();
            #region 关键字

            string tagIdStr = string.Empty;
            string nameStr = txtTagNameStr.Text.Trim();
            nameStr = Regex.Replace(nameStr, @"\s+", "|", RegexOptions.IgnoreCase);
            if (nameStr.Length != 0)
            {
                if (nameStr.StartsWith("|"))
                    nameStr = nameStr.Substring(1, nameStr.Length - 1);
                if (nameStr.EndsWith("|"))
                    nameStr = nameStr.Substring(0, nameStr.Length - 1);
                B_Tag tagBll = new B_Tag();
                DataRow dr = tagBll.AddTagStr(nameStr, ChannelModel.ModelType, 0, "后台管理员");
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
            Articlemodel.TagIdStr = tagIdStr;
            Articlemodel.TagNameStr = nameStr;
            #endregion
            Articlemodel.IsFocus = chkBoxIsFocus.Checked;
            Articlemodel.IsHeader = chkBoxIsHeader.Checked;
            Articlemodel.IsIrregular = chkBoxIsIrregular.Checked;
            Articlemodel.IsRecommend = chkBoxIsRecommend.Checked;
            Articlemodel.IsShowCommentLink = IsShowCommentLink.Checked;
            Articlemodel.IsSideShow = chkBoxIsSideShow.Checked;
            Articlemodel.IsTop = chkBoxIsTop.Checked;

            Articlemodel.Title = SiteBll.GetFiltering(txtTitle.Text.Trim());
            Articlemodel.LongTitle = SiteBll.GetFiltering(txtLongTitle.Text.Trim());
            Articlemodel.TitleColor = txtTitleColor.Text.Trim();
            Articlemodel.TitleFontType = Int32.Parse(ddlTitleFontType.SelectedValue.Trim());
            Articlemodel.UId = AdminModel.UserId;
            Articlemodel.UName = AdminModel.LoginName;
            Articlemodel.AdminUId = AdminModel.UserId;
            Articlemodel.AdminUName = AdminModel.AdminName;
            Articlemodel.UserType = 1;
            Articlemodel.Status = 3;
            //头条文章属性设置
            Articlemodel.HeaderFont = txtHeaderFont.Text.Trim() + "|" + ddlHeaderProPerty.SelectedValue + "|" + ddlHeaderSize.SelectedValue + "|" + txtHeaderColor.Text.Trim();
            Articlemodel.HeaderImgPath = txtHeaderImgPath.Value;
            #endregion
            if (rbOuter.Checked == true)
            {
                Articlemodel.OuterUrl = txtOuterUrl.Text.Trim();
            }
            #region 不是外部链接地址情况
    
                if (rbComm.Checked == true)
                {
                    Articlemodel.TitleType = 1;
                }
                else if (rbImg.Checked == true)
                {
                    Articlemodel.TitleType = 2;
                    Articlemodel.TitleImgPath = Request.Form["txtTitleImgPath"].Trim();
                }
            if (!rbOuter.Checked)
            {
                if (Request.Form["ChargeTypeRadioButtonList"] == "2")
                    Articlemodel.ChargeHourCount = Int32.Parse(txtChargeHourCount.Text.Trim());
                //重复收费方式
                if (rdBtnChargeType1.Checked)
                    Articlemodel.ChargeType = 1;
                if (rdBtnChargeType2.Checked)
                {
                    Articlemodel.ChargeType = 2;
                    Articlemodel.ChargeHourCount = Int32.Parse(txtChargeHourCount.Text.Trim());
                }
                if (rdBtnChargeType3.Checked)
                {
                    Articlemodel.ChargeType = 3;
                    Articlemodel.ChargeViewCount = Int32.Parse(txtChargeViewCount.Text.Trim());
                }
                if (rdBtnChargeType4.Checked)
                {
                    Articlemodel.ChargeType = 4;
                    Articlemodel.ChargeHourCount = Int32.Parse(txtChargeHourCount.Text.Trim());
                    Articlemodel.ChargeViewCount = Int32.Parse(txtChargeViewCount.Text.Trim());
                }
                if (rdBtnChargeType5.Checked)
                {
                    Articlemodel.ChargeType = 5;
                    Articlemodel.ChargeHourCount = Int32.Parse(txtChargeHourCount.Text.Trim());
                    Articlemodel.ChargeViewCount = Int32.Parse(txtChargeViewCount.Text.Trim());
                }
                if (rdBtnChargeType6.Checked)
                    Articlemodel.ChargeType = 6;
                B_ConvertImage convertBll = new B_ConvertImage(SiteModel.Domain, InfoModel.UploadPath);
                if (chkBoxRemoteSaveImage.Checked)
                {

                    txtContent.Value = convertBll.ConvertLocalImagePath(txtContent.Value);

                }
                else
                {
                    txtContent.Value = convertBll.ConvertImgePath(txtContent.Value);
                }
                Articlemodel.Content = SiteBll.GetFiltering(txtContent.Value);
                Articlemodel.Content = Articlemodel.Content.Replace(@"<div style=""page-break-after: always""><span style=""display: none"">&nbsp;</span></div>", "{Ky:PAGE}");
                //生成的格式
                Articlemodel.PageType = int.Parse(rdBtnPageType.SelectedValue);
                Articlemodel.IsOpened = int.Parse(rdBtnIsOpened.SelectedValue.Trim());
                if (Articlemodel.IsOpened == 0)
                {
                    string groupIdstr = string.Empty;
                    foreach (ListItem li in chkBoxGroupIdStr.Items)
                    {
                        if (li.Selected)
                        {
                            groupIdstr += li.Value + "|";
                        }
                    }
                    Articlemodel.GroupIdStr = "|" + groupIdstr;
                }
                else { Articlemodel.GroupIdStr = ""; }
                Articlemodel.HitCount = Int32.Parse(txtHitCount.Text.Trim());
                Articlemodel.IsAllowComment = chkBoxIsAllowComment.Checked;
                Articlemodel.PointCount = Int32.Parse(txtPointCount.Text.Trim());
                Articlemodel.StarLevel = ddlStarLevel.SelectedValue.Trim();
                //文章所属数据表 Articlemodel.TableName="";
                Articlemodel.TemplatePath = Request.Form["txtTemplatePath"].Trim();
                //文章所属专题
                string idStr = string.Empty;
                for (int i = 0; i < lBoxTopicIdStr.Items.Count; i++)
                {
                    if (lBoxTopicIdStr.Items[i].Selected)
                    {
                        idStr += lBoxTopicIdStr.Items[i].Value + "|";
                    }
                }
                if (idStr != "")
                    Articlemodel.SpecialIdStr = "|" + idStr;
                else
                    Articlemodel.SpecialIdStr = "";
                if (txtViewer.Text.Trim() != string.Empty)
                {
                    Articlemodel.ViewUName = "|" + txtViewer.Text.Trim() + "|";
                    if (txtViewEndTime.Text.Trim() == "")
                    {
                        litMsg.Text = "<script>alert('签收结束时间必须填写');</script>";
                        return;
                    }
                }
                else
                    Articlemodel.ViewUName = string.Empty;
            }
            #endregion

            #region 保存

            if (!CheckValidate())
            {
                return;
            }
            B_Article AddArticle = new B_Article();
            if (ArticleId > 0)
            {
                //返回文章ID
                ArticleId = AddArticle.Update(Articlemodel);
            }
            else
            {
                ArticleId = AddArticle.Add(Articlemodel);
            }
            if (chkBoxIsCreate.Checked)
            {
                DataRow dr = CreateBll.GetInfoById("kyarticle", ArticleId);
                CreateBll.CreateSingleInfo(dr);
            }
            Response.Redirect("InfoList.aspx?ChId=" + ChannelId + "&ColId=" + Articlemodel.ColId);


            #endregion  保存
        }
    }
    #endregion 设置文章信息及保存

    #region  绑定专题
    public void BindSpeacil()
    {
        B_Special specialBll = new B_Special();
        lBoxTopicIdStr.Items.Clear();
        DataTable dt = specialBll.GetChannelSpecial(ChannelId);
        DataView dvParent = new DataView(dt);
        dvParent.RowFilter = "ParentId=0";
        for (int i = 0; i < dvParent.Count; i++)
        {
            int parentId = Convert.ToInt32(dvParent[i]["Id"]);
            lBoxTopicIdStr.Items.Add(new ListItem(dvParent[i]["SpecialCName"].ToString(), parentId.ToString()));
            DataView dvChild = new DataView(dt);
            dvChild.RowFilter = "ParentId=" + parentId;
            for (int j = 0; j < dvChild.Count; j++)
            {
                lBoxTopicIdStr.Items.Add(new ListItem("└" + dvChild[j]["SpecialCName"], dvChild[j]["Id"].ToString()));
            }
        }
    }

    #endregion

    #region  验证文本框输入是否合法
    private bool CheckValidate()
    {
        const string datePattern = @"\d{4}-\d{1,2}-\d{1,2}$";
        const string numPattern = @"\d+$";
        const string pattUrl = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        //判断所选栏目是否允许添加文章
        int colId = Convert.ToInt32(Request.Form["ddlColId"]);
        if (colId == 0)
        {
            litMsg.Text = "<script>alert('请选择栏目');</script>";
            return false;
        }
        bool flag = ColumnBll.ChkHasChildByColId(colId);
        if ((flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo) || !AdminGroupBll.Power_Channel(ChannelId, colId, AdminUserModel.GroupId, 2))
        {
            litMsg.Text = "<script>alert('所选择的栏目不能添加" + ChannelModel.TypeName + "');</script>";
            return false;
        }

        if (txtTitle.Text.Trim() == "")
        {
            litMsg.Text = "<script>alert('该" + ChannelModel.TypeName + "标题必须填写');</script>";
            return false;
        }
        if (rbImg.Checked)
        {
            if (Request.Form["txtTitleImgPath"].Trim() == "")
            {
                litMsg.Text = "<script>alert('图片地址必须填写');</script>";
                return false;
            }
        }
        if (rbOuter.Checked)
        {
            if (txtOuterUrl.Text.Trim() == "")
            {
                litMsg.Text = "<script>alert('" + ChannelModel.TypeName + "的链接URL必须填写');</script>";
                return false;
            }
            if (!Regex.IsMatch(txtOuterUrl.Text.Trim(), pattUrl))
            {
                litMsg.Text = "<script>alert('请正确填写" + ChannelModel.TypeName + "的链接URL');</script>";
                return false;
            }
        }
        //文章内容
        if (!rbOuter.Checked)
        {
            if (txtContent.Value.Length == 0)
            {
                litMsg.Text = "<script>alert('" + ChannelModel.TypeName + "内容必须填写');</script>";
                return false;
            }
            //阅读点数
            if (txtPointCount.Text.Trim() == "")
            {
                litMsg.Text = "<script>alert('阅读点数必须填写');</script>";
                return false;
            }
            if (Regex.IsMatch(txtPointCount.Text.Trim(), numPattern))
            {
                if (int.Parse(txtPointCount.Text.Trim()) < 0)
                {
                    litMsg.Text = "<script>alert('请输入正确的阅读点数');</script>";
                    return false;
                }
            }
            else
            {
                litMsg.Text = "<script>alert('请输入正确的阅读点数');</script>";
                return false;
            }
            //点击数
            if (txtHitCount.Text.Trim() == "")
            {
                litMsg.Text = "<script>alert('点击数必须填写');</script>";
                return false;
            }
            if (Regex.IsMatch(txtHitCount.Text.Trim(), numPattern))
            {
                if (int.Parse(txtHitCount.Text.Trim()) < 0)
                {
                    litMsg.Text = "<script>alert('点击数必须为非负数');</script>";
                    return false;
                }
            }
            else
            {
                litMsg.Text = "<script>alert('点击数必须为非负数');</script>";
                return false;
            }
            //更新/过期时间
            if (txtExpireTime.Text.Trim() == "")
            {
                litMsg.Text = "<script>alert('归档时间必须填写');</script>";
                return false;
            }
            if (!Regex.IsMatch(txtExpireTime.Text.Trim(), datePattern))
            {
                litMsg.Text = "<script>alert('请输入正确的归档时间(2008-08-08)');</script>";
                return false;
            }

            if (!Regex.IsMatch(txtViewEndTime.Text.Trim(), datePattern) && txtViewEndTime.Text.Trim() != "")
            {
                litMsg.Text = "<script>alert('请输入正确的签收结束时间(2008-08-08)');</script>";
                return false;
            }
            if (Request.Form["txtTemplatePath"].Trim() == "")
            {
                litMsg.Text = "<script>alert('模板路径必须填写');</script>";
                return false;
            }

            // 重复收费方式
            if (rdBtnChargeType2.Checked)
            {
                if (txtChargeHourCount.Text.Trim() == "")
                {
                    litMsg.Text = "<script>alert('请输入距离上次收费时间');</script>";
                    return false;
                }
                if (Regex.IsMatch(txtChargeHourCount.Text.Trim(), numPattern))
                {
                    if (int.Parse(txtChargeHourCount.Text.Trim()) < 0)
                    {
                        litMsg.Text = "<script>alert('请正确输入'距离上次收费时间后重新收费的小时数'');</script>";
                        return false;
                    }
                }
                else
                {
                    litMsg.Text = "<script>alert('请正确输入'距离上次收费时间后重新收费的小时数'');</script>";
                    return false;
                }
            }
            if (rdBtnChargeType3.Checked)
            {
                if (txtChargeViewCount.Text.Trim() == "")
                {
                    litMsg.Text = "<script>alert('请输入会员重复阅读此文章后重新收费次数');</script>";
                    return false;
                }
                if (Regex.IsMatch(txtChargeViewCount.Text.Trim(), numPattern))
                {
                    if (int.Parse(txtChargeViewCount.Text.Trim()) < 0)
                    {
                        litMsg.Text = "<script>alert('请正确输入'会员重复阅读此文章后重新收费次数'');</script>";
                        return false;
                    }
                }
                else
                {
                    litMsg.Text = "<script>alert('请正确输入'会员重复阅读此文章后重新收费次数'');</script>";
                    return false;
                }
            }
        }
        if (chkBoxIsHeader.Checked)
        {
            if (txtHeaderFont.Text.Trim().Length == 0)
            {
                litMsg.Text = "<script>alert('头条文字必须填写');</script>";
                return false;
            }
            if (txtHeaderColor.Text.Trim().Length == 0)
            {
                litMsg.Text = "<script>alert('头条文字颜色必须选择');</script>";
                return false;
            }
        }

        return true;
    }
    #endregion

}

