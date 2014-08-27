namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a target pattern
    /// </summary>
    /// <remarks>
    /// If the response matches the url and mime type, then the result will be processed by the target.
    /// </remarks>
    public class TargetPattern
    {
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        [JsonProperty("mimeType")]
        public string MimeType
        {
            get;
            set;
        }
    }
}
