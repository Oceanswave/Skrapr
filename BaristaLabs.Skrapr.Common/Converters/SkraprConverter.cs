namespace BaristaLabs.Skrapr.Common.Converters
{
    using BaristaLabs.Skrapr.Common.DomainModel;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class SkraprConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(System.Type objectType)
        {
            return typeof(ISchedule).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var typeName = jsonObject["type"].ToString();

            ISkrapr skrapr;
            switch (typeName)
            {
                case "web":
                    skrapr = new WebSkrapr();
                    break;
                default:
                    return null;
            }

            serializer.Populate(jsonObject.CreateReader(), skrapr);
            return skrapr;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
