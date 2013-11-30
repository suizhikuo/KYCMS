namespace Ky.BLL
{
    using Ky.Model;
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using Ky.Common;

    public class B_SiteInfo
    {
        private string DirName = (Param.SiteRootPath + @"\" + Param.ConfDirName);

        public B_SiteInfo()
        {
            if (!Directory.Exists(this.DirName))
            {
                Directory.CreateDirectory(this.DirName);
            }
        }

        public string GetFiltering(string FilterStr)
        {
            StringBuilder builder = new StringBuilder(FilterStr);
            if (this.GetSiteModel().FilterStr != "")
            {
                string[] strArray = this.GetSiteModel().FilterStr.Split(new char[] { '|' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] != "")
                    {
                        builder = builder.Replace(strArray[i], "*");
                    }
                }
            }
            return builder.ToString();
        }

        public M_InfoSite GetInfoModel()
        {
            string path = this.DirName + @"\infosite.config";
            if (!File.Exists(path))
            {
                return null;
            }
            XmlDocument document = new XmlDocument();
            document.Load(path);
            M_InfoSite site = new M_InfoSite();
            XmlNode node = document.ChildNodes[1];
            site.InfoCreateNum = int.Parse(node.ChildNodes[0].InnerText);
            site.SpecialInfoCreateNum = int.Parse(node.ChildNodes[1].InnerText);
            site.SearchTime = int.Parse(node.ChildNodes[2].InnerText);
            site.SearchResultPageSize = int.Parse(node.ChildNodes[3].InnerText);
            site.IsOpenViewerDig = bool.Parse(node.ChildNodes[4].InnerText);
            site.ImgUploadType = node.ChildNodes[5].InnerText.Trim();
            site.VideoUploadType = node.ChildNodes[6].InnerText.Trim();
            site.AudioUploadType = node.ChildNodes[7].InnerText.Trim();
            site.SoftUploadType = node.ChildNodes[8].InnerText.Trim();
            site.OtherUploadType = node.ChildNodes[9].InnerText.Trim();
            site.HistoryTime = int.Parse(node.ChildNodes[10].InnerText);
            return site;
        }

        public M_Site GetSiteModel()
        {
            string path = this.DirName + @"\site.config";
            if (!File.Exists(path))
            {
                return null;
            }
            XmlDocument document = new XmlDocument();
            document.Load(path);
            M_Site site = new M_Site();
            XmlNode node = document.ChildNodes[1];
            site.SequenceNum = node.ChildNodes[0].InnerText.Trim();
            site.SiteName = node.ChildNodes[1].InnerText.Trim();
            site.Domain = node.ChildNodes[2].InnerText.Trim();
            site.LogoAddress = node.ChildNodes[3].InnerText.Trim();
            site.BannerAddress = node.ChildNodes[4].InnerText.Trim();
            site.CopyRight = node.ChildNodes[5].InnerText.Trim();
            site.IsStaticType = bool.Parse(node.ChildNodes[6].InnerText.Trim());
            site.IsAbsPathType = bool.Parse(node.ChildNodes[7].InnerText.Trim());
            site.Keyword = node.ChildNodes[8].InnerText.Trim();
            site.KeyContent = node.ChildNodes[9].InnerText.Trim();
            site.IndexTemplatePath = node.ChildNodes[10].InnerText.Trim();
            site.PageType = int.Parse(node.ChildNodes[11].InnerText.Trim());
            site.EmailServerAddress = node.ChildNodes[12].InnerText.Trim();
            site.EmailServerUserName = node.ChildNodes[13].InnerText.Trim();
            site.EmailServerUserPass = node.ChildNodes[14].InnerText.Trim();
            site.IsAllowRegsite = bool.Parse(node.ChildNodes[15].InnerText.Trim());
            site.IsTestEmail = bool.Parse(node.ChildNodes[16].InnerText.Trim());
            site.DefaultUserGroup = int.Parse(node.ChildNodes[17].InnerText);
            site.LogErrorNum = int.Parse(node.ChildNodes[18].InnerText.Trim());
            site.IsLoginValidate = bool.Parse(node.ChildNodes[19].InnerText.Trim());
            site.IsCommentValidate = bool.Parse(node.ChildNodes[20].InnerText.Trim());
            site.IsAllowCommentNoName = bool.Parse(node.ChildNodes[21].InnerText.Trim());
            site.IsAddCommentEditor = bool.Parse(node.ChildNodes[22].InnerText.Trim());
            site.FilterStr = node.ChildNodes[23].InnerText.Trim();
            site.GUnitName = node.ChildNodes[24].InnerText.Trim();
            site.IsImgWaterMark = bool.Parse(node.ChildNodes[25].InnerText.Trim());
            site.WaterMarkStr = node.ChildNodes[26].InnerText.Trim();
            site.WaterMarkFontSize = int.Parse(node.ChildNodes[27].InnerText.Trim());
            site.WaterMarkFontName = node.ChildNodes[28].InnerText.Trim();
            site.WaterMarkFontColor = node.ChildNodes[29].InnerText.Trim();
            site.WaterMarkIsBold = bool.Parse(node.ChildNodes[30].InnerText.Trim());
            site.WaterMarkPath = node.ChildNodes[31].InnerText.Trim();
            site.WaterMarkHW = node.ChildNodes[32].InnerText.Trim();
            site.WaterMarkLight = int.Parse(node.ChildNodes[33].InnerText.Trim());
            site.WaterMarkPos = int.Parse(node.ChildNodes[34].InnerText.Trim());
            site.IsOpenRZM = bool.Parse(node.ChildNodes[35].InnerText.Trim());
            site.DisabledLoginTime = int.Parse(node.ChildNodes[36].InnerText.Trim());
            site.IsOpenInvite = bool.Parse(node.ChildNodes[37].InnerText.Trim());
            site.GNumber = int.Parse(node.ChildNodes[38].InnerText.Trim());
            site.G_Score = int.Parse(node.ChildNodes[39].InnerText.Trim());
            site.G_Day = int.Parse(node.ChildNodes[40].InnerText.Trim());
            site.LoginScore = int.Parse(node.ChildNodes[41].InnerText.Trim());
            site.UserClassCount = int.Parse(node.ChildNodes[42].InnerText.Trim());
            site.IsOpenRegLink = bool.Parse(node.ChildNodes[43].InnerText.Trim());
            site.IsCheckLink = bool.Parse(node.ChildNodes[44].InnerText.Trim());
            return site;
        }

        public void SetInfoSite(M_InfoSite model)
        {
            string path = this.DirName + @"\infosite.config";
            if (!File.Exists(path))
            {
                XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("InfoSite");
                writer.WriteElementString("InfoCreateNum", model.InfoCreateNum.ToString());
                writer.WriteElementString("SpecialInfoCreateNum", model.SpecialInfoCreateNum.ToString());
                writer.WriteElementString("SearchTime", model.SearchTime.ToString());
                writer.WriteElementString("SearchResultPageSize", model.SearchResultPageSize.ToString());
                writer.WriteElementString("IsOpenViewerDig", model.IsOpenViewerDig.ToString());
                writer.WriteElementString("ImgUploadType", model.ImgUploadType);
                writer.WriteElementString("VideoUploadType", model.VideoUploadType);
                writer.WriteElementString("AudioUploadType", model.AudioUploadType);
                writer.WriteElementString("SoftUploadType", model.SoftUploadType);
                writer.WriteElementString("OtherUploadType", model.OtherUploadType);
                writer.WriteElementString("HistoryTime", model.HistoryTime.ToString());
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            else
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);
                XmlNode node = document.ChildNodes[1];
                node.ChildNodes[0].InnerText = model.InfoCreateNum.ToString();
                node.ChildNodes[1].InnerText = model.SpecialInfoCreateNum.ToString();
                node.ChildNodes[2].InnerText = model.SearchTime.ToString();
                node.ChildNodes[3].InnerText = model.SearchResultPageSize.ToString();
                node.ChildNodes[4].InnerText = model.IsOpenViewerDig.ToString();
                node.ChildNodes[5].InnerText = model.ImgUploadType;
                node.ChildNodes[6].InnerText = model.VideoUploadType;
                node.ChildNodes[7].InnerText = model.AudioUploadType;
                node.ChildNodes[8].InnerText = model.SoftUploadType;
                node.ChildNodes[9].InnerText = model.OtherUploadType;
                node.ChildNodes[10].InnerText = model.HistoryTime.ToString();
                document.Save(path);
            }
        }

        public void SetSite(M_Site model)
        {
            string path = this.DirName + @"\site.config";
            if (!File.Exists(path))
            {
                XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Site");
                writer.WriteElementString("SequenceNum", model.SequenceNum);
                writer.WriteElementString("SiteName", model.SiteName);
                writer.WriteElementString("Domain", model.Domain);
                writer.WriteElementString("LogoAddress", model.LogoAddress);
                writer.WriteElementString("BannerAddress", model.BannerAddress);
                writer.WriteElementString("CopyRight", model.CopyRight);
                writer.WriteElementString("IsStaticType", model.IsStaticType.ToString());
                writer.WriteElementString("IsAbsPathType", model.IsAbsPathType.ToString());
                writer.WriteElementString("Keyword", model.Keyword);
                writer.WriteElementString("KeyContent", model.KeyContent);
                writer.WriteElementString("IndexTemplatePath", model.IndexTemplatePath);
                writer.WriteElementString("PageType", model.PageType.ToString());
                writer.WriteElementString("EmailServerAddress", model.EmailServerAddress);
                writer.WriteElementString("EmailServerUserName", model.EmailServerUserName);
                writer.WriteElementString("EmailServerUserPass", model.EmailServerUserPass);
                writer.WriteElementString("IsAllowRegsite", model.IsAllowRegsite.ToString());
                writer.WriteElementString("IsTestEmail", model.IsTestEmail.ToString());
                writer.WriteElementString("DefaultUserGroup", model.DefaultUserGroup.ToString());
                writer.WriteElementString("LogErrorNum", model.LogErrorNum.ToString());
                writer.WriteElementString("IsLoginValidate", model.IsLoginValidate.ToString());
                writer.WriteElementString("IsCommentValidate", model.IsCommentValidate.ToString());
                writer.WriteElementString("IsAllowCommentNoName", model.IsAllowCommentNoName.ToString());
                writer.WriteElementString("IsAddCommentEditor", model.IsAddCommentEditor.ToString());
                writer.WriteElementString("FilterStr", model.FilterStr);
                writer.WriteElementString("GUnitName", model.GUnitName);
                writer.WriteElementString("IsImgWaterMark", model.IsImgWaterMark.ToString());
                writer.WriteElementString("WaterMarkStr", model.WaterMarkStr);
                writer.WriteElementString("WaterMarkFontSize", model.WaterMarkFontSize.ToString());
                writer.WriteElementString("WaterMarkFontName", model.WaterMarkFontName);
                writer.WriteElementString("WaterMarkFontColor", model.WaterMarkFontColor);
                writer.WriteElementString("WaterMarkIsBold", model.WaterMarkIsBold.ToString());
                writer.WriteElementString("WaterMarkPath", model.WaterMarkPath);
                writer.WriteElementString("WaterMarkHW", model.WaterMarkHW.ToString());
                writer.WriteElementString("WaterMarkLight", model.WaterMarkLight.ToString());
                writer.WriteElementString("WaterMarkPos", model.WaterMarkPos.ToString());
                writer.WriteElementString("IsOpenRZM", model.IsOpenRZM.ToString());
                writer.WriteElementString("DisabledLoginTime", model.DisabledLoginTime.ToString());
                writer.WriteElementString("IsOpenInvite", model.IsOpenInvite.ToString());
                writer.WriteElementString("G_GNumber", model.GNumber.ToString());
                writer.WriteElementString("G_Score", model.G_Score.ToString());
                writer.WriteElementString("G_Day", model.G_Day.ToString());
                writer.WriteElementString("LoginScore", model.LoginScore.ToString());
                writer.WriteElementString("UserClassCount", model.UserClassCount.ToString());
                writer.WriteElementString("IsOpenRegLink", model.IsOpenRegLink.ToString());
                writer.WriteElementString("IsCheckLink", model.IsCheckLink.ToString());
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            else
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);
                XmlNode node = document.ChildNodes[1];
                node.ChildNodes[0].InnerText = model.SequenceNum;
                node.ChildNodes[1].InnerText = model.SiteName;
                node.ChildNodes[2].InnerText = model.Domain;
                node.ChildNodes[3].InnerText = model.LogoAddress;
                node.ChildNodes[4].InnerText = model.BannerAddress;
                node.ChildNodes[5].InnerText = model.CopyRight;
                node.ChildNodes[6].InnerText = model.IsStaticType.ToString();
                node.ChildNodes[7].InnerText = model.IsAbsPathType.ToString();
                node.ChildNodes[8].InnerText = model.Keyword;
                node.ChildNodes[9].InnerText = model.KeyContent;
                node.ChildNodes[10].InnerText = model.IndexTemplatePath;
                node.ChildNodes[11].InnerText = model.PageType.ToString();
                node.ChildNodes[12].InnerText = model.EmailServerAddress;
                node.ChildNodes[13].InnerText = model.EmailServerUserName;
                node.ChildNodes[14].InnerText = model.EmailServerUserPass;
                node.ChildNodes[15].InnerText = model.IsAllowRegsite.ToString();
                node.ChildNodes[16].InnerText = model.IsTestEmail.ToString();
                node.ChildNodes[17].InnerText = model.DefaultUserGroup.ToString();
                node.ChildNodes[18].InnerText = model.LogErrorNum.ToString();
                node.ChildNodes[19].InnerText = model.IsLoginValidate.ToString();
                node.ChildNodes[20].InnerText = model.IsCommentValidate.ToString();
                node.ChildNodes[21].InnerText = model.IsAllowCommentNoName.ToString();
                node.ChildNodes[22].InnerText = model.IsAddCommentEditor.ToString();
                node.ChildNodes[23].InnerText = model.FilterStr;
                node.ChildNodes[24].InnerText = model.GUnitName;
                node.ChildNodes[25].InnerText = model.IsImgWaterMark.ToString();
                node.ChildNodes[26].InnerText = model.WaterMarkStr;
                node.ChildNodes[27].InnerText = model.WaterMarkFontSize.ToString();
                node.ChildNodes[28].InnerText = model.WaterMarkFontName;
                node.ChildNodes[29].InnerText = model.WaterMarkFontColor;
                node.ChildNodes[30].InnerText = model.WaterMarkIsBold.ToString();
                node.ChildNodes[31].InnerText = model.WaterMarkPath;
                node.ChildNodes[32].InnerText = model.WaterMarkHW.ToString();
                node.ChildNodes[33].InnerText = model.WaterMarkLight.ToString();
                node.ChildNodes[34].InnerText = model.WaterMarkPos.ToString();
                node.ChildNodes[35].InnerText = model.IsOpenRZM.ToString();
                node.ChildNodes[36].InnerText = model.DisabledLoginTime.ToString();
                node.ChildNodes[37].InnerText = model.IsOpenInvite.ToString();
                node.ChildNodes[38].InnerText = model.GNumber.ToString();
                node.ChildNodes[39].InnerText = model.G_Score.ToString();
                node.ChildNodes[40].InnerText = model.G_Day.ToString();
                node.ChildNodes[41].InnerText = model.LoginScore.ToString();
                node.ChildNodes[42].InnerText = model.UserClassCount.ToString();
                node.ChildNodes[43].InnerText = model.IsOpenRegLink.ToString();
                node.ChildNodes[44].InnerText = model.IsCheckLink.ToString();
                document.Save(path);
            }
        }
    }
}

