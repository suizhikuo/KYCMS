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
public partial class System_down_SetDownLoad : System.Web.UI.Page
{
    M_DownLoad DownLoadmodel = new M_DownLoad();
    M_LoginAdmin AdminModel = null;
    protected M_Site SiteModel = null;
    protected M_Channel ChannelModel = null;
    M_DownLoadAddress AddressModel = new M_DownLoadAddress();
    B_DownLoad DownLoadBll = new B_DownLoad();
    B_DownLoadServerType DownServerTypeBll = new B_DownLoadServerType();
    B_Create CreateBll = new B_Create();
    B_Admin AdminBll = new B_Admin();
    B_SiteInfo SiteBll = new B_SiteInfo();
    B_Channel ChannelBll = new B_Channel();
    B_DownLoadaddress AddressBll = new B_DownLoadaddress();
    B_Dictionary DictionaryBll = new B_Dictionary();
    protected B_Column ColumnBll = new B_Column();
    protected int Id = 0; 
    protected int returnNum = 0;
    protected int ChannelId = 0;
    protected int ColumnId = 0;
    string AddressId = "";
    protected DataTable dt;
    protected string AddressName = "";
    protected string DownServerId = "";
    protected string AddressPath = "";
    protected string[] str = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        AdminModel = AdminBll.GetLoginModel();
        litMsg.Text = "";
        SiteModel = SiteBll.GetSiteModel();
        if(SiteModel==null)
        {
            Function.ShowSysMsg(0, "<li>全站参数获取错误</li>");
        }
        txtSoftTemplatePath.Attributes.Add("readonly", "");
        txtTitleImgPath.Attributes.Add("readonly","");
        if(!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            ChannelId = int.Parse(Request.QueryString["ChId"]);
        }
        if(!ColumnBll.ChkHasColumnByChId(ChannelId))
        {
            Function.ShowSysMsg(0, "<li>本频道下没有栏目，不能添加信息</li><li>建议您先添加栏目</li><li><a href='info/SetColumn.aspx?ChId=" + ChannelId + "'>添加栏目</a> <a href='info/ColumnList.aspx?ChId=" + ChannelId + "'>栏目管理</a></li>"); 
        }
        ChannelModel = ChannelBll.GetChannel(ChannelId);
        if(ChannelId<=0 || ChannelModel==null || ChannelModel.ModelType!=3)
        {
            Function.ShowSysMsg(0, "<li>频道参数错误</li>");
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
                ColumnId = int.Parse(Request.QueryString["ColId"]);
        }
        if (ColumnId != 0 && ColumnBll.GetColumn(ColumnId) == null)
        {
            Function.ShowSysMsg(0, "<li>所选栏目不存在或已经被删除</li>");
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
            }
            catch{}
        }
        B_InfoModel infoModelBll=new B_InfoModel();
        M_InfoModel infoModel = infoModelBll.GetModel(ChannelModel.ModelType);
        FilePicPath.Text = infoModel.UploadPath+"|"+infoModel.UploadSize.ToString();
        if(Id>0)
             litNav.Text = "<a href='ColumnList.aspx?Chid=" + ChannelId + "'>" + ChannelModel.ChName + "</a> &gt;&gt; 修改" + ChannelModel.TypeName;
        else
             litNav.Text = "<a href='ColumnList.aspx?Chid=" + ChannelId + "'>" + ChannelModel.ChName + "</a> &gt;&gt; 添加" + ChannelModel.TypeName;
         if (!IsPostBack)
        {
            BindGroup();
            BindDownServerType();
            BindSpeacil();
            if (Id > 0)
                ShowDownLoadInfo(Id);
            ddlBind();
        }
    }
    protected void ddlBind()
    {
        ddlSoftType.DataSource = DictionaryBll.FormatCategory(36);
        ddlSoftType.DataTextField =  "DicName";
        ddlSoftType.DataValueField = "DicValue";
        ddlSoftType.DataBind();

        ddlSoftLanguage.DataSource = DictionaryBll.FormatCategory(28);
        ddlSoftLanguage.DataTextField =  "DicName";
        ddlSoftType.DataValueField = "DicValue";
        ddlSoftLanguage.DataBind();

        ddlSoftWarrantType.DataSource = DictionaryBll.FormatCategory(44);
        ddlSoftWarrantType.DataTextField =  "DicName";
        ddlSoftType.DataValueField = "DicValue";
        ddlSoftWarrantType.DataBind();

        string[] softOsArray =  DictionaryBll.GetString(53).Split('|');
        for (int i = 0; i < softOsArray.Length;i++ )
        {
            Label lb = new Label();
            lb.Text = "<a href=\"javascript:SetDownOS('"+softOsArray[i]+"')\">"+softOsArray[i]+"</a>/";
            plSoftOs.Controls.Add(lb);
        }
    }

    #region  绑定所有专题
    public void BindSpeacil()
    {
        B_Special specialBll = new B_Special();
        lBoxSpecialIdStr.Items.Clear();
        DataTable dt = specialBll.GetChannelSpecial(ChannelId);
        DataView dvParent = new DataView(dt);
        dvParent.RowFilter = "ParentId=0";
        for (int i = 0; i < dvParent.Count; i++)
        {
            int parentId = Convert.ToInt32(dvParent[i]["Id"]);
            lBoxSpecialIdStr.Items.Add(new ListItem(dvParent[i]["SpecialCName"].ToString(), parentId.ToString()));
            DataView dvChild = new DataView(dt);
            dvChild.RowFilter = "ParentId=" + parentId;
            for (int j = 0; j < dvChild.Count; j++)
            {
                lBoxSpecialIdStr.Items.Add(new ListItem("└" + dvChild[j]["SpecialCName"], dvChild[j]["Id"].ToString()));
            }
        }
    }
    #endregion 绑定下载服务器类别

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


    #region 绑定服务器类别
    protected void BindDownServerType()
    {
        DataTable dt = DownServerTypeBll.GetTypeList();
        ddlDownServerID.DataTextField = "TypeName";
        ddlDownServerID.DataValueField = "TypeId";
        ddlDownServerID.DataSource = dt;
        ddlDownServerID.DataBind();
        ddlDownServerID.Items.Insert(0, new ListItem("↓不使用下载服务器↓", "-1"));
    }
    #endregion

    #region 保存信息事件
    protected void btnSoftSaveAs_Click(object sender, EventArgs e)
    {
        bool flag = CheckValidate();
        if(flag)
        {
            #region //添加软件
            DownLoadmodel.Id = Id;
            if (!string.IsNullOrEmpty(Request.Form["ddlColId"]))
                DownLoadmodel.ColId = int.Parse(Request.Form["ddlColId"]);
            DownLoadmodel.Title = txtSoftName.Text.Trim();
            DownLoadmodel.TitleColor = txtTitleColor.Text.Trim();
            DownLoadmodel.TitleFontType = int.Parse(ddlTitleFontType.SelectedValue.Trim());
            if (rbImg.Checked)
            {
                DownLoadmodel.TitleType = 2;
                DownLoadmodel.TitleImgPath = Request.Form["txtTitleImgPath"].Trim();
            }
            else if (rbComm.Checked)
            {
                DownLoadmodel.TitleType = 1;
            }
            DownLoadmodel.Edition = txtSoftEdition.Text.Trim();
            DownLoadmodel.PlayAddress = txtSoftPlayAddress.Text.Trim();
            DownLoadmodel.UId = AdminModel.UserId;
            DownLoadmodel.UName = AdminModel.LoginName;
            DownLoadmodel.UserType = 1;
            DownLoadmodel.AdminUId = AdminModel.UserId;
            DownLoadmodel.AdminUName = AdminModel.AdminName;
            DownLoadmodel.UserCateId = 0;
            //专题
            string idStr = string.Empty;
            for (int i = 0; i < lBoxSpecialIdStr.Items.Count; i++)
            {
                if (lBoxSpecialIdStr.Items[i].Selected)
                {
                    idStr += lBoxSpecialIdStr.Items[i].Value + "|";
                }
            }
            if (idStr != "")
                DownLoadmodel.SpecialIdStr = "|" + idStr;
            else
                DownLoadmodel.SpecialIdStr = "";
            #region 关键字

            string tagIdStr = string.Empty;
            string nameStr = txtTagName.Text.Trim();
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
            DownLoadmodel.TagIdStr = tagIdStr;
            DownLoadmodel.TagNameStr = nameStr;
            #endregion
            DownLoadmodel.DownLoadDownNum = int.Parse(txtSoftDownNum.Text.Trim());
            DownLoadmodel.DownLoadDownDayNum = int.Parse(txtSoftDownDayNum.Text.Trim());
            DownLoadmodel.DownLoadDownWeekNum = int.Parse(txtSoftDownWeekNum.Text.Trim());
            DownLoadmodel.DownLoadDownMonthNum = int.Parse(txtSoftDownMonthNum.Text.Trim());

            //添加时间
            if (txtAddTime.Text.Trim().Length != 0)
            {
                if (Function.IsDate(txtAddTime.Text.Trim().ToString()))
                    DownLoadmodel.AddTime = DateTime.Parse(txtAddTime.Text.Trim().ToString());
                else
                    Function.ShowSysMsg(0, "<li>你输入的日期格式不对</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            else
                DownLoadmodel.AddTime = DateTime.Now;

            DownLoadmodel.UpdateTime = DateTime.Now;
            if (txtSoftOS.Text.Trim().Length == 0)
                DownLoadmodel.DownLoadOS = "";
            else
                DownLoadmodel.DownLoadOS = "|" + txtSoftOS.Text.Trim() + "|";
            DownLoadmodel.Language = ddlSoftLanguage.SelectedValue;
            DownLoadmodel.WarrantType = ddlSoftWarrantType.SelectedValue;
            DownLoadmodel.DownLoadSize = txtSoftSize.Text.Trim();
            DownLoadmodel.RegAddress = txtSoftRegAddress.Text.Trim();
            DownLoadmodel.IsTop =chkBoxIsTop.Checked;
            DownLoadmodel.IsRecommend = chkBoxIsRecommand.Checked;
            DownLoadmodel.IsFocus = chkBoxIsFocus.Checked;
            DownLoadmodel.IsSideShow = chkBoxIsSideShow.Checked;
            DownLoadmodel.IsAllowComment = chkBoxIsAllowComment.Checked;
            DownLoadmodel.Status =3;
            DownLoadmodel.Content = txtSoftRemark.Value;
            DownLoadmodel.TitleImgPath = txtTitleImgPath.Text.Trim();
            DownLoadmodel.Plugin = ddlSoftPlugin.SelectedValue;
            DownLoadmodel.PointCount = int.Parse(txtSoftPoint.Text.Trim());
            DownLoadmodel.IsDeleted = false;
            DownLoadmodel.DownLoadStarLevel = ddlSoftGrade.SelectedValue;
            DownLoadmodel.DownLoadDisplePwd = txtSoftDisplePwd.Text.Trim();
            DownLoadmodel.TemplatePath = txtSoftTemplatePath.Text.Trim();
            DownLoadmodel.PageType = int.Parse(rdBtnPageType.SelectedValue);
            DownLoadmodel.IsOpened = int.Parse(rdBtnIsOpened.SelectedValue);
            DownLoadmodel.DownLoadType = ddlSoftType.SelectedValue;
            DownLoadmodel.HitCount = Convert.ToInt32(hfHitCount.Value);
            if (DownLoadmodel.IsOpened == 0)
            {
                string groupIdStr = "";
                foreach (ListItem li in chkBoxGroupIdStr.Items)
                {
                    if (li.Selected)
                    {
                        groupIdStr += li.Value + "|";
                    }
                }
                DownLoadmodel.GroupIdStr = "|" + groupIdStr;
            }
            else { DownLoadmodel.GroupIdStr = ""; }
            //重复收费方式
            if (rdBtnChargeType1.Checked)
                DownLoadmodel.ChargeType = 1;
            if (rdBtnChargeType2.Checked)
            {
                DownLoadmodel.ChargeType = 2;
                DownLoadmodel.ChargeHourCount = Int32.Parse(txtChargeHourCount.Text.Trim());
            }
            if (rdBtnChargeType3.Checked)
            {
                DownLoadmodel.ChargeType = 3;
                DownLoadmodel.ChargeViewCount = Int32.Parse(txtChargeViewCount.Text.Trim());
            }
            if (rdBtnChargeType4.Checked)
            {
                DownLoadmodel.ChargeType = 4;
                DownLoadmodel.ChargeHourCount = Int32.Parse(txtChargeHourCount.Text.Trim());
                DownLoadmodel.ChargeViewCount = Int32.Parse(txtChargeViewCount.Text.Trim());
            }
            if (rdBtnChargeType5.Checked)
            {
                DownLoadmodel.ChargeType = 5;
                DownLoadmodel.ChargeHourCount = Int32.Parse(txtChargeHourCount.Text.Trim());
                DownLoadmodel.ChargeViewCount = Int32.Parse(txtChargeViewCount.Text.Trim());
            }
            if (rdBtnChargeType6.Checked)
                DownLoadmodel.ChargeType = 6;

            #endregion 
            #region 保存

            if (Id > 0)
            {
                Id = DownLoadBll.Update(DownLoadmodel);
            }
            else
            {
                Id = DownLoadBll.Add(DownLoadmodel);
            }
            

            #region 设置下载地址
            int addressNum=int.Parse(Request.Form["AddressNum"]);
            string[] addressId = txtAddressIdstr.Text.Split(',');
            for(int i=1;i<addressNum+1;i++)
            {
                if (txtreturnNum.Text!="" && i<=addressId.Length)
                {
                    AddressModel.AddressId = int.Parse(addressId[i - 1]);
                }
                if (Request.Form["nmDLId_" + i] == "1")
                    AddressModel.AddressId = 0;
                AddressModel.DownLoadDataId=Id;
                AddressModel.AddressNum=addressNum;
                if (!string.IsNullOrEmpty(Request.Form["nmAddressName_" + i]) && !string.IsNullOrEmpty(Request.Form["ddlDownServerID_" + i]) && !string.IsNullOrEmpty(Request.Form["nmAddressPath_" + i]))
               {
                   AddressModel.AddressName = Request.Form["nmAddressName_" + i];
                   AddressModel.DownLoadServerID = int.Parse(Request.Form["ddlDownServerID_" + i]);
                   AddressModel.AddressPath = Request.Form["nmAddressPath_" + i];
                }
                else
                {
                    AddressModel.AddressName = "";
                    AddressModel.DownLoadServerID = -1;
                    AddressModel.AddressPath = "";
                }
                if (AddressModel.AddressId > 0 && Request.Form["nmDLId_" + i] == "0")
                    AddressBll.Update(AddressModel);
                else if (AddressModel.AddressId == 0 || Request.Form["nmDLId_" + i] == "1")
                    AddressBll.Add(AddressModel);
            }
            #endregion

            if (chkBoxIsCreate.Checked)
            {
                DataRow dr = CreateBll.GetInfoById("KyDownLoadData", Id);
                CreateBll.CreateSingleInfo(dr);
            }

            Response.Redirect("InfoList.aspx?ChId=" + ChannelId + "&ColId=" + DownLoadmodel.ColId);
            #endregion
        }
    }
    #endregion


    #region 根据软件ID获取软件信息 
    protected void ShowDownLoadInfo(int id)
    {
        DownLoadmodel = DownLoadBll.GetDownLoadData(id);
        if (DownLoadmodel.TitleType == 1)
            rbComm.Checked = true;
        else if (DownLoadmodel.TitleType == 2)
            rbImg.Checked = true;
        txtTitleImgPath.Text = DownLoadmodel.TitleImgPath;
        dt = AddressBll.GetInfoBySoftId(id);
        txtreturnNum.Text = dt.Rows.Count.ToString();
        returnNum = dt.Rows.Count;
        for (int i = 0; i < dt.Rows.Count;i++ )
        {
            AddressId += dt.Rows[i]["AddressId"].ToString()+",";
            AddressName += "'"+dt.Rows[i]["AddressName"].ToString() + "',";
            DownServerId += "'" + dt.Rows[i]["DownLoadServerID"].ToString() + "',";
            AddressPath += "'" + dt.Rows[i]["AddressPath"] + "',";
        }
        if (dt.Rows.Count != 0)
        {
            AddressId = AddressId.Substring(0, AddressId.Length - 1);
            AddressName = AddressName.Substring(0, AddressName.Length - 1);
            DownServerId = DownServerId.Substring(0, DownServerId.Length - 1);
            AddressPath = AddressPath.Substring(0, AddressPath.Length - 1);
        }
        txtAddressIdstr.Text = AddressId;
        if(DownLoadmodel==null || DownLoadmodel.Status==-1)
        {
            litMsg.Text = "<script type='text/javascript'>alert('所选" + ChannelModel.TypeName + "不存在或已经被删除');history.back();</script>";
            Response.End();
            return;
        }
        txtSoftName.Text = DownLoadmodel.Title;
        txtSoftEdition.Text = DownLoadmodel.Edition;
        txtSoftPlayAddress.Text = DownLoadmodel.PlayAddress;
        //所属专题
        string[] arraySpecialIdStr = DownLoadmodel.SpecialIdStr.Split('|');
        for (int i = 0; i < arraySpecialIdStr.Length;i++ )
        {
            for (int j = 0; j< lBoxSpecialIdStr.Items.Count;j++ )
            {
                if (lBoxSpecialIdStr.Items[j].Value == arraySpecialIdStr[i])
                    lBoxSpecialIdStr.Items[j].Selected = true;
            }
        }
        string tagNameStr = DownLoadmodel.TagNameStr;
        if (tagNameStr != string.Empty && tagNameStr.StartsWith("|") && tagNameStr.EndsWith("|"))
        {
            tagNameStr = tagNameStr.Substring(0, tagNameStr.Length - 1);
            tagNameStr = tagNameStr.Substring(1, tagNameStr.Length - 1);
        }
        tagNameStr = tagNameStr.Replace("|", " ");
        txtTagName.Text = tagNameStr;

        txtSoftDownNum.Text = DownLoadmodel.DownLoadDownNum.ToString();
        txtSoftDownDayNum.Text = DownLoadmodel.DownLoadDownDayNum.ToString();
        txtSoftDownWeekNum.Text = DownLoadmodel.DownLoadDownWeekNum.ToString();
        txtSoftDownMonthNum.Text = DownLoadmodel.DownLoadDownMonthNum.ToString();

        //添加时间
        txtAddTime.Text = DownLoadmodel.AddTime.ToString();

        if (DownLoadmodel.DownLoadOS == "")
            txtSoftOS.Text = "";
        else
        {
            string softOs = DownLoadmodel.DownLoadOS.Substring(0, DownLoadmodel.DownLoadOS.Length - 1);
            softOs=softOs.Substring(1, softOs.Length - 1);
            txtSoftOS.Text = softOs;
        }
        txtTitleColor.Text = DownLoadmodel.TitleColor;
        ddlTitleFontType.SelectedValue = DownLoadmodel.TitleFontType.ToString();
        try
        {
            ddlSoftType.SelectedValue = DownLoadmodel.DownLoadType;
            ddlSoftLanguage.SelectedValue = DownLoadmodel.Language;
            ddlSoftWarrantType.SelectedValue = DownLoadmodel.WarrantType;
            ddlSoftGrade.SelectedValue = DownLoadmodel.DownLoadStarLevel.ToString();
        }
        catch { }

        txtSoftSize.Text = DownLoadmodel.DownLoadSize.ToString();
        txtSoftRegAddress.Text = DownLoadmodel.RegAddress;
        chkBoxIsTop.Checked = DownLoadmodel.IsTop;
        chkBoxIsRecommand.Checked = DownLoadmodel.IsRecommend;
        chkBoxIsFocus.Checked = DownLoadmodel.IsFocus;
        chkBoxIsSideShow.Checked = DownLoadmodel.IsSideShow;
        chkBoxIsAllowComment.Checked = DownLoadmodel.IsAllowComment;
        txtSoftRemark.Value = DownLoadmodel.Content;
        //保存路径
        ddlSoftPlugin.SelectedValue= DownLoadmodel.Plugin;
       // txtSoftAddress.Text = DownLoadmodel.SoftAddress;
        txtSoftPoint.Text = DownLoadmodel.PointCount.ToString();
        txtSoftDisplePwd.Text = DownLoadmodel.DownLoadDisplePwd;
        txtSoftTemplatePath.Text = DownLoadmodel.TemplatePath;
        rdBtnPageType.SelectedValue = DownLoadmodel.PageType.ToString();
        rdBtnIsOpened.SelectedValue = DownLoadmodel.IsOpened.ToString();
        hfHitCount.Value =DownLoadmodel.HitCount .ToString();

        foreach(ListItem li in chkBoxGroupIdStr.Items)
        {
            if(DownLoadmodel.GroupIdStr.IndexOf("|"+li.Value+"|")!=-1)
                li.Selected=true;
        }
        //收费方式
        switch (DownLoadmodel.ChargeType)
        {
            case 1:
                rdBtnChargeType1.Checked = true;
                break;
            case 2:
                txtChargeHourCount.Text = DownLoadmodel.ChargeHourCount.ToString();
                rdBtnChargeType2.Checked = true;
                break;
            case 3:
                rdBtnChargeType3.Checked = true;
                txtChargeViewCount.Text = DownLoadmodel.ChargeViewCount.ToString();
                break;
            case 4:
                rdBtnChargeType4.Checked = true;
                txtChargeHourCount.Text = DownLoadmodel.ChargeHourCount.ToString();
                txtChargeViewCount.Text = DownLoadmodel.ChargeViewCount.ToString();
                break;
            case 5:
                rdBtnChargeType5.Checked = true;
                txtChargeHourCount.Text = DownLoadmodel.ChargeHourCount.ToString();
                txtChargeViewCount.Text = DownLoadmodel.ChargeViewCount.ToString();
                break;
        }
        btnSoftSaveAs.Text = "确定修改";
    }
    #endregion

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

        if(txtSoftName.Text.Trim().Length==0)
        {
            litMsg.Text = "<script>alert('"+ChannelModel.TypeName+"名称必须填写');</script>";
            return false;
        }


        if (!Regex.IsMatch(txtSoftSize.Text.Trim(),floatPattern))
        {
            litMsg.Text = "<script>alert('" + ChannelModel.TypeName + "大小必须为非负整型或非负浮点型');</script>";
            return false;
        }
        if (txtSoftRemark.Value.Length == 0)
        {
            litMsg.Text = "<script>alert('" + ChannelModel.TypeName + "简介必须填写');</script>";
            return false;
        }
        if (txtSoftPoint.Text.Trim().Length == 0)
        {
            litMsg.Text = "<script>alert('下载收取金币数必须填写');</script>";
            return false;
        }
        if (!Regex.IsMatch(txtSoftPoint.Text.Trim(),numPattern))
        {
            litMsg.Text = "<script>alert('请输入正确的下载收取金币数');</script>";
            return false;
        }
        if (!Regex.IsMatch(txtSoftDownDayNum.Text.Trim(), numPattern) || !Regex.IsMatch(txtSoftDownWeekNum.Text.Trim(), numPattern) || !Regex.IsMatch(txtSoftDownMonthNum.Text.Trim(), numPattern) || !Regex.IsMatch(txtSoftDownNum.Text.Trim(), numPattern))
        {
            litMsg.Text = "<script>alert('请输入正确的浏览数');</script>";
            return false;
        }
        return true;
    }
    #endregion
}
