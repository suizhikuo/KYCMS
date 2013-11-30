namespace Ky.BLL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_CustomFormField
    {
        private ICustomFormField dal = DataAccess.CreateCustomFormField();

        public void Add(M_CustomFormField model)
        {
            this.dal.Add(model);
        }

        public void Del(int FieldId)
        {
            this.dal.Del(FieldId);
        }

        public string GetFieldContent(string Content, int PlaceId, int TypeId)
        {
            return Content.Split(new char[] { ',' })[PlaceId].Split(new char[] { '=' })[TypeId].ToString();
        }

        public static string GetFieldType(string FieldType)
        {
            switch (FieldType)
            {
                case "TextType":
                    return "单行文本";

                case "ListBoxType":
                    return "多选项";

                case "DateType":
                    return "日期";

                case "MultipleHtmlType":
                    return "多行文本(支持Html)";

                case "MultipleTextType":
                    return "多行文本(不支持Html)";

                case "PicType":
                    return "图片";

                case "RadioType":
                    return "单选项";

                case "FileType":
                    return "文件";
            }
            return "";
        }

        public DataTable GetIsUserList(int CustomFormId)
        {
            return this.dal.GetIsUserList(CustomFormId);
        }

        public DataTable GetList(int CustomFormId)
        {
            return this.dal.GetList(CustomFormId);
        }

        public M_CustomFormField GetModel(int FieldId)
        {
            return this.dal.GetModel(FieldId);
        }

        public M_CustomFormField GetModel(int CustomFormId, string Name)
        {
            return this.dal.GetModel(CustomFormId, Name);
        }

        public DataTable GetSelectPropertyTrue(int CustomFormId)
        {
            return this.dal.GetSelectPropertyTrue(CustomFormId);
        }

        public DataTable GetTitleList(int CustomFormId)
        {
            return this.dal.GetTitleList(CustomFormId);
        }

        public DataSet ListSearch(int CustomFormId)
        {
            DataTable list = new DataTable();
            list = this.GetList(CustomFormId);
            if (list.Rows.Count > 0)
            {
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("Name", typeof(string)));
                table.Columns.Add(new DataColumn("Alias", typeof(string)));
                DataTable table3 = new DataTable();
                table3.Columns.Add(new DataColumn("Name", typeof(string)));
                table3.Columns.Add(new DataColumn("Alias", typeof(string)));
                table3.Columns.Add(new DataColumn("Content", typeof(string)));
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    if (list.Rows[i]["IsSearchForm"].ToString() == "True")
                    {
                        switch (list.Rows[i]["Type"].ToString())
                        {
                            case "TextType":
                            case "MultipleTextType":
                            case "MultipleHtmlType":
                            case "DateType":
                            case "RadomType":
                            {
                                DataRow row = table.NewRow();
                                row[0] = list.Rows[i]["Name"].ToString();
                                row[1] = list.Rows[i]["Alias"].ToString();
                                table.Rows.Add(row);
                                break;
                            }
                            case "RadioType":
                            case "ListBoxType":
                            {
                                DataRow row2 = table3.NewRow();
                                row2[0] = list.Rows[i]["Name"].ToString();
                                row2[1] = list.Rows[i]["Alias"].ToString();
                                row2[2] = list.Rows[i]["Content"].ToString().Split(new char[] { ',' })[0].Split(new char[] { '=' })[1];
                                table3.Rows.Add(row2);
                                break;
                            }
                        }
                    }
                }
                DataSet set = new DataSet();
                set.Tables.Add(table);
                set.Tables.Add(table3);
                return set;
            }
            return null;
        }

        public void MoveField(int CustomFormId, int FieldId, string MoveType)
        {
            this.dal.MoveField(CustomFormId, FieldId, MoveType);
        }

        public void Update(M_CustomFormField model)
        {
            this.dal.Update(model);
        }
    }
}

