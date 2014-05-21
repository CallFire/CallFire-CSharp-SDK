using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests
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

        public ResourceList<Broadcast> DeserializeList(string filePath)
        {
            var broadcast = new ResourceList<Broadcast>();

            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(ResourceList<Broadcast>));
                TextReader reader = new StreamReader(Path);

                broadcast = (ResourceList<Broadcast>)serializer.Deserialize(reader);
                reader.Close();
            }

            return broadcast;
        }
    }
}
