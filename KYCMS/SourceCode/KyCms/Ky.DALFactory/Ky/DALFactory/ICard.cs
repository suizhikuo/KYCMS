namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ICard
    {
        string Add(M_Card model);
        void Delete(string account);
        M_Card GetCard(string account);
        DataSet GetCards(int pageSize, int pageIndex, string whereString);
        DataTable GetCardsByType(CardType type);
        DataTable GetCardsByUser(string userName);
        void Update(M_Card model);
    }
}

