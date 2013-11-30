namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;

    public class B_DownLoad
    {
        private IDownLoad IDL = DataAccess.CreateDownload();

        public int Add(M_DownLoad model)
        {
            return this.IDL.Add(model);
        }

        public void ClearDownCount()
        {
            this.IDL.ClearDownCount();
        }

        public int GetDownCount(int id, int type)
        {
            return this.IDL.GetDownCount(id, type);
        }

        public M_DownLoad GetDownLoadData(int ID)
        {
            return this.IDL.GetDownLoadData(ID);
        }

        public void SetDownCount(int id)
        {
            this.IDL.SetDownCount(id);
        }

        public int Update(M_DownLoad model)
        {
            return this.IDL.Update(model);
        }
    }
}

