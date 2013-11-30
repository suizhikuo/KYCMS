namespace Ky.BLL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_ModelField
    {
        private IModelField dal = DataAccess.CreateModelField();

        public void Add(M_ModelField model)
        {
            this.dal.Add(model);
        }

        public void AddField(string TableName, string FieldName, string FieldType, string DefaultValue)
        {
            this.dal.AddField(TableName, FieldName, FieldType, DefaultValue);
        }

        public void Del(int FieldId)
        {
            this.dal.Del(FieldId);
        }

        public void DelField(string TableName, string FieldName)
        {
            this.dal.DelField(TableName, FieldName);
        }

        public DataTable GetAllTable()
        {
            return this.dal.GetAllTable();
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

                case "RadomType":
                    return "随机数";

                case "NumberType":
                    return "数字";

                case "ErLinkageType":
                    return "二级联动";

                case "SanLinkageType":
                    return "三级联动";
            }
            return "";
        }

        public DataTable GetList(int ModelId)
        {
            return this.dal.GetList(ModelId);
        }

        public M_ModelField GetModel(int FieldId)
        {
            return this.dal.GetModel(FieldId);
        }

        public DataTable GetSearchField(int modelId)
        {
            return this.dal.GetSearchField(modelId);
        }

        public DataTable GetSelectPropertyTrue(int ModelId)
        {
            return this.dal.GetSelectPropertyTrue(ModelId);
        }

        public DataTable GetSysteFieldList()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Alias", typeof(string)));
            table.Columns.Add(new DataColumn("Type", typeof(string)));
            table.Columns.Add(new DataColumn("IsNotNull", typeof(string)));
            string[] strArray = "Title|标题|标题|√,ColId|栏目编号|数字|√,SpecialIdStr|专题编号|数字|√,Status|审核状态|数字|√,TemplatePath|模板路径|模板|√,HitCount|点击数|数字|√,IsRecommend|推荐|是/否|√,IsTop|置顶|是/否|√,IsFocus|焦点|是/否|√".Split(new char[] { ',' });
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

        public DataTable GetTableAllField(string TableName)
        {
            return this.dal.GetTableAllField(TableName);
        }

        public DataTable GetTableAllFieldAndType(string TableName)
        {
            return this.dal.GetTableAllFieldAndType(TableName);
        }

        public bool IsNotField(string TableName, string FieldName)
        {
            return this.dal.IsNotField(TableName, FieldName);
        }

        public void MoveField(int ModelId, int FieldId, string MoveType)
        {
            this.dal.MoveField(ModelId, FieldId, MoveType);
        }

        public void Update(M_ModelField model)
        {
            this.dal.Update(model);
        }

        public void UpdateFieldDefault(string TableName, string FieldName, string DefaultValue)
        {
            this.dal.UpdateFieldDefault(TableName, FieldName, DefaultValue);
        }
    }
}

