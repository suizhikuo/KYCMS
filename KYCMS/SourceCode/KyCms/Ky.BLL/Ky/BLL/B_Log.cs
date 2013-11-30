namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Web;

    public class B_Log
    {
        private ILog dal = DataAccess.CreateLog();

        public static void Add(LogType logType, string description)
        {
            M_LoginAdmin loginModel = new B_Admin().GetLoginModel();
            ILog log = DataAccess.CreateLog();
            string ipAddress = string.Empty;
            if (HttpContext.Current.Request.UserHostAddress != null)
            {
                ipAddress = HttpContext.Current.Request.UserHostAddress;
            }
            log.Add(logType, loginModel.AdminName, loginModel.UserId, description, ipAddress, DateTime.Now);
        }

        public void Delete(DateTime logTime)
        {
            this.dal.Delete(logTime);
            Add(LogType.Delete, "清理" + logTime.ToString("yyyy-MM-dd HH:mm:ss") + "前的日志");
        }

        public DataTable GetList(LogType logType, string userName, string startTime, string endTime, int currPage, int pageSize, ref int recordCount)
        {
            return this.dal.GetList(logType, userName, startTime, endTime, currPage, pageSize, ref recordCount);
        }

        public static string GetNameByLogType(object logType)
        {
            switch (((LogType) logType))
            {
                case LogType.All:
                    return "";

                case LogType.Login:
                    return "登陆/退出";

                case LogType.Add:
                    return "添加操作";

                case LogType.Update:
                    return "修改操作";

                case LogType.Delete:
                    return "清除操作";

                case LogType.Move:
                    return "移动操作";
            }
            return "未知操作";
        }
    }
}

