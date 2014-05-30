using System;
using System.Linq;
using System.Web;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests
{
    [TestFixture]
    public class CustomSerializerTests
    {
        private CustomSerializer _serializer;
        private Broadcast _broadcast;

        [SetUp]
        public void Setup()
        {
            _serializer = new CustomSerializer();
            _broadcast = new Broadcast(1, "Broadcast Name", BroadcastStatus.ARCHIVED,
                new DateTime(2014, 1, 1, 3, 0, 0), BroadcastType.TEXT,
                new TextBroadcastConfig(2, new DateTime(2014, 1, 1, 3, 0, 0),
                    "111", null, new BroadcastConfigRetryConfig(1, 1, "1", "1"), "message", new BigMessageStrategy()));
        }

        [Test]
        public void Serializer_should_serialize_int()
        {
            Assert.IsTrue(_serializer.GetProperties(_broadcast).Any(p => p.Key == "id" && p.Value == "1"));
        }

        [Test]
        public void Serializer_should_serialize_string()
        {
            Assert.IsTrue(_serializer.GetProperties(_broadcast).Any(p => p.Key == "Name" && p.Value == HttpUtility.UrlEncode("Broadcast Name")));
        }

        [Test]
        public void Serializer_should_serialize_date()
        {
            Assert.IsTrue(_serializer.GetProperties(_broadcast).Any(p => p.Key == "LastModified" && p.Value == HttpUtility.UrlEncode("2014-01-01T03:00:00")));
        }

        [Test]
        public void Serializer_should_serialize_inner_object_property()
        {
            Assert.IsTrue(_serializer.GetProperties(_broadcast).Any(p => p.Key == "Message" && p.Value == "message"));
        }

        [Test]
        public void Serializer_should_serialize_array()
        {
            var test = new TestObject(new []{"val1","val2"});
            Assert.IsTrue(_serializer.GetProperties(test).Any(p => p.Key == "Values" && p.Value == HttpUtility.UrlEncode("val1 val2")));
        }

        private class TestObject
        {
            private string[] Values { get; set; }

            public TestObject(string[] values)
            {
                Values = values;
            }
        }
    }
}
