namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using BaristaLabs.Skrapr.Common.Converters;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Represents a Skrapr project, a collection of Skraprs which execute on a schedule.
    /// </summary>
    public class Project
    {
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
        /// Gets or sets a value that indicates if the project is disabled
        /// </summary>
        /// <remarks>
        /// If the project is disabled, none of the associated Skraprs will execute.
        /// </remarks>
        [JsonProperty("disabled", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool Disabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection of skraprs associated with the project.
        /// </summary>
        [JsonProperty("skraprs", ItemConverterType = typeof(SkraprConverter))]
        public IList<ISkrapr> Skraprs
        {
            get;
            set;
        }
    }
}
