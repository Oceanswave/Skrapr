namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.ComponentModel;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents a Skrapr project, a collection of Skraprs which execute on a schedule.
    /// </summary>
    /// <remarks>
    /// An example of a Skrapr project is a weather aggregator.
    /// 
    /// A weather aggregator project may have multiple skraprs that crawl different sites.
    /// One skraper may target weather.com, gathering information from a few of the web pages.
    /// Another skraper in the same project may target weather underground, using the rss feed and the home page as targets.
    /// </remarks>
    public class Project
    {
        /// <summary>
        /// Gets or sets the id of the project.
        /// </summary>
        [JsonProperty("_id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id of the user that the project is associated with.
        /// </summary>
        [JsonProperty("userId")]
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates the status of the project.
        /// </summary>
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(false)]
        public ProjectStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates when the project was created.
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTime? CreatedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates when the project was last updated.
        /// </summary>
        [JsonProperty("lastUpdated")]
        public DateTime? LastUpdated
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
