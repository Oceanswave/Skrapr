namespace BaristaLabs.Skrapr.Common.Tests
{
    using System;
    using System.Collections.Generic;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using BaristaLabs.Skrapr.Common.Tests.Properties;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class SerializationTests
    {
        private static readonly Target ExampleTarget01 = new Target
            {
                Name = "Front Page Weather",
                Description = "Gets the weather information from the front page.",
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
                        "source",
                        new ConstPropertyPluckr
                        {
                            Value = "Weather.com",
                        }
                    },
                     {
                        "zipCode",
                        new LastPathSegmentPropertyPluckr
                        {
                            ValueType = PropertyValueType.PrimaryKey,
                        }
                    },
                    {
                        "url",
                        new UrlPropertyPluckr()
                    },
                    {
                        "retrievedAt",
                        new NowUtcPropertyPluckr()
                    },
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

        private static readonly WebSkrapr ExampleSkrapr01 = new WebSkrapr
        {
            Name = "Weather.com",
            Description = "Gets weather information from weather.com",
            StartUrls = new List<string>
            {
                "http://www.weather.com/"
            },
            IncludeFilter = new List<string>
            {
                "http://www.weather.com/.*"   
            },
            UserAgent = "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko",
            IgnoreRobots = true,
            Targets = new List<Target>
            {
                ExampleTarget01
            },
            Authenticators = new List<IAuthenticator>
            {
                new NtlmAuthenticator
                {
                    Username = "testuser",
                    Password = "password"
                }, new FormAuthenticator
                {
                    Username = "testuser",
                    Password = "password",
                    RequireJQuery = true,
                    IsAuthenticatedScript = @"function(username) {
    var currentUserName = jQuery('.username').text();
    return currentUserName == username;
}",
                    AuthenticationScript = @"function(username, password) {
    var form = jQuery('.loginForm');
    jQuery(form).find('.username').val(username);
    jQuery(form).find('.password').val(password);
    form.submit();
}"
                }
            },
            Schedule = new List<ISchedule>
            {
                new CronSchedule
                {
                    CronExpression = "0 0 * * * ?"
                }
            }
        };

        private static readonly Project ExampleProject01 = new Project
        {
            Name = "Weather Comparison",
            Description = "Skrapes numerous weather sources to compare the results.",
            Skraprs = new List<ISkrapr>
            {
                ExampleSkrapr01
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

            result.ShouldBeEquivalentTo(ExampleTarget01);
        }

        [TestMethod]
        public void Ensure_That_ExampleSkrapr01_Serializes()
        {
            var result = JsonConvert.SerializeObject(ExampleSkrapr01, Formatting.Indented);

            //Start checking!
            var expected = Resources.ExampleSkrapr01;
            Assert.IsTrue(String.Compare(result, expected, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        [TestMethod]
        public void Ensure_That_ExampleSkrapr01_Deserializes()
        {
            //Start checking!
            var json = Resources.ExampleSkrapr01;
            var result = JsonConvert.DeserializeObject<WebSkrapr>(json);

            result.ShouldBeEquivalentTo(ExampleSkrapr01);
        }

        [TestMethod]
        public void Ensure_That_ExampleProject01_Serializes()
        {
            var result = JsonConvert.SerializeObject(ExampleProject01, Formatting.Indented);

            //Start checking!
            var expected = Resources.ExampleProject01;
            Assert.IsTrue(String.Compare(result, expected, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        [TestMethod]
        public void Ensure_That_ExampleProject01_Deserializes()
        {
            //Start checking!
            var json = Resources.ExampleProject01;
            var result = JsonConvert.DeserializeObject<Project>(json);

            result.ShouldBeEquivalentTo(ExampleProject01);
        }
    }
}
