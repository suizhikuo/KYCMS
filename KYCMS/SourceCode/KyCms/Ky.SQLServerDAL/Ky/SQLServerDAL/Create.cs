namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class Create : ICreate
    {
        public DataTable GetArticle_HeadeList(int infoCount, int colid, bool isImg)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@infocount", infoCount), new SqlParameter("@colid", colid), new SqlParameter("@isimg", isImg) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_Article_HeaderList", commandParameters);
        }

        public DataTable GetChannel_Column_InfoList(int chId, int colCount, string colIdStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", chId), new SqlParameter("@colcount", colCount), new SqlParameter("@colidstr", colIdStr) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetChannel_Column_InfoList", commandParameters);
        }

        public DataTable GetChannel_InfoList(string tableName, int infoCount, int chid, string typeStr, string dateStr, string orderStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@infocount", infoCount), new SqlParameter("@chid", chid), new SqlParameter("@typestr", typeStr), new SqlParameter("@datestr", dateStr), new SqlParameter("@orderstr", orderStr) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetChannel_InfoList", commandParameters);
        }

        public int GetChannel_SpecialInfoCount(string tableName, int infoCount, string specialIdStr, string dateStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@infocount", infoCount), new SqlParameter("@specialidstr", specialIdStr), new SqlParameter("@datestr", dateStr) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_Ch_GetSpecialInfoCount", commandParameters));
        }

        public DataTable GetChannel_SpecialInfoList(string tableName, int infoCount, string specialIdStr, string dateStr, string orderStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@infocount", infoCount), new SqlParameter("@specialidstr", specialIdStr), new SqlParameter("@datestr", dateStr), new SqlParameter("@orderStr", orderStr) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_Ch_GetSpecialInfoList", commandParameters);
        }

        public DataRow GetCloseInfo(string tableName, int id, int colid, string direct)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@id", id), new SqlParameter("@colid", colid), new SqlParameter("@direct", direct) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetCloseInfo", commandParameters);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return table.Rows[0];
            }
            return null;
        }

        public DataTable GetColumn_ChildCol_InfoList(int colId, int colCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@colid", colId), new SqlParameter("@colcount", colCount) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetColumn_ChildCol_InfoList", commandParameters);
        }

        public int GetColumn_FinallyInfoCount(string tableName, string colIdStr, string dateStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@colidstr", colIdStr), new SqlParameter("@datestr", dateStr) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetColumn_FinallyInfoCount", commandParameters));
        }

        public DataTable GetColumn_FinallyInfoList(string tableName, string colIdStr, string dateStr, string orderStr, bool isPadding, int pageIndex, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@colidstr", colIdStr), new SqlParameter("@datestr", dateStr), new SqlParameter("@orderstr", orderStr), new SqlParameter("@ispadding", isPadding), new SqlParameter("@pageindex", pageIndex), new SqlParameter("@pagesize", pageSize) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetColumn_FinallyInfoList", commandParameters);
        }

        public DataTable GetColumn_FlashInfoList(string tableName, int chId, string colIdStr, int infoCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@chid", chId), new SqlParameter("@colidstr", colIdStr), new SqlParameter("@infocount", infoCount) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetColumn_FlashInfoList", commandParameters);
        }

        public DataTable GetColumn_InfoList(string tableName, int infoCount, string colIdStr, string typeStr, string dateStr, string orderStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@infocount", infoCount), new SqlParameter("@colidstr", colIdStr), new SqlParameter("@typestr", typeStr), new SqlParameter("@datestr", dateStr), new SqlParameter("@orderstr", orderStr) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetColumn_InfoList", commandParameters);
        }

        public DataTable GetColumnAll(string tableName, string colId, int pageIndex, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", SqlDbType.NVarChar), new SqlParameter("@colidstr", SqlDbType.NVarChar), new SqlParameter("@pageindex", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int) };
            commandParameters[0].Value = tableName;
            commandParameters[1].Value = colId;
            commandParameters[2].Value = pageIndex;
            commandParameters[3].Value = pageSize;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetColumn_Info", commandParameters);
        }

        public DataTable GetDateRange(string tableName, string startDate, string endDate, int pageIndex, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", SqlDbType.NVarChar), new SqlParameter("@startdate", SqlDbType.NVarChar, 15), new SqlParameter("@enddate", SqlDbType.NVarChar, 15), new SqlParameter("@pageindex", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int) };
            commandParameters[0].Value = tableName;
            commandParameters[1].Value = startDate;
            commandParameters[2].Value = endDate;
            commandParameters[3].Value = pageIndex;
            commandParameters[4].Value = pageSize;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetDateRange_Info", commandParameters);
        }

        public int GetDigCount(int modelId, int infoId)
        {
            int num = 0;
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", modelId), new SqlParameter("@infoid", infoId) };
            object obj2 = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetDigCount", commandParameters);
            if (obj2 != null)
            {
                num = Convert.ToInt32(obj2);
            }
            return num;
        }

        public DataTable GetField_InfoList(int modelType, string tableName, int chId, int colId, string fieldName, string keyword, int pageIndex, int pageSize, ref int recordCount)
        {
            ArrayList paramList = new ArrayList();
            string str = " i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname ";
            string str2 = string.Format(" [{0}] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid ", tableName);
            string str3 = this.GetSearchCondition(chId, colId, fieldName, keyword, modelType, paramList);
            string cmdText = string.Empty;
            if (pageIndex == 1)
            {
                cmdText = string.Format("select top {0} {1}from{2}where{3}order by i.[id] desc", new object[] { pageSize, str, str2, str3 });
            }
            else
            {
                cmdText = string.Format("select top {0} {1}from{2}where i.[id]<(select min(o.[id]) from(select top {4} i.[id] from{2}where{3}order by i.[id] desc)o) and{3}order by i.[id] desc", new object[] { pageSize, str, str2, str3, (pageIndex - 1) * pageSize });
            }
            SqlParameter[] commandParameters = new SqlParameter[paramList.Count];
            for (int i = 0; i < commandParameters.Length; i++)
            {
                Item item = (Item) paramList[i];
                commandParameters[i] = new SqlParameter(item.Name, item.Value);
            }
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, cmdText, commandParameters);
            cmdText = string.Format("select count(i.[id]) from{0}where{1}", str2, str3);
            recordCount = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.Text, cmdText, commandParameters));
            return table;
        }

        public DataTable GetIdRange(string tableName, int startId, int endId, int pageIndex, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tableName", SqlDbType.NVarChar), new SqlParameter("@startid", SqlDbType.Int), new SqlParameter("@endid", SqlDbType.Int), new SqlParameter("@pageindex", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int) };
            commandParameters[0].Value = tableName;
            commandParameters[1].Value = startId;
            commandParameters[2].Value = endId;
            commandParameters[3].Value = pageIndex;
            commandParameters[4].Value = pageSize;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetIdRange_Info", commandParameters);
        }

        public DataTable GetInfo(string tableName, int cursorPage, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CursorPage", SqlDbType.Int), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@tableName", SqlDbType.NVarChar) };
            commandParameters[0].Value = cursorPage;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = tableName;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetAll_Info", commandParameters);
        }

        public DataTable GetInfo_RelationInfoList(string tableName, int infoCount, string whereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@infocount", infoCount), new SqlParameter("@wherestr", whereStr) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_Info_RelationInfoList", commandParameters);
        }

        public DataRow GetInfoById(string tableName, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int), new SqlParameter("@tableName", SqlDbType.NVarChar) };
            commandParameters[0].Value = id;
            commandParameters[1].Value = tableName;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetId_Info", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        public DataSet GetIrregularr(string tableName, int chId, int pageIndex, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", chId), new SqlParameter("@tablename", tableName), new SqlParameter("@pageindex", pageIndex), new SqlParameter("@pagesize", pageSize) };
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_Irregular_GetInfoList", commandParameters);
        }

        public DataTable GetNewRecordNum(string tableName, int topNum, int pageIndex, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", SqlDbType.NVarChar), new SqlParameter("@topnum", SqlDbType.Int), new SqlParameter("@pageindex", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int) };
            commandParameters[0].Value = tableName;
            commandParameters[1].Value = topNum;
            commandParameters[2].Value = pageIndex;
            commandParameters[3].Value = pageSize;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_GetNewRange_Info", commandParameters);
        }

        private string GetSearchCondition(int chId, int colId, string fieldNameStr, string keywordStr, int modelType, ArrayList paramList)
        {
            Item item = new Item();
            string str = string.Empty;
            if (chId != 0)
            {
                str = str + " co.[chid]=@chid and ";
                item.Name = "@chid";
                item.Value = chId.ToString();
                paramList.Add(item);
            }
            if (colId != 0)
            {
                str = str + " i.[colid]=@colid and ";
                item.Name = "@colid";
                item.Value = colId.ToString();
                paramList.Add(item);
            }
            if ((fieldNameStr.Length != 0) && (keywordStr.Length != 0))
            {
                string[] strArray = fieldNameStr.Split(new char[] { '$' });
                string[] strArray2 = keywordStr.Split(new char[] { '$' });
                for (int i = 0; (i < strArray.Length) && (i < strArray2.Length); i++)
                {
                    string tagName = strArray2[i];
                    string str3 = strArray[i];
                    string str4 = "=";
                    if (tagName != string.Empty)
                    {
                        if ((str3.ToLower() == "tagnamestr") || (str3.ToLower() == "title"))
                        {
                            str4 = " like ";
                            if (str3.ToLower() == "tagnamestr")
                            {
                                Tag tag = new Tag();
                                tag.ClearSearchCount();
                                tag.SetTagSearchCount(tagName, modelType);
                                tagName = "%|" + tagName + "|%";
                            }
                            else
                            {
                                tagName = "%" + tagName + "%";
                            }
                        }
                        str = str + string.Format(" i.[{0}]{1}@{2} and ", str3, str4, str3);
                        item.Name = "@" + str3;
                        item.Value = tagName;
                        paramList.Add(item);
                    }
                }
            }
            return (str + " i.status=3 and i.isdeleted=0 ");
        }

        public int GetSite_SpecialInfoCount(string tableNameStr, int infoCount, string specialIdStr, string dateStr)
        {
            int num;
            if (tableNameStr == string.Empty)
            {
                return 0;
            }
            string[] strArray = tableNameStr.Split(new char[] { ',' });
            StringBuilder builder = new StringBuilder();
            string str = string.Empty;
            if (infoCount > 0)
            {
                str = " top " + infoCount.ToString() + " ";
            }
            string str2 = "select " + str + " i.[id] from ";
            string str3 = " where  i.[addtime]>=@datestr and " + specialIdStr + " i.status=3 and i.isdeleted=0";
            for (num = 0; num < strArray.Length; num++)
            {
                if (num < (strArray.Length - 1))
                {
                    builder.Append(str2);
                    builder.Append(strArray[num]);
                    builder.Append(" i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid ");
                    builder.Append(str3);
                    builder.Append(" union all ");
                }
                else
                {
                    builder.Append(str2);
                    builder.Append(strArray[num]);
                    builder.Append(" i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid ");
                    builder.Append(str3);
                }
            }
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@datestr", dateStr) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, builder.ToString(), commandParameters);
            for (num = table.Rows.Count - 1; (infoCount != 0) && (num > infoCount); num--)
            {
                table.Rows.RemoveAt(num);
            }
            int count = table.Rows.Count;
            table.Dispose();
            return count;
        }

        public DataTable GetSite_SpecialInfoList(string tableNameStr, int infoCount, string specialIdStr, string dateStr, string orderStr)
        {
            int num;
            if (tableNameStr == string.Empty)
            {
                return null;
            }
            string[] strArray = tableNameStr.Split(new char[] { ',' });
            StringBuilder builder = new StringBuilder();
            string str = string.Empty;
            if (infoCount > 0)
            {
                str = " top " + infoCount.ToString() + " ";
            }
            string str2 = "select " + str + " m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname,i.[id],i.[colid],i.[title],i.[TitleColor],i.[TitleFontType],i.[TitleType],i.[TitleImgPath],i.[uid],i.[uname],i.[usertype],i.[uname],i.[adminuid],i.[adminuname],i.[status],i.[hitcount],i.[addtime],i.[updatetime],i.[templatepath],i.[pagetype],i.[isopened],i.[iscreated],i.[usercateid],i.[pointcount],i.[tagnamestr] from ";
            string str3 = " where  i.[addtime]>=@datestr and " + specialIdStr + " i.status=3 and i.isdeleted=0";
            for (num = 0; num < strArray.Length; num++)
            {
                if (num < (strArray.Length - 1))
                {
                    builder.Append(str2);
                    builder.Append(strArray[num]);
                    builder.Append(" i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid ");
                    builder.Append(str3);
                    builder.Append(" union all ");
                }
                else
                {
                    builder.Append(str2);
                    builder.Append(strArray[num]);
                    builder.Append(" i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid ");
                    builder.Append(str3);
                }
            }
            builder.Append(" order by ");
            builder.Append(orderStr);
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@datestr", dateStr) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, builder.ToString(), commandParameters);
            for (num = table.Rows.Count - 1; (infoCount != 0) && (num > infoCount); num--)
            {
                table.Rows.RemoveAt(num);
            }
            return table;
        }

        public void InfoRecordCount(string tableName, string wheStr, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@InputStr", SqlDbType.NVarChar), new SqlParameter("@RecordCount", SqlDbType.Int), new SqlParameter("@tableName", SqlDbType.NVarChar) };
            commandParameters[0].Value = wheStr;
            commandParameters[1].Value = 0;
            commandParameters[1].Direction = ParameterDirection.Output;
            commandParameters[2].Value = tableName;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_InfoRecordCount", commandParameters);
            recordCount = int.Parse(commandParameters[1].Value.ToString());
        }

        public int LastInfoCount(string tableName, int topNum)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tableName", SqlDbType.NVarChar), new SqlParameter("@topnum", SqlDbType.Int) };
            commandParameters[0].Value = tableName;
            commandParameters[1].Value = topNum;
            return (int) SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_ListInfoCount", commandParameters);
        }

        public void SetDigCount(int modelId, int infoId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", modelId), new SqlParameter("@infoid", infoId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Create_SetDigCount", commandParameters);
        }
    }
}

