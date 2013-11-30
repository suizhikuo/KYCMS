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
using System.Text;
using Ky.Model;
using Ky.Common;

public partial class system_info_MoveExpireArticle : System.Web.UI.Page
{
    private B_Article ArticleBll = new B_Article();
    private B_Channel BChannel = new B_Channel();
    private B_Column BColumu = new B_Column();
    protected string ChName = "";
    protected int ChId = 0;
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminGroupBll.Power_Judge(27);
            AjaxPro.Utility.RegisterTypeForAjax(typeof(system_info_MoveExpireArticle));
            BindChannel();
            if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
            {
                try
                {
                    ChId = int.Parse(Request.QueryString["ChId"]);
                }
                catch { }
            }
            if (ChId == 0&&dlistChannel.Items.Count>0)
            {
                Literal litChId = (Literal)dlistChannel.Items[0].FindControl("litChId");
                ChId = int.Parse(litChId.Text);
            }
            if (ChId > 0)
            {
                M_Channel channelModel = BChannel.GetChannel(ChId);
                if (channelModel != null)
                {
                    ChName = channelModel.ChName;
                    BindColumn();
                }
                else
                {
                    Function.ShowSysMsg(0, "<li>所选频道不存在或者已经被删除</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
                }
            }
            else
            {
                Function.ShowSysMsg(0, "<li>请先添加文章模型的频道</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }
    }

    private void BindChannel()
    {
        DataView dv = BChannel.GetChannelByType(1);
        dlistChannel.DataSource = dv;
        dlistChannel.DataBind();
        dv.Dispose();
    }

    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
    public string DoWithExpireArticle(string chId,string colId)
    {
        int expireArticleCount = ArticleBll.GetExpireArticleCount(int.Parse(chId), int.Parse(colId));

        if (expireArticleCount > 0)
        {
            ArticleBll.MoveExprieArticle(int.Parse(chId), int.Parse(colId));
            B_Log.Add(LogType.Move, "成功移动" + expireArticleCount + "项数据：频道编号：" + chId + ",栏目编号：" + colId + "");
            return "成功操作<font color=red>" + expireArticleCount + "</font>项数据";
        }
        else
        {
            return "<font color=red>无任何数据需要归档处理！</font>";
        }
    }

    private void BindColumn()
    {
        DataTable dt = BColumu.GetListItemByChannelId(ChId);
        repColumn.DataSource = dt;
        repColumn.DataBind();
        dt.Dispose();
    }

    /// <summary>
    /// 返回图片条件
    /// </summary>
    /// <param name="ChId"></param>
    /// <param name="ColId"></param>
    /// <param name="Depth"></param>
    /// <returns></returns>
    public string GetImgNum(int ChId, int ColId, int Depth)
    {
        if (ColId == 0) //频道
        {
            return GetImgList(1, 0, 0);
        }
        else
        {
            if (BColumu.ChkHasChildByColId(ColId))
            {
                return GetImgList(1, 0, Depth);
            }
            else
            {
                return GetImgList(0, 1, Depth);
            }
        }
    }

    /// <summary>
    /// 返回图片
    /// </summary>
    /// <param name="Add"></param>
    /// <param name="Del"></param>
    /// <param name="Depth"></param>
    /// <returns></returns>
    public string GetImgList(int Add, int Del, int Depth)
    {
        string sGetImgList = "";

        string AddImg = "<img src='../../images/+.gif' border=0 align='absmiddle'>";
        string DelImg = "<img src='../../images/-.gif' border=0 align='absmiddle'>";
        string DepthList = "<img src='../../images/tree_line.gif' border=0 align='absmiddle'>";

        if (Depth == 0)
        {
            sGetImgList = AddImg;
        }
        else
        {
            for (int i = 0; i < Depth; i++)
            {
                sGetImgList += DepthList;
            }

            if (Add != 0)
            {
                sGetImgList += AddImg;
            }
            else
            {
                sGetImgList += DelImg;
            }
        }

        return sGetImgList;
    }


}
