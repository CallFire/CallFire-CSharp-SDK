using System;
using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class QueryContactBatchRestClientTest : QueryContactBatchClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            ExpectedQueryBroadcastData = new CfQueryBroadcastData(500, 0, 1);

            ExpectedContactBatch = new CfContactBatch(1, "contactBatch", CfBatchStatus.Active, 2, DateTime.Now, 10, 15);

            var contactBatchArray = new CfContactBatch[1];
            contactBatchArray[0] = ExpectedContactBatch;

            ExpectedContactBatchQueryResult = new CfContactBatchQueryResult(10, contactBatchArray);

            var resource = new ResourceList();
            var array = new ContactBatch[1];
            array[0] = ContactBatchMapper.ToSoapContactBatch(ExpectedContactBatchQueryResult.ContactBatch[0]);
            resource.Resource = array;
            resource.TotalResults = 1;

            var serializer = new XmlSerializer(typeof(ResourceList));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resource);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}/batch?MaxResults={1}&FirstResult={2}",
                            ExpectedQueryBroadcastData.BroadcastId, ExpectedQueryBroadcastData.MaxResults,
                            ExpectedQueryBroadcastData.FirstResult)),
                            Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                            Arg<object>.Is.Null))
                .Return(writer.ToString());
        }
    }
}
