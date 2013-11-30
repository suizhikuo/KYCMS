namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Channel : IChannel
    {
        public int Add(M_Channel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ChName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@TemplatePath", SqlDbType.NVarChar), new SqlParameter("@IsChildSite", SqlDbType.Bit, 1), new SqlParameter("@ChildSiteUrl", SqlDbType.NVarChar), new SqlParameter("@IsOpenLink", SqlDbType.Bit, 1), new SqlParameter("@ModelType", SqlDbType.Int, 4), new SqlParameter("@DirName", SqlDbType.NVarChar), new SqlParameter("@TypeName", SqlDbType.NVarChar), new SqlParameter("@TypeUnit", SqlDbType.NVarChar), new SqlParameter("@IsDisabled", SqlDbType.Bit, 1), new SqlParameter("@IsOpened", SqlDbType.Bit, 1), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 500), new SqlParameter("@VerifyType", SqlDbType.Int, 4), new SqlParameter("@Notice1", SqlDbType.NVarChar), new SqlParameter("@Notice2", SqlDbType.NVarChar), 
                new SqlParameter("@Keyword", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@MiniHitCount", SqlDbType.Int, 4), new SqlParameter("@IsStaticType", SqlDbType.Bit, 1), new SqlParameter("@ColumnSortType", SqlDbType.Int, 4), new SqlParameter("@InfoSortType", SqlDbType.Int, 4), new SqlParameter("@FileNameType", SqlDbType.Int, 4), new SqlParameter("@ChannelPageType", SqlDbType.Int, 4), new SqlParameter("@ColumnPageType", SqlDbType.Int, 4), new SqlParameter("@InfoPageType", SqlDbType.Int, 4), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@Sort", SqlDbType.Int, 4), new SqlParameter("@ColumnTemplatePath", SqlDbType.NVarChar), new SqlParameter("@InfoTemplatePath", SqlDbType.NVarChar), new SqlParameter("@CommentTemplatePath", SqlDbType.NVarChar), new SqlParameter("@IsDeleted", SqlDbType.Bit, 1), 
                new SqlParameter("@ChType", SqlDbType.Int, 4)
             };
            commandParameters[0].Value = model.ChName;
            commandParameters[1].Value = model.Description;
            commandParameters[2].Value = model.TemplatePath;
            commandParameters[3].Value = model.IsChildSite;
            commandParameters[4].Value = model.ChildSiteUrl;
            commandParameters[5].Value = model.IsOpenLink;
            commandParameters[6].Value = model.ModelType;
            commandParameters[7].Value = model.DirName;
            commandParameters[8].Value = model.TypeName;
            commandParameters[9].Value = model.TypeUnit;
            commandParameters[10].Value = model.IsDisabled;
            commandParameters[11].Value = model.IsOpened;
            commandParameters[12].Value = model.GroupIdStr;
            commandParameters[13].Value = model.VerifyType;
            commandParameters[14].Value = model.Notice1;
            commandParameters[15].Value = model.Notice2;
            commandParameters[16].Value = model.Keyword;
            commandParameters[17].Value = model.Content;
            commandParameters[18].Value = model.MiniHitCount;
            commandParameters[19].Value = model.IsStaticType;
            commandParameters[20].Value = model.ColumnSortType;
            commandParameters[21].Value = model.InfoSortType;
            commandParameters[22].Value = model.FileNameType;
            commandParameters[23].Value = model.ChannelPageType;
            commandParameters[24].Value = model.ColumnPageType;
            commandParameters[25].Value = model.InfoPageType;
            commandParameters[26].Value = model.AddTime;
            commandParameters[27].Value = model.Sort;
            commandParameters[28].Value = model.ColumnTemplatePath;
            commandParameters[29].Value = model.InfoTemplatePath;
            commandParameters[30].Value = model.CommentTemplatePath;
            commandParameters[31].Value = model.IsDeleted;
            commandParameters[32].Value = model.ChType;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Channel_Add", commandParameters));
        }

        public void CompleteDelete(int chId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", chId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Channel_CompleteDelete", commandParameters);
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ChId", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "up_Channel_Delete", commandParameters);
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Channel_GetAll", null);
        }

        public void SetDisable(int chId, bool isDisabled)
        {
            SqlParameter[] commandParameters = new SqlParameter[2];
            commandParameters[0] = new SqlParameter("@ChId", SqlDbType.Int, 4);
            commandParameters[0].Value = chId;
            commandParameters[1] = new SqlParameter("@IsDisabled", SqlDbType.Bit, 1);
            commandParameters[1].Value = isDisabled;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Channel_SetDisaled", commandParameters);
        }

        public int Update(M_Channel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ChId", SqlDbType.Int, 4), new SqlParameter("@ChName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@TemplatePath", SqlDbType.NVarChar), new SqlParameter("@IsChildSite", SqlDbType.Bit, 1), new SqlParameter("@ChildSiteUrl", SqlDbType.NVarChar), new SqlParameter("@IsOpenLink", SqlDbType.Bit, 1), new SqlParameter("@ModelType", SqlDbType.Int, 4), new SqlParameter("@DirName", SqlDbType.NVarChar), new SqlParameter("@TypeName", SqlDbType.NVarChar), new SqlParameter("@TypeUnit", SqlDbType.NVarChar), new SqlParameter("@IsDisabled", SqlDbType.Bit, 1), new SqlParameter("@IsOpened", SqlDbType.Bit, 1), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 500), new SqlParameter("@VerifyType", SqlDbType.Int, 4), new SqlParameter("@Notice1", SqlDbType.NVarChar), 
                new SqlParameter("@Notice2", SqlDbType.NVarChar), new SqlParameter("@Keyword", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@MiniHitCount", SqlDbType.Int, 4), new SqlParameter("@IsStaticType", SqlDbType.Bit, 1), new SqlParameter("@ColumnSortType", SqlDbType.Int, 4), new SqlParameter("@InfoSortType", SqlDbType.Int, 4), new SqlParameter("@FileNameType", SqlDbType.Int, 4), new SqlParameter("@ChannelPageType", SqlDbType.Int, 4), new SqlParameter("@ColumnPageType", SqlDbType.Int, 4), new SqlParameter("@InfoPageType", SqlDbType.Int, 4), new SqlParameter("@Sort", SqlDbType.Int, 4), new SqlParameter("@ColumnTemplatePath", SqlDbType.NVarChar), new SqlParameter("@InfoTemplatePath", SqlDbType.NVarChar), new SqlParameter("@CommentTemplatePath", SqlDbType.NVarChar), new SqlParameter("@ChType", SqlDbType.Int, 4)
             };
            commandParameters[0].Value = model.ChId;
            commandParameters[1].Value = model.ChName;
            commandParameters[2].Value = model.Description;
            commandParameters[3].Value = model.TemplatePath;
            commandParameters[4].Value = model.IsChildSite;
            commandParameters[5].Value = model.ChildSiteUrl;
            commandParameters[6].Value = model.IsOpenLink;
            commandParameters[7].Value = model.ModelType;
            commandParameters[8].Value = model.DirName;
            commandParameters[9].Value = model.TypeName;
            commandParameters[10].Value = model.TypeUnit;
            commandParameters[11].Value = model.IsDisabled;
            commandParameters[12].Value = model.IsOpened;
            commandParameters[13].Value = model.GroupIdStr;
            commandParameters[14].Value = model.VerifyType;
            commandParameters[15].Value = model.Notice1;
            commandParameters[16].Value = model.Notice2;
            commandParameters[17].Value = model.Keyword;
            commandParameters[18].Value = model.Content;
            commandParameters[19].Value = model.MiniHitCount;
            commandParameters[20].Value = model.IsStaticType;
            commandParameters[21].Value = model.ColumnSortType;
            commandParameters[22].Value = model.InfoSortType;
            commandParameters[23].Value = model.FileNameType;
            commandParameters[24].Value = model.ChannelPageType;
            commandParameters[25].Value = model.ColumnPageType;
            commandParameters[26].Value = model.InfoPageType;
            commandParameters[27].Value = model.Sort;
            commandParameters[28].Value = model.ColumnTemplatePath;
            commandParameters[29].Value = model.InfoTemplatePath;
            commandParameters[30].Value = model.CommentTemplatePath;
            commandParameters[31].Value = model.ChType;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Channel_Update", commandParameters);
            return model.ChId;
        }
    }
}

