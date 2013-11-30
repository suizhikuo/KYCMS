namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Image : IImage
    {
        private Ky.SQLServerDAL.InfoOper InfoOper = new Ky.SQLServerDAL.InfoOper();
        private const string TABLENAME = "kyimage";

        public int Add(M_Image model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@TitleColor", SqlDbType.NVarChar), new SqlParameter("@TitleFontType", SqlDbType.Int, 4), new SqlParameter("@TitleType", SqlDbType.Int, 4), new SqlParameter("@TitleImgPath", SqlDbType.VarChar, 255), new SqlParameter("@UId", SqlDbType.Int, 4), new SqlParameter("@UName", SqlDbType.NVarChar), new SqlParameter("@UserType", SqlDbType.Int, 4), new SqlParameter("@AdminUId", SqlDbType.Int, 4), new SqlParameter("@AdminUName", SqlDbType.Char, 10), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@HitCount", SqlDbType.Int, 4), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@UpdateTime", SqlDbType.DateTime), new SqlParameter("@TemplatePath", SqlDbType.VarChar, 255), 
                new SqlParameter("@PageType", SqlDbType.Int, 4), new SqlParameter("@IsCreated", SqlDbType.Bit, 1), new SqlParameter("@UserCateId", SqlDbType.Int, 4), new SqlParameter("@PointCount", SqlDbType.Int, 4), new SqlParameter("@ChargeType", SqlDbType.Int, 4), new SqlParameter("@ChargeHourCount", SqlDbType.Int, 4), new SqlParameter("@ChargeViewCount", SqlDbType.Int, 4), new SqlParameter("@IsOpened", SqlDbType.Int, 4), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 0x3e8), new SqlParameter("@IsDeleted", SqlDbType.Bit, 1), new SqlParameter("@IsRecommend", SqlDbType.Bit, 1), new SqlParameter("@IsTop", SqlDbType.Bit, 1), new SqlParameter("@IsFocus", SqlDbType.Bit, 1), new SqlParameter("@IsSideShow", SqlDbType.Bit, 1), new SqlParameter("@TagIdStr", SqlDbType.VarChar, 300), new SqlParameter("@IsAllowComment", SqlDbType.Bit, 1), 
                new SqlParameter("@TagNameStr", SqlDbType.NVarChar), new SqlParameter("@SpecialIdStr", SqlDbType.VarChar, 500), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@ImgPath", SqlDbType.NText), new SqlParameter("@Identity", SqlDbType.Int, 4)
             };
            commandParameters[0].Value = model.ColId;
            commandParameters[1].Value = model.Title;
            commandParameters[2].Value = model.TitleColor;
            commandParameters[3].Value = model.TitleFontType;
            commandParameters[4].Value = model.TitleType;
            commandParameters[5].Value = model.TitleImgPath;
            commandParameters[6].Value = model.UId;
            commandParameters[7].Value = model.UName;
            commandParameters[8].Value = model.UserType;
            commandParameters[9].Value = model.AdminUId;
            commandParameters[10].Value = model.AdminUName;
            commandParameters[11].Value = model.Status;
            commandParameters[12].Value = model.HitCount;
            commandParameters[13].Value = model.AddTime;
            commandParameters[14].Value = model.UpdateTime;
            commandParameters[15].Value = model.TemplatePath;
            commandParameters[16].Value = model.PageType;
            commandParameters[17].Value = model.IsCreated;
            commandParameters[18].Value = model.UserCateId;
            commandParameters[19].Value = model.PointCount;
            commandParameters[20].Value = model.ChargeType;
            commandParameters[21].Value = model.ChargeHourCount;
            commandParameters[22].Value = model.ChargeViewCount;
            commandParameters[23].Value = model.IsOpened;
            commandParameters[24].Value = model.GroupIdStr;
            commandParameters[25].Value = model.IsDeleted;
            commandParameters[26].Value = model.IsRecommend;
            commandParameters[27].Value = model.IsTop;
            commandParameters[28].Value = model.IsFocus;
            commandParameters[29].Value = model.IsSideShow;
            commandParameters[30].Value = model.TagIdStr;
            commandParameters[31].Value = model.IsAllowComment;
            commandParameters[32].Value = model.TagNameStr;
            commandParameters[33].Value = model.SpecialIdStr;
            commandParameters[34].Value = model.Content;
            commandParameters[35].Value = model.ImgPath;
            commandParameters[36].Value = 0;
            commandParameters[36].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Image_Add", commandParameters);
            return (int) commandParameters[36].Value;
        }

        public M_Image GetItem(int imgId)
        {
            DataRow info = this.InfoOper.GetInfo("kyimage", imgId);
            if (info == null)
            {
                return null;
            }
            M_Image image = new M_Image();
            image.Id = imgId;
            if (info["ColId"].ToString() != "")
            {
                image.ColId = int.Parse(info["ColId"].ToString());
            }
            image.Title = info["Title"].ToString();
            image.TitleColor = info["TitleColor"].ToString();
            if (info["TitleFontType"].ToString() != "")
            {
                image.TitleFontType = int.Parse(info["TitleFontType"].ToString());
            }
            if (info["TitleType"].ToString() != "")
            {
                image.TitleType = int.Parse(info["TitleType"].ToString());
            }
            image.TitleImgPath = info["TitleImgPath"].ToString();
            if (info["UId"].ToString() != "")
            {
                image.UId = int.Parse(info["UId"].ToString());
            }
            image.UName = info["UName"].ToString();
            if (info["UserType"].ToString() != "")
            {
                image.UserType = int.Parse(info["UserType"].ToString());
            }
            if (info["AdminUId"].ToString() != "")
            {
                image.AdminUId = int.Parse(info["AdminUId"].ToString());
            }
            image.AdminUName = info["AdminUName"].ToString();
            if (info["Status"].ToString() != "")
            {
                image.Status = int.Parse(info["Status"].ToString());
            }
            if (info["HitCount"].ToString() != "")
            {
                image.HitCount = int.Parse(info["HitCount"].ToString());
            }
            if (info["AddTime"].ToString() != "")
            {
                image.AddTime = DateTime.Parse(info["AddTime"].ToString());
            }
            if (info["UpdateTime"].ToString() != "")
            {
                image.UpdateTime = DateTime.Parse(info["UpdateTime"].ToString());
            }
            image.TemplatePath = info["TemplatePath"].ToString();
            if (info["PageType"].ToString() != "")
            {
                image.PageType = int.Parse(info["PageType"].ToString());
            }
            if (info["IsCreated"].ToString() != "")
            {
                if ((info["IsCreated"].ToString() == "1") || (info["IsCreated"].ToString().ToLower() == "true"))
                {
                    image.IsCreated = true;
                }
                else
                {
                    image.IsCreated = false;
                }
            }
            if (info["UserCateId"].ToString() != "")
            {
                image.UserCateId = int.Parse(info["UserCateId"].ToString());
            }
            if (info["PointCount"].ToString() != "")
            {
                image.PointCount = int.Parse(info["PointCount"].ToString());
            }
            if (info["ChargeType"].ToString() != "")
            {
                image.ChargeType = int.Parse(info["ChargeType"].ToString());
            }
            if (info["ChargeHourCount"].ToString() != "")
            {
                image.ChargeHourCount = int.Parse(info["ChargeHourCount"].ToString());
            }
            if (info["ChargeViewCount"].ToString() != "")
            {
                image.ChargeViewCount = int.Parse(info["ChargeViewCount"].ToString());
            }
            if (info["IsOpened"].ToString() != "")
            {
                image.IsOpened = int.Parse(info["IsOpened"].ToString());
            }
            image.GroupIdStr = info["GroupIdStr"].ToString();
            if (info["IsDeleted"].ToString() != "")
            {
                if ((info["IsDeleted"].ToString() == "1") || (info["IsDeleted"].ToString().ToLower() == "true"))
                {
                    image.IsDeleted = true;
                }
                else
                {
                    image.IsDeleted = false;
                }
            }
            if (info["IsRecommend"].ToString() != "")
            {
                if ((info["IsRecommend"].ToString() == "1") || (info["IsRecommend"].ToString().ToLower() == "true"))
                {
                    image.IsRecommend = true;
                }
                else
                {
                    image.IsRecommend = false;
                }
            }
            if (info["IsTop"].ToString() != "")
            {
                if ((info["IsTop"].ToString() == "1") || (info["IsTop"].ToString().ToLower() == "true"))
                {
                    image.IsTop = true;
                }
                else
                {
                    image.IsTop = false;
                }
            }
            if (info["IsFocus"].ToString() != "")
            {
                if ((info["IsFocus"].ToString() == "1") || (info["IsFocus"].ToString().ToLower() == "true"))
                {
                    image.IsFocus = true;
                }
                else
                {
                    image.IsFocus = false;
                }
            }
            if (info["IsSideShow"].ToString() != "")
            {
                if ((info["IsSideShow"].ToString() == "1") || (info["IsSideShow"].ToString().ToLower() == "true"))
                {
                    image.IsSideShow = true;
                }
                else
                {
                    image.IsSideShow = false;
                }
            }
            image.TagIdStr = info["TagIdStr"].ToString();
            if (info["IsAllowComment"].ToString() != "")
            {
                if ((info["IsAllowComment"].ToString() == "1") || (info["IsAllowComment"].ToString().ToLower() == "true"))
                {
                    image.IsAllowComment = true;
                }
                else
                {
                    image.IsAllowComment = false;
                }
            }
            image.TagNameStr = info["TagNameStr"].ToString();
            image.SpecialIdStr = info["SpecialIdStr"].ToString();
            image.Content = info["Content"].ToString();
            image.ImgPath = info["ImgPath"].ToString();
            return image;
        }

        public void Update(M_Image model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@TitleColor", SqlDbType.NVarChar), new SqlParameter("@TitleFontType", SqlDbType.Int, 4), new SqlParameter("@TitleType", SqlDbType.Int, 4), new SqlParameter("@TitleImgPath", SqlDbType.VarChar, 255), new SqlParameter("@UId", SqlDbType.Int, 4), new SqlParameter("@UName", SqlDbType.NVarChar), new SqlParameter("@UserType", SqlDbType.Int, 4), new SqlParameter("@AdminUId", SqlDbType.Int, 4), new SqlParameter("@AdminUName", SqlDbType.Char, 10), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@HitCount", SqlDbType.Int, 4), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@UpdateTime", SqlDbType.DateTime), 
                new SqlParameter("@TemplatePath", SqlDbType.VarChar, 255), new SqlParameter("@PageType", SqlDbType.Int, 4), new SqlParameter("@IsCreated", SqlDbType.Bit, 1), new SqlParameter("@UserCateId", SqlDbType.Int, 4), new SqlParameter("@PointCount", SqlDbType.Int, 4), new SqlParameter("@ChargeType", SqlDbType.Int, 4), new SqlParameter("@ChargeHourCount", SqlDbType.Int, 4), new SqlParameter("@ChargeViewCount", SqlDbType.Int, 4), new SqlParameter("@IsOpened", SqlDbType.Int, 4), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 0x3e8), new SqlParameter("@IsDeleted", SqlDbType.Bit, 1), new SqlParameter("@IsRecommend", SqlDbType.Bit, 1), new SqlParameter("@IsTop", SqlDbType.Bit, 1), new SqlParameter("@IsFocus", SqlDbType.Bit, 1), new SqlParameter("@IsSideShow", SqlDbType.Bit, 1), new SqlParameter("@TagIdStr", SqlDbType.VarChar, 300), 
                new SqlParameter("@IsAllowComment", SqlDbType.Bit, 1), new SqlParameter("@TagNameStr", SqlDbType.NVarChar), new SqlParameter("@SpecialIdStr", SqlDbType.VarChar, 500), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@ImgPath", SqlDbType.NText)
             };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.ColId;
            commandParameters[2].Value = model.Title;
            commandParameters[3].Value = model.TitleColor;
            commandParameters[4].Value = model.TitleFontType;
            commandParameters[5].Value = model.TitleType;
            commandParameters[6].Value = model.TitleImgPath;
            commandParameters[7].Value = model.UId;
            commandParameters[8].Value = model.UName;
            commandParameters[9].Value = model.UserType;
            commandParameters[10].Value = model.AdminUId;
            commandParameters[11].Value = model.AdminUName;
            commandParameters[12].Value = model.Status;
            commandParameters[13].Value = model.HitCount;
            commandParameters[14].Value = model.AddTime;
            commandParameters[15].Value = model.UpdateTime;
            commandParameters[16].Value = model.TemplatePath;
            commandParameters[17].Value = model.PageType;
            commandParameters[18].Value = model.IsCreated;
            commandParameters[19].Value = model.UserCateId;
            commandParameters[20].Value = model.PointCount;
            commandParameters[21].Value = model.ChargeType;
            commandParameters[22].Value = model.ChargeHourCount;
            commandParameters[23].Value = model.ChargeViewCount;
            commandParameters[24].Value = model.IsOpened;
            commandParameters[25].Value = model.GroupIdStr;
            commandParameters[26].Value = model.IsDeleted;
            commandParameters[27].Value = model.IsRecommend;
            commandParameters[28].Value = model.IsTop;
            commandParameters[29].Value = model.IsFocus;
            commandParameters[30].Value = model.IsSideShow;
            commandParameters[31].Value = model.TagIdStr;
            commandParameters[32].Value = model.IsAllowComment;
            commandParameters[33].Value = model.TagNameStr;
            commandParameters[34].Value = model.SpecialIdStr;
            commandParameters[35].Value = model.Content;
            commandParameters[36].Value = model.ImgPath;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Image_Update", commandParameters);
        }
    }
}

