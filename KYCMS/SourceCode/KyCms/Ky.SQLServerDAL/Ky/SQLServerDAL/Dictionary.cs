namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Dictionary : IDictionary
    {
        public int Add(M_Dictionary model)
        {
            return this.Set(1, model);
        }

        public int Delete(int id)
        {
            M_Dictionary model = new M_Dictionary();
            model.Id = id;
            model.DicName = "";
            return this.Set(3, model);
        }

        private DataSet Get(int type, int pageSize, int pageIndex, string whereStr, int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.NVarChar), new SqlParameter("@Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = type;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = pageIndex;
            commandParameters[3].Value = whereStr;
            commandParameters[4].Value = id;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Dictionary_Get", commandParameters);
        }

        public DataSet GetList(int pageSize, int pageIndex, string whereStr)
        {
            return this.Get(2, pageSize, pageIndex, whereStr, 0);
        }

        public M_Dictionary GetModel(int id)
        {
            DataTable table = this.Get(1, -1, -1, "", id).Tables[0];
            M_Dictionary dictionary = new M_Dictionary();
            if (table.Rows.Count > 0)
            {
                dictionary.Id = id;
                dictionary.ParentId = Convert.ToInt32(table.Rows[0]["ParentId"]);
                dictionary.Sort = Convert.ToInt32(table.Rows[0]["Sort"]);
                dictionary.DicName = table.Rows[0]["DicName"].ToString();
                return dictionary;
            }
            return null;
        }

        private int Set(int type, M_Dictionary model)
        {
            int num = 0;
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@ParentId", SqlDbType.Int, 4), new SqlParameter("@DicName", SqlDbType.NVarChar), new SqlParameter("@Sort", SqlDbType.Int, 4), new SqlParameter("@Identity", SqlDbType.Int, 4) };
            commandParameters[0].Value = type;
            commandParameters[1].Value = model.Id;
            commandParameters[2].Value = model.ParentId;
            commandParameters[3].Value = model.DicName;
            commandParameters[4].Value = model.Sort;
            commandParameters[5].Value = 0;
            commandParameters[5].Direction = ParameterDirection.Output;
            num = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Dictionary_Set", commandParameters);
            if (type == 1)
            {
                num = Convert.ToInt32(commandParameters[5].Value);
            }
            return num;
        }

        public int Update(M_Dictionary model)
        {
            return this.Set(2, model);
        }
    }
}

