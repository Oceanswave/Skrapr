namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents a skrapr target.
    /// </summary>
    /// <remarks>
    /// A skrapr may contain a number of types of targets. For instance, a website would be crawled via a webtarget,
    /// while crawling a rssreader would use a rsstarget.
    /// 
    /// These differing kinds of targets have different semantics surrounding how they must be skraped.
    /// 
    /// Skraprs may combine targets in order to provide a hollistic view of data.
    /// </remarks>
    public abstract class TargetBase
    {
        /// <summary>
        /// Gets or sets the id of the target.
        /// </summary>
        [JsonProperty("_id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the type of target (web, rss, etc...)
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public abstract string Type
        {
            get;
        }

        /// <summary>
        /// Gets or sets the id of the skrapr that the target is associated with.
        /// </summary>
        [JsonProperty("skraprId", Required = Required.Always)]
        public string SkraprId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the target.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description of the target.
        /// </summary>
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a url pattern that this target will apply.
        /// </summary>
        /// <remarks>
        /// For instance, if a pattern is http://.*.winamp.com and the crawled url matches, then the target will evaluated.
        /// 
        /// All targets whose patterns match will be executed.
        /// </remarks>
        [JsonProperty("pattern")]
        public TargetPattern Pattern
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if the status of the target.
        /// </summary>
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(TargetStatus.Active)]
        public TargetStatus Status
        {
            get;
            set;
        }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData
        {
            get;
            set;
        }
    }
}
