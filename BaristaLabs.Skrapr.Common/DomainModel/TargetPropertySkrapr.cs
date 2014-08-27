namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TargetPropertySkrapr
    {
        [JsonProperty("script")]
        public string Script
        {
            get;
            set;
        }
    }
}
