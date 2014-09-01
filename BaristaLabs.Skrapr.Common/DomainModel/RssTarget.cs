namespace BaristaLabs.Skrapr.Common.DomainModel
{
    /// <summary>
    /// Represents an RSS Feed Target
    /// </summary>
    public class RssTarget : TargetBase
    {
        public override string Type
        {
            get { return "rss"; }
        }

        //TODO: Properties from fields,
    }
}
