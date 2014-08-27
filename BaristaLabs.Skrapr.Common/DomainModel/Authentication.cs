namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

    public class Authentication
    {
        /// <summary>
        /// Gets or sets the name of the authentcation.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        //Trigger? Url based, or script...

        //TODO: Is this a base abstract class or has a type parameter.. probably abstract.
    }
}
