using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.Rest
{
    [TestFixture]
    public class CallfireRestRouteTests
    {
        [Test, TestCaseSource("TestCases")]
        public void CallfireRestRoute_tostring_tests(CallfireRestRoute<Broadcast> route, string expected)
        {
            Assert.IsTrue(
                string.Equals(expected, route.ToString(), StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(new CallfireRestRoute<Broadcast>(null), "/broadcast")
                    .SetName("Should create default route");
                yield return new TestCaseData(new CallfireRestRoute<Broadcast>(1), "/broadcast/1")
                    .SetName("Should create route with id");
                yield return new TestCaseData(new CallfireRestRoute<Broadcast>(1, null, "test", null), "/broadcast/1/test")
                    .SetName("Should create route with id and action");
                yield return new TestCaseData(new CallfireRestRoute<Broadcast>(1, "test", null, null), "/broadcast/test/1")
                    .SetName("Should create route with object and id");
                yield return new TestCaseData(new CallfireRestRoute<Broadcast>(1, "testobject", "testaction", null),
                "/broadcast/testobject/1/testaction")
                    .SetName("Should create route with object, id and action");
                yield return new TestCaseData(new CallfireRestRoute<Broadcast>(1, null, null, new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } })
                , "/broadcast/1?key1=value1&key2=value2")
                    .SetName("Should create route with parameters");
            }
        }
    }
}
