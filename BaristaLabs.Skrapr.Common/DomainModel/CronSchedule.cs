namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using BaristaLabs.Skrapr.Common.Converters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a CronExpression. See http://quartz-scheduler.org/api/2.2.0/org/quartz/CronExpression.html
    /// </summary>
    [JsonConverter(typeof(CronScheduleConverter))]
    public class CronSchedule : Schedule
    {
        public CronSchedule()
        {
            Seconds = "0";
            Minutes = "0";
            Hours = "0";
            DayOfMonth = "*";
            Month = "*";
            DayOfWeek = "?";
        }

        public override string Name
        {
            get { return "cron"; }
        }

        public string Seconds
        {
            get;
            set;
        }

        public string Minutes
        {
            get;
            set;
        }

        public string Hours
        {
            get;
            set;
        }

        public string DayOfMonth
        {
            get;
            set;
        }

        public string Month
        {
            get;
            set;
        }

        public string DayOfWeek
        {
            get;
            set;
        }

        public string Year
        {
            get;
            set;
        }
    }
}
