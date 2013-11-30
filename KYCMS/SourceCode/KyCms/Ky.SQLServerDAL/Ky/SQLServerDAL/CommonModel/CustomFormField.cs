namespace Ky.SQLServerDAL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using Ky.SQLServerDAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CustomFormField : ICustomFormField
    {
        public void Add(M_CustomFormField model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int, 4), new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@Alias", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@IsNotNull", SqlDbType.Bit), new SqlParameter("@IsSearchForm", SqlDbType.Bit), new SqlParameter("@Type", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@IsList", SqlDbType.Bit), new SqlParameter("@IsUserInsert", SqlDbType.Bit), new SqlParameter("@AddDate", SqlDbType.DateTime) };
            commandParameters[0].Value = model.CustomFormId;
            commandParameters[1].Value = model.Name;
            commandParameters[2].Value = model.Alias;
            commandParameters[3].Value = model.Description;
            commandParameters[4].Value = model.IsNotNull;
            commandParameters[5].Value = model.IsSearchForm;
            commandParameters[6].Value = model.Type;
            commandParameters[7].Value = model.Content;
            commandParameters[8].Value = model.IsList;
            commandParameters[9].Value = model.IsUserInsert;
            commandParameters[10].Value = model.AddDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_Add", commandParameters);
        }

        public void Del(int FieldId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FieldId", SqlDbType.Int) };
            commandParameters[0].Value = FieldId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_Del", commandParameters);
        }

        public DataTable GetIsUserList(int CustomFormId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int) };
            commandParameters[0].Value = CustomFormId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_GetIsUserList", commandParameters);
        }

        public DataTable GetList(int CustomFormId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int) };
            commandParameters[0].Value = CustomFormId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_GetList", commandParameters);
        }

        public M_CustomFormField GetModel(int FieldId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FieldId", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = FieldId;
            commandParameters[1].Value = 1;
            M_CustomFormField field = new M_CustomFormField();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_CustomFormField_GetModel", commandParameters);
            field.FieldId = FieldId;
            if (set.Tables[0].Rows.Count > 0)
            {
                if (set.Tables[0].Rows[0]["CustomFormId"].ToString() != "")
                {
                    field.CustomFormId = int.Parse(set.Tables[0].Rows[0]["CustomFormId"].ToString());
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
                if (set.Tables[0].Rows[0]["IsList"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsList"].ToString() == "1") || (set.Tables[0].Rows[0]["IsList"].ToString().ToLower() == "true"))
                    {
                        field.IsList = true;
                    }
                    else
                    {
                        field.IsList = false;
                    }
                }
                if (set.Tables[0].Rows[0]["IsUserInsert"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsUserInsert"].ToString() == "1") || (set.Tables[0].Rows[0]["IsUserInsert"].ToString().ToLower() == "true"))
                    {
                        field.IsUserInsert = true;
                    }
                    else
                    {
                        field.IsUserInsert = false;
                    }
                }
                if (set.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    field.AddDate = DateTime.Parse(set.Tables[0].Rows[0]["AddDate"].ToString());
                }
                return field;
            }
            return null;
        }

        public M_CustomFormField GetModel(int CustomFormId, string Name)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int, 4), new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = CustomFormId;
            commandParameters[1].Value = Name;
            commandParameters[2].Value = 2;
            M_CustomFormField field = new M_CustomFormField();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_CustomFormField_GetModel", commandParameters);
            field.FieldId = int.Parse(set.Tables[0].Rows[0]["FieldId"].ToString());
            if (set.Tables[0].Rows.Count > 0)
            {
                if (set.Tables[0].Rows[0]["CustomFormId"].ToString() != "")
                {
                    field.CustomFormId = int.Parse(set.Tables[0].Rows[0]["CustomFormId"].ToString());
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
                if (set.Tables[0].Rows[0]["IsList"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsList"].ToString() == "1") || (set.Tables[0].Rows[0]["IsList"].ToString().ToLower() == "true"))
                    {
                        field.IsList = true;
                    }
                    else
                    {
                        field.IsList = false;
                    }
                }
                if (set.Tables[0].Rows[0]["IsUserInsert"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsUserInsert"].ToString() == "1") || (set.Tables[0].Rows[0]["IsUserInsert"].ToString().ToLower() == "true"))
                    {
                        field.IsUserInsert = true;
                    }
                    else
                    {
                        field.IsUserInsert = false;
                    }
                }
                if (set.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    field.AddDate = DateTime.Parse(set.Tables[0].Rows[0]["AddDate"].ToString());
                }
                return field;
            }
            return null;
        }

        public DataTable GetSelectPropertyTrue(int CustomFormId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int) };
            commandParameters[0].Value = CustomFormId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_SelectPropertyTrue", commandParameters);
        }

        public DataTable GetTitleList(int CustomFormId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int) };
            commandParameters[0].Value = CustomFormId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_GetTitleList", commandParameters);
        }

        public void MoveField(int CustomFormId, int FieldId, string MoveType)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int), new SqlParameter("@FieldId", SqlDbType.Int), new SqlParameter("@MoveType", SqlDbType.NVarChar) };
            commandParameters[0].Value = CustomFormId;
            commandParameters[1].Value = FieldId;
            commandParameters[2].Value = MoveType;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_MoveField", commandParameters);
        }

        public void Update(M_CustomFormField model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FieldId", SqlDbType.Int), new SqlParameter("@CustomFormId", SqlDbType.Int, 4), new SqlParameter("@Alias", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@IsNotNull", SqlDbType.Bit), new SqlParameter("@IsSearchForm", SqlDbType.Bit), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@IsList", SqlDbType.Bit), new SqlParameter("@IsUserInsert", SqlDbType.Bit), new SqlParameter("@AddDate", SqlDbType.DateTime) };
            commandParameters[0].Value = model.FieldId;
            commandParameters[1].Value = model.CustomFormId;
            commandParameters[2].Value = model.Alias;
            commandParameters[3].Value = model.Description;
            commandParameters[4].Value = model.IsNotNull;
            commandParameters[5].Value = model.IsSearchForm;
            commandParameters[6].Value = model.Content;
            commandParameters[7].Value = model.IsList;
            commandParameters[8].Value = model.IsUserInsert;
            commandParameters[9].Value = model.AddDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomFormField_Update", commandParameters);
        }
    }
}

