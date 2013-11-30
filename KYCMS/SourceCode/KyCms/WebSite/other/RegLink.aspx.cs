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
using Ky.Model;
using Ky.Common;

public partial class RegLink : System.Web.UI.Page
{
    B_Link linkBll = new B_Link();
    B_SiteInfo siteBll = new B_SiteInfo();
    B_Dictionary dictionaryBll = new B_Dictionary();
    B_Create createBll = new B_Create();
    M_Site siteModel = new M_Site();
    protected void Page_Load(object sender, EventArgs e)
    {
        hylnk.NavigateUrl = createBll.GetIndexUrl();
        siteModel = siteBll.GetSiteModel();
        if (!siteModel.IsOpenRegLink)
        {
            Function.ShowMsg(0, "<li>对不起,本站目前暂不接受友情链接申请.</li><li><a href='" + hylnk.NavigateUrl + "'>返回首页</a></li>");
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        M_Site siteModel = siteBll.GetSiteModel();
        lbMySiteName.Text = siteModel.SiteName;
        txtMyPicLink.Text = "<a href=\"" + siteModel.Domain + "\" target=\"_blank\"><img src=\"" + siteModel.LogoAddress + "\" title=\"" + siteModel.SiteName+"\" /></a>";
        imgMyLogo.ImageUrl = siteModel.LogoAddress;
        txtMyTextLink.Text="<a href='"+siteModel.Domain+"' title='"+siteModel.SiteName+"' target='_blank'>"+siteModel.SiteName+"</a>";

        ddlLinkCategory.DataSource = dictionaryBll.GetDictionary(73);
        ddlLinkCategory.DataTextField = "DicName";
        ddlLinkCategory.DataValueField = "Id";
        ddlLinkCategory.DataBind();
    
    }
    protected void btnReg_Click(object sender, EventArgs e)
    {
        CheckInput();
        M_Link model = new M_Link();
        model.AddTime = DateTime.Now;
        model.Description = siteBll.GetFiltering(txtDescription.Text.Length > 200 ? txtDescription.Text.Substring(0, 200) : txtDescription.Text);
        model.Email = txtEmail.Text;
        model.LinkCategory = ddlLinkCategory.SelectedValue;
        if (rbPicLink.Checked)
        { model.LinkType = 2;}
        if (rbTextLink.Checked)
        { model.LinkType = 1; }
        model.OwnerName = txtRegName.Text;
        model.SiteLogo = txtRegLogo.Text;
        model.SiteName = txtRegSiteName.Text;
        model.SiteUrl = txtRegUrl.Text;
        model.Status = siteModel.IsCheckLink ? 1 : 2;
        model.IsDisable = false;
        linkBll.Add(model);
        if (siteModel.IsCheckLink)
        {
            Function.ShowMsg(1, "<li>您的申请已提交,请等待我们的审核</li><li><a href='" + hylnk.NavigateUrl + "'>返回首页</a></li>");
        }
        else
        {
            Function.ShowMsg(1, "<li>操作成功</li><li><a href='" + hylnk.NavigateUrl + "'>返回首页</a></li>");
        }
    }

    void CheckInput()
    {
        if (txtRegSiteName.Text == "")
        {
            Function.ShowMsg(0, "<li>请输入您的站点名称</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>");
        }
        if (txtRegUrl.Text == "")
        {
            Function.ShowMsg(0, "<li>请输入您的站点URL</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>");
        }
        if (rbPicLink.Checked && txtRegLogo.Text == "")
        {
            Function.ShowMsg(0, "<li>请输入您的站点LOGO地址</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>");
        }
        if (txtEmail.Text == "")
        {
            Function.ShowMsg(0, "<li>请输入您的联系Email</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>");
        }
    }
}
