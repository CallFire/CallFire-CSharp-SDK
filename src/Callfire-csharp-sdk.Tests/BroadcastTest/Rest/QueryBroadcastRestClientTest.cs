using System;
using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class QueryBroadcastRestClientTest : QueryBroadcastClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            var queryBroadcast = new Broadcast[1];
            BroadcastId = 1;
            BroadcastName = "broadcast";
            BroadcastLastModified = DateTime.Now;
            queryBroadcast[0] = new Broadcast(BroadcastId, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.IVR, null);

            CfBroadcastType[] broadcastType = { CfBroadcastType.Ivr};
            ExpectedQueryBroadcast = new CfQueryBroadcasts(5, 0, broadcastType, true, "labelName");

            var cfBroadcastQueryResult = new BroadcastQueryResult(1, queryBroadcast);

            var resource = new ResourceList();
            var array = new Broadcast[1];
            array[0] = cfBroadcastQueryResult.Broadcast[0];
            resource.Resource = array;
            resource.TotalResults = 1;

            var serializer = new XmlSerializer(typeof(ResourceList));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resource);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast?MaxResults={0}&FirstResult={1}&Type={2}&Running={3}&LabelName={4}", 
                    ExpectedQueryBroadcast.MaxResults, ExpectedQueryBroadcast.FirstResult, BroadcastType.IVR.ToString(), ExpectedQueryBroadcast.Running.ToString().ToLower(), ExpectedQueryBroadcast.LabelName)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<string>.Is.Anything))
                .Return(writer.ToString());
        }
    }
}
