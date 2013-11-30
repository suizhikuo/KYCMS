namespace Ky.BLL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using Ky.Common;

    public class B_SuperLabel
    {
        private ISuperLabel dal = DataAccess.CreateSuperLabel();
        private string DirName = (Param.SiteRootPath + @"\" + Param.ConfDirName);

        public void Add(M_SuperLabel model)
        {
            this.dal.Add(model);
        }

        public int CheckName(string Name)
        {
            return this.dal.CheckName(Name);
        }

        public DataTable CheckSql(string sql)
        {
            return this.dal.CheckSql(sql);
        }

        public DataTable DataBaseTypeSql(string LinkPath, string DataBaseType, string sql)
        {
            return this.dal.DataBaseTypeSql(LinkPath, DataBaseType, sql);
        }

        public void Delete(int SuperId)
        {
            this.dal.Delete(SuperId);
        }

        public string FiltrateWhereSql(string sql)
        {
            if (sql.ToLower().IndexOf("where").ToString() == "-1")
            {
                return sql;
            }
            return sql.Substring(0, sql.ToLower().IndexOf("where") - 1);
        }

        public DataSet GetList(int currPage, int pageSize)
        {
            return this.dal.GetList(currPage, pageSize);
        }

        public M_SuperLabel GetModel(int SuperId)
        {
            return this.dal.GetModel(SuperId);
        }

        public int GetSuperId(string Name)
        {
            return this.dal.GetSuperId(Name);
        }

        public bool IsModelTable(string TableName)
        {
            return this.dal.IsModelTable(TableName);
        }

        public DataSet SuperLabelOut(string InSuperId)
        {
            return this.dal.SuperLabelOut(InSuperId);
        }

        public void Update(M_SuperLabel model)
        {
            this.dal.Update(model);
        }
    }
}

