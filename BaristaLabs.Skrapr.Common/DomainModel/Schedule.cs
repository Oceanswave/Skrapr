namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Quartz;

    public abstract class Schedule : ISchedule
    {
        /// <summary>
        /// Gets the type of the schedule
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public abstract string Type
        {
            get;
        }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a schedule defined as a CronExpression. See http://quartz-scheduler.org/api/2.2.0/org/quartz/CronExpression.html
    /// </summary>
    public class CronSchedule : Schedule
    {
        public override string Type
        {
            get { return "cron"; }
        }

        [JsonProperty("cronExpression", Required = Required.Always)]
        public string CronExpression
        {
            get;
            set;
        }

        public CronExpression GetCronExpression()
        {
            return new CronExpression(CronExpression);
        }
    }
}
