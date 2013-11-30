namespace Ky.BLL
{
    using Ky.Common;
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI.HtmlControls;

    public class B_UpLoadFile
    {
        public string GetUpLoadFile(HtmlInputFile FilePicName, string FilePicPath, int FileSize)
        {
            if ((FileSize != 0) && (FilePicName.PostedFile.ContentLength > (FileSize * 0x400)))
            {
                HttpContext.Current.Response.Write("<script>alert('上传图片大小超出了限制');window.close();</script>");
                HttpContext.Current.Response.End();
            }
            switch (Path.GetFileName(FilePicName.PostedFile.FileName))
            {
                case "":
                case null:
                    HttpContext.Current.Response.Write("<script language=javascript>alert('请选择需要上传的文件!');window.close();</script>");
                    HttpContext.Current.Response.End();
                    break;
            }
            if (((((((FilePicName.PostedFile.ContentType != "image/gif") && (FilePicName.PostedFile.ContentType != "image/pjpeg")) && ((FilePicName.PostedFile.ContentType != "image/bmp") && (FilePicName.PostedFile.ContentType != "image/x-png"))) && (((FilePicName.PostedFile.ContentType != "image/jpeg") && (FilePicName.PostedFile.ContentType != "application/x-shockwave-flash")) && ((FilePicName.PostedFile.ContentType != "application/vnd.ms-excel") && (FilePicName.PostedFile.ContentType != "application/msword")))) && ((((FilePicName.PostedFile.ContentType != "application/vnd.ms-powerpoint") && (FilePicName.PostedFile.ContentType != "application/octet-stream")) && ((FilePicName.PostedFile.ContentType != "application/x-zip-compressed") && (FilePicName.PostedFile.ContentType != "pplication/vnd.rn-realmedia"))) && (((FilePicName.PostedFile.ContentType != "application/vnd.rn-realmedia-vbr") && (FilePicName.PostedFile.ContentType != "video/x-ms-wmv")) && ((FilePicName.PostedFile.ContentType != "audio/x-ms-wma") && (FilePicName.PostedFile.ContentType != "video/x-ms-asf"))))) && ((((FilePicName.PostedFile.ContentType != "video/avi") && (FilePicName.PostedFile.ContentType != "audio/mp3")) && ((FilePicName.PostedFile.ContentType != "video/mpeg4") && (FilePicName.PostedFile.ContentType != "video/mpg"))) && (((FilePicName.PostedFile.ContentType != "audio/mid") && (FilePicName.PostedFile.ContentType != "video/avi")) && (FilePicName.PostedFile.ContentType != "application/x-rar-compressed")))) && (FilePicName.PostedFile.ContentType != "application/x-zip-compressed"))
            {
                HttpContext.Current.Response.Write("<script>alert('上传文件格式不正确！');window.close();</script>");
                HttpContext.Current.Response.End();
                return "";
            }
            string extension = Path.GetExtension(FilePicName.PostedFile.FileName);
            string fileName = Function.GetFileName();
            string str4 = DateTime.Now.ToString("yyyyMM");
            string path = HttpContext.Current.Server.MapPath(FilePicPath) + str4 + "/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = path + fileName + extension;
            FilePicName.PostedFile.SaveAs(filename);
            return (str4 + "/" + fileName + extension);
        }
    }
}

