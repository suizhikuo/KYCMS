namespace Ky.BLL
{
    using Ky.BLL.CommonModel;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    public class B_Collection
    {
        private B_Channel ChannelBll = new B_Channel();
        private M_Channel ChannelM = new M_Channel();
        private B_Column ColumnBll = new B_Column();
        private M_Column ColumnM = new M_Column();
        private ICollection dal = DataAccess.CreateCollection();
        private B_InfoModel InfoModelBll = new B_InfoModel();
        private M_InfoModel ModelM = new M_InfoModel();
        private B_SiteInfo SiteBll = new B_SiteInfo();
        private M_Site SiteModel = null;
        private B_Superior SuperiorBll = new B_Superior();
        private M_Superior SuperiorM = new M_Superior();

        public void Add(M_Collection collectionM)
        {
            this.dal.Add(collectionM);
        }

        public bool AddCollectionData(string contentAddress, M_Collection collectionM)
        {
            bool flag = true;
            string fieldName = string.Empty;
            string fieldValue = string.Empty;
            string tableName = string.Empty;
            string content = this.GetContent(contentAddress, collectionM);
            this.ColumnM = this.ColumnBll.GetColumn(collectionM.ColId);
            this.ChannelM = this.ChannelBll.GetChannel(this.ColumnM.ChId);
            this.ModelM = this.InfoModelBll.GetModel(this.ChannelM.ModelType);
            tableName = this.ModelM.TableName.Replace("\"", "");
            fieldName = content.Split(new char[] { '┃' })[0].ToString();
            fieldValue = content.Split(new char[] { '┃' })[1].ToString();
            fieldName = fieldName.Substring(0, fieldName.Length - 1);
            string str5 = ",colid,uid,usertype,adminuid,updatetime,IsRecommend,IsFocus,IsSideShow,IsTop,isAllowComment,IsCreated,HitCount,TemplatePath,SpecialIdStr,Status";
            string str6 = ",expiretime,IsIrregular,IsHeader,StarLevel";
            if (this.ModelM.ModelId == 1)
            {
                fieldName = fieldName + str5 + str6;
            }
            else
            {
                fieldName = fieldName + str5;
            }
            fieldValue = fieldValue.Substring(0, fieldValue.Length - 1);
            fieldValue = ((string.Concat(new object[] { fieldValue, "$", collectionM.ColId, "$" }) + "0$") + "1$" + "0$") + DateTime.Now.ToString() + "$";
            string str7 = "0$";
            string str8 = "0$";
            string str9 = "0$";
            string str10 = "0$";
            string str11 = "0$";
            string str12 = "0$";
            string str13 = "0$";
            string str14 = "0$";
            string proterySet = collectionM.ProterySet;
            if (proterySet != "")
            {
                string[] strArray = proterySet.Split(new char[] { ',' });
                for (int i = 0; i < (strArray.Length - 1); i++)
                {
                    switch (int.Parse(strArray[i].ToString()))
                    {
                        case 0:
                            str7 = "1$";
                            break;

                        case 1:
                            str8 = "1$";
                            break;

                        case 2:
                            str9 = "1$";
                            break;

                        case 3:
                            str10 = "1$";
                            break;

                        case 4:
                            str11 = "1$";
                            break;

                        case 5:
                            str12 = "1$";
                            break;

                        case 6:
                            str13 = "1$";
                            break;

                        case 7:
                            str14 = "1$";
                            break;
                    }
                }
            }
            fieldValue = ((((fieldValue + str7 + str8 + str10 + str11 + str13 + str14) + collectionM.HiteCount + "$") + this.ColumnM.InfoTemplatePath + "$") + collectionM.SpecialId + "$") + "3";
            if (this.ModelM.ModelId == 1)
            {
                fieldValue = (string.Concat(new object[] { fieldValue, "$", DateTime.Now.AddDays(500000.0), "$" }) + str12) + str9 + collectionM.StarLevel;
            }
            try
            {
                this.CollectionData(tableName, fieldName, fieldValue);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public void CollectionData(string tableName, string fieldName, string fieldValue)
        {
            this.dal.CollectionData(tableName, fieldName, fieldValue);
        }

        public void Delete(int id)
        {
            this.dal.Delete(id);
        }

        public string FilterA(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(input, "<.?a(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public string FilterDiv(string htmlCode)
        {
            string str = htmlCode;
            return Regex.Replace(htmlCode, "<.?div(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public string FilterFont(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(input, "<.?font(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public string FilterImg(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(input, "<img(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public string FilterObject(string htmlCode)
        {
            string pattern = @"<object((?:.|\n)*?)</object>";
            string oldValue = string.Empty;
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(htmlCode);
            if (match.Success)
            {
                oldValue = match.Value;
                htmlCode = htmlCode.Replace(oldValue, "");
            }
            return htmlCode;
        }

        public string FilterScript(string htmlCode)
        {
            string pattern = @"<script((?:.|\n)*?)</script>";
            string oldValue = string.Empty;
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(htmlCode);
            if (match.Success)
            {
                oldValue = match.Value;
                htmlCode = htmlCode.Replace(oldValue, "");
            }
            return htmlCode;
        }

        public string FilterSpan(string htmlCode)
        {
            string str = htmlCode;
            return Regex.Replace(htmlCode, "<.?span(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public string FilterStyle(string htmlCode)
        {
            string pattern = @"<style((?:.|\n)*?)</style>";
            string oldValue = string.Empty;
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(htmlCode);
            if (match.Success)
            {
                oldValue = match.Value;
                htmlCode = htmlCode.Replace(oldValue, "");
            }
            return htmlCode;
        }

        public string FilterTableProtery(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(Regex.Replace(Regex.Replace(input, "<.?table(.|\n)*?>", "", RegexOptions.IgnoreCase), "<.?tr(.|\n)*?>", "", RegexOptions.IgnoreCase), "<.?td(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        private string GetContent(M_Collection collectionM, string contentStr)
        {
            this.ColumnM = this.ColumnBll.GetColumn(collectionM.ColId);
            this.ChannelM = this.ChannelBll.GetChannel(this.ColumnM.ChId);
            this.ModelM = this.InfoModelBll.GetModel(this.ChannelM.ModelType);
            this.SiteModel = this.SiteBll.GetSiteModel();
            B_ConvertImage image = new B_ConvertImage(this.SiteModel.Domain, this.ModelM.UploadPath);
            string simpleFilterRule = collectionM.SimpleFilterRule;
            string pattern = string.Empty;
            string complexityFilterRule = collectionM.ComplexityFilterRule;
            if (complexityFilterRule != "")
            {
                string[] strArray = complexityFilterRule.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    this.SuperiorM = this.SuperiorBll.GetIdBySuperior(int.Parse(strArray[i].ToString()));
                    pattern = this.TransferStr(this.SuperiorM.StartCode) + "((?:.|\n)*?)" + this.TransferStr(this.SuperiorM.EndCode);
                    contentStr = this.SuperiorHtml(contentStr, pattern);
                }
            }
            if (simpleFilterRule != "")
            {
                string[] strArray2 = simpleFilterRule.Split(new char[] { ',' });
                for (int j = 0; j < (strArray2.Length - 1); j++)
                {
                    switch (int.Parse(strArray2[j].ToString()))
                    {
                        case 0:
                            contentStr = this.FilterObject(contentStr);
                            break;

                        case 1:
                            contentStr = this.FilterScript(contentStr);
                            break;

                        case 2:
                            contentStr = this.FilterStyle(contentStr);
                            break;

                        case 3:
                            contentStr = this.FilterDiv(contentStr);
                            break;

                        case 4:
                            contentStr = this.FilterSpan(contentStr);
                            break;

                        case 5:
                            contentStr = this.FilterTableProtery(contentStr);
                            break;

                        case 6:
                            contentStr = this.FilterImg(contentStr);
                            break;

                        case 7:
                            contentStr = this.FilterFont(contentStr);
                            break;

                        case 8:
                            contentStr = this.FilterA(contentStr);
                            break;

                        case 9:
                            contentStr = this.RemoveHtml(contentStr);
                            break;
                    }
                }
            }
            contentStr = image.ConvertLocalImagePath(contentStr);
            contentStr = image.ConvertContent(contentStr);
            return contentStr;
        }

        public string GetContent(string contentAddress, M_Collection collectionM)
        {
            string contentStr = string.Empty;
            string htmlCode = string.Empty;
            string input = string.Empty;
            string str5 = string.Empty;
            string regStr = string.Empty;
            string charSet = collectionM.CharSet;
            string imagePath = string.Empty;
            if (charSet == "0")
            {
                charSet = "gb2312";
            }
            else
            {
                charSet = "utf-8";
            }
            string webSite = collectionM.WebSite;
            string fieldListSet = collectionM.FieldListSet;
            string contentPageSet = collectionM.ContentPageSet;
            string[] strArray = fieldListSet.Split(new char[] { '|' });
            string[] strArray2 = new string[strArray.Length - 1];
            this.ColumnM = this.ColumnBll.GetColumn(collectionM.ColId);
            this.ChannelM = this.ChannelBll.GetChannel(this.ColumnM.ChId);
            int num = 0;
            if (contentPageSet != "")
            {
                num = int.Parse(contentPageSet.Split(new char[] { '|' })[0].ToString().Split(new char[] { '┃' })[1].ToString());
            }
            string str13 = string.Empty;
            string nextAddress = string.Empty;
            htmlCode = this.GetHtmlCode(contentAddress, charSet);
            for (int i = 0; i < strArray2.Length; i++)
            {
                regStr = this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()) + "((?:.|\n)*?)" + this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString());
                if (strArray[i].Split(new char[] { ',' })[0].ToString().ToLower() == "content")
                {
                    contentStr = this.GetRegValue(regStr, htmlCode);
                    contentStr = this.GetContent(collectionM, contentStr);
                    switch (num)
                    {
                        case 1:
                            str13 = this.TransferStr(contentPageSet.Split(new char[] { '|' })[1].Split(new char[] { '┃' })[1].ToString()) + "((?:.|\n)*?)" + this.TransferStr(contentPageSet.Split(new char[] { '|' })[2].Split(new char[] { '┃' })[1].ToString());
                            nextAddress = this.IsFullAddress(collectionM.WebSite, collectionM.ListPageUrl, this.GetHref(this.GetRegValue(str13, htmlCode)));
                            if ((nextAddress != "") && (collectionM.WebSite != nextAddress))
                            {
                                string[] strArray3 = nextAddress.Substring(0, nextAddress.Length - 1).Split(new char[] { ',' });
                                nextAddress = strArray3[strArray3.Length - 1];
                                contentStr = contentStr + this.GetPageCodeContent(nextAddress, str13, collectionM, regStr, contentStr);
                            }
                            break;

                        case 2:
                            nextAddress = contentPageSet.Split(new char[] { '|' })[1].Split(new char[] { '┃' })[1].ToString();
                            contentStr = contentStr + this.GetPageIdContent(nextAddress, collectionM, regStr, contentAddress, contentStr, imagePath);
                            break;

                        case 3:
                            nextAddress = contentPageSet.Split(new char[] { '|' })[1].Split(new char[] { '┃' })[1].ToString();
                            contentStr = contentStr + this.GetListAddressContent(nextAddress, collectionM, regStr, contentStr);
                            break;
                    }
                    if (contentStr == "")
                    {
                        contentStr = strArray[i].Split(new char[] { ',' })[3].ToString();
                    }
                    contentStr = Regex.Replace(Regex.Replace(contentStr, this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString()), "", RegexOptions.IgnoreCase), this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()), "", RegexOptions.IgnoreCase);
                }
                else if (strArray[i].Split(new char[] { ',' })[0].ToString().ToLower() == "addtime")
                {
                    if ((((this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()) != "") && (this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()).Length != 0)) && (this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString()) != "")) && (this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString()).Length != 0))
                    {
                        contentStr = this.RemoveHtml(this.GetRegValue(regStr, htmlCode).Replace(this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()), "").Replace(this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString()), "").Replace("\r\n", "").Replace("&nbsp;", "")).Trim();
                    }
                    else
                    {
                        contentStr = strArray[i].Split(new char[] { ',' })[3].ToString().Trim();
                    }
                }
                else
                {
                    if ((((this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()) != "") && (this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()).Length != 0)) && (this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString()) != "")) && (this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString()).Length != 0))
                    {
                        contentStr = this.RemoveHtml(this.GetRegValue(regStr, htmlCode).Replace(this.TransferStr(strArray[i].Split(new char[] { ',' })[1].ToString()), "").Replace(this.TransferStr(strArray[i].Split(new char[] { ',' })[2].ToString()), "").Trim());
                    }
                    else
                    {
                        contentStr = this.RemoveHtml(this.GetRegValue(regStr, htmlCode)).Trim();
                    }
                    if (contentStr == "")
                    {
                        contentStr = strArray[i].Split(new char[] { ',' })[3].ToString();
                    }
                }
                input = input + strArray[i].Split(new char[] { ',' })[0].ToString().ToLower() + ",";
                str5 = str5 + contentStr + "$";
            }
            if (!Regex.Match(input, "uname", RegexOptions.IgnoreCase).Success)
            {
                input = input + "uname,";
                str5 = str5 + "admin$";
            }
            if (!Regex.Match(input, "addtime", RegexOptions.IgnoreCase).Success)
            {
                input = input + "addtime,";
                str5 = str5 + DateTime.Now.ToString() + "$";
            }
            if ((imagePath != string.Empty) && (imagePath.Length != 0))
            {
                input = input + "ImgPath,";
                str5 = str5 + "|" + imagePath + "$";
            }
            return (input + "┃" + str5);
        }

        public string GetHref(string htmlCode)
        {
            string str = string.Empty;
            string pattern = "(h|H)(r|R)(e|E)(f|F) *= *('|\")?((\\w|\\\\|\\/|\\.|:|-|_|\\?|=|&|\\w)+)('|\"| *|>)?";
            foreach (Match match in Regex.Matches(htmlCode, pattern, RegexOptions.IgnoreCase))
            {
                str = str + match.Value.ToString().Replace("href=", "").Trim().Replace("\"", "").Replace("'", "") + ",";
            }
            return str;
        }

        public string GetHtmlCode(string urlStr, string charSet)
        {
            string input = string.Empty;
            WebClient client = new WebClient();
            client.Encoding = Encoding.GetEncoding(charSet);
            if ((urlStr.Trim().Length != 0) && (urlStr.LastIndexOf(',') != -1))
            {
                urlStr = urlStr.Substring(0, urlStr.LastIndexOf(','));
            }
            byte[] bytes = client.DownloadData(urlStr);
            try
            {
                input = Encoding.GetEncoding(charSet).GetString(bytes);
            }
            catch
            {
            }
            string pattern = "<%@LANGUAGE=\"VBSCRIPT\" CODEPAGE=\"936\"%>";
            if (Regex.Match(input, pattern, RegexOptions.IgnoreCase).Success)
            {
                return string.Empty;
            }
            return input;
        }

        public M_Collection GetIdByCollection(int id)
        {
            return this.dal.GetIdByCollection(id);
        }

        public string GetImageSrc(string htmlCode)
        {
            string str = string.Empty;
            string pattern = "<img.+?>";
            foreach (Match match in Regex.Matches(htmlCode, pattern, RegexOptions.IgnoreCase))
            {
                str = str + this.GetImg(match.Value.ToString().Trim()) + "|";
            }
            return str;
        }

        public string GetImg(string imgStr)
        {
            string str = string.Empty;
            string pattern = @"src=.+\.(bmp|jpg|gif|png)";
            foreach (Match match in Regex.Matches(imgStr.ToString(), pattern, RegexOptions.IgnoreCase))
            {
                str = str + match.Value.ToString().Trim().Replace("src=", "").Replace("\"", "");
            }
            return str;
        }

        public DataTable GetList()
        {
            return this.dal.GetList();
        }

        private string GetListAddressContent(string addressStr, M_Collection collectionM, string contentRegex, string contentStr)
        {
            string str;
            int num;
            addressStr = addressStr.Replace("\r\n", "|");
            if (collectionM.CharSet == "0")
            {
                str = "gb2312";
            }
            else
            {
                str = "utf-8";
            }
            string[] strArray = addressStr.Split(new char[] { '|' });
            string str2 = string.Empty;
            string htmlCode = string.Empty;
            for (num = 0; num < strArray.Length; num++)
            {
                if (strArray[num] != "")
                {
                    str2 = str2 + strArray[num] + "|";
                }
            }
            string[] strArray2 = str2.Split(new char[] { '|' });
            for (num = 0; num < (strArray2.Length - 1); num++)
            {
                htmlCode = this.GetHtmlCode(strArray2[num], str);
                contentStr = contentStr + this.GetContent(collectionM, this.GetRegValue(contentRegex, htmlCode));
            }
            return contentStr;
        }

        public string GetListAddressLink(string addressStr, string doMain, string listUrl, string charSet, string listRegex, string linkRegex, string linkStr)
        {
            int num;
            addressStr = addressStr.Replace("\r\n", "|");
            string[] strArray = addressStr.Split(new char[] { '|' });
            string str = string.Empty;
            string htmlCode = string.Empty;
            string listStr = string.Empty;
            for (num = 0; num < strArray.Length; num++)
            {
                if (strArray[num] != "")
                {
                    str = str + strArray[num] + "|";
                }
            }
            string[] strArray2 = str.Split(new char[] { '|' });
            for (num = 0; num < (strArray2.Length - 1); num++)
            {
                htmlCode = this.GetHtmlCode(strArray2[num], charSet);
                listStr = this.GetRegValue(listRegex, htmlCode);
                linkStr = linkStr + this.LinkStr(listStr, listUrl, linkRegex, doMain);
            }
            return linkStr;
        }

        private string GetPageCodeContent(string nextAddress, string contentPageRegexStr, M_Collection collectionM, string contentRegex, string contentStr)
        {
            string str;
            if (collectionM.CharSet == "0")
            {
                str = "gb2312";
            }
            else
            {
                str = "utf-8";
            }
            string webSite = collectionM.WebSite;
            string htmlCode = this.GetHtmlCode(nextAddress, str);
            contentStr = contentStr + "{Ky:PAGE}" + this.GetContent(collectionM, this.GetRegValue(contentRegex, htmlCode));
            nextAddress = this.IsFullAddress(webSite, collectionM.ListPageUrl, this.GetHref(this.GetRegValue(contentPageRegexStr, htmlCode)));
            if (nextAddress != "")
            {
                string[] strArray = nextAddress.Substring(0, nextAddress.Length - 1).Split(new char[] { ',' });
                nextAddress = strArray[strArray.Length - 1];
                if (nextAddress == strArray[0])
                {
                    return contentStr;
                }
                return this.GetPageCodeContent(nextAddress, contentPageRegexStr, collectionM, contentRegex, contentStr);
            }
            return contentStr;
        }

        public string GetPageCodeLink(string nextAddress, string doMain, string listUrl, string charSet, string listRegex, string linkRegex, string pageRegex, string linkStr)
        {
            string htmlCode = this.GetHtmlCode(nextAddress, charSet);
            string regValue = this.GetRegValue(listRegex, htmlCode);
            linkStr = linkStr + this.LinkStr(regValue, listUrl, linkRegex, doMain);
            nextAddress = this.IsFullAddress(doMain, listUrl, this.GetHref(this.GetRegValue(pageRegex, htmlCode)));
            if (nextAddress != doMain.Substring(0, doMain.Length - 1))
            {
                this.GetPageCodeLink(nextAddress, doMain, listUrl, charSet, listRegex, linkRegex, pageRegex, linkStr);
            }
            return linkStr;
        }

        public string GetPageIdContent(string nextAddress, M_Collection collectionM, string contentRegex, string address, string contentStr, string imagePath)
        {
            string str;
            int num2;
            this.ColumnM = this.ColumnBll.GetColumn(collectionM.ColId);
            this.ChannelM = this.ChannelBll.GetChannel(this.ColumnM.ChId);
            if (collectionM.CharSet == "0")
            {
                str = "gb2312";
            }
            else
            {
                str = "utf-8";
            }
            string input = string.Empty;
            input = this.GetHtmlCode(address, str);
            int startIndex = address.LastIndexOf('.');
            string pattern = address.Insert(startIndex, "((?:.|\n)*?)");
            MatchCollection matchs = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            string str5 = string.Empty;
            foreach (Match match in matchs)
            {
                str5 = str5 + match.Value + ",";
            }
            string[] strArray = null;
            if (str5 != "")
            {
                strArray = str5.Substring(0, str5.Length - 1).Split(new char[] { ',' });
            }
            string str6 = string.Empty;
            if ((strArray == null) && (strArray.Length == 0))
            {
                return string.Empty;
            }
            string[] strArray2 = new string[strArray.Length];
            if (strArray.Length > 0)
            {
                for (num2 = 0; num2 < strArray.Length; num2++)
                {
                    int num3 = 0;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[num2] == strArray2[i])
                        {
                            num3++;
                        }
                    }
                    if (num3 == 0)
                    {
                        strArray2[num2] = strArray[num2];
                    }
                }
            }
            num2 = 0;
            while (num2 < strArray2.Length)
            {
                if (strArray2[num2] != "")
                {
                    str6 = str6 + strArray2[num2] + ",";
                }
                num2++;
            }
            if (str6 != "")
            {
                strArray = str6.Substring(0, str6.Length - 1).Split(new char[] { ',' });
                for (num2 = 1; num2 < (strArray.Length - 1); num2++)
                {
                    if (strArray[num2] != "")
                    {
                        input = this.GetHtmlCode(strArray[num2], str);
                        contentStr = contentStr + "{Ky:PAGE}" + this.GetContent(collectionM, this.GetRegValue(contentRegex, input));
                    }
                }
            }
            return contentStr;
        }

        public string GetPageIdLink(string addressStr, string doMain, string listUrl, string charSet, string listRegex, string linkRegex, int startId, int endId, string linkStr)
        {
            string htmlCode = string.Empty;
            string listStr = string.Empty;
            string urlStr = string.Empty;
            if (startId >= endId)
            {
                while (endId <= startId)
                {
                    urlStr = addressStr.Replace("{$ID}", endId.ToString());
                    htmlCode = this.GetHtmlCode(urlStr, charSet);
                    listStr = this.GetRegValue(listRegex, htmlCode);
                    linkStr = linkStr + this.LinkStr(listStr, listUrl, linkRegex, doMain);
                    endId++;
                }
                return linkStr;
            }
            while (startId <= endId)
            {
                urlStr = addressStr.Replace("{$ID}", startId.ToString());
                htmlCode = this.GetHtmlCode(urlStr, charSet);
                listStr = this.GetRegValue(listRegex, htmlCode);
                linkStr = linkStr + this.LinkStr(listStr, listUrl, linkRegex, doMain);
                startId++;
            }
            return linkStr;
        }

        public string GetRegValue(string regStr, string htmlCode)
        {
            string str = string.Empty;
            Match match = new Regex(regStr, RegexOptions.IgnoreCase).Match(htmlCode);
            if (match.Success)
            {
                str = match.Value;
            }
            return str;
        }

        private string IsFullAddress(string domain, string listUrl, string linkStr)
        {
            string urlStr = string.Empty;
            Match match = new Regex(domain, RegexOptions.IgnoreCase).Match(linkStr);
            if (linkStr.Substring(0, 7) == "http://")
            {
                return linkStr;
            }
            if (match.Success)
            {
                return linkStr;
            }
            if ((linkStr.Length != 0) && (linkStr.Substring(0, 1) == "/"))
            {
                urlStr = domain.Substring(0, domain.Length - 1) + linkStr;
                if ((this.GetHtmlCode(urlStr, "gb2312") == "") || (this.GetHtmlCode(urlStr, "gb2312").Length == 0))
                {
                    urlStr = listUrl.Substring(0, listUrl.LastIndexOf('/')) + "/" + linkStr;
                }
                return urlStr;
            }
            if ((linkStr.Length != 0) && (linkStr.Substring(0, 3) == "../"))
            {
                urlStr = listUrl.Substring(0, listUrl.LastIndexOf('/')) + "/" + linkStr;
                if ((this.GetHtmlCode(urlStr, "gb2312") == "") || (this.GetHtmlCode(urlStr, "gb2312").Length == 0))
                {
                    urlStr = listUrl.Substring(0, listUrl.LastIndexOf('/')) + "/" + linkStr;
                }
                return urlStr;
            }
            urlStr = domain + linkStr;
            string htmlCode = this.GetHtmlCode(urlStr, "gb2312");
            if ((htmlCode == "") || (htmlCode.Length == 0))
            {
                return (listUrl.Substring(0, listUrl.LastIndexOf('/')) + "/" + linkStr);
            }
            return (domain + linkStr);
        }

        public string LinkStr(string listStr, string listUrl, string linkReg, string domain)
        {
            string str = string.Empty;
            MatchCollection matchs = Regex.Matches(listStr, linkReg, RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                str = str + this.IsFullAddress(domain, listUrl, this.GetHref(match.Value));
            }
            return str;
        }

        public string ListPageLink(M_Collection collectionM)
        {
            string str9;
            string linkStr = string.Empty;
            string htmlCode = string.Empty;
            string regStr = string.Empty;
            string listStr = string.Empty;
            string linkReg = string.Empty;
            string str6 = string.Empty;
            string nextAddress = string.Empty;
            string pageSet = collectionM.PageSet;
            int num = int.Parse(pageSet.Split(new char[] { '|' })[0].ToString().Split(new char[] { '┃' })[1].ToString());
            if (collectionM.CharSet == "0")
            {
                str9 = "gb2312";
            }
            else
            {
                str9 = "utf-8";
            }
            htmlCode = this.GetHtmlCode(collectionM.ListPageUrl, str9);
            regStr = this.TransferStr(collectionM.ListStartCode) + "((?:.|\n)*?)" + this.TransferStr(collectionM.ListEndCode);
            listStr = this.GetRegValue(regStr, htmlCode);
            linkReg = this.TransferStr(collectionM.LinkStartCode) + "((?:.|\n)*?)" + this.TransferStr(collectionM.LinkEndCode);
            linkStr = this.LinkStr(listStr, collectionM.ListPageUrl, linkReg, collectionM.WebSite);
            switch (num)
            {
                case 1:
                    str6 = this.TransferStr(pageSet.Split(new char[] { '|' })[1].Split(new char[] { '┃' })[1].ToString()) + "((?:.|\n)*?)" + this.TransferStr(pageSet.Split(new char[] { '|' })[2].Split(new char[] { '┃' })[1].ToString());
                    nextAddress = this.IsFullAddress(collectionM.WebSite, collectionM.ListPageUrl, this.GetHref(this.GetRegValue(str6, htmlCode)));
                    return (linkStr + this.GetPageCodeLink(nextAddress, collectionM.WebSite, collectionM.ListPageUrl, str9, regStr, linkReg, str6, linkStr));

                case 2:
                {
                    int startId = int.Parse(pageSet.Split(new char[] { '|' })[2].Split(new char[] { '┃' })[1].ToString());
                    int endId = int.Parse(pageSet.Split(new char[] { '|' })[3].Split(new char[] { '┃' })[1].ToString());
                    nextAddress = pageSet.Split(new char[] { '|' })[1].Split(new char[] { '┃' })[1].ToString();
                    return (linkStr + this.GetPageIdLink(nextAddress, collectionM.WebSite, collectionM.ListPageUrl, str9, regStr, linkReg, startId, endId, linkStr));
                }
                case 3:
                    nextAddress = pageSet.Split(new char[] { '|' })[1].Split(new char[] { '┃' })[1].ToString();
                    return (linkStr + this.GetListAddressLink(nextAddress, collectionM.WebSite, collectionM.ListPageUrl, str9, regStr, linkReg, linkStr));
            }
            return linkStr;
        }

        public string RemoveHtml(string htmlCode)
        {
            string str = htmlCode;
            foreach (Match match in Regex.Matches(htmlCode, "<.+?>"))
            {
                str = str.Replace(match.Value, "");
            }
            return str;
        }

        public string RemoveStrtAndEndStr(string regStr, string regStart, string regEnd)
        {
            string str = regStr;
            if ((regStr != string.Empty) && (regStr != null))
            {
                if ((regStart != string.Empty) && (regStart != null))
                {
                    str = str.Replace(regStart, "");
                }
                if ((regEnd != string.Empty) && (regStart != null))
                {
                    str = str.Replace(regEnd, "");
                }
                return str;
            }
            return str;
        }

        public string SuperiorHtml(string htmlCode, string pattern)
        {
            string input = htmlCode;
            return Regex.Replace(input, pattern, "", RegexOptions.IgnoreCase);
        }

        public string TransferStr(string str)
        {
            str = str.Replace("(", @"\(").Replace(")", @"\)");
            str = str.Replace(".", @"\.");
            str = str.Replace("*", @"\*");
            str = str.Replace("+", @"\+");
            str = str.Replace("?", @"\?");
            str = str.Replace("|", @"\|");
            str = str.Replace("^", @"\^");
            str = str.Replace("$", @"\$");
            str = str.Replace("[", @"\[").Replace("]", "]");
            return str;
        }

        public void Update(M_Collection collectionM)
        {
            this.dal.Update(collectionM);
        }
    }
}

