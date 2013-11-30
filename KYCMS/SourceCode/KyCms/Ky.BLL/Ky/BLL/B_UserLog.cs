namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_UserLog
    {
        private IUserLog dal = DataAccess.CreateUserLog();
        private B_SiteInfo SiteBll = new B_SiteInfo();
        private M_Site SiteModel = null;
        private B_UserGroup UserGroupBll = new B_UserGroup();
        private B_ViewLog ViewLogBll = new B_ViewLog();

        public B_UserLog()
        {
            this.SiteModel = this.SiteBll.GetSiteModel();
        }

        public void Add(M_UserLog model)
        {
            this.dal.Add(model);
        }

        public bool CheckIsPay(int checkPayType, int modelType, int infoId, int userId, int hourCount, int viewCount)
        {
            return this.dal.CheckIsPay(checkPayType, modelType, infoId, userId, hourCount, viewCount);
        }

        public bool CheckReducePointCondition(int reduceType, int userId, decimal goldNum, int point, DateTime expireTime, int dayViewCount, ref string msg)
        {
            if (reduceType == 0)
            {
                if (goldNum < point)
                {
                    msg = string.Concat(new object[] { "你所拥有的金币不够，浏览该内容页需要", point, this.SiteModel.GUnitName, "金币" });
                    return false;
                }
            }
            else if (reduceType == 1)
            {
                if (expireTime < DateTime.Now)
                {
                    msg = "你不是包月用户，只有包月用户才能浏览该内容页";
                    return false;
                }
                if (!this.ViewLogBll.CheckMaxViewCount(userId, DateTime.Now.ToString("yyyy-MM-dd"), dayViewCount))
                {
                    msg = "你今天浏览收费内容页已达到包月用户当天允许的最大浏览次数" + dayViewCount + "次";
                    return false;
                }
            }
            else if (reduceType == 2)
            {
                if ((goldNum < point) && (expireTime < DateTime.Now))
                {
                    msg = string.Concat(new object[] { "浏览该内容页需要", point, this.SiteModel.GUnitName, "金币" });
                    return false;
                }
                if (!((goldNum >= point) || this.ViewLogBll.CheckMaxViewCount(userId, DateTime.Now.ToString("yyyy-MM-dd"), dayViewCount)))
                {
                    msg = "你今天浏览收费内容页已达到包月用户当天允许的最大浏览次数" + dayViewCount + "次";
                    return false;
                }
            }
            else if ((reduceType == 3) && ((goldNum < point) || (expireTime < DateTime.Now)))
            {
                msg = string.Concat(new object[] { "浏览该内容页需要", point, this.SiteModel.GUnitName, "金币且必须是包月用户" });
                return false;
            }
            return true;
        }

        public DataTable ListLog(string whereStr, int pageSize, int pageIndex, ref int total)
        {
            return this.dal.ListLog(whereStr, pageSize, pageIndex, ref total);
        }

        public bool ReducePoint(int reduceType, int pointCount, int modelId, int infoId, string title, int userId, DateTime expireTime, string userName, int dayViewCount)
        {
            bool flag;
            M_UserLog model = new M_UserLog();
            model.ModelType = modelId;
            model.InfoId = infoId;
            model.Point = pointCount;
            model.UserId = userId;
            model.UserName = userName;
            model.Description = string.Concat(new object[] { "浏览内容，编号：", infoId, "，标题：", title });
            model.AddTime = DateTime.Now;
            if (reduceType == 0)
            {
                flag = this.dal.ReducePoint(userId, pointCount);
                if (flag)
                {
                    this.dal.Add(model);
                }
                return flag;
            }
            if (reduceType == 2)
            {
                if ((expireTime < DateTime.Now) || !this.ViewLogBll.CheckMaxViewCount(userId, DateTime.Now.ToString("yyyy-MM-dd"), dayViewCount))
                {
                    flag = this.dal.ReducePoint(userId, pointCount);
                    if (flag)
                    {
                        this.dal.Add(model);
                    }
                    return flag;
                }
                return true;
            }
            if (reduceType == 3)
            {
                flag = this.dal.ReducePoint(userId, pointCount);
                if (flag)
                {
                    this.dal.Add(model);
                }
                return flag;
            }
            return true;
        }
    }
}

