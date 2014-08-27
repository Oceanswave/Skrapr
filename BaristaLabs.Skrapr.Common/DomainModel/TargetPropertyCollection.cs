namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;

    [JsonDictionary]
    public class TargetPropertyCollection : KeyedCollection<string, TargetProperty>
    {
        protected override string GetKeyForItem(TargetProperty item)
        {
            return item.Name;
        }
    }
}
