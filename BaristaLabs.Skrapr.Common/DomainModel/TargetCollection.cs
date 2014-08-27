namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a collection of targets.
    /// </summary>
    [JsonDictionary]
    public class TargetCollection : KeyedCollection<string, Target>
    {
        protected override string GetKeyForItem(Target item)
        {
            return item.Name;
        }
    }
}
