namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;

    public class B_Money
    {
        private IMoney dal = DataAccess.CreateMoney();

        public void ExpireTime(int Value, int UserId)
        {
            this.dal.ExpireTime(Value, UserId);
        }

        public void Integral(int Value, int UserId)
        {
            this.dal.Integral(Value, UserId);
        }

        public void Integral(int Value, string UserName)
        {
            M_User user = new B_User().GetUser(UserName);
            if (user != null)
            {
                this.Integral(Value, user.UserID);
            }
        }

        public void YellowBoy(decimal Value, int UserId)
        {
            this.dal.YellowBoy(Value, UserId);
        }
    }
}

