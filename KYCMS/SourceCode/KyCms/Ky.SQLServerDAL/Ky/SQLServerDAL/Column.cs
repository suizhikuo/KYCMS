namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Column : IColumn
    {
        public int Add(M_Column model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ChId", SqlDbType.Int, 4), new SqlParameter("@ColName", SqlDbType.NVarChar), new SqlParameter("@ColDirName", SqlDbType.NVarChar), new SqlParameter("@ColParentId", SqlDbType.Int, 4), new SqlParameter("@IsOuterColumn", SqlDbType.Bit, 1), new SqlParameter("@OuterColumnUrl", SqlDbType.VarChar, 255), new SqlParameter("@ColumnImgPath", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@Keyword", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@IsAllowAddInfo", SqlDbType.Bit, 1), new SqlParameter("@ColumnTemplatePath", SqlDbType.NVarChar), new SqlParameter("@InfoTemplatePath", SqlDbType.NVarChar), new SqlParameter("@CommentTemplatePath", SqlDbType.NVarChar), new SqlParameter("@Sort", SqlDbType.Int, 4), new SqlParameter("@IsAllowComment", SqlDbType.Bit, 1), 
                new SqlParameter("@IsCheckComment", SqlDbType.Bit, 1), new SqlParameter("@InfoTableName", SqlDbType.NVarChar), new SqlParameter("@ScoreReward", SqlDbType.Int, 4), new SqlParameter("@PointCount", SqlDbType.Int, 4), new SqlParameter("@ChargeType", SqlDbType.Int, 4), new SqlParameter("@ChargeHourCount", SqlDbType.Int, 4), new SqlParameter("@ChargeViewCount", SqlDbType.Int, 4), new SqlParameter("@IsOpened", SqlDbType.Bit, 1), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 500), new SqlParameter("@ColumnPageType", SqlDbType.Int, 4), new SqlParameter("@InfoPageType", SqlDbType.Int, 4), new SqlParameter("@IsDeleted", SqlDbType.Bit, 1), new SqlParameter("@AddTime", SqlDbType.DateTime)
             };
            commandParameters[0].Value = model.ChId;
            commandParameters[1].Value = model.ColName;
            commandParameters[2].Value = model.ColDirName;
            commandParameters[3].Value = model.ColParentId;
            commandParameters[4].Value = model.IsOuterColumn;
            commandParameters[5].Value = model.OuterColumnUrl;
            commandParameters[6].Value = model.ColumnImgPath;
            commandParameters[7].Value = model.Description;
            commandParameters[8].Value = model.Keyword;
            commandParameters[9].Value = model.Content;
            commandParameters[10].Value = model.IsAllowAddInfo;
            commandParameters[11].Value = model.ColumnTemplatePath;
            commandParameters[12].Value = model.InfoTemplatePath;
            commandParameters[13].Value = model.CommentTemplatePath;
            commandParameters[14].Value = model.Sort;
            commandParameters[15].Value = model.IsAllowComment;
            commandParameters[16].Value = model.IsCheckComment;
            commandParameters[17].Value = model.InfoTableName;
            commandParameters[18].Value = model.ScoreReward;
            commandParameters[19].Value = model.PointCount;
            commandParameters[20].Value = model.ChargeType;
            commandParameters[21].Value = model.ChargeHourCount;
            commandParameters[22].Value = model.ChargeViewCount;
            commandParameters[23].Value = model.IsOpened;
            commandParameters[24].Value = model.GroupIdStr;
            commandParameters[25].Value = model.ColumnPageType;
            commandParameters[26].Value = model.InfoPageType;
            commandParameters[27].Value = model.IsDeleted;
            commandParameters[28].Value = model.AddTime;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_Add", commandParameters));
        }

        public void CompleteDelete(int colId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@colid", colId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_CompleteDelete", commandParameters);
        }

        public void Delete(int chId, string colStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ChId", chId), new SqlParameter("@ColIdStr", colStr) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_Delete", commandParameters);
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_GetAll", null);
        }

        public void Move(int colId, int targetId, bool isChannel, string childIdStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ColId", colId), new SqlParameter("@TargetId", targetId), new SqlParameter("@IsChannel", isChannel), new SqlParameter("@ChildIdStr", childIdStr) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_Move", commandParameters);
        }

        public int Update(M_Column model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@ChId", SqlDbType.Int, 4), new SqlParameter("@ColName", SqlDbType.NVarChar), new SqlParameter("@ColDirName", SqlDbType.NVarChar), new SqlParameter("@ColParentId", SqlDbType.Int, 4), new SqlParameter("@IsOuterColumn", SqlDbType.Bit, 1), new SqlParameter("@OuterColumnUrl", SqlDbType.VarChar, 255), new SqlParameter("@ColumnImgPath", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@Keyword", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@IsAllowAddInfo", SqlDbType.Bit, 1), new SqlParameter("@ColumnTemplatePath", SqlDbType.NVarChar), new SqlParameter("@InfoTemplatePath", SqlDbType.NVarChar), new SqlParameter("@CommentTemplatePath", SqlDbType.NVarChar), new SqlParameter("@Sort", SqlDbType.Int, 4), 
                new SqlParameter("@IsAllowComment", SqlDbType.Bit, 1), new SqlParameter("@IsCheckComment", SqlDbType.Bit, 1), new SqlParameter("@InfoTableName", SqlDbType.NVarChar), new SqlParameter("@ScoreReward", SqlDbType.Int, 4), new SqlParameter("@PointCount", SqlDbType.Int, 4), new SqlParameter("@ChargeType", SqlDbType.Int, 4), new SqlParameter("@ChargeHourCount", SqlDbType.Int, 4), new SqlParameter("@ChargeViewCount", SqlDbType.Int, 4), new SqlParameter("@IsOpened", SqlDbType.Bit, 1), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 500), new SqlParameter("@ColumnPageType", SqlDbType.Int, 4), new SqlParameter("@InfoPageType", SqlDbType.Int, 4)
             };
            commandParameters[0].Value = model.ColId;
            commandParameters[1].Value = model.ChId;
            commandParameters[2].Value = model.ColName;
            commandParameters[3].Value = model.ColDirName;
            commandParameters[4].Value = model.ColParentId;
            commandParameters[5].Value = model.IsOuterColumn;
            commandParameters[6].Value = model.OuterColumnUrl;
            commandParameters[7].Value = model.ColumnImgPath;
            commandParameters[8].Value = model.Description;
            commandParameters[9].Value = model.Keyword;
            commandParameters[10].Value = model.Content;
            commandParameters[11].Value = model.IsAllowAddInfo;
            commandParameters[12].Value = model.ColumnTemplatePath;
            commandParameters[13].Value = model.InfoTemplatePath;
            commandParameters[14].Value = model.CommentTemplatePath;
            commandParameters[15].Value = model.Sort;
            commandParameters[16].Value = model.IsAllowComment;
            commandParameters[17].Value = model.IsCheckComment;
            commandParameters[18].Value = model.InfoTableName;
            commandParameters[19].Value = model.ScoreReward;
            commandParameters[20].Value = model.PointCount;
            commandParameters[21].Value = model.ChargeType;
            commandParameters[22].Value = model.ChargeHourCount;
            commandParameters[23].Value = model.ChargeViewCount;
            commandParameters[24].Value = model.IsOpened;
            commandParameters[25].Value = model.GroupIdStr;
            commandParameters[26].Value = model.ColumnPageType;
            commandParameters[27].Value = model.InfoPageType;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_Update", commandParameters);
            return model.ColId;
        }

        public void UpdateActionTableTemplate(int ColId, string ActionTable, string InfoTemplatePath)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@TableName", SqlDbType.NVarChar), new SqlParameter("@InfoTemplatePath", SqlDbType.VarChar) };
            commandParameters[0].Value = ColId;
            commandParameters[1].Value = ActionTable;
            commandParameters[2].Value = InfoTemplatePath;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_SetInfoTemplate", commandParameters);
        }

        public void UpdateTemplate(M_Column model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@ColumnTemplatePath", SqlDbType.NVarChar), new SqlParameter("@InfoTemplatePath", SqlDbType.NVarChar), new SqlParameter("@CommentTemplatePath", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.ColId;
            commandParameters[1].Value = model.ColumnTemplatePath;
            commandParameters[2].Value = model.InfoTemplatePath;
            commandParameters[3].Value = model.CommentTemplatePath;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Column_Update_Template", commandParameters);
        }
    }
}

