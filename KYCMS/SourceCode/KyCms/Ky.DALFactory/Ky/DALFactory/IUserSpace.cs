namespace Ky.DALFactory
{
    using Ky.Model;
    using System;

    public interface IUserSpace
    {
        int GetSapcePrevPowerByUserId(int userId);
        M_UserSpace GetUserSpaceById(int Id);
        void RegSpace(M_UserSpace model);
        void UpdateSpace(M_UserSpace model);
    }
}

