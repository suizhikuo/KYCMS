namespace Ky.BLL
{
    using Ky.Common;
    using Ky.Model;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    using System.Web.UI.HtmlControls;

    public class B_UpLoadPic
    {
        public string GetUpLoadPicPath(HtmlInputFile FilePicName, string FilePicPath, bool WaterMark, bool NewSize, int MaxWidth, int MaxHeight, bool BiLi, int BiLiValue, int FileSize)
        {
            string fileName = Path.GetFileName(FilePicName.PostedFile.FileName);
            string str2 = Path.GetExtension(FilePicName.PostedFile.FileName).ToString();
            bool flag = false;
            if ((FileSize != 0) && (FilePicName.PostedFile.ContentLength > (FileSize * 0x400)))
            {
                HttpContext.Current.Response.Write("<script>alert('上传图片大小超出了限制');window.close();</script>");
                HttpContext.Current.Response.End();
            }
            B_SiteInfo info = new B_SiteInfo();
            string imgUploadType = info.GetInfoModel().ImgUploadType;
            string[] strArray = imgUploadType.Split(new char[] { '|' });
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
                HttpContext.Current.Response.Write("<script>alert('上传图片格式只能够是：" + imgUploadType + "！');window.close();</script>");
                HttpContext.Current.Response.End();
            }
            M_Site siteModel = new M_Site();
            siteModel = info.GetSiteModel();
            if (NewSize)
            {
                return this.PicNewSize(FilePicName, FilePicPath, WaterMark, MaxWidth, MaxHeight, BiLi, BiLiValue);
            }
            if (WaterMark)
            {
                if (siteModel.IsImgWaterMark)
                {
                    return this.PicWaterMark(FilePicName, FilePicPath, "");
                }
                return this.LetterWaterMark(FilePicName, FilePicPath, "");
            }
            return this.NotWaterMark_NotNewSize(FilePicName, FilePicPath);
        }

        public string LetterWaterMark(HtmlInputFile FilePicName, string FilePicPath, string UpLoadPicPath)
        {
            Font font;
            B_SiteInfo info = new B_SiteInfo();
            M_Site siteModel = new M_Site();
            siteModel = info.GetSiteModel();
            string str = "";
            if (UpLoadPicPath == "")
            {
                str = this.NotWaterMark_NotNewSize(FilePicName, FilePicPath);
            }
            else
            {
                str = UpLoadPicPath;
            }
            string waterMarkStr = siteModel.WaterMarkStr;
            int waterMarkFontSize = siteModel.WaterMarkFontSize;
            string waterMarkFontName = siteModel.WaterMarkFontName;
            string waterMarkFontColor = siteModel.WaterMarkFontColor;
            bool waterMarkIsBold = siteModel.WaterMarkIsBold;
            string path = HttpContext.Current.Server.MapPath(FilePicPath) + str;
            string[] strArray = str.Split(new char[] { '/' });
            string[] strArray2 = strArray[1].Split(new char[] { '.' });
            string destFileName = HttpContext.Current.Server.MapPath(FilePicPath) + strArray[0] + strArray2[0] + "_1" + strArray2[1];
            if (File.Exists(path))
            {
                File.Copy(path, destFileName);
            }
            Image image = Image.FromFile(destFileName);
            Graphics graphics = Graphics.FromImage(image);
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            if (waterMarkIsBold)
            {
                font = new Font(waterMarkFontName, (float) waterMarkFontSize, FontStyle.Bold);
            }
            else
            {
                font = new Font(waterMarkFontName, (float) waterMarkFontSize);
            }
            Brush brush = new SolidBrush(ColorTranslator.FromHtml("#" + waterMarkFontColor));
            string s = waterMarkStr;
            graphics.DrawString(s, font, brush, (float) 0f, (float) 0f);
            graphics.Dispose();
            image.Save(path);
            image.Dispose();
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }
            return str;
        }

        private static Size NewSize(int maxWidth, int maxHeight, int width, int height)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = Convert.ToDouble(width);
            double num4 = Convert.ToDouble(height);
            double num5 = Convert.ToDouble(maxWidth);
            double num6 = Convert.ToDouble(maxHeight);
            if ((num3 < num5) && (num4 < num6))
            {
                num = num3;
                num2 = num4;
            }
            else if ((num3 / num4) > (num5 / num6))
            {
                num = maxWidth;
                num2 = (num * num4) / num3;
            }
            else
            {
                num2 = maxHeight;
                num = (num2 * num3) / num4;
            }
            return new Size(Convert.ToInt32(num), Convert.ToInt32(num2));
        }

        public string NotWaterMark_NotNewSize(HtmlInputFile FilePicName, string FilePicPath)
        {
            switch (Path.GetFileName(FilePicName.PostedFile.FileName))
            {
                case "":
                case null:
                    HttpContext.Current.Response.Write("<script language=javascript>alert('请选择需要上传的文件!');window.close();</script>");
                    HttpContext.Current.Response.End();
                    break;
            }
            if ((((FilePicName.PostedFile.ContentType != "image/gif") && (FilePicName.PostedFile.ContentType != "image/pjpeg")) && ((FilePicName.PostedFile.ContentType != "image/bmp") && (FilePicName.PostedFile.ContentType != "image/x-png"))) && (FilePicName.PostedFile.ContentType != "image/jpeg"))
            {
                HttpContext.Current.Response.Write("<script>alert('上传图片文件格式不正确,图片格式只能够是：gif、jpg、jpeg、png、bmp！');window.close();</script>");
                HttpContext.Current.Response.End();
                return "";
            }
            string str2 = Path.GetExtension(FilePicName.PostedFile.FileName).ToUpper();
            string fileName = Function.GetFileName();
            string str4 = DateTime.Now.ToString("yyyyMM");
            string path = HttpContext.Current.Server.MapPath(FilePicPath) + str4 + "/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = path + fileName + ".jpg";
            string str7 = path + fileName + "_1" + str2;
            FilePicName.PostedFile.SaveAs(str7);
            Image image = Image.FromFile(str7);
            image.Save(filename, ImageFormat.Jpeg);
            image.Dispose();
            if (File.Exists(str7))
            {
                File.Delete(str7);
            }
            return (str4 + "/" + fileName + ".jpg");
        }

        public string PicNewSize(HtmlInputFile FilePicName, string FilePicPath, bool WaterMark, int MaxWidth, int MaxHeight, bool BiLi, int BiLiValue)
        {
            Size size;
            string upLoadPicPath = this.NotWaterMark_NotNewSize(FilePicName, FilePicPath);
            string path = HttpContext.Current.Server.MapPath(FilePicPath) + upLoadPicPath;
            string[] strArray = upLoadPicPath.Split(new char[] { '/' });
            string[] strArray2 = strArray[1].Split(new char[] { '.' });
            string destFileName = HttpContext.Current.Server.MapPath(FilePicPath) + strArray[0] + strArray2[0] + "_1" + strArray2[1];
            if (File.Exists(path))
            {
                File.Copy(path, destFileName);
            }
            Image image = Image.FromFile(destFileName);
            if (BiLi)
            {
                size = NewSize((image.Width * BiLiValue) / 100, (image.Height * BiLiValue) / 100, image.Width, image.Height);
            }
            else
            {
                size = NewSize(MaxWidth, MaxHeight, image.Width, image.Height);
            }
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, new Rectangle(0, 0, size.Width, size.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            graphics.Dispose();
            bitmap.Save(path);
            bitmap.Dispose();
            image.Dispose();
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }
            B_SiteInfo info = new B_SiteInfo();
            M_Site siteModel = new M_Site();
            siteModel = info.GetSiteModel();
            if (!WaterMark)
            {
                return upLoadPicPath;
            }
            if (siteModel.IsImgWaterMark)
            {
                return this.PicWaterMark(FilePicName, FilePicPath, upLoadPicPath);
            }
            return this.LetterWaterMark(FilePicName, FilePicPath, upLoadPicPath);
        }

        public string PicWaterMark(HtmlInputFile FilePicName, string FilePicPath, string UpLoadPicPath)
        {
            B_SiteInfo info = new B_SiteInfo();
            M_Site siteModel = new M_Site();
            siteModel = info.GetSiteModel();
            string[] strArray = siteModel.WaterMarkHW.Split(new char[] { '|' });
            string path = Param.ApplicationRootPath + siteModel.WaterMarkPath;
            int srcHeight = int.Parse(strArray[0]);
            int srcWidth = int.Parse(strArray[1]);
            int waterMarkLight = siteModel.WaterMarkLight;
            int waterMarkPos = siteModel.WaterMarkPos;
            string str2 = "";
            if (UpLoadPicPath == "")
            {
                str2 = this.NotWaterMark_NotNewSize(FilePicName, FilePicPath);
            }
            else
            {
                str2 = UpLoadPicPath;
            }
            string str3 = HttpContext.Current.Server.MapPath(FilePicPath) + str2;
            string[] strArray2 = str2.Split(new char[] { '/' });
            string[] strArray3 = strArray2[1].Split(new char[] { '.' });
            string destFileName = HttpContext.Current.Server.MapPath(FilePicPath) + strArray2[0] + strArray3[0] + "_1" + strArray3[1];
            if (File.Exists(str3))
            {
                File.Copy(str3, destFileName);
            }
            Image image = Image.FromFile(destFileName);
            Image image2 = Image.FromFile(HttpContext.Current.Server.MapPath(path));
            float[][] numArray = new float[5][];
            float[] numArray2 = new float[5];
            numArray2[0] = 1f;
            numArray[0] = numArray2;
            float[] numArray3 = new float[5];
            numArray3[1] = 1f;
            numArray[1] = numArray3;
            float[] numArray4 = new float[5];
            numArray4[2] = 1f;
            numArray[2] = numArray4;
            float[] numArray5 = new float[5];
            numArray5[3] = ((float) waterMarkLight) / 100f;
            numArray[3] = numArray5;
            float[] numArray6 = new float[5];
            numArray6[4] = 1f;
            numArray[4] = numArray6;
            float[][] newColorMatrix = numArray;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Graphics graphics = Graphics.FromImage(image);
            switch (waterMarkPos)
            {
                case 1:
                    graphics.DrawImage(image2, new Rectangle(0, 0, srcWidth, srcHeight), 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel, imageAttr);
                    break;

                case 2:
                    graphics.DrawImage(image2, new Rectangle(image.Width - srcWidth, 0, srcWidth, srcHeight), 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel, imageAttr);
                    break;

                case 3:
                    graphics.DrawImage(image2, new Rectangle(image.Width - srcWidth, image.Height - srcHeight, srcWidth, srcHeight), 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel, imageAttr);
                    break;

                case 4:
                    graphics.DrawImage(image2, new Rectangle(0, image.Height - srcHeight, srcWidth, srcHeight), 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel, imageAttr);
                    break;
            }
            graphics.Dispose();
            image.Save(str3);
            image.Dispose();
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }
            return str2;
        }
    }
}

