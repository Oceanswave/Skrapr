namespace BaristaLabs.Skrapr.Common.Tests
{
    using System;
    using System.Collections.Generic;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using BaristaLabs.Skrapr.Common.Tests.Properties;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class SerializationTests
    {
        private static readonly Target ExampleTarget01 = new Target
            {
                Name = "Get the Weather",
                Description = "Crawls the weather data.",
                Type = "Weather",
                RequireJQuery = true,
                AdditionalScriptDependencies = null,
                Disabled = false,
                IsBlob = false,
                Pattern = new TargetPattern
                {
                    Url = @"http://www.weather.com/weather/today/\d{5}",
                    MimeType = "text/html"
                },
                Properties = new Dictionary<string, IPropertyPluckr>
                {
                    {
                        "rightNow",
                        new CssTextPropertyPluckr
                        {
                            Selector = "ul.nav-list li a",
                            ValueType = PropertyValueType.String,
                            IsArray = true
                        }
                    },
                    {
                        "earlierToday",
                        new ScriptPropertyPluckr
                        {
                            Script = "jQuery('ul.nav-list li a').text();",
                            Transform = @"function(result) {
    return result
}"
                        }
                    }
                }
            };

        [TestMethod]
        public void Ensure_That_ExampleTarget01_Serializes()
        {
            var result = JsonConvert.SerializeObject(ExampleTarget01, Formatting.Indented);

            //Start checking!
            var expected = Resources.ExampleTarget01;
            Assert.IsTrue(String.Compare(result, expected, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        [TestMethod]
        public void Ensure_That_ExampleTarget01_Deserializes()
        {
            //Start checking!
            var json = Resources.ExampleTarget01;
            var result = JsonConvert.DeserializeObject<Target>(json);

            
        }

        [TestMethod]
        public void Ensure_That_CronSchedule_Serializes()
        {
            var schedule = new CronSchedule("0 0 0 * * ?");
            var result = JsonConvert.SerializeObject(schedule);
            const string expected = "\"0 0 0 * * ?\"";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Ensure_That_CronSchedule_Deserializes()
        {
            const string schedule = "\"0 0 0 * * ?\"";
            var result = JsonConvert.DeserializeObject<CronSchedule>(schedule);

            Assert.AreEqual("0 0 0 * * ?", result.ToString());
        }
    }
}
