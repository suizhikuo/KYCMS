namespace Ky.BLL
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_PowerGroup
    {
        private IPowerGroup ipg = DataAccess.CreatePowerGroup();

        public void Del(int PowerId)
        {
            this.ipg.Del(PowerId);
        }

        public void Insert(M_PowerGroup model)
        {
            this.ipg.Insert(model);
        }

        public DataTable Manage()
        {
            return this.ipg.Manage();
        }

        public string Power_Auditing(int ChId, int PowerId)
        {
            if (PowerId == 1)
            {
                return "3";
            }
            M_PowerGroup group = new M_PowerGroup();
            group = this.ipg.Show(PowerId);
            string str = "0";
            string[] strArray = group.PowerAuditing.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { '=' });
                if (strArray2[0] == ("" + ChId + ""))
                {
                    str = strArray2[1].ToString();
                }
            }
            return str;
        }

        public bool Power_Channel(int ChId, int ColId, int PowerId, int TypeId)
        {
            if (PowerId == 1)
            {
                return true;
            }
            M_PowerGroup group = new M_PowerGroup();
            group = this.ipg.Show(PowerId);
            string[] strArray4 = group.PowerChannel.Split(new char[] { ',' });
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

        public bool Power_Column(int ChId, int PowerId)
        {
            if (PowerId == 1)
            {
                return true;
            }
            M_PowerGroup group = new M_PowerGroup();
            group = this.ipg.Show(PowerId);
            string[] strArray = group.PowerColumn.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { '=' });
                if ((strArray2[0] == ("" + ChId + "")) && (strArray2[1] == "1"))
                {
                    return true;
                }
            }
            return false;
        }

        public void Power_Judge(int ChId)
        {
            B_Admin admin = new B_Admin();
            M_LoginAdmin loginModel = admin.GetLoginModel();
            int groupId = admin.GetModel(loginModel.UserId).GroupId;
            M_PowerColumn model = new B_PowerColumn().GetModel(ChId);
            if (!this.Power_Column(ChId, groupId))
            {
                Ky.Common.Function.ShowSysMsg(0, model.ColumnErrorCodes);
            }
        }

        public void Power_Judge(int ChId, int ColId, int TypeId, string ErrorTitle)
        {
            B_Admin admin = new B_Admin();
            M_LoginAdmin loginModel = admin.GetLoginModel();
            int groupId = admin.GetModel(loginModel.UserId).GroupId;
            if (!this.Power_Channel(ChId, ColId, groupId, TypeId))
            {
                Ky.Common.Function.ShowSysMsg(0, ErrorTitle);
            }
        }

        public DataTable PowerColumnNameList()
        {
            return this.ipg.PowerColumnNameList();
        }

        public DataTable PowerModelList()
        {
            return this.ipg.PowerModelList();
        }

        public M_PowerGroup Show(int PowerId)
        {
            return this.ipg.Show(PowerId);
        }

        public void Update(M_PowerGroup model)
        {
            this.ipg.Update(model);
        }
    }
}

