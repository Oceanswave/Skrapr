namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a collection of authentication objects
    /// </summary>
    public class AuthenticationCollection : KeyedCollection<string, Authentication>
    {
        protected override string GetKeyForItem(Authentication item)
        {
            return item.Name;
        }
    }
}
