namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_UserAlbum
    {
        private IUserAlbum IUA = DataAccess.CreateUserAlbum();

        public void AddAlbum(M_UserAlbum model)
        {
            this.IUA.AddAlbum(model);
        }

        public void DeleteAlbum(int Id, int UserId)
        {
            this.IUA.DeleteAlbum(Id, UserId);
        }

        public M_UserAlbum GetAlbumById(int Id, int userId)
        {
            return this.IUA.GetAlbumById(Id, userId);
        }

        public DataTable GetUserAlbumByUserId(int userId, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.IUA.GetUserAlbumByUserId(userId, pageIndex, pageSize, ref recordCount);
        }

        public void UpdateAlbum(M_UserAlbum model)
        {
            this.IUA.UpdateAlbum(model);
        }
    }
}

