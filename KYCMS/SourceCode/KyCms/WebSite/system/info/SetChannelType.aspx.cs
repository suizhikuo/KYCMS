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

public partial class system_info_SetChannelType : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Channel ChannelBll = new B_Channel();
    int ChId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(36);
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        M_Channel channelModel = ChannelBll.GetChannel(ChId);
        if (channelModel == null)
        {
            Response.Write("<script>alert('频道参数错误');window.close();</script>");
            return;
        }
        if (!IsPostBack)
        {
            BindChType(channelModel.ChType);
        }
        
    }

    private void BindChType(int chType)
    {
        int ChTypeDicID = 1;
        B_Dictionary dicBll = new B_Dictionary();
        DataTable dt = dicBll.GetDictionary(ChTypeDicID);
        ddlChType.DataTextField = "dicname";
        ddlChType.DataValueField = "id";
        ddlChType.DataSource = dt.DefaultView;
        ddlChType.DataBind();
        ddlChType.Items.Add(new ListItem("其他","0"));
        dt.Dispose();
        try
        {
            ddlChType.SelectedValue = chType.ToString();
        }
        catch { }
    }
    protected void btnSetChType_Click(object sender, EventArgs e)
    {
        M_Channel channelModel = ChannelBll.GetChannel(ChId);
        channelModel.ChType = int.Parse(ddlChType.SelectedValue);
        ChannelBll.Update(channelModel);
        ChannelBll.ClearCache();
        Response.Write("<script>opener.parent.document.frames['LeftIframe'].location.reload();window.close();opener.location.href('ChannelList.aspx?chtype=" + ddlChType.SelectedValue + "');</script>");
    }
}
