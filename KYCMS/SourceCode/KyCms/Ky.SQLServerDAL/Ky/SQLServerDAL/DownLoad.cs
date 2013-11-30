namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DownLoad : IDownLoad
    {
        public int Add(M_DownLoad model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@ColId", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@TitleColor", SqlDbType.NVarChar), new SqlParameter("@TitleFontType", SqlDbType.Int, 4), new SqlParameter("@TitleType", SqlDbType.Int, 4), new SqlParameter("@TitleImgPath", SqlDbType.VarChar, 255), new SqlParameter("@UId", SqlDbType.Int, 4), new SqlParameter("@UName", SqlDbType.NVarChar), new SqlParameter("@UserType", SqlDbType.Int, 4), new SqlParameter("@AdminUId", SqlDbType.Int, 4), new SqlParameter("@AdminUName", SqlDbType.NVarChar), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@HitCount", SqlDbType.Int, 4), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@UpdateTime", SqlDbType.DateTime), 
                new SqlParameter("@TemplatePath", SqlDbType.VarChar, 255), new SqlParameter("@PageType", SqlDbType.Int, 4), new SqlParameter("@IsCreated", SqlDbType.Bit, 1), new SqlParameter("@UserCateId", SqlDbType.Int, 4), new SqlParameter("@PointCount", SqlDbType.Int, 4), new SqlParameter("@ChargeType", SqlDbType.Int, 4), new SqlParameter("@ChargeHourCount", SqlDbType.Int, 4), new SqlParameter("@ChargeViewCount", SqlDbType.Int, 4), new SqlParameter("@IsOpened", SqlDbType.Int, 4), new SqlParameter("@GroupIdStr", SqlDbType.VarChar, 200), new SqlParameter("@IsDeleted", SqlDbType.Bit, 1), new SqlParameter("@IsRecommend", SqlDbType.Bit, 1), new SqlParameter("@IsTop", SqlDbType.Bit, 1), new SqlParameter("@IsFocus", SqlDbType.Bit, 1), new SqlParameter("@IsSideShow", SqlDbType.Bit, 1), new SqlParameter("@TagIdStr", SqlDbType.VarChar, 300), 
                new SqlParameter("@TagNameStr", SqlDbType.NVarChar), new SqlParameter("@SpecialIdStr", SqlDbType.VarChar, 200), new SqlParameter("@Content", SqlDbType.NVarChar, 500), new SqlParameter("@Edition", SqlDbType.NVarChar), new SqlParameter("@PlayAddress", SqlDbType.NVarChar), new SqlParameter("@DownLoadDownNum", SqlDbType.Int, 4), new SqlParameter("@DownLoadDownMonthNum", SqlDbType.Int, 4), new SqlParameter("@DownLoadDownWeekNum", SqlDbType.Int, 4), new SqlParameter("@DownLoadDownDayNum", SqlDbType.Int, 4), new SqlParameter("@DownLoadOS", SqlDbType.NVarChar), new SqlParameter("@DownLoadServerDataId", SqlDbType.NVarChar), new SqlParameter("@Language", SqlDbType.NVarChar), new SqlParameter("@WarrantType", SqlDbType.NVarChar), new SqlParameter("@DownLoadSize", SqlDbType.NVarChar), new SqlParameter("@RegAddress", SqlDbType.NVarChar), new SqlParameter("@Plugin", SqlDbType.NVarChar), 
                new SqlParameter("@DownLoadStarLevel", SqlDbType.NVarChar), new SqlParameter("@DownLoadDisplePwd", SqlDbType.NVarChar), new SqlParameter("@DownLoadType", SqlDbType.NVarChar), new SqlParameter("@IsAllowComment", SqlDbType.Bit, 1)
             };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.ColId;
            commandParameters[2].Value = model.Title;
            commandParameters[3].Value = model.TitleColor;
            commandParameters[4].Value = model.TitleFontType;
            commandParameters[5].Value = model.TitleType;
            commandParameters[6].Value = model.TitleImgPath;
            commandParameters[7].Value = model.UId;
            commandParameters[8].Value = model.UName;
            commandParameters[9].Value = model.UserType;
            commandParameters[10].Value = model.AdminUId;
            commandParameters[11].Value = model.AdminUName;
            commandParameters[12].Value = model.Status;
            commandParameters[13].Value = model.HitCount;
            commandParameters[14].Value = model.AddTime;
            commandParameters[15].Value = model.UpdateTime;
            commandParameters[16].Value = model.TemplatePath;
            commandParameters[17].Value = model.PageType;
            commandParameters[18].Value = model.IsCreated;
            commandParameters[19].Value = model.UserCateId;
            commandParameters[20].Value = model.PointCount;
            commandParameters[21].Value = model.ChargeType;
            commandParameters[22].Value = model.ChargeHourCount;
            commandParameters[23].Value = model.ChargeViewCount;
            commandParameters[24].Value = model.IsOpened;
            commandParameters[25].Value = model.GroupIdStr;
            commandParameters[26].Value = model.IsDeleted;
            commandParameters[27].Value = model.IsRecommend;
            commandParameters[28].Value = model.IsTop;
            commandParameters[29].Value = model.IsFocus;
            commandParameters[30].Value = model.IsSideShow;
            commandParameters[31].Value = model.TagIdStr;
            commandParameters[32].Value = model.TagNameStr;
            commandParameters[33].Value = model.SpecialIdStr;
            commandParameters[34].Value = model.Content;
            commandParameters[35].Value = model.Edition;
            commandParameters[36].Value = model.PlayAddress;
            commandParameters[37].Value = model.DownLoadDownNum;
            commandParameters[38].Value = model.DownLoadDownMonthNum;
            commandParameters[39].Value = model.DownLoadDownWeekNum;
            commandParameters[40].Value = model.DownLoadDownDayNum;
            commandParameters[41].Value = model.DownLoadOS;
            commandParameters[42].Value = model.DownLoadServerDataId;
            commandParameters[43].Value = model.Language;
            commandParameters[44].Value = model.WarrantType;
            commandParameters[45].Value = model.DownLoadSize;
            commandParameters[46].Value = model.RegAddress;
            commandParameters[47].Value = model.Plugin;
            commandParameters[48].Value = model.DownLoadStarLevel;
            commandParameters[49].Value = model.DownLoadDisplePwd;
            commandParameters[50].Value = model.DownLoadType;
            commandParameters[51].Value = model.IsAllowComment;
            commandParameters[0].Direction = ParameterDirection.InputOutput;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadData_Set", commandParameters);
            return int.Parse(commandParameters[0].Value.ToString());
        }

        public void ClearDownCount()
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadData_ClearDownCount", new SqlParameter[0]);
        }

        public int GetDownCount(int id, int type)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", id), new SqlParameter("@type", type) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoad_GetDownCount", commandParameters));
        }

        public M_DownLoad GetDownLoadData(int ID)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tablename", "KyDownLoadData"), new SqlParameter("@Id", ID) };
            M_DownLoad load = new M_DownLoad();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Info_GetInfo", commandParameters);
            if (table.Rows.Count > 0)
            {
                load.Id = int.Parse(table.Rows[0]["Id"].ToString());
                load.ColId = int.Parse(table.Rows[0]["ColId"].ToString());
                load.Title = table.Rows[0]["Title"].ToString();
                load.TitleColor = table.Rows[0]["TitleColor"].ToString();
                load.TitleFontType = int.Parse(table.Rows[0]["TitleFontType"].ToString());
                load.TitleType = int.Parse(table.Rows[0]["TitleType"].ToString());
                load.TitleImgPath = table.Rows[0]["TitleImgPath"].ToString();
                load.UId = int.Parse(table.Rows[0]["UId"].ToString());
                load.UName = table.Rows[0]["UName"].ToString();
                load.UserType = int.Parse(table.Rows[0]["UserType"].ToString());
                load.AdminUId = int.Parse(table.Rows[0]["AdminUId"].ToString());
                load.AdminUName = table.Rows[0]["AdminUName"].ToString();
                load.Status = int.Parse(table.Rows[0]["Status"].ToString());
                load.HitCount = int.Parse(table.Rows[0]["HitCount"].ToString());
                load.AddTime = DateTime.Parse(table.Rows[0]["AddTime"].ToString());
                load.UpdateTime = DateTime.Parse(table.Rows[0]["UpdateTime"].ToString());
                load.TemplatePath = table.Rows[0]["TemplatePath"].ToString();
                load.PageType = int.Parse(table.Rows[0]["PageType"].ToString());
                if (table.Rows[0]["IsCreated"].ToString().ToLower() == "true")
                {
                    load.IsCreated = true;
                }
                else
                {
                    load.IsCreated = false;
                }
                load.UserCateId = int.Parse(table.Rows[0]["UserCateId"].ToString());
                load.PointCount = int.Parse(table.Rows[0]["PointCount"].ToString());
                load.ChargeType = int.Parse(table.Rows[0]["ChargeType"].ToString());
                load.ChargeHourCount = int.Parse(table.Rows[0]["ChargeHourCount"].ToString());
                load.ChargeViewCount = int.Parse(table.Rows[0]["ChargeViewCount"].ToString());
                load.IsOpened = int.Parse(table.Rows[0]["IsOpened"].ToString());
                load.GroupIdStr = table.Rows[0]["GroupIdStr"].ToString();
                if (table.Rows[0]["IsDeleted"].ToString().ToLower() == "true")
                {
                    load.IsDeleted = true;
                }
                else
                {
                    load.IsDeleted = false;
                }
                if (table.Rows[0]["IsRecommend"].ToString().ToLower() == "true")
                {
                    load.IsRecommend = true;
                }
                else
                {
                    load.IsRecommend = false;
                }
                if (table.Rows[0]["IsTop"].ToString().ToLower() == "true")
                {
                    load.IsTop = true;
                }
                else
                {
                    load.IsTop = false;
                }
                if (table.Rows[0]["IsFocus"].ToString().ToLower() == "true")
                {
                    load.IsFocus = true;
                }
                else
                {
                    load.IsFocus = false;
                }
                if (table.Rows[0]["IsSideShow"].ToString().ToLower() == "true")
                {
                    load.IsSideShow = true;
                }
                else
                {
                    load.IsSideShow = false;
                }
                if (table.Rows[0]["IsAllowComment"].ToString().ToLower() == "true")
                {
                    load.IsAllowComment = true;
                }
                else
                {
                    load.IsAllowComment = false;
                }
                load.TagIdStr = table.Rows[0]["TagIdStr"].ToString();
                load.TagNameStr = table.Rows[0]["TagNameStr"].ToString();
                load.SpecialIdStr = table.Rows[0]["SpecialIdStr"].ToString();
                load.Content = table.Rows[0]["Content"].ToString();
                load.Edition = table.Rows[0]["Edition"].ToString();
                load.PlayAddress = table.Rows[0]["PlayAddress"].ToString();
                load.DownLoadDownNum = int.Parse(table.Rows[0]["DownLoadDownNum"].ToString());
                load.DownLoadDownMonthNum = int.Parse(table.Rows[0]["DownLoadDownMonthNum"].ToString());
                load.DownLoadDownWeekNum = int.Parse(table.Rows[0]["DownLoadDownWeekNum"].ToString());
                load.DownLoadDownDayNum = int.Parse(table.Rows[0]["DownLoadDownDayNum"].ToString());
                load.DownLoadOS = table.Rows[0]["DownLoadOS"].ToString();
                load.DownLoadServerDataId = int.Parse(table.Rows[0]["DownLoadServerDataId"].ToString());
                load.WarrantType = table.Rows[0]["WarrantType"].ToString();
                load.Language = table.Rows[0]["Language"].ToString();
                load.DownLoadSize = table.Rows[0]["DownLoadSize"].ToString();
                load.RegAddress = table.Rows[0]["RegAddress"].ToString();
                load.Plugin = table.Rows[0]["Plugin"].ToString();
                load.DownLoadStarLevel = table.Rows[0]["DownLoadStarLevel"].ToString();
                load.DownLoadDisplePwd = table.Rows[0]["DownLoadDisplePwd"].ToString();
                load.DownLoadType = table.Rows[0]["DownLoadType"].ToString();
                return load;
            }
            return null;
        }

        public void SetDownCount(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoad_SetDownCount", commandParameters);
        }

        public int Update(M_DownLoad model)
        {
            return this.Add(model);
        }
    }
}

