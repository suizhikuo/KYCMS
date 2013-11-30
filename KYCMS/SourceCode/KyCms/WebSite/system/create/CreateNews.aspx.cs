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

using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using Ky.SQLServerDAL;
using Ky.BLL;
using Ky.Common;
using Ky.Model;
using Ky.BLL.CommonModel;

public partial class System_create_CreateNews : System.Web.UI.Page, ICallbackEventHandler
{
    B_Channel Bll = new B_Channel();
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup GroupBll = new B_PowerGroup();
    B_SiteInfo SiteBll = new B_SiteInfo();
    B_Channel ChannelBll = new B_Channel();
    M_Site SiteModel = null;
    B_InfoModel InfoModelBll = new B_InfoModel();
    public static int modelId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        modelId = int.Parse(Request.QueryString["modelId"].ToString());
        GroupBll.Power_Judge(7);
        SiteModel = SiteBll.GetSiteModel();
        string rpc = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild", "null", "ShowError", false);

        string func = "function ListData(id) { " + rpc + "; }";

        string rpc1 = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild1", "null", "ShowError", false);
        string func1 = "function ListData1(id) {" + rpc1 + ";}";

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData", func, true);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData1", func1, true);

        if (!IsPostBack)
        {
            BindData();
            BindSpeacil();
            ChannelBind();
            ModelBind();
        }
    }

    void BindData()
    {
        ddlParent.DataSource = Bll.GetChannelByType(modelId);
        ddlParent.DataTextField = "ChName";
        ddlParent.DataValueField = "ChId";
        ddlParent.DataBind();

        ddlCh.DataSource = Bll.GetList(false);
        ddlCh.DataTextField = "ChName";
        ddlCh.DataValueField = "ChId";
        ddlCh.DataBind();
        if (ddlParent.Items.Count > 0)
        {
            int chId = int.Parse(ddlParent.SelectedValue);
            B_Column column = new B_Column();
            ColumnList.DataSource = column.GetFormatListItemByChannelId(chId);
            ColumnList.DataTextField = "ColName";
            ColumnList.DataValueField = "ColId";
            ColumnList.DataBind();

            lbColumn.DataSource = column.GetFormatListItemByChannelId(int.Parse(ddlCh.SelectedValue.ToString()));
            lbColumn.DataTextField = "ColName";
            lbColumn.DataValueField = "ColId";
            lbColumn.DataBind();
        }

    }

    private void ChannelBind()
    {
        B_Channel bll = new B_Channel();
        lbChannel.DataSource = bll.GetList(false);
        lbChannel.DataTextField = "ChName";
        lbChannel.DataValueField = "ChId";
        lbChannel.DataBind();
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
                if (_result == "")
                {
                    _result = _result.Substring(0, _result.Length - 1);
                }
                _result = _result.Substring(0, _result.Length - 1);
            }
        }
    }


    #region 将所有文章生成静态
    protected void btnNewsContent_Click(object sender, EventArgs e)
    {
        if(!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        Response.Redirect("Createing.aspx?type=infoall&modelId=" + modelId);
    }
    #endregion



    #region 首页生成静态按钮事件
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        else
        {
            if (SiteModel.PageType == 4)
            {
                Function.ShowSysMsg(0, "<li>首页已经配置为不生成静态页面</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }
        }
        Response.Redirect("Createing.aspx?type=index");
    }
    #endregion



    #region 将指定范围内的文章生成静态页面
    protected void btnCreateId_Click(object sender, EventArgs e)
    {
        if(!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        #region 验证用户的输入
        bool flag1 = true;
        string msg = "";
        if (txtIdStart.Text != "")
        {
            if (RegPositiveIntegerOP(txtIdStart.Text) == false)
            {
                Function.ShowSysMsg(0, "<li>必须输入正整数</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
                flag1 = false;
            }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>开始ID必须填写</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            flag1 = false;        
        }

        if (txtIdEnd.Text != "" && txtIdStart.Text != "")
        {
            if (RegPositiveIntegerOP(txtIdEnd.Text) == false)
            {
                Function.ShowSysMsg(0, "<li>必须输入正整数</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
                flag1 = false;
            }            
        }
        else
        {
            Function.ShowSysMsg(0, "<li>结束ID必须填写</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            flag1 = false;
        }
        litMessage.Text = msg;
        #endregion

        if (flag1)
        {
            int startid = int.Parse(txtIdStart.Text.ToString().Trim());
            int endid = int.Parse(txtIdEnd.Text.ToString().Trim());
            Response.Redirect("Createing.aspx?type=infoid&startid=" + startid + "&endid=" + endid+"&modelId="+modelId);
        }
    }
    #endregion




    #region 将指定的最新文章的条数生成静态页面
    protected void btnNewsCount_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        string msg = "";
        bool flag1 = true;
        #region 验证用户的输入
        if (txtNewsCount.Text == "")
        {
            Function.ShowSysMsg(0, "<li>文章的条数必须填写</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            flag1 = false;
        }
        else 
        {
            if (RegPositiveIntegerOP(txtNewsCount.Text) == false)
            {
                Function.ShowSysMsg(0, "<li>必须输入正整数</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
                flag1 = false;
            }
        }
        litMessage.Text = msg;
        #endregion

        if (flag1)
        {
            Response.Redirect("Createing.aspx?type=lastinfocount&newsrecordcount=" + int.Parse(txtNewsCount.Text.ToString().Trim())+"&modelId="+modelId);
        }
    }
    #endregion




    #region 将指定日期范围内的文章生成静态页面
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        bool flag2 = true;
        #region 验证日期
        if (txtStartDate.Text == "")
        {
            Function.ShowSysMsg(0, "<li>必须选择开始日期</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            flag2 = false;
        }
        if (txtEndDate.Text == "")
        {
            Function.ShowSysMsg(0, "<li>必须选择结束日期</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            flag2 = false;
        }
        #endregion

        if (flag2)
        {
            Response.Redirect("Createing.aspx?type=infodate&startdate=" + txtStartDate.Text.ToString() + "&enddate=" + txtEndDate.Text.ToString()+"&modelId="+modelId);
        }
    }
    #endregion



    #region 发布指定栏目下的文章
    protected void btnColumnCreate_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        string chid = ddlParent.SelectedValue;
        M_Channel channelModel = ChannelBll.GetChannel(int.Parse(chid));
        if (channelModel == null || !channelModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>所属频道没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        string colIdStr = "";
        colIdStr = Request.Form["ColumnList"].ToString();
        Session["newscolumnid"] = colIdStr;
        Response.Redirect("Createing.aspx?type=infocolumn&modelId="+modelId);
    }
    #endregion



    //正整数
    private static Regex RegPositiveInteger = new Regex(@"^[0-9]*[1-9][0-9]*$");


    /// <summary>
    /// 检测正整数
    /// </summary>
    /// <param name="inputData"></param>
    /// <returns></returns>
    public bool RegPositiveIntegerOP(string inputData)
    {
        Match m = RegPositiveInteger.Match(inputData);
        return m.Success;
    }

    protected void btnCreateColumn_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }

        string chid = ddlCh.SelectedValue;
        M_Channel channelModel = ChannelBll.GetChannel(int.Parse(chid));
        if (channelModel == null || !channelModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>所属频道没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        string colIdStr = "";
        B_Create bll = new B_Create();
        colIdStr = Request.Form["lbColumn"].ToString();
        Session["createcolid"] = colIdStr;
        Response.Redirect("Createing.aspx?type=column");
    }

    private void BindSpeacil()
    {
        B_Special bll = new B_Special();
        DataTable dt = bll.GetAllSpecial();
        foreach (DataRow dr in dt.Rows)
        {
            string colname = dr["SpecialCName"].ToString();
            int colid = Convert.ToInt32(dr["ID"].ToString());
            int depth = int.Parse(dr["Depth"].ToString());
            for (int i = 0; i < depth; i++)
            {
                colname = "├┄" + colname;
            }
            lbSpeacil.Items.Add(new ListItem(colname, colid.ToString()));
        }
    }
    protected void btnCreateSpeacil_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        string specialStr = Request.Form["lbSpeacil"].ToString();
        Session["createspecialstr"] = specialStr;
        Response.Redirect("Createing.aspx?type=special");
    }
    protected void btnCreateChannel_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        string chIdStr = "";
        B_Create bll = new B_Create();
        for (int i = 0; i < lbChannel.Items.Count;i++ )
        {
            if(lbChannel.Items[i].Selected)
            {
                string chid = lbChannel.Items[i].Value;
                M_Channel channelModel = ChannelBll.GetChannel(int.Parse(chid));
                if (channelModel != null && channelModel.IsStaticType)
                {
                    chIdStr = chIdStr + chid + ",";
                }
            }
        }
        if (chIdStr == string.Empty)
        {
            Function.ShowSysMsg(0, "<li>所属频道没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        chIdStr = chIdStr.Substring(0, (chIdStr.Length - 1));
        Session["createchid"] = chIdStr;
        Response.Redirect("Createing.aspx?type=channel&modelId="+modelId);
        
    }
    #region 发布所有栏目
    protected void btnCreateColumnAll_Click(object sender, EventArgs e)
    {
        if (!SiteModel.IsStaticType)
        {
            Function.ShowSysMsg(0, "<li>全站参数设置没有开启生成静态页面功能</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
        }
        Response.Redirect("Createing.aspx?type=columnall");
    }
    #endregion

    private void ModelBind()
    {
        repModel.DataSource = InfoModelBll.GetList();
        repModel.DataBind();
    }
}
