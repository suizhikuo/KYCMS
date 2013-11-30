namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserAlbum
    {
        void AddAlbum(M_UserAlbum model);
        void DeleteAlbum(int Id, int UserId);
        M_UserAlbum GetAlbumById(int Id, int userId);
        DataTable GetUserAlbumByUserId(int userId, int pageIndex, int pageSize, ref int recordCount);
        void UpdateAlbum(M_UserAlbum model);
    }
}

