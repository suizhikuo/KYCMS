namespace Ky.BLL
{
    using Ky.DALFactory;
    using System;

    public class B_KyCommon
    {
        private IKyCommon dal = DataAccess.CreateCommon();

        public bool CheckHas(string input, string fileldName, string tableName)
        {
            return this.dal.CheckHas(input, fileldName, tableName);
        }
    }
}

