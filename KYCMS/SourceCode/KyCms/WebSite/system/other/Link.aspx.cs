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
using Ky.Common;

public partial class system_other_Link : System.Web.UI.Page
{
    protected string sTitle = "查看友情链接";
    B_Link linkBll = new B_Link();
    B_Dictionary dictionary = new B_Dictionary();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    M_Link model = new M_Link();
    int LinkId = 0;
    bool IsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(19);

        //查看
        if (!string.IsNullOrEmpty(Request.QueryString["LinkId"]))
        {
            LinkId = Function.CheckNumber(Request.QueryString["LinkId"]) ? int.Parse(Request.QueryString["LinkId"]) : 0;
            model = linkBll.GetModel(LinkId);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        //新增
        else if ((!string.IsNullOrEmpty(Request.QueryString["action"])) && Request.QueryString["action"] == "add")
        {
            TrIsDisable.Visible = TrStatus.Visible = false;
            IsAdd = true;
            btnReg.Text = "添加";
            if (!IsPostBack)
            { BindLinkCategory(); }            
        }
        else
        { Response.Redirect("LinkList.aspx"); }
    }

    /// <summary>
    /// 在查看时绑定数据
    /// </summary>
    void BindData()
    {
        BindLinkCategory();
        
        if (model == null)
        {
            Function.ShowSysMsg(0, "<li>此项目不存在</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (model.LinkType == 1)
        {
            rbTextLink.Checked = true;
        }
        if (model.LinkType == 2)
        {
            rbPicLink.Checked = true;
        }
        for (int i = 0; i < ddlLinkCategory.Items.Count; i++)
        {
            if (model.LinkCategory == ddlLinkCategory.Items[i].Value)
            {
                ddlLinkCategory.SelectedIndex = i;
                break;
            }
        }
        txtRegSiteName.Text = model.SiteName;
        txtRegUrl.Text = model.SiteUrl;
        txtRegLogo.Text = model.SiteLogo;
        txtRegName.Text = model.OwnerName;
        txtEmail.Text = model.Email;
        txtDescription.Text = model.Description;

        lbStatus.Text = model.Status == 1 ? "<span style='color:red'>待审<span>" : "通过";
        btnSetPass.Enabled = model.Status == 1 ? true : false;
        lbIsDisable.Text = model.IsDisable ? "<span style='color:red'>停用</span>" : "正常";
        btnDisable.Text = model.IsDisable ? "启用" : "停用";
        sTitle += model.SiteName;
    }

    /// <summary>
    /// 绑定链接类型
    /// </summary>
    void BindLinkCategory()
    {
        DataTable dt = dictionary.GetDictionary(73);
        if (dt != null)
        {
            ddlLinkCategory.DataSource = dt;
            ddlLinkCategory.DataTextField = "DicName";
            ddlLinkCategory.DataValueField = "Id";
            ddlLinkCategory.DataBind();
        }
    }

    /// <summary>
    /// 修改/新增
    /// </summary>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!CheckInput())
        {
            return;
        }
        if (IsAdd)
        {
            model.IsDisable = false;
            model.Status = 2;
            model.AddTime = DateTime.Now;
        }
        model.Description = txtDescription.Text;
        model.Email = txtEmail.Text;
        model.LinkCategory = ddlLinkCategory.SelectedValue;
        if (rbTextLink.Checked)
        { model.LinkType = 1; }
        if (rbPicLink.Checked)
        { model.LinkType = 2; }
        model.OwnerName = txtRegName.Text;
        model.SiteLogo = txtRegLogo.Text;
        model.SiteName = txtRegSiteName.Text;
        model.SiteUrl = txtRegUrl.Text;
        if (IsAdd)
        {
            linkBll.Add(model);
        }
        else
        {
            linkBll.Update(model);
        }
        Response.Redirect("LinkList.aspx");
    }

    /// <summary>
    /// 检查用户输入
    /// </summary>
    bool CheckInput()
    {
        if (txtRegSiteName.Text == "")
        {
            Function.ShowSysMsg(0,"<li>请输入站点名称</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (txtRegUrl.Text == "")
        {
            Function.ShowSysMsg(0, "<li>请输入站点URL</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (rbPicLink.Checked && txtRegLogo.Text == "")
        {
            Function.ShowSysMsg(0, "<li>请输入LOGO地址</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        return true;
    }

    /// <summary>
    /// 通过审核
    /// </summary>
    protected void btnSetPass_Click(object sender, EventArgs e)
    {
        linkBll.Set(LinkId, 2);
        BindData();
    }


    /// <summary>
    /// 停用/启用
    /// </summary>
    protected void btnDisable_Click(object sender, EventArgs e)
    {
        if (btnDisable.Text == "停用")
        { linkBll.Set(LinkId,3); }
        if (btnDisable.Text == "启用")
        { linkBll.Set(LinkId,4); }
        Response.Redirect("LinkList.aspx");
    }
}
