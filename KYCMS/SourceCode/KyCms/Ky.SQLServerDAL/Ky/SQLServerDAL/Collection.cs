namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    internal class Collection : ICollection
    {
        public void Add(M_Collection model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ObjectName", SqlDbType.NVarChar), new SqlParameter("@WebSite", SqlDbType.NVarChar), new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@SpecialId", SqlDbType.NVarChar), new SqlParameter("@CharSet", SqlDbType.NVarChar), new SqlParameter("@ListPageUrl", SqlDbType.NVarChar), new SqlParameter("@ObjectDemo", SqlDbType.Text), new SqlParameter("@ListStartCode", SqlDbType.NText), new SqlParameter("@ListEndCode", SqlDbType.NText), new SqlParameter("@LinkStartCode", SqlDbType.NText), new SqlParameter("@LinkEndCode", SqlDbType.NText), new SqlParameter("@PageSet", SqlDbType.NVarChar), new SqlParameter("@ContentPageSet", SqlDbType.NVarChar), new SqlParameter("@FieldListSet", SqlDbType.NText), new SqlParameter("@SimpleFilterRule", SqlDbType.NVarChar), new SqlParameter("@ComplexityFilterRule", SqlDbType.NVarChar), 
                new SqlParameter("@ProterySet", SqlDbType.NVarChar), new SqlParameter("@StarLevel", SqlDbType.NVarChar), new SqlParameter("@HiteCount", SqlDbType.Int, 4)
             };
            commandParameters[0].Value = model.ObjectName;
            commandParameters[1].Value = model.WebSite;
            commandParameters[2].Value = model.ColId;
            commandParameters[3].Value = model.SpecialId;
            commandParameters[4].Value = model.CharSet;
            commandParameters[5].Value = model.ListPageUrl;
            commandParameters[6].Value = model.ObjectDemo;
            commandParameters[7].Value = model.ListStartCode;
            commandParameters[8].Value = model.ListEndCode;
            commandParameters[9].Value = model.LinkStartCode;
            commandParameters[10].Value = model.LinkEndCode;
            commandParameters[11].Value = model.PageSet;
            commandParameters[12].Value = model.ContentPageSet;
            commandParameters[13].Value = model.FieldListSet;
            commandParameters[14].Value = model.SimpleFilterRule;
            commandParameters[15].Value = model.ComplexityFilterRule;
            commandParameters[16].Value = model.ProterySet;
            commandParameters[17].Value = model.StarLevel;
            commandParameters[18].Value = model.HiteCount;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Collection_Add", commandParameters);
        }

        public void CollectionData(string tableName, string fieldName, string fieldValue)
        {
            int num;
            string[] strArray = fieldValue.Split(new char[] { '$' });
            string[] strArray2 = fieldName.Split(new char[] { ',' });
            string str = "";
            string str2 = "";
            for (num = 0; num < strArray2.Length; num++)
            {
                if ((strArray2.Length - 1) == num)
                {
                    str = str + "[" + strArray2[num].ToString() + "])";
                    str2 = str2 + "@" + strArray2[num].ToString() + ")";
                }
                else
                {
                    str = str + "[" + strArray2[num].ToString() + "],";
                    str2 = str2 + "@" + strArray2[num].ToString() + ",";
                }
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into " + tableName + "(");
            builder.Append(str);
            builder.Append(" values (");
            builder.Append(str2);
            SqlParameter[] commandParameters = new SqlParameter[strArray2.Length];
            for (num = 0; num < strArray2.Length; num++)
            {
                commandParameters[num] = new SqlParameter("@" + strArray2[num].ToString(), strArray[num].ToString());
            }
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.Text, builder.ToString(), commandParameters);
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Collection_Delete", commandParameters);
        }

        public M_Collection GetIdByCollection(int Id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = Id;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Collection_GetIdByCollection", commandParameters);
            M_Collection m_s = new M_Collection();
            m_s.Id = Id;
            if (table.Rows.Count > 0)
            {
                m_s.ObjectName = table.Rows[0]["ObjectName"].ToString();
                m_s.WebSite = table.Rows[0]["WebSite"].ToString();
                if (table.Rows[0]["ColId"].ToString() != "")
                {
                    m_s.ColId = int.Parse(table.Rows[0]["ColId"].ToString());
                }
                m_s.SpecialId = table.Rows[0]["SpecialId"].ToString();
                m_s.CharSet = table.Rows[0]["CharSet"].ToString();
                m_s.ListPageUrl = table.Rows[0]["ListPageUrl"].ToString();
                m_s.ObjectDemo = table.Rows[0]["ObjectDemo"].ToString();
                m_s.ListStartCode = table.Rows[0]["ListStartCode"].ToString();
                m_s.ListEndCode = table.Rows[0]["ListEndCode"].ToString();
                m_s.LinkStartCode = table.Rows[0]["LinkStartCode"].ToString();
                m_s.LinkEndCode = table.Rows[0]["LinkEndCode"].ToString();
                m_s.PageSet = table.Rows[0]["PageSet"].ToString();
                m_s.ContentPageSet = table.Rows[0]["ContentPageSet"].ToString();
                m_s.FieldListSet = table.Rows[0]["FieldListSet"].ToString();
                m_s.SimpleFilterRule = table.Rows[0]["SimpleFilterRule"].ToString();
                m_s.ComplexityFilterRule = table.Rows[0]["ComplexityFilterRule"].ToString();
                m_s.ProterySet = table.Rows[0]["ProterySet"].ToString();
                m_s.StarLevel = table.Rows[0]["StarLevel"].ToString();
                if (table.Rows[0]["HiteCount"].ToString() != "")
                {
                    m_s.HiteCount = int.Parse(table.Rows[0]["HiteCount"].ToString());
                }
                return m_s;
            }
            return null;
        }

        public DataTable GetList()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Collection_GetList", null);
        }

        public void Update(M_Collection model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@ObjectName", SqlDbType.NVarChar), new SqlParameter("@WebSite", SqlDbType.NVarChar), new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@SpecialId", SqlDbType.NVarChar), new SqlParameter("@CharSet", SqlDbType.NVarChar), new SqlParameter("@ListPageUrl", SqlDbType.NVarChar), new SqlParameter("@ObjectDemo", SqlDbType.Text), new SqlParameter("@ListStartCode", SqlDbType.NText), new SqlParameter("@ListEndCode", SqlDbType.NText), new SqlParameter("@LinkStartCode", SqlDbType.NText), new SqlParameter("@LinkEndCode", SqlDbType.NText), new SqlParameter("@PageSet", SqlDbType.NVarChar), new SqlParameter("@ContentPageSet", SqlDbType.NVarChar), new SqlParameter("@FieldListSet", SqlDbType.NText), new SqlParameter("@SimpleFilterRule", SqlDbType.NVarChar), 
                new SqlParameter("@ComplexityFilterRule", SqlDbType.NVarChar), new SqlParameter("@ProterySet", SqlDbType.NVarChar), new SqlParameter("@StarLevel", SqlDbType.NVarChar), new SqlParameter("@HiteCount", SqlDbType.Int, 4)
             };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.ObjectName;
            commandParameters[2].Value = model.WebSite;
            commandParameters[3].Value = model.ColId;
            commandParameters[4].Value = model.SpecialId;
            commandParameters[5].Value = model.CharSet;
            commandParameters[6].Value = model.ListPageUrl;
            commandParameters[7].Value = model.ObjectDemo;
            commandParameters[8].Value = model.ListStartCode;
            commandParameters[9].Value = model.ListEndCode;
            commandParameters[10].Value = model.LinkStartCode;
            commandParameters[11].Value = model.LinkEndCode;
            commandParameters[12].Value = model.PageSet;
            commandParameters[13].Value = model.ContentPageSet;
            commandParameters[14].Value = model.FieldListSet;
            commandParameters[15].Value = model.SimpleFilterRule;
            commandParameters[16].Value = model.ComplexityFilterRule;
            commandParameters[17].Value = model.ProterySet;
            commandParameters[18].Value = model.StarLevel;
            commandParameters[19].Value = model.HiteCount;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Collection_Update", commandParameters);
        }
    }
}

