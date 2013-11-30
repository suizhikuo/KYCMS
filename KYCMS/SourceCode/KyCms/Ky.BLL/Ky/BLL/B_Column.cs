namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Collections;
    using System.Data;
    using System.Web;
    using System.Web.Caching;

    public class B_Column
    {
        private IColumn ic = DataAccess.CreateColumn();

        public int Add(M_Column c)
        {
            B_Log.Add(LogType.Add, "添加栏目：" + c.ColName);
            int num = this.ic.Add(c);
            this.ClearCache();
            return num;
        }

        public bool ChkHasChildByColId(int columnId)
        {
            DataView view = new DataView(this.GetAll());
            view.RowFilter = "ColParentId=" + columnId + " And IsDeleted=0";
            return (view.Count > 0);
        }

        public bool ChkHasColumnByChId(int channelId)
        {
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc";
            view.RowFilter = "ChId=" + channelId + " And IsDeleted=0";
            return (view.Count > 0);
        }

        public bool ClearCache()
        {
            HttpContext.Current.Cache.Remove("Column");
            return (HttpContext.Current.Cache["Column"] == null);
        }

        public void CompleteDelete(int colId)
        {
            this.ic.CompleteDelete(colId);
        }

        public void Delete(int colId, int chId, string colIdStr)
        {
            this.ic.Delete(chId, colIdStr);
            this.ClearCache();
            B_Log.Add(LogType.Add, "删除栏目到回收站 编号：" + colId);
        }

        public DataTable GetAll()
        {
            if (HttpContext.Current.Cache["Column"] == null)
            {
                HttpContext.Current.Cache.Add("Column", this.ic.GetAll(), null, DateTime.Now.AddHours(1.0), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }
            return (DataTable) HttpContext.Current.Cache["Column"];
        }

        public DataView GetChildColumn(int columnId)
        {
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc";
            view.RowFilter = "ColParentId=" + columnId + " And ColParentId<>0 And IsDeleted=0";
            return view;
        }

        public DataView GetChildCoumnByColId(int columnId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColId", typeof(int));
            table.Columns.Add("ColName", typeof(string));
            table.Columns.Add("ModelType", typeof(int));
            table.Columns.Add("Type", typeof(int));
            table.Columns.Add("ChannelLinkId", typeof(int));
            table.Columns.Add("ColumnLinkId", typeof(int));
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc";
            view.RowFilter = "ColParentId=" + columnId + " And IsDeleted=0";
            for (int i = 0; i < view.Count; i++)
            {
                DataRow row = table.NewRow();
                row["ColId"] = view[i]["ColId"];
                row["ColName"] = view[i]["ColName"];
                int id = Convert.ToInt32(view[i]["ChId"]);
                M_Channel channel = new B_Channel().GetChannel(id);
                row["ModelType"] = channel.ModelType;
                row["Type"] = 3;
                row["ChannelLinkId"] = view[i]["ChId"];
                row["ColumnLinkId"] = view[i]["ColId"];
                table.Rows.Add(row);
            }
            DataView view2 = new DataView(table);
            table.Dispose();
            return view2;
        }

        public string GetChildIdByColumnId(int columnId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColId", typeof(int));
            table.Columns.Add("ColName", typeof(string));
            table.Columns.Add("Depth", typeof(int));
            DataView view = new DataView(this.GetAll());
            view.RowFilter = "ColParentId<>0 And IsDeleted=0";
            DataTable dt = view.ToTable();
            this.GetListItem(columnId, dt, 0, table);
            dt.Dispose();
            string str = columnId.ToString();
            foreach (DataRow row in table.Rows)
            {
                str = str + "," + row["ColId"];
            }
            return str;
        }

        public string GetChildIdByColumnId(int colId, int stauts)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColId", typeof(int));
            table.Columns.Add("ColName", typeof(string));
            table.Columns.Add("Depth", typeof(int));
            DataView view = new DataView(this.GetAll());
            if (stauts == 1)
            {
                view.RowFilter = "ColParentId<>0";
            }
            else if (stauts == 2)
            {
                view.RowFilter = "ColParentId<>0 And IsDeleted=0";
            }
            else if (stauts == 3)
            {
                view.RowFilter = "ColParentId<>0 And IsDeleted=1";
            }
            DataTable dt = view.ToTable();
            this.GetListItem(colId, dt, 0, table);
            dt.Dispose();
            string str = colId.ToString();
            foreach (DataRow row in table.Rows)
            {
                str = str + "," + row["ColId"];
            }
            return str;
        }

        public M_Column GetColumn(int columnId)
        {
            DataRow[] rowArray = this.GetAll().Select("ColId=" + columnId + " And IsDeleted=0");
            if (rowArray.Length > 0)
            {
                M_Column column = new M_Column();
                DataRow row = rowArray[0];
                column.ColId = (int) row["ColId"];
                column.ChId = (int) row["ChId"];
                column.ColParentId = (int) row["ColParentId"];
                column.ColName = row["ColName"].ToString();
                column.ColDirName = row["ColDirName"].ToString();
                column.IsOuterColumn = (bool) row["IsOuterColumn"];
                column.OuterColumnUrl = row["OuterColumnUrl"].ToString();
                column.ColumnTemplatePath = row["ColumnTemplatePath"].ToString();
                column.InfoTemplatePath = row["InfoTemplatePath"].ToString();//内容模板
                column.CommentTemplatePath = row["CommentTemplatePath"].ToString();
                column.Description = row["Description"].ToString();
                column.IsAllowAddInfo = (bool) row["IsAllowAddInfo"];
                column.Sort = (int) row["Sort"];
                column.IsAllowComment = (bool) row["IsAllowComment"];
                column.IsCheckComment = (bool) row["IsCheckComment"];
                column.Keyword = row["Keyword"].ToString();
                column.Content = row["Content"].ToString();
                column.IsOpened = (bool) row["IsOpened"];
                column.GroupIdStr = row["GroupIdStr"].ToString();
                column.ScoreReward = (int) row["ScoreReward"];
                column.PointCount = (int) row["PointCount"];
                column.ChargeType = (int) row["ChargeType"];
                column.ChargeHourCount = (int) row["ChargeHourCount"];
                column.ChargeViewCount = (int) row["ChargeViewCount"];
                column.ColumnPageType = (int) row["ColumnPageType"];
                column.InfoPageType = (int) row["InfoPageType"];
                column.IsDeleted = (bool) row["IsDeleted"];
                column.AddTime = (DateTime) row["AddTime"];
                return column;
            }
            return null;
        }

        public DataView GetColumnListByChannelId(int chId)
        {
            DataView view = new DataView(this.GetAll());
            view.RowFilter = "ChId=" + chId + " And IsDeleted=0";
            return view;
        }

        public DataView GetFirstColumnByChannelId(int chId)
        {
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc";
            view.RowFilter = "ChId=" + chId + " And ColParentId=0 And IsDeleted=0";
            return view;
        }

        public DataView GetFirstColumnMenuByChannelId(int chId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColId", typeof(int));
            table.Columns.Add("ColName", typeof(string));
            table.Columns.Add("ModelType", typeof(int));
            table.Columns.Add("Type", typeof(int));
            table.Columns.Add("ChannelLinkId", typeof(int));
            table.Columns.Add("ColumnLinkId", typeof(int));
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc";
            view.RowFilter = "ChId=" + chId + " And ColParentId=0 And IsDeleted=0";
            for (int i = 0; i < view.Count; i++)
            {
                DataRow row = table.NewRow();
                row["ColId"] = view[i]["ColId"];
                row["ColName"] = view[i]["ColName"];
                int id = Convert.ToInt32(view[i]["ChId"]);
                M_Channel channel = new B_Channel().GetChannel(id);
                row["ModelType"] = channel.ModelType;
                row["Type"] = 3;
                row["ChannelLinkId"] = view[i]["ChId"];
                row["ColumnLinkId"] = view[i]["ColId"];
                table.Rows.Add(row);
            }
            DataView view2 = new DataView(table);
            table.Dispose();
            return view2;
        }

        private void GetFormatListItem(int parentId, DataTable dt, int depth, DataTable dt2)
        {
            DataRow[] rowArray = dt.Select("ColParentId=" + parentId + " And IsDeleted=0", "Sort Asc");
            foreach (DataRow row in rowArray)
            {
                DataRow row2 = dt2.NewRow();
                int num = int.Parse(row["ColId"].ToString());
                row2["ColId"] = num;
                string str = row["ColName"].ToString();
                for (int i = 0; i < depth; i++)
                {
                    str = "├┄" + str;
                }
                row2["ColName"] = str;
                row2["Depth"] = depth;
                dt2.Rows.Add(row2);
                this.GetFormatListItem(num, dt, depth + 1, dt2);
            }
        }

        public DataTable GetFormatListItemByChannelId(int chId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColId", typeof(int));
            table.Columns.Add("ColName", typeof(string));
            table.Columns.Add("Depth", typeof(int));
            DataView view = new DataView(this.GetAll());
            view.RowFilter = "ChId=" + chId + " And IsDeleted=0";
            DataTable dt = view.ToTable();
            this.GetFormatListItem(0, dt, 0, table);
            dt.Dispose();
            return table;
        }

        public DataView GetList(bool isDeleted)
        {
            DataView view = new DataView(this.GetAll());
            if (isDeleted)
            {
                view.RowFilter = "IsDeleted=1";
                return view;
            }
            view.RowFilter = "IsDeleted=0";
            return view;
        }

        private void GetListItem(int parentId, DataTable dt, int depth, DataTable dt2)
        {
            DataRow[] rowArray = dt.Select("ColParentId=" + parentId + " And IsDeleted=0", "Sort Asc");
            int count = dt.Rows.Count;
            foreach (DataRow row in rowArray)
            {
                DataRow row2 = dt2.NewRow();
                int num2 = int.Parse(row["ColId"].ToString());
                row2["ColId"] = num2;
                row2["ColName"] = row["ColName"];
                row2["Depth"] = depth;
                dt2.Rows.Add(row2);
                this.GetListItem(num2, dt, depth + 1, dt2);
            }
        }

        public DataTable GetListItemByChannelId(int chId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColId", typeof(int));
            table.Columns.Add("ColName", typeof(string));
            table.Columns.Add("Depth", typeof(int));
            DataView view = new DataView(this.GetAll());
            view.RowFilter = "ChId=" + chId + " And IsDeleted=0";
            DataTable dt = view.ToTable();
            this.GetListItem(0, dt, 0, table);
            dt.Dispose();
            return table;
        }

        public string GetParentColId(int colId)
        {
            ArrayList list = new ArrayList();
            M_Column column = this.GetColumn(colId);
            if (column == null)
            {
                return null;
            }
            list.Add(colId);
            if (column.ColParentId > 0)
            {
                while (column.ColParentId >= 0)
                {
                    if (column.ColParentId > 0)
                    {
                        column = this.GetColumn(column.ColParentId);
                    }
                    else
                    {
                        column = this.GetColumn(column.ColId);
                    }
                    if (column == null)
                    {
                        return null;
                    }
                    list.Add(column.ColId);
                    if (column.ColParentId == 0)
                    {
                        break;
                    }
                }
            }
            string str = string.Empty;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                str = str + list[i].ToString() + ",";
            }
            if ((str.Length > 0) && str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public void Move(int colId, int targetId, bool isChannel, string childIdStr)
        {
            this.ic.Move(colId, targetId, isChannel, childIdStr);
            this.ClearCache();
        }

        public int Update(M_Column c)
        {
            B_Log.Add(LogType.Add, string.Concat(new object[] { "修改栏目 编号：", c.ColId, "，栏目名称：", c.ColName }));
            int num = this.ic.Update(c);
            this.ClearCache();
            return num;
        }

        public void UpdateActionTableTemplate(int ColId, string ActionTable, string InfoTemplatePath)
        {
            this.ic.UpdateActionTableTemplate(ColId, ActionTable, InfoTemplatePath);
        }

        public void UpdateTemplate(M_Column model)
        {
            this.ic.UpdateTemplate(model);
        }
    }
}

