namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using Newtonsoft.Json;
    using System.ComponentModel;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents the base property pluckr class.
    /// </summary>
    /// <remarks>
    /// A property pluckr performs the action of plucking a property value from a page. Kinds of pluckrs include title, url, css, script and more.
    /// </remarks>
    public abstract class PropertyPluckrBase : IPropertyPluckr
    {
        [JsonProperty("type", Required = Required.Always)]
        public abstract string Type
        {
            get;
        }

        /// <summary>
        /// Gets or sets a description of the property.
        /// </summary>
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a JavaScript based script that will transform the retrieved value (Optional - If not specified, the plucker value will be used)
        /// </summary>
        [JsonProperty("transform", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Transform
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the target property type (after the transform)
        /// </summary>
        [JsonProperty("valueType", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(PropertyValueType.String)]
        public PropertyValueType ValueType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates if the result (after the transform) is an array of the result type.
        /// </summary>
        [JsonProperty("isArray", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool IsArray
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that always returns the same value.
    /// </summary>
    public class ConstPropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "const"; }
        }

        [JsonProperty("value", Required = Required.Always)]
        public string Value
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that returns the current UTC DateTime as the result.
    /// </summary>
    public class NowUtcPropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "nowUtc"; }
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that returns the page title as the result.
    /// </summary>
    public class TitlePropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "title"; }
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that returns the current (full) url as the result.
    /// </summary>
    public class UrlPropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "url"; }
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that returns the last path segment of the current url as the result.
    /// </summary>
    /// <remarks>
    /// For http://www.google.com/something/someother/dude.jpg?size=big#stuff=nasty will return dude.jpg
    /// Usually used to get the filename of a resource without resorting to using a transform script.
    /// </remarks>
    public class LastPathSegmentPropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "lastPathSegment"; }
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that returns a query string value as the result.
    /// </summary>
    public class QueryStringValuePropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "queryString"; }
        }

        [JsonProperty("key", Required = Required.Always)]
        public string Key
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that returns a value from the response header as the result.
    /// </summary>
    public class HeaderPropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "header"; }
        }

        [JsonProperty("header", Required = Required.Always)]
        public string Header
        {
            get;
            set;
        }
    }

        /// <summary>
    /// Represents a Property Pluckr that returns a cookie value as the result.
    /// </summary>
    public class CookiePropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "cookie"; }
        }

        [JsonProperty("domain", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Domain
        {
            get;
            set;
        }

        [JsonProperty("name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that uses a css selector to retrieve the desired property value from a page.
    /// </summary>
    public abstract class CssPropertyPluckr : PropertyPluckrBase
    {
        [JsonProperty("selector", Required = Required.Always)]
        public string Selector
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a css pluckr that returns the html of the selected element(s) as the return value.
    /// </summary>
    public class CssHtmlPropertyPluckr : CssPropertyPluckr
    {

        public override string Type
        {
            get { return "cssHtml"; }
        }
    }

    /// <summary>
    /// Reprents a css pluckr that returns the text value of the selected element(s) as the return value.
    /// </summary>
    public class CssTextPropertyPluckr : CssPropertyPluckr
    {
   
        public override string Type
        {
	        get { return "cssText"; }
        }
    }

    /// <summary>
    /// Reprents a css pluckr that returns the attribute value of a specified attribute on the selected element(s) as the return value.
    /// </summary>
    public class CssAttributePropertyPluckr : CssPropertyPluckr
    {

        public override string Type
        {
            get { return "cssAttr"; }
        }

        [JsonProperty("attr", Required = Required.Always)]
        public string Attr
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a Property Pluckr that uses JavaScript to retrieve the desired property value from a page.
    /// </summary>
    public class ScriptPropertyPluckr : PropertyPluckrBase
    {
        public override string Type
        {
            get { return "script"; }
        }

        /// <summary>
        /// The script that is invoked in the context of the page.
        /// </summary>
        /// <remarks>
        /// This value should always be a javascript function (function() { ... }) that returns a value.
        /// 
        /// Since this script is invoked in the context of the page, it is possible to retrieve page globals.
        /// 
        /// If jQuery is required, ensure that the RequireJQuery property of the target is set to true.
        /// Other scripts can be injected via the "AdditionalDependencies" collection on the Target.
        /// </remarks>
        [JsonProperty("script", Required = Required.Always)]
        public string Script
        {
            get;
            set;
        }
    }
}
