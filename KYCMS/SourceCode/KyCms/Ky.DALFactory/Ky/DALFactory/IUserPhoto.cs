namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserPhoto
    {
        void AddPhoto(M_UserPhoto model);
        void DeletePhoto(string IdStr, int UserId, int count);
        M_UserPhoto GetPhotoByPhotoId(int Id);
        DataTable GetUserPhotoById(int AlbumId, int UserId, int pageIndex, int pageSize, ref int recordCount);
        void UpdatePhoto(M_UserPhoto model);
    }
}

