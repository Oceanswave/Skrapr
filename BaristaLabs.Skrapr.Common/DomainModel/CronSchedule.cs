namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using BaristaLabs.Skrapr.Common.Converters;
    using Newtonsoft.Json;
    using Quartz;

    /// <summary>
    /// Represents a schedule defined as a CronExpression. See http://quartz-scheduler.org/api/2.2.0/org/quartz/CronExpression.html
    /// </summary>
    [JsonConverter(typeof(CronScheduleConverter))]
    public class CronSchedule : Schedule
    {
        private readonly CronExpression m_cronExpression;
        public CronSchedule(string cronExpression)
        {
            m_cronExpression = new CronExpression(cronExpression);
        }

        public override string Name
        {
            get { return "cron"; }
        }

        [JsonIgnore]
        public CronExpression Expression
        {
            get { return m_cronExpression; }
        }

        public override string ToString()
        {
            return m_cronExpression.ToString();
        }
    }
}
