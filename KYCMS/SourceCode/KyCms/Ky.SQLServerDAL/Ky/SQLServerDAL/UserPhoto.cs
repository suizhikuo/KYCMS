namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserPhoto : IUserPhoto
    {
        public void AddPhoto(M_UserPhoto model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@AlbumId", SqlDbType.Int, 4), new SqlParameter("@FileName", SqlDbType.NVarChar), new SqlParameter("@FilePath", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@PostTime", SqlDbType.NVarChar), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@PhotoId", SqlDbType.Int, 4), new SqlParameter("@VisitNum", SqlDbType.Int, 4), new SqlParameter("@FileSize", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.AlbumId;
            commandParameters[1].Value = model.FileName;
            commandParameters[2].Value = model.FilePath;
            commandParameters[3].Value = model.Description;
            commandParameters[4].Value = model.PostTime;
            commandParameters[5].Value = model.UserId;
            commandParameters[6].Value = model.UserName;
            commandParameters[7].Value = model.PhotoId;
            commandParameters[8].Value = model.VisitNum;
            commandParameters[9].Value = model.FileSize;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserPhoto_Set", commandParameters);
        }

        public void DeletePhoto(string IdStr, int UserId, int count)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@PhotoIdStr", IdStr), new SqlParameter("@UserId", UserId), new SqlParameter("@Count", count) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserPhoto_Delete", commandParameters);
        }

        public M_UserPhoto GetPhotoByPhotoId(int Id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@PhotoId", Id) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserPhoto_GetByPhotoId", commandParameters);
            M_UserPhoto photo = new M_UserPhoto();
            if (table.Rows.Count > 0)
            {
                photo.FileName = table.Rows[0]["FileName"].ToString();
                photo.FilePath = table.Rows[0]["FilePath"].ToString();
                photo.PhotoId = int.Parse(table.Rows[0]["PhotoId"].ToString());
                photo.PostTime = table.Rows[0]["PostTime"].ToString();
                photo.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                photo.UserName = table.Rows[0]["UserName"].ToString();
                photo.AlbumId = int.Parse(table.Rows[0]["AlbumId"].ToString());
                photo.Description = table.Rows[0]["Description"].ToString();
                photo.VisitNum = int.Parse(table.Rows[0]["VisitNum"].ToString());
                return photo;
            }
            return null;
        }

        public DataTable GetUserPhotoById(int AlbumId, int UserId, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@AlbumId", AlbumId), new SqlParameter("@UserId", UserId), new SqlParameter("@PageIndex", pageIndex), new SqlParameter("@PageSize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserPhoto_GetById", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public void UpdatePhoto(M_UserPhoto model)
        {
            this.AddPhoto(model);
        }
    }
}

