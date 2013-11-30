namespace Ky.BLL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_UserGroupModel
    {
        private IUserGroupModel dal = DataAccess.CreateUserGroupModel();

        public int Add(M_UserGroupModel model)
        {
            this.dal.AddTable(model.TableName);
            return this.dal.Add(model);
        }

        public void Delete(int Id)
        {
            this.dal.Delete(Id);
        }

        public DataTable GetAll()
        {
            return this.dal.GetAll();
        }

        public M_UserGroupModel GetModel(int Id)
        {
            return this.dal.GetModel(Id);
        }

        public DataTable GetSysteFieldList()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Alias", typeof(string)));
            table.Columns.Add(new DataColumn("Type", typeof(string)));
            table.Columns.Add(new DataColumn("IsNotNull", typeof(string)));
            string[] strArray = "Id|自动编号|Id|√,UId|用户Id|数字|√,AddTime|添加时间|日期时间|√,UpdateTime|更新时间|日期时间|√".Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { '|' });
                DataRow row = table.NewRow();
                row[0] = strArray2[0];
                row[1] = strArray2[1];
                row[2] = strArray2[2];
                row[3] = strArray2[3];
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable GetTextType(int ModelId)
        {
            return this.dal.GetTextType(ModelId);
        }

        public void Update(M_UserGroupModel model)
        {
            this.dal.Update(model);
        }

        public void UpdateModelHtml(M_UserGroupModel model)
        {
            this.dal.UpdateModelHtml(model);
        }

        public void UpdateUserGroupId(int Id, int UserGroupId)
        {
            this.dal.UpdateUserGroupId(Id, UserGroupId);
        }
    }
}

