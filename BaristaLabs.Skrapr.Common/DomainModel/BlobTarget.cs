namespace BaristaLabs.Skrapr.Common.DomainModel
{
    /// <summary>
    /// Indicates a blob target.
    /// </summary>
    /// <remarks>
    /// If the pattern matches, the result will be stored as a blob. Metadata can be optionally associated with the blob.
    /// </remarks>
    public class BlobTarget : TargetBase
    {
        public override string Type
        {
            get { return "blob"; }
        }
    }
}
