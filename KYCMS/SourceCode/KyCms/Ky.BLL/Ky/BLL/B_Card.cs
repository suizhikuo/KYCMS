namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Card
    {
        private ICard ic = DataAccess.CreateCard();

        public string Add(M_Card model)
        {
            return this.ic.Add(model);
        }

        public void Delete(string cardAccount)
        {
            this.ic.Delete(cardAccount);
            B_Log.Add(LogType.Delete, "删除编号" + cardAccount + "的卡");
        }

        public M_Card GetCard(string account)
        {
            return this.ic.GetCard(account);
        }

        public DataSet GetCards(int pageSize, int pageIndex, string whereString)
        {
            return this.ic.GetCards(pageSize, pageIndex, whereString);
        }

        public DataTable GetCardsByType(CardType type)
        {
            return this.ic.GetCardsByType(type);
        }

        public DataTable GetCardsByUser(string userName)
        {
            return this.ic.GetCardsByUser(userName);
        }

        public void Update(M_Card model)
        {
            this.ic.Update(model);
            B_Log.Add(LogType.Update, "修改用户卡。卡号为" + model.CardAccount);
        }
    }
}

