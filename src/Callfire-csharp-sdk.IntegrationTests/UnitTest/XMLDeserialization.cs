using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest.Data;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.UnitTest
{
    [TestFixture]
    public class XmlDeserialization
    {
        public const string Path = "C:\\Users\\marcelob-ot\\Documents\\GitHub\\CallFire-CSharp-SDK\\src\\ResourceListResponse.xml";

        [Test]
        public void Test_BroadcastTypeMapper()
        {
            var broadcast = DeserializeList(Path);
            Assert.IsNotNull(broadcast);
        }

        public ResourceList DeserializeList(string filePath)
        {
            var broadcast = new ResourceList();

            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(ResourceList));
                TextReader reader = new StreamReader(Path);

                broadcast = (ResourceList)serializer.Deserialize(reader);
                reader.Close();
            }

            return broadcast;
        }
    }
}
