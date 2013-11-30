namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Article : IArticle
    {
        private Ky.SQLServerDAL.InfoOper InfoOper = new Ky.SQLServerDAL.InfoOper();
        private const string TABLENAME = "kyarticle";

        public int Add(M_Article model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@TitleColor", SqlDbType.NVarChar), new SqlParameter("@TitleFontType", SqlDbType.Int, 4), new SqlParameter("@TitleType", SqlDbType.Int, 4), new SqlParameter("@TitleImgPath", SqlDbType.VarChar, 255), new SqlParameter("@UId", SqlDbType.Int, 4), new SqlParameter("@UName", SqlDbType.NVarChar), new SqlParameter("@UserType", SqlDbType.Int, 4), new SqlParameter("@AdminUId", SqlDbType.Int, 4), new SqlParameter("@AdminUName", SqlDbType.NVarChar), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@HitCount", SqlDbType.Int, 4), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@UpdateTime", SqlDbType.DateTime), 
                new SqlParameter("@TemplatePath", SqlDbType.VarChar, 255), new SqlParameter("@PageType", SqlDbType.Int, 4), new SqlParameter("@IsCreated", SqlDbType.Bit, 1), new SqlParameter("@UserCateId", SqlDbType.Int, 4), new SqlParameter("@PointCount", SqlDbType.Int, 4), new SqlParameter("@ChargeType", SqlDbType.Int, 4), new SqlParameter("@ChargeHourCount", SqlDbType.Int, 4), new SqlParameter("@ChargeViewCount", SqlDbType.Int, 4), new SqlParameter("@IsOpened", SqlDbType.Int, 4), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 200), new SqlParameter("@IsDeleted", SqlDbType.Bit, 1), new SqlParameter("@IsRecommend", SqlDbType.Bit, 1), new SqlParameter("@IsTop", SqlDbType.Bit, 1), new SqlParameter("@IsFocus", SqlDbType.Bit, 1), new SqlParameter("@IsSideShow", SqlDbType.Bit, 1), new SqlParameter("@TagIdStr", SqlDbType.VarChar, 300), 
                new SqlParameter("@TagNameStr", SqlDbType.NVarChar), new SqlParameter("@SpecialIdStr", SqlDbType.VarChar, 200), new SqlParameter("@LongTitle", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@ShortContent", SqlDbType.NVarChar), new SqlParameter("@OuterUrl", SqlDbType.VarChar, 255), new SqlParameter("@Author", SqlDbType.NVarChar), new SqlParameter("@Source", SqlDbType.NVarChar), new SqlParameter("@IsHeader", SqlDbType.Bit, 1), new SqlParameter("@HeaderFont", SqlDbType.NVarChar), new SqlParameter("@HeaderImgPath", SqlDbType.VarChar, 255), new SqlParameter("@StarLevel", SqlDbType.NVarChar), new SqlParameter("@IsShowCommentLink", SqlDbType.Bit, 1), new SqlParameter("@IsIrregular", SqlDbType.Bit, 1), new SqlParameter("@IrregularId", SqlDbType.Int, 4), new SqlParameter("@ViewUName", SqlDbType.NText), 
                new SqlParameter("@ViewUName2", SqlDbType.NText), new SqlParameter("@ViewEndTime", SqlDbType.NVarChar), new SqlParameter("@IsAllowComment", SqlDbType.Bit, 1), new SqlParameter("@ExpireTime", SqlDbType.DateTime)
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
            commandParameters[32].Value = model.TagNameStr;
            commandParameters[33].Value = model.SpecialIdStr;
            commandParameters[34].Value = model.LongTitle;
            commandParameters[35].Value = model.Content;
            commandParameters[36].Value = model.ShortContent;
            commandParameters[37].Value = model.OuterUrl;
            commandParameters[38].Value = model.Author;
            commandParameters[39].Value = model.Source;
            commandParameters[40].Value = model.IsHeader;
            commandParameters[41].Value = model.HeaderFont;
            commandParameters[42].Value = model.HeaderImgPath;
            commandParameters[43].Value = model.StarLevel;
            commandParameters[44].Value = model.IsShowCommentLink;
            commandParameters[45].Value = model.IsIrregular;
            commandParameters[46].Value = model.IrregularId;
            commandParameters[47].Value = model.ViewUName;
            commandParameters[48].Value = model.ViewUName2;
            commandParameters[49].Value = model.ViewEndTime;
            commandParameters[50].Value = model.IsAllowComment;
            commandParameters[51].Value = model.ExpireTime;
            commandParameters[0].Direction = ParameterDirection.InputOutput;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "up_Article_Set", commandParameters);
            return int.Parse(commandParameters[0].Value.ToString());
        }

        public M_Article GetArticle(int Id)
        {
            DataRow info = this.InfoOper.GetInfo("kyarticle", Id);
            if (info == null)
            {
                return null;
            }
            M_Article article = new M_Article();
            article.Id = int.Parse(info["Id"].ToString());
            article.ColId = int.Parse(info["ColId"].ToString());
            article.Title = info["Title"].ToString();
            article.TitleColor = info["TitleColor"].ToString();
            article.TitleFontType = int.Parse(info["TitleFontType"].ToString());
            article.TitleType = int.Parse(info["TitleType"].ToString());
            article.TitleImgPath = info["TitleImgPath"].ToString();
            article.UId = int.Parse(info["UId"].ToString());
            article.UName = info["UName"].ToString();
            article.UserType = int.Parse(info["UserType"].ToString());
            article.AdminUId = int.Parse(info["AdminUId"].ToString());
            article.AdminUName = info["AdminUName"].ToString();
            article.Status = int.Parse(info["Status"].ToString());
            article.HitCount = int.Parse(info["HitCount"].ToString());
            article.AddTime = DateTime.Parse(info["AddTime"].ToString());
            article.UpdateTime = DateTime.Parse(info["UpdateTime"].ToString());
            article.TemplatePath = info["TemplatePath"].ToString();
            article.PageType = int.Parse(info["PageType"].ToString());
            if (info["IsCreated"].ToString().ToLower() == "true")
            {
                article.IsCreated = true;
            }
            else
            {
                article.IsCreated = false;
            }
            article.UserCateId = int.Parse(info["UserCateId"].ToString());
            article.PointCount = int.Parse(info["PointCount"].ToString());
            article.ChargeType = int.Parse(info["ChargeType"].ToString());
            article.ChargeHourCount = int.Parse(info["ChargeHourCount"].ToString());
            article.ChargeViewCount = int.Parse(info["ChargeViewCount"].ToString());
            article.IsOpened = int.Parse(info["IsOpened"].ToString());
            article.GroupIdStr = info["GroupIdStr"].ToString();
            if (info["IsDeleted"].ToString().ToLower() == "true")
            {
                article.IsDeleted = true;
            }
            else
            {
                article.IsDeleted = false;
            }
            if (info["IsRecommend"].ToString().ToLower() == "true")
            {
                article.IsRecommend = true;
            }
            else
            {
                article.IsRecommend = false;
            }
            if (info["IsTop"].ToString().ToLower() == "true")
            {
                article.IsTop = true;
            }
            else
            {
                article.IsTop = false;
            }
            if (info["IsFocus"].ToString().ToLower() == "true")
            {
                article.IsFocus = true;
            }
            else
            {
                article.IsFocus = false;
            }
            if (info["IsSideShow"].ToString().ToLower() == "true")
            {
                article.IsSideShow = true;
            }
            else
            {
                article.IsSideShow = false;
            }
            article.TagIdStr = info["TagIdStr"].ToString();
            article.TagNameStr = info["TagNameStr"].ToString();
            article.SpecialIdStr = info["SpecialIdStr"].ToString();
            article.LongTitle = info["LongTitle"].ToString();
            article.Content = info["Content"].ToString();
            article.ShortContent = info["ShortContent"].ToString();
            article.OuterUrl = info["OuterUrl"].ToString();
            article.Author = info["Author"].ToString();
            article.Source = info["Source"].ToString();
            if (info["IsHeader"].ToString().ToLower() == "true")
            {
                article.IsHeader = true;
            }
            else
            {
                article.IsHeader = false;
            }
            article.HeaderFont = info["HeaderFont"].ToString();
            article.HeaderImgPath = info["HeaderImgPath"].ToString();
            article.StarLevel = info["StarLevel"].ToString();
            if (info["IsShowCommentLink"].ToString().ToLower() == "true")
            {
                article.IsShowCommentLink = true;
            }
            else
            {
                article.IsShowCommentLink = false;
            }
            if (info["IsIrregular"].ToString().ToLower() == "true")
            {
                article.IsIrregular = true;
            }
            else
            {
                article.IsIrregular = false;
            }
            article.IrregularId = int.Parse(info["IrregularId"].ToString());
            article.ViewUName = info["ViewUName"].ToString();
            article.ViewUName2 = info["ViewUName2"].ToString();
            article.ViewEndTime = info["ViewEndTime"].ToString();
            if (info["IsAllowComment"].ToString().ToLower() == "true")
            {
                article.IsAllowComment = true;
            }
            else
            {
                article.IsAllowComment = false;
            }
            article.ExpireTime = DateTime.Parse(info["ExpireTime"].ToString());
            return article;
        }

        public int GetExpireArticleCount(int chId, int colId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", chId), new SqlParameter("@colid", colId) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Article_GetExpireArticleCount", commandParameters));
        }

        public void MoveExprieArticle(int chId, int colId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", chId), new SqlParameter("@colid", colId) };
            SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Article_MoveExpireArticle", commandParameters);
        }

        public void SetViewState(int Id, string viewerName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", Id), new SqlParameter("@viewername", viewerName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Article_SetViewer", commandParameters);
        }

        public int Update(M_Article model)
        {
            return this.Add(model);
        }
    }
}

