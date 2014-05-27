using System;
using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class GetContactBatchRestClientTest : GetContactBatchClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            ContactBatchId = 1;
            ExpectedContactBatch = new CfContactBatch(ContactBatchId, "contactBatch", CfBatchStatus.Active, 5, DateTime.Now, 200, 10);

            var contactBatch = ContactBatchMapper.ToSoapContactBatch(ExpectedContactBatch);

            var resource = new Resource { Resources = contactBatch };
            var serializer = new XmlSerializer(typeof(Resource));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resource);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/batch/{0}", ContactBatchId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<object>.Is.Null))
                .Return(writer.ToString());
        }
    }
}
