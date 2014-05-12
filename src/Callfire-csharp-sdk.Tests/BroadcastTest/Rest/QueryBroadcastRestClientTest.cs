using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class QueryBroadcastRestClientTest : QueryBroadcastClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            var queryBroadcast = new Broadcast[1];
            BroadcastId = 1;
            BroadcastName = "broadcast";
            BroadcastLastModified = DateTime.Now;
            queryBroadcast[0] = new Broadcast(BroadcastId, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.IVR, null);

            ExpectedQueryBroadcast = new CfQueryBroadcasts(5, 0, CfBroadcastType.Ivr, true, false, "labelName");

            var cfBroadcastQueryResult = new BroadcastQueryResult(1, queryBroadcast);

            JsonServiceClientMock
                .Stub(j => j.Send<BroadcastQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast?MaxResults={0}&FirstResult={1}&Type={2}&LabelName={3}", ExpectedQueryBroadcast.MaxResults, ExpectedQueryBroadcast.FirstResult, BroadcastType.IVR.ToString(), ExpectedQueryBroadcast.LabelName)),
                    Arg<object>.Is.Null))
                .Return(cfBroadcastQueryResult);
        }
    }
}
