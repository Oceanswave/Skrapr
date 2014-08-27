namespace BaristaLabs.Skrapr.Common.Converters
{
    using Newtonsoft.Json;

    /// <summary>
    /// Converts the CronSchedule object into a CronExpression.
    /// </summary>
    public class CronScheduleConverter : JsonConverter
    {
        public override bool CanConvert(System.Type objectType)
        {
            throw new System.NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
