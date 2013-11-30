namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Review : IReview
    {
        public bool Add(M_Review model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("ModelType", SqlDbType.TinyInt), new SqlParameter("InfoId", SqlDbType.NVarChar), new SqlParameter("ReviewTitle", SqlDbType.NVarChar), new SqlParameter("IsArgue", SqlDbType.Bit), new SqlParameter("IsSquare", SqlDbType.TinyInt), new SqlParameter("BrarNum", SqlDbType.Int), new SqlParameter("FightNum", SqlDbType.Int), new SqlParameter("IsElite", SqlDbType.Bit), new SqlParameter("ReviewContent", SqlDbType.NText), new SqlParameter("ReviewTime", SqlDbType.DateTime), new SqlParameter("UserNum", SqlDbType.NVarChar), new SqlParameter("ReviewIP", SqlDbType.NVarChar), new SqlParameter("IsCheck", SqlDbType.Bit) };
            commandParameters[0].Value = model.ModelType;
            commandParameters[1].Value = model.InfoId;
            commandParameters[2].Value = model.ReviewTitle;
            commandParameters[3].Value = model.IsArgue;
            commandParameters[4].Value = model.IsSquare;
            commandParameters[5].Value = model.BrarNum;
            commandParameters[6].Value = model.FightNum;
            commandParameters[7].Value = model.IsElite;
            commandParameters[8].Value = model.ReviewContent;
            commandParameters[9].Value = model.ReviewTime;
            commandParameters[10].Value = model.UserNum;
            commandParameters[11].Value = model.ReviewIP;
            commandParameters[12].Value = model.IsCheck;
            return (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_Add", commandParameters) > 0);
        }

        public void DelReview(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            commandParameters[1].Value = 1;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_Oper", commandParameters);
        }

        public void DelReviewByInfoId(int modelType, int infoId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelType", SqlDbType.Int, 4), new SqlParameter("@InfoId", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = modelType;
            commandParameters[1].Value = infoId;
            commandParameters[2].Value = 2;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_Oper", commandParameters);
        }

        public DataTable GetList(int modelType, int infoId, bool isCheck)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelType", SqlDbType.Int), new SqlParameter("@InfoId", SqlDbType.Int), new SqlParameter("@IsCheck", SqlDbType.Bit) };
            commandParameters[0].Value = modelType;
            commandParameters[1].Value = infoId;
            commandParameters[2].Value = isCheck;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_GetTop5List", commandParameters);
        }

        public M_Review GetModel(int ID)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = ID;
            commandParameters[1].Value = 4;
            M_Review review = new M_Review();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_Oper", commandParameters);
            review.Id = ID;
            if (set.Tables[0].Rows.Count > 0)
            {
                if (set.Tables[0].Rows[0]["ModelType"].ToString() != "")
                {
                    review.ModelType = int.Parse(set.Tables[0].Rows[0]["ModelType"].ToString());
                }
                review.InfoId = set.Tables[0].Rows[0]["InfoId"].ToString();
                review.ReviewTitle = set.Tables[0].Rows[0]["ReviewTitle"].ToString();
                if (set.Tables[0].Rows[0]["IsArgue"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsArgue"].ToString() == "1") || (set.Tables[0].Rows[0]["IsArgue"].ToString().ToLower() == "true"))
                    {
                        review.IsArgue = true;
                    }
                    else
                    {
                        review.IsArgue = false;
                    }
                }
                if (set.Tables[0].Rows[0]["IsSquare"].ToString() != "")
                {
                    review.IsSquare = int.Parse(set.Tables[0].Rows[0]["IsSquare"].ToString());
                }
                if (set.Tables[0].Rows[0]["BrarNum"].ToString() != "")
                {
                    review.BrarNum = int.Parse(set.Tables[0].Rows[0]["BrarNum"].ToString());
                }
                if (set.Tables[0].Rows[0]["FightNum"].ToString() != "")
                {
                    review.FightNum = int.Parse(set.Tables[0].Rows[0]["FightNum"].ToString());
                }
                if (set.Tables[0].Rows[0]["IsElite"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsElite"].ToString() == "1") || (set.Tables[0].Rows[0]["IsElite"].ToString().ToLower() == "true"))
                    {
                        review.IsElite = true;
                    }
                    else
                    {
                        review.IsElite = false;
                    }
                }
                review.ReviewContent = set.Tables[0].Rows[0]["ReviewContent"].ToString();
                if (set.Tables[0].Rows[0]["ReviewTime"].ToString() != "")
                {
                    review.ReviewTime = DateTime.Parse(set.Tables[0].Rows[0]["ReviewTime"].ToString());
                }
                review.UserNum = set.Tables[0].Rows[0]["UserNum"].ToString();
                review.ReviewIP = set.Tables[0].Rows[0]["ReviewIP"].ToString();
                if (set.Tables[0].Rows[0]["IsCheck"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsCheck"].ToString() == "1") || (set.Tables[0].Rows[0]["IsCheck"].ToString().ToLower() == "true"))
                    {
                        review.IsCheck = true;
                        return review;
                    }
                    review.IsCheck = false;
                }
                return review;
            }
            return null;
        }

        public DataSet ManageList(string tableName, int modelType, int pageIndex, int pageSize, bool isCheck)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", tableName), new SqlParameter("@modeltype", modelType), new SqlParameter("@pageindex", pageIndex), new SqlParameter("@pagesize", pageSize), new SqlParameter("@ischeck", isCheck) };
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_GetManageList", commandParameters);
        }

        public DataSet ReviewList(int currPage, int pageSize, string StrWhere)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@pageindex", SqlDbType.Int, 4), new SqlParameter("@pagesize", SqlDbType.Int, 4), new SqlParameter("@wherestr", SqlDbType.NVarChar, 500) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = StrWhere;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_GetMoreList", commandParameters);
        }

        public void UpdateIsCheck(int id)
        {
            bool flag = true;
            M_Review review = new M_Review();
            if (this.GetModel(id).IsCheck)
            {
                flag = false;
            }
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4), new SqlParameter("@IsCheck", SqlDbType.Bit) };
            commandParameters[0].Value = id;
            commandParameters[1].Value = 3;
            commandParameters[2].Value = flag;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Review_Oper", commandParameters);
        }
    }
}

