namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserAlbum : IUserAlbum
    {
        public void AddAlbum(M_UserAlbum model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@AlbumName", SqlDbType.NVarChar), new SqlParameter("@AlbumCate", SqlDbType.NVarChar), new SqlParameter("@AlbumDescription", SqlDbType.NVarChar), new SqlParameter("@ImgCount", SqlDbType.Int, 4), new SqlParameter("@Logo", SqlDbType.NVarChar), new SqlParameter("@IsOpened", SqlDbType.Int, 4), new SqlParameter("@AlbumPassword", SqlDbType.NVarChar), new SqlParameter("@AddTime", SqlDbType.NVarChar), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.AlbumName;
            commandParameters[2].Value = model.AlbumCate;
            commandParameters[3].Value = model.AlbumDescription;
            commandParameters[4].Value = model.ImgCount;
            commandParameters[5].Value = model.Logo;
            commandParameters[6].Value = model.IsOpened;
            commandParameters[7].Value = model.AlbumPassword;
            commandParameters[8].Value = model.AddTime;
            commandParameters[9].Value = model.UserId;
            commandParameters[10].Value = model.UserName;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserAlbum_Set", commandParameters);
        }

        public void DeleteAlbum(int Id, int UserId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", Id), new SqlParameter("@UserId", UserId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserAlbum_Delete", commandParameters);
        }

        public M_UserAlbum GetAlbumById(int Id, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", Id), new SqlParameter("@UserId", userId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserAlbum_GetById", commandParameters);
            M_UserAlbum album = new M_UserAlbum();
            if (table.Rows.Count > 0)
            {
                album.Id = int.Parse(table.Rows[0]["Id"].ToString());
                album.Logo = table.Rows[0]["Logo"].ToString();
                album.AlbumName = table.Rows[0]["AlbumName"].ToString();
                album.AlbumCate = table.Rows[0]["AlbumCate"].ToString();
                album.AlbumDescription = table.Rows[0]["AlbumDescription"].ToString();
                album.ImgCount = int.Parse(table.Rows[0]["ImgCount"].ToString());
                album.IsOpened = int.Parse(table.Rows[0]["IsOpened"].ToString());
                album.AlbumPassword = table.Rows[0]["AlbumPassword"].ToString();
                album.AddTime = table.Rows[0]["AddTime"].ToString();
                album.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                album.UserName = table.Rows[0]["UserName"].ToString();
                return album;
            }
            return null;
        }

        public DataTable GetUserAlbumByUserId(int userId, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId), new SqlParameter("@PageIndex", pageIndex), new SqlParameter("@PageSize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserAlbum_GetByUserId", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public void UpdateAlbum(M_UserAlbum model)
        {
            this.AddAlbum(model);
        }
    }
}

