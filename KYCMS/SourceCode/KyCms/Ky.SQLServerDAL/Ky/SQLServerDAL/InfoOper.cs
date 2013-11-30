namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class InfoOper : IInfoOper
    {
        public void AddHitCount(string tableName, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id) };
            SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_AddHitCount", commandParameters);
        }

        public void Auditing(string tableName, int id, int status, int adminId, string adminName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id), new SqlParameter("@status", status), new SqlParameter("@adminid", adminId), new SqlParameter("@adminname", adminName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_Auditing", commandParameters);
        }

        public void Cancel(string tableName, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_Cancel", commandParameters);
        }

        public void CompleteDeleteInfo(string tableName, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_CompleteDeleteInfo", commandParameters);
        }

        public void DeleteInfoToRecycle(string idStr, string tableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@idstr", idStr), new SqlParameter("@tablename", tableName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_DeleteToRecycle", commandParameters);
        }

        public DataSet GetCustomTableList(string TableName, int currPage, int pageSize, string strWhere)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@TableName", SqlDbType.NVarChar, 50), new SqlParameter("@strWhere", SqlDbType.NVarChar, 0x3e8) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = TableName;
            commandParameters[3].Value = strWhere;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomTable_GetList", commandParameters);
        }

        public int GetHitCount(string tableName, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_GetHitCount", commandParameters));
        }

        public DataRow GetInfo(string tableName, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_GetInfo", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        public DataTable GetInfoList(string tableName, string fieldName, string keyword, int chId, string colIdStr, string status, string property, string propertyType, string propertyValue, int userType, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@fieldname", fieldName), new SqlParameter("@keyword", keyword), new SqlParameter("@chId", chId), new SqlParameter("@colidstr", colIdStr), new SqlParameter("@status", status), new SqlParameter("@property", property), new SqlParameter("@propertyType", propertyType), new SqlParameter("@propertyvalue", propertyValue), new SqlParameter("@usertype", userType), new SqlParameter("@pageindex", pageIndex), new SqlParameter("@pagesize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_GetInfoList", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public DataTable GetRecycleInfoList(string tableName, int type, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@type", type), new SqlParameter("@pageindex", pageIndex), new SqlParameter("@pagesize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_GetRecycleInfoList", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public DataTable GetRssInfoList(string tableName, int chId, string colId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@chid", chId), new SqlParameter("@colid", colId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Rss_GetInfoList", commandParameters);
        }

        public DataTable GetSpecialInfoList(string tableNameStr, int specialId)
        {
            if (tableNameStr == string.Empty)
            {
                return null;
            }
            string[] strArray = tableNameStr.Split(new char[] { ',' });
            StringBuilder builder = new StringBuilder();
            string str = "select [id],m.modelname,m.modelid,title,titletype,i.colid,uname,usertype,hitcount,issideshow,istop,isrecommend,isfocus,status from ";
            string str2 = " where specialidstr like '%|" + specialId + "|%' and i.isdeleted=0 ";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i < (strArray.Length - 1))
                {
                    builder.Append(str);
                    builder.Append(strArray[i]);
                    builder.Append(" i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid ");
                    builder.Append(str2);
                    builder.Append(" union all ");
                }
                else
                {
                    builder.Append(str);
                    builder.Append(strArray[i]);
                    builder.Append(" i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid ");
                    builder.Append(str2);
                }
            }
            builder.Append(" order by id desc ");
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, builder.ToString(), new SqlParameter[0]);
        }

        public DataRow GetUserInfo(string tableName, int UserId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@UserId", UserId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_GetUserInfo", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        public DataTable GetUserInfoList(string tableName, int uId, string fieldName, string keyword, int chId, string colIdStr, string status, string property, string propertyType, string propertyValue, int userCateId, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@uid", uId), new SqlParameter("@fieldname", fieldName), new SqlParameter("@keyword", keyword), new SqlParameter("@chId", chId), new SqlParameter("@colidstr", colIdStr), new SqlParameter("@status", status), new SqlParameter("@property", property), new SqlParameter("@propertyType", propertyType), new SqlParameter("@propertyvalue", propertyValue), new SqlParameter("@usercateid", userCateId), new SqlParameter("@pageindex", pageIndex), new SqlParameter("@pagesize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_User_GetInfoList", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public bool IsExistsInfoByUserId(string tableName, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@uid", userId) };
            return (int.Parse(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_User_IsExistsInfo", commandParameters).ToString()) == 1);
        }

        public void MassMoveInfo(string tableName, string idStr, int colid, int targetColId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@idstr", idStr), new SqlParameter("@colid", colid), new SqlParameter("@targetColId", targetColId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_MassMoveInfo", commandParameters);
        }

        public void MassSetInfo(string tableName, string idStr, int colId, bool tagFlag, string tagIdStr, string tagNameStr, bool topFlag, bool isTop, bool recommendFlag, bool isRecommend, bool focusFlag, bool isFocus, bool templatePathFlag, string templatePath, bool hitCountFlag, int hitCount, bool isOpenedFlag, int isOpened, bool groupIdStrFlag, string groupIdStr, bool pointCountFlag, int pointCount, bool chargeTypeFlag, int chargeType, bool chargeHourCountFlag, int chargeHourCount, bool chargeViewCountFlag, int chargeViewCount, bool pageTypeFlag, int pageType)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@tablename", tableName), new SqlParameter("@idstr", idStr), new SqlParameter("@colid", colId), new SqlParameter("@tagflag", tagFlag), new SqlParameter("@tagidstr", tagIdStr), new SqlParameter("@tagnamestr", tagNameStr), new SqlParameter("@topflag", topFlag), new SqlParameter("@istop", isTop), new SqlParameter("@recommendflag", recommendFlag), new SqlParameter("@isrecommend", isRecommend), new SqlParameter("@focusflag", focusFlag), new SqlParameter("@isfocus", isFocus), new SqlParameter("@templatepathflag", templatePathFlag), new SqlParameter("@templatepath", templatePath), new SqlParameter("@hitcountflag", hitCountFlag), new SqlParameter("@hitcount", hitCount), 
                new SqlParameter("@isopenedflag", isOpenedFlag), new SqlParameter("@isopened", isOpened), new SqlParameter("@groupidstrflag", groupIdStrFlag), new SqlParameter("@groupidstr", groupIdStr), new SqlParameter("@pointcountflag", pointCountFlag), new SqlParameter("@pointcount", pointCount), new SqlParameter("@chargetypeflag", chargeTypeFlag), new SqlParameter("@chargetype", chargeType), new SqlParameter("@chargehourcountflag", chargeHourCountFlag), new SqlParameter("@chargehourcount", chargeHourCount), new SqlParameter("@chargeviewcountflag", chargeViewCountFlag), new SqlParameter("@chargeviewcount", chargeHourCount), new SqlParameter("@pagetypeflag", pageTypeFlag), new SqlParameter("@pagetype", pageType)
             };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_MassSetInfo", commandParameters);
        }

        public void RestoreRecycle(string tableName, int type, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", tableName), new SqlParameter("@Type", type), new SqlParameter("@Id", id) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Recycle_Restore", commandParameters);
        }

        public void SetInfoSpecial(string tableName, int id, string specialIdStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id), new SqlParameter("@specialidstr", specialIdStr) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_SetInfoSpecial", commandParameters);
        }

        public void SetProperty(string tableName, string property, string propertyValue, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@property", property), new SqlParameter("@propertyvalue", propertyValue), new SqlParameter("@id", id) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_SetProperty", commandParameters);
        }

        public void SetPublish(string tableName, int id, int uId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id), new SqlParameter("@uid", uId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_User_Publish", commandParameters);
        }

        public void UpdateIsCreated(string tableName, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id) };
            SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_UpdateIsCreated", commandParameters);
        }

        public void UserDeleteInfo(string idStr, string tableName, int uId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@idstr", idStr), new SqlParameter("@tablename", tableName), new SqlParameter("@uid", uId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_User_DeleteInfo", commandParameters);
        }
    }
}

