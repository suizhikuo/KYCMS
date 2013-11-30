namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ILog
    {
        void Add(LogType logType, string userName, int userId, string description, string ipAddress, DateTime logTime);
        void Delete(DateTime logTime);
        DataTable GetList(LogType logType, string userName, string startTime, string endTime, int currPage, int pageSize, ref int recordCount);
    }
}

