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
        /// <summary>
        /// Gets or sets the url pattern to use. This is a regular expression.
        /// </summary>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the mime type to use. This is a regular expression.
        /// </summary>
        [JsonProperty("mimeType")]
        public string MimeType
        {
            get;
            set;
        }
    }
}
