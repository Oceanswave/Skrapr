namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;

    public enum PropertyValueType
    {
        /// <summary>
        /// Indicates that the property value is a string.
        /// </summary>
        [JsonProperty("string")]
        String,

        /// <summary>
        /// Indicates that the property value is an integer.
        /// </summary>
        [JsonProperty("integer")]
        Integer,

        /// <summary>
        /// Indicates that the property value is a floating-point number.
        /// </summary>
        [JsonProperty("float")]
        Float,

        /// <summary>
        /// Indicates that the property value is a base64 encoded byte array.
        /// </summary>
        [JsonProperty("base64")]
        Base64,

        /// <summary>
        /// Indicates that the property value is a child url that will be added to the skrapr queue.
        /// </summary>
        [JsonProperty("childUrl")]
        ChildUrl,

        /// <summary>
        /// Indicates that the property value is a primary key. If more than one primary keys exist in the result, the last will be used.
        /// </summary>
        [JsonProperty("primaryKey")]
        PrimaryKey,

        /// <summary>
        /// Indicates that the property value is a secondary key. Multiple secondary keys can exist.
        /// </summary>
        [JsonProperty("secondaryKey")]
        SecondaryKey,

        /// <summary>
        /// Indicates that the property value is a revision id. If more than one revision Id properties exist, the last will be used.
        /// </summary>
        [JsonProperty("revisionId")]
        RevisionId,

        /// <summary>
        /// Indicates that the property value should be used as the type property. If more than one type properties exist, the last will be used.
        /// </summary>
        [JsonProperty("type")]
        Type
    }
}
