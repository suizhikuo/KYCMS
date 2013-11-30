namespace Ky.BLL
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;

    public class B_Img
    {
        private IImage dal = DataAccess.CreateImage();

        public int Add(M_Image model)
        {
            return this.dal.Add(model);
        }

        public M_Image GetItem(int imgId)
        {
            return this.dal.GetItem(imgId);
        }

        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int per)
        {
            Image image = Image.FromFile(originalImagePath);
            int width = image.Width;
            int height = image.Height;
            int num3 = 0;
            int num4 = 0;
            if (per <= 0)
            {
                num3 = width;
                num4 = height;
            }
            else
            {
                double num5 = (((double) width) / 100.0) * per;
                double num6 = (((double) height) / 100.0) * per;
                num3 = (int) num5;
                num4 = (int) num6;
            }
            Image image2 = new Bitmap(num3, num4);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(image, new Rectangle(0, 0, num3, num4), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
            try
            {
                image2.Save(thumbnailPath, ImageFormat.Jpeg);
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
                File.Copy(thumbnailPath, originalImagePath, true);
                if (File.Exists(thumbnailPath))
                {
                    File.Delete(thumbnailPath);
                }
            }
            catch (Exception exception)
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
                throw exception;
            }
        }

        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {
            Image image = Image.FromFile(originalImagePath);
            int num = image.Width;
            int num2 = image.Height;
            int num3 = 0;
            int num4 = 0;
            if ((width <= 0) || (height <= 0))
            {
                num3 = num;
                num4 = num2;
            }
            else
            {
                num3 = width;
                num4 = height;
            }
            Image image2 = new Bitmap(num3, num4);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(image, new Rectangle(0, 0, num3, num4), new Rectangle(0, 0, num, num2), GraphicsUnit.Pixel);
            try
            {
                image2.Save(thumbnailPath, ImageFormat.Jpeg);
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
                File.Copy(thumbnailPath, originalImagePath, true);
                if (File.Exists(thumbnailPath))
                {
                    File.Delete(thumbnailPath);
                }
            }
            catch (Exception exception)
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
                throw exception;
            }
        }

        public static void MakeWater(string originalImagePath, string thumbnailPath, string waterImgPath, int height, int width, int alpha, int pos)
        {
            Image image = Image.FromFile(originalImagePath);
            Image image2 = Image.FromFile(Param.SiteRootPath + waterImgPath);
            int srcWidth = width;
            int srcHeight = height;
            if ((srcWidth == 0) || (srcHeight == 0))
            {
                srcWidth = image2.Width;
                srcHeight = image2.Height;
            }
            ImageAttributes imageAttr = new ImageAttributes();
            float num3 = (alpha == 0) ? 1f : (((float) alpha) / 100f);
            float[][] numArray2 = new float[5][];
            float[] numArray3 = new float[5];
            numArray3[0] = 1f;
            numArray2[0] = numArray3;
            numArray3 = new float[5];
            numArray3[1] = 1f;
            numArray2[1] = numArray3;
            numArray3 = new float[5];
            numArray3[2] = 1f;
            numArray2[2] = numArray3;
            numArray3 = new float[5];
            numArray3[3] = num3;
            numArray2[3] = numArray3;
            numArray3 = new float[5];
            numArray3[4] = 1f;
            numArray2[4] = numArray3;
            float[][] newColorMatrix = numArray2;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;
            int x = 0;
            int y = 0;
            if (pos == 1)
            {
                x = 5;
                y = 5;
            }
            else if (pos == 2)
            {
                x = (image.Width - srcWidth) - 5;
                y = 5;
            }
            else if (pos == 3)
            {
                x = (image.Width - srcWidth) - 5;
                y = (image.Height - srcHeight) - 5;
            }
            else
            {
                x = 5;
                y = (image.Height - srcHeight) - 5;
            }
            graphics.DrawImage(image2, new Rectangle(x, y, srcWidth, srcHeight), 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel, imageAttr);
            graphics.Dispose();
            image.Save(thumbnailPath);
            image.Dispose();
            File.Copy(thumbnailPath, originalImagePath, true);
            if (File.Exists(thumbnailPath))
            {
                File.Delete(thumbnailPath);
            }
        }

        public static void MakeWater(string originalImagePath, string thumbnailPath, string content, int size, string name, string color, bool isBold)
        {
            Image image = Image.FromFile(originalImagePath);
            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            Font font = null;
            if (isBold)
            {
                font = new Font(name, (float) size, FontStyle.Bold);
            }
            else
            {
                font = new Font(name, (float) size);
            }
            Brush brush = new SolidBrush(ColorTranslator.FromHtml("#" + color));
            graphics.DrawString(content, font, brush, 5f, (float) ((image.Height - size) - 10));
            image.Save(thumbnailPath);
            graphics.Dispose();
            image.Dispose();
            File.Copy(thumbnailPath, originalImagePath, true);
            if (File.Exists(thumbnailPath))
            {
                File.Delete(thumbnailPath);
            }
        }

        public void Update(M_Image model)
        {
            this.dal.Update(model);
        }
    }
}

