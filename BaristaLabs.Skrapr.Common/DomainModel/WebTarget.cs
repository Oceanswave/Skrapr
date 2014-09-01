namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using BaristaLabs.Skrapr.Common.Converters;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Represents a WebScrapr target.
    /// </summary>
    /// <remarks>
    /// Once a page has been visited by the Scrapr, all targets will be evaluated to see if they match.
    /// If a pattern matches, then the contents of that page will be skraped and the result stored.
    /// </remarks>
    public class WebTarget : TargetBase
    {
        public override string Type
        {
            get { return "web"; }
        }

        /// <summary>
        /// Gets or sets result Type Name.
        /// </summary>
        /// <remarks>
        /// The value here indicates the type name that is stored in the type field of the persisted skrapr result.
        /// </remarks>
        [JsonProperty("resultType", Required = Required.Always)]
        public string ResultType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if jQuery should be injected on the page, if it doesn't already exist. (Optional - Default is that jQuery is not required)
        /// </summary>
        [JsonProperty("requireJQuery", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool RequireJQuery
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates a number of additional dependencies that should be injected into the page. (Optional - Default is no scripts will be injected)
        /// </summary>
        /// <remarks>
        /// Absolute urls to publically available resources are required.
        /// </remarks>
        [JsonProperty("scriptDependencies", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public IList<string> AdditionalScriptDependencies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection of properties.
        /// </summary>
        [JsonProperty("properties", Required = Required.Always, ItemConverterType = typeof(PropertyPluckrConverter))]
        public IDictionary<string, IPropertyPluckr> Properties
        {
            get;
            set;
        }
    }
}
