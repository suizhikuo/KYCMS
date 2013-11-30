namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_UserPhoto
    {
        private IUserPhoto IUP = DataAccess.CreateUserPhoto();

        public void AddPhoto(M_UserPhoto model)
        {
            this.IUP.AddPhoto(model);
        }

        public void DeletePhoto(string IdStr, int UserId, int count)
        {
            this.IUP.DeletePhoto(IdStr, UserId, count);
        }

        public M_UserPhoto GetPhotoByPhotoId(int Id)
        {
            return this.IUP.GetPhotoByPhotoId(Id);
        }

        public DataTable GetUserPhotoById(int AlbumId, int UserId, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.IUP.GetUserPhotoById(AlbumId, UserId, pageIndex, pageSize, ref recordCount);
        }

        public void UpdatePhoto(M_UserPhoto model)
        {
            this.IUP.UpdatePhoto(model);
        }
    }
}

