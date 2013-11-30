namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Enterprise
    {
        private IEnterprise IE = DataAccess.CreateEnterprise();

        public void AddEnterPrise(M_Enterprise model)
        {
            this.IE.AddEnterPrise(model);
        }

        public void DeleteEnterprise(string idStr, int userId)
        {
            this.IE.DeleteEnterprise(idStr, userId);
        }

        public M_Enterprise GetEnterpriseById(int Id, int userId)
        {
            return this.IE.GetEnterpriseById(Id, userId);
        }

        public DataTable GetEnterpriseByUserId(int userId, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.IE.GetEnterpriseByUserId(userId, pageIndex, pageSize, ref recordCount);
        }

        public void UpdateEnterPrise(M_Enterprise model)
        {
            this.IE.UpdateEnterPrise(model);
        }
    }
}

