﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaristaLabs.Skrapr.Common.Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BaristaLabs.Skrapr.Common.Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;name&quot;: &quot;Get the Weather&quot;,
        ///  &quot;description&quot;: &quot;Crawls the weather data.&quot;,
        ///  &quot;pattern&quot;: {
        ///    &quot;url&quot;: &quot;http://www.weather.com/weather/today/\\d{5}&quot;,
        ///    &quot;mimeType&quot;: &quot;text/html&quot;
        ///  },
        ///  &quot;type&quot;: &quot;Weather&quot;,
        ///  &quot;requireJQuery&quot;: true,
        ///  &quot;properties&quot;: {
        ///    &quot;rightNow&quot;: {
        ///      &quot;type&quot;: &quot;cssText&quot;,
        ///      &quot;selector&quot;: &quot;ul.nav-list li a&quot;,
        ///      &quot;isArray&quot;: true
        ///    },
        ///    &quot;earlierToday&quot;: {
        ///      &quot;type&quot;: &quot;script&quot;,
        ///      &quot;script&quot;: &quot;jQuery(&apos;ul.nav-list li a&apos;).text();&quot;,
        ///      &quot;transform&quot;: &quot;function(result) { [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ExampleTarget01 {
            get {
                return ResourceManager.GetString("ExampleTarget01", resourceCulture);
            }
        }
    }
}
