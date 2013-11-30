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
using Ky.Model;
using Ky.BLL;
using System.Text.RegularExpressions;
using System.IO;
using Ky.BLL.CommonModel;
using Ky.Common;
public partial class user_info_SetDownLoad : System.Web.UI.Page
{
    protected int Id = 0;
    protected int ChId = 0;
    protected int ColId = 0;

    protected M_Channel ChannelModel = null;
    protected B_Column ColumnBll = new B_Column();
    protected M_UserGroup UserGroupModel = null;
    protected B_UserGroup UserGroupBll = new B_UserGroup();
    protected M_Site SiteModel = new M_Site();
    protected B_SiteInfo SiteBll = new B_SiteInfo();

    B_DownLoadaddress AddressBll = new B_DownLoadaddress();
    B_DownLoad DownLoadBll = new B_DownLoad();
    B_User UserBll = new B_User();
    B_Channel ChannelBll = new B_Channel();
    B_Dictionary DictionaryBll = new B_Dictionary();
    M_User UserModel = new M_User();
    M_DownLoad DownLoadmodel = new M_DownLoad();
    M_Column ColumnModel = null;
    M_DownLoadAddress AddressModel = new M_DownLoadAddress();
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
                Id = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            ChId = int.Parse(Request.QueryString["ChId"]);
        }
        ChannelModel = ChId <= 0 ? null : ChannelBll.GetChannel(ChId);
        if (ChannelModel == null || ChId < 0)
            Function.ShowMsg(0, "<li>频道参数错误</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        if (!UserGroupBll.Power_ColumnPower(ChId, 0, UserGroupModel.ColumnPower, 3))
            Function.ShowMsg(0, "<li>本频道没有添加" + ChannelModel.TypeName + "的权限</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        if (!ColumnBll.ChkHasColumnByChId(ChId))
            Function.ShowMsg(0, "<li>本频道下没有栏目，不能添加" + ChannelModel.TypeName + "</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
            ColId = Convert.ToInt32(Request.QueryString["ColId"]);
        ColumnModel = ColId <= 0 ? null : ColumnBll.GetColumn(ColId);
        if (ColId > 0 && ColumnModel == null)
            Function.ShowMsg(0, "<li>所选栏目不存在或已经被删除</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        B_InfoModel infoModelBll = new B_InfoModel();
        M_InfoModel infoModel = infoModelBll.GetModel(ChannelModel.ModelType);
        FilePicPath.Text = infoModel.UploadPath + "|" + infoModel.UploadSize.ToString();
        if (!IsPostBack)
        {
            UserCateBound();
            ddlBind();
            if (Id > 0)
                ShowInfo(Id);
        }
    }
    protected void ddlBind()
    {
        ddlSoftType.DataSource = DictionaryBll.GetDictionary(27);
        ddlSoftType.DataTextField = ddlSoftType.DataValueField = "DicName";
        ddlSoftType.DataBind();

        ddlSoftLanguage.DataSource = DictionaryBll.GetDictionary(29);
        ddlSoftLanguage.DataTextField = ddlSoftType.DataValueField = "DicName";
        ddlSoftLanguage.DataBind();
        ;

        ddlSoftWarrantType.DataSource = DictionaryBll.GetDictionary(31);
        ddlSoftWarrantType.DataTextField = ddlSoftType.DataValueField = "DicName";
        ddlSoftWarrantType.DataBind();

        DataTable softOsArray = DictionaryBll.GetDictionary(33);
        for (int i = 0; i < softOsArray.Rows.Count; i++)
        {
            Label lb = new Label();
            lb.Text = "<a href=\"javascript:SetDownOS('" + softOsArray.Rows[i]["DicName"].ToString() + "')\">" + softOsArray.Rows[i]["DicName"].ToString() + "</a>/";
            plSoftOs.Controls.Add(lb);
        }
    }

    protected void btnSoftSaveAs_Click(object sender, EventArgs e)
    {
        bool flag = CheckValidate();
        if (flag)
        {
            #region //添加软件
            DownLoadmodel.Id = Id;
            if(Id>0)
            {
                  DownLoadmodel = DownLoadBll.GetDownLoadData(Id);
            }
            if (!string.IsNullOrEmpty(Request.Form["ddlColId"]))
                DownLoadmodel.ColId = int.Parse(Request.Form["ddlColId"]);
            DownLoadmodel.Title = txtSoftName.Text.Trim();
            DownLoadmodel.UserCateId = int.Parse(ddlUserCate.SelectedValue);
            DownLoadmodel.TitleFontType = 0;
            DownLoadmodel.TitleType = 1;

            DownLoadmodel.Edition = txtSoftEdition.Text.Trim();
            DownLoadmodel.PlayAddress = txtSoftPlayAddress.Text.Trim();
            DownLoadmodel.UId = UserModel.UserID;
            DownLoadmodel.UName = UserModel.LogName;
            DownLoadmodel.UserType = 0;

            #region 关键字

            string tagIdStr = string.Empty;
            string nameStr = txtTagName.Text.Trim();
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
            DownLoadmodel.TagIdStr = tagIdStr;
            DownLoadmodel.TagNameStr = nameStr;
            #endregion

            DownLoadmodel.AddTime = DateTime.Now;
            DownLoadmodel.UpdateTime = DateTime.Now;
            if (txtSoftOS.Text.Trim().Length == 0)
                DownLoadmodel.DownLoadOS = "";
            else
                DownLoadmodel.DownLoadOS = "|" + txtSoftOS.Text.Trim() + "|";
            DownLoadmodel.Language = ddlSoftLanguage.SelectedValue;
            DownLoadmodel.WarrantType = ddlSoftWarrantType.SelectedValue;
            DownLoadmodel.RegAddress = txtSoftRegAddress.Text.Trim();

            if (ChannelModel.VerifyType == 0)
                DownLoadmodel.Status = 3;
            else
                DownLoadmodel.Status = 0;
            DownLoadmodel.Content = txtSoftRemark.Text.Trim();
            DownLoadmodel.PointCount = int.Parse(txtSoftPoint.Text.Trim());
            DownLoadmodel.IsDeleted = false;
            DownLoadmodel.DownLoadDisplePwd = txtSoftDisplePwd.Text.Trim();
            DownLoadmodel.DownLoadType = ddlSoftType.SelectedValue;
            DownLoadmodel.DownLoadSize = txtSoftSize.Text.Trim();
            if (Id <= 0)
                DownLoadmodel.IsOpened = 2;
            #region 继承栏目相关设置
            if (Id <= 0)
            {
                if (!string.IsNullOrEmpty(Request.Form["ddlColId"]) && Request.Form["ddlColId"] != "-1")
                {
                    ColumnModel = ColumnBll.GetColumn(int.Parse(Request.Form["ddlColId"].ToString()));
                    DownLoadmodel.TemplatePath = ColumnModel.InfoTemplatePath;
                    DownLoadmodel.PageType = ColumnModel.InfoPageType;
                    DownLoadmodel.ChargeType = ColumnModel.ChargeType;
                    DownLoadmodel.ChargeHourCount = ColumnModel.ChargeHourCount;
                    DownLoadmodel.ChargeViewCount = ColumnModel.ChargeViewCount;
                }
            }
            #endregion
            #endregion
            if (Id > 0)
                Id = DownLoadBll.Update(DownLoadmodel);
            else
                Id = DownLoadBll.Add(DownLoadmodel);
            AddressModel.AddressId = Convert.ToInt32(hfAddressId.Value);
            AddressModel.AddressName = "下载地址1";
            AddressModel.AddressNum = 1;
            AddressModel.AddressPath = txtSoftAddressPath.Text.Trim();
            AddressModel.DownLoadDataId = Id;
            AddressModel.DownLoadServerID = -1;
            if (AddressModel.AddressId > 0)
            { AddressBll.Update(AddressModel); }
            else
            {
                AddressBll.Add(AddressModel);
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
            Response.Redirect("InfoList.aspx?ChId=" + ChId + "&ColId=" + DownLoadmodel.ColId);

        }
    }

    protected void ShowInfo(int Id)
    {
        DataTable dt = AddressBll.GetInfoBySoftId(Id);
        txtSoftAddressPath.Text = dt.Rows[0]["AddressPath"].ToString();
        hfAddressId.Value = dt.Rows[0]["Addressid"].ToString();
        DownLoadmodel = DownLoadBll.GetDownLoadData(Id);
        if (DownLoadmodel == null)
        {
            Function.ShowMsg(0, "<li>所选" + ChannelModel.TypeName + "不存在或已经被删除</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        }
        txtSoftName.Text = DownLoadmodel.Title;
        ddlUserCate.SelectedValue = DownLoadmodel.UserCateId.ToString();
        txtSoftEdition.Text = DownLoadmodel.Edition;
        ddlSoftType.SelectedValue = DownLoadmodel.DownLoadType;
        ddlSoftLanguage.SelectedValue = DownLoadmodel.Language;
        ddlSoftWarrantType.SelectedValue = DownLoadmodel.WarrantType;
        string tagNameStr = DownLoadmodel.TagNameStr;
        if (tagNameStr != string.Empty && tagNameStr.StartsWith("|") && tagNameStr.EndsWith("|"))
        {
            tagNameStr = tagNameStr.Substring(0, tagNameStr.Length - 1);
            tagNameStr = tagNameStr.Substring(1, tagNameStr.Length - 1);
        }
        txtTagName.Text = tagNameStr;
        if (DownLoadmodel.DownLoadOS == "")
            txtSoftOS.Text = "";
        else
        {
            string softOs = DownLoadmodel.DownLoadOS.Substring(0, DownLoadmodel.DownLoadOS.Length - 1);
            softOs = softOs.Substring(1, softOs.Length - 1);
            txtSoftOS.Text = softOs;
        }
        txtSoftSize.Text = DownLoadmodel.DownLoadSize.ToString();
        txtSoftRegAddress.Text = DownLoadmodel.RegAddress;
        txtSoftPlayAddress.Text = DownLoadmodel.PlayAddress;
        txtSoftRemark.Text = DownLoadmodel.Content;
        txtSoftPoint.Text = DownLoadmodel.PointCount.ToString();
        hfIsOpened.Value = DownLoadmodel.IsOpened.ToString();
        txtSoftDisplePwd.Text = DownLoadmodel.DownLoadDisplePwd;
    }

    #region 效验文本框的输入
    public bool CheckValidate()
    {
        const string numPattern = @"\d+$";
        const string floatPattern = @"(\d+)(\.?)(\d*)$";
        //判断所选栏目是否允许添加下载
        bool flag = ColumnBll.ChkHasChildByColId(Convert.ToInt32(Request.Form["ddlColId"]));
        if (flag && !ColumnBll.GetColumn(Convert.ToInt32(Request.Form["ddlColId"])).IsAllowAddInfo)
        {
            litMsg.Text = "<script>alert('所选择的栏目不能添加" + ChannelModel.TypeName + "');</script>";
            return false;
        }

        if (txtSoftName.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('" + ChannelModel.TypeName + "名称必须填写');</script>";
            return false;
        }


        if (!Regex.IsMatch(txtSoftSize.Text.Trim(), floatPattern))
        {
            litMsg.Text = "<script>alert('" + ChannelModel.TypeName + "大小必须为非负整型或非负浮点型');</script>";
            return false;
        }
        if (txtSoftRemark.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('" + ChannelModel.TypeName + "简介必须填写');</script>";
            return false;
        }
        if (txtSoftPoint.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('下载收取金币数必须填写');</script>";
            return false;
        }
        if (!Regex.IsMatch(txtSoftPoint.Text.Trim(), numPattern))
        {
            litMsg.Text = "<script>alert('请输入正确的下载收取金币数');</script>";
            return false;
        }

        return true;
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

}
