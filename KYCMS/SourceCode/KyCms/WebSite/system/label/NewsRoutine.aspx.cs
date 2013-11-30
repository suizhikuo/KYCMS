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

public partial class System_label_NewsRoutine : System.Web.UI.Page, ICallbackEventHandler
{
    B_Channel bll = new B_Channel();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        AdminGroupBll.Power_Judge(6);
        string rpc = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild", "null", "ShowError", false);
        string rpc1 = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild1", "null", "ShowError", false);
        string rpc2 = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild2", "null", "ShowError", false);

        string func = "function ListData(id) { " + rpc + "; }";
        string func1 = "function ListData1(id){"+rpc1+"}";
        string func2 = "function ListData2(id){" + rpc2 + "}";

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData", func, true);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"ListData1",func1,true);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData2", func2, true);

        if (!IsPostBack)
        {
            StyleBind();
            VoteBind();
            BindData();
        }
    }
    #region 绑定投票的主题
    private void VoteBind()
    {
        B_Vote bllVote = new B_Vote();
        DataTable dt = bllVote.GetAll();
        DataView dv = dt.DefaultView;
        dv.RowFilter = "EndDate>'" + DateTime.Now.Date + "'";
        ddlVote.DataSource = dv;
        ddlVote.DataTextField = "Subject";
        ddlVote.DataValueField = "VoteSubjectId";
        DataBind();
    }
    #endregion

    #region 绑定样式所有列表
    private void StyleBind()
    {
        B_Style bllStyle = new B_Style();
        ddlStyle.DataSource = bllStyle.GetAllStyle();
        ddlStyle.DataTextField = "Name";
        ddlStyle.DataValueField = "StyleID";
        ddlStyle.DataBind();

        dropStyle.DataSource = bllStyle.GetAllStyle();
        dropStyle.DataTextField = "Name";
        dropStyle.DataValueField = "StyleID";
        dropStyle.DataBind();
    }
    #endregion

    void BindData()
    {
        ddlParent.DataSource = bll.GetList(false);
        ddlParent.DataTextField = "ChName";
        ddlParent.DataValueField = "ChId";
        ddlParent.DataBind();

        #region 首页栏目导航频道
        ddlNavChannel.DataSource = bll.GetList(false);
        ddlNavChannel.DataTextField = "ChName";
        ddlNavChannel.DataValueField = "ChId";
        ddlNavChannel.DataBind();
        #endregion

        #region 文字头条频道与栏目
        ddlChHeader.DataSource = bll.GetChannelByType(1);
        ddlChHeader.DataTextField = "ChName";
        ddlChHeader.DataValueField = "ChId";
        ddlChHeader.DataBind();
        #endregion 

        #region 图片头条
        ddlPicChHeader.DataSource = bll.GetChannelByType(1);
        ddlPicChHeader.DataTextField = "ChName";
        ddlPicChHeader.DataValueField = "ChId";
        ddlPicChHeader.DataBind();
        #endregion

        int chId = int.Parse(ddlParent.SelectedValue);

        B_Column column = new B_Column();
        ddlChild.DataSource = column.GetFormatListItemByChannelId(chId);
        ddlChild.DataTextField = "ColName";
        ddlChild.DataValueField = "ColId";
        ddlChild.DataBind();
        ddlChild.Items.Insert(0, new ListItem("当前栏目", "0"));
        ddlChild.Items.Insert(1, new ListItem("所有栏目", "all"));

        #region 文字头条频道与栏目
        ddlCoHeader.DataSource = column.GetFormatListItemByChannelId(chId);
        ddlCoHeader.DataTextField = "ColName";
        ddlCoHeader.DataValueField = "ColId";
        ddlCoHeader.DataBind();
        #endregion

        #region 文字头条
        ddlPicCoHeader.DataSource = column.GetFormatListItemByChannelId(chId);
        ddlPicCoHeader.DataTextField = "ColName";
        ddlPicCoHeader.DataValueField = "ColId";
        ddlPicCoHeader.DataBind();
        #endregion
    }
    private string _result;
    public string GetCallbackResult()
    {
        return _result;
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
        if (!string.IsNullOrEmpty(eventArgument))
        {
            if (eventArgument != "0")
            {

                B_Column column = new B_Column();
                int chid = int.Parse(eventArgument);
                DataTable dt = column.GetFormatListItemByChannelId(chid);
                foreach (DataRow row in dt.Rows)
                {
                    _result += row["ColName"].ToString();
                    _result += ",";
                    _result += row["ColId"].ToString();
                    _result += "|";
                }
                if (_result != null && _result.Length > 0)
                {
                    _result = _result.Substring(0, _result.Length - 1);
                }

            }
        }
    }
}
