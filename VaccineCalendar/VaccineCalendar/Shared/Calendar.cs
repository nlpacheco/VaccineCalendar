using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCalendar.Shared
{
    public static class Calendar
    {
        static readonly DateTime TodayDebug = new DateTime(2018, 06, 5);
        public static DateTime Today
        {
            get { return (Settings.DebugMode) ? TodayDebug : DateTime.Today; } 
        }

        public static string IdadeTexto(DateTime BirthDay)
        {

            int numAnos = Years(BirthDay, Today);
            if (numAnos >= 2)
                return ($"{numAnos} anos.");
            int numMeses = Months(BirthDay, Today);
            return numMeses> 1 ? ($"{numMeses} meses.") : ($"{numMeses} mes.") ;
        }


        private static int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }

        private static int Months(DateTime start, DateTime end)
        {
            if (start.Date >= end.Date) return 0;
            return (end.Year * 12 + end.Month) - (start.Year * 12 + start.Month) - ((end.Day < start.Day) ? 1 : 0);
        }
    }
}