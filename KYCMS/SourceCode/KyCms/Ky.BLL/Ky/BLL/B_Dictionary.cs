namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Text;

    public class B_Dictionary
    {
        private int count = 0;
        private IDictionary dal = DataAccess.CreateDictionary();
        private int Id = 0;
        private string spacer = "\x00a0";
        private int sum = 0;

        public int Add(M_Dictionary model)
        {
            return this.dal.Add(model);
        }

        private void Del(int id)
        {
            this.sum++;
            DataTable dictionary = this.GetDictionary(id);
            for (int i = 0; i < dictionary.Rows.Count; i++)
            {
                int num2 = Convert.ToInt32(dictionary.Rows[i]["ID"]);
                this.dal.Delete(num2);
                this.Del(num2);
            }
        }

        public int Delete(int id)
        {
            this.Del(id);
            this.dal.Delete(id);
            B_Log.Add(LogType.Delete, "删除字典成功.编号:" + id);
            return this.sum;
        }

        private void Format(int id, DataTable dt, bool containSelft)
        {
            DataTable dictionary = this.GetDictionary(id);
            for (int i = 0; i < dictionary.Rows.Count; i++)
            {
                this.count++;
                DataRow row = dt.NewRow();
                if (id == this.Id)
                {
                    if (containSelft && (this.Id != 0))
                    {
                        row["DicName"] = this.spacer + "|--\x00a0" + dictionary.Rows[i]["DicName"].ToString();
                    }
                    else
                    {
                        row["DicName"] = dictionary.Rows[i]["DicName"].ToString();
                    }
                    row["DicValue"] = dictionary.Rows[i]["DicName"].ToString();
                    row["DicId"] = Convert.ToInt32(dictionary.Rows[i]["ID"]);
                }
                else
                {
                    for (int j = 0; j < this.count; j++)
                    {
                        this.spacer = this.spacer + "\x00a0";
                    }
                    row["DicName"] = this.spacer + "|--\x00a0" + dictionary.Rows[i]["DicName"].ToString();
                    row["DicValue"] = dictionary.Rows[i]["DicName"].ToString();
                    row["DicId"] = Convert.ToInt32(dictionary.Rows[i]["ID"]);
                }
                dt.Rows.Add(row);
                this.Format(Convert.ToInt32(dictionary.Rows[i]["ID"]), dt, containSelft);
            }
            this.count = 0;
            this.spacer = "\x00a0";
        }

        public DataTable FormatCategory(int id)
        {
            return this.FormatCategory(id, false);
        }

        public DataTable FormatCategory(int id, bool ContainSelf)
        {
            this.Id = id;
            DataTable dt = new DataTable();
            dt.Columns.Add("DicName", typeof(string));
            dt.Columns.Add("DicValue", typeof(string));
            dt.Columns.Add("DicId", typeof(int));
            if (ContainSelf)
            {
                DataRow row = dt.NewRow();
                M_Dictionary model = this.GetModel(id);
                if (model != null)
                {
                    row["DicName"] = model.DicName;
                    row["DicValue"] = model.DicName;
                    row["DicId"] = model.Id;
                    dt.Rows.Add(row);
                }
            }
            this.Format(id, dt, ContainSelf);
            return dt;
        }

        public DataTable GetDictionary(int id)
        {
            return this.dal.GetList(1000000, 1, "ParentId=" + id).Tables[0];
        }

        public M_Dictionary GetModel(int id)
        {
            return this.dal.GetModel(id);
        }

        public DataTable GetParents()
        {
            return this.dal.GetList(1000000, 1, "ParentId=0").Tables[0];
        }

        public string GetString(int id)
        {
            string str = "";
            StringBuilder builder = new StringBuilder();
            DataTable dictionary = this.GetDictionary(id);
            for (int i = 0; i < dictionary.Rows.Count; i++)
            {
                builder.Append(dictionary.Rows[i]["DicName"]);
                builder.Append("|");
            }
            str = builder.ToString();
            if (str.EndsWith("|"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public int Update(M_Dictionary model)
        {
            return this.dal.Update(model);
        }
    }
}

