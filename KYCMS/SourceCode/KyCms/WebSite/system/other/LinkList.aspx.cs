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

public partial class system_info_LinkList : System.Web.UI.Page
{
    B_Link linkBll = new B_Link();
    B_PowerGroup power = new B_PowerGroup();
    B_Dictionary dictionary = new B_Dictionary();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(19);
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        string whereString = "";
        if (ViewState["whereString"] != null)
        {
            whereString = ViewState["whereString"].ToString();
        }
        DataSet ds = linkBll.GetList(Pager.PageSize, Pager.CurrentPageIndex, whereString);
        if (ds.Tables[0] != null)
        {
            rptLink.DataSource = ds.Tables[0];
            rptLink.DataBind();
            Pager.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        }
        if (!IsPostBack)
        {
            ddlHeaderCategory.DataSource = dictionary.GetDictionary(73);
            ddlHeaderCategory.DataTextField = "DicName";
            ddlHeaderCategory.DataValueField = "Id";
            ddlHeaderCategory.DataBind();
            ddlHeaderLinkType.Items.Add(new ListItem("文字链接", "1"));
            ddlHeaderLinkType.Items.Add(new ListItem("图片链接", "2"));
        }
    }

    protected void rptLinkItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        string[] args = e.CommandArgument.ToString().Split('|');
        int key = int.Parse(args[0]);

        if (e.CommandName == "Delete")
        {
            linkBll.Set(key, 1);
            BindData();
        }
        if (e.CommandName == "Pass")
        {
            linkBll.Set(key, 2);
            BindData();
        }
        if (e.CommandName == "Disable")
        {
            int isDisable = args[1].ToLower() == "true" ? 4 : 3;
            linkBll.Set(key, isDisable);
            BindData();
        }
    }

    protected void rptItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label isDisable = e.Item.FindControl("lbIsDisable") as Label;
            Label statuts = e.Item.FindControl("lbStatus") as Label;
            LinkButton setStatus = e.Item.FindControl("lnkbtnPass") as LinkButton;
            LinkButton setDisable = e.Item.FindControl("lnkbtnDisable") as LinkButton;
            if (isDisable.Text.ToLower() == "true")
            {
                isDisable.Text = "<span style='color:red'>停用</span>";
                setDisable.Text = "启用";
                setDisable.Attributes.Add("onclick", "return confirm('是否启用?')");
            }
            if (isDisable.Text.ToLower() == "false")
            {
                isDisable.Text = "正常";
                setDisable.Text = "停用";
                setDisable.Attributes.Add("onclick", "return confirm('是否停用?')");
            }
            if (statuts.Text == "1")
            {
                statuts.Text = "<span style='color:red'>待审</span>";
                setStatus.Attributes.Add("onclick", "return confirm('是否通过审核?')");
                setStatus.Enabled = true;
            }
            if (statuts.Text == "2")
            {
                setStatus.Enabled = false;
                statuts.Text = "通过";
            }
        }
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }
    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptLink.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rptLink.Items[i].FindControl("chkBox");
            if (chk.Checked)
            {
                Literal id = (Literal)rptLink.Items[i].FindControl("LitId");
                linkBll.Set(int.Parse(id.Text), 1);
            }
        }
        BindData();
    }
    protected void ddlHeaderLinkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["whereString"] = "LinkType=" + ddlHeaderLinkType.SelectedValue;
        BindData();
    }
    protected void ddlHeaderCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["whereString"] = "LinkCategory=" + ddlHeaderCategory.SelectedValue;
        BindData();
    }
    protected void lnkbtnAll_Click(object sender, EventArgs e)
    {
        ViewState["whereString"] = "";
        BindData();
    }
}
