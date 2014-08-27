namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

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
        /// Gets or sets a value that indicates if the project is disabled
        /// </summary>
        /// <remarks>
        /// If the project is disabled, none of the associated Skraprs will execute.
        /// </remarks>
        [JsonProperty("disabled")]
        public bool Disabled
        {
            get;
            set;
        }
    }
}
