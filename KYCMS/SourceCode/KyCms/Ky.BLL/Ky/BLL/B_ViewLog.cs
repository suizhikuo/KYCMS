namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;

    public class B_ViewLog
    {
        private IViewLog dal = DataAccess.CreateViewLog();

        public void Add(M_ViewLog model)
        {
            this.dal.Add(model);
        }

        public bool CheckMaxViewCount(int userId, string date, int maxViewCount)
        {
            return ((maxViewCount == 0) || (this.GetViewCount(userId, date) < maxViewCount));
        }

        public int GetViewCount(int userId, string date)
        {
            return this.dal.GetViewCount(userId, date);
        }
    }
}

