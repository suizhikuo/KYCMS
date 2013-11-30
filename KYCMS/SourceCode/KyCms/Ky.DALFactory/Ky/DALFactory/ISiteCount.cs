namespace Ky.DALFactory
{
    using System;
    using System.Data;

    public interface ISiteCount
    {
        void AddDayCount(string currDay, string currHour);
        void AddMonthCount(string currMonth, string currDay);
        void AddWeekCount(string currDate, string currWeekDay);
        void AddYearCount(string currYear, string currMonth);
        DataTable GetData(string dataType, string filter);
    }
}

