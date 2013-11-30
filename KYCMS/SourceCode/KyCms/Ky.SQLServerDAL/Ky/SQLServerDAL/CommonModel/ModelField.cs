namespace Ky.SQLServerDAL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using Ky.SQLServerDAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ModelField : IModelField
    {
        public void Add(M_ModelField model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelId", SqlDbType.Int, 4), new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@Alias", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@IsNotNull", SqlDbType.Bit), new SqlParameter("@IsSearchForm", SqlDbType.Bit), new SqlParameter("@Type", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@AddDate", SqlDbType.DateTime) };
            commandParameters[0].Value = model.ModelId;
            commandParameters[1].Value = model.Name;
            commandParameters[2].Value = model.Alias;
            commandParameters[3].Value = model.Description;
            commandParameters[4].Value = model.IsNotNull;
            commandParameters[5].Value = model.IsSearchForm;
            commandParameters[6].Value = model.Type;
            commandParameters[7].Value = model.Content;
            commandParameters[8].Value = model.AddDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_Add", commandParameters);
        }

        public void AddField(string TableName, string FieldName, string FieldType, string DefaultValue)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", SqlDbType.NVarChar), new SqlParameter("@FieldName", SqlDbType.NVarChar), new SqlParameter("@FieldType", SqlDbType.NVarChar), new SqlParameter("@DefaultValue", SqlDbType.NVarChar) };
            commandParameters[0].Value = TableName;
            commandParameters[1].Value = FieldName;
            commandParameters[2].Value = FieldType;
            commandParameters[3].Value = DefaultValue;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_AddField", commandParameters);
        }

        public void Del(int FieldId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FieldId", SqlDbType.Int) };
            commandParameters[0].Value = FieldId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_Del", commandParameters);
        }

        public void DelField(string TableName, string FieldName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", SqlDbType.NVarChar), new SqlParameter("@FieldName", SqlDbType.NVarChar) };
            commandParameters[0].Value = TableName;
            commandParameters[1].Value = FieldName;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_DelField", commandParameters);
        }

        public DataTable GetAllTable()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_GetAllTable", new SqlParameter[0]);
        }

        public DataTable GetList(int ModelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelId", SqlDbType.Int) };
            commandParameters[0].Value = ModelId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_GetList", commandParameters);
        }

        public M_ModelField GetModel(int FieldId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FieldId", SqlDbType.Int, 4) };
            commandParameters[0].Value = FieldId;
            M_ModelField field = new M_ModelField();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_ModelField_GetModel", commandParameters);
            field.FieldId = FieldId;
            if (set.Tables[0].Rows.Count > 0)
            {
                if (set.Tables[0].Rows[0]["ModelId"].ToString() != "")
                {
                    field.ModelId = int.Parse(set.Tables[0].Rows[0]["ModelId"].ToString());
                }
                field.Name = set.Tables[0].Rows[0]["Name"].ToString();
                field.Alias = set.Tables[0].Rows[0]["Alias"].ToString();
                field.Description = set.Tables[0].Rows[0]["Description"].ToString();
                if (set.Tables[0].Rows[0]["IsNotNull"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsNotNull"].ToString() == "1") || (set.Tables[0].Rows[0]["IsNotNull"].ToString().ToLower() == "true"))
                    {
                        field.IsNotNull = true;
                    }
                    else
                    {
                        field.IsNotNull = false;
                    }
                }
                if (set.Tables[0].Rows[0]["IsSearchForm"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsSearchForm"].ToString() == "1") || (set.Tables[0].Rows[0]["IsSearchForm"].ToString().ToLower() == "true"))
                    {
                        field.IsSearchForm = true;
                    }
                    else
                    {
                        field.IsSearchForm = false;
                    }
                }
                field.Type = set.Tables[0].Rows[0]["Type"].ToString();
                field.Content = set.Tables[0].Rows[0]["Content"].ToString();
                if (set.Tables[0].Rows[0]["OrderId"].ToString() != "")
                {
                    field.OrderId = int.Parse(set.Tables[0].Rows[0]["OrderId"].ToString());
                }
                if (set.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    field.AddDate = DateTime.Parse(set.Tables[0].Rows[0]["AddDate"].ToString());
                }
                return field;
            }
            return null;
        }

        public DataTable GetSearchField(int modelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", modelId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_GetSearchField", commandParameters);
        }

        public DataTable GetSelectPropertyTrue(int ModelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelId", SqlDbType.Int) };
            commandParameters[0].Value = ModelId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_SelectPropertyTrue", commandParameters);
        }

        public DataTable GetTableAllField(string TableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", SqlDbType.NVarChar) };
            commandParameters[0].Value = TableName;
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_GetTableAllField", commandParameters);
        }

        public DataTable GetTableAllFieldAndType(string TableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", SqlDbType.NVarChar) };
            commandParameters[0].Value = TableName;
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_GetTableAllFieldAndType", commandParameters);
        }

        public bool IsNotField(string TableName, string FieldName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", SqlDbType.NVarChar), new SqlParameter("@FieldName", SqlDbType.NVarChar) };
            commandParameters[0].Value = TableName;
            commandParameters[1].Value = FieldName;
            DataTable table = new DataTable();
            if (SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_IsNotField", commandParameters).Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public void MoveField(int ModelId, int FieldId, string MoveType)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelId", SqlDbType.Int), new SqlParameter("@FieldId", SqlDbType.Int), new SqlParameter("@MoveType", SqlDbType.NVarChar) };
            commandParameters[0].Value = ModelId;
            commandParameters[1].Value = FieldId;
            commandParameters[2].Value = MoveType;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_MoveField", commandParameters);
        }

        public void Update(M_ModelField model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FieldId", SqlDbType.Int), new SqlParameter("@ModelId", SqlDbType.Int, 4), new SqlParameter("@Alias", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@IsNotNull", SqlDbType.Bit), new SqlParameter("@IsSearchForm", SqlDbType.Bit), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@AddDate", SqlDbType.DateTime) };
            commandParameters[0].Value = model.FieldId;
            commandParameters[1].Value = model.ModelId;
            commandParameters[2].Value = model.Alias;
            commandParameters[3].Value = model.Description;
            commandParameters[4].Value = model.IsNotNull;
            commandParameters[5].Value = model.IsSearchForm;
            commandParameters[6].Value = model.Content;
            commandParameters[7].Value = model.AddDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_Update", commandParameters);
        }

        public void UpdateFieldDefault(string TableName, string FieldName, string DefaultValue)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", SqlDbType.NVarChar), new SqlParameter("@FieldName", SqlDbType.NVarChar), new SqlParameter("@DefaultValue", SqlDbType.NVarChar) };
            commandParameters[0].Value = TableName;
            commandParameters[1].Value = FieldName;
            commandParameters[2].Value = DefaultValue;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ModelField_UpdateFieldDefault", commandParameters);
        }
    }
}

