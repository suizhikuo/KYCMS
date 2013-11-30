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
using Ky.Common;
using Ky.BLL;
using Ky.Model;
using System.Drawing;
using System.Text.RegularExpressions;

public partial class System_SetSiteInfo : System.Web.UI.Page
{
    B_SiteInfo Bll = new B_SiteInfo();
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup GroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GroupBll.Power_Judge(31);
            BindFontFamily();
            ShowInfo();
        }
    }
    private void BindFontFamily()
    {
        foreach(FontFamily ff in FontFamily.Families)
        {
            ddlWaterMarkFontName.Items.Add(new ListItem(ff.GetName(0),ff.GetName(0)));
        }
    }

   

    #region 取得参数信息
    private void ShowInfo()
    {
        M_Site siteModel = Bll.GetSiteModel();
        M_InfoSite infoModel = Bll.GetInfoModel();
        litRZM.Text = Param.RzmNumber;
        if (siteModel != null)
        {
            txtSiteName.Text = siteModel.SiteName;
            txtDomain.Text = siteModel.Domain;
            txtLogoAddress.Text = siteModel.LogoAddress;
            txtBannerAddress.Text = siteModel.BannerAddress;
            txtKeyword.Text = siteModel.Keyword;
            txtKeyContent.Text = siteModel.KeyContent;
            txtSequenceNum.Text = siteModel.SequenceNum;
            txtIndexTemplatePath.Text = siteModel.IndexTemplatePath;

            int pageType = siteModel.PageType;
            switch (pageType)
            {
                case 1: rdPageType1.Checked = true; break;
                case 2: rdPageType2.Checked = true; break;
                case 3: rdPageType3.Checked = true; break;
                case 4: rdPageType4.Checked = true; break;
                default: break;
            }

            chkBoxIsStaticType.Checked = siteModel.IsStaticType;
          
           
            if (siteModel.IsAbsPathType)
            {
                rdIsAbsPathType2.Checked = true;
            }
            else
            {
                rdIsAbsPathType1.Checked = true;
            }

            txtCopyRight.Text = siteModel.CopyRight;

            chkBoxAllowRegiste.Checked = siteModel.IsAllowRegsite;
            chkBoxIsTestEmail.Checked = siteModel.IsTestEmail;

            chkBoxIsLoginValidate.Checked = siteModel.IsLoginValidate;
            chkBoxIsCommentValidate.Checked = siteModel.IsCommentValidate;
            chkBoxIsAllowCommentNoName.Checked = siteModel.IsAllowCommentNoName;
            chkBoxIsAddCommentEditor.Checked = siteModel.IsAddCommentEditor;
            txtFilterStr.Text = siteModel.FilterStr;
            txtGUnitName.Text = siteModel.GUnitName;
            txtLoginErrorNum.Text = siteModel.LogErrorNum.ToString();
            txtLoginScore.Text = siteModel.LoginScore.ToString();
            chkBoxIsOpenInvite.Checked = bool.Parse(siteModel.IsOpenInvite.ToString());
            txtGNumber.Text = siteModel.GNumber.ToString();
            txtG_Score.Text = siteModel.G_Score.ToString();
            txtG_Day.Text = siteModel.G_Day.ToString();



            if (siteModel.IsImgWaterMark)
            {
                rdIsImgWaterMark2.Checked = true;
            }
            else
            {
                rdIsImgWaterMark1.Checked = true;
            }

            txtWaterMarkStr.Text = siteModel.WaterMarkStr;
            txtWaterMarkFontSize.Text = siteModel.WaterMarkFontSize.ToString();
            //txtWaterMarkFontName.Text = siteModel.WaterMarkFontName;
            try
            {
                ddlWaterMarkFontName.SelectedValue = siteModel.WaterMarkFontName;
            }
            catch { }
            txtWaterMarkFontColor.Text = siteModel.WaterMarkFontColor;
            chkBoxWaterMarkIsBold.Checked = siteModel.WaterMarkIsBold;

            txtWaterMarkPath.Text = siteModel.WaterMarkPath;
            string waterMarkHW = siteModel.WaterMarkHW;
            string[] hw = waterMarkHW.Split('|');
            txtWaterMarkH.Text = hw[0];
            txtWaterMarkW.Text = hw[1];
            txtWaterMarkLight.Text = siteModel.WaterMarkLight.ToString();
            ddlWaterMarkPos.SelectedValue = siteModel.WaterMarkPos.ToString();

         
            txtEmailServerAddress.Text = siteModel.EmailServerAddress;
            txtServerUserName.Text = siteModel.EmailServerUserName;
            // txtServerUserPass.Text = "*****";
            litUserPass.Text = siteModel.EmailServerUserPass;
            if (litUserPass.Text.Length != 0)
            {
                litSet.Text = "[已设置密码]";
            }
            chkBoxIsOpenRZM.Checked = siteModel.IsOpenRZM;
            txtDisabledLoginTime.Text = siteModel.DisabledLoginTime.ToString();
            txtUserClassCount.Text = siteModel.UserClassCount.ToString();
            chkBosIsOpenRegLink.Checked = siteModel.IsOpenRegLink;
            chkIsCheckLink.Checked = siteModel.IsCheckLink;
        }
        if (infoModel != null)
        {
            txtInfoCreateNum.Text = infoModel.InfoCreateNum.ToString();
            txtSpecialInfoCreateNum.Text = infoModel.SpecialInfoCreateNum.ToString();
            txtSearchTime.Text = infoModel.SearchTime.ToString();
            txtSearchResultPageSize.Text = infoModel.SearchResultPageSize.ToString();
            chkBoxIsOpenViewerDig.Checked = infoModel.IsOpenViewerDig;


            txtUploadType.Text = infoModel.ImgUploadType;
            txtUploadVideoType.Text = infoModel.VideoUploadType;
            txtUploadAudioType.Text = infoModel.AudioUploadType;
            txtUploadSoftType.Text = infoModel.SoftUploadType;
            txtUploadOtherType.Text = infoModel.OtherUploadType;
            txtHistoryTime.Text = infoModel.HistoryTime.ToString();
        }
      
    }
    #endregion

    protected void btnSumbit_Click(object sender, EventArgs e)
    {

        if(txtSequenceNum.Text.Trim().Length==0)
        {
            Function.ShowSysMsg(0, "<li>产品序列号必须填写</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        if (txtDomain.Text.Trim().Length == 0)
        {
            Function.ShowSysMsg(0, "<li>站点域名必须填写</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
         if(txtIndexTemplatePath.Text.Trim().Length==0)
        {
            Function.ShowSysMsg(0, "<li>首页模版必须选择</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
     
        if(chkBoxIsTestEmail.Checked&&(txtEmailServerAddress.Text.Trim().Length==0||txtServerUserName.Text.Trim().Length==0||(txtServerUserPass.Text.Trim().Length==0&&litUserPass.Text.Length==0)))
        {
             Function.ShowSysMsg(0, "<li>选择了注册时邮箱验证，邮件发送设置必须填写</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        if(chkBoxIsTestEmail.Checked)
        {
            if(!Regex.IsMatch(txtServerUserName.Text.Trim(),@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",RegexOptions.IgnoreCase))
            {
                Function.ShowSysMsg(0, "<li>发送邮件的地址名称格式不正确</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }
        }
        if (txtFilterStr.Text.Length > 1000)
        {
            Function.ShowSysMsg(0, "<li>过滤关键字不能超过1000个字</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        if(txtGUnitName.Text.Trim().Length==0)
        {
            Function.ShowSysMsg(0, "<li>金币单位必须填写</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }

     

        M_Site siteModel = new M_Site();
        M_InfoSite infoModel = new  M_InfoSite();


        siteModel.SiteName = txtSiteName.Text;
        siteModel.Domain = txtDomain.Text;
        siteModel.LogoAddress = txtLogoAddress.Text;

        siteModel.BannerAddress = txtBannerAddress.Text;
        siteModel.Keyword = txtKeyword.Text;
        siteModel.KeyContent = txtKeyContent.Text;
        siteModel.SequenceNum = txtSequenceNum.Text;

        if (Request.Form["txtIndexTemplatePath"] != null && Request.Form["txtIndexTemplatePath"] != "")
        {
            siteModel.IndexTemplatePath = Request.Form["txtIndexTemplatePath"];
        }

        if (rdPageType1.Checked)
        {
            siteModel.PageType = 1;
        }
        else if (rdPageType2.Checked)
        {
            siteModel.PageType = 2;
        }
        else if (rdPageType3.Checked)
        {
            siteModel.PageType = 3;
        }
        else if (rdPageType4.Checked)
        {
            siteModel.PageType = 4;
        }

        siteModel.IsStaticType = chkBoxIsStaticType.Checked;
      


        if (rdIsAbsPathType2.Checked)
        {
            siteModel.IsAbsPathType = true;
        }
        else
        {
            siteModel.IsAbsPathType = false;
        }

        siteModel.CopyRight = txtCopyRight.Text;

        siteModel.DefaultUserGroup = 0;
        siteModel.IsAllowRegsite = chkBoxAllowRegiste.Checked;
        siteModel.IsTestEmail = chkBoxIsTestEmail.Checked;
        siteModel.IsLoginValidate = chkBoxIsLoginValidate.Checked;
        siteModel.IsCommentValidate = chkBoxIsCommentValidate.Checked;
        siteModel.IsAllowCommentNoName = chkBoxIsAllowCommentNoName.Checked;
        siteModel.IsAddCommentEditor = chkBoxIsAddCommentEditor.Checked;
        siteModel.FilterStr = txtFilterStr.Text;
        siteModel.GUnitName = txtGUnitName.Text;
        try
        {
            siteModel.LogErrorNum = int.Parse(txtLoginErrorNum.Text);
        }
        catch
        {
            siteModel.LogErrorNum = 0;
        }

        siteModel.IsOpenInvite = chkBoxIsOpenInvite.Checked;
       
        try
        {
            siteModel.GNumber = int.Parse(txtGNumber.Text.Trim());
        }
        catch { siteModel.GNumber = 0; }
        try
        {
            siteModel.G_Day = int.Parse(txtG_Day.Text);
        }
        catch { siteModel.G_Day = 0; }
        try
        {
            siteModel.G_Score = int.Parse(txtG_Score.Text);
        }
        catch { siteModel.G_Score = 0; }
        try
        {
            siteModel.LoginScore = int.Parse(txtLoginScore.Text);
        }
        catch { siteModel.LoginScore = 0; }

        if (rdIsImgWaterMark2.Checked)
        {
            siteModel.IsImgWaterMark = true;
        }
        else
        {
            siteModel.IsImgWaterMark = false;
        }

        siteModel.WaterMarkStr = txtWaterMarkStr.Text;
        try
        {
            siteModel.WaterMarkFontSize = int.Parse(txtWaterMarkFontSize.Text);
        }
        catch
        {
            siteModel.WaterMarkFontSize = 0;
        }
        siteModel.WaterMarkFontName = ddlWaterMarkFontName.SelectedValue;
        if (Request.Form["txtWaterMarkFontColor"] != null && Request.Form["txtWaterMarkFontColor"] != "")
        {
            siteModel.WaterMarkFontColor = Request.Form["txtWaterMarkFontColor"];
        }
        siteModel.WaterMarkIsBold = chkBoxWaterMarkIsBold.Checked;

        siteModel.WaterMarkPath = txtWaterMarkPath.Text;
        siteModel.WaterMarkHW = txtWaterMarkH.Text + "|" + txtWaterMarkW.Text;
        try
        {
            siteModel.WaterMarkLight = int.Parse(txtWaterMarkLight.Text);
        }
        catch
        {
            siteModel.WaterMarkLight = 0;
        }
        siteModel.WaterMarkPos = int.Parse(ddlWaterMarkPos.SelectedValue);

        siteModel.EmailServerAddress = txtEmailServerAddress.Text;
        siteModel.EmailServerUserName = txtServerUserName.Text;
        if (txtServerUserPass.Text.Trim().Length != 0)
        {
            siteModel.EmailServerUserPass = txtServerUserPass.Text;
        }
        else
        {
            siteModel.EmailServerUserPass = litUserPass.Text;
        }

        siteModel.IsOpenRZM = chkBoxIsOpenRZM.Checked;
        try
        {
            siteModel.DisabledLoginTime = int.Parse(txtDisabledLoginTime.Text.Trim());
        }
        catch 
        {
            siteModel.DisabledLoginTime = 0;
        }
        try
        {
            siteModel.UserClassCount = int.Parse(txtUserClassCount.Text.Trim());
        }
        catch
        {
            siteModel.UserClassCount = 0;
        }
        siteModel.IsOpenRegLink = chkBosIsOpenRegLink.Checked;
        siteModel.IsCheckLink = chkIsCheckLink.Checked;

        try
        {
            infoModel.InfoCreateNum = int.Parse(txtInfoCreateNum.Text);
            if (infoModel.InfoCreateNum < 50 || infoModel.InfoCreateNum > 5000)
            {
                infoModel.InfoCreateNum = 100;
            }
        }
        catch
        {
            infoModel.InfoCreateNum = 100;
        }
        try
        {
            infoModel.SpecialInfoCreateNum = int.Parse(txtSpecialInfoCreateNum.Text);
        }
        catch
        {
            infoModel.SpecialInfoCreateNum = 0;
        }

        try
        {
            infoModel.SearchTime = int.Parse(txtSearchTime.Text);
        }
        catch
        {
            infoModel.SearchTime = 0;
        }
       
        try
        {
            infoModel.SearchResultPageSize = int.Parse(txtSearchResultPageSize.Text);
        }
        catch
        {
            infoModel.SearchResultPageSize = 0;
        }
        infoModel.IsOpenViewerDig = chkBoxIsOpenViewerDig.Checked;

        infoModel.ImgUploadType = txtUploadType.Text.Trim();
        infoModel.VideoUploadType = txtUploadVideoType.Text.Trim();
        infoModel.AudioUploadType = txtUploadAudioType.Text.Trim();
        infoModel.SoftUploadType = txtUploadSoftType.Text.Trim();
        infoModel.OtherUploadType = txtUploadOtherType.Text.Trim();
        try
        {
            infoModel.HistoryTime = int.Parse(txtHistoryTime.Text.Trim());
        }
        catch
        {
            infoModel.HistoryTime = 0;
        }

        B_Log.Add(LogType.Update, "配置全站参数设置成功");
        Bll.SetSite(siteModel);
        Bll.SetInfoSite(infoModel);
        Function.ShowSysMsg(1, "<li>全站参数设置成功</li><li><a href='javascript:history.back()'>返回上一页</a></li>");

    }
}
