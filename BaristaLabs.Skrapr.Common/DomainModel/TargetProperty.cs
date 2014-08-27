namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

    public class TargetProperty
    {
        /// <summary>
        /// Gets or sets a value that indicates the property name. Can be '.' seperated values
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        //TODO: IsType, IsId, IsRev

        //TODO: Text/Html/Script
        [JsonProperty("skrapr")]
        public TargetPropertySkrapr Skrapr
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a JavaScript based script that will transform the value.
        /// </summary>
        [JsonProperty("transform")]
        public string Transform
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if the crawled property is an array.
        /// </summary>
        [JsonProperty("isArray")]
        public bool IsArray
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if the crawled property is a child url.
        /// </summary>
        [JsonProperty("isChildUrl")]
        public bool IsChildUrl
        {
            get;
            set;
        }
    }
}
