namespace BaristaLabs.Skrapr.Common.DomainModel
{
    public enum PropertyValueType
    {
        /// <summary>
        /// Indicates that the property value is a string.
        /// </summary>
        String,

        /// <summary>
        /// Indicates that the property value is an integer.
        /// </summary>
        Integer,

        /// <summary>
        /// Indicates that the property value is a floating-point number.
        /// </summary>
        Float,


        /// <summary>
        /// Indicates that the property value is a date.
        /// </summary>
        Date,

        /// <summary>
        /// Indicates that the property value is a base64 encoded byte array.
        /// </summary>
        Base64,

        /// <summary>
        /// Indicates that the property value is a child url that will be added to the skrapr queue.
        /// </summary>
        ChildUrl,

        /// <summary>
        /// Indicates that the property value is a primary key. If more than one primary keys exist in the result, the last will be used.
        /// </summary>
        PrimaryKey,

        /// <summary>
        /// Indicates that the property value is a secondary key. Multiple secondary keys can exist.
        /// </summary>
        SecondaryKey,

        /// <summary>
        /// Indicates that the property value is a revision id. If more than one revision Id properties exist, the last will be used.
        /// </summary>
        RevisionId,

        /// <summary>
        /// Indicates that the property value should be used as the type property. If more than one type properties exist, the last will be used.
        /// </summary>
        Type
    }
}
