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
using Ky.Common;
using Ky.BLL.CommonModel;
using Ky.Model;
using System.Text.RegularExpressions;
using System.Text;

public partial class List : System.Web.UI.Page
{
    protected B_Create CreateBll = new B_Create();
    protected B_Channel ChannelBll = new B_Channel();
    protected B_SiteInfo SiteBll = new B_SiteInfo();
    B_Column ColumnBll = new B_Column();
    M_Channel ChannelModel = null;
    M_InfoModel InfoModel = null;
    M_Site SiteModel = null;
    M_Column ColumnModel = null;
    protected int ChId = 0;
    protected int ColId = 0;
    bool isSearch = false;
    protected string FieldName = string.Empty;
    protected string Keyword = string.Empty;
    protected int PageIndex = 1;
    protected int PageSize = 20;
    protected int SearchTime = 0;
    protected string StyleContent = string.Empty;
    protected string LoopStr = string.Empty;
    protected string SiteNameStr = string.Empty;
    protected string ChannelNameStr = string.Empty;
    protected string ColumnNameStr = string.Empty;
    protected string KeywordStr = string.Empty;
    string[] styleArray = null;


    B_InfoModel InfoModelBll = new B_InfoModel();
    B_Style StyleBll = new B_Style();

    protected void Page_Load(object sender, EventArgs e)
    {
        PageSize = CreateBll.InfoSiteModel.SearchResultPageSize;
        SearchTime = CreateBll.InfoSiteModel.SearchTime;
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        ChannelModel = ChannelBll.GetChannel(ChId);
        if (ChannelModel == null)
        {
            Function.ShowMsg(0, "<li>搜索参数错误</li>");
        }
        InfoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
        if (InfoModel == null)
        {
            Function.ShowMsg(0, "<li>搜索参数错误</li>");
        }
        DataRow dr = StyleBll.GetSearchStyle(InfoModel.ModelId);

        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColId = int.Parse(Request.QueryString["ColId"]);
                ColumnModel = ColumnBll.GetColumn(ColId);
            }
            catch { }
        }

        if (!string.IsNullOrEmpty(Request.QueryString["search"]))
        {
            isSearch = true;
        }

        if (!string.IsNullOrEmpty(Request.QueryString["FieldName"]))
        {
            FieldName = Request.QueryString["FieldName"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Keyword"]))
        {
            Keyword = Request.QueryString["Keyword"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                PageIndex = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
        if (dr == null || dr["content"].ToString()==string.Empty)
            StyleContent = Param.ListStyle;
        else
            StyleContent = dr["content"].ToString();
 
        styleArray = new string[3];
        GetStyle(styleArray);
        litHeader.Text = styleArray[0];
        LoopStr = styleArray[1];

        
        SiteModel = SiteBll.GetSiteModel();

        SiteNameStr = "<a href=" + CreateBll.GetIndexUrl() + ">" + SiteModel.SiteName + "</a>";
        ChannelNameStr = " >> <a href=" + CreateBll.GetChannelUrl(ChId) + ">" + ChannelModel.ChName + "</a>";
        if(ColumnModel!=null)
            ColumnNameStr = " >> <a href=" + CreateBll.GetColumnUrl(ColId,1) + ">" + ColumnModel.ColName + "</a>";
        if (Keyword.Length != 0)
        {
            if (isSearch)
            {
                KeywordStr = " >> 关键字：" + Function.HtmlEncode(Keyword).Replace("$","&nbsp;&nbsp;");
            }
            else
            {
                KeywordStr = " >> " + Function.HtmlEncode(Keyword).Replace("$", "&nbsp;&nbsp;");
            }
        }
        Header.Title = SiteModel.SiteName + (KeywordStr == string.Empty ? "" : "_" + Keyword) +"_信息列表" ;
        BindInfo();  
    }

    private string GetLocalUrl(string paramName,int paramValue)
    {
        string _localUrl = Request.Url.ToString();
        _localUrl = _localUrl.Substring(0, _localUrl.LastIndexOf("?"));
        _localUrl = _localUrl + "?chid=" + Request.QueryString["chid"] + "&fieldname=" + Request.QueryString["fieldname"] + "&keyword=" + Function.UrlEncode(Request.QueryString["keyword"]);
        string _subUrl = _localUrl.Substring(_localUrl.IndexOf("?") + 1);
        string _patt = "(^|&|\\?)("+   paramName   +"=)([^&]*)(&|$)";
        Match _match = Regex.Match(_subUrl,_patt,RegexOptions.IgnoreCase);
     
       if(_match.Success)
       {
           return Regex.Replace(_localUrl, _match.Value, _match.Groups[1].Value + _match.Groups[2].Value + paramValue + _match.Groups[4].Value, RegexOptions.IgnoreCase);
       }
       else
       {
           return _localUrl + (_localUrl.IndexOf("?") > -1 ? "&" : "?") + paramName + "=" + paramValue;
       }
    }

    private string GetPageNav(int pageIndex, int pageCount, int recordCount, int pageSize, string typeName, string typeUnit)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\">");
        sb.AppendLine("<tr>");
        sb.AppendLine("<td width=\"40%\" align=\"left\">");
        sb.Append(string.Format("当前第{0}/{1}页 共{2}{5} 每页{3}{5}{4}", pageIndex, pageCount, recordCount, PageSize, typeName, typeUnit));
        sb.AppendLine("</td>");
        sb.AppendLine("<td width=\"60%\" align=\"right\">");
        if (pageIndex <= 1)
        {
            sb.Append("<a disabled=\"true\">首页</a>&nbsp;");
            sb.Append("<a disabled=\"true\">上一页</a>&nbsp;");
        }
        else
        {
            sb.Append("<a href=\"" + GetLocalUrl("p", 1) + "\">首页</a>&nbsp;");
            int _prePageIndex = pageIndex - 1;
            sb.Append("<a href=\"" + GetLocalUrl("p", _prePageIndex) + "\">上一页</a>&nbsp;");
        }
        string _pageNumberStr = Function.GetPageNumStr(PageIndex, pageCount, 11);
        string[] _pageNumberArray = _pageNumberStr.Split('|');
        for (int i = 0; i < _pageNumberArray.Length; i++)
        {
            int _currNumber = int.Parse(_pageNumberArray[i]);
            if (_currNumber == PageIndex)
            {
                sb.Append("<a style=\"color:red\">" + _currNumber + "</a>&nbsp;");
            }
            else
            {
                sb.Append("<a href=\"" + GetLocalUrl("p", _currNumber) + "\">" + _currNumber + "</a>&nbsp;");
            }
        }
        if (pageIndex >= pageCount)
        {
            sb.Append("<a disabled=\"true\">下一页</a>&nbsp;");
            sb.Append("<a disabled=\"true\">尾页</a>");
        }
        else
        {
            int _nextPageIndex = pageIndex + 1;
            sb.Append("<a href=\"" + GetLocalUrl("p", _nextPageIndex) + "\">下一页</a>&nbsp;");
            sb.Append("<a href=\"" + GetLocalUrl("p", pageCount) + "\">尾页</a>");
        }
        sb.AppendLine("</td>");
        sb.AppendLine("</tr>");
        sb.AppendLine("</table>");
        return sb.ToString();
    }

    protected void GetStyle(string[] content)
    {
        Match match = Regex.Match(StyleContent, @"((?:.|\n)*?)<ky_loop>((?:.|\n)*?)</ky_loop>((?:.|\n)*)", RegexOptions.IgnoreCase);
        for (int i = 0; i < 3; i++)
        {
            content[i] = match.Groups[i + 1].Value;
        }
    }


    protected void repInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal temp_litItem = (Literal)e.Item.FindControl("litItem");
            StringBuilder sb = new StringBuilder(LoopStr);
            DataRow dr = ((DataRowView)e.Item.DataItem).Row;
            MatchCollection matches = CreateBll.GetStyleFileldName(LoopStr);
            CreateBll.GetListStyleHTML(matches, sb, dr, 0, "yyyy-mm-dd", e.Item.ItemIndex);
            temp_litItem.Text = sb.ToString();
        }
    }



    private void BindInfo()
    {
        int recordCount = 0;
        DataTable dt = null;
        if (isSearch && !CheckSearchTime())
        {
            Function.ShowMsg(0, "<li>很抱歉，" + SearchTime + " 秒内不能再次搜索</li>");
        }
        dt = CreateBll.GetField_InfoList(InfoModel.ModelId, InfoModel.TableName, ChId, ColId, FieldName, Keyword, PageIndex, PageSize, ref recordCount);

        if (isSearch)
        {
            Response.Cookies["SearchTime"].Value = DateTime.Now.ToString();
        }
        repInfo.DataSource = dt;
        repInfo.DataBind();
        dt.Dispose();
        repInfo.Visible = true;
        int _pageCount = (recordCount - 1) / PageSize + 1;
        litHeader.Text = styleArray[0].Replace("{@curr_nav}",SiteNameStr+ChannelNameStr+ColumnNameStr+KeywordStr);
        litFooter.Text = styleArray[2].Replace("{@page_nav}",GetPageNav(PageIndex, _pageCount, recordCount, PageSize, ChannelModel.TypeName, ChannelModel.TypeUnit));
    }

    private bool CheckSearchTime()
    {
        if (SearchTime > 0)
        {
            if (Request.Cookies["SearchTime"] != null)
            {
                string timeStr = Request.Cookies["SearchTime"].Value;
                DateTime time = DateTime.Parse(timeStr);
                DateTime allowTime = time.AddSeconds(SearchTime);
                if (DateTime.Now > allowTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }
}
