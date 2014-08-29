namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Interface for a Property Pluckr
    /// </summary>
    public interface IPropertyPluckr
    {
        [JsonProperty("type", Required = Required.Always)]
        string Type
        {
            get;
        }

        /// <summary>
        /// Gets or sets a JavaScript based script that will transform the retrieved value (Optional - If not specified, the plucker value will be used)
        /// </summary>
        [JsonProperty("transform", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        string Transform
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the target property type (after the transform)
        /// </summary>
        [JsonProperty("resultType", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(PropertyValueType.String)]
        PropertyValueType ValueType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if the result (after the transform) is an array of the result type.
        /// </summary>
        [JsonProperty("isArray", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        bool IsArray
        {
            get;
            set;
        }
    }
}
