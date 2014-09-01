namespace BaristaLabs.Skrapr.Common.Converters
{
    using BaristaLabs.Skrapr.Common.DomainModel;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converts a json target into a concrete target based on type.
    /// </summary>
    class TargetConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(System.Type objectType)
        {
            return typeof(TargetBase).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var typeName = jsonObject["type"].ToString();

            TargetBase target;
            switch (typeName)
            {
                case "web":
                    target = new WebTarget();
                    break;
                case "blob":
                    target = new BlobTarget();
                    break;
                case "rss":
                    target = new RssTarget();
                    break;
                default:
                    return null;
            }

            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
