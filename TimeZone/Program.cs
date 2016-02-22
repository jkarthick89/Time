using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace TimeZone
{
    class Program
    {
        static void Main(string[] args)
        {
            //added this comments
            DateTime IndianTime = new DateTime(2007, 01, 02, 12, 16, 00);            
            DateTime ESTtime = new DateTime(2015, 05, 20, 17, 57, 33);
            //added this comment1
            TimeZoneInfo ESTtimeZone2 = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");                        
            DateTime newTime = TimeZoneInfo.ConvertTime(IndianTime,TimeZoneInfo.Local, ESTtimeZone2);                      

            //DateTime ConvertedDT = GetLocalDateTime(IndianTime);

            //TimeZoneInfo oTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            //IList<TimeZoneInfo> oTimeZone = TimeZoneInfo.GetSystemTimeZones();
            //TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            //Convert
            //DateTime dt = TimeZoneInfo.CreateCustomTimeZone(IndianTime, easternZone);

            //DateTime time1 = new DateTime();// your DataTimeVariable
            //DateTime UTCTime = ESTtime1.ToUniversalTime();

            //TimeZoneInfo timeZone1 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            //String newTime1 = ESTtimeZone2.IsDaylightSavingTime(ESTtime1) ? ESTtimeZone2.DaylightName : ESTtimeZone2.StandardName;
            //TimeZoneInfo ESTnewtimeZone2 = TimeZoneInfo.FindSystemTimeZoneById(newTime1);

            //DateTime newDaylightTime = TimeZoneInfo.ConvertTime(ESTtime, timeZone1, ESTnewtimeZone2);
        }

        public static DateTime GetLocalDateTime(DateTime dt)
        {
            //Declare & initialise required variables
            TimeZoneInfo currentTimezone = GetLocalTimezone();
            DateTimeOffset offsetDate = new DateTimeOffset(dt);

            //Return the DateTime accomodating the Timezone's UTC Offset
            return offsetDate.ToOffset(currentTimezone.GetUtcOffset(offsetDate)).DateTime;
        }

        private static TimeZoneInfo GetLocalTimezone()
        {
            //'Declare & initialise required variables
            CultureInfo currentCulture = GetCurrentCulture();
            String timeZoneId = "Eastern Standard Time";//"GMT Standard Time";//'Assume UK by default

            //'Verify the country we are localising for
            switch (currentCulture.Name)
            {

                case "de-DE":
                    //'Set Time Zone ID Based on Culture
                    timeZoneId = "Central Europe Standard Time";
                    break;
                case "en-AU":
                    //'Set Time Zone ID Based on Culture
                    timeZoneId = "AUS Eastern Standard Time";
                    break;
            }

            // 'Return the timezone for the current culture
            return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }


        private static CultureInfo GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture;

        }

    }
}
