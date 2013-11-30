namespace Ky.SQLServerDAL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using Ky.SQLServerDAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class InfoModel : IInfoModel
    {
        public int Add(M_InfoModel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", model.ModelId), new SqlParameter("@modelname", model.ModelName), new SqlParameter("@modeldesc", model.ModelDesc), new SqlParameter("@tablename", model.TableName), new SqlParameter("@uploadpath", model.UploadPath), new SqlParameter("@uploadsize", model.UploadSize), new SqlParameter("@ModelHtml", model.ModelHtml), new SqlParameter("@IsHtml", model.IsHtml) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_Set", commandParameters));
        }

        public int AddInfoModel(DataTable dt, string TableName)
        {
            int num;
            string str = "";
            string str2 = "";
            for (num = 0; num < dt.Rows.Count; num++)
            {
                if ((dt.Rows.Count - 1) == num)
                {
                    str = str + "[" + dt.Rows[num]["FieldName"].ToString() + "])";
                    str2 = str2 + "@" + dt.Rows[num]["FieldName"].ToString() + ");select scope_identity()";
                }
                else
                {
                    str = str + "[" + dt.Rows[num]["FieldName"].ToString() + "],";
                    str2 = str2 + "@" + dt.Rows[num]["FieldName"].ToString() + ",";
                }
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into " + TableName + "(");
            builder.Append(str);
            builder.Append(" values (");
            builder.Append(str2);
            SqlParameter[] commandParameters = new SqlParameter[dt.Rows.Count];
            for (num = 0; num < dt.Rows.Count; num++)
            {
                commandParameters[num] = new SqlParameter("@" + dt.Rows[num]["FieldName"].ToString(), dt.Rows[num]["FieldValue"].ToString());
            }
            int num2 = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.Text, builder.ToString(), commandParameters));
            dt.Clear();
            dt.Dispose();
            return num2;
        }

        public void AddTable(string tableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_AddTable", commandParameters);
        }

        public bool CheckExistsChannel(int modelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", modelId) };
            int num = (int) SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_CheckExistsChannel", commandParameters);
            return (num == 1);
        }

        public bool CheckTableValidate(string tableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", tableName) };
            int num = (int) SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_CheckTableValidate", commandParameters);
            return (num == 1);
        }

        public bool CheckUploadPathValidate(string uploadPath)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UploadPath", uploadPath) };
            int num = (int) SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_CheckUploadPathValidate", commandParameters);
            return (num == 1);
        }

        public void Delete(int modelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", modelId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_Delete", commandParameters);
        }

        public DataTable GetList()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_GetList", new SqlParameter[0]);
        }

        public M_InfoModel GetModel(int modelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", modelId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_GetInfo", commandParameters);
            if ((table != null) && (table.Rows.Count > 0))
            {
                DataRow row = table.Rows[0];
                M_InfoModel model = new M_InfoModel();
                model.ModelId = (int) row["ModelId"];
                model.ModelName = row["ModelName"].ToString();
                model.ModelDesc = row["ModelDesc"].ToString();
                model.TableName = row["TableName"].ToString();
                model.UploadPath = row["UploadPath"].ToString();
                model.UploadSize = (int) row["UploadSize"];
                model.IsSystem = (bool) row["IsSystem"];
                model.AddTime = (DateTime) row["AddTime"];
                model.ModelHtml = row["ModelHtml"].ToString();
                model.IsHtml = (bool) row["IsHtml"];
                return model;
            }
            return null;
        }

        public int GetModelInfoCount(string tableName, string whereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@wherestr", whereStr) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_GetInfoCount", commandParameters));
        }

        public DataTable GetTextType(int ModelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelId", ModelId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_InfoModel_GetTextType", commandParameters);
        }

        public DataSet ModelOut(string InModelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@InModelId", SqlDbType.NVarChar) };
            commandParameters[0].Value = InModelId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_Out", commandParameters);
            table.TableName = "Table0";
            DataTable table2 = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_InModelId", commandParameters);
            table2.TableName = "Table1";
            DataSet set = new DataSet();
            set.Tables.Add(table.Copy());
            set.Tables.Add(table2.Copy());
            return set;
        }

        public int Update(M_InfoModel model)
        {
            return this.Add(model);
        }

        public void UpdateInfoModel(DataTable dt, string TableName)
        {
            int num;
            string str = "";
            for (num = 0; num < dt.Rows.Count; num++)
            {
                if (dt.Rows[num]["FieldName"].ToString() != "Id")
                {
                    string str2;
                    if ((dt.Rows.Count - 1) == num)
                    {
                        str2 = str;
                        str = str2 + "[" + dt.Rows[num]["FieldName"].ToString() + "]=@" + dt.Rows[num]["FieldName"].ToString() + "";
                    }
                    else
                    {
                        str2 = str;
                        str = str2 + "[" + dt.Rows[num]["FieldName"].ToString() + "]=@" + dt.Rows[num]["FieldName"].ToString() + ",";
                    }
                }
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("update " + TableName + " set ");
            builder.Append(str);
            builder.Append(" where Id=@Id");
            SqlParameter[] commandParameters = new SqlParameter[dt.Rows.Count];
            for (num = 0; num < dt.Rows.Count; num++)
            {
                commandParameters[num] = new SqlParameter("@" + dt.Rows[num]["FieldName"].ToString(), dt.Rows[num]["FieldValue"].ToString());
            }
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.Text, builder.ToString(), commandParameters);
            dt.Clear();
            dt.Dispose();
        }

        public void UpdateModelHtml(M_InfoModel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelHtml", model.ModelHtml), new SqlParameter("@ModelId", model.ModelId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Model_ModelHtml", commandParameters);
        }
    }
}

