namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_UserGroup
    {
        private IUserGroup dal = DataAccess.CreateUserGroup();

        public void Add(M_UserGroup model)
        {
            this.dal.Add(model);
        }

        public string ColumnPower_ColumnPower(int ChId, int ColId, string ColumnPower, int a, int b, int c)
        {
            object obj2;
            string str = "";
            bool flag = false;
            string[] strArray3 = ColumnPower.Split(new char[] { ',' });
            for (int i = 0; i < strArray3.Length; i++)
            {
                string[] strArray2 = strArray3[i].Split(new char[] { '=' })[0].Split(new char[] { '@' });
                if ((strArray2[0] == ("" + ChId + "")) && (strArray2[1] == ("" + ColId + "")))
                {
                    obj2 = str;
                    str = string.Concat(new object[] { obj2, "", ChId, "@", ColId, "=", a, "|", b, "|", c, "|," });
                    flag = true;
                }
                else
                {
                    str = str + strArray3[i] + ",";
                }
            }
            if (!flag)
            {
                obj2 = str;
                str = string.Concat(new object[] { obj2, "", ChId, "@", ColId, "=", a, "|", b, "|", c, "|," });
            }
            return str.Substring(0, str.Length - 1).ToString();
        }

        public void Delete(int UserGroupId)
        {
            this.dal.Delete(UserGroupId);
        }

        public DataSet GetList(int currPage, int pageSize, string StrWhere)
        {
            return this.dal.GetList(currPage, pageSize, StrWhere);
        }

        public M_UserGroup GetModel(int UserGroupId)
        {
            return this.dal.GetModel(UserGroupId);
        }

        public DataTable ManageList(string StrWhere)
        {
            return this.dal.ManageList(StrWhere);
        }

        public bool Power_ColumnPower(int ChId, int ColId, string ColumnPower, int TypeId)
        {
            string[] strArray4 = ColumnPower.Split(new char[] { ',' });
            for (int i = 0; i < strArray4.Length; i++)
            {
                string[] strArray = strArray4[i].Split(new char[] { '=' });
                string[] strArray2 = strArray[0].Split(new char[] { '@' });
                if (((strArray2[0] == ("" + ChId + "")) && (strArray2[1] == ("" + ColId + ""))) && (strArray[1].Split(new char[] { '|' })[TypeId - 1] == "1"))
                {
                    return true;
                }
            }
            return false;
        }

        public string Power_UserGroup(string PowerName, int TypeId, string GroupPower)
        {
            string[] strArray = GroupPower.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { '=' });
                if (strArray2[0] == PowerName)
                {
                    return strArray2[1].Split(new char[] { '|' })[TypeId];
                }
            }
            return "0";
        }

        public void Update(M_UserGroup model)
        {
            this.dal.Update(model);
        }
    }
}

