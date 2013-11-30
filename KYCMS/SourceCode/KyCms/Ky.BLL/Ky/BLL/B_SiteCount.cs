namespace Ky.BLL
{
    using Ky.DALFactory;
    using System;
    using System.Data;

    public class B_SiteCount
    {
        private ISiteCount dal = DataAccess.CreateSiteCount();

        public void AddDayCount()
        {
            string currDay = DateTime.Now.ToString("yyyy-MM-dd");
            string currHour = DateTime.Now.ToString("HH");
            if (currHour.StartsWith("0"))
            {
                currHour = currHour.Substring(1, currHour.Length - 1);
            }
            this.dal.AddDayCount(currDay, currHour);
        }

        public void AddMonthCount()
        {
            string currMonth = DateTime.Now.ToString("yyyy-MM");
            string currDay = DateTime.Now.ToString("dd");
            if (currDay.StartsWith("0"))
            {
                currDay = currDay.Substring(1, currDay.Length - 1);
            }
            this.dal.AddMonthCount(currMonth, currDay);
        }

        public void AddWeekCount()
        {
            string currDate = string.Empty;
            int dayOfWeek = (int) DateTime.Now.DayOfWeek;
            switch (dayOfWeek)
            {
                case 1:
                    currDate = DateTime.Now.ToString("yyyy-MM-dd");
                    break;

                case 0:
                    dayOfWeek = 7;
                    break;
            }
            this.dal.AddWeekCount(currDate, dayOfWeek.ToString());
        }

        public void AddYearCount()
        {
            string currYear = DateTime.Now.ToString("yyyy");
            string currMonth = DateTime.Now.ToString("MM");
            if (currMonth.StartsWith("0"))
            {
                currMonth = currMonth.Substring(1, currMonth.Length - 1);
            }
            this.dal.AddYearCount(currYear, currMonth);
        }

        public DataTable GetData(string dataType, string filter)
        {
            return this.dal.GetData(dataType, filter);
        }
    }
}

