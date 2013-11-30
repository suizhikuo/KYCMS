namespace Ky.BLL
{
    using Ky.Common;
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    public class B_ConvertImage
    {
        private string _domainName;
        private string _replacePath;
        private string _uploadPath;

        public B_ConvertImage(string domainName, string uploadPath)
        {
            this._domainName = domainName;
            this._uploadPath = uploadPath;
            this._replacePath = Param.ApplicationRootPath + "/upload/" + this._uploadPath;
        }

        private bool checkIsLocalImage(string imgPath)
        {
            string str = imgPath.ToLower();
            string str2 = this._domainName.ToLower();
            return !(str.StartsWith("http://") && (!str.StartsWith("http://") || !str.StartsWith(str2)));
        }

        public string ConvertContent(string content)
        {
            StringBuilder builder = new StringBuilder(content);
            builder.Replace("{@ModelPath}", this._replacePath);
            return builder.ToString();
        }

        public string ConvertImgePath(string content)
        {
            content = Regex.Replace(content, this._replacePath, "{@ModelPath}", RegexOptions.IgnoreCase);
            return content;
        }

        public string ConvertLocalImagePath(string content)
        {
            string pattern = "<img.*? src=(?:\"|')?(.*?)(?:\"|')? .*?>";
            MatchCollection matchs = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                if (match.Groups.Count > 1)
                {
                    string imgPath = match.Groups[1].Value;
                    string replacement = string.Empty;
                    if (!this.checkIsLocalImage(imgPath))
                    {
                        replacement = this.RemoteSaveImage(imgPath);
                        if (replacement != string.Empty)
                        {
                            content = Regex.Replace(content, imgPath, replacement, RegexOptions.IgnoreCase);
                        }
                    }
                }
            }
            content = Regex.Replace(content, this._replacePath, "{@ModelPath}", RegexOptions.IgnoreCase);
            return content;
        }

        private string RemoteSaveImage(string imgPath)
        {
            string str = @"\upload\" + this._uploadPath + @"\" + DateTime.Now.ToString("yyyyMM");
            if (!Directory.Exists(Param.SiteRootPath + str))
            {
                Directory.CreateDirectory(Param.SiteRootPath + str);
            }
            string extension = Path.GetExtension(imgPath);
            string fileName = Function.GetFileName();
            WebClient client = new WebClient();
            try
            {
                string str4 = Param.SiteRootPath + str + @"\" + fileName + extension;
                string address = imgPath;
                client.DownloadFile(address, str4);
                return (Param.ApplicationRootPath + str.Replace(@"\", "/") + "/" + fileName + extension);
            }
            catch
            {
                client.Dispose();
                return string.Empty;
            }
        }
    }
}

