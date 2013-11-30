namespace Ky.BLL
{
    using Ky.BLL.CommonModel;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Text;

    public class B_InfoOper
    {
        private IInfoOper dal = DataAccess.CreateInfoOper();

        public void AddHitCount(string tableName, int id)
        {
            this.dal.AddHitCount(tableName, id);
        }

        public void Auditing(string tableName, string idStr, int status)
        {
            if (idStr != string.Empty)
            {
                B_Admin admin = new B_Admin();
                B_Column column = new B_Column();
                B_Channel channel = new B_Channel();
                string[] strArray = idStr.Split(new char[] { ',' });
                foreach (string str in strArray)
                {
                    int id = int.Parse(str);
                    DataRow info = this.dal.GetInfo(tableName, id);
                    if (info == null)
                    {
                        break;
                    }
                    int columnId = (int) info["colid"];
                    M_Column column2 = column.GetColumn(columnId);
                    if (column2 == null)
                    {
                        break;
                    }
                    M_Channel channel2 = channel.GetChannel(column2.ChId);
                    if (channel2 == null)
                    {
                        break;
                    }
                    int num3 = (int) info["Status"];
                    int num4 = (int) info["UserType"];
                    int userId = (int) info["UId"];
                    string str2 = info["UName"].ToString();
                    string newValue = info["Title"].ToString();
                    string str4 = channel2.Notice2.Replace("{@标题}", newValue);
                    M_LoginAdmin loginModel = admin.GetLoginModel();
                    int adiminId = loginModel.UserId;
                    string loginName = loginModel.LoginName;
                    this.dal.Auditing(tableName, id, status, adiminId, loginName);
                    if ((((status == 3) && (num3 != 3)) && (num4 == 0)) && (userId > 0))
                    {
                        B_WebMessage message = new B_WebMessage();
                        M_WebMessage message2 = new M_WebMessage();
                        message2.Title = "稿件采纳通知";
                        message2.Content = str4;
                        message2.IsRead = 0;
                        message2.IsSend = 1;
                        message2.ReceiverId = userId;
                        message2.ReceiverName = str2;
                        message2.SendId = 0;
                        message2.SendName = loginName;
                        message2.OverdueDate = DateTime.Now;
                        message2.AddDate = DateTime.Now;
                        message2.ReceiverDel = 0;
                        message2.SendDel = 0;
                        message.Insert(message2);
                    }
                    M_User user = new B_User().GetUser(userId);
                    if (user == null)
                    {
                        break;
                    }
                    B_UserGroup group = new B_UserGroup();
                    M_UserGroup model = group.GetModel(user.GroupID);
                    if (group == null)
                    {
                        break;
                    }
                    int num7 = int.Parse(group.Power_UserGroup("Contribute", 0, model.GroupPower)) * column2.ScoreReward;
                    new B_Money().Integral(num7, userId);
                }
            }
        }

        public string BuildLinkString()
        {
            StringBuilder builder = new StringBuilder();
            DataTable list = new B_InfoModel().GetList();
            if ((list == null) || (list.Rows.Count <= 0))
            {
                return "";
            }
            foreach (DataRow row in list.Rows)
            {
                builder.Append(" | <a href=\"RecycleInfo.aspx");
                builder.Append("?ModelId=");
                builder.Append(row["ModelId"].ToString());
                builder.Append("\">");
                builder.Append(row["ModelName"].ToString());
                builder.Append("</a>");
            }
            return builder.ToString();
        }

        public void Cancel(string tableName, int id)
        {
            B_Channel channel = new B_Channel();
            B_Column column = new B_Column();
            B_Admin admin = new B_Admin();
            DataRow info = this.dal.GetInfo(tableName, id);
            if (info != null)
            {
                int columnId = (int) info["colid"];
                M_Column column2 = column.GetColumn(columnId);
                if (column2 != null)
                {
                    M_Channel channel2 = channel.GetChannel(column2.ChId);
                    if (channel2 != null)
                    {
                        int num2 = (int) info["UserType"];
                        int num3 = (int) info["UId"];
                        string str = info["UName"].ToString();
                        string newValue = info["Title"].ToString();
                        string str3 = channel2.Notice1.Replace("{@标题}", newValue);
                        string loginName = admin.GetLoginModel().LoginName;
                        this.dal.Cancel(tableName, id);
                        if ((num2 == 0) && (num3 > 0))
                        {
                            B_WebMessage message = new B_WebMessage();
                            M_WebMessage model = new M_WebMessage();
                            model.Title = "退稿通知";
                            model.Content = str3;
                            model.IsRead = 0;
                            model.IsSend = 1;
                            model.ReceiverId = num3;
                            model.ReceiverName = str;
                            model.SendId = 0;
                            model.SendName = loginName;
                            model.OverdueDate = DateTime.Now;
                            model.AddDate = DateTime.Now;
                            model.ReceiverDel = 0;
                            model.SendDel = 0;
                            message.Insert(model);
                        }
                    }
                }
            }
        }

        public void CompleteDeleteInfo(string tableName, int id)
        {
            this.dal.CompleteDeleteInfo(tableName, id);
        }

        public void DeleteInfoToRecycle(string idStr, string tableName)
        {
            this.dal.DeleteInfoToRecycle(idStr, tableName);
        }

        public DataSet GetCustomTableList(string TableName, int currPage, int pageSize, string strWhere)
        {
            return this.dal.GetCustomTableList(TableName, currPage, pageSize, strWhere);
        }

        public int GetHitCount(string tableName, int id)
        {
            return this.dal.GetHitCount(tableName, id);
        }

        public DataRow GetInfo(string tableName, int id)
        {
            return this.dal.GetInfo(tableName, id);
        }

        public DataTable GetInfoList(string tableName, string fieldName, string keyword, int chId, string colIdStr, string status, string property, string propertyType, string propertyValue, int userType, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.dal.GetInfoList(tableName, fieldName, keyword, chId, colIdStr, status, property, propertyType, propertyValue, userType, pageIndex, pageSize, ref recordCount);
        }

        public DataTable GetRecycleInfoList(string tableName, int type, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.dal.GetRecycleInfoList(tableName, type, pageIndex, pageSize, ref recordCount);
        }

        public DataTable GetRssInfoList(string tableName, int chId, string colId)
        {
            return this.dal.GetRssInfoList(tableName, chId, colId);
        }

        public DataTable GetSpecialInfoList(string tableNameStr, int specialId)
        {
            return this.dal.GetSpecialInfoList(tableNameStr, specialId);
        }

        public DataRow GetUserInfo(string tableName, int UserId)
        {
            return this.dal.GetUserInfo(tableName, UserId);
        }

        public DataTable GetUserInfoList(string tableName, int uId, string fieldName, string keyword, int chId, string colIdStr, string status, string property, string propertyType, string propertyValue, int userCateId, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.dal.GetUserInfoList(tableName, uId, fieldName, keyword, chId, colIdStr, status, property, propertyType, propertyValue, userCateId, pageIndex, pageSize, ref recordCount);
        }

        public bool IsExistsInfoByUserId(string tableName, int userId)
        {
            return this.dal.IsExistsInfoByUserId(tableName, userId);
        }

        public void MassMoveInfo(string tableName, string idStr, int colId, int targetColId)
        {
            this.dal.MassMoveInfo(tableName, idStr, colId, targetColId);
        }

        public void MassSetInfo(string tableName, string idStr, int colId, bool tagFlag, string tagIdStr, string tagNameStr, bool topFlag, bool isTop, bool recommendFlag, bool isRecommend, bool focusFlag, bool isFocus, bool templatePathFlag, string templatePath, bool hitCountFlag, int hitCount, bool isOpenedFlag, int isOpened, bool groupIdStrFlag, string groupIdStr, bool pointCountFlag, int pointCount, bool chargeTypeFlag, int chargeType, bool chargeHourCountFlag, int chargeHourCount, bool chargeViewCountFlag, int chargeViewCount, bool pageTypeFlag, int pageType)
        {
            this.dal.MassSetInfo(tableName, idStr, colId, tagFlag, tagIdStr, tagNameStr, topFlag, isTop, recommendFlag, isRecommend, focusFlag, isFocus, templatePathFlag, templatePath, hitCountFlag, hitCount, isOpenedFlag, isOpened, groupIdStrFlag, groupIdStr, pointCountFlag, pointCount, chargeTypeFlag, chargeType, chargeHourCountFlag, chargeHourCount, chargeViewCountFlag, chargeViewCount, pageTypeFlag, pageType);
        }

        public void RestoreRecycle(string tableName, int type, int id)
        {
            this.dal.RestoreRecycle(tableName, type, id);
        }

        public void SetInfoSpecial(string tableName, int id, string specialIdStr)
        {
            this.dal.SetInfoSpecial(tableName, id, specialIdStr);
        }

        public void SetProperty(string tableName, string property, string propertyValue, int id)
        {
            this.dal.SetProperty(tableName, property, propertyValue, id);
        }

        public void SetPublish(string tableName, int id, int uId)
        {
            this.dal.SetPublish(tableName, id, uId);
        }

        public void UpdateIsCreated(string tableName, int id)
        {
            this.dal.UpdateIsCreated(tableName, id);
        }

        public void UserDeleteInfo(string idStr, string tableName, int uId)
        {
            this.dal.UserDeleteInfo(idStr, tableName, uId);
        }
    }
}

