namespace Ky.DALFactory
{
    using Ky.Model;
    using System;

    public interface IViewLog
    {
        void Add(M_ViewLog model);
        int GetViewCount(int userId, string date);
    }
}

