﻿namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Scrapr target.
    /// </summary>
    /// <remarks>
    /// Once a page has been visited by the Scrapr, all targets will be evaluated to see if they match.
    /// If a pattern matches, then the contents of that page will be skraped and the result stored.
    /// </remarks>
    public class Target
    {
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
        [JsonProperty("description")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a pattern that this target will apply.
        /// </summary>
        /// <remarks>
        /// For instance, if a pattern is http://.*.winamp.com then...
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
        /// Gets or sets a value that indicates if the target is disabled.
        /// </summary>
        [JsonProperty("disabled")]
        public bool? Disabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets result Type Name.
        /// </summary>
        /// <remarks>
        /// The value here indicates the type name that is stored in the type field of the persisted skrapr result.
        /// </remarks>
        [JsonProperty("type", Required = Required.Always)]
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if the target is a blob. (Optional - Default is false)
        /// </summary>
        /// <remarks>
        /// If this value is true, the response body will be stored as a blob
        /// </remarks>
        [JsonProperty("isBlob")]
        public bool IsBlob
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if jQuery should be injected on the page, if it doesn't already exist. (Optional - Default is that jQuery is not required)
        /// </summary>
        [JsonProperty("requireJQuery")]
        public bool RequireJQuery
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates a number of additional dependencies that should be injected into the page. (Optional - Default is no scripts will be injected)
        /// </summary>
        [JsonProperty("scriptDependencies")]
        public IList<string> AdditionalScriptDependencies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection of properties.
        /// </summary>
        [JsonProperty("properties", Required = Required.Always)]
        public TargetPropertyCollection Properties
        {
            get;
            set;
        }
    }
}