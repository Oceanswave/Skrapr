namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a collection of targets.
    /// </summary>
    public class TargetCollection : KeyedCollection<string, Target>
    {
        protected override string GetKeyForItem(Target item)
        {
            return item.Name;
        }
    }
}
