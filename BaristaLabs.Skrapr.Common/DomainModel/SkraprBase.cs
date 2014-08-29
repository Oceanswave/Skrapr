namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

    public abstract class SkraprBase : ISkrapr
    {
        /// <summary>
        /// Gets the type of skrapr. Possible values include web, mail, fileSystem, nntp, ...
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public abstract string Type
        {
            get;
        }
    }
}
