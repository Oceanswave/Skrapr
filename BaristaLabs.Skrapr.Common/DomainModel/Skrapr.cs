namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.Generic;
    using System.Security.Authentication;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Skrapr -- a collection of rules that scrape a site.
    /// </summary>
    public class Skrapr
    {
        public Skrapr()
        {
            this.TypePropertyName = "_type";
        }

        /// <summary>
        /// Gets or sets the user agent to use when skraping. Defaults to ...
        /// </summary>
        [JsonProperty("userAgent")]
        public string UserAgent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the skrapr is incremental (???)
        /// </summary>
        [JsonProperty("incremental")]
        public bool Incremental
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the property name of the field that indicates the type. Defaults to '_type'
        /// </summary>
        [JsonProperty("typePropertyName")]
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
        [JsonProperty("includeFilter")]
        public IList<string> IncludeFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of black-listed urls for crawling.
        /// </summary>
        [JsonProperty("excludeFilter")]
        public IList<string> ExcludeFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates the maximum number of results to retrieve.
        /// </summary>
        /// <remarks>Once this value is reached, the skrapr will stop.</remarks>
        [JsonProperty("maxResults")]
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
        [JsonProperty("IgnoreRobots")]
        public bool IgnoreRobots
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of authentications which will be used
        /// </summary>
        [JsonProperty("authentications")]
        public IList<AuthenticationException> Authentications
        {
            get;
            set;
        }

        [JsonProperty("targets")]
        public TargetCollection Targets
        {
            get;
            set;
        }

        [JsonProperty("schedule")]
        public IList<Schedule> Schedule
        {
            get;
            set;
        }
    }
}
