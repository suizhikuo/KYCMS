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
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class System_Tag_TagList : System.Web.UI.Page
{
    B_Tag TagBll = new B_Tag();
    B_TagCategroy TagCategoryBll = new B_TagCategroy();
    B_InfoModel InfoModelBll = new B_InfoModel();
    protected B_PowerGroup GroupBll = new B_PowerGroup();
    protected int P = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        LitMsg.Text = string.Empty;
        if (Request.QueryString["P"] != null && Request.QueryString["P"] != "")
        {
            try
            {
                P = int.Parse(Request.QueryString["P"]);
            }
            catch
            {
               
            }
        }
        Bind();
        if (!IsPostBack)
        {
            GroupBll.Power_Judge(28);
            TagBll.ClearSearchCount();
            BindDDL();
        }
    }

    private void BindDDL()
    {
        DataTable dt = TagCategoryBll.GetList();
        ddlTagCategoryId.DataTextField = "Name";
        ddlTagCategoryId.DataValueField = "TagCategoryId";
        ddlTagCategoryId.DataSource = dt;
        ddlTagCategoryId.DataBind();
        ddlTagCategoryId.Items.Insert(0, new ListItem("无类别", "0"));
        dt.Dispose();
        dt = InfoModelBll.GetList();
        ddlModelType.DataTextField = "ModelName";
        ddlModelType.DataValueField = "ModelId";
        ddlModelType.DataSource = dt.DefaultView;
        ddlModelType.DataBind();
    }

    private void Bind()
    {
        int recordCount = 0;
        DataTable dt = TagBll.GetList(P, Pager.PageSize, ref recordCount);
        repTag.DataSource = dt;
        repTag.DataBind();
        Pager.RecordCount = recordCount;
        Pager.CurrentPageIndex = P;
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         M_Tag model = new M_Tag();
        model.Name = txtTagName.Text.Trim();
        model.TagCategoryId = int.Parse(ddlTagCategoryId.SelectedValue);
        model.ModelType = int.Parse(ddlModelType.SelectedValue);
        model.UserId = 0;
        model.UserName = "后台管理员";
        if (model.Name.Length == 0 || model.Name.Length > 20)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('关键字名称必须填写');</script>";
            return;
        }
        bool flag = TagBll.Add(model);
        if (!flag)
        {
            LitMsg.Text = "<script type='text/javascript'>alert('该关键字已经存在，无需再添加');</script>";
            return;
        }
        Bind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        int searchCount = 0;
        if (!Function.CheckNumberNotZero(txtSearchCount.Text.Trim()))
        {
            LitMsg.Text = "<script type='text/javascript'>alert('清理关键字搜索次数的条件必须为正整数');</script>";
            return;
        }
        try
        {
            searchCount = int.Parse(txtSearchCount.Text.Trim());
        }
        catch
        { }
        TagBll.Delete(searchCount);
        
        txtSearchCount.Text = "";
        Bind();
    }
}
