namespace BaristaLabs.Skrapr.Common.Converters
{
    using BaristaLabs.Skrapr.Common.DomainModel;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class AuthenticatorConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(System.Type objectType)
        {
            return typeof(IAuthenticator).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var typeName = jsonObject["type"].ToString();

            IAuthenticator authenticator;
            switch (typeName)
            {
                case "basic":
                    authenticator = new BasicAuthenticator();
                    break;
                case "digest":
                    authenticator = new DigestAuthenticator();
                    break;
                case "ntlm":
                    authenticator = new NtlmAuthenticator();
                    break;
                case "form":
                    authenticator = new FormAuthenticator();
                    break;
                default:
                    return null;
            }

            serializer.Populate(jsonObject.CreateReader(), authenticator);
            return authenticator;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
