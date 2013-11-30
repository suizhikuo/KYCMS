using Ky.BLL.CommonModel;
using Ky.Common;
using Ky.DALFactory;
using Ky.Model;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace Ky.BLL
{
    public class B_Create
    {
        private const string AddFav = "addfav";
        private const string ApplicationPath = "applicationpath";
        private B_Article ArticleBll = new B_Article();
        private const int ARTICLEMODELID = 1;
        private const string BannerAddress = "banner";
        private const string Browse_Info = "browse_info";
        private const string Ch_Col_InfoList = "ch_col_infolist";
        private const string Ch_Col_Nav = "ch_col_nav";
        private const string Ch_InfoList = "ch_infolist";
        private B_Channel ChannelBll = new B_Channel();
        private Hashtable channelCache = new Hashtable();
        private const string Col_ChildCol_InfoList = "col_childcol_infolist";
        private const string Col_ChildCol_Nav = "col_childcol_nav";
        private const string Col_FinallyInfoList = "col_finallyinfolist";
        private const string Col_FlashInfoList = "col_flashinfolist";
        private const string Col_InfoList = "col_infolist";
        private B_Column ColumnBll = new B_Column();
        private Hashtable columnCache = new Hashtable();
        protected string ColumnsContent = "";
        private const string CommentFrom = "review";
        private const string copyRight = "\r\n ShareWin";
        private const string Copyright = "copyright";
        private const string CurrChId = "currchid";
        private const string CurrColId = "currcolid";
        private const string CurrInfoId = "currinfoid";
        private const string CurrUserInfo = "curruserinfo";
        private ICreate dal = DataAccess.Create();
        private const string DomainName = "domain";
        private string HostAddress = string.Empty;
        private const string Image_HeaderArticleList = "article_img_headerlist";
        private const string Index_Ch_Nav = "index_ch_nav";
        private const string Index_Col_Nav = "index_col_nav";
        private const string Index_Sp_Nav = "index_sp_nav";
        private const string Info_RelationInfoList = "info_relationinfolist";
        private DataTable InfoFieldCaChe = null;
        private B_InfoModel InfoModelBll = new B_InfoModel();
        private B_InfoOper InfoOperBll = new B_InfoOper();
        public M_InfoSite InfoSiteModel = null;
        private const string InfoTotal = "infototal";
        private const string KyLink = "kylink";
        private Hashtable lbCache = new Hashtable();
        private const string Login = "login";
        private const string LogoAddress = "logo";
        private DataTable modelCache = null;
        private B_ModelField ModelFieldBll = new B_ModelField();
        private const string MoreRevieList = "morereviewlist";
        private const string My_Pos = "my_pos";
        protected string[] MyColumnsContent;
        protected string[] MySqlContent;
        private const string Page_Info = "page_info";
        private const string PvTotal = "pvtotal";
        private const string Report = "report";
        private const string ReviewList = "reviewlist";
        private const string Rss_Link = "rsslink";
        private Hashtable SearchChColCache = new Hashtable();
        private const string SearchForm = "searchform";
        private B_SiteInfo SiteBll = new B_SiteInfo();
        public M_Site SiteModel = null;
        private const string SiteName = "sitename";
        private const string Sp_Nav = "sp_nav";
        private const string SpeciaiRemark = "specialremark";
        private const string Special_InfoList = "special_infolist";
        private B_Special SpecialBll = new B_Special();
        private const string SpecialCustomContent = "specialcontent";
        private const string SpecialImg = "specialimg";
        protected string SqlContent = "";
        private B_Style StyleBll = new B_Style();
        private Hashtable styleCache = new Hashtable();
        private Hashtable templateCache = new Hashtable();
        private const string Text_HeaderArticleList = "article_txt_headerlist";
        private DataTable UserFieldCache = null;
        private B_UserGroupModel UserGroupModelBll = new B_UserGroupModel();
        private const string Vote = "vote";

        public B_Create()
        {
            this.SiteModel = this.SiteBll.GetSiteModel();
            this.InfoSiteModel = this.SiteBll.GetInfoModel();
            if (this.SiteModel.IsAbsPathType)
            {
                this.HostAddress = this.SiteModel.Domain;
            }
            else
            {
                this.HostAddress = Param.ApplicationRootPath;
            }
        }

        private string Article_Img_GetHeaderList(string paramStr)
        {
            string paramValue = "0";
            this.GetParamValue(paramStr, "colid", ref paramValue);
            DataTable table = this.dal.GetArticle_HeadeList(1, int.Parse(paramValue), true);
            string str2 = string.Empty;
            if (table.Rows.Count > 0)
            {
                DataRow dr = table.Rows[0];
                str2 = string.Concat(new object[] { "<a href='", this.GetInfoUrl(dr), "' target='_blank'><img src='", this.GetHeaderImg(dr), "' alt='", dr["title"], "' border='0'/></a>\r\n" });
            }
            return str2;
        }

        private string Article_Text_GetHeaderList(string paramStr)
        {
            string paramValue = "0";
            string str2 = "5";
            string str3 = "1";
            string str4 = "30";
            string str5 = "left";
            this.GetParamValue(paramStr, "colid", ref paramValue);
            this.GetParamValue(paramStr, "infocount", ref str2);
            this.GetParamValue(paramStr, "cellcount", ref str3);
            this.GetParamValue(paramStr, "titleLength", ref str4);
            this.GetParamValue(paramStr, "align", ref str5);
            DataTable table = this.dal.GetArticle_HeadeList(int.Parse(str2), int.Parse(paramValue), false);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            builder.AppendLine("<tr>");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str9;
                DataRow dr = table.Rows[i];
                string str6 = dr["headerfont"].ToString();
                builder.AppendLine("<td align='" + str5 + "'>");
                string[] strArray = str6.Split(new char[] { '|' });
                if (strArray.Length != 4)
                {
                    goto Label_022D;
                }
                string input = string.Empty;
                input = strArray[0];
                string str8 = string.Empty;
                string str12 = strArray[1];
                if ((str12 != null) && !(str12 == "常规"))
                {
                    if (str12 == "粗体")
                    {
                        goto Label_016B;
                    }
                    if (str12 == "斜体")
                    {
                        goto Label_0174;
                    }
                }
                str8 = string.Empty;
                goto Label_017D;
            Label_016B:
                str8 = "font-weight:bold;";
                goto Label_017D;
            Label_0174:
                str8 = "font-style:italic;";
            Label_017D:
                str9 = string.Empty;
                str9 = "font-size:" + strArray[2] + ";";
                string str10 = string.Empty;
                str10 = "color:#" + strArray[3];
                builder.AppendLine("<a href='" + this.GetInfoUrl(dr) + "' target='_blank'><span style='" + str8 + str9 + str10 + "'>" + this.SiteBll.GetFiltering(this.SubStr(input, int.Parse(str4), "")) + "</span></a>");
            Label_022D:
                builder.AppendLine("</td>");
                int num2 = 1;
                try
                {
                    num2 = int.Parse(str3);
                }
                catch
                {
                }
                int num3 = i + 1;
                if (((num2 > 1) && ((num3 % num2) == 0)) && (num2 != table.Rows.Count))
                {
                    builder.AppendLine("</tr>");
                    builder.AppendLine("<tr>");
                }
            }
            builder.AppendLine("</tr>");
            builder.AppendLine("</table>");
            table.Dispose();
            return builder.ToString();
        }

        private string Ch_Col_GetInfoList(string paramStr, int currChId)//栏目循环
        {
            string paramValue = "0";
            string str2 = "0";
            string str3 = string.Empty;
            string str4 = "0";
            string str5 = "1";
            string str6 = "out_table";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            this.GetParamValue(paramStr, "chid", ref paramValue);
            this.GetParamValue(paramStr, "colcount", ref str2);
            this.GetParamValue(paramStr, "colidstr", ref str3);
            this.GetParamValue(paramStr, "colstyle", ref str4);
            this.GetParamValue(paramStr, "colcellcount", ref str5);
            this.GetParamValue(paramStr, "showstyle", ref str6);
            this.GetParamValue(paramStr, "divid", ref str7);
            this.GetParamValue(paramStr, "divclass", ref str8);
            this.GetParamValue(paramStr, "ulid", ref str9);
            this.GetParamValue(paramStr, "ulclass", ref str10);
            int chId = 0;
            if (paramValue == "0")
            {
                chId = currChId;
            }
            else
            {
                chId = int.Parse(paramValue);
            }
            if (chId == 0)
            {
                return string.Empty;
            }
            int cellCount = 0;
            try
            {
                cellCount = int.Parse(str5);
            }
            catch
            {
            }
            string styleContent = this.GetStyleContent(int.Parse(str4));
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            DataTable table = this.dal.GetChannel_Column_InfoList(chId, int.Parse(str2), str3);
            StringBuilder sb = new StringBuilder();
            int count = table.Rows.Count;
            this.SetLabelHeaderHTML2(sb, str6, cellCount);
            for (int i = 0; i < count; i++)
            {
                DataRow dr = table.Rows[i];
                string str12 = styleContent;
                this.SetLabelBodyHeaderHTML(sb, str6, cellCount, true);
                foreach (Match match in styleFileldName)
                {
                    if (match.Groups.Count > 1)
                    {
                        string input = match.Groups[1].Value.Trim().ToLower();
                        string apiName = string.Empty;
                        string param = string.Empty;
                        Match match2 = Regex.Match(input, @"(.*?)#(.*?)\((.*?)\)");
                        if (match2.Success)
                        {
                            input = match2.Groups[1].Value;
                            apiName = match2.Groups[2].Value;
                            param = match2.Groups[3].Value;
                        }
                        switch (input)
                        {
                            case "rowindex":
                                goto Label_02B5;

                            case "columnurl":
                                goto Label_02CF;
                        }
                        str12 = str12.Replace(match.Value, this.GetCommonFiled(dr, input, apiName, param));
                    }
                    goto Label_02EA;
                Label_02B5:
                    str12 = str12.Replace(match.Value, this.GetRowIndex(i));
                    goto Label_02EA;
                Label_02CF:
                    str12 = str12.Replace(match.Value, this.GetColumnUrl(dr));
                Label_02EA: ;
                }
                sb.AppendLine(str12);
                int currColId = (int)dr["ColId"];
                string listStr = this.Col_GetInfoList(paramStr, currColId);
                this.SetLabelBodyHTML2(sb, listStr, str6, str7, str8, str9, str10);
                this.SetLableBodyFooterHTML(sb, str6, cellCount, i, count);
            }
            this.SetLabelFooterHTML2(sb, str6, cellCount);
            table.Dispose();
            return sb.ToString();
        }

        private string Ch_Col_GetNav(string paramStr, int currChId)
        {
            string paramValue = "";
            string str2 = "";
            string str3 = "";
            string str4 = "10";
            string str5 = string.Empty;
            this.GetParamValue(paramStr, "navcss", ref paramValue);
            this.GetParamValue(paramStr, "arrange", ref str2);
            this.GetParamValue(paramStr, "compart", ref str3);
            this.GetParamValue(paramStr, "navcount", ref str4);
            this.GetParamValue(paramStr, "target", ref str5);
            DataView firstColumnByChannelId = this.ColumnBll.GetFirstColumnByChannelId(currChId);
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= firstColumnByChannelId.Count; i++)
            {
                int colId = (int)firstColumnByChannelId[i - 1]["colid"];
                string str6 = firstColumnByChannelId[i - 1]["colname"].ToString();
                string str7 = firstColumnByChannelId[i - 1]["content"].ToString();
                if (str2 == "true")
                {
                    if (((i % int.Parse(str4)) == 0) && (i != firstColumnByChannelId.Count))
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a><br/>", new object[] { this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6 }));
                    }
                    else if (i == firstColumnByChannelId.Count)
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a>", new object[] { this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6 }));
                    }
                    else
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a>{5}", new object[] { this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6, str3 }));
                    }
                }
                else
                {
                    builder.Append(string.Format("{0}<a href=\"{1}\" target=\"{2}\" title=\"{3}\" class=\"{4}\">{5}</a></br>", new object[] { str3, this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6 }));
                }
            }
            return builder.ToString();
        }

        private string Ch_GetInfoList(string paramStr, int currChId)
        {
            if (this.channelCache.Contains(paramStr) && (currChId == 0))
            {
                return (string)this.channelCache[paramStr];
            }
            string paramValue = "0";
            string str2 = "0";
            string str3 = "0";
            string str4 = "out_table";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "1";
            string str10 = "yyyy-mm-dd";
            string str11 = "10";
            string str12 = "";
            string str13 = "";
            string str14 = "10";
            string str15 = "datedesc";
            string str16 = "30";
            string str17 = "0";
            string str18 = "";
            string str19 = "";
            this.GetParamValue(paramStr, "modelid", ref paramValue);
            this.GetParamValue(paramStr, "chid", ref str2);
            this.GetParamValue(paramStr, "liststyle", ref str3);
            this.GetParamValue(paramStr, "showstyle", ref str4);
            this.GetParamValue(paramStr, "divid", ref str5);
            this.GetParamValue(paramStr, "divclass", ref str6);
            this.GetParamValue(paramStr, "ulid", ref str7);
            this.GetParamValue(paramStr, "ulclass", ref str8);
            this.GetParamValue(paramStr, "cellcount", ref str9);
            this.GetParamValue(paramStr, "dateformat", ref str10);
            this.GetParamValue(paramStr, "infocount", ref str11);
            this.GetParamValue(paramStr, "property1", ref str12);
            this.GetParamValue(paramStr, "property2", ref str13);
            this.GetParamValue(paramStr, "daterange", ref str14);
            this.GetParamValue(paramStr, "order", ref str15);
            this.GetParamValue(paramStr, "titlelength", ref str16);
            this.GetParamValue(paramStr, "rowcount", ref str17);
            this.GetParamValue(paramStr, "compart", ref str18);
            this.GetParamValue(paramStr, "ajaxflag", ref str19);
            if (str19.Length != 0)
            {
                return string.Format("<script language=\"javascript\">GetAjaxLabel(\"{0}\",\"{1}\",{2},\"{3}\")</script>", new object[] { Param.ApplicationRootPath + "/common/GetAjaxLabel.aspx", Ky.Common.Function.UrlEncode(paramStr), currChId, "ch" });
            }
            int id = 0;
            if (str2 == "0")
            {
                id = currChId;
            }
            else
            {
                id = int.Parse(str2);
            }
            if (id == 0)
            {
                return string.Empty;
            }
            M_Channel channel = this.ChannelBll.GetChannel(id);
            if (channel == null)
            {
                return string.Empty;
            }
            string tableName = this.GetTableName(channel.ModelType);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            string typeStr = this.GetTypeStr(str12, id, str13);
            string dateRangeStr = this.GetDateRangeStr(str14);
            string orderStr = this.GetOrderStr(str15);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            int cellCount = 1;
            int totalCount = 0;
            int rowCount = 0;
            try
            {
                cellCount = int.Parse(str9);
                rowCount = int.Parse(str17);
            }
            catch
            {
            }
            DataTable table = this.dal.GetChannel_InfoList(tableName, int.Parse(str11), id, typeStr, dateRangeStr, orderStr);
            totalCount = table.Rows.Count;
            string styleContent = this.GetStyleContent(int.Parse(str3));
            StringBuilder sb = new StringBuilder();
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            this.SetLabelHeaderHTML(sb, str4, cellCount);
            for (int i = 0; i < totalCount; i++)
            {
                DataRow dr = table.Rows[i];
                StringBuilder builder2 = new StringBuilder(styleContent);
                this.GetListStyleHTML(styleFileldName, builder2, dr, int.Parse(str16), str10, i);
                this.SetLabelBodyHTML(sb, builder2, str4, cellCount, i, totalCount);
                this.SetCompartHMTL(sb, str4, cellCount, rowCount, i, totalCount, str18);
            }
            this.SetLabelFooterHTML(sb, str4, cellCount);
            table.Dispose();
            if (currChId == 0)
            {
                this.channelCache.Add(paramStr, sb.ToString());
            }
            return sb.ToString();
        }

        public string Ch_GetInfoList_Ajax(string paramStr, int currChId)
        {
            string paramValue = "0";
            string str2 = "0";
            string str3 = "0";
            string str4 = "out_table";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "1";
            string str10 = "yyyy-mm-dd";
            string str11 = "10";
            string str12 = "";
            string str13 = "";
            string str14 = "10";
            string str15 = "datedesc";
            string str16 = "30";
            string str17 = "0";
            string str18 = "";
            this.GetParamValue(paramStr, "modelid", ref paramValue);
            this.GetParamValue(paramStr, "chid", ref str2);
            this.GetParamValue(paramStr, "liststyle", ref str3);
            this.GetParamValue(paramStr, "showstyle", ref str4);
            this.GetParamValue(paramStr, "divid", ref str5);
            this.GetParamValue(paramStr, "divclass", ref str6);
            this.GetParamValue(paramStr, "ulid", ref str7);
            this.GetParamValue(paramStr, "ulclass", ref str8);
            this.GetParamValue(paramStr, "cellcount", ref str9);
            this.GetParamValue(paramStr, "dateformat", ref str10);
            this.GetParamValue(paramStr, "infocount", ref str11);
            this.GetParamValue(paramStr, "property1", ref str12);
            this.GetParamValue(paramStr, "property2", ref str13);
            this.GetParamValue(paramStr, "daterange", ref str14);
            this.GetParamValue(paramStr, "order", ref str15);
            this.GetParamValue(paramStr, "titlelength", ref str16);
            this.GetParamValue(paramStr, "rowcount", ref str17);
            this.GetParamValue(paramStr, "compart", ref str18);
            int id = 0;
            if (str2 == "0")
            {
                id = currChId;
            }
            else
            {
                id = int.Parse(str2);
            }
            if (id == 0)
            {
                return string.Empty;
            }
            M_Channel channel = this.ChannelBll.GetChannel(id);
            if (channel == null)
            {
                return string.Empty;
            }
            string tableName = this.GetTableName(channel.ModelType);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            string typeStr = this.GetTypeStr(str12, id, str13);
            string dateRangeStr = this.GetDateRangeStr(str14);
            string orderStr = this.GetOrderStr(str15);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            int cellCount = 1;
            int totalCount = 0;
            int rowCount = 0;
            try
            {
                cellCount = int.Parse(str9);
                rowCount = int.Parse(str17);
            }
            catch
            {
            }
            DataTable table = this.dal.GetChannel_InfoList(tableName, int.Parse(str11), id, typeStr, dateRangeStr, orderStr);
            totalCount = table.Rows.Count;
            string styleContent = this.GetStyleContent(int.Parse(str3));
            StringBuilder sb = new StringBuilder();
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            this.SetLabelHeaderHTML(sb, str4, cellCount);
            for (int i = 0; i < totalCount; i++)
            {
                DataRow dr = table.Rows[i];
                StringBuilder builder2 = new StringBuilder(styleContent);
                this.GetListStyleHTML(styleFileldName, builder2, dr, int.Parse(str16), str10, i);
                this.SetLabelBodyHTML(sb, builder2, str4, cellCount, i, totalCount);
                this.SetCompartHMTL(sb, str4, cellCount, rowCount, i, totalCount, str18);
            }
            this.SetLabelFooterHTML(sb, str4, cellCount);
            table.Dispose();
            return sb.ToString();
        }

        private string Ch_GetPageInfo(string paramStr, int chId)
        {
            string paramValue = "0";
            this.GetParamValue(paramStr, "type", ref paramValue);
            M_Channel channel = this.ChannelBll.GetChannel(chId);
            switch (paramValue)
            {
                case "1":
                    return channel.ChName;

                case "2":
                    return channel.Keyword;

                case "3":
                    return channel.Content;
            }
            return string.Empty;
        }

        public bool CheckColumn(DataRow dr, string name)
        {
            return dr.Table.Columns.Contains(name);
        }

        public void ClearHashTable()
        {
            if (this.lbCache != null)
            {
                this.lbCache.Clear();
            }
            if (this.styleCache != null)
            {
                this.styleCache.Clear();
            }
            if (this.channelCache != null)
            {
                this.channelCache.Clear();
            }
            if (this.columnCache != null)
            {
                this.columnCache.Clear();
            }
            if (this.templateCache != null)
            {
                this.templateCache.Clear();
            }
            if (this.SearchChColCache != null)
            {
                this.SearchChColCache.Clear();
            }
            if (this.InfoFieldCaChe != null)
            {
                this.InfoFieldCaChe.Dispose();
            }
            if (this.UserFieldCache != null)
            {
                this.UserFieldCache.Dispose();
            }
        }

        private string Col_ChildCol_GetInfoList(string paramStr, int currColId)
        {
            string paramValue = "0";
            string str2 = "0";
            string str3 = "0";
            string str4 = "1";
            string str5 = "out_table";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            this.GetParamValue(paramStr, "colId", ref paramValue);
            this.GetParamValue(paramStr, "colcount", ref str2);
            this.GetParamValue(paramStr, "colstyle", ref str3);
            this.GetParamValue(paramStr, "colcellcount", ref str4);
            this.GetParamValue(paramStr, "showstyle", ref str5);
            this.GetParamValue(paramStr, "divid", ref str6);
            this.GetParamValue(paramStr, "divclass", ref str7);
            this.GetParamValue(paramStr, "ulid", ref str8);
            this.GetParamValue(paramStr, "ulclass", ref str9);
            int colId = 0;
            if (paramValue == "0")
            {
                colId = currColId;
            }
            else
            {
                colId = int.Parse(paramValue);
            }
            if (colId == 0)
            {
                return string.Empty;
            }
            int cellCount = 0;
            try
            {
                cellCount = int.Parse(str4);
            }
            catch
            {
            }
            string styleContent = this.GetStyleContent(int.Parse(str3));
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            DataTable table = this.dal.GetColumn_ChildCol_InfoList(colId, int.Parse(str2));
            StringBuilder sb = new StringBuilder();
            int count = table.Rows.Count;
            this.SetLabelHeaderHTML2(sb, str5, cellCount);
            for (int i = 0; i < count; i++)
            {
                DataRow dr = table.Rows[i];
                string str11 = styleContent;
                this.SetLabelBodyHeaderHTML(sb, str5, cellCount, false);
                foreach (Match match in styleFileldName)
                {
                    if (match.Groups.Count > 1)
                    {
                        string input = match.Groups[1].Value.Trim().ToLower();
                        string apiName = string.Empty;
                        string param = string.Empty;
                        Match match2 = Regex.Match(input, @"(.*?)#(.*?)\((.*?)\)");
                        if (match2.Success)
                        {
                            input = match2.Groups[1].Value;
                            apiName = match2.Groups[2].Value;
                            param = match2.Groups[3].Value;
                        }
                        switch (input)
                        {
                            case "rowindex":
                                goto Label_029D;

                            case "columnurl":
                                goto Label_02B7;
                        }
                        str11 = str11.Replace(match.Value, this.GetCommonFiled(dr, input, apiName, param));
                    }
                    goto Label_02D2;
                Label_029D:
                    str11 = str11.Replace(match.Value, this.GetRowIndex(i));
                    goto Label_02D2;
                Label_02B7:
                    str11 = str11.Replace(match.Value, this.GetColumnUrl(dr));
                Label_02D2: ;
                }
                sb.AppendLine(str11);
                int num5 = (int)dr["ColId"];
                string listStr = this.Col_GetInfoList(paramStr, num5);
                this.SetLabelBodyHTML2(sb, listStr, str5, str6, str7, str8, str9);
                this.SetLableBodyFooterHTML(sb, str5, cellCount, i, count);
            }
            this.SetLabelFooterHTML2(sb, str5, cellCount);
            table.Dispose();
            return sb.ToString();
        }

        private string Col_ChildCol_GetNav(string paramStr, int currColId)
        {
            string paramValue = "";
            string str2 = "";
            string str3 = "";
            string str4 = "10";
            string str5 = string.Empty;
            this.GetParamValue(paramStr, "navcss", ref paramValue);
            this.GetParamValue(paramStr, "arrange", ref str2);
            this.GetParamValue(paramStr, "compart", ref str3);
            this.GetParamValue(paramStr, "navcount", ref str4);
            this.GetParamValue(paramStr, "target", ref str5);
            DataView childColumn = this.ColumnBll.GetChildColumn(currColId);
            if (this.ColumnBll.GetColumn(currColId) == null)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= childColumn.Count; i++)
            {
                int colId = (int)childColumn[i - 1]["colid"];
                string str6 = childColumn[i - 1]["colname"].ToString();
                string str7 = childColumn[i - 1]["content"].ToString();
                if (str2 == "true")
                {
                    if (((i % int.Parse(str4)) == 0) && (i != childColumn.Count))
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a><br/>", new object[] { this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6 }));
                    }
                    else if (i == childColumn.Count)
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a>", new object[] { this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6 }));
                    }
                    else
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a>{5}", new object[] { this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6, str3 }));
                    }
                }
                else
                {
                    builder.Append(string.Format("{0}<a href=\"{1}\" target=\"{2}\" title=\"{3}\" class=\"{4}\">{5}</a></br>", new object[] { str3, this.GetColumnUrl(colId, 1), str5, str7, paramValue, str6 }));
                }
            }
            return builder.ToString();
        }

        private string Col_GetFinallyInfoList(string paramStr, int currColId, int pageIndex, int recordCount)
        {
            string paramValue = "false";
            string str2 = "1";
            string str3 = "";
            string str4 = "0";
            string str5 = "false";
            string str6 = "0";
            string str7 = "out_table";
            string str8 = "1";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = "";
            string str14 = "";
            string str15 = "yyyy-mm-dd";
            string str16 = "10";
            string str17 = "datedesc";
            string str18 = "30";
            string str19 = "0";
            string str20 = "";
            string str21 = "{@page_nav}";
            this.GetParamValue(paramStr, "padding", ref paramValue);
            this.GetParamValue(paramStr, "paddingstyle", ref str2);
            this.GetParamValue(paramStr, "paddingcss", ref str3);
            this.GetParamValue(paramStr, "pagesize", ref str4);
            this.GetParamValue(paramStr, "includesub", ref str5);
            this.GetParamValue(paramStr, "liststyle", ref str6);
            this.GetParamValue(paramStr, "showStyle", ref str7);
            this.GetParamValue(paramStr, "cellcount", ref str8);
            this.GetParamValue(paramStr, "divid", ref str9);
            this.GetParamValue(paramStr, "divclass", ref str10);
            this.GetParamValue(paramStr, "ulid", ref str11);
            this.GetParamValue(paramStr, "ulclass", ref str12);
            this.GetParamValue(paramStr, "liid", ref str13);
            this.GetParamValue(paramStr, "liclass", ref str14);
            this.GetParamValue(paramStr, "dateformat", ref str15);
            this.GetParamValue(paramStr, "daterange", ref str16);
            this.GetParamValue(paramStr, "order", ref str17);
            this.GetParamValue(paramStr, "titleLength", ref str18);
            this.GetParamValue(paramStr, "rowcount", ref str19);
            this.GetParamValue(paramStr, "compart", ref str20);
            this.GetParamValue(paramStr, "pagenav", ref str21);
            if (currColId == 0)
            {
                return string.Empty;
            }
            M_Column column = this.ColumnBll.GetColumn(currColId);
            if (column == null)
            {
                return string.Empty;
            }
            M_Channel channel = this.ChannelBll.GetChannel(column.ChId);
            if (channel == null)
            {
                return string.Empty;
            }
            string tableName = this.GetTableName(channel.ModelType);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            string colIdStr = string.Empty;
            if (str5 == "true")
            {
                colIdStr = this.ColumnBll.GetChildIdByColumnId(currColId);
            }
            else
            {
                colIdStr = currColId.ToString();
            }
            string dateRangeStr = this.GetDateRangeStr(str16);
            string orderStr = this.GetOrderStr(str17);
            int cellCount = 1;
            int totalCount = 0;
            int rowCount = 0;
            try
            {
                cellCount = int.Parse(str8);
                rowCount = int.Parse(str19);
            }
            catch
            {
            }
            bool isPadding = false;
            if (paramValue == "true")
            {
                isPadding = true;
            }
            DataTable table = this.dal.GetColumn_FinallyInfoList(tableName, colIdStr, dateRangeStr, orderStr, isPadding, pageIndex, int.Parse(str4));
            totalCount = table.Rows.Count;
            if (totalCount == 0)
            {
                return string.Empty;
            }
            string styleContent = this.GetStyleContent(int.Parse(str6));
            StringBuilder sb = new StringBuilder();
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            this.SetLabelHeaderHTML(sb, str7, cellCount);
            string typeUnit = string.Empty;
            string typeName = string.Empty;
            for (int i = 0; i < totalCount; i++)
            {
                DataRow dr = table.Rows[i];
                StringBuilder builder2 = new StringBuilder(styleContent);
                this.GetListStyleHTML(styleFileldName, builder2, dr, int.Parse(str18), str15, i);
                this.SetLabelBodyHTML(sb, builder2, str7, cellCount, i, totalCount);
                this.SetCompartHMTL(sb, str7, cellCount, rowCount, i, totalCount, str20);
                typeUnit = dr["typeUnit"].ToString();
                typeName = dr["typeName"].ToString();
            }
            this.SetLabelFooterHTML(sb, str7, cellCount);
            table.Dispose();
            if (isPadding)
            {
                int pageCount = ((recordCount - 1) / int.Parse(str4)) + 1;
                sb.Append(str21.Replace("{@page_nav}", this.GetColumnPageNav(currColId, typeUnit, typeName, recordCount, pageIndex, int.Parse(str4), pageCount, str2, str3)));
            }
            return sb.ToString();
        }

        private string Col_GetFlashInfoList(string paramStr, int currColId)
        {
            string paramValue = "0";
            string str2 = "0";
            string str3 = "5";
            string str4 = "false";
            string str5 = "30";
            string str6 = "120,100";
            this.GetParamValue(paramStr, "colid", ref paramValue);
            this.GetParamValue(paramStr, "chid", ref str2);
            this.GetParamValue(paramStr, "infocount", ref str3);
            this.GetParamValue(paramStr, "includesub", ref str4);
            this.GetParamValue(paramStr, "titlelength", ref str5);
            this.GetParamValue(paramStr, "imgsize", ref str6);
            int id = 0;
            int columnId = 0;
            string colIdStr = string.Empty;
            if ((str2 != "0") && (paramValue == "all"))
            {
                id = int.Parse(str2);
                if (id == 0)
                {
                    return string.Empty;
                }
            }
            else
            {
                if (paramValue == "0")
                {
                    columnId = currColId;
                }
                else
                {
                    columnId = int.Parse(paramValue);
                }
                if (columnId == 0)
                {
                    return string.Empty;
                }
                if (str4 == "true")
                {
                    colIdStr = this.ColumnBll.GetChildIdByColumnId(columnId);
                }
                else
                {
                    colIdStr = columnId.ToString();
                }
            }
            if ((id == 0) && (colIdStr == string.Empty))
            {
                return string.Empty;
            }
            if (columnId != 0)
            {
                M_Column column = this.ColumnBll.GetColumn(columnId);
                if (column == null)
                {
                    return string.Empty;
                }
                id = column.ChId;
            }
            M_Channel channel = this.ChannelBll.GetChannel(id);
            if (channel == null)
            {
                return string.Empty;
            }
            string tableName = this.GetTableName(channel.ModelType);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            DataTable table = this.dal.GetColumn_FlashInfoList(tableName, id, colIdStr, int.Parse(str3));
            string str9 = string.Empty;
            string str10 = string.Empty;
            string str11 = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                str11 = str11 + Ky.Common.Function.UrlEncode(this.SubStr(row["title"].ToString(), int.Parse(str5), "")) + "|";
                str10 = str10 + Ky.Common.Function.UrlEncode(this.GetInfoUrl(row)) + "|";
                str9 = str9 + this.GetInfoTitleImg(row) + "|";
            }
            table.Dispose();
            if (str11.EndsWith("|"))
            {
                str11 = str11.Substring(0, str11.Length - 1);
            }
            if (str10.EndsWith("|"))
            {
                str10 = str10.Substring(0, str10.Length - 1);
            }
            if (str9.EndsWith("|"))
            {
                str9 = str9.Substring(0, str9.Length - 1);
            }
            string[] strArray = str6.Split(new char[] { ',' });
            StringBuilder builder = new StringBuilder();
            builder.Append("<script type=\"text/javascript\">\r\n");
            builder.Append("<!--\r\n");
            builder.Append("var focus_width=" + strArray[1] + ";\r\n");
            builder.Append("var focus_height=" + strArray[0] + ";\r\n");
            builder.Append("var text_height=20;\r\n");
            builder.Append("var swf_height = focus_height+text_height;\r\n");
            builder.Append("var pics='" + str9 + "';\r\n");
            builder.Append("var links='" + str10 + "'\r\n");
            builder.Append("var texts='" + str11 + "'\r\n");
            builder.Append("document.write('<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"'+ focus_width +'\" height=\"'+ swf_height +'\">');\r\n");
            builder.Append("document.write('<param name=\"allowScriptAccess\" value=\"sameDomain\"><param name=\"movie\" value=\"" + Param.ApplicationRootPath + "/Flash.swf\"><param name=\"quality\" value=\"high\"><param name=\"bgcolor\" value=\"#cccccc\">');\r\n");
            builder.Append("document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">');\r\n");
            builder.Append("document.write('<param name=\"FlashVars\" value=\"pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'\">')\r\n");
            builder.Append("document.write('<embed src=\"" + Param.ApplicationRootPath + "/Flash.swf\" wmode=\"opaque\" FlashVars=\"pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'\" menu=\"false\" bgcolor=\"#cccccc\" quality=\"high\" width=\"'+ focus_width +'\" height=\"'+ swf_height +'\" allowScriptAccess=\"sameDomain\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />');\r\n");
            builder.Append("document.write('</object>');\r\n");
            builder.Append("//-->\r\n");
            builder.Append("</script>");
            return builder.ToString();
        }

        private string Col_GetInfoList(string paramStr, int currColId)
        {
            if (this.columnCache.Contains(paramStr) && (currColId == 0))
            {
                return (string)this.columnCache[paramStr];
            }
            string paramValue = "0";
            string str2 = "false";
            string str3 = "0";
            string str4 = "out_table";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "1";
            string str10 = "yyyy-mm-dd";
            string str11 = "10";
            string str12 = "";
            string str13 = "";
            string str14 = "10";
            string str15 = "datedesc";
            string str16 = "30";
            string str17 = "0";
            string str18 = "";
            string str19 = "";
            this.GetParamValue(paramStr, "colId", ref paramValue);
            this.GetParamValue(paramStr, "includesub", ref str2);
            this.GetParamValue(paramStr, "liststyle", ref str3);
            this.GetParamValue(paramStr, "showstyle", ref str4);
            this.GetParamValue(paramStr, "divid", ref str5);
            this.GetParamValue(paramStr, "divclass", ref str6);
            this.GetParamValue(paramStr, "ulid", ref str7);
            this.GetParamValue(paramStr, "ulclass", ref str8);
            this.GetParamValue(paramStr, "cellcount", ref str9);
            this.GetParamValue(paramStr, "dateformat", ref str10);
            this.GetParamValue(paramStr, "infocount", ref str11);
            this.GetParamValue(paramStr, "property1", ref str12);
            this.GetParamValue(paramStr, "property2", ref str13);
            this.GetParamValue(paramStr, "daterange", ref str14);
            this.GetParamValue(paramStr, "order", ref str15);
            this.GetParamValue(paramStr, "titlelength", ref str16);
            this.GetParamValue(paramStr, "rowcount", ref str17);
            this.GetParamValue(paramStr, "compart", ref str18);
            this.GetParamValue(paramStr, "ajaxflag", ref str19);
            if (str19.Length != 0)
            {
                return string.Format("<script language=\"javascript\">GetAjaxLabel(\"{0}\",\"{1}\",{2},\"{3}\")</script>", new object[] { Param.ApplicationRootPath + "/common/GetAjaxLabel.aspx", Ky.Common.Function.UrlEncode(paramStr), currColId, "col" });
            }
            string str21 = "0";
            if (paramValue == "0")
            {
                str21 = currColId.ToString();
            }
            else
            {
                str21 = paramValue;
            }
            if ((str21 == "0") || (str21.Trim().Length == 0))
            {
                return string.Empty;
            }
            string[] strArray = str21.Split(new char[] { ',' });
            int columnId = int.Parse(strArray[0]);
            M_Column column = this.ColumnBll.GetColumn(columnId);
            if (column == null)
            {
                return string.Empty;
            }
            M_Channel channel = this.ChannelBll.GetChannel(column.ChId);
            if (channel == null)
            {
                return string.Empty;
            }
            string tableName = this.GetTableName(channel.ModelType);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            string colIdStr = string.Empty;
            if (strArray.Length > 1)
            {
                colIdStr = str21;
            }
            else if (str2 == "true")
            {
                colIdStr = this.ColumnBll.GetChildIdByColumnId(columnId);
            }
            else
            {
                colIdStr = columnId.ToString();
            }
            string typeStr = this.GetTypeStr(str12, column.ChId, str13);
            string dateRangeStr = this.GetDateRangeStr(str14);
            string orderStr = this.GetOrderStr(str15);
            int cellCount = 1;
            int totalCount = 0;
            int rowCount = 0;
            try
            {
                cellCount = int.Parse(str9);
                rowCount = int.Parse(str17);
            }
            catch
            {
            }
            DataTable table = this.dal.GetColumn_InfoList(tableName, int.Parse(str11), colIdStr, typeStr, dateRangeStr, orderStr);
            totalCount = table.Rows.Count;
            string styleContent = this.GetStyleContent(int.Parse(str3));
            StringBuilder sb = new StringBuilder();
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            this.SetLabelHeaderHTML(sb, str4, cellCount);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                StringBuilder builder2 = new StringBuilder(styleContent);
                this.GetListStyleHTML(styleFileldName, builder2, dr, int.Parse(str16), str10, i);
                this.SetLabelBodyHTML(sb, builder2, str4, cellCount, i, totalCount);
                this.SetCompartHMTL(sb, str4, cellCount, rowCount, i, totalCount, str18);
            }
            this.SetLabelFooterHTML(sb, str4, cellCount);
            table.Dispose();
            if (currColId == 0)
            {
                this.columnCache.Add(paramStr, sb.ToString());
            }
            return sb.ToString();
        }

        public string Col_GetInfoList_Ajax(string paramStr, int currColId)
        {
            string paramValue = "0";
            string str2 = "false";
            string str3 = "0";
            string str4 = "out_table";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "1";
            string str10 = "yyyy-mm-dd";
            string str11 = "10";
            string str12 = "";
            string str13 = "";
            string str14 = "10";
            string str15 = "datedesc";
            string str16 = "30";
            string str17 = "0";
            string str18 = "";
            this.GetParamValue(paramStr, "colId", ref paramValue);
            this.GetParamValue(paramStr, "includesub", ref str2);
            this.GetParamValue(paramStr, "liststyle", ref str3);
            this.GetParamValue(paramStr, "showstyle", ref str4);
            this.GetParamValue(paramStr, "divid", ref str5);
            this.GetParamValue(paramStr, "divclass", ref str6);
            this.GetParamValue(paramStr, "ulid", ref str7);
            this.GetParamValue(paramStr, "ulclass", ref str8);
            this.GetParamValue(paramStr, "cellcount", ref str9);
            this.GetParamValue(paramStr, "dateformat", ref str10);
            this.GetParamValue(paramStr, "infocount", ref str11);
            this.GetParamValue(paramStr, "property1", ref str12);
            this.GetParamValue(paramStr, "property2", ref str13);
            this.GetParamValue(paramStr, "daterange", ref str14);
            this.GetParamValue(paramStr, "order", ref str15);
            this.GetParamValue(paramStr, "titlelength", ref str16);
            this.GetParamValue(paramStr, "rowcount", ref str17);
            this.GetParamValue(paramStr, "compart", ref str18);
            string str19 = "0";
            if (paramValue == "0")
            {
                str19 = currColId.ToString();
            }
            else
            {
                str19 = paramValue;
            }
            if ((str19 == "0") || (str19.Trim().Length == 0))
            {
                return string.Empty;
            }
            string[] strArray = str19.Split(new char[] { ',' });
            int columnId = int.Parse(strArray[0]);
            M_Column column = this.ColumnBll.GetColumn(columnId);
            if (column == null)
            {
                return string.Empty;
            }
            M_Channel channel = this.ChannelBll.GetChannel(column.ChId);
            if (channel == null)
            {
                return string.Empty;
            }
            string tableName = this.GetTableName(channel.ModelType);
            if (tableName == string.Empty)
            {
                return string.Empty;
            }
            string colIdStr = string.Empty;
            if (strArray.Length > 1)
            {
                colIdStr = str19;
            }
            else if (str2 == "true")
            {
                colIdStr = this.ColumnBll.GetChildIdByColumnId(columnId);
            }
            else
            {
                colIdStr = columnId.ToString();
            }
            string typeStr = this.GetTypeStr(str12, column.ChId, str13);
            string dateRangeStr = this.GetDateRangeStr(str14);
            string orderStr = this.GetOrderStr(str15);
            int cellCount = 1;
            int totalCount = 0;
            int rowCount = 0;
            try
            {
                cellCount = int.Parse(str9);
                rowCount = int.Parse(str17);
            }
            catch
            {
            }
            DataTable table = this.dal.GetColumn_InfoList(tableName, int.Parse(str11), colIdStr, typeStr, dateRangeStr, orderStr);
            totalCount = table.Rows.Count;
            string styleContent = this.GetStyleContent(int.Parse(str3));
            StringBuilder sb = new StringBuilder();
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            this.SetLabelHeaderHTML(sb, str4, cellCount);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                StringBuilder builder2 = new StringBuilder(styleContent);
                this.GetListStyleHTML(styleFileldName, builder2, dr, int.Parse(str16), str10, i);
                this.SetLabelBodyHTML(sb, builder2, str4, cellCount, i, totalCount);
                this.SetCompartHMTL(sb, str4, cellCount, rowCount, i, totalCount, str18);
            }
            this.SetLabelFooterHTML(sb, str4, cellCount);
            table.Dispose();
            return sb.ToString();
        }

        private string Col_GetPageInfo(string paramStr, int colId)
        {
            string paramValue = "0";
            this.GetParamValue(paramStr, "type", ref paramValue);
            M_Column column = this.ColumnBll.GetColumn(colId);
            switch (paramValue)
            {
                case "1":
                    return column.ColName;

                case "2":
                    return column.Keyword;

                case "3":
                    return column.Content;
            }
            return string.Empty;
        }

        public bool CreateChannelPage(int chId)
        {
            M_Channel channel = this.ChannelBll.GetChannel(chId);
            int channelPageType = channel.ChannelPageType;
            if (!((this.SiteModel.IsStaticType && channel.IsStaticType) && channel.IsOpened))
            {
                channelPageType = 4;
            }
            string templatePath = string.Empty;
            this.CreateDir(Param.SiteRootPath + @"\" + channel.DirName);
            switch (channelPageType)
            {
                case 2:
                    templatePath = Param.SiteRootPath + @"\" + channel.DirName + @"\Index.htm";
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.html");
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.shtml");
                    break;

                case 3:
                    templatePath = Param.SiteRootPath + @"\" + channel.DirName + @"\Index.shtml";
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.html");
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.htm");
                    break;

                case 4:
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.html");
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.htm");
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.shtml");
                    return true;

                default:
                    templatePath = Param.SiteRootPath + @"\" + channel.DirName + @"\Index.html";
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.htm");
                    this.DeleteFile(Param.SiteRootPath + @"\" + channel.DirName + @"\Index.shtml");
                    break;
            }
            return this.WriterTemplate(templatePath, this.GetChannelPage(chId));
        }

        public bool CreateColumnlPage(int colId)
        {
            M_Column column = this.ColumnBll.GetColumn(colId);
            M_Channel channel = this.ChannelBll.GetChannel(column.ChId);
            if ((this.SiteModel.IsStaticType && channel.IsStaticType) && column.IsOpened)
            {
                string str4;
                string str = string.Empty;
                switch (column.ColumnPageType)
                {
                    case 2:
                        str = "htm";
                        break;

                    case 3:
                        str = "shtml";
                        break;

                    case 4:
                        str = "aspx";
                        return true;

                    default:
                        str = "html";
                        break;
                }
                string str2 = string.Empty;
                string str3 = string.Empty;
                switch (channel.ColumnSortType)
                {
                    case 2:
                        str2 = @"\" + channel.DirName + @"\List";
                        str3 = @"\Index_" + colId;
                        break;

                    case 3:
                        str2 = @"\" + channel.DirName;
                        str3 = @"\Index_" + colId;
                        break;

                    default:
                        str2 = @"\" + channel.DirName + @"\" + column.ColDirName;
                        str3 = @"\Index";
                        break;
                }
                this.CreateDir(Param.SiteRootPath + str2);
                int recordCount = 0;
                int pageSize = 0;
                bool isPadding = false;
                this.GetColumn_FinallyInfoListData(colId, ref isPadding, ref pageSize, ref recordCount);
                if (!isPadding)
                {
                    str4 = Param.SiteRootPath + str2 + str3 + "." + str;
                    this.WriterTemplate(str4, this.GetColumnPage(colId, 1));
                }
                else if (pageSize == 0)
                {
                    str4 = Param.SiteRootPath + str2 + str3 + "." + str;
                    this.WriterTemplate(str4, this.GetColumnPage(colId, 1));
                }
                else
                {
                    int num3 = ((recordCount - 1) / pageSize) + 1;
                    for (int i = 0; i < num3; i++)
                    {
                        str4 = (i == 0) ? (Param.SiteRootPath + str2 + str3 + "." + str) : string.Concat(new object[] { Param.SiteRootPath, str2, str3, "_", i + 1, ".", str });
                        this.WriterTemplate(str4, this.GetColumnPage(colId, i + 1));
                    }
                }
            }
            return true;
        }

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("DtId", typeof(int));
            table.Columns.Add("DtCon", typeof(string));
            return table;
        }

        private DataTable CreateDataTable1()
        {
            DataTable table = new DataTable();
            table.Columns.Add("DtId", typeof(int));
            table.Columns.Add("DtCon", typeof(string));
            return table;
        }

        private void CreateDir(string path)
        {
            if (!(Directory.Exists(path) || !(path != "")))
            {
                Directory.CreateDirectory(path);
            }
        }

        public bool CreateIndexPage()
        {
            int pageType = this.SiteModel.PageType;
            if (!this.SiteModel.IsStaticType)
            {
                pageType = 4;
            }
            string templatePath = string.Empty;
            switch (pageType)
            {
                case 2:
                    templatePath = Param.SiteRootPath + @"\Index.htm";
                    this.DeleteFile(Param.SiteRootPath + @"\Index.html");
                    this.DeleteFile(Param.SiteRootPath + @"\Index.shtml");
                    break;

                case 3:
                    templatePath = Param.SiteRootPath + @"\Index.shtml";
                    this.DeleteFile(Param.SiteRootPath + @"\Index.htm");
                    this.DeleteFile(Param.SiteRootPath + @"\Index.html");
                    break;

                case 4:
                    this.DeleteFile(Param.SiteRootPath + @"\Index.htm");
                    this.DeleteFile(Param.SiteRootPath + @"\Index.html");
                    this.DeleteFile(Param.SiteRootPath + @"\Index.shtml");
                    return true;

                default:
                    templatePath = Param.SiteRootPath + @"\Index.html";
                    this.DeleteFile(Param.SiteRootPath + @"\Index.htm");
                    this.DeleteFile(Param.SiteRootPath + @"\Index.shtml");
                    break;
            }
            return this.WriterTemplate(templatePath, this.GetIndexPage());
        }

        public bool CreateInfo(DataRow dr)
        {
            M_Channel channel = new M_Channel();
            channel = this.ChannelBll.GetChannel(int.Parse(dr["ChId"].ToString()));
            int num = (int)dr["modelid"];
            bool isStaticType = this.SiteModel.IsStaticType;
            bool flag2 = (bool)dr["isstatictype"];
            int num2 = (int)dr["isopened"];
            bool flag3 = (bool)dr["colisopened"];
            int num3 = (int)dr["pointcount"];
            int num4 = (int)dr["pagetype"];
            int num5 = (int)dr["status"];
            string str = string.Empty;
            if (num == 1)
            {
                str = dr["viewuname"].ToString();
            }
            if ((((!isStaticType || !flag2) || ((num4 == 4) || (num5 != 3))) || (str.Length != 0)) || ((num != 3) && ((num2 == 0) || ((num2 == 2) && !flag3))))
            {
                return false;
            }
            try
            {
                if (dr["outerurl"].ToString() != string.Empty)
                {
                    return false;
                }
            }
            catch
            {
            }
            string[] strArray = this.NewsFileName(dr).Split(new char[] { '|' });
            if (strArray[1] == ".aspx")
            {
                return false;
            }
            string str3 = dr["DirName"].ToString();
            string str4 = dr["coldirName"].ToString();
            int pageSize = 0;
            string templatePath = "";
            string content = "";
            string str7 = "";
            string str8 = "";
            string path = "";
            string str10 = "";
            if (channel.InfoSortType == 1)
            {
                path = Param.SiteRootPath + @"\" + str3;
                str10 = Param.SiteRootPath + @"\" + str3 + @"\" + str4;
                str7 = str3;
                str8 = str4;
            }
            else if (channel.InfoSortType == 2)
            {
                path = Param.SiteRootPath + @"\" + str3;
                str10 = Param.SiteRootPath + @"\" + str3 + @"\Html";
                str7 = str3;
                str8 = "Html";
            }
            else if (channel.InfoSortType == 3)
            {
                path = Param.SiteRootPath + @"\" + str3;
                str7 = str3;
                str8 = "";
            }
            else
            {
                string[] strArray2;
                DateTime time;
                if (channel.InfoSortType == 4)
                {
                    path = Param.SiteRootPath + @"\" + str3;
                    strArray2 = new string[5];
                    strArray2[0] = Param.SiteRootPath;
                    strArray2[1] = @"\";
                    strArray2[2] = str3;
                    strArray2[3] = @"\";
                    time = (DateTime)dr["AddTime"];
                    strArray2[4] = time.ToString("yyyy'/'MM'/'dd");
                    str10 = string.Concat(strArray2);
                    str7 = str3;
                    time = (DateTime)dr["AddTime"];
                    str8 = time.ToString("yyyy'/'MM'/'dd");
                }
                else if (channel.InfoSortType == 5)
                {
                    path = Param.SiteRootPath + @"\" + str3;
                    strArray2 = new string[5];
                    strArray2[0] = Param.SiteRootPath;
                    strArray2[1] = @"\";
                    strArray2[2] = str3;
                    strArray2[3] = @"\";
                    time = (DateTime)dr["AddTime"];
                    strArray2[4] = time.ToString("yyyy'/'MM-dd");
                    str10 = string.Concat(strArray2);
                    str7 = str3;
                    time = (DateTime)dr["AddTime"];
                    str8 = time.ToString("yyyy'/'MM-dd");
                }
                else if (channel.InfoSortType == 6)
                {
                    path = Param.SiteRootPath + @"\" + str3;
                    strArray2 = new string[5];
                    strArray2[0] = Param.SiteRootPath;
                    strArray2[1] = @"\";
                    strArray2[2] = str3;
                    strArray2[3] = @"\";
                    time = (DateTime)dr["AddTime"];
                    strArray2[4] = time.ToString("yyyy-MM-dd");
                    str10 = string.Concat(strArray2);
                    str7 = str3;
                    time = (DateTime)dr["AddTime"];
                    str8 = time.ToString("yyyy-MM-dd");
                }
                else if (channel.InfoSortType == 7)
                {
                    path = Param.SiteRootPath + @"\" + str3;
                    strArray2 = new string[5];
                    strArray2[0] = Param.SiteRootPath;
                    strArray2[1] = @"\";
                    strArray2[2] = str3;
                    strArray2[3] = @"\";
                    time = (DateTime)dr["AddTime"];
                    strArray2[4] = time.ToString("yyyyMM");
                    str10 = string.Concat(strArray2);
                    str7 = str3;
                    str8 = ((DateTime)dr["AddTime"]).ToString("yyyyMM");
                }
            }
            if (Directory.Exists(path))
            {
                if (!Directory.Exists(str10))
                {
                    this.CreateDir(str10);
                }
            }
            else
            {
                this.CreateDir(path);
                this.CreateDir(str10);
            }
            templatePath = string.Concat(new object[] { Param.SiteRootPath, @"\", str7, @"\", str8, @"\", strArray[0], dr["Id"], strArray[1] });
            pageSize = this.TotalContentPageNumber(dr);
            content = this.GetInfo(dr, 1, pageSize);
            if (pageSize != 1)
            {
                this.WriterTemplate(templatePath, content);
                for (int i = 2; i <= pageSize; i++)
                {
                    content = this.GetInfo(dr, i, pageSize);
                    templatePath = string.Concat(new object[] { Param.SiteRootPath, @"\", str7, @"\", str8, @"\", strArray[0], dr["Id"], "_", i - 1, strArray[1] });
                    this.WriterTemplate(templatePath, content);
                }
            }
            else
            {
                this.WriterTemplate(templatePath, content);
            }
            B_Article article = new B_Article();
            string tableName = (string)dr["tablename"];
            int id = (int)dr["id"];
            this.InfoOperBll.UpdateIsCreated(tableName, id);
            return true;
        }

        public bool CreateSingleInfo(DataRow dr)
        {
            if (this.CreateInfo(dr) && (Param.Publish == "1"))
            {
                int chId = (int)dr["chid"];
                int colId = (int)dr["colid"];
                string[] strArray = this.ColumnBll.GetParentColId(colId).Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    int num4 = int.Parse(strArray[i]);
                    this.CreateColumnlPage(num4);
                }
                this.CreateChannelPage(chId);
                this.CreateIndexPage();
            }
            return true;
        }

        public bool CreateSinglePage(int singleId)
        {
            M_SinglePage model = new B_SinglePage().GetModel(singleId);
            string path = Param.SiteRootPath + model.FolderPath;
            this.CreateDir(path);
            string templatePath = (path + model.FileName + model.FileExtend).Replace("/", @"\");
            return this.WriterTemplate(templatePath, this.GetSinglePage(singleId));
        }

        public bool CreateSpecialPage(int spId)
        {
            string str5;
            if (!this.SiteModel.IsStaticType)
            {
                return true;
            }
            M_Special special = this.SpecialBll.GetSpecial(spId);
            string str = string.Empty;
            string extension = special.Extension;
            if ((extension != null) && !(extension == "1"))
            {
                if (extension == "2")
                {
                    str = ".htm";
                    goto Label_0094;
                }
                if (extension == "3")
                {
                    str = ".shtml";
                    goto Label_0094;
                }
                if (extension == "4")
                {
                    str = ".aspx";
                    goto Label_0094;
                }
            }
            str = ".html";
        Label_0094:
            if (special.Extension == "4")
            {
                return true;
            }
            string str2 = string.Empty;
            string str3 = string.Empty;
            extension = special.SaveDirType;
            if ((extension != null) && !(extension == "1"))
            {
                if (extension == "2")
                {
                    str2 = @"\special\" + special.SpecialEName;
                    str3 = @"\Index";
                    goto Label_019C;
                }
                if (extension == "3")
                {
                    str2 = @"\special\" + DateTime.Now.ToString("yyyy");
                    str3 = @"\" + special.SpecialEName;
                    goto Label_019C;
                }
                if (extension == "4")
                {
                    str2 = @"\special\" + DateTime.Now.ToString("yyyy") + @"\" + special.SpecialEName;
                    str3 = @"\Index";
                    goto Label_019C;
                }
            }
            str2 = @"\special";
            str3 = @"\" + special.SpecialEName;
        Label_019C:
            this.CreateDir(Param.SiteRootPath + str2);
            int recordCount = 0;
            string pageSize = "30";
            bool isPadding = false;
            this.GetSpecial_InfoListData(spId, ref isPadding, ref pageSize, ref recordCount);
            if (!isPadding)
            {
                str5 = Param.SiteRootPath + str2 + str3 + str;
                this.WriterTemplate(str5, this.GetSpecialPage(spId, 1));
            }
            else
            {
                int num2 = ((recordCount - 1) / int.Parse(pageSize)) + 1;
                for (int i = 1; i <= num2; i++)
                {
                    str5 = (i == 1) ? (Param.SiteRootPath + str2 + str3 + str) : string.Concat(new object[] { Param.SiteRootPath, str2, str3, "_", i, str });
                    this.WriterTemplate(str5, this.GetSpecialPage(spId, i));
                }
            }
            return true;
        }

        private void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        private int Get_SpecialInfoCount(string paramStr, int currSpId, ref bool isPadding)
        {
            string paramValue = "0";
            string str2 = "false";
            string str3 = "0";
            string str4 = "10";
            string str5 = "datedesc";
            string str6 = "false";
            this.GetParamValue(paramStr, "spid", ref paramValue);
            this.GetParamValue(paramStr, "padding", ref str2);
            this.GetParamValue(paramStr, "infocount", ref str3);
            this.GetParamValue(paramStr, "dateRange", ref str4);
            this.GetParamValue(paramStr, "order", ref str5);
            this.GetParamValue(paramStr, "includesub", ref str6);
            int id = 0;
            if (paramValue == "0")
            {
                id = currSpId;
            }
            else
            {
                id = int.Parse(paramValue);
            }
            if (id == 0)
            {
                return 0;
            }
            if (str2 != "true")
            {
                isPadding = false;
            }
            else
            {
                isPadding = true;
            }
            string orderStr = this.GetOrderStr(str5);
            string dateRangeStr = this.GetDateRangeStr(str4);
            M_Special special = this.SpecialBll.GetSpecial(id);
            if (special == null)
            {
                return 0;
            }
            string specialIdStr = string.Format(" (i.[specialidstr] like '%{0}%' ", id);
            if (str6.ToString() == "true")
            {
                DataTable specialByParentId = this.SpecialBll.GetSpecialByParentId(id);
                foreach (DataRow row in specialByParentId.Rows)
                {
                    int num2 = (int)row["id"];
                    specialIdStr = specialIdStr + string.Format(" or i.[specialidstr] like '%{0}%' ", num2);
                }
                specialByParentId.Dispose();
            }
            specialIdStr = specialIdStr + ") and ";
            if (special.SiteID == 0)
            {
                DataTable modelAll = this.GetModelAll();
                string tableNameStr = string.Empty;
                foreach (DataRow row2 in modelAll.Rows)
                {
                    object obj2 = tableNameStr;
                    tableNameStr = string.Concat(new object[] { obj2, "[", row2["TableName"], "]," });
                }
                modelAll.Dispose();
                if (tableNameStr == string.Empty)
                {
                    return 0;
                }
                if ((tableNameStr.Length > 0) && tableNameStr.EndsWith(","))
                {
                    tableNameStr = tableNameStr.Substring(0, tableNameStr.Length - 1);
                }
                return this.dal.GetSite_SpecialInfoCount(tableNameStr, int.Parse(str3), specialIdStr, dateRangeStr);
            }
            M_Channel channel = this.ChannelBll.GetChannel(special.SiteID);
            if (channel == null)
            {
                return 0;
            }
            string tableName = this.GetTableName(channel.ModelType);
            if (tableName == string.Empty)
            {
                return 0;
            }
            return this.dal.GetChannel_SpecialInfoCount(tableName, int.Parse(str3), specialIdStr, dateRangeStr);
        }

        private string GetAddFav(string paramStr)
        {
            string paramValue = "[添加收藏]";
            this.GetParamValue(paramStr, "showtext", ref paramValue);
            return ("<a href=\"#\" onclick=\"javascript:WinOpen('" + Param.ApplicationRootPath + "/user/UserFavorite.aspx?url='+escape(location.href)+'&title='+escape(document.title),'fav',500,200)\">" + paramValue + "</a>");
        }

        private string GetAddress(DataRow dr)
        {
            int num;
            string str = string.Empty;
            DataTable infoBySoftId = null;
            DataTable typeList = null;
            DataTable groupAddresList = null;
            B_DownLoadaddress loadaddress = new B_DownLoadaddress();
            B_DownLoadServerType type = new B_DownLoadServerType();
            B_DownLoadServerData data = new B_DownLoadServerData();
            infoBySoftId = loadaddress.GetInfoBySoftId((int)dr["id"]);
            typeList = type.GetTypeList();
            groupAddresList = loadaddress.GetGroupAddresList((int)dr["id"], -1);
            if (groupAddresList != null)
            {
                str = "本地下载<br>";
                for (num = 0; num < groupAddresList.Rows.Count; num++)
                {
                    str = str + "<a href=\"" + Param.ApplicationRootPath + "/Down.aspx?Sid=-1&Aid=" + groupAddresList.Rows[num]["addressid"].ToString() + " \" target=\"_black\">" + groupAddresList.Rows[num]["addressname"].ToString() + "</a><br>";
                }
            }
            typeList = type.GetTypeList();
            for (num = 0; num < typeList.Rows.Count; num++)
            {
                groupAddresList = loadaddress.GetGroupAddresList((int)dr["id"], (int)typeList.Rows[num]["TypeId"]);
                if (groupAddresList != null)
                {
                    str = str + typeList.Rows[num]["TypeName"].ToString() + "<br>";
                    for (int i = 0; i < groupAddresList.Rows.Count; i++)
                    {
                        str = str + "<a href=\"" + Param.ApplicationRootPath + "/Down.aspx?Sid=" + groupAddresList.Rows[i]["downloadserverdataid"].ToString() + "&Aid=" + groupAddresList.Rows[i]["addressid"].ToString() + " \" target=\"_black\">" + groupAddresList.Rows[i]["downloadservername"].ToString() + "</a><br>";
                    }
                }
            }
            return str;
        }

        private string GetApplicationPath()
        {
            return Param.ApplicationRootPath;
        }

        private string GetBannerAddress()
        {
            return this.SiteModel.BannerAddress;
        }

        public string GetChannelPage(int chId)
        {
            M_Channel channel = this.ChannelBll.GetChannel(chId);
            string templatePath = Param.SiteRootPath + channel.TemplatePath.Replace("/", @"\");
            StringBuilder fileContent = new StringBuilder(this.GetContentByReplaceSysJS(this.ReadTemplate(templatePath)));
            this.ReplaceLabelNameToContent(fileContent);
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                string newValue = string.Empty;
                if (match.Groups.Count > 1)
                {
                    switch (match.Groups[1].Value.Trim().ToLower())
                    {
                        case "my_pos":
                            newValue = this.GetCurrent_Pos(match.Value, "channel", chId, "");
                            goto Label_04E3;

                        case "ch_infolist":
                            newValue = this.Ch_GetInfoList(match.Value, chId);
                            goto Label_04E3;

                        case "col_infolist":
                            newValue = this.Col_GetInfoList(match.Value, 0);
                            goto Label_04E3;

                        case "ch_col_infolist":
                            newValue = this.Ch_Col_GetInfoList(match.Value, chId);
                            goto Label_04E3;

                        case "col_childcol_infolist":
                            newValue = this.Col_ChildCol_GetInfoList(match.Value, 0);
                            goto Label_04E3;

                        case "index_ch_nav":
                            newValue = this.Index_Ch_GetNav(match.Value);
                            goto Label_04E3;

                        case "ch_col_nav":
                            newValue = this.Ch_Col_GetNav(match.Value, chId);
                            goto Label_04E3;

                        case "col_flashinfolist":
                            newValue = this.Col_GetFlashInfoList(match.Value, 0);
                            goto Label_04E3;

                        case "page_info":
                            newValue = this.Ch_GetPageInfo(match.Value, chId);
                            goto Label_04E3;

                        case "addfav":
                            newValue = this.GetAddFav(match.Value);
                            goto Label_04E3;

                        case "report":
                            newValue = this.GetReport(match.Value);
                            goto Label_04E3;

                        case "login":
                            newValue = this.GetLogin(match.Value);
                            goto Label_04E3;

                        case "pvtotal":
                            newValue = this.GetPvTotal();
                            goto Label_04E3;

                        case "article_txt_headerlist":
                            newValue = this.Article_Text_GetHeaderList(match.Value);
                            goto Label_04E3;

                        case "article_img_headerlist":
                            newValue = this.Article_Img_GetHeaderList(match.Value);
                            goto Label_04E3;

                        case "searchform":
                            newValue = this.GetSearchForm();
                            goto Label_04E3;

                        case "sitename":
                            newValue = this.GetSiteName();
                            goto Label_04E3;

                        case "domain":
                            newValue = this.GetDomainName();
                            goto Label_04E3;

                        case "copyright":
                            newValue = this.GetCopyright();
                            goto Label_04E3;

                        case "logo":
                            newValue = this.GetLogoAddress();
                            goto Label_04E3;

                        case "banner":
                            newValue = this.GetBannerAddress();
                            goto Label_04E3;

                        case "applicationpath":
                            newValue = this.GetApplicationPath();
                            goto Label_04E3;

                        case "vote":
                            newValue = this.GetVote(match.Value);
                            goto Label_04E3;

                        case "kylink":
                            newValue = this.GetLink(match.Value);
                            goto Label_04E3;

                        case "rsslink":
                            newValue = this.GetRssLink(match.Value, "chId", chId);
                            goto Label_04E3;

                        case "infototal":
                            newValue = this.GetTotal();
                            goto Label_04E3;

                        case "index_sp_nav":
                            newValue = this.GetIndexSpNav(match.Value);
                            goto Label_04E3;

                        case "index_col_nav":
                            newValue = this.GetIndex_Col_Nav(match.Value);
                            goto Label_04E3;

                        case "currchid":
                            newValue = chId.ToString();
                            goto Label_04E3;
                    }
                    newValue = string.Empty;
                }
            Label_04E3:
                fileContent.Replace(match.Value, newValue);
            }
            return (fileContent.ToString() + "\r\n<!-- " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "签发-->");
        }

        public string GetChannelUrl(int chId)
        {
            M_Channel channel = this.ChannelBll.GetChannel(chId);
            if (channel.IsChildSite)
            {
                return channel.ChildSiteUrl;
            }
            if (((!this.SiteModel.IsStaticType || !channel.IsStaticType) || !channel.IsOpened) || (channel.ChannelPageType == 4))
            {
                return (this.HostAddress + "/Channel.aspx?ChId=" + chId);
            }
            string str = string.Empty;
            switch (channel.ChannelPageType)
            {
                case 2:
                    str = "htm";
                    break;

                case 3:
                    str = "shtml";
                    break;

                default:
                    str = "html";
                    break;
            }
            string str2 = string.Empty;
            str2 = "/" + channel.DirName;
            return (this.HostAddress + str2 + "/Index." + str);
        }

        public DataRow GetCloseInfo(string tableName, int id, int colId, string direct)
        {
            return this.dal.GetCloseInfo(tableName, id, colId, direct);
        }

        private int GetColumn_FinallyInfoCount(string paramStr, int currColId)
        {
            string paramValue = "0";
            string str2 = "false";
            string str3 = "10";
            this.GetParamValue(paramStr, "modelid", ref paramValue);
            this.GetParamValue(paramStr, "includesub", ref str2);
            this.GetParamValue(paramStr, "daterange", ref str3);
            if (currColId == 0)
            {
                return 0;
            }
            string colIdstr = string.Empty;
            if (str2 == "true")
            {
                colIdstr = this.ColumnBll.GetChildIdByColumnId(currColId);
            }
            else
            {
                colIdstr = currColId.ToString();
            }
            string dateRangeStr = this.GetDateRangeStr(str3);
            string tableName = this.GetTableName(int.Parse(paramValue));
            if (tableName == string.Empty)
            {
                return 0;
            }
            return this.dal.GetColumn_FinallyInfoCount(tableName, colIdstr, dateRangeStr);
        }

        private void GetColumn_FinallyInfoListData(int colId, ref bool isPadding, ref int pageSize, ref int recordCount)
        {
            M_Column column = this.ColumnBll.GetColumn(colId);
            if (column != null)
            {
                string templatePath = Param.SiteRootPath + column.ColumnTemplatePath.Replace("/", @"\");
                StringBuilder fileContent = new StringBuilder(this.ReadTemplate(templatePath));
                this.ReplaceLabelNameToContent(fileContent);
                MatchCollection paramId = this.GetParamId(fileContent.ToString());
                foreach (Match match in paramId)
                {
                    if ((match.Groups.Count > 1) && (match.Groups[1].Value.Trim().ToLower() == "col_finallyinfolist"))
                    {
                        string paramValue = "false";
                        string str3 = "0";
                        this.GetParamValue(match.Value, "padding", ref paramValue);
                        this.GetParamValue(match.Value, "pagesize", ref str3);
                        if (paramValue == "true")
                        {
                            isPadding = true;
                        }
                        else
                        {
                            isPadding = false;
                        }
                        pageSize = int.Parse(str3);
                        recordCount = this.GetColumn_FinallyInfoCount(match.Value, colId);
                        break;
                    }
                }
            }
        }

        public DataTable GetColumnAll(string tableName, string colId, int pageIndex, int pageSize)
        {
            return this.dal.GetColumnAll(tableName, colId, pageIndex, pageSize);
        }

        public string GetColumnPage(int colId, int pageIndex)
        {
            bool flag = false;
            M_Column column = this.ColumnBll.GetColumn(colId);
            string templatePath = Param.SiteRootPath + column.ColumnTemplatePath.Replace("/", @"\");
            StringBuilder fileContent = new StringBuilder(this.GetContentByReplaceSysJS(this.ReadTemplate(templatePath)));
            this.ReplaceLabelNameToContent(fileContent);
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                string newValue = string.Empty;
                if (match.Groups.Count > 1)
                {
                    switch (match.Groups[1].Value.Trim().ToLower())
                    {
                        case "my_pos":
                            newValue = this.GetCurrent_Pos(match.Value, "column", colId, "");
                            goto Label_0592;

                        case "ch_infolist":
                            newValue = this.Ch_GetInfoList(match.Value, column.ChId);
                            goto Label_0592;

                        case "col_infolist":
                            newValue = this.Col_GetInfoList(match.Value, colId);
                            goto Label_0592;

                        case "ch_col_infolist":
                            newValue = this.Ch_Col_GetInfoList(match.Value, column.ChId);
                            goto Label_0592;

                        case "col_childcol_infolist":
                            newValue = this.Col_ChildCol_GetInfoList(match.Value, colId);
                            goto Label_0592;

                        case "col_finallyinfolist":
                            if (!flag)
                            {
                                int recordCount = this.GetColumn_FinallyInfoCount(match.Value, colId);
                                newValue = this.Col_GetFinallyInfoList(match.Value, colId, pageIndex, recordCount);
                                flag = true;
                            }
                            goto Label_0592;

                        case "index_ch_nav":
                            newValue = this.Index_Ch_GetNav(match.Value);
                            goto Label_0592;

                        case "ch_col_nav":
                            newValue = this.Ch_Col_GetNav(match.Value, column.ChId);
                            goto Label_0592;

                        case "col_childcol_nav":
                            newValue = this.Col_ChildCol_GetNav(match.Value, colId);
                            goto Label_0592;

                        case "col_flashinfolist":
                            newValue = this.Col_GetFlashInfoList(match.Value, colId);
                            goto Label_0592;

                        case "page_info":
                            newValue = this.Col_GetPageInfo(match.Value, colId);
                            goto Label_0592;

                        case "addfav":
                            newValue = this.GetAddFav(match.Value);
                            goto Label_0592;

                        case "report":
                            newValue = this.GetReport(match.Value);
                            goto Label_0592;

                        case "login":
                            newValue = this.GetLogin(match.Value);
                            goto Label_0592;

                        case "pvtotal":
                            newValue = this.GetPvTotal();
                            goto Label_0592;

                        case "article_txt_headerlist":
                            newValue = this.Article_Text_GetHeaderList(match.Value);
                            goto Label_0592;

                        case "article_img_headerlist":
                            newValue = this.Article_Img_GetHeaderList(match.Value);
                            goto Label_0592;

                        case "searchform":
                            newValue = this.GetSearchForm();
                            goto Label_0592;

                        case "sitename":
                            newValue = this.GetSiteName();
                            goto Label_0592;

                        case "domain":
                            newValue = this.GetDomainName();
                            goto Label_0592;

                        case "copyright":
                            newValue = this.GetCopyright();
                            goto Label_0592;

                        case "logo":
                            newValue = this.GetLogoAddress();
                            goto Label_0592;

                        case "banner":
                            newValue = this.GetBannerAddress();
                            goto Label_0592;

                        case "applicationpath":
                            newValue = this.GetApplicationPath();
                            goto Label_0592;

                        case "vote":
                            newValue = this.GetVote(match.Value);
                            goto Label_0592;

                        case "kylink":
                            newValue = this.GetLink(match.Value);
                            goto Label_0592;

                        case "rsslink":
                            newValue = this.GetRssLink(match.Value, "colId", colId);
                            goto Label_0592;

                        case "infototal":
                            newValue = this.GetTotal();
                            goto Label_0592;

                        case "index_sp_nav":
                            newValue = this.GetIndexSpNav(match.Value);
                            goto Label_0592;

                        case "currchid":
                            {
                                int chId = column.ChId;
                                newValue = chId.ToString();
                                goto Label_0592;
                            }
                        case "currcolid":
                            newValue = column.ColId.ToString();
                            goto Label_0592;

                        case "index_col_nav":
                            newValue = this.GetIndex_Col_Nav(match.Value);
                            goto Label_0592;
                    }
                    newValue = string.Empty;
                }
            Label_0592:
                fileContent.Replace(match.Value, newValue);
            }
            return (fileContent.ToString() + "\r\n<!-- " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "签发-->");
        }

        public string GetColumnPageNav(int colid, string typeUnit, string typeName, int recordCount, int pageIndex, int pageSize, int pageCount, string paddingStyle, string paddingCss)
        {
            int num4;
            int num5;
            string str11;
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            StringBuilder builder = new StringBuilder();
            int num = int.Parse(paddingStyle);
            string str = (paddingCss.Length == 0) ? " " : (" class=\"" + paddingCss + "\" ");
            builder.Append("<div id=\"pagenav\">");
            int num2 = pageIndex - 1;
            int num3 = pageIndex + 1;
            if (num2 < 1)
            {
                num2 = 1;
            }
            if (num3 > pageCount)
            {
                num3 = pageCount;
            }
            string[] strArray = null;
            string columnUrl = this.GetColumnUrl(colid, 1);
            string str10 = string.Empty;
            switch (num)
            {
                case 2:
                    str10 = string.Format("<span{0}>{1}页/{2}{3}</span>", new object[] { str, pageIndex, recordCount, typeUnit });
                    builder.AppendLine(str10);
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "<font face=webdings>9</font>", str, columnUrl));
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "<font face=webdings>3</font>", str, this.GetColumnUrl(colid, num2)));
                    strArray = Ky.Common.Function.GetPageNumStr(pageIndex, pageCount, 7).Split(new char[] { '|' });
                    for (num4 = 0; num4 < strArray.Length; num4++)
                    {
                        num5 = int.Parse(strArray[num4]);
                        str11 = this.GetColumnUrl(colid, num5);
                        builder.AppendLine(this.GetCurrPageHTML(pageIndex, num5, str, str11));
                    }
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "<font face=webdings>4</font>", str, this.GetColumnUrl(colid, num3)));
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "<font face=webdings>:</font>", str, this.GetColumnUrl(colid, pageCount)));
                    builder.AppendLine(this.GetGoHTML(columnUrl, colid, pageCount, str));
                    break;

                case 3:
                    str10 = string.Format("<span{0}>共{1}{2}{3}</span>", new object[] { str, recordCount, typeUnit, typeName });
                    builder.AppendLine(str10);
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "首页", str, columnUrl));
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "上一页", str, this.GetColumnUrl(colid, num2)));
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "下一页", str, this.GetColumnUrl(colid, num3)));
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "尾页", str, this.GetColumnUrl(colid, pageCount)));
                    builder.AppendLine(string.Format("<span{0}>{1}{2}{3}/页</span>", new object[] { str, pageSize, typeUnit, typeName }));
                    builder.AppendLine(this.GetGoHTML(columnUrl, colid, pageCount, str));
                    break;

                case 4:
                    strArray = Ky.Common.Function.GetPageNumStr(pageIndex, pageCount, 7).Split(new char[] { '|' });
                    num4 = 0;
                    while (num4 < strArray.Length)
                    {
                        num5 = int.Parse(strArray[num4]);
                        str11 = this.GetColumnUrl(colid, num5);
                        builder.AppendLine(this.GetCurrPageHTML(pageIndex, num5, str, str11));
                        num4++;
                    }
                    break;

                default:
                    str10 = string.Format("<span{0}>共{1}/{2}页</span>", str, pageIndex, pageCount);
                    builder.AppendLine(str10);
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "<<", str, this.GetColumnUrl(colid, num2)));
                    strArray = Ky.Common.Function.GetPageNumStr(pageIndex, pageCount, 7).Split(new char[] { '|' });
                    for (num4 = 0; num4 < strArray.Length; num4++)
                    {
                        num5 = int.Parse(strArray[num4]);
                        str11 = this.GetColumnUrl(colid, num5);
                        builder.AppendLine(this.GetCurrPageHTML(pageIndex, num5, str, str11));
                    }
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, ">>", str, this.GetColumnUrl(colid, num3)));
                    builder.AppendLine(this.GetGoHTML(columnUrl, colid, pageCount, str));
                    break;
            }
            builder.Append("</div>");
            return builder.ToString();
        }

        public string GetColumnUrl(DataRow dr)
        {
            if (this.CheckColumn(dr, "colid"))
            {
                return this.GetColumnUrl((int)dr["colid"], 1);
            }
            return string.Empty;
        }

        public string GetColumnUrl(int colId, int pageIndex)
        {
            if (pageIndex == 0)
            {
                return string.Empty;
            }
            M_Column column = this.ColumnBll.GetColumn(colId);
            if (column == null)
            {
                return "#";
            }
            if (column.IsOuterColumn && (pageIndex == 1))
            {
                return column.OuterColumnUrl;
            }
            M_Channel channel = this.ChannelBll.GetChannel(column.ChId);
            if (((!this.SiteModel.IsStaticType || !channel.IsStaticType) || !column.IsOpened) || (column.ColumnPageType == 4))
            {
                return ((pageIndex == 1) ? (this.HostAddress + "/Column.aspx?ColId=" + colId) : string.Concat(new object[] { this.HostAddress, "/Column.aspx?ColId=", colId, "&P=", pageIndex }));
            }
            string str = string.Empty;
            switch (column.ColumnPageType)
            {
                case 2:
                    str = "htm";
                    break;

                case 3:
                    str = "shtml";
                    break;

                default:
                    str = "html";
                    break;
            }
            string colDirName = string.Empty;
            string str3 = string.Empty;
            if (!channel.IsChildSite || (channel.ChildSiteUrl.Length == 0))
            {
                switch (channel.ColumnSortType)
                {
                    case 1:
                        goto Label_0303;

                    case 2:
                        colDirName = "/" + channel.DirName + "/List";
                        str3 = "/Index_" + colId;
                        goto Label_0377;

                    case 3:
                        colDirName = "/" + channel.DirName;
                        str3 = "/Index_" + colId;
                        goto Label_0377;
                }
            }
            else
            {
                switch (channel.ColumnSortType)
                {
                    case 2:
                        colDirName = "List";
                        str3 = "/Index_" + colId;
                        break;

                    case 3:
                        colDirName = "";
                        str3 = "Index_" + colId;
                        break;

                    default:
                        colDirName = column.ColDirName;
                        str3 = "/Index";
                        break;
                }
                if (this.SiteModel.IsAbsPathType)
                {
                    return ((pageIndex == 1) ? (channel.ChildSiteUrl + "/" + colDirName + str3 + "." + str) : string.Concat(new object[] { channel.ChildSiteUrl, "/", colDirName, str3, "_", pageIndex, ".", str }));
                }
                return ((pageIndex == 1) ? (colDirName + str3 + "." + str) : string.Concat(new object[] { colDirName, str3, "_", pageIndex, ".", str }));
            }
        Label_0303:
            colDirName = "/" + channel.DirName + "/" + column.ColDirName;
            str3 = "/Index";
        Label_0377:
            return ((pageIndex == 1) ? (this.HostAddress + colDirName + str3 + "." + str) : string.Concat(new object[] { this.HostAddress, colDirName, str3, "_", pageIndex, ".", str }));
        }

        private string GetCommentForm(int modelType, int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<script language=\"javascript\">");
            builder.AppendLine(string.Concat(new object[] { "var data = XmlHttpPostMethodText('", Param.ApplicationRootPath, "/sys_template/AddReview.aspx','ModelType=", modelType, "&Id=", id, "');" }));
            builder.AppendLine("document.write(data)");
            builder.AppendLine("</script>");
            return builder.ToString();
        }

        public string GetCommentLink(DataRow dr)
        {
            if ((this.CheckColumn(dr, "isshowcommentlink") && this.CheckColumn(dr, "isallowcomment")) && this.CheckColumn(dr, "newsid"))
            {
                if (((bool)dr["isshowcommentlink"]) && ((bool)dr["isallowcomment"]))
                {
                    return string.Concat(new object[] { "[<a href='", Param.ApplicationRootPath, "/Comment.aspx?Id=", dr["newsid"], "&Type=1' target='_blank'>评论</a>]" });
                }
                return string.Empty;
            }
            return string.Empty;
        }

        public string GetCommonFieldForInfo(DataRow dr, string fieldName, string apiName, string param)
        {
            if (this.CheckColumn(dr, fieldName) && this.CheckColumn(dr, "modelid"))
            {
                string input = string.Empty;
                int modelId = (int)dr["modelid"];
                if (this.GetInfoFieldType(modelId, fieldName) == 0)
                {
                    input = Ky.Common.Function.HtmlEncode(dr[fieldName].ToString()).Replace("\r\n", "<br/>").Replace(" ", "&nbsp;&nbsp;");
                }
                else
                {
                    input = dr[fieldName].ToString();
                }
                if (!(apiName.ToLower() == "len"))
                {
                    return input;
                }
                int length = 0;
                try
                {
                    length = int.Parse(param);
                }
                catch
                {
                }
                return this.SubStr(input, length, "");
            }
            return string.Empty;
        }

        public string GetCommonFieldForUserInfo(DataRow dr, string fieldName, string apiName, string param)
        {
            if (this.CheckColumn(dr, fieldName) && this.CheckColumn(dr, "modelid"))
            {
                string input = string.Empty;
                int modelId = (int)dr["modelid"];
                if (this.GetUserFieldType(modelId, fieldName) == 0)
                {
                    input = Ky.Common.Function.HtmlEncode(dr[fieldName].ToString()).Replace("\r\n", "<br/>").Replace(" ", "&nbsp;&nbsp;");
                }
                else
                {
                    input = dr[fieldName].ToString();
                }
                if (!(apiName.ToLower() == "len"))
                {
                    return input;
                }
                int length = 0;
                try
                {
                    length = int.Parse(param);
                }
                catch
                {
                }
                return this.SubStr(input, length, "");
            }
            return string.Empty;
        }

        public string GetCommonFiled(DataRow dr, string fiedName, string apiName, string param)
        {
            if (this.CheckColumn(dr, fiedName))
            {
                string input = Regex.Replace(dr[fiedName].ToString(), "<.+?>", "", RegexOptions.IgnoreCase).Replace("\r\n", "<br/>").Replace(" ", "&nbsp;&nbsp;");
                if (!(apiName.ToLower() == "len"))
                {
                    return input;
                }
                int length = 0;
                try
                {
                    length = int.Parse(param);
                }
                catch
                {
                }
                return this.SubStr(input, length, "");
            }
            return string.Empty;
        }

        public string GetContentByReplaceSysJS(string fileContent)
        {
            if (Regex.IsMatch(fileContent.ToString(), "<head>(.|\n)*?</head>", RegexOptions.IgnoreCase))
            {
                return Regex.Replace(fileContent.ToString(), @"<head>((.|\n)*?)</head>", "<head>$1" + this.GetSystemJS() + "</head>", RegexOptions.IgnoreCase);
            }
            return (this.GetSystemJS() + fileContent);
        }

        public string GetContentByReplaceSysJS2(string fileContent, int id, int modelId)
        {
            if (Regex.IsMatch(fileContent.ToString(), "<head>(.|\n)*?</head>", RegexOptions.IgnoreCase))
            {
                return Regex.Replace(fileContent.ToString(), @"<head>((.|\n)*?)</head>", "<head>$1" + this.GetSystemJS() + this.GetViewTotal(id, modelId) + "</head>", RegexOptions.IgnoreCase);
            }
            return (this.GetSystemJS() + this.GetViewTotal(id, modelId) + fileContent);
        }

        private string GetCopyright()
        {
            return this.SiteModel.CopyRight;
        }

        private string GetCurrent_Pos(string paramStr, string pos, int currId, string tableName)
        {
            ArrayList list;
            string[] strArray2;
            int num;
            DataRow info;
            string paramValue = string.Empty;
            string str2 = ">>";
            string str3 = "false";
            this.GetParamValue(paramStr, "hrefcss", ref paramValue);
            this.GetParamValue(paramStr, "compart", ref str2);
            this.GetParamValue(paramStr, "showchannel", ref str3);
            if (paramValue != string.Empty)
            {
                paramValue = "class='" + paramValue + "'";
            }
            M_Channel channel = null;
            M_Column column = null;
            string indexUrl = string.Empty;
            string channelUrl = string.Empty;
            StringBuilder builder = new StringBuilder();
            switch (pos.ToLower())
            {
                case "index":
                    builder.Append(this.SiteModel.SiteName);
                    goto Label_0B9C;

                case "singlepage":
                    {
                        indexUrl = this.GetIndexUrl();
                        builder.Append("<a " + paramValue + " href='" + indexUrl + "'>");
                        builder.Append(this.SiteModel.SiteName);
                        builder.Append("</a>");
                        builder.Append(str2);
                        M_SinglePage model = new B_SinglePage().GetModel(currId);
                        if (model != null)
                        {
                            builder.Append(model.Name);
                            goto Label_0B9C;
                        }
                        return string.Empty;
                    }
                case "channel":
                    channel = this.ChannelBll.GetChannel(currId);
                    if (channel != null)
                    {
                        indexUrl = this.GetIndexUrl();
                        builder.Append("<a " + paramValue + " href='" + indexUrl + "'>");
                        builder.Append(this.SiteModel.SiteName);
                        builder.Append("</a>");
                        builder.Append(str2);
                        builder.Append(channel.ChName);
                        goto Label_0B9C;
                    }
                    return string.Empty;

                case "column":
                    column = this.ColumnBll.GetColumn(currId);
                    if (column != null)
                    {
                        channel = this.ChannelBll.GetChannel(column.ChId);
                        if (channel == null)
                        {
                            return string.Empty;
                        }
                        indexUrl = this.GetIndexUrl();
                        channelUrl = this.GetChannelUrl(channel.ChId);
                        builder.Append("<a " + paramValue + " href='" + indexUrl + "'>");
                        builder.Append(this.SiteModel.SiteName);
                        builder.Append("</a>");
                        builder.Append(str2);
                        if (str3 == "true")
                        {
                            builder.Append("<a " + paramValue + " href='" + channelUrl + "'>");
                            builder.Append(channel.ChName);
                            builder.Append("</a>");
                            builder.Append(str2);
                        }
                        column = this.ColumnBll.GetColumn(currId);
                        list = new ArrayList();
                        string[] strArray = new string[] { this.GetColumnUrl(column.ColId, 1), column.ColName };
                        list.Add(strArray);
                        if (column.ColParentId > 0)
                        {
                            while (column.ColParentId >= 0)
                            {
                                if (column.ColParentId > 0)
                                {
                                    column = this.ColumnBll.GetColumn(column.ColParentId);
                                }
                                else
                                {
                                    column = this.ColumnBll.GetColumn(column.ColId);
                                }
                                if (column == null)
                                {
                                    return string.Empty;
                                }
                                strArray2 = new string[] { this.GetColumnUrl(column.ColId, 1), column.ColName };
                                list.Add(strArray2);
                                if (column.ColParentId == 0)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    return string.Empty;

                case "info":
                    info = this.InfoOperBll.GetInfo(tableName, currId);
                    if (info != null)
                    {
                        int columnId = (int)info["colid"];
                        column = this.ColumnBll.GetColumn(columnId);
                        if (column == null)
                        {
                            return string.Empty;
                        }
                        channel = this.ChannelBll.GetChannel(column.ChId);
                        if (channel == null)
                        {
                            return string.Empty;
                        }
                        channelUrl = this.GetChannelUrl(channel.ChId);
                        indexUrl = this.GetIndexUrl();
                        builder.Append("<a " + paramValue + " href='" + indexUrl + "'>");
                        builder.Append(this.SiteModel.SiteName);
                        builder.Append("</a>");
                        builder.Append(str2);
                        if (str3 == "true")
                        {
                            builder.Append("<a " + paramValue + " href='" + channelUrl + "'>");
                            builder.Append(channel.ChName);
                            builder.Append("</a>");
                            builder.Append(str2);
                        }
                        list = new ArrayList();
                        string[] strArray3 = new string[] { this.GetColumnUrl(column.ColId, 1), column.ColName };
                        list.Add(strArray3);
                        if (column.ColParentId > 0)
                        {
                            while (column.ColParentId >= 0)
                            {
                                if (column.ColParentId > 0)
                                {
                                    column = this.ColumnBll.GetColumn(column.ColParentId);
                                }
                                else
                                {
                                    column = this.ColumnBll.GetColumn(column.ColId);
                                }
                                if (column == null)
                                {
                                    return string.Empty;
                                }
                                strArray2 = new string[] { this.GetColumnUrl(column.ColId, 1), column.ColName };
                                list.Add(strArray2);
                                if (column.ColParentId == 0)
                                {
                                    break;
                                }
                            }
                        }
                        num = list.Count - 1;
                        while (num >= 0)
                        {
                            strArray2 = new string[2];
                            strArray2 = (string[])list[num];
                            builder.Append("<a " + paramValue + " href='" + strArray2[0] + "'>");
                            builder.Append(strArray2[1]);
                            builder.Append("</a>");
                            builder.Append(str2);
                            num--;
                        }
                        builder.Append("内容阅读");
                        goto Label_0B9C;
                    }
                    return string.Empty;

                case "comment":
                    indexUrl = this.GetIndexUrl();
                    builder.Append("<a " + paramValue + " href='" + indexUrl + "'>");
                    builder.Append(this.SiteModel.SiteName);
                    builder.Append("</a>");
                    builder.Append(str2);
                    info = this.dal.GetInfoById(tableName, currId);
                    if (info != null)
                    {
                        string infoUrl = this.GetInfoUrl(info, 1);
                        string str8 = Ky.Common.Function.HtmlEncode(info["title"].ToString());
                        builder.Append("<a " + paramValue + " href='" + infoUrl + "'>");
                        builder.Append(str8);
                        builder.Append("</a>");
                        builder.Append(str2);
                        builder.Append("评论列表");
                        goto Label_0B9C;
                    }
                    return string.Empty;

                case "special":
                    {
                        M_Special special = this.SpecialBll.GetSpecial(currId);
                        if (special != null)
                        {
                            indexUrl = this.GetIndexUrl();
                            builder.Append("<a " + paramValue + " href='" + indexUrl + "'>");
                            builder.Append(this.SiteModel.SiteName);
                            builder.Append("</a>");
                            builder.Append(str2);
                            string specialCName = special.SpecialCName;
                            if (special.ParentID != 0)
                            {
                                special = this.SpecialBll.GetSpecial(special.ParentID);
                                if (special == null)
                                {
                                    return string.Empty;
                                }
                                string specialUrl = this.GetSpecialUrl(special.ID, 1);
                                builder.Append("<a " + paramValue + " href='" + specialUrl + "'>");
                                builder.Append(special.SpecialCName);
                                builder.Append("</a>");
                                builder.Append(str2);
                            }
                            builder.Append(specialCName);
                            goto Label_0B9C;
                        }
                        return string.Empty;
                    }
                default:
                    goto Label_0B9C;
            }
            for (num = list.Count - 1; num >= 0; num--)
            {
                strArray2 = new string[2];
                strArray2 = (string[])list[num];
                if (num > 0)
                {
                    builder.Append("<a " + paramValue + " href='" + strArray2[0] + "'>");
                    builder.Append(strArray2[1]);
                    builder.Append("</a>");
                    builder.Append(str2);
                }
                else
                {
                    builder.Append(strArray2[1]);
                }
            }
        Label_0B9C:
            return builder.ToString();
        }

        private string GetCurrentUserInfo(string paramStr, DataRow dr)
        {
            string paramValue = "0";
            this.GetParamValue(paramStr, "userstyle", ref paramValue);
            string styleContent = this.GetStyleContent(int.Parse(paramValue));
            int num = int.Parse(dr["usertype"].ToString());
            int userId = int.Parse(dr["uid"].ToString());
            if (num == 0)
            {
                DataRow userAllInfo = new B_User().GetUserAllInfo(userId);
                if (userAllInfo == null)
                {
                    return string.Empty;
                }
                MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
                StringBuilder builder = new StringBuilder(styleContent);
                foreach (Match match in styleFileldName)
                {
                    if (match.Groups.Count > 1)
                    {
                        string input = match.Groups[1].Value.Trim().ToLower();
                        string apiName = string.Empty;
                        string param = string.Empty;
                        Match match2 = Regex.Match(input, @"(.*?)#(.*?)\((.*?)\)");
                        if (match2.Success)
                        {
                            input = match2.Groups[1].Value;
                            apiName = match2.Groups[2].Value;
                            param = match2.Groups[3].Value;
                        }
                        builder.Replace(match.Value, this.GetCommonFieldForInfo(userAllInfo, input, apiName, param));
                    }
                }
                return builder.ToString();
            }
            return string.Empty;
        }

        public string GetCurrPageHTML(int pageIndex, int currNumber, string href)
        {
            if (currNumber != pageIndex)
            {
                return string.Format("<a href=\"{0}\">{1}</a>", href, currNumber);
            }
            return string.Format("{1}", currNumber);
        }

        public string GetCurrPageHTML(int pageIndex, int currNumber, string paddingCss, string href)
        {
            if (currNumber != pageIndex)
            {
                return string.Format("<a href=\"{1}\">{2}</a>", paddingCss, href, currNumber);
            }
            return string.Format("<span class=\"\">{1}</span>", paddingCss, currNumber);
        }

        public DataTable GetDateRange(string tableName, string startDate, string endDate, int pageIndex, int pageSize)
        {
            return this.dal.GetDateRange(tableName, startDate, endDate, pageIndex, pageSize);
        }

        private string GetDateRangeStr(string dateRange)
        {
            int num = int.Parse(dateRange);
            if (num > 0)
            {
                return DateTime.Now.AddDays((double)(num * -1)).ToString("yyyy-MM-dd");
            }
            return string.Empty;
        }

        public string GetDateTime(DataRow dr, string dateStr)
        {
            if (this.CheckColumn(dr, "addtime"))
            {
                DateTime time = (DateTime)dr["addtime"];
                string str = dateStr;
                string newValue = string.Empty;
                if (dateStr.IndexOf("yyyy") != -1)
                {
                    newValue = time.ToString("yyyy");
                    str = str.Replace("yyyy", newValue);
                }
                else if (dateStr.IndexOf("yy") != -1)
                {
                    newValue = time.ToString("yy");
                    str = str.Replace("yy", newValue);
                }
                return str.Replace("mm", time.ToString("MM")).Replace("dd", time.ToString("dd")).Replace("hh", time.ToString("HH")).Replace("mi", time.ToString("mm")).Replace("ss", time.ToString("ss"));
            }
            return string.Empty;
        }

        private string GetDig(string paramStr, int infoId, int modelId)
        {
            string paramValue = string.Empty;
            this.GetParamValue(paramStr, "hrefCss", ref paramValue);
            return string.Format("<script language=\"javascript\" src=\"{0}/common/Dig.aspx?id={1}&modelid={2}&css={3}\"></script>", new object[] { Param.ApplicationRootPath, infoId, modelId, Ky.Common.Function.UrlEncode(paramValue) });
        }

        public int GetDigCount(int modelId, int infoId)
        {
            return this.dal.GetDigCount(modelId, infoId);
        }

        private string GetDomainName()
        {
            return this.SiteModel.Domain;
        }

        public string GetDownCount(DataRow dr, int type)
        {
            if (this.CheckColumn(dr, "id"))
            {
                int num = (int)dr["id"];
                return string.Concat(new object[] { "<script language='javascript' src='", Param.ApplicationRootPath, "/Common/GetDownCount.aspx?Id=", num, "&type=", type, "'></script>" });
            }
            return string.Empty;
        }

        public DataTable GetField_InfoList(int modelType, string tableName, int chId, int colId, string fieldName, string keyword, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.dal.GetField_InfoList(modelType, tableName, chId, colId, fieldName, keyword, pageIndex, pageSize, ref recordCount);
        }

        public string GetGoHTML(string f_url, int id, int pageCount, string paddingCss)
        {
            return string.Format("<span{0}>转到第<input type=\"text\" id=\"txtPageNav{3}\" style=\"width:15px\" maxlength=\"4\"/>页 <input type=\"button\" value=\"跳转\" onclick='go(\"{1}\",{2},{3})'/></span>", new object[] { paddingCss, f_url, pageCount, id });
        }

        public string GetHeaderImg(DataRow dr)
        {
            if (this.CheckColumn(dr, "headerimgpath") && this.CheckColumn(dr, "uploadpath"))
            {
                string str = dr["headerimgpath"].ToString();
                string str2 = dr["uploadpath"].ToString();
                return (Param.ApplicationRootPath + "/upload/" + str2 + "/" + str);
            }
            return string.Empty;
        }

        public DataTable GetIdRange(string tableName, int startId, int endId, int pageIndex, int pageSize)
        {
            return this.dal.GetIdRange(tableName, startId, endId, pageIndex, pageSize);
        }

        private string GetImgPath(DataRow dr, int pageIndex)
        {
            string str2 = string.Empty;
            string[] strArray = null;
            string str3 = string.Empty;
            M_InfoModel model = null;
            if (this.CheckColumn(dr, "imgpath") && this.CheckColumn(dr, "modelid"))
            {
                str2 = dr["imgpath"].ToString();
                if (str2.Length <= 0)
                {
                    return string.Empty;
                }
                str2 = str2.Substring(1, str2.Length - 2);
                model = this.InfoModelBll.GetModel((int)dr["modelId"]);
                str3 = Param.ApplicationRootPath + "/upload/" + model.UploadPath + "/";
                strArray = str2.Split(new char[] { '|' });
                if (strArray.Length > 0)
                {
                    return (str3 + strArray[pageIndex - 1].ToString() + " \"\" style=\"cursor:hand;\" onclick=\"javascript:window.location.href='" + this.GetNextPageAddress(dr, pageIndex, strArray.Length) + " '\"");
                }
            }
            return string.Empty;
        }

        private string GetIndex_Col_Nav(string paramStr)
        {
            string paramValue = string.Empty;
            this.GetParamValue(paramStr, "chid", ref paramValue);
            return this.Ch_Col_GetNav(paramStr, int.Parse(paramValue));
        }

        public string GetIndexPage()
        {
            string templatePath = Param.SiteRootPath + this.SiteModel.IndexTemplatePath.Replace("/", @"\");
            StringBuilder fileContent = new StringBuilder(this.GetContentByReplaceSysJS(this.ReadTemplate(templatePath)));
            this.ReplaceLabelNameToContent(fileContent);
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                string newValue = string.Empty;
                if (match.Groups.Count > 1)
                {
                    switch (match.Groups[1].Value.Trim().ToLower())
                    {
                        case "my_pos":
                            newValue = this.GetCurrent_Pos(match.Value, "index", 0, "");
                            goto Label_0450;

                        case "ch_infolist":
                            newValue = this.Ch_GetInfoList(match.Value, 0);
                            goto Label_0450;

                        case "col_infolist":
                            newValue = this.Col_GetInfoList(match.Value, 0);
                            goto Label_0450;

                        case "ch_col_infolist":
                            newValue = this.Ch_Col_GetInfoList(match.Value, 0);
                            goto Label_0450;

                        case "col_childcol_infolist":
                            newValue = this.Col_ChildCol_GetInfoList(match.Value, 0);
                            goto Label_0450;

                        case "index_ch_nav":
                            newValue = this.Index_Ch_GetNav(match.Value);
                            goto Label_0450;

                        case "col_flashinfolist":
                            newValue = this.Col_GetFlashInfoList(match.Value, 0);
                            goto Label_0450;

                        case "page_info":
                            newValue = this.Index_GetPageInfo(match.Value);
                            goto Label_0450;

                        case "addfav":
                            newValue = this.GetAddFav(match.Value);
                            goto Label_0450;

                        case "report":
                            newValue = this.GetReport(match.Value);
                            goto Label_0450;

                        case "login":
                            newValue = this.GetLogin(match.Value);
                            goto Label_0450;

                        case "pvtotal":
                            newValue = this.GetPvTotal();
                            goto Label_0450;

                        case "article_txt_headerlist":
                            newValue = this.Article_Text_GetHeaderList(match.Value);
                            goto Label_0450;

                        case "article_img_headerlist":
                            newValue = this.Article_Img_GetHeaderList(match.Value);
                            goto Label_0450;

                        case "searchform":
                            newValue = this.GetSearchForm();
                            goto Label_0450;

                        case "sitename":
                            newValue = this.GetSiteName();
                            goto Label_0450;

                        case "domain":
                            newValue = this.GetDomainName();
                            goto Label_0450;

                        case "copyright":
                            newValue = this.GetCopyright();
                            goto Label_0450;

                        case "logo":
                            newValue = this.GetLogoAddress();
                            goto Label_0450;

                        case "banner":
                            newValue = this.GetBannerAddress();
                            goto Label_0450;

                        case "applicationpath":
                            newValue = this.GetApplicationPath();
                            goto Label_0450;

                        case "vote":
                            newValue = this.GetVote(match.Value);
                            goto Label_0450;

                        case "kylink":
                            newValue = this.GetLink(match.Value);
                            goto Label_0450;

                        case "index_sp_nav":
                            newValue = this.GetIndexSpNav(match.Value);
                            goto Label_0450;

                        case "infototal":
                            newValue = this.GetTotal();
                            goto Label_0450;

                        case "index_col_nav":
                            newValue = this.GetIndex_Col_Nav(match.Value);
                            goto Label_0450;
                    }
                    newValue = string.Empty;
                }
            Label_0450:
                fileContent.Replace(match.Value, newValue);
            }
            return (fileContent.ToString() + "\r\n<!-- " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "签发-->");
        }

        private string GetIndexSpNav(string paramStr)
        {
            string paramValue = "";
            string str2 = "";
            string str3 = "";
            string str4 = "10";
            string str5 = "";
            this.GetParamValue(paramStr, "navcss", ref paramValue);
            this.GetParamValue(paramStr, "arrange", ref str2);
            this.GetParamValue(paramStr, "compart", ref str3);
            this.GetParamValue(paramStr, "navcount", ref str4);
            this.GetParamValue(paramStr, "target", ref str5);
            DataTable specials = this.SpecialBll.GetSpecials(0);
            DataView view = new DataView(specials);
            view.RowFilter = "islock=0";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < view.Count; i++)
            {
                int specialId = (int)view[i]["ID"];
                string str6 = view[i]["SpecialCName"].ToString();
                if (str2 == "true")
                {
                    if (i == int.Parse(str4))
                    {
                        builder.Append("<a href='");
                        builder.Append(this.GetSpecialUrl(specialId, 1));
                        builder.Append("' target='");
                        builder.Append(str5);
                        builder.Append("' class='");
                        builder.Append(paramValue);
                        builder.Append("'>");
                        builder.Append(str6);
                        builder.Append("</a><br/>");
                    }
                    else if (i >= (view.Count - 1))
                    {
                        builder.Append("<a href='");
                        builder.Append(this.GetSpecialUrl(specialId, 1));
                        builder.Append("' target='");
                        builder.Append(str5);
                        builder.Append("' class='");
                        builder.Append(paramValue);
                        builder.Append("'>");
                        builder.Append(str6);
                        builder.Append("</a>");
                    }
                    else
                    {
                        builder.Append("<a href='");
                        builder.Append(this.GetSpecialUrl(specialId, 1));
                        builder.Append("' target='");
                        builder.Append(str5);
                        builder.Append("' class='");
                        builder.Append(paramValue);
                        builder.Append("'>");
                        builder.Append(str6);
                        builder.Append("</a>");
                        builder.Append(str3);
                    }
                }
                else
                {
                    builder.Append(str3);
                    builder.Append("<a href='");
                    builder.Append(this.GetSpecialUrl(specialId, 1));
                    builder.Append("' target='");
                    builder.Append(str5);
                    builder.Append("' class='");
                    builder.Append(paramValue);
                    builder.Append("'>");
                    builder.Append(str6);
                    builder.Append("</a><br/>");
                }
            }
            specials.Dispose();
            view.Dispose();
            return builder.ToString();
        }

        public string GetIndexUrl()
        {
            if (!(this.SiteModel.IsStaticType && (this.SiteModel.PageType != 4)))
            {
                return (this.HostAddress + "/Index.aspx");
            }
            string str = string.Empty;
            switch (this.SiteModel.PageType)
            {
                case 2:
                    str = "htm";
                    break;

                case 3:
                    str = "shtml";
                    break;

                default:
                    str = "html";
                    break;
            }
            return (this.HostAddress + "/Index." + str);
        }

        public string GetInfo(DataRow dr, int pageId, int PageSize)
        {
            int modelId = (int)dr["modelId"];
            int id = (int)dr["id"];
            string templatePath = Param.SiteRootPath + dr["templatepath"].ToString().Replace("/", @"\");
            StringBuilder fileContent = null;
            fileContent = new StringBuilder(this.GetContentByReplaceSysJS2(this.ReadTemplate(templatePath), id, modelId));
            this.ReplaceLabelNameToContent(fileContent, int.Parse(dr["uid"].ToString()));
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                string newValue = string.Empty;
                if (match.Groups.Count > 1)
                {
                    switch (match.Groups[1].Value.Trim().ToLower())
                    {
                        case "my_pos":
                            newValue = this.GetCurrent_Pos(match.Value, "info", int.Parse(dr["Id"].ToString()), dr["tablename"].ToString());
                            goto Label_0639;

                        case "ch_infolist":
                            newValue = this.Ch_GetInfoList(match.Value, int.Parse(dr["chid"].ToString()));
                            goto Label_0639;

                        case "col_infolist":
                            newValue = this.Col_GetInfoList(match.Value, int.Parse(dr["colid"].ToString()));
                            goto Label_0639;

                        case "page_info":
                            newValue = this.Info_GetPageInfo(dr["tablename"].ToString(), int.Parse(dr["Id"].ToString()));
                            goto Label_0639;

                        case "index_ch_nav":
                            newValue = this.Index_Ch_GetNav(match.Value);
                            goto Label_0639;

                        case "browse_info":
                            newValue = this.Info(match.Value, dr, pageId, PageSize);
                            goto Label_0639;

                        case "addfav":
                            newValue = this.GetAddFav(match.Value);
                            goto Label_0639;

                        case "report":
                            newValue = this.GetReport(match.Value);
                            goto Label_0639;

                        case "col_flashinfolist":
                            newValue = this.Col_GetFlashInfoList(match.Value, 0);
                            goto Label_0639;

                        case "review":
                            newValue = this.GetCommentForm(modelId, int.Parse(dr["Id"].ToString()));
                            goto Label_0639;

                        case "reviewlist":
                            newValue = this.GetReviewList(modelId, int.Parse(dr["Id"].ToString()));
                            goto Label_0639;

                        case "vote":
                            newValue = this.GetVote(match.Value);
                            goto Label_0639;

                        case "login":
                            newValue = this.GetLogin(match.Value);
                            goto Label_0639;

                        case "pvtotal":
                            newValue = this.GetPvTotal();
                            goto Label_0639;

                        case "info_relationinfolist":
                            newValue = this.Info_GetRelationInfoList(match.Value, dr["tablename"].ToString(), dr["tagIdstr"].ToString());
                            goto Label_0639;

                        case "article_txt_headerlist":
                            newValue = this.Article_Text_GetHeaderList(match.Value);
                            goto Label_0639;

                        case "article_img_headerlist":
                            newValue = this.Article_Img_GetHeaderList(match.Value);
                            goto Label_0639;

                        case "searchform":
                            newValue = this.GetSearchForm();
                            goto Label_0639;

                        case "sitename":
                            newValue = this.GetSiteName();
                            goto Label_0639;

                        case "domain":
                            newValue = this.GetDomainName();
                            goto Label_0639;

                        case "copyright":
                            newValue = this.GetCopyright();
                            goto Label_0639;

                        case "logo":
                            newValue = this.GetLogoAddress();
                            goto Label_0639;

                        case "banner":
                            newValue = this.GetBannerAddress();
                            goto Label_0639;

                        case "applicationpath":
                            newValue = this.GetApplicationPath();
                            goto Label_0639;

                        case "kylink":
                            newValue = this.GetLink(match.Value);
                            goto Label_0639;

                        case "infototal":
                            newValue = this.GetTotal();
                            goto Label_0639;

                        case "index_sp_nav":
                            newValue = this.GetIndexSpNav(match.Value);
                            goto Label_0639;

                        case "currchid":
                            newValue = dr["chid"].ToString();
                            goto Label_0639;

                        case "currcolid":
                            newValue = dr["colid"].ToString();
                            goto Label_0639;

                        case "currinfoid":
                            newValue = id.ToString();
                            goto Label_0639;

                        case "curruserinfo":
                            newValue = this.GetCurrentUserInfo(match.Value, dr);
                            goto Label_0639;

                        case "index_col_nav":
                            newValue = this.GetIndex_Col_Nav(match.Value);
                            goto Label_0639;
                    }
                    newValue = string.Empty;
                }
            Label_0639:
                fileContent.Replace(match.Value, newValue);
            }
            return (fileContent.ToString() + "\r\n<!-- " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "签发-->");
        }

        public DataTable GetInfo(string tableName, int cursorPage, int pageSize)
        {
            return this.dal.GetInfo(tableName, cursorPage, pageSize);
        }

        public DataRow GetInfoById(string tableName, int Id)
        {
            return this.dal.GetInfoById(tableName, Id);
        }

        public string GetInfoCloseName(DataRow dr, string direct)
        {
            if (((this.CheckColumn(dr, "id") && this.CheckColumn(dr, "colid")) && (this.CheckColumn(dr, "modelid") && this.CheckColumn(dr, "tablename"))) && this.CheckColumn(dr, "title"))
            {
                int id = (int)dr["id"];
                int colid = (int)dr["colid"];
                int num3 = (int)dr["modelid"];
                string str = dr["typename"].ToString();
                string tableName = dr["tablename"].ToString();
                DataRow row = this.dal.GetCloseInfo(tableName, id, colid, direct);
                if (row != null)
                {
                    int num4 = (int)row["id"];
                    if (num4 == 0)
                    {
                        return ("没有" + str);
                    }
                    return Ky.Common.Function.HtmlEncode(row["title"].ToString());
                }
                return string.Empty;
            }
            return string.Empty;
        }

        public string GetInfoCloseUrl(DataRow dr, string direct)
        {
            if (((this.CheckColumn(dr, "id") && this.CheckColumn(dr, "colid")) && (this.CheckColumn(dr, "modelid") && this.CheckColumn(dr, "tablename"))) && this.CheckColumn(dr, "title"))
            {
                int id = (int)dr["id"];
                int colid = (int)dr["colid"];
                int modelId = (int)dr["modelid"];
                string str = dr["typename"].ToString();
                string tableName = dr["tablename"].ToString();
                DataRow row = this.dal.GetCloseInfo(tableName, id, colid, direct);
                if (row != null)
                {
                    int num4 = (int)row["id"];
                    if (num4 == 0)
                    {
                        return string.Empty;
                    }
                    return this.GetInfoUrl(num4, modelId, 1);
                }
                return string.Empty;
            }
            return string.Empty;
        }

        public string GetInfoCommentList(int modelId, int id, int pageIndex)
        {
            string tableName = this.GetTableName(modelId);
            if (tableName.Length == 0)
            {
                return string.Empty;
            }
            int columnId = (int)this.InfoOperBll.GetInfo(tableName, id)["colid"];
            M_Column column = this.ColumnBll.GetColumn(columnId);
            string templatePath = Param.SiteRootPath + column.CommentTemplatePath.Replace("/", @"\");
            StringBuilder fileContent = new StringBuilder(this.GetContentByReplaceSysJS(this.ReadTemplate(templatePath)));
            this.ReplaceLabelNameToContent(fileContent);
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                string newValue = string.Empty;
                if (match.Groups.Count > 1)
                {
                    switch (match.Groups[1].Value.Trim().ToLower())
                    {
                        case "morereviewlist":
                            newValue = this.GetMoreReviewList(modelId, id, pageIndex, match.Value);
                            goto Label_04B0;

                        case "review":
                            newValue = this.GetCommentForm(modelId, id);
                            goto Label_04B0;

                        case "ch_infolist":
                            newValue = this.Ch_GetInfoList(match.Value, 0);
                            goto Label_04B0;

                        case "col_infolist":
                            newValue = this.Col_GetInfoList(match.Value, 0);
                            goto Label_04B0;

                        case "ch_col_infolist":
                            newValue = this.Ch_Col_GetInfoList(match.Value, 0);
                            goto Label_04B0;

                        case "col_childcol_infolist":
                            newValue = this.Col_ChildCol_GetInfoList(match.Value, 0);
                            goto Label_04B0;

                        case "index_ch_nav":
                            newValue = this.Index_Ch_GetNav(match.Value);
                            goto Label_04B0;

                        case "col_flashinfolist":
                            newValue = this.Col_GetFlashInfoList(match.Value, 0);
                            goto Label_04B0;

                        case "addfav":
                            newValue = this.GetAddFav(match.Value);
                            goto Label_04B0;

                        case "report":
                            newValue = this.GetReport(match.Value);
                            goto Label_04B0;

                        case "login":
                            newValue = this.GetLogin(match.Value);
                            goto Label_04B0;

                        case "pvtotal":
                            newValue = this.GetPvTotal();
                            goto Label_04B0;

                        case "article_txt_headerlist":
                            newValue = this.Article_Text_GetHeaderList(match.Value);
                            goto Label_04B0;

                        case "article_img_headerlist":
                            newValue = this.Article_Img_GetHeaderList(match.Value);
                            goto Label_04B0;

                        case "searchform":
                            newValue = this.GetSearchForm();
                            goto Label_04B0;

                        case "sitename":
                            newValue = this.GetSiteName();
                            goto Label_04B0;

                        case "domain":
                            newValue = this.GetDomainName();
                            goto Label_04B0;

                        case "copyright":
                            newValue = this.GetCopyright();
                            goto Label_04B0;

                        case "logo":
                            newValue = this.GetLogoAddress();
                            goto Label_04B0;

                        case "banner":
                            newValue = this.GetBannerAddress();
                            goto Label_04B0;

                        case "applicationpath":
                            newValue = this.GetApplicationPath();
                            goto Label_04B0;

                        case "vote":
                            newValue = this.GetVote(match.Value);
                            goto Label_04B0;

                        case "kylink":
                            newValue = this.GetLink(match.Value);
                            goto Label_04B0;

                        case "infototal":
                            newValue = this.GetTotal();
                            goto Label_04B0;

                        case "my_pos":
                            newValue = this.GetCurrent_Pos(match.Value, "comment", id, tableName);
                            goto Label_04B0;

                        case "page_info":
                            newValue = this.Info_GetPageInfo(tableName, id);
                            goto Label_04B0;
                    }
                    newValue = string.Empty;
                }
            Label_04B0:
                fileContent.Replace(match.Value, newValue);
            }
            return fileContent.ToString();
        }

        private int GetInfoFieldType(int modelId, string fieldName)
        {
            if (((modelId == 1) || (modelId == 2)) || (modelId == 3))
            {
                if ((modelId == 2) && (fieldName.ToLower().Trim() == "content"))
                {
                    return 1;
                }
                if ((modelId == 3) && (fieldName.ToLower().Trim() == "content"))
                {
                    return 1;
                }
            }
            else
            {
                if (this.InfoFieldCaChe != null)
                {
                    DataRow[] rowArray = this.InfoFieldCaChe.Select(string.Format("modelid={0}", modelId));
                    if ((rowArray == null) || (rowArray.Length == 0))
                    {
                        this.InfoFieldCaChe = null;
                    }
                }
                if (this.InfoFieldCaChe == null)
                {
                    this.InfoFieldCaChe = this.InfoModelBll.GetTextType(modelId);
                }
                DataRow[] rowArray2 = this.InfoFieldCaChe.Select(string.Format("modelid={0} and [name]='{1}'", modelId, fieldName));
                if ((rowArray2 == null) || (rowArray2.Length == 0))
                {
                    return 0;
                }
                return 1;
            }
            return 0;
        }

        public string GetInfoHitCount(DataRow dr)
        {
            if (this.CheckColumn(dr, "id") && this.CheckColumn(dr, "modelid"))
            {
                int num = (int)dr["id"];
                int num2 = (int)dr["modelid"];
                return string.Concat(new object[] { "<script language='javascript' src='", Param.ApplicationRootPath, "/Common/GetInfoViewCount.aspx?modelId=", num2, "&Id=", num, "'></script>" });
            }
            return string.Empty;
        }

        public string GetInfoTagNameStr(DataRow dr, bool isList)
        {
            if ((this.CheckColumn(dr, "tagnamestr") && this.CheckColumn(dr, "tagidstr")) && this.CheckColumn(dr, "modelid"))
            {
                string str = dr["tagnamestr"].ToString();
                if (((str.Length > 0) && str.StartsWith("|")) && str.EndsWith("|"))
                {
                    str = str.Substring(0, str.Length - 1);
                    str = str.Substring(1, str.Length - 1);
                }
                string str2 = dr["tagidstr"].ToString();
                int num = (int)dr["modelid"];
                if (((str2.Length > 0) && str2.StartsWith("|")) && str2.EndsWith("|"))
                {
                    str2 = str2.Substring(0, str2.Length - 1);
                    str2 = str2.Substring(1, str2.Length - 1);
                }
                string[] strArray = str.Split(new char[] { '|' });
                string[] strArray2 = str2.Split(new char[] { '|' });
                StringBuilder builder = new StringBuilder();
                string str3 = string.Empty;
                for (int i = 0; (i < strArray2.Length) && (i < strArray.Length); i++)
                {
                    builder.Append(str3);
                    builder.Append(string.Concat(new object[] { "<a href='", Param.ApplicationRootPath, "/List.aspx?chid=", dr["chid"], "&Keyword=", Ky.Common.Function.UrlEncode(strArray[i]), "&FieldName=tagnamestr' target='_blank'>", Ky.Common.Function.HtmlEncode(strArray[i]), "</a>" }));
                    if (isList)
                    {
                        str3 = "&nbsp;&nbsp;";
                    }
                    else
                    {
                        str3 = "&nbsp;&nbsp;";
                    }
                }
                return builder.ToString();
            }
            return string.Empty;
        }

        public string GetInfoTitle(DataRow dr, int length)
        {
            string str = string.Empty;
            if ((!this.CheckColumn(dr, "title") || !this.CheckColumn(dr, "titlecolor")) || !this.CheckColumn(dr, "titlefonttype"))
            {
                return string.Empty;
            }
            string input = dr["title"].ToString();
            string str3 = dr["titleColor"].ToString();
            int num = int.Parse(dr["titlefonttype"].ToString());
            str = Ky.Common.Function.HtmlEncode(this.SubStr(input, length, ""));
            switch (num)
            {
                case 1:
                    str = "<b>" + str + "</b>";
                    break;

                case 2:
                    str = "<i>" + str + "</i>";
                    break;
            }
            if (str3 != string.Empty)
            {
                str = "<font style='color:#" + str3 + "'>" + str + "</font>";
            }
            return str;
        }

        public string GetInfoTitle(DataRow dr, string apiName, string param, int length)
        {
            if (apiName.Length != 0)
            {
                int num = 0;
                if (apiName.ToLower() == "len")
                {
                    try
                    {
                        num = int.Parse(param);
                    }
                    catch
                    {
                    }
                    return this.GetInfoTitle(dr, num);
                }
            }
            return this.GetInfoTitle(dr, length);
        }

        public string GetInfoTitleImg(DataRow dr)
        {
            if (this.CheckColumn(dr, "titleimgpath") && this.CheckColumn(dr, "uploadpath"))
            {
                string str = dr["titleimgpath"].ToString();
                if (str.Length == 0)
                {
                    return (Param.ApplicationRootPath + "/images/noPic.gif");
                }
                string str2 = dr["uploadpath"].ToString();
                return (Param.ApplicationRootPath + "/upload/" + str2 + "/" + str);
            }
            return string.Empty;
        }

        public string GetInfoUrl(DataRow dr)
        {
            return this.GetInfoUrl(dr, 1);
        }

        public string GetInfoUrl(DataRow dr, int pageIndex)
        {
            string str = string.Empty;
            int num = 0;
            int num2 = 0;
            num = (int)dr["modelid"];
            num2 = (int)dr["id"];
            if ((num == 1) && (this.CheckColumn(dr, "outerurl") && this.CheckColumn(dr, "viewuname")))
            {
                string str2 = dr["outerurl"].ToString();
                if (str2 != string.Empty)
                {
                    return str2;
                }
                if (dr["viewuname"].ToString() != string.Empty)
                {
                    if (pageIndex == 1)
                    {
                        return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", num, "&Id=", num2 });
                    }
                    return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", num, "&Id=", num2, "&P=", pageIndex });
                }
            }
            bool isStaticType = this.SiteModel.IsStaticType;
            bool flag2 = (bool)dr["isstatictype"];
            int num3 = (int)dr["pointcount"];
            int num4 = (int)dr["isopened"];
            bool flag3 = (bool)dr["colisopened"];
            int num5 = (int)dr["pagetype"];
            if ((((!isStaticType || !flag2) || (num4 == 0)) || ((num4 == 2) && !flag3)) || (num5 == 4))
            {
                if (pageIndex == 1)
                {
                    return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", num, "&Id=", num2 });
                }
                return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", num, "&Id=", num2, "&P=", pageIndex });
            }
            string str4 = string.Empty;
            string str5 = string.Empty;
            string str6 = string.Empty;
            string str7 = dr["dirname"].ToString();
            string str8 = dr["coldirname"].ToString();
            int num6 = (int)dr["infosorttype"];
            int num7 = (int)dr["filenametype"];
            DateTime time = (DateTime)dr["addtime"];
            int id = (int)dr["chid"];
            M_Channel channel = this.ChannelBll.GetChannel(id);
            if (!channel.IsChildSite || (channel.ChildSiteUrl.Length == 0))
            {
                switch (num6)
                {
                    case 1:
                        goto Label_041B;

                    case 2:
                        str4 = "/" + str7 + "/html";
                        goto Label_04E5;

                    case 3:
                        str4 = "/" + str7;
                        goto Label_04E5;

                    case 4:
                        str4 = "/" + str7 + "/" + time.ToString("yyyy'/'MM'/'dd");
                        goto Label_04E5;

                    case 5:
                        str4 = "/" + str7 + "/" + time.ToString("yyyy'/'MM-dd");
                        goto Label_04E5;

                    case 6:
                        str4 = "/" + str7 + "/" + time.ToString("yyyy-MM-dd");
                        goto Label_04E5;

                    case 7:
                        str4 = "/" + str7 + "/" + time.ToString("yyyyMM");
                        goto Label_04E5;
                }
            }
            else
            {
                switch (num6)
                {
                    case 2:
                        str4 = "html";
                        goto Label_04E5;

                    case 3:
                        str4 = "";
                        goto Label_04E5;

                    case 4:
                        str4 = time.ToString("yyyy'/'MM'/'dd");
                        goto Label_04E5;

                    case 5:
                        str4 = time.ToString("yyyy'/'MM-dd");
                        goto Label_04E5;

                    case 6:
                        str4 = time.ToString("yyyy-MM-dd");
                        goto Label_04E5;

                    case 7:
                        str4 = time.ToString("yyyyMM");
                        goto Label_04E5;
                }
                str4 = str8;
                goto Label_04E5;
            }
        Label_041B:
            str4 = "/" + str7 + "/" + str8;
        Label_04E5:
            switch (num5)
            {
                case 2:
                    str5 = "htm";
                    break;

                case 3:
                    str5 = "shtml";
                    break;

                default:
                    str5 = "html";
                    break;
            }
            switch (num7)
            {
                case 2:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { time.ToString("yyyyMM"), num2, ".", str5 }) : string.Concat(new object[] { time.ToString("yyyyMM"), num2, "_", pageIndex, ".", str5 });
                    break;

                case 3:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { time.ToString("yyyyMMdd"), num2, ".", str5 }) : string.Concat(new object[] { time.ToString("yyyyMMdd"), num2, "_", pageIndex, ".", str5 });
                    break;

                case 4:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { str7, "_", num2, ".", str5 }) : string.Concat(new object[] { str7, "_", num2, "_", pageIndex, ".", str5 });
                    break;

                case 5:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { str7, "_", time.ToString("yyyyMMdd"), num2, ".", str5 }) : string.Concat(new object[] { str7, "_", time.ToString("yyyyMMdd"), num2, "_", pageIndex, ".", str5 });
                    break;

                default:
                    str6 = (pageIndex == 1) ? (num2 + "." + str5) : string.Concat(new object[] { num2, "_", pageIndex, ".", str5 });
                    break;
            }
            if (channel.IsChildSite && (channel.ChildSiteUrl.Length != 0))
            {
                if (this.SiteModel.IsAbsPathType)
                {
                    if (str4.Length == 0)
                    {
                        str = channel.ChildSiteUrl + "/" + str6;
                    }
                    else
                    {
                        str = channel.ChildSiteUrl + "/" + str4 + "/" + str6;
                    }
                    return str;
                }
                if (str4.Length == 0)
                {
                    str = str6;
                }
                else
                {
                    str = str4 + "/" + str6;
                }
                return str;
            }
            return (this.HostAddress + str4 + "/" + str6);
        }

        public string GetInfoUrl(int id, string tableName)
        {
            DataRow[] rowArray = this.GetModelAll().Select("tablename='" + tableName + "'");
            int modelId = 0;
            if ((rowArray != null) && (rowArray.Length > 0))
            {
                modelId = (int)rowArray[0]["ModelId"];
                return this.GetInfoUrl(id, modelId, 1);
            }
            return string.Empty;
        }

        public string GetInfoUrl(int id, int modelId, int pageIndex)
        {
            string str = string.Empty;
            M_InfoModel model = this.InfoModelBll.GetModel(modelId);
            if (model == null)
            {
                return string.Empty;
            }
            DataRow info = this.InfoOperBll.GetInfo(model.TableName, id);
            if (modelId == 1)
            {
                if (!this.CheckColumn(info, "outerurl") || !this.CheckColumn(info, "viewuname"))
                {
                    return string.Empty;
                }
                string str2 = info["outerurl"].ToString();
                if (str2 != string.Empty)
                {
                    return str2;
                }
                if (info["viewuname"].ToString() != string.Empty)
                {
                    if (pageIndex == 1)
                    {
                        return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", modelId, "&Id=", id });
                    }
                    return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", modelId, "&Id=", id, "&P=", pageIndex });
                }
            }
            int columnId = (int)info["colId"];
            M_Column column = this.ColumnBll.GetColumn(columnId);
            if (column == null)
            {
                return string.Empty;
            }
            M_Channel channel = this.ChannelBll.GetChannel(column.ChId);
            if (channel == null)
            {
                return string.Empty;
            }
            bool isStaticType = this.SiteModel.IsStaticType;
            bool flag2 = channel.IsStaticType;
            int num2 = (int)info["pointcount"];
            int num3 = (int)info["isopened"];
            bool isOpened = column.IsOpened;
            int num4 = (int)info["pagetype"];
            if ((((!isStaticType || !flag2) || (num3 == 0)) || ((num3 == 2) && !isOpened)) || (num4 == 4))
            {
                if (pageIndex == 1)
                {
                    return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", modelId, "&Id=", id });
                }
                return string.Concat(new object[] { this.HostAddress, "/Info.aspx?ModelId=", modelId, "&Id=", id, "&P=", pageIndex });
            }
            string str4 = string.Empty;
            string str5 = string.Empty;
            string str6 = string.Empty;
            string dirName = channel.DirName;
            string colDirName = column.ColDirName;
            int infoSortType = channel.InfoSortType;
            int fileNameType = channel.FileNameType;
            DateTime time = (DateTime)info["addtime"];
            if (!channel.IsChildSite || (channel.ChildSiteUrl.Length == 0))
            {
                switch (infoSortType)
                {
                    case 1:
                        goto Label_044F;

                    case 2:
                        str4 = "/" + dirName + "/html";
                        goto Label_0519;

                    case 3:
                        str4 = "/" + dirName;
                        goto Label_0519;

                    case 4:
                        str4 = "/" + dirName + "/" + time.ToString("yyyy'/'MM'/'dd");
                        goto Label_0519;

                    case 5:
                        str4 = "/" + dirName + "/" + time.ToString("yyyy'/'MM-dd");
                        goto Label_0519;

                    case 6:
                        str4 = "/" + dirName + "/" + time.ToString("yyyy-MM-dd");
                        goto Label_0519;

                    case 7:
                        str4 = "/" + dirName + "/" + time.ToString("yyyyMM");
                        goto Label_0519;
                }
            }
            else
            {
                switch (infoSortType)
                {
                    case 2:
                        str4 = "html";
                        goto Label_0519;

                    case 3:
                        str4 = "";
                        goto Label_0519;

                    case 4:
                        str4 = time.ToString("yyyy'/'MM'/'dd");
                        goto Label_0519;

                    case 5:
                        str4 = time.ToString("yyyy'/'MM-dd");
                        goto Label_0519;

                    case 6:
                        str4 = time.ToString("yyyy-MM-dd");
                        goto Label_0519;

                    case 7:
                        str4 = time.ToString("yyyyMM");
                        goto Label_0519;
                }
                str4 = colDirName;
                goto Label_0519;
            }
        Label_044F:
            str4 = "/" + dirName + "/" + colDirName;
        Label_0519:
            switch (num4)
            {
                case 2:
                    str5 = "htm";
                    break;

                case 3:
                    str5 = "shtml";
                    break;

                default:
                    str5 = "html";
                    break;
            }
            switch (fileNameType)
            {
                case 2:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { time.ToString("yyyyMM"), id, ".", str5 }) : string.Concat(new object[] { time.ToString("yyyyMM"), id, "_", pageIndex, ".", str5 });
                    break;

                case 3:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { time.ToString("yyyyMMdd"), id, ".", str5 }) : string.Concat(new object[] { time.ToString("yyyyMMdd"), id, "_", pageIndex, ".", str5 });
                    break;

                case 4:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { dirName, "_", id, ".", str5 }) : string.Concat(new object[] { dirName, "_", id, "_", pageIndex, ".", str5 });
                    break;

                case 5:
                    str6 = (pageIndex == 1) ? string.Concat(new object[] { dirName, "_", time.ToString("yyyyMMdd"), id, ".", str5 }) : string.Concat(new object[] { dirName, "_", time.ToString("yyyyMMdd"), id, "_", pageIndex, ".", str5 });
                    break;

                default:
                    str6 = (pageIndex == 1) ? (id + "." + str5) : string.Concat(new object[] { id, "_", pageIndex, ".", str5 });
                    break;
            }
            if (channel.IsChildSite && (channel.ChildSiteUrl.Length != 0))
            {
                if (this.SiteModel.IsAbsPathType)
                {
                    if (str4.Length == 0)
                    {
                        str = channel.ChildSiteUrl + "/" + str6;
                    }
                    else
                    {
                        str = channel.ChildSiteUrl + "/" + str4 + "/" + str6;
                    }
                    return str;
                }
                if (str4.Length == 0)
                {
                    str = str6;
                }
                else
                {
                    str = str4 + "/" + str6;
                }
                return str;
            }
            return (this.HostAddress + str4 + "/" + str6);
        }

        public DataTable GetIrregularr(string tableName, int chId, int pageIndex, int pageSize, ref int recordCount)
        {
            DataSet set = this.dal.GetIrregularr(tableName, chId, pageIndex, pageSize);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        private string GetLabelContent(string lbName)
        {
            if (!this.lbCache.Contains(lbName))
            {
                string labelContentByName = new B_LabelContent().GetLabelContentByName(lbName);
                this.lbCache.Add(lbName, labelContentByName);
            }
            return this.lbCache[lbName].ToString();
        }

        private string GetLink(string paramStr)
        {
            int num5;
            string paramValue = "0";
            string str2 = "10";
            string str3 = "false";
            string str4 = "10";
            string str5 = "_blank";
            string whereString = string.Empty;
            string str7 = string.Empty;
            int num = 2;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            this.GetParamValue(paramStr, "type", ref paramValue);
            this.GetParamValue(paramStr, "linkcount", ref str2);
            this.GetParamValue(paramStr, "arrange", ref str3);
            this.GetParamValue(paramStr, "rowcount", ref str4);
            this.GetParamValue(paramStr, "linktarget", ref str5);
            num2 = int.Parse(str4);
            switch (paramValue)
            {
                case "0":
                    whereString = "";
                    break;

                case "1":
                case "2":
                    if (paramValue == "1")
                    {
                        whereString = "linktype=1 and";
                    }
                    else
                    {
                        whereString = "linktype=2 and";
                    }
                    break;

                default:
                    whereString = "linkcategory='" + paramValue + "' and";
                    break;
            }
            whereString = whereString + " Status=2 and IsDisable=0";
            B_Link link = new B_Link();
            DataTable table = link.GetList(int.Parse(str2), 1, whereString).Tables[0];
            num3 = (table.Rows.Count / int.Parse(str4)) + 1;
            num4 = (num3 * int.Parse(str4)) - table.Rows.Count;
            if ((table.Rows.Count > 0) && (table != null))
            {
                if (str3 == "false")
                {
                    for (num5 = 0; num5 < table.Rows.Count; num5++)
                    {
                        if (num5 == (num2 - 1))
                        {
                            str7 = str7 + this.GetLinkStr(table.Rows[num5], str5) + "<br>";
                            num2 = int.Parse(str4) * num;
                            num++;
                        }
                        else
                        {
                            str7 = str7 + this.GetLinkStr(table.Rows[num5], str5);
                        }
                    }
                }
                else
                {
                    for (num5 = 0; num5 < table.Rows.Count; num5++)
                    {
                        str7 = str7 + this.GetLinkStr(table.Rows[num5], str5) + "<br>";
                    }
                }
            }
            for (num5 = 0; num5 < num4; num5++)
            {
                if (paramValue == "2")
                {
                    str7 = str7 + "<a href=\"" + Param.ApplicationRootPath + "/other/RegLink.aspx\" target=\"" + str5 + "\"><img src=\"" + Param.ApplicationRootPath + "/images/appfriendlink.gif\" border=\"0\" width=\"88\" height=\"31\" alt=\" 申请友情链接\"></a> ";
                }
                else
                {
                    str7 = str7 + "<a href=\"" + Param.ApplicationRootPath + "/other/RegLink.aspx\" target=\"" + str5 + "\">申请友情链接</a> ";
                }
            }
            return str7;
        }

        private string GetLinkStr(DataRow dr, string target)
        {
            string str = string.Empty;
            if (((int)dr["LinkType"]) == 1)
            {
                return string.Concat(new object[] { str, "<a href=\"", dr["SiteUrl"], "\" target=\"", target, "\">", dr["SiteName"].ToString(), "</a> " });
            }
            return string.Concat(new object[] { str, "<a href=\"", dr["SiteUrl"], "\" target=\"", target, "\"><img src=\"", dr["SiteLogo"].ToString(), "\" border=\"0\" width=\"88\" height=\"31\"", dr["SiteName"].ToString(), "></a> " });
        }

        public void GetListStyleHTML(MatchCollection mc, StringBuilder sb, DataRow dr, int titleLength, string dateFormat, int rowIndex)
        {
            foreach (Match match in mc)
            {
                if (match.Groups.Count > 1)
                {
                    string input = match.Groups[1].Value.Trim().ToLower();
                    string apiName = string.Empty;
                    string param = string.Empty;
                    Match match2 = Regex.Match(input, @"(.*?)#(.*?)\((.*?)\)");
                    if (match2.Success)
                    {
                        input = match2.Groups[1].Value;
                        apiName = match2.Groups[2].Value;
                        param = match2.Groups[3].Value;
                    }
                    switch (input)
                    {
                        case "rep":
                            sb.Replace(match.Value, this.GetRep(rowIndex, apiName, param));
                            break;

                        case "rowindex":
                            sb.Replace(match.Value, this.GetRowIndex(rowIndex));
                            break;

                        case "title":
                            sb.Replace(match.Value, this.GetInfoTitle(dr, apiName, param, titleLength));
                            break;

                        case "infourl":
                            sb.Replace(match.Value, this.GetInfoUrl(dr));
                            break;

                        case "addtime":
                            sb.Replace(match.Value, this.GetDateTime(dr, dateFormat));
                            break;

                        case "columnurl":
                            sb.Replace(match.Value, this.GetColumnUrl(dr));
                            break;

                        case "titleimgpath":
                            sb.Replace(match.Value, this.GetInfoTitleImg(dr));
                            break;

                        case "tagnamestr":
                            sb.Replace(match.Value, this.GetInfoTagNameStr(dr, true));
                            break;

                        default:
                            sb.Replace(match.Value, this.GetCommonFiled(dr, input, apiName, param));
                            break;
                    }
                }
            }
        }

        private string GetLogin(string paramStr)
        {
            string paramValue = string.Empty;
            this.GetParamValue(paramStr, "arrange", ref paramValue);
            StringBuilder builder = new StringBuilder();
            builder.Append("<!-- 用户登陆引用 start-->\r\n");
            builder.Append("<script language='javascript'>");
            builder.Append("var data = XmlHttpPostMethodText('" + Param.ApplicationRootPath + "/sys_template/login.aspx?loginModel=" + paramValue + "','');\r\n");
            builder.Append("document.write(data)");
            builder.Append("</script>");
            builder.Append("<!-- 用户登陆引用 end-->\r\n");
            return builder.ToString();
        }

        private string GetLogoAddress()
        {
            return this.SiteModel.LogoAddress;
        }

        private DataTable GetModelAll()
        {
            if (this.modelCache == null)
            {
                this.modelCache = this.InfoModelBll.GetList();
            }
            return this.modelCache;
        }

        private string GetMoreReviewList(int modelType, int id, int pageIndex, string paramStr)
        {
            string paramValue = "20";
            this.GetParamValue(paramStr, "pagesize", ref paramValue);
            StringBuilder builder = new StringBuilder();
            builder.Append("<!-- 更多评论列表引用 start-->\r\n");
            builder.Append(string.Concat(new object[] { "<div id='review_morelist_", modelType, "_", id, "'></div>" }));
            builder.Append("<script language='javascript'>");
            builder.Append(string.Concat(new object[] { "var data = XmlHttpGetMethodText('", Param.ApplicationRootPath, "/sys_template/MoreReviewList.aspx?ModelType=", modelType, "&Id=", id, "&PageSize=", paramValue, "&P=", pageIndex, "');\r\n" }));
            builder.Append(string.Concat(new object[] { "document.getElementById('review_morelist_", modelType, "_", id, "').innerHTML=data;" }));
            builder.Append("</script>");
            builder.Append("<!-- 更多评论列表引用 end-->\r\n");
            return builder.ToString();
        }

        public DataTable GetNewRecordNum(string tableName, int topNum, int pageIndex, int pageSize)
        {
            return this.dal.GetNewRecordNum(tableName, topNum, pageIndex, pageSize);
        }

        private string GetNextPageAddress(DataRow dr, int pageId, int pageSize)
        {
            string str = string.Empty;
            string[] strArray = this.NewsFileName(dr).Split(new char[] { '|' });
            M_Column column = this.ColumnBll.GetColumn((int)dr["colId"]);
            M_Channel channel = this.ChannelBll.GetChannel((int)dr["chId"]);
            int num = (int)dr["modelid"];
            bool isStaticType = this.SiteModel.IsStaticType;
            bool flag2 = (bool)dr["isstatictype"];
            int num2 = (int)dr["isopened"];
            bool flag3 = (bool)dr["colisopened"];
            int num3 = (int)dr["pointcount"];
            int num4 = (int)dr["pagetype"];
            string str4 = string.Empty;
            if (num == 1)
            {
                str4 = (string)dr["viewuname"];
            }
            if (((!isStaticType || !flag2) || ((num4 == 4) || (str4.Length != 0))) || ((num != 3) && (((num3 > 0) || (num2 == 0)) || ((num2 == 2) && !flag3))))
            {
                if (pageId == pageSize)
                {
                    str = string.Concat(new object[] { Param.ApplicationRootPath, "/Info.aspx?ModelId=", dr["modelId"], "&Id=", dr["id"], "&P=", pageSize });
                }
                else
                {
                    str = string.Concat(new object[] { Param.ApplicationRootPath, "/Info.aspx?ModelId=", dr["modelId"], "&id=", dr["Id"], "&P=", pageId + 1 });
                }
                return str;
            }
            if (pageId != pageSize)
            {
                str = string.Concat(new object[] { strArray[0], dr["id"], "_", pageId + 1, strArray[1] });
            }
            else if (pageId == 1)
            {
                str = strArray[0] + dr["id"] + strArray[1];
            }
            else
            {
                str = string.Concat(new object[] { strArray[0], dr["id"], "_", pageSize - 1, strArray[1] });
            }
            return str;
        }

        public string GetNextPageHTML(int pageIndex, int pageCount, string nextPageText, string paddingCss, string href)
        {
            if (pageIndex >= pageCount)
            {
                return string.Format("<span class=\"\">{1}</span>", paddingCss, nextPageText);
            }
            return string.Format("<a href=\"{1}\">{2}</a>", paddingCss, href, nextPageText);
        }

        private string GetOrderStr(string orderStr)
        {
            string str3 = orderStr;
            if ((str3 != null) && !(str3 == "datedesc"))
            {
                if (str3 == "dateasc")
                {
                    return "i.[addtime] asc";
                }
                if (str3 == "hitdesc")
                {
                    return "i.[hitcount] desc";
                }
                if (str3 == "hitasc")
                {
                    return "i.[hitcount] asc";
                }
            }
            return " i.[addtime] desc ";
        }

        public DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
            {
                return dt;
            }
            DataTable table = dt.Copy();
            table.Clear();
            int num = (PageIndex - 1) * PageSize;
            int count = PageIndex * PageSize;
            if (num < dt.Rows.Count)
            {
                if (count > dt.Rows.Count)
                {
                    count = dt.Rows.Count;
                }
                for (int i = num; i <= (count - 1); i++)
                {
                    DataRow row = table.NewRow();
                    DataRow row2 = dt.Rows[i];
                    foreach (DataColumn column in dt.Columns)
                    {
                        row[column.ColumnName] = row2[column.ColumnName];
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        private string GetPageIndexContent(DataRow dr, int pageIndex)
        {
            string content = string.Empty;
            string[] strArray = null;
            DataTable table = this.CreateDataTable();
            string str2 = string.Empty;
            int pageSize = this.TotalContentPageNumber(dr);
            if (this.CheckColumn(dr, "content"))
            {
                string str5;
                MatchCollection matchs;
                string str6;
                string labelContent;
                string vote;
                string uploadPath = (string)dr["uploadPath"];
                content = dr["content"].ToString().Replace("{Ky:PAGE}", "┃");
                content = new B_ConvertImage(this.SiteModel.Domain, uploadPath).ConvertContent(content);
                strArray = content.Split(new char[] { '┃' });
                if (strArray.Length > 1)
                {
                    int num2 = 0;
                    foreach (string str4 in strArray)
                    {
                        DataRow row = table.NewRow();
                        row["DtId"] = num2;
                        str5 = "";
                        matchs = Regex.Matches(str4, "{Ky_.*?}", RegexOptions.IgnoreCase);
                        if (matchs.Count > 0)
                        {
                            str6 = "";
                            foreach (Match match in matchs)
                            {
                                str6 = match.Value;
                            }
                            labelContent = this.GetLabelContent(str6);
                            if (labelContent != "")
                            {
                                vote = this.GetVote(labelContent);
                                str5 = str4.Replace(str6, vote);
                            }
                            else
                            {
                                str5 = str4.Replace(str6, "");
                            }
                        }
                        else
                        {
                            str5 = str4;
                        }
                        row["DtCon"] = str5;
                        table.Rows.Add(row);
                        num2++;
                    }
                    str2 = table.Rows[pageIndex - 1]["DtCon"].ToString();
                }
                else
                {
                    str5 = "";
                    matchs = Regex.Matches(content, "{Ky_.*?}", RegexOptions.IgnoreCase);
                    if (matchs.Count > 0)
                    {
                        str6 = "";
                        foreach (Match match in matchs)
                        {
                            str6 = match.Value;
                        }
                        labelContent = this.GetLabelContent(str6);
                        if (labelContent != "")
                        {
                            vote = this.GetVote(labelContent);
                            str5 = content.Replace(str6, vote);
                        }
                        else
                        {
                            str5 = content.Replace(str6, "");
                        }
                    }
                    if (str5 != "")
                    {
                        str2 = str5;
                    }
                    else
                    {
                        str2 = content;
                    }
                }
            }
            return (str2 + this.GetPageSize(dr, pageIndex, pageSize));
        }
        //单页内容分页
        private string GetPageSize(DataRow dr, int pageId, int pageSize)
        {
            int num5;
            if (pageSize <= 1)
            {
                return string.Empty;
            }
            string[] strArray = this.NewsFileName(dr).Split(new char[] { '|' });
            string str4 = string.Empty;
            string str5 = "\r\n<div style=\"text-align:center\">";
            string str6 = "</div>";
            string str7 = string.Empty;
            string str8 = string.Empty;
            string strPage = "<div class=pagecss>";//单页内容分页样式
            M_Column column = this.ColumnBll.GetColumn((int)dr["colId"]);
            M_Channel channel = this.ChannelBll.GetChannel((int)dr["chId"]);
            int num = (int)dr["modelid"];
            bool isStaticType = this.SiteModel.IsStaticType;
            bool flag2 = (bool)dr["isstatictype"];
            int num2 = (int)dr["isopened"];
            bool flag3 = (bool)dr["colisopened"];
            int num3 = (int)dr["pointcount"];
            int num4 = (int)dr["pagetype"];
            string str9 = string.Empty;
            switch (num)
            {
                case 1:
                    str9 = dr["viewuname"].ToString();
                    break;

                case 2:
                    if (((!isStaticType || !flag2) || ((num4 == 4) || (str9.Length != 0))) || ((num != 3) && (((num3 > 0) || (num2 == 0)) || ((num2 == 2) && !flag3))))
                    {
                        for (num5 = 1; num5 <= pageSize; num5++)
                        {
                            str4 = string.Concat(new object[] { str4, " <a href=", Param.ApplicationRootPath, "/Info.aspx?ModelId=", dr["modelId"], "&Id=", dr["id"], "&P=", num5, ">[", num5, "]</a>" });
                        }
                        return (str5 + str4 + str6);
                    }
                    for (num5 = 0; num5 < pageSize; num5++)
                    {
                        if (num5 != 0)
                        {
                            str4 = string.Concat(new object[] { str4, " <a href=\"", strArray[0], dr["id"], "_", num5, strArray[1], "\">", num5 + 1, "</a>" });
                        }
                        else
                        {
                            str4 = string.Concat(new object[] { str4, " <a href=\"", strArray[0], dr["id"], strArray[1], "\">", num5 + 1, "</a>" });
                        }
                    }
                    return (str5 + str4 + str6);
            }
            if (((!isStaticType || !flag2) || ((num4 == 4) || (str9.Length != 0))) || ((num != 3) && ((num2 == 0) || ((num2 == 2) && !flag3))))
            {
                str7 = string.Concat(new object[] { strPage + "<a href=", Param.ApplicationRootPath, "/Info.aspx?ModelId=", dr["modelId"], "&Id=", dr["id"], "&P=1>首页</a>" });
                str8 = string.Concat(new object[] { " <a href=", Param.ApplicationRootPath, "/Info.aspx?ModelId=", dr["modelId"], "&Id=", dr["id"], "&P=", pageSize, ">尾页</a></div>" });
                for (num5 = 1; num5 < (pageSize + 1); num5++)
                {
                    str4 = string.Concat(new object[] { str4, " <a href=", Param.ApplicationRootPath, "/Info.aspx?ModelId=", dr["modelId"], "&Id=", dr["id"], "&P=", num5, ">", num5, "</a>" });
                }
                return (str5 + str7 + str4 + str8 + str6);
            }
            str7 = string.Concat(new object[] { strPage + "<a href=\"", strArray[0], dr["id"], strArray[1], "\">首页</a>" });
            str8 = string.Concat(new object[] { " <a href=\"", strArray[0], dr["id"], "_", pageSize - 1, strArray[1], "\">尾页</a></div>" });
            for (num5 = 0; num5 < pageSize; num5++)
            {
                if (num5 != 0)
                {
                    str4 = string.Concat(new object[] { str4, " <a href=\"", strArray[0], dr["id"], "_", num5, strArray[1], "\">", num5 + 1, "</a>" });
                }
                else
                {
                    str4 = string.Concat(new object[] { str4, " <a href=\"", strArray[0], dr["id"], strArray[1], "\">", num5 + 1, "</a> " });
                }
            }
            return (str5 + str7 + str4 + str8 + str6);
        }

        private MatchCollection GetParamId(string paramStr)
        {
            return Regex.Matches(paramStr, "{\\$Ky.*?\\bid=\"(.*?)\".*?/}", RegexOptions.IgnoreCase);
        }

        private void GetParamValue(string paramStr, string paramName, ref string paramValue)
        {
            MatchCollection matchs = Regex.Matches(paramStr, @"{\$Ky.*?\b" + paramName + "=\"(.*?)\".*?/}", RegexOptions.IgnoreCase);
            if (((matchs.Count > 0) && (matchs[0].Groups.Count > 1)) && (matchs[0].Groups[1].Value != ""))
            {
                paramValue = matchs[0].Groups[1].Value.ToLower();
            }
        }

        public string GetPrePageHTML(int pageIndex, string prePageText, string paddingCss, string href)
        {
            if (pageIndex <= 1)
            {
                return string.Format("<span{0}>{1}</span>", paddingCss, prePageText);
            }
            return string.Format("<a href=\"{1}\">{2}</a>", paddingCss, href, prePageText);
        }

        private string GetPvTotal()
        {
            return ("<script language='javascript' src='" + Param.ApplicationRootPath + "/common/ViewCount.aspx'></script>\r\n");
        }

        private string GetRep(int rowIndex, string apiName, string param)
        {
            if (apiName.ToLower() != "rep")
            {
                return string.Empty;
            }
            if (param == string.Empty)
            {
                return "1";
            }
            int num = 1;
            try
            {
                num = int.Parse(param);
            }
            catch
            {
            }
            int num2 = (rowIndex + 1) % num;
            if (num2 == 0)
            {
                num2 = num;
            }
            return num2.ToString();
        }

        private string GetReport(string paramStr)
        {
            string paramValue = "[举报]";
            this.GetParamValue(paramStr, "showtext", ref paramValue);
            return ("<a href=\"javascript:WinOpen('" + Param.ApplicationRootPath + "/user/Report.aspx?url='+escape(location.href),'fav',500,200)\">" + paramValue + "</a>");
        }

        private string GetReviewList(int modelType, int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<script language='javascript'>");
            builder.AppendLine(string.Concat(new object[] { "var data = XmlHttpPostMethodText('", Param.ApplicationRootPath, "/sys_template/ReviewList.aspx','ModelType=", modelType, "&Id=", id, "');\r\n" }));
            builder.AppendLine("document.write(data)");
            builder.AppendLine("</script>");
            return builder.ToString();
        }

        public string GetRowIndex(int index)
        {
            return Convert.ToString((int)(index + 1));
        }

        private string GetRssLink(string paramStr, string propery, int id)
        {
            string paramValue = "RSS";
            string str2 = "false";
            this.GetParamValue(paramStr, "text", ref paramValue);
            this.GetParamValue(paramStr, "includesub", ref str2);
            if (propery.ToLower() == "chid")
            {
                return string.Format("<a href=\"{0}/Rss.aspx?{1}={2}\" target=\"_blank\">{3}</a>", new object[] { Param.ApplicationRootPath, propery, id, paramValue });
            }
            if (str2 == "false")
            {
                return string.Format("<a href=\"{0}/Rss.aspx?{1}={2}\" target=\"_blank\">{3}</a>", new object[] { Param.ApplicationRootPath, propery, id, paramValue });
            }
            return string.Format("<a href=\"{0}/Rss.aspx?{1}={2}&includsub=true\" target=\"_blank\">{3}</a>", new object[] { Param.ApplicationRootPath, propery, id, paramValue });
        }

        private string GetSearchForm()
        {
            return ("<script language=\"javascript\" src=\"" + Param.ApplicationRootPath + "/common/GetSearchForm.aspx\"></script>");
        }

        public string GetSinglePage(int singleId)
        {
            M_SinglePage model = new B_SinglePage().GetModel(singleId);
            string templatePath = Param.SiteRootPath + model.TemplatePath.Replace("/", @"\");
            StringBuilder fileContent = new StringBuilder(this.GetContentByReplaceSysJS(this.ReadTemplate(templatePath)));
            this.ReplaceLabelNameToContent(fileContent);
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                string newValue = string.Empty;
                if (match.Groups.Count > 1)
                {
                    switch (match.Groups[1].Value.Trim().ToLower())
                    {
                        case "my_pos":
                            newValue = this.GetCurrent_Pos(match.Value, "singlepage", singleId, "");
                            goto Label_0422;

                        case "ch_infolist":
                            newValue = this.Ch_GetInfoList(match.Value, 0);
                            goto Label_0422;

                        case "col_infolist":
                            newValue = this.Col_GetInfoList(match.Value, 0);
                            goto Label_0422;

                        case "ch_col_infolist":
                            newValue = this.Ch_Col_GetInfoList(match.Value, 0);
                            goto Label_0422;

                        case "col_childcol_infolist":
                            newValue = this.Col_ChildCol_GetInfoList(match.Value, 0);
                            goto Label_0422;

                        case "index_ch_nav":
                            newValue = this.Index_Ch_GetNav(match.Value);
                            goto Label_0422;

                        case "col_flashinfolist":
                            newValue = this.Col_GetFlashInfoList(match.Value, 0);
                            goto Label_0422;

                        case "page_info":
                            newValue = this.Index_GetPageInfo(match.Value);
                            goto Label_0422;

                        case "addfav":
                            newValue = this.GetAddFav(match.Value);
                            goto Label_0422;

                        case "report":
                            newValue = this.GetReport(match.Value);
                            goto Label_0422;

                        case "login":
                            newValue = this.GetLogin(match.Value);
                            goto Label_0422;

                        case "pvtotal":
                            newValue = this.GetPvTotal();
                            goto Label_0422;

                        case "article_txt_headerlist":
                            newValue = this.Article_Text_GetHeaderList(match.Value);
                            goto Label_0422;

                        case "article_img_headerlist":
                            newValue = this.Article_Img_GetHeaderList(match.Value);
                            goto Label_0422;

                        case "searchform":
                            newValue = this.GetSearchForm();
                            goto Label_0422;

                        case "sitename":
                            newValue = this.GetSiteName();
                            goto Label_0422;

                        case "domain":
                            newValue = this.GetDomainName();
                            goto Label_0422;

                        case "copyright":
                            newValue = this.GetCopyright();
                            goto Label_0422;

                        case "logo":
                            newValue = this.GetLogoAddress();
                            goto Label_0422;

                        case "banner":
                            newValue = this.GetBannerAddress();
                            goto Label_0422;

                        case "applicationpath":
                            newValue = this.GetApplicationPath();
                            goto Label_0422;

                        case "vote":
                            newValue = this.GetVote(match.Value);
                            goto Label_0422;

                        case "kylink":
                            newValue = this.GetLink(match.Value);
                            goto Label_0422;

                        case "infototal":
                            newValue = this.GetTotal();
                            goto Label_0422;
                    }
                    newValue = string.Empty;
                }
            Label_0422:
                fileContent.Replace(match.Value, newValue);
            }
            return fileContent.ToString();
        }

        private string GetSiteName()
        {
            return this.SiteModel.SiteName;
        }

        private string GetSpecailRemark(int spId)
        {
            M_Special special = this.SpecialBll.GetSpecial(spId);
            if (special == null)
            {
                return string.Empty;
            }
            return special.SpecialRemark;
        }

        private void GetSpecial_InfoListData(int spId, ref bool isPadding, ref string pageSize, ref int recordCount)
        {
            M_Special special = this.SpecialBll.GetSpecial(spId);
            string templatePath = Param.SiteRootPath + special.SpecialTemplet.Replace("/", @"\");
            StringBuilder fileContent = new StringBuilder(this.ReadTemplate(templatePath));
            this.ReplaceLabelNameToContent(fileContent);
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                if ((match.Groups.Count > 1) && (match.Groups[1].Value.Trim().ToLower() == "special_infolist"))
                {
                    this.GetParamValue(match.Value, "pagesize", ref pageSize);
                    recordCount = this.Get_SpecialInfoCount(match.Value, spId, ref isPadding);
                }
            }
        }

        private string GetSpecialCustomContent(string paramStr, int spId)
        {
            string paramValue = "1";
            this.GetParamValue(paramStr, "pos", ref paramValue);
            M_Special special = this.SpecialBll.GetSpecial(spId);
            if (special == null)
            {
                return string.Empty;
            }
            string[] strArray = special.SpecialContent.Split(new char[] { '|' });
            if (!(Ky.Common.Function.CheckNumber(paramValue) && (int.Parse(paramValue) <= strArray.Length)))
            {
                return string.Empty;
            }
            return strArray[int.Parse(paramValue) - 1];
        }

        private string GetSpecialImg(int spId)
        {
            M_Special special = this.SpecialBll.GetSpecial(spId);
            if (special == null)
            {
                return string.Empty;
            }
            return (Param.ApplicationRootPath + "/upload/special_img" + special.PicSavePath);
        }

        public string GetSpecialPage(int specialId, int pageIndex)
        {
            bool isPadding = false;
            M_Special special = this.SpecialBll.GetSpecial(specialId);
            string templatePath = Param.SiteRootPath + special.SpecialTemplet.Replace("/", @"\");
            StringBuilder fileContent = new StringBuilder(this.GetContentByReplaceSysJS(this.ReadTemplate(templatePath)));
            this.ReplaceLabelNameToContent(fileContent);
            MatchCollection paramId = this.GetParamId(fileContent.ToString());
            foreach (Match match in paramId)
            {
                string newValue = string.Empty;
                if (match.Groups.Count > 1)
                {
                    switch (match.Groups[1].Value.Trim().ToLower())
                    {
                        case "ch_infolist":
                            newValue = this.Ch_GetInfoList(match.Value, 0);
                            goto Label_0515;

                        case "col_infolist":
                            newValue = this.Col_GetInfoList(match.Value, 0);
                            goto Label_0515;

                        case "ch_col_infolist":
                            newValue = this.Ch_Col_GetInfoList(match.Value, 0);
                            goto Label_0515;

                        case "col_childcol_infolist":
                            newValue = this.Col_ChildCol_GetInfoList(match.Value, 0);
                            goto Label_0515;

                        case "special_infolist":
                            if (!isPadding)
                            {
                                int recordCount = this.Get_SpecialInfoCount(match.Value, specialId, ref isPadding);
                                newValue = this.Special_GetInfoList(match.Value, specialId, pageIndex, recordCount);
                                isPadding = true;
                            }
                            goto Label_0515;

                        case "index_ch_nav":
                            newValue = this.Index_Ch_GetNav(match.Value);
                            goto Label_0515;

                        case "col_flashinfolist":
                            newValue = this.Col_GetFlashInfoList(match.Value, 0);
                            goto Label_0515;

                        case "vote":
                            newValue = this.GetVote(match.Value);
                            goto Label_0515;

                        case "my_pos":
                            newValue = this.GetCurrent_Pos(match.Value, "special", specialId, "");
                            goto Label_0515;

                        case "addfav":
                            newValue = this.GetAddFav(match.Value);
                            goto Label_0515;

                        case "report":
                            newValue = this.GetReport(match.Value);
                            goto Label_0515;

                        case "login":
                            newValue = this.GetLogin(match.Value);
                            goto Label_0515;

                        case "pvtotal":
                            newValue = this.GetPvTotal();
                            goto Label_0515;

                        case "article_txt_headerlist":
                            newValue = this.Article_Text_GetHeaderList(match.Value);
                            goto Label_0515;

                        case "article_img_headerlist":
                            newValue = this.Article_Img_GetHeaderList(match.Value);
                            goto Label_0515;

                        case "searchform":
                            newValue = this.GetSearchForm();
                            goto Label_0515;

                        case "sitename":
                            newValue = this.GetSiteName();
                            goto Label_0515;

                        case "domain":
                            newValue = this.GetDomainName();
                            goto Label_0515;

                        case "copyright":
                            newValue = this.GetCopyright();
                            goto Label_0515;

                        case "logo":
                            newValue = this.GetLogoAddress();
                            goto Label_0515;

                        case "banner":
                            newValue = this.GetBannerAddress();
                            goto Label_0515;

                        case "applicationpath":
                            newValue = this.GetApplicationPath();
                            goto Label_0515;

                        case "specialimg":
                            newValue = this.GetSpecialImg(specialId);
                            goto Label_0515;

                        case "specialcontent":
                            newValue = this.GetSpecialCustomContent(match.Value, specialId);
                            goto Label_0515;

                        case "specialremark":
                            newValue = this.GetSpecailRemark(specialId);
                            goto Label_0515;

                        case "sp_nav":
                            newValue = this.GetSpNav(match.Value, specialId);
                            goto Label_0515;

                        case "kylink":
                            newValue = this.GetLink(match.Value);
                            goto Label_0515;

                        case "infototal":
                            newValue = this.GetTotal();
                            goto Label_0515;

                        case "index_sp_nav":
                            newValue = this.GetIndexSpNav(match.Value);
                            goto Label_0515;
                    }
                    newValue = this.GetIndex_Col_Nav(match.Value);
                }
            Label_0515:
                fileContent.Replace(match.Value, newValue);
            }
            return (fileContent.ToString() + "\r\n<!-- " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "签发-->");
        }

        public string GetSpecialPageNav(int currSpId, int pageIndex, int pageSize, int recordCount, int pageCount, string paddingStyle, string paddingCss)
        {
            int num4;
            int num5;
            string str11;
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            StringBuilder builder = new StringBuilder();
            int num = int.Parse(paddingStyle);
            string str = (paddingCss.Length == 0) ? " " : (" class=\"" + paddingCss + "\" ");
            builder.Append("<div id=\"pagenav\">");
            int num2 = pageIndex - 1;
            int num3 = pageIndex + 1;
            if (num2 < 1)
            {
                num2 = 1;
            }
            if (num3 > pageCount)
            {
                num3 = pageCount;
            }
            string[] strArray = null;
            string specialUrl = this.GetSpecialUrl(currSpId, 1);
            string str10 = string.Empty;
            switch (num)
            {
                case 2:
                    str10 = string.Format("<span{0}>{1}页/{2}篇</span>", str, pageIndex, recordCount);
                    builder.AppendLine(str10);
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "<font face=webdings>9</font>", str, specialUrl));
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "<font face=webdings>3</font>", str, this.GetSpecialUrl(currSpId, num2)));
                    strArray = Ky.Common.Function.GetPageNumStr(pageIndex, pageCount, 7).Split(new char[] { '|' });
                    for (num4 = 0; num4 < strArray.Length; num4++)
                    {
                        num5 = int.Parse(strArray[num4]);
                        str11 = this.GetSpecialUrl(currSpId, num5);
                        builder.AppendLine(this.GetCurrPageHTML(pageIndex, num5, str, str11));
                    }
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "<font face=webdings>4</font>", str, this.GetSpecialUrl(currSpId, num3)));
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "<font face=webdings>:</font>", str, this.GetSpecialUrl(currSpId, pageCount)));
                    builder.AppendLine(this.GetGoHTML(specialUrl, currSpId, pageCount, str));
                    break;

                case 3:
                    str10 = string.Format("<span{0}>共{1}篇内容</span>", str, recordCount);
                    builder.AppendLine(str10);
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "首页", str, specialUrl));
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "上一页", str, this.GetSpecialUrl(currSpId, num2)));
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "下一页", str, this.GetSpecialUrl(currSpId, num3)));
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, "尾页", str, this.GetSpecialUrl(currSpId, pageCount)));
                    builder.AppendLine(string.Format("<span{0}>{1}篇内容/页</span>", str, pageSize));
                    builder.AppendLine(this.GetGoHTML(specialUrl, currSpId, pageCount, str));
                    break;

                case 4:
                    strArray = Ky.Common.Function.GetPageNumStr(pageIndex, pageCount, 7).Split(new char[] { '|' });
                    num4 = 0;
                    while (num4 < strArray.Length)
                    {
                        num5 = int.Parse(strArray[num4]);
                        str11 = this.GetSpecialUrl(currSpId, num5);
                        builder.AppendLine(this.GetCurrPageHTML(pageIndex, num5, str, str11));
                        num4++;
                    }
                    break;

                default:
                    str10 = string.Format("<span{0}>共{1}/{2}页</span>", str, pageIndex, pageCount);
                    builder.AppendLine(str10);
                    builder.AppendLine(this.GetPrePageHTML(pageIndex, "<<", str, this.GetSpecialUrl(currSpId, num2)));
                    strArray = Ky.Common.Function.GetPageNumStr(pageIndex, pageCount, 7).Split(new char[] { '|' });
                    for (num4 = 0; num4 < strArray.Length; num4++)
                    {
                        num5 = int.Parse(strArray[num4]);
                        str11 = this.GetSpecialUrl(currSpId, num5);
                        builder.AppendLine(this.GetCurrPageHTML(pageIndex, num5, str, str11));
                    }
                    builder.AppendLine(this.GetNextPageHTML(pageIndex, pageCount, ">>", str, this.GetSpecialUrl(currSpId, num3)));
                    builder.AppendLine(this.GetGoHTML(specialUrl, currSpId, pageCount, str));
                    break;
            }
            builder.Append("</div>");
            return builder.ToString();
        }

        public string GetSpecialUrl(int specialId, int pageIndex)
        {
            M_Special special = this.SpecialBll.GetSpecial(specialId);
            if ((special.SpecialDomain != string.Empty) && (pageIndex == 1))
            {
                return special.SpecialDomain;
            }
            string str = string.Empty;
            int num = int.Parse(special.Extension);
            string str2 = string.Empty;
            switch (num)
            {
                case 2:
                    str2 = ".htm";
                    break;

                case 3:
                    str2 = ".shtml";
                    break;

                case 4:
                    str2 = ".aspx";
                    break;

                default:
                    str2 = ".html";
                    break;
            }
            if (!(this.SiteModel.IsStaticType && (num != 4)))
            {
                return ((pageIndex == 1) ? (this.HostAddress + "/Special.aspx?SpId=" + specialId) : string.Concat(new object[] { this.HostAddress, "/Special.aspx?SpId=", specialId, "&P=", pageIndex }));
            }
            switch (int.Parse(special.SaveDirType))
            {
                case 2:
                    str = "/special/" + special.SpecialEName + "/index";
                    break;

                case 3:
                    str = "/special/" + DateTime.Now.ToString("yyyy") + "/" + special.SpecialEName;
                    break;

                case 4:
                    str = "/special/" + DateTime.Now.ToString("yyyy") + "/" + special.SpecialEName + "/index";
                    break;

                default:
                    str = "/special/" + special.SpecialEName;
                    break;
            }
            if (pageIndex == 1)
            {
                return (this.HostAddress + str + str2);
            }
            return string.Concat(new object[] { this.HostAddress, str, "_", pageIndex, str2 });
        }

        private string GetSpNav(string paramStr, int currSpId)
        {
            string paramValue = "";
            string str2 = "";
            string str3 = "";
            string str4 = "10";
            string str5 = string.Empty;
            this.GetParamValue(paramStr, "navcss", ref paramValue);
            this.GetParamValue(paramStr, "arrange", ref str2);
            this.GetParamValue(paramStr, "compart", ref str3);
            this.GetParamValue(paramStr, "navcount", ref str4);
            this.GetParamValue(paramStr, "target", ref str5);
            DataView view = new DataView(this.SpecialBll.GetSpecialByParentId(currSpId));
            view.RowFilter = "islock=0";
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= view.Count; i++)
            {
                int specialId = (int)view[i - 1]["id"];
                string str6 = view[i - 1]["SpecialCName"].ToString();
                if (str2 == "true")
                {
                    if (((i % int.Parse(str4)) == 0) && (i != view.Count))
                    {
                        builder.Append("<a href='");
                        builder.Append(this.GetSpecialUrl(specialId, 1));
                        builder.Append("' target='");
                        builder.Append(str5);
                        builder.Append("' class='");
                        builder.Append(paramValue);
                        builder.Append("'>");
                        builder.Append(str6);
                        builder.Append("</a><br/>");
                    }
                    else if (i == view.Count)
                    {
                        builder.Append("<a href='");
                        builder.Append(this.GetSpecialUrl(specialId, 1));
                        builder.Append("' target='");
                        builder.Append(str5);
                        builder.Append("' class='");
                        builder.Append(paramValue);
                        builder.Append("'>");
                        builder.Append(str6);
                        builder.Append("</a>");
                    }
                    else
                    {
                        builder.Append("<a href='");
                        builder.Append(this.GetSpecialUrl(specialId, 1));
                        builder.Append("' target='");
                        builder.Append(str5);
                        builder.Append("' class='");
                        builder.Append(paramValue);
                        builder.Append("'>");
                        builder.Append(str6);
                        builder.Append("</a>");
                        builder.Append(str3);
                    }
                }
                else
                {
                    builder.Append(str3);
                    builder.Append("<a href='");
                    builder.Append(this.GetSpecialUrl(specialId, 1));
                    builder.Append("' target='");
                    builder.Append(str5);
                    builder.Append("' class='");
                    builder.Append(paramValue);
                    builder.Append("'>");
                    builder.Append(str6);
                    builder.Append("</a><br/>");
                }
            }
            return builder.ToString();
        }

        protected void GetStyle(string[] content)
        {
            Match match = Regex.Match(this.SqlContent, @"((?:.|\n)*?)<ky_loop>((?:.|\n)*?)</ky_loop>((?:.|\n)*)", RegexOptions.IgnoreCase);
            for (int i = 0; i < 3; i++)
            {
                content[i] = match.Groups[i + 1].Value;
            }
        }

        protected void GetStyleColumns(string[] content)
        {
            Match match = Regex.Match(this.ColumnsContent, @"((?:.|\n)*?)<ky_loop_columns>((?:.|\n)*?)</ky_loop_columns>((?:.|\n)*)", RegexOptions.IgnoreCase);
            for (int i = 0; i < 3; i++)
            {
                content[i] = match.Groups[i + 1].Value;
            }
        }

        private string GetStyleContent(int styleId)
        {
            if (!this.styleCache.Contains(styleId))
            {
                string styleContent = new B_Style().GetStyleContent(styleId);
                this.styleCache.Add(styleId, styleContent);
            }
            return this.styleCache[styleId].ToString();
        }

        public MatchCollection GetStyleFileldName(string styleContent)
        {
            return Regex.Matches(styleContent, "{Ky_(.*?)}", RegexOptions.IgnoreCase);
        }

        public string GetSuperLabel(string Name, int UserId)
        {
            object obj2;
            string str = "";
            B_SuperLabel label = new B_SuperLabel();
            M_SuperLabel model = new M_SuperLabel();
            int superId = label.GetSuperId(Name);
            model = label.GetModel(superId);
            if (superId == 0)
            {
                return "该超级标签名称出错!";
            }
            if ((model.DataBaseType == 1) || (model.DataBaseType == 3))
            {
                if (model.IsHtml)
                {
                    string sqlStr = model.SqlStr;
                    MatchCollection matchs = Regex.Matches(sqlStr, "{#(.*?)}", RegexOptions.IgnoreCase);
                    if (matchs.Count > 0)
                    {
                        DataRow userAllInfo = new B_User().GetUserAllInfo(UserId);
                        foreach (Match match in matchs)
                        {
                            sqlStr = sqlStr.Replace("{#" + match.Groups[1].Value + "}", userAllInfo["" + match.Groups[1].Value + ""].ToString());
                        }
                    }
                    DataTable table = new DataTable();
                    if (model.DataBaseType == 3)
                    {
                        table = label.DataBaseTypeSql(model.DataBaseConn, model.DataBaseType.ToString(), sqlStr);
                    }
                    else
                    {
                        table = label.CheckSql(sqlStr);
                    }
                    this.SqlContent = model.Content;
                    this.MySqlContent = new string[3];
                    this.GetStyle(this.MySqlContent);
                    this.ColumnsContent = this.MySqlContent[1];
                    this.MyColumnsContent = new string[3];
                    this.GetStyleColumns(this.MyColumnsContent);
                    int numColumns = model.NumColumns;
                    int num4 = table.Rows.Count / numColumns;
                    str = str + this.MySqlContent[0];
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if ((this.MySqlContent[1].Trim().ToLower().IndexOf("<ky_loop_columns>") > 0) && (this.MySqlContent[1].Trim().ToLower().IndexOf("</ky_loop_columns>") > 0))
                        {
                            str = str + this.MyColumnsContent[0];
                            int num6 = 0;
                            while (num6 < model.NumColumns)
                            {
                                if (i == table.Rows.Count)
                                {
                                    str = str + this.MyColumnsContent[0] + this.MyColumnsContent[2];
                                }
                                else
                                {
                                    str = str + "" + this.StrValue(table.Rows[i], model.HostTable, this.MyColumnsContent[1]) + "";
                                }
                                num6++;
                                i++;
                            }
                            str = str + this.MyColumnsContent[2];
                        }
                        else
                        {
                            str = str + "" + this.StrValue(table.Rows[i], model.HostTable, this.MySqlContent[1]) + "";
                        }
                    }
                    str = str + this.MySqlContent[2];
                }
                else
                {
                    obj2 = str + "<!---" + Name.Replace("{Ky_S_", "").Replace("}", "") + "超级标签开始-->";
                    obj2 = string.Concat(new object[] { obj2, "<div id='SuperLabel_Div_", superId, "'></div>" });
                    str = string.Concat(new object[] { obj2, "<script language=\"javascript\">var data = XmlHttpPostMethodText(\"", Param.ApplicationRootPath, "/common/SuperLabelList.aspx?SuperId=", superId, "&UserId=", UserId, "\",\"\");document.getElementById('SuperLabel_Div_", superId, "').innerHTML=data;</script>" }) + "<!---" + Name.Replace("{Ky_S_", "").Replace("}", "") + "超级标签结束-->";
                }
            }
            if (model.DataBaseType != 2)
            {
                return str;
            }
            if (model.IsHtml)
            {
                try
                {
                    WebClient client = new WebClient();
                    client.Encoding = Encoding.GetEncoding("utf-8");
                    byte[] bytes = client.DownloadData("" + model.SqlStr + "");
                    return Encoding.GetEncoding("utf-8").GetString(bytes);
                }
                catch
                {
                    return "读取外部数据错误";
                }
            }
            obj2 = str + "<!---" + Name.Replace("{Ky_S_", "").Replace("}", "") + "超级标签开始-->";
            obj2 = string.Concat(new object[] { obj2, "<div id='SuperLabel_Div_", superId, "'></div>" });
            return (string.Concat(new object[] { obj2, "<script language=\"javascript\">var data = XmlHttpPostMethodText(\"", model.SqlStr, "\",\"\");document.getElementById('SuperLabel_Div_", superId, "').innerHTML=data;</script>" }) + "<!---" + Name.Replace("{Ky_S_", "").Replace("}", "") + "超级标签结束-->");
        }

        private string GetSystemJS()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<script language='javascript' src='" + Param.ApplicationRootPath + "/js/Page.js'></script>");
            builder.AppendLine("<script language='javascript' src='" + Param.ApplicationRootPath + "/js/Xmlhttp.js'></script>");
            return builder.ToString();
        }

        private string GetTableName(int modelId)
        {
            DataTable modelAll = this.GetModelAll();
            DataRow[] rowArray = modelAll.Select("modelid=" + modelId);
            if ((rowArray != null) && (rowArray.Length > 0))
            {
                string str = rowArray[0]["tablename"].ToString();
                modelAll.Dispose();
                return str;
            }
            return string.Empty;
        }

        private string GetTotal()
        {
            StringBuilder builder = new StringBuilder();
            DataView list = this.ChannelBll.GetList(false);
            list.RowFilter = "isdeleted=0 and isdisabled=0";
            for (int i = 0; i < list.Count; i++)
            {
                int chId = (int)list[i]["chid"];
                string str = list[i]["chname"].ToString();
                int modelId = (int)list[i]["modeltype"];
                string str2 = list[i]["typeUnit"].ToString();
                string tableName = this.GetTableName(modelId);
                if (tableName == string.Empty)
                {
                    return string.Empty;
                }
                int recordCount = 0;
                this.InfoOperBll.GetInfoList(tableName, "", "", chId, "0", "-99", "", "", "", -1, 1, 1, ref recordCount);
                builder.Append(string.Format("{0}：{1}{2}<br/>", str, recordCount, str2));
            }
            list.Dispose();
            int userCount = new B_User().GetUserCount(0, 0);
            builder.Append(string.Format("会员总计：{0}个<br/>", userCount));
            return builder.ToString();
        }

        public string GetTypeStr(string property1, int chId, string property2)
        {
            string[] strArray;
            string[] strArray2;
            string str3;
            string str4;
            StringBuilder builder = new StringBuilder();
            string str = string.Empty;
            if (property1.Trim() != string.Empty)
            {
                strArray = property1.Split(new char[] { '|' });
                foreach (string str2 in strArray)
                {
                    strArray2 = str2.Split(new char[] { '$' });
                    str3 = strArray2[0];
                    str4 = strArray2[1];
                    if (str3.Trim() == "ishot")
                    {
                        M_Channel channel = this.ChannelBll.GetChannel(chId);
                        if (channel != null)
                        {
                            builder.Append(str);
                            builder.Append("(");
                            builder.Append(" i.[hitcount]>='" + channel.MiniHitCount + "' ");
                            builder.Append(")");
                            str = " and ";
                        }
                    }
                    else
                    {
                        builder.Append(str);
                        builder.Append("(");
                        builder.Append(" i.[" + strArray2[0] + "]='" + strArray2[1] + "' ");
                        str = " and ";
                        builder.Append(")");
                    }
                }
            }
            string str5 = builder.ToString();
            builder.Remove(0, builder.Length);
            if (property2.Trim() != string.Empty)
            {
                string[] strArray3 = property2.Split(new char[] { '#' });
                foreach (string str6 in strArray3)
                {
                    builder.Append(str);
                    builder.Append("(");
                    strArray = str6.Split(new char[] { '|' });
                    string str7 = string.Empty;
                    foreach (string str2 in strArray)
                    {
                        strArray2 = str2.Split(new char[] { '$' });
                        str3 = strArray2[0];
                        str4 = strArray2[1];
                        builder.Append(str7);
                        builder.Append(" i.[" + strArray2[0] + "]='" + strArray2[1] + "' ");
                        str7 = " or ";
                    }
                    builder.Append(")");
                    str = " and ";
                }
            }
            string str8 = builder.ToString();
            builder = null;
            return (str5 + str8);
        }

        private int GetUserFieldType(int modelId, string fieldName)
        {
            if (this.UserFieldCache != null)
            {
                DataRow[] rowArray = this.UserFieldCache.Select(string.Format("modelid={0}", modelId));
                if ((rowArray == null) || (rowArray.Length == 0))
                {
                    this.UserFieldCache = null;
                }
            }
            if (this.UserFieldCache == null)
            {
                this.UserFieldCache = this.UserGroupModelBll.GetTextType(modelId);
            }
            DataRow[] rowArray2 = this.UserFieldCache.Select(string.Format("modelid={0} and [name]='{1}'", modelId, fieldName));
            if ((rowArray2 == null) || (rowArray2.Length == 0))
            {
                return 0;
            }
            return 1;
        }

        private string GetViewTotal(int id, int modelId)
        {
            return string.Concat(new object[] { "<script language='javascript' src='", Param.ApplicationRootPath, "/common/InfoViewCount.aspx?ModelId=", modelId, "&&Id=", id, "'></script>\r\n" });
        }

        public string GetVote(string paramStr)
        {
            string paramValue = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            this.GetParamValue(paramStr, "arrange", ref paramValue);
            this.GetParamValue(paramStr, "votesubjectid", ref str2);
            this.GetParamValue(paramStr, "topicstyle", ref str3);
            this.GetParamValue(paramStr, "optionstyle", ref str4);
            DataTable subject = new B_Vote().GetSubject(int.Parse(str2));
            int count = subject.Rows.Count;
            int num2 = 0;
            string str5 = "";
            string str6 = "";
            string str7 = "";
            if (paramValue == "horizontal")
            {
                str7 = "style=\"float:left;\"";
            }
            if (subject.Rows.Count <= 0)
            {
                return str6;
            }
            foreach (DataRow row in subject.Rows)
            {
                string str8;
                if (num2 == 0)
                {
                    if (row["isMore"].ToString() == "False")
                    {
                        str8 = "radio";
                    }
                    else
                    {
                        str8 = "CheckBox";
                    }
                    str6 = str6 + "<br>\r\n<form action=\"" + Param.ApplicationRootPath + "/common/SetVote.aspx\" method=\"post\" ><div " + str7 + "><table>\r\n";
                    str6 = string.Concat(new object[] { str6, "<tr><td class=\"", str3, "\">", row["VoteTitle"], "</td></tr>\r\n" });
                    if (row["ItemTitle1"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum1\">", row["ItemTitle1"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle2"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum2\">", row["ItemTitle2"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle3"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum3\">", row["ItemTitle3"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle4"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum4\">", row["ItemTitle4"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle5"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum5\">", row["ItemTitle5"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle6"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum6\">", row["ItemTitle6"], "</td></tr>\r\n" });
                    }
                    str6 = str6 + "</table></div>\r\n";
                    str5 = str5 + row["VoteId"].ToString() + ",";
                }
                else
                {
                    if (row["isMore"].ToString() == "False")
                    {
                        str8 = "radio";
                    }
                    else
                    {
                        str8 = "CheckBox";
                    }
                    str6 = str6 + "<div " + str7 + "><table>\r\n";
                    str6 = string.Concat(new object[] { str6, "<tr><td class=\"", str3, "\">", row["VoteTitle"], "</td></tr>\r\n" });
                    if (row["ItemTitle1"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum1\">", row["ItemTitle1"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle2"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum2\">", row["ItemTitle2"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle3"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum3\">", row["ItemTitle3"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle4"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum4\">", row["ItemTitle4"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle5"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum5\">", row["ItemTitle5"], "</td></tr>\r\n" });
                    }
                    if (row["ItemTitle6"].ToString() != "")
                    {
                        str6 = string.Concat(new object[] { str6, "<tr class=\"", str4, "\"><td><input type=", str8, " name=\"", row["VoteId"], "vote\" value=\"ItemNum6\">", row["ItemTitle6"], "</td></tr>\r\n" });
                    }
                    str6 = str6 + "</table></div>\r\n";
                    str5 = str5 + row["VoteId"].ToString() + ",";
                }
                num2++;
            }
            return (str6 + "<div style=\"clear:both;\"><table><tr><td><input type=\"hidden\" value=\"subject" + str2 + "\" name=\"subjectflagl\"><input type=\"hidden\" value=\"" + str5 + "\" name=\"hidvoteIdAll\"> <input type=\"submit\" value=\"投票\"> &nbsp;<input type=\"button\" value=\"查看\" onclick=\"javascript:window.location.href='" + Param.ApplicationRootPath + "/common/ViewVote.aspx?vid=" + str2 + "' \"></td></tr></table></div></form>");
        }

        private string Index_Ch_GetNav(string paramStr)
        {
            string paramValue = "";
            string str2 = "";
            string str3 = "";
            string str4 = "10";
            string str5 = "";
            this.GetParamValue(paramStr, "navcss", ref paramValue);
            this.GetParamValue(paramStr, "arrange", ref str2);
            this.GetParamValue(paramStr, "compart", ref str3);
            this.GetParamValue(paramStr, "navcount", ref str4);
            this.GetParamValue(paramStr, "target", ref str5);
            DataTable table = this.ChannelBll.GetList(false).ToTable();
            DataView view = new DataView(table);
            view.RowFilter = "isdisabled=0";
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= view.Count; i++)
            {
                int chId = (int)view[i - 1]["chid"];
                string str6 = view[i - 1]["content"].ToString();
                string str7 = view[i - 1]["chname"].ToString();
                if (str2 == "true")
                {
                    if (((i % int.Parse(str4)) == 0) && (i != view.Count))
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a><br/>", new object[] { this.GetChannelUrl(chId), str5, str6, paramValue, str7 }));
                    }
                    else if (i == view.Count)
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a>", new object[] { this.GetChannelUrl(chId), str5, str6, paramValue, str7 }));
                    }
                    else
                    {
                        builder.Append(string.Format("<a href=\"{0}\" target=\"{1}\" title=\"{2}\" class=\"{3}\">{4}</a>{5}", new object[] { this.GetChannelUrl(chId), str5, str6, paramValue, str7, str3 }));
                    }
                }
                else
                {
                    builder.Append(string.Format("{0}<a href=\"{1}\" target=\"{2}\" title=\"{3}\" class=\"{4}\">{5}</a></br>", new object[] { str3, this.GetChannelUrl(chId), str5, str6, paramValue, str7 }));
                }
            }
            table.Dispose();
            view.Dispose();
            return builder.ToString();
        }

        private string Index_GetPageInfo(string paramStr)
        {
            string paramValue = "0";
            this.GetParamValue(paramStr, "type", ref paramValue);
            switch (paramValue)
            {
                case "1":
                    return this.SiteModel.SiteName;

                case "2":
                    return this.SiteModel.Keyword;

                case "3":
                    return this.SiteModel.KeyContent;
            }
            return string.Empty;
        }

        public string Info(string paramStr, DataRow dr, int pageId, int PageSize)
        {
            int num3;
            string paramValue = "";
            string input = "";
            string str3 = "yyyy-mm-dd";
            string newValue = "";
            string infoCloseUrl = "";
            string infoCloseName = "";
            string str7 = "";
            this.GetParamValue(paramStr, "style", ref paramValue);
            this.GetParamValue(paramStr, "dateformat", ref str3);
            input = this.GetStyleContent(int.Parse(paramValue));
            ArrayList list = new ArrayList();
            Match match = Regex.Match(input, @"((?:.|\n)*?)<ky_hidden>((?:.|\n)*?)</ky_hidden>((?:.|\n)*)", RegexOptions.IgnoreCase);
            int num = int.Parse(dr["pointcount"].ToString());
            int num2 = int.Parse(dr["id"].ToString());
            string str8 = dr["tablename"].ToString();
            if (match.Success)
            {
                for (num3 = 1; num3 < match.Groups.Count; num3++)
                {
                    list.Add(match.Groups[num3].Value);
                }
            }
            else
            {
                list.Add(input);
            }
            string str9 = string.Empty;
            for (num3 = 0; num3 < list.Count; num3++)
            {
                MatchCollection matchs;
                string str10;
                string str11;
                string str12;
                if (num3 == 1)
                {
                    if (num > 0)
                    {
                        input = string.Format("<script language=\"javascript\">GetHiddenContent(\"{0}\",\"{1}\",{2},{3},{4},\"{5}\")</script>", new object[] { Param.ApplicationRootPath + "/common/GetHiddenContent.aspx", Ky.Common.Function.UrlEncode(paramStr), num2, pageId, PageSize, str8 });
                        str9 = str9 + input;
                    }
                    else
                    {
                        Match match2 = Regex.Match(list[num3].ToString(), @"<ky_pay>((?:.|\n)*?)</ky_pay>", RegexOptions.IgnoreCase);
                        if (match2.Success)
                        {
                            input = match2.Groups[1].Value;
                            goto Label_0207;
                        }
                    }
                    continue;
                }
                input = list[num3].ToString();
            Label_0207:
                matchs = Regex.Matches(input, "{ky_user_(.*?)}", RegexOptions.IgnoreCase);
                if (matchs.Count > 0)
                {
                    int num4 = int.Parse(dr["usertype"].ToString());
                    int userId = int.Parse(dr["uid"].ToString());
                    if (num4 == 0)
                    {
                        DataRow userAllInfo = new B_User().GetUserAllInfo(userId);
                        foreach (Match match3 in matchs)
                        {
                            str10 = match3.Groups[1].Value.Trim().ToLower();
                            str11 = string.Empty;
                            str12 = string.Empty;
                            Match match4 = Regex.Match(str10, @"(.*?)#(.*?)\((.*?)\)");
                            if (match4.Success)
                            {
                                str10 = match4.Groups[1].Value;
                                str11 = match4.Groups[2].Value;
                                str12 = match4.Groups[3].Value;
                            }
                            string fiedName = str10;
                            if (userAllInfo == null)
                            {
                                input = input.Replace(match3.Value, "");
                            }
                            else
                            {
                                input = input.Replace(match3.Value, this.GetCommonFiled(userAllInfo, fiedName, str11, str12));
                            }
                        }
                    }
                }
                MatchCollection styleFileldName = this.GetStyleFileldName(input);
                DataTable table = this.CreateDataTable();
                DataTable table2 = this.CreateDataTable1();
                int modelId = (int)dr["modelid"];
                foreach (Match match5 in styleFileldName)
                {
                    string fieldName = string.Empty;
                    if (match5.Groups.Count > 1)
                    {
                        fieldName = match5.Groups[1].Value.ToLower();
                    }
                    else
                    {
                        return string.Empty;
                    }
                    str10 = fieldName;
                    str11 = string.Empty;
                    str12 = string.Empty;
                    Match match6 = Regex.Match(str10, @"(.*?)#(.*?)\((.*?)\)");
                    if (match6.Success)
                    {
                        str10 = match6.Groups[1].Value;
                        str11 = match6.Groups[2].Value;
                        str12 = match6.Groups[3].Value;
                    }
                    switch (str10)
                    {
                        case "content":
                            if ((modelId != 1) && (modelId != 2))
                            {
                                break;
                            }
                            input = input.Replace(match5.Value, this.GetPageIndexContent(dr, pageId));
                            goto Label_095C;

                        case "hitcount":
                            input = input.Replace(match5.Value, this.GetInfoHitCount(dr));
                            goto Label_095C;

                        case "title":
                            input = input.Replace(match5.Value, this.GetInfoTitle(dr, 0));
                            goto Label_095C;

                        case "tagnamestr":
                            input = input.Replace(match5.Value, this.GetInfoTagNameStr(dr, false));
                            goto Label_095C;

                        case "pre":
                            newValue = this.GetInfoCloseName(dr, "pre");
                            input = input.Replace(match5.Value, newValue);
                            goto Label_095C;

                        case "preurl":
                            infoCloseUrl = this.GetInfoCloseUrl(dr, "pre");
                            input = input.Replace(match5.Value, infoCloseUrl);
                            goto Label_095C;

                        case "next":
                            infoCloseName = this.GetInfoCloseName(dr, "next");
                            input = input.Replace(match5.Value, infoCloseName);
                            goto Label_095C;

                        case "nexturl":
                            str7 = this.GetInfoCloseUrl(dr, "next");
                            input = input.Replace(match5.Value, str7);
                            goto Label_095C;

                        case "titleimgpath":
                            input = input.Replace(match5.Value, this.GetInfoTitleImg(dr));
                            goto Label_095C;

                        case "imgpath":
                            if (modelId != 2)
                            {
                                goto Label_076A;
                            }
                            input = input.Replace(match5.Value, this.GetImgPath(dr, pageId));
                            goto Label_095C;

                        case "addresspath":
                            if (modelId != 3)
                            {
                                goto Label_07B3;
                            }
                            input = input.Replace(match5.Value, this.GetAddress(dr));
                            goto Label_095C;

                        case "downloaddownnum":
                            if (modelId != 3)
                            {
                                goto Label_07FD;
                            }
                            input = input.Replace(match5.Value, this.GetDownCount(dr, 1));
                            goto Label_095C;

                        case "downloaddownmonthnum":
                            if (modelId != 3)
                            {
                                goto Label_0847;
                            }
                            input = input.Replace(match5.Value, this.GetDownCount(dr, 2));
                            goto Label_095C;

                        case "downloaddownweeknum":
                            if (modelId != 3)
                            {
                                goto Label_0891;
                            }
                            input = input.Replace(match5.Value, this.GetDownCount(dr, 3));
                            goto Label_095C;

                        case "downloaddowndaynum":
                            if (modelId != 3)
                            {
                                goto Label_08DB;
                            }
                            input = input.Replace(match5.Value, this.GetDownCount(dr, 4));
                            goto Label_095C;

                        case "addtime":
                            input = input.Replace(match5.Value, this.GetDateTime(dr, str3));
                            goto Label_095C;

                        case "dig":
                            input = input.Replace(match5.Value, this.GetDig("", (int)dr["id"], modelId));
                            goto Label_095C;

                        default:
                            input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                            goto Label_095C;
                    }
                    input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                    goto Label_095C;
                Label_076A:
                    input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                    goto Label_095C;
                Label_07B3:
                    input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                    goto Label_095C;
                Label_07FD:
                    input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                    goto Label_095C;
                Label_0847:
                    input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                    goto Label_095C;
                Label_0891:
                    input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                    goto Label_095C;
                Label_08DB:
                    input = input.Replace(match5.Value, this.GetCommonFieldForInfo(dr, fieldName, str11, str12));
                Label_095C: ;
                }
                str9 = str9 + input;
            }
            return str9;
        }

        public string Info_Ajax(string paramStr, DataRow dr, int pageIndex, int pageCount, int pos)
        {
            Match match;
            string str9;
            string str10;
            string str11;
            string paramValue = "";
            string input = "";
            string str3 = "yyyy-mm-dd";
            string newValue = "";
            string infoCloseUrl = "";
            string infoCloseName = "";
            string str7 = "";
            this.GetParamValue(paramStr, "style", ref paramValue);
            this.GetParamValue(paramStr, "dateformat", ref str3);
            input = this.GetStyleContent(int.Parse(paramValue));
            if (pos == 0)
            {
                match = Regex.Match(input, @"<ky_hidden>(?:.|\n)*<ky_no_login>((?:.|\n)*?)</ky_no_login>(?:.|\n)*</ky_hidden>", RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return string.Empty;
                }
                input = match.Groups[1].Value;
            }
            else if (pos == 1)
            {
                match = Regex.Match(input, @"<ky_hidden>(?:.|\n)*<ky_no_pay>((?:.|\n)*?)</ky_no_pay>(?:.|\n)*</ky_hidden>", RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return string.Empty;
                }
                input = match.Groups[1].Value;
                string replacement = string.Concat(new object[] { Param.ApplicationRootPath, "/common/dofee.aspx?modelid=", dr["modelid"], "&infoid=", dr["id"] });
                input = Regex.Replace(match.Groups[1].Value, "{@feeurl}", replacement);
            }
            else if (pos == 2)
            {
                match = Regex.Match(input, @"<ky_hidden>(?:.|\n)*<ky_pay>((?:.|\n)*?)</ky_pay>(?:.|\n)*</ky_hidden>", RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return string.Empty;
                }
                input = match.Groups[1].Value;
            }
            else
            {
                return string.Empty;
            }
            MatchCollection matchs = Regex.Matches(input, "{ky_user_(.*?)}", RegexOptions.IgnoreCase);
            if (matchs.Count > 0)
            {
                int num = int.Parse(dr["usertype"].ToString());
                int userId = int.Parse(dr["uid"].ToString());
                if (num == 0)
                {
                    DataRow userAllInfo = new B_User().GetUserAllInfo(userId);
                    foreach (Match match2 in matchs)
                    {
                        str9 = match2.Groups[1].Value.Trim().ToLower();
                        str10 = string.Empty;
                        str11 = string.Empty;
                        Match match3 = Regex.Match(str9, @"(.*?)#(.*?)\((.*?)\)");
                        if (match3.Success)
                        {
                            str9 = match3.Groups[1].Value;
                            str10 = match3.Groups[2].Value;
                            str11 = match3.Groups[3].Value;
                        }
                        string fieldName = str9;
                        if (userAllInfo == null)
                        {
                            input = input.Replace(match2.Value, "");
                        }
                        else
                        {
                            input = input.Replace(match2.Value, this.GetCommonFieldForUserInfo(userAllInfo, fieldName, str10, str11));
                        }
                    }
                }
            }
            MatchCollection styleFileldName = this.GetStyleFileldName(input);
            DataTable table = this.CreateDataTable();
            DataTable table2 = this.CreateDataTable1();
            int modelId = (int)dr["modelid"];
            foreach (Match match4 in styleFileldName)
            {
                string str13 = string.Empty;
                if (match4.Groups.Count > 1)
                {
                    str13 = match4.Groups[1].Value.ToLower();
                }
                else
                {
                    return string.Empty;
                }
                str9 = str13;
                str10 = string.Empty;
                str11 = string.Empty;
                Match match5 = Regex.Match(str9, @"(.*?)#(.*?)\((.*?)\)");
                if (match5.Success)
                {
                    str9 = match5.Groups[1].Value;
                    str10 = match5.Groups[2].Value;
                    str11 = match5.Groups[3].Value;
                }
                switch (str9)
                {
                    case "content":
                        if ((modelId != 1) && (modelId != 2))
                        {
                            break;
                        }
                        input = input.Replace(match4.Value, this.GetPageIndexContent(dr, pageIndex));
                        goto Label_0929;

                    case "hitcount":
                        input = input.Replace(match4.Value, this.GetInfoHitCount(dr));
                        goto Label_0929;

                    case "title":
                        input = input.Replace(match4.Value, this.GetInfoTitle(dr, 0));
                        goto Label_0929;

                    case "tagnamestr":
                        input = input.Replace(match4.Value, this.GetInfoTagNameStr(dr, false));
                        goto Label_0929;

                    case "pre":
                        newValue = this.GetInfoCloseName(dr, "pre");
                        input = input.Replace(match4.Value, newValue);
                        goto Label_0929;

                    case "preurl":
                        infoCloseUrl = this.GetInfoCloseUrl(dr, "pre");
                        input = input.Replace(match4.Value, infoCloseUrl);
                        goto Label_0929;

                    case "next":
                        infoCloseName = this.GetInfoCloseName(dr, "next");
                        input = input.Replace(match4.Value, infoCloseName);
                        goto Label_0929;

                    case "nexturl":
                        str7 = this.GetInfoCloseUrl(dr, "next");
                        input = input.Replace(match4.Value, str7);
                        goto Label_0929;

                    case "titleimgpath":
                        input = input.Replace(match4.Value, this.GetInfoTitleImg(dr));
                        goto Label_0929;

                    case "imgpath":
                        if (modelId != 2)
                        {
                            goto Label_0737;
                        }
                        input = input.Replace(match4.Value, this.GetImgPath(dr, pageIndex));
                        goto Label_0929;

                    case "addresspath":
                        if (modelId != 3)
                        {
                            goto Label_0780;
                        }
                        input = input.Replace(match4.Value, this.GetAddress(dr));
                        goto Label_0929;

                    case "downloaddownnum":
                        if (modelId != 3)
                        {
                            goto Label_07CA;
                        }
                        input = input.Replace(match4.Value, this.GetDownCount(dr, 1));
                        goto Label_0929;

                    case "downloaddownmonthnum":
                        if (modelId != 3)
                        {
                            goto Label_0814;
                        }
                        input = input.Replace(match4.Value, this.GetDownCount(dr, 2));
                        goto Label_0929;

                    case "downloaddownweeknum":
                        if (modelId != 3)
                        {
                            goto Label_085E;
                        }
                        input = input.Replace(match4.Value, this.GetDownCount(dr, 3));
                        goto Label_0929;

                    case "downloaddowndaynum":
                        if (modelId != 3)
                        {
                            goto Label_08A8;
                        }
                        input = input.Replace(match4.Value, this.GetDownCount(dr, 4));
                        goto Label_0929;

                    case "addtime":
                        input = input.Replace(match4.Value, this.GetDateTime(dr, str3));
                        goto Label_0929;

                    case "dig":
                        input = input.Replace(match4.Value, this.GetDig("", (int)dr["id"], modelId));
                        goto Label_0929;

                    default:
                        input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
                        goto Label_0929;
                }
                input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
                goto Label_0929;
            Label_0737:
                input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
                goto Label_0929;
            Label_0780:
                input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
                goto Label_0929;
            Label_07CA:
                input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
                goto Label_0929;
            Label_0814:
                input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
                goto Label_0929;
            Label_085E:
                input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
                goto Label_0929;
            Label_08A8:
                input = input.Replace(match4.Value, this.GetCommonFieldForInfo(dr, str13, str10, str11));
            Label_0929: ;
            }
            return input;
        }

        private string Info_GetPageInfo(string tableName, int id)
        {
            DataRow info = this.InfoOperBll.GetInfo(tableName, id);
            if (info != null)
            {
                return info["title"].ToString();
            }
            return string.Empty;
        }

        private string Info_GetRelationInfoList(string paramStr, string tableName, string tagIdStr)
        {
            int num;
            string paramValue = "0";
            string str2 = "5";
            string str3 = "yyyy-mm-dd";
            string str4 = "30";
            this.GetParamValue(paramStr, "liststyle", ref paramValue);
            this.GetParamValue(paramStr, "infocount", ref str2);
            this.GetParamValue(paramStr, "dateformat", ref str3);
            this.GetParamValue(paramStr, "titlelength", ref str4);
            if (((tagIdStr.Length > 0) && tagIdStr.StartsWith("|")) && tagIdStr.EndsWith("|"))
            {
                tagIdStr = tagIdStr.Substring(0, tagIdStr.Length - 1);
                tagIdStr = tagIdStr.Substring(1, tagIdStr.Length - 1);
            }
            if (tagIdStr.Length == 0)
            {
                return string.Empty;
            }
            string[] strArray = tagIdStr.Split(new char[] { '|' });
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < strArray.Length; num++)
            {
                if (num == 0)
                {
                    builder.Append(" and (");
                }
                builder.Append("i.[tagidstr] Like '%|" + strArray[num] + "|%'");
                if (num != (strArray.Length - 1))
                {
                    builder.Append(" or ");
                }
                else
                {
                    builder.Append(") ");
                }
            }
            DataTable table = this.dal.GetInfo_RelationInfoList(tableName, int.Parse(str2), builder.ToString());
            string styleContent = this.GetStyleContent(int.Parse(paramValue));
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            StringBuilder builder2 = new StringBuilder();
            for (num = 0; num < table.Rows.Count; num++)
            {
                DataRow dr = table.Rows[num];
                StringBuilder sb = new StringBuilder(styleContent);
                this.GetListStyleHTML(styleFileldName, sb, dr, int.Parse(str4), str3, num);
                builder2.AppendLine(sb.ToString());
            }
            table.Dispose();
            return builder2.ToString();
        }

        public void InfoRecordCount(string tableName, string wheStr, ref int recordCount)
        {
            this.dal.InfoRecordCount(tableName, wheStr, ref recordCount);
        }

        public int LastInfoCount(string tableName, int topNum)
        {
            return this.dal.LastInfoCount(tableName, topNum);
        }

        private string NewsFileName(DataRow dr)
        {
            M_Channel channel = new M_Channel();
            channel = this.ChannelBll.GetChannel(int.Parse(dr["ChId"].ToString()));
            string str = "";
            if (channel.FileNameType == 1)
            {
                str = "";
            }
            else
            {
                DateTime time;
                if (channel.FileNameType == 2)
                {
                    time = (DateTime)dr["AddTime"];
                    str = time.ToString("yyyyMM");
                }
                else if (channel.FileNameType == 3)
                {
                    time = (DateTime)dr["AddTime"];
                    str = time.ToString("yyyyMMdd");
                }
                else if (channel.FileNameType == 4)
                {
                    str = dr["DirName"].ToString() + "_";
                }
                else if (channel.FileNameType == 5)
                {
                    str = dr["DirName"].ToString() + "_" + ((DateTime)dr["AddTime"]).ToString("yyyyMMdd");
                }
            }
            string str2 = dr["PageType"].ToString();
            string str4 = str2;
            if (str4 != null)
            {
                if (!(str4 == "1"))
                {
                    if (str4 == "2")
                    {
                        str2 = ".htm";
                    }
                    else if (str4 == "3")
                    {
                        str2 = ".shtml";
                    }
                    else if (str4 == "4")
                    {
                        str2 = ".aspx";
                    }
                }
                else
                {
                    str2 = ".html";
                }
            }
            return (str + "|" + str2);
        }

        private string ReadTemplate(string templatePath)
        {
            string str = Param.SiteRootPath.ToLower() + @"\template";
            if (!templatePath.ToLower().StartsWith(str))
            {
                return string.Empty;
            }
            string str3 = string.Empty;
            StreamReader reader = null;
            try
            {
                try
                {
                    str3 = new StreamReader(templatePath, Encoding.GetEncoding("GB2312")).ReadToEnd();
                }
                catch
                {
                    return string.Empty;
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return str3;
        }

        private void ReplaceLabelNameToContent(StringBuilder fileContent)
        {
            MatchCollection matchs = Regex.Matches(fileContent.ToString(), "{Ky_.*?}", RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                string newValue = string.Empty;
                if (match.Value.ToLower().StartsWith("{ky_s_"))
                {
                    newValue = this.GetSuperLabel(match.Value, -1);
                }
                else
                {
                    newValue = this.GetLabelContent(match.Value);
                }
                fileContent.Replace(match.Value, newValue);
            }
        }

        private void ReplaceLabelNameToContent(StringBuilder fileContent, int userId)
        {
            MatchCollection matchs = Regex.Matches(fileContent.ToString(), "{Ky_.*?}", RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                string newValue = string.Empty;
                if (match.Value.ToLower().StartsWith("{ky_s_"))
                {
                    newValue = this.GetSuperLabel(match.Value, userId);
                }
                else
                {
                    newValue = this.GetLabelContent(match.Value);
                }
                fileContent.Replace(match.Value, newValue);
            }
        }

        private void SetCompartHMTL(StringBuilder sb, string showStyle, int cellCount, int rowCount, int rowIndex, int totalCount, string compart)
        {
            if ((cellCount <= 1) && (rowCount > 0))
            {
                int num = rowIndex + 1;
                if (((num % rowCount) == 0) && (num != totalCount))
                {
                    sb.AppendLine(compart);
                }
            }
        }

        public void SetDigCount(int modelId, int infoId)
        {
            this.dal.SetDigCount(modelId, infoId);
        }

        private void SetLabelBodyHeaderHTML(StringBuilder sb, string showStyle, int cellCount, bool isCh)
        {
            string str = string.Empty;
            if (isCh)
            {
                str = "ch_col";
            }
            else
            {
                str = "col_subcol";
            }
            if (showStyle != "out_div")
            {
                if (cellCount == 1)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td valign=\"top\">");
                }
                else
                {
                    sb.AppendLine("<td valign=\"top\">");
                }
                sb.AppendLine("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"" + str + "\">");
            }
            else if (cellCount == 1)
            {
                sb.AppendLine("<div id=\"" + str + "\">");
            }
            else
            {
                sb.AppendLine("<div  style=\"float:left\" id=\"" + str + "\">");
            }
        }

        private void SetLabelBodyHTML(StringBuilder sb, StringBuilder sb2, string showStyle, int cellCount, int index, int totalCount)
        {
            if (cellCount > 1)
            {
                sb.AppendLine(sb2.ToString());
            }
            else
            {
                sb.Append(sb2.ToString());
            }
            if (cellCount > 1)
            {
                int num = index + 1;
                if (((num % cellCount) == 0) && (num != totalCount))
                {
                    if (showStyle != "out_div")
                    {
                        sb.AppendLine("</tr>");
                        sb.AppendLine("<tr>");
                    }
                    else
                    {
                        sb.AppendLine("</div>");
                        sb.AppendLine("<div style=\"float:left\">");
                    }
                }
            }
        }

        private void SetLabelBodyHTML2(StringBuilder sb, string listStr, string showStyle, string divId, string divClass, string ulId, string ulClass)
        {
            if (showStyle != "out_div")
            {
                sb.AppendLine(listStr);
            }
            else
            {
                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;
                string str4 = string.Empty;
                if (divId != string.Empty)
                {
                    str = " id=\"" + divId + "\"";
                }
                if (divClass != string.Empty)
                {
                    str2 = " class=\"" + divClass + "\"";
                }
                if (ulId != string.Empty)
                {
                    str3 = " id=\"" + ulId + "\"";
                }
                if (ulClass != string.Empty)
                {
                    str4 = " class=\"" + ulClass + "\"";
                }
                sb.AppendLine("<div" + str + str2 + ">");
                sb.AppendLine("<ul" + str3 + str4 + ">");
                sb.AppendLine(listStr);
                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
            }
        }

        private void SetLabelFooterHTML(StringBuilder sb, string showStyle, int cellCount)
        {
            if (cellCount > 1)
            {
                if (showStyle != "out_div")
                {
                    sb.AppendLine("</tr>");
                }
                else
                {
                    sb.AppendLine("</div>");
                }
            }
        }

        private void SetLabelFooterHTML2(StringBuilder sb, string showStyle, int cellCount)
        {
            if ((showStyle != "out_div") && (cellCount > 1))
            {
                sb.AppendLine("</tr>");
            }
        }

        private void SetLabelHeaderHTML(StringBuilder sb, string showStyle, int cellCount)
        {
            if (cellCount > 1)
            {
                if (showStyle != "out_div")
                {
                    sb.AppendLine("<tr>");
                }
                else
                {
                    sb.AppendLine("<div style=\"float:left\">");
                }
            }
        }

        private void SetLabelHeaderHTML2(StringBuilder sb, string showStyle, int cellCount)
        {
            if ((showStyle != "out_div") && (cellCount > 1))
            {
                sb.AppendLine("<tr>");
            }
        }

        private void SetLableBodyFooterHTML(StringBuilder sb, string showStyle, int cellCount, int rowIndex, int totalCount)
        {
            if (showStyle != "out_div")
            {
                sb.AppendLine("</table>");
                if (cellCount == 1)
                {
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");
                }
                else
                {
                    sb.AppendLine("</td>");
                    int num = rowIndex + 1;
                    if (((num % cellCount) == 0) && (num != totalCount))
                    {
                        sb.AppendLine("</tr>");
                        sb.AppendLine("<tr>");
                    }
                }
            }
            else
            {
                sb.AppendLine("</div>");
            }
        }

        private string Special_GetInfoList(string paramStr, int currSpecialId, int pageIndex, int recordCount)
        {
            DataRow current;
            int num10;
            string paramValue = "0";
            string str2 = "false";
            string str3 = "0";
            string str4 = "1";
            string str5 = "";
            string str6 = "0";
            string str7 = "0";
            string str8 = "out_table";
            string str9 = "1";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = "";
            string str14 = "";
            string str15 = "";
            string str16 = "yyyy-mm-dd";
            string str17 = "10";
            string str18 = "datedesc";
            string str19 = "30";
            string str20 = "";
            string str21 = "";
            string str22 = "false";
            string str23 = "{@page_nav}";
            this.GetParamValue(paramStr, "spid", ref paramValue);
            this.GetParamValue(paramStr, "padding", ref str2);
            this.GetParamValue(paramStr, "infocount", ref str3);
            this.GetParamValue(paramStr, "paddingstyle", ref str4);
            this.GetParamValue(paramStr, "paddingcss", ref str5);
            this.GetParamValue(paramStr, "pagesize", ref str6);
            this.GetParamValue(paramStr, "liststyle", ref str7);
            this.GetParamValue(paramStr, "showstyle", ref str8);
            this.GetParamValue(paramStr, "cellcount", ref str9);
            this.GetParamValue(paramStr, "divid", ref str10);
            this.GetParamValue(paramStr, "divclass", ref str11);
            this.GetParamValue(paramStr, "ulid", ref str12);
            this.GetParamValue(paramStr, "ulclass", ref str13);
            this.GetParamValue(paramStr, "liid", ref str14);
            this.GetParamValue(paramStr, "liclass", ref str15);
            this.GetParamValue(paramStr, "dateformat", ref str16);
            this.GetParamValue(paramStr, "dateRange", ref str17);
            this.GetParamValue(paramStr, "order", ref str18);
            this.GetParamValue(paramStr, "titleLength", ref str19);
            this.GetParamValue(paramStr, "rowcount", ref str20);
            this.GetParamValue(paramStr, "compart", ref str21);
            this.GetParamValue(paramStr, "includesub", ref str22);
            this.GetParamValue(paramStr, "pagenav", ref str23);
            int id = 0;
            if (paramValue == "0")
            {
                id = currSpecialId;
            }
            else
            {
                id = int.Parse(paramValue);
            }
            if (id == 0)
            {
                return string.Empty;
            }
            string dateRangeStr = this.GetDateRangeStr(str17);
            string orderStr = this.GetOrderStr(str18);
            int cellCount = 1;
            int totalCount = 0;
            int rowCount = 0;
            try
            {
                cellCount = int.Parse(str9);
                rowCount = int.Parse(str20);
            }
            catch
            {
            }
            M_Special special = this.SpecialBll.GetSpecial(id);
            if (special == null)
            {
                return string.Empty;
            }
            string specialIdStr = string.Format(" (i.[specialidstr] like '%{0}%' ", id);
            if (str22.ToString() == "true")
            {
                DataTable specialByParentId = this.SpecialBll.GetSpecialByParentId(id);
                foreach (DataRow row in specialByParentId.Rows)
                {
                    int num5 = (int)row["id"];
                    specialIdStr = specialIdStr + string.Format(" or i.[specialidstr] like '%{0}%' ", num5);
                }
                specialByParentId.Dispose();
            }
            specialIdStr = specialIdStr + ") and ";
            DataTable table2 = null;
            if (special.SiteID == 0)
            {
                DataTable modelAll = this.GetModelAll();
                string tableNameStr = string.Empty;
                IEnumerator enumerator = modelAll.Rows.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow)enumerator.Current;
                        object obj2 = tableNameStr;
                        tableNameStr = string.Concat(new object[] { obj2, "[", current["TableName"], "]," });
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                if (tableNameStr == string.Empty)
                {
                    return string.Empty;
                }
                if ((tableNameStr.Length > 0) && tableNameStr.EndsWith(","))
                {
                    tableNameStr = tableNameStr.Substring(0, tableNameStr.Length - 1);
                }
                table2 = this.dal.GetSite_SpecialInfoList(tableNameStr, int.Parse(str3), specialIdStr, dateRangeStr, orderStr);
            }
            else
            {
                M_Channel channel = this.ChannelBll.GetChannel(special.SiteID);
                if (channel == null)
                {
                    return string.Empty;
                }
                string tableName = this.GetTableName(channel.ModelType);
                if (tableName == string.Empty)
                {
                    return string.Empty;
                }
                table2 = this.dal.GetChannel_SpecialInfoList(tableName, int.Parse(str3), specialIdStr, dateRangeStr, orderStr);
            }
            DataTable table4 = null;
            if (str2 == "true")
            {
                int num6 = pageIndex;
                int num7 = int.Parse(str6);
                int num8 = (num6 - 1) * num7;
                int num9 = num6 * num7;
                table4 = table2.Clone();
                for (num10 = num8; (num10 < num9) && (num10 < table2.Rows.Count); num10++)
                {
                    current = table4.NewRow();
                    foreach (DataColumn column in table4.Columns)
                    {
                        current[column.ColumnName] = table2.Rows[num10][column.ColumnName];
                    }
                    table4.Rows.Add(current);
                }
            }
            else
            {
                table4 = table2;
            }
            if ((table4 == null) || (table4.Rows.Count == 0))
            {
                return string.Empty;
            }
            string styleContent = this.GetStyleContent(int.Parse(str7));
            StringBuilder sb = new StringBuilder();
            MatchCollection styleFileldName = this.GetStyleFileldName(styleContent);
            totalCount = table4.Rows.Count;
            this.SetLabelHeaderHTML(sb, str8, cellCount);
            for (num10 = 0; num10 < table4.Rows.Count; num10++)
            {
                current = table4.Rows[num10];
                StringBuilder builder2 = new StringBuilder(styleContent);
                this.GetListStyleHTML(styleFileldName, builder2, current, int.Parse(str19), str16, num10);
                this.GetListStyleHTML(styleFileldName, builder2, current, int.Parse(str19), str16, num10);
                this.SetLabelBodyHTML(sb, builder2, str8, cellCount, num10, totalCount);
                this.SetCompartHMTL(sb, str8, cellCount, rowCount, num10, totalCount, str21);
            }
            this.SetLabelFooterHTML(sb, str8, cellCount);
            table2.Dispose();
            if (str2 == "true")
            {
                int pageCount = ((recordCount - 1) / int.Parse(str6)) + 1;
                sb.Append(str23.Replace("{@page_nav}", this.GetSpecialPageNav(currSpecialId, pageIndex, int.Parse(str6), recordCount, pageCount, str4, str5)));
            }
            return sb.ToString();
        }

        public string StrValue(DataRow dr, string HostTable, string MyContent)
        {
            StringBuilder builder = new StringBuilder(MyContent);
            MatchCollection styleFileldName = this.GetStyleFileldName(MyContent);
            string str = builder.ToString();
            foreach (Match match in styleFileldName)
            {
                if (match.Groups.Count > 1)
                {
                    if (match.Groups[1].Value.ToLower() == "infourl")
                    {
                        str = str.Replace(match.Value, "" + this.GetInfoUrl(int.Parse(dr["Id"].ToString()), HostTable) + "");
                    }
                    else if (match.Groups[1].Value.ToLower() == "title")
                    {
                        str = str.Replace(match.Value, "" + Ky.Common.Function.Encode(dr["" + match.Groups[1].Value + ""].ToString()) + "");
                    }
                    else
                    {
                        str = str.Replace(match.Value, "" + dr["" + match.Groups[1].Value + ""].ToString() + "");
                    }
                }
            }
            return str.ToString();
        }

        public string SubStr(string input, int length, string replace)
        {
            if ((length > 0) && (Encoding.Default.GetBytes(input).Length > length))
            {
                return (Ky.Common.Function.SubStrByByte(input, length) + replace);
            }
            return input;
        }

        public int TotalContentPageNumber(DataRow dr)
        {
            int length = 0;
            string str = string.Empty;
            int num2 = (int)dr["modelId"];
            if (num2 == 2)
            {
                if (this.CheckColumn(dr, "imgpath"))
                {
                    str = dr["imgpath"].ToString();
                    if (str.Length <= 0)
                    {
                        return 1;
                    }
                    length = str.Substring(1, str.Length - 2).Split(new char[] { '|' }).Length;
                }
                return length;
            }
            if (this.CheckColumn(dr, "content"))
            {
                length = dr["content"].ToString().Replace("{Ky:PAGE}", "┃").Split(new char[] { '┃' }).Length;
            }
            return length;
        }

        private bool WriterTemplate(string templatePath, string content)
        {
            StreamWriter writer = null;
            try
            {
                try
                {
                    writer = new StreamWriter(templatePath, false, Encoding.UTF8);
                    writer.Write(content);
                    writer.Flush();
                }
                catch
                {
                    return false;
                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return true;
        }
    }
}

