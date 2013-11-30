namespace Ky.DALFactory
{
    using Ky.Model;
    using System;

    public interface IDownLoad
    {
        int Add(M_DownLoad model);
        void ClearDownCount();
        int GetDownCount(int id, int type);
        M_DownLoad GetDownLoadData(int ID);
        void SetDownCount(int id);
        int Update(M_DownLoad model);
    }
}

