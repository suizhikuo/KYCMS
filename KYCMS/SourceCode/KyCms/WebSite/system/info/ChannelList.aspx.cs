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
using System.Text.RegularExpressions;

public partial class System_KyChanel : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup GroupBll = new B_PowerGroup();
    B_InfoModel InfoModelBll = new B_InfoModel();
    int ChType = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        if (!string.IsNullOrEmpty(Request.QueryString["ChType"]))
        {
            try
            {
                ChType = int.Parse(Request.QueryString["ChType"]);
            }
            catch { }
        }
        if (!Page.IsPostBack)
        {
            this.bind();
            BindModelList();
        }
    }

    public void bind()
    {
        B_Channel ch = new B_Channel();
        DataView dv = ch.GetList(false);
        if (ChType != -1)
        {
            DataTable dt = dv.ToTable();
            DataView dv2 = new DataView(dt);
            dv2.RowFilter = "[chtype]=" + ChType;
            repChannel.DataSource = dv2;
            spanAddChannel.Visible = false;
            litAddChannel.Visible = true;
            litAddChannel.Text = "<a href='SetChannel.aspx?ChType="+ChType+"'>添加频道</a>";
        }
        else
        {
            repChannel.DataSource = dv;
        }
        repChannel.DataBind();
    }

    private void BindModelList()
    {
        int chType = 1;
        B_Dictionary dictionBll = new B_Dictionary();
        DataTable chTypeDt = dictionBll.GetDictionary(chType);
        repModelList.DataSource = chTypeDt;
        repModelList.DataBind();
        chTypeDt.Dispose();
    }

    public string GetIsStaticType(object isStaticType)
    {
        string returnStr = "";
        if (isStaticType != null)
        {
            bool flag = Convert.ToBoolean(isStaticType);

            if (flag)
            {
                returnStr = "生成";
            }
            else
            {
                returnStr = "不生成";
            }
        }
        return returnStr;
    }
    public string GetIsDisabled(object isDisabled)
    {
        string returnStr = "";
        if (isDisabled != null)
        {
            bool flag = Convert.ToBoolean(isDisabled);

            if (flag)
            {
                returnStr = "禁用";
            }
            else
            {
                returnStr = "正常";
            }
        }
        return returnStr;
    }
    public string GetBtnText(object isDisabled)
    {
        string returnStr = "";
        if (isDisabled != null)
        {
            bool flag = Convert.ToBoolean(isDisabled);

            if (flag)
            {
                returnStr = "启用";
            }
            else
            {
                returnStr = "禁用";
            }
        }
        return returnStr;
    }

    protected void repChannel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        B_Channel channelBll = new B_Channel();
        int idx = e.Item.ItemIndex;
        Label lbChId = (Label)repChannel.Items[idx].FindControl("ChId");
        Label Type = (Label)repChannel.Items[idx].FindControl("ModelType");
        int chId = int.Parse(lbChId.Text);
        if (e.CommandName == "state")
        {
            GroupBll.Power_Judge(36);
            LinkButton btn = (LinkButton)e.CommandSource;
            if (btn.Text == "禁用")
            {
                channelBll.SetDisable(chId, true);
            }
            else
            {
                channelBll.SetDisable(chId, false);
            }
            this.bind();
        }
        if (e.CommandName == "delete")
        {
            GroupBll.Power_Judge(36);
            channelBll.Delete(chId);
            Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();location.href('ChannelList.aspx');</script>");
        }
    }

}
