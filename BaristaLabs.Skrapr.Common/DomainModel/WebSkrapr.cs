namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using BaristaLabs.Skrapr.Common.Converters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Web Skrapr -- a collection of rules that scrape web pages.
    /// </summary>
    public class WebSkrapr : SkraprBase
    {
        public WebSkrapr()
        {
            TypePropertyName = "_type";
        }

        public override string Type
        {
            get { return "web"; }
        }

        /// <summary>
        /// Gets or sets the name of the skrapr.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description of the Skrapr.
        /// </summary>
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user agent to use when skraping. Defaults to Chrome > 37
        /// </summary>
        [JsonProperty("userAgent")]
        [DefaultValue("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.102 Safari/537.36")]
        public string UserAgent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the skrapr is incremental (???)
        /// </summary>
        [JsonProperty("incremental", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool Incremental
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the property name of the field that indicates the type. Defaults to '_type'
        /// </summary>
        [JsonProperty("typePropertyName", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue("_type")]
        public string TypePropertyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of urls that will be used as the start point for skraping.
        /// </summary>
        [JsonProperty("startUrls")]
        public IList<string> StartUrls
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of white-listed urls for crawling.
        /// </summary>
        [JsonProperty("includeFilter", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public IList<string> IncludeFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of black-listed urls for crawling.
        /// </summary>
        [JsonProperty("excludeFilter", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public IList<string> ExcludeFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates the maximum number of results to retrieve.
        /// </summary>
        /// <remarks>Once this value is reached, the skrapr will stop.</remarks>
        [JsonProperty("maxResults", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public int? MaxResults
        {
            get;
            set;
        }

        //TODO: MaxDepth

        //TODO: OverWrite

        //TODO: Version

        /// <summary>
        /// Gets or sets a value that indicates if the site's robots.txt is ignored.
        /// </summary>
        [JsonProperty("ignoreRobots")]
        public bool IgnoreRobots
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of authenticators which will be used
        /// </summary>
        [JsonProperty("authenticators", ItemConverterType = typeof(AuthenticatorConverter), DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public IList<IAuthenticator> Authenticators
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of skrapr targets.
        /// </summary>
        /// <remarks>
        /// A target is a definition of ...
        /// </remarks>
        [JsonProperty("targets")]
        public IList<Target> Targets
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection of schedules. If no schedules are defined, the Skrapr will only execute manually.
        /// </summary>
        [JsonProperty("schedule", ItemConverterType = typeof(ScheduleConverter), DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public IList<ISchedule> Schedule
        {
            get;
            set;
        }
    }
}
