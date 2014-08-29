namespace BaristaLabs.Skrapr.Common.Converters
{
    using BaristaLabs.Skrapr.Common.DomainModel;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class PropertyPluckrConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(System.Type objectType)
        {
            return typeof(IPropertyPluckr).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var typeName = jsonObject["type"].ToString();

            IPropertyPluckr pluckr;
            switch (typeName)
            {
                case "title":
                    pluckr = new TitlePropertyPluckr();
                    break;
                case "const":
                    pluckr = new ConstPropertyPluckr();
                    break;
                case "nowUtc":
                    pluckr = new NowUtcPropertyPluckr();
                    break;
                case "url":
                    pluckr = new UrlPropertyPluckr();
                    break;
                case "lastPathSegment":
                    pluckr = new LastPathSegmentPropertyPluckr();
                    break;
                case "queryString":
                    pluckr = new QueryStringValuePropertyPluckr();
                    break;
                case "header":
                    pluckr = new HeaderPropertyPluckr();
                    break;
                case "cookie":
                    pluckr = new CookiePropertyPluckr();
                    break;
                case "cssHtml":
                    pluckr = new CssHtmlPropertyPluckr();
                    break;
                case "cssText":
                    pluckr = new CssTextPropertyPluckr();
                    break;
                case "cssAttr":
                    pluckr = new CssAttributePropertyPluckr();
                    break;
                case "script":
                    pluckr = new ScriptPropertyPluckr();
                    break;
                default:
                    return null;
            }

            serializer.Populate(jsonObject.CreateReader(), pluckr);
            return pluckr;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
