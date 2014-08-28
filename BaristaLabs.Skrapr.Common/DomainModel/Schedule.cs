namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

    public abstract class Schedule
    {
        /// <summary>
        /// Gets the of the schedule
        /// </summary>
        [JsonProperty("name")]
        public abstract string Name
        {
            get;
        }
    }
}
