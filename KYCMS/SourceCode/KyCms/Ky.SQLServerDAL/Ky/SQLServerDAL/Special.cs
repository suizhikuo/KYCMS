namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Special : ISpecial
    {
        public void Add(M_Special model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@SiteID", SqlDbType.Int, 4), new SqlParameter("@SpecialCName", SqlDbType.NVarChar, 30), new SqlParameter("@SpecialEName", SqlDbType.NVarChar, 20), new SqlParameter("@SpecialDomain", SqlDbType.NVarChar, 100), new SqlParameter("@SpecialRemark", SqlDbType.NVarChar, 200), new SqlParameter("@IsLock", SqlDbType.Bit, 1), new SqlParameter("@IsCommand", SqlDbType.Bit, 1), new SqlParameter("@SpecialAddTime", SqlDbType.DateTime), new SqlParameter("@MetaKeyWord", SqlDbType.NVarChar, 200), new SqlParameter("@MetaRemark", SqlDbType.NVarChar, 200), new SqlParameter("@SpecialTemplet", SqlDbType.NVarChar, 200), new SqlParameter("@SpecialItemNum", SqlDbType.Int, 4), new SqlParameter("@SpecialContent", SqlDbType.NText), new SqlParameter("@SaveDirType", SqlDbType.NVarChar, 200), new SqlParameter("@Extension", SqlDbType.VarChar, 50), 
                new SqlParameter("@PicSavePath", SqlDbType.NVarChar, 200), new SqlParameter("@IsDeleted", SqlDbType.Bit, 1)
             };
            commandParameters[0].Value = model.ParentID;
            commandParameters[1].Value = model.SiteID;
            commandParameters[2].Value = model.SpecialCName;
            commandParameters[3].Value = model.SpecialEName;
            commandParameters[4].Value = model.SpecialDomain;
            commandParameters[5].Value = model.SpecialRemark;
            commandParameters[6].Value = model.IsLock;
            commandParameters[7].Value = model.IsCommand;
            commandParameters[8].Value = model.SpecialAddTime;
            commandParameters[9].Value = model.MetaKeyWord;
            commandParameters[10].Value = model.MetaRemark;
            commandParameters[11].Value = model.SpecialTemplet;
            commandParameters[12].Value = model.SpecialItemNum;
            commandParameters[13].Value = model.SpecialContent;
            commandParameters[14].Value = model.SaveDirType;
            commandParameters[15].Value = model.Extension;
            commandParameters[16].Value = model.PicSavePath;
            commandParameters[17].Value = model.IsDeleted;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_Add", commandParameters);
        }

        public void CompleteDelete(int specialId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@specialid", specialId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_CompleteDelete", commandParameters);
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_Delete", commandParameters);
        }

        public DataTable GetAllSpecial()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("SpecialCName", typeof(string));
            table.Columns.Add("Depth", typeof(int));
            DataTable dt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_GetAll", null);
            this.GetListItem(0, dt, 0, table);
            dt.Dispose();
            return table;
        }

        public DataTable GetChannelSpecial(int chId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", chId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_GetChSpecialList", commandParameters);
        }

        private void GetListItem(int parentId, DataTable dt, int depth, DataTable dt2)
        {
            DataRow[] rowArray = dt.Select("ParentID=" + parentId);
            foreach (DataRow row in rowArray)
            {
                DataRow row2 = dt2.NewRow();
                int num = int.Parse(row["ID"].ToString());
                row2["ID"] = num;
                row2["SpecialCName"] = row["SpecialCName"];
                row2["Depth"] = depth;
                dt2.Rows.Add(row2);
                this.GetListItem(num, dt, depth + 1, dt2);
            }
        }

        public M_Special GetSpecial(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            M_Special special = new M_Special();
            DataSet set = new DataSet();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_GetSpecial", commandParameters);
            if (table != null)
            {
                set.Tables.Add(table.Copy());
            }
            special.ID = id;
            if (set.Tables[0].Rows.Count > 0)
            {
                if (set.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    special.ParentID = int.Parse(set.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (set.Tables[0].Rows[0]["SiteID"].ToString() != "")
                {
                    special.SiteID = int.Parse(set.Tables[0].Rows[0]["SiteID"].ToString());
                }
                special.SpecialCName = set.Tables[0].Rows[0]["SpecialCName"].ToString();
                special.SpecialEName = set.Tables[0].Rows[0]["SpecialEName"].ToString();
                special.Extension = set.Tables[0].Rows[0]["Extension"].ToString();
                special.PicSavePath = set.Tables[0].Rows[0]["PicSavePath"].ToString();
                special.SpecialDomain = set.Tables[0].Rows[0]["SpecialDomain"].ToString();
                special.SpecialRemark = set.Tables[0].Rows[0]["SpecialRemark"].ToString();
                if (set.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsLock"].ToString() == "1") || (set.Tables[0].Rows[0]["IsLock"].ToString().ToLower() == "true"))
                    {
                        special.IsLock = true;
                    }
                    else
                    {
                        special.IsLock = false;
                    }
                }
                if (set.Tables[0].Rows[0]["IsCommand"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsCommand"].ToString() == "1") || (set.Tables[0].Rows[0]["IsCommand"].ToString().ToLower() == "true"))
                    {
                        special.IsCommand = true;
                    }
                    else
                    {
                        special.IsCommand = false;
                    }
                }
                if (set.Tables[0].Rows[0]["IsDeleted"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsDeleted"].ToString() == "1") || (set.Tables[0].Rows[0]["IsDeleted"].ToString().ToLower() == "true"))
                    {
                        special.IsDeleted = true;
                    }
                    else
                    {
                        special.IsDeleted = false;
                    }
                }
                if (set.Tables[0].Rows[0]["SpecialAddTime"].ToString() != "")
                {
                    special.SpecialAddTime = DateTime.Parse(set.Tables[0].Rows[0]["SpecialAddTime"].ToString());
                }
                special.MetaKeyWord = set.Tables[0].Rows[0]["MetaKeyWord"].ToString();
                special.MetaRemark = set.Tables[0].Rows[0]["MetaRemark"].ToString();
                special.SpecialTemplet = set.Tables[0].Rows[0]["SpecialTemplet"].ToString();
                if (set.Tables[0].Rows[0]["SpecialItemNum"].ToString() != "")
                {
                    special.SpecialItemNum = int.Parse(set.Tables[0].Rows[0]["SpecialItemNum"].ToString());
                }
                special.SpecialContent = set.Tables[0].Rows[0]["SpecialContent"].ToString();
                special.SaveDirType = set.Tables[0].Rows[0]["SaveDirType"].ToString();
                return special;
            }
            return null;
        }

        public DataTable GetSpecialByParentId(int id)
        {
            return this.GetSpecials(1, id);
        }

        public DataTable GetSpecials(int SelectType)
        {
            return this.GetSpecials(SelectType, 0);
        }

        private DataTable GetSpecials(int selectType, int parentId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SelectType", SqlDbType.Int, 4), new SqlParameter("@ParentId", SqlDbType.Int, 4) };
            commandParameters[0].Value = selectType;
            commandParameters[1].Value = parentId;
            DataTable table = new DataTable("Specials");
            table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_GetSpecials", commandParameters);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str = table.Rows[i]["Extension"].ToString();
                if (str != null)
                {
                    if (!(str == "1"))
                    {
                        if (str == "2")
                        {
                            goto Label_00EB;
                        }
                        if (str == "3")
                        {
                            goto Label_0109;
                        }
                        if (str == "4")
                        {
                            goto Label_0127;
                        }
                    }
                    else
                    {
                        table.Rows[i]["Extension"] = ".html";
                    }
                }
                continue;
            Label_00EB:
                table.Rows[i]["Extension"] = ".htm";
                continue;
            Label_0109:
                table.Rows[i]["Extension"] = ".shtml";
                continue;
            Label_0127:
                table.Rows[i]["Extension"] = ".aspx";
            }
            return table;
        }

        public void Update(M_Special model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@SiteID", SqlDbType.Int, 4), new SqlParameter("@SpecialCName", SqlDbType.NVarChar, 30), new SqlParameter("@SpecialDomain", SqlDbType.NVarChar, 100), new SqlParameter("@SpecialRemark", SqlDbType.NVarChar, 200), new SqlParameter("@IsLock", SqlDbType.Bit, 1), new SqlParameter("@IsCommand", SqlDbType.Bit, 1), new SqlParameter("@SpecialAddTime", SqlDbType.DateTime), new SqlParameter("@MetaKeyWord", SqlDbType.NVarChar, 200), new SqlParameter("@MetaRemark", SqlDbType.NVarChar, 200), new SqlParameter("@SpecialTemplet", SqlDbType.NVarChar, 200), new SqlParameter("@SpecialItemNum", SqlDbType.Int, 4), new SqlParameter("@SpecialContent", SqlDbType.NText), new SqlParameter("@SaveDirType", SqlDbType.NVarChar, 200), new SqlParameter("@Extension", SqlDbType.VarChar), 
                new SqlParameter("@PicSavePath", SqlDbType.NVarChar, 200)
             };
            commandParameters[0].Value = model.ID;
            commandParameters[1].Value = model.ParentID;
            commandParameters[2].Value = model.SiteID;
            commandParameters[3].Value = model.SpecialCName;
            commandParameters[4].Value = model.SpecialDomain;
            commandParameters[5].Value = model.SpecialRemark;
            commandParameters[6].Value = model.IsLock;
            commandParameters[7].Value = model.IsCommand;
            commandParameters[8].Value = model.SpecialAddTime;
            commandParameters[9].Value = model.MetaKeyWord;
            commandParameters[10].Value = model.MetaRemark;
            commandParameters[11].Value = model.SpecialTemplet;
            commandParameters[12].Value = model.SpecialItemNum;
            commandParameters[13].Value = model.SpecialContent;
            commandParameters[14].Value = model.SaveDirType;
            commandParameters[15].Value = model.Extension;
            commandParameters[16].Value = model.PicSavePath;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Special_Update", commandParameters);
        }
    }
}

