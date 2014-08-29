namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

    public interface ISkrapr
    {
        /// <summary>
        /// Gets the type of skrapr. Possible values include web, mail, fileSystem, nntp, ...
        /// </summary>
        [JsonProperty("type")]
        string Type
        {
            get;
        }
    }
}