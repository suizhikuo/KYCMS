namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Web;
    using System.Web.Caching;

    public class B_Channel
    {
        private IChannel dal = DataAccess.CreateChannel();

        public int Add(M_Channel model)
        {
            B_Log.Add(LogType.Add, "添加频道：" + model.ChName);
            int num = this.dal.Add(model);
            this.ClearCache();
            return num;
        }

        public bool ChkIsHasChannelByType(int modelType)
        {
            DataView view = new DataView(this.GetAll());
            if (modelType == 0)
            {
                view.RowFilter = "IsDeleted=0";
                return (view.Count > 0);
            }
            view.RowFilter = "ModelType=" + modelType + " And IsDeleted=0";
            return (view.Count > 0);
        }

        public bool ClearCache()
        {
            HttpContext.Current.Cache.Remove("Channel");
            return (HttpContext.Current.Cache["Channel"] == null);
        }

        public void CompleteDelete(int chId)
        {
            this.dal.CompleteDelete(chId);
        }

        public void Delete(int id)
        {
            this.dal.Delete(id);
            this.ClearCache();
            new B_Column().ClearCache();
            B_Log.Add(LogType.Add, "删除频道到回收站 编号为：" + id);
        }

        public DataTable GetAll()
        {
            if (HttpContext.Current.Cache["Channel"] == null)
            {
                HttpContext.Current.Cache.Add("Channel", this.dal.GetAll(), null, DateTime.Now.AddHours(1.0), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }
            return (DataTable) HttpContext.Current.Cache["Channel"];
        }

        public M_Channel GetChannel(int id)
        {
            return this.GetChannel(id, 0);
        }

        public M_Channel GetChannel(int id, int isDeleted)
        {
            M_Channel channel = new M_Channel();
            DataRow[] rowArray = this.GetAll().Select(string.Concat(new object[] { "ChId=", id, "And IsDeleted=", isDeleted }));
            if (rowArray.Length > 0)
            {
                DataRow row = rowArray[0];
                channel.ChId = (int) row["ChId"];
                channel.ChName = row["ChName"].ToString();
                channel.Description = row["Description"].ToString();
                channel.TemplatePath = row["TemplatePath"].ToString();
                channel.IsChildSite = (bool) row["IsChildSite"];
                channel.ChildSiteUrl = row["ChildSiteUrl"].ToString();
                channel.IsOpenLink = (bool) row["IsOpenLink"];
                channel.ModelType = (int) row["ModelType"];
                channel.DirName = row["DirName"].ToString();
                channel.TypeName = row["TypeName"].ToString();
                channel.TypeUnit = row["TypeUnit"].ToString();
                channel.IsDisabled = (bool) row["IsDisabled"];
                channel.IsOpened = (bool) row["IsOpened"];
                channel.GroupIdStr = row["GroupIdStr"].ToString();
                channel.VerifyType = (int) row["VerifyType"];
                channel.Notice1 = row["Notice1"].ToString();
                channel.Notice2 = row["Notice2"].ToString();
                channel.Keyword = row["Keyword"].ToString();
                channel.Content = row["Content"].ToString();
                channel.MiniHitCount = (int) row["MiniHitCount"];
                channel.IsStaticType = (bool) row["IsStaticType"];
                channel.ColumnSortType = (int) row["ColumnSortType"];
                channel.InfoSortType = (int) row["InfoSortType"];
                channel.FileNameType = (int) row["FileNameType"];
                channel.ChannelPageType = (int) row["ChannelPageType"];
                channel.ColumnPageType = (int) row["ColumnPageType"];
                channel.InfoPageType = (int) row["InfoPageType"];
                channel.AddTime = (DateTime) row["AddTime"];
                channel.Sort = (int) row["Sort"];
                channel.ColumnTemplatePath = row["ColumnTemplatePath"].ToString();
                channel.InfoTemplatePath = row["InfoTemplatePath"].ToString();
                channel.CommentTemplatePath = row["CommentTemplatePath"].ToString();
                channel.ChType = (row["ChType"].ToString() == string.Empty) ? 0 : int.Parse(row["ChType"].ToString());
                return channel;
            }
            return null;
        }

        public DataView GetChannelByType(int modelType)
        {
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc";
            if (modelType == 0)
            {
                view.RowFilter = "IsDeleted=0";
                return view;
            }
            view.RowFilter = "ModelType=" + modelType + "And IsDeleted=0";
            return view;
        }

        public DataView GetChannelByType(string modelType)
        {
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc";
            view.RowFilter = "ModelType in (" + modelType + ") And IsDeleted=0";
            return view;
        }

        public DataView GetChannelMenuDataByType(int modelType)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ChId", typeof(int));
            table.Columns.Add("ChName", typeof(string));
            table.Columns.Add("ModelType", typeof(int));
            table.Columns.Add("Type", typeof(int));
            table.Columns.Add("ChannelLinkId", typeof(int));
            table.Columns.Add("ColumnLinkId", typeof(int));
            DataView view = new DataView(this.GetAll());
            if (modelType == 0)
            {
                view.Sort = "ModelType,Sort Asc";
                view.RowFilter = "IsDeleted=0";
            }
            else
            {
                view.Sort = "ModelType,Sort Asc";
                view.RowFilter = "ModelType=" + modelType + " And IsDeleted=0";
            }
            for (int i = 0; i < view.Count; i++)
            {
                DataRow row = table.NewRow();
                row["ChId"] = view[i]["ChId"];
                row["ChName"] = view[i]["ChName"];
                row["ModelType"] = view[i]["ModelType"];
                row["Type"] = 2;
                row["ChannelLinkId"] = view[i]["ChId"];
                row["ColumnLinkId"] = 0;
                table.Rows.Add(row);
            }
            DataView view2 = new DataView(table);
            table.Dispose();
            return view2;
        }

        public DataView GetList(bool isDeleted)
        {
            DataView view = new DataView(this.GetAll());
            view.Sort = "Sort Asc,ChId Asc";
            if (isDeleted)
            {
                view.RowFilter = "IsDeleted=1";
                return view;
            }
            view.RowFilter = "IsDeleted=0";
            return view;
        }

        public void SetDisable(int ChId, bool IsDisabled)
        {
            this.dal.SetDisable(ChId, IsDisabled);
            this.ClearCache();
            if (!IsDisabled)
            {
                B_Log.Add(LogType.Add, "禁用频道 编号：" + ChId);
            }
            else
            {
                B_Log.Add(LogType.Add, "启用频道 编号：" + ChId);
            }
        }

        public int Update(M_Channel model)
        {
            B_Log.Add(LogType.Add, "修改频道：" + model.ChName);
            int num = this.dal.Update(model);
            this.ClearCache();
            return num;
        }
    }
}

