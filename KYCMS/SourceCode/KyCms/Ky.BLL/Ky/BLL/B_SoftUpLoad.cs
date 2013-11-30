namespace Ky.BLL
{
    using Ky.Common;
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI.HtmlControls;

    public class B_SoftUpLoad
    {
        public string UpLoadSoft(HtmlInputFile FilePicName, string FilePicPath)
        {
            string fileName = Path.GetFileName(FilePicName.PostedFile.FileName);
            string str2 = Path.GetExtension(FilePicName.PostedFile.FileName).ToString();
            bool flag = false;
            B_SiteInfo info = new B_SiteInfo();
            string softUploadType = info.GetInfoModel().SoftUploadType;
            string[] strArray = softUploadType.Split(new char[] { '|' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].ToLower() == str2.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                HttpContext.Current.Response.Write("<script>alert('上传软件格式只能够是：" + softUploadType + "');window.history.go(-1);</script>");
                HttpContext.Current.Response.End();
            }
            if ((((FilePicName.PostedFile.ContentType == "text/asp") || (FilePicName.PostedFile.ContentType == "video/x-ms-asf")) || ((FilePicName.PostedFile.ContentType == "text/html") || (FilePicName.PostedFile.ContentType == "application/xml"))) || (FilePicName.PostedFile.ContentType == "text/plain"))
            {
                HttpContext.Current.Response.Write("<script>alert('上传文件格式不正确,请压缩后再上传');window.history.go(-1);</script>");
                HttpContext.Current.Response.End();
            }
            string str4 = Function.GetFileName();
            string str5 = DateTime.Now.ToString("yyyyMM");
            string path = HttpContext.Current.Server.MapPath(FilePicPath) + str5 + "/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = path + str4 + str2;
            FilePicName.PostedFile.SaveAs(filename);
            return ("/" + str5 + "/" + str4 + str2);
        }
    }
}

