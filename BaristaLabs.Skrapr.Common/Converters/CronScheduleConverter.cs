namespace BaristaLabs.Skrapr.Common.Converters
{
    using System;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converts the CronSchedule object into a CronExpression.
    /// </summary>
    public class CronScheduleConverter : JsonConverter
    {
        public override bool CanConvert(System.Type objectType)
        {
            return typeof (CronSchedule) == objectType;
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType != typeof (string))
                throw new JsonSerializationException("Unable to deserialize CronSchedule:" + reader.ToString());

            return new CronSchedule(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var cronSchedule = value as CronSchedule;
            if (cronSchedule == null)
                return;

            var result = new JValue(cronSchedule.ToString());
            writer.WriteValue(result);
        }
    }
}
