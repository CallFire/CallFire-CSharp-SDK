using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    class QueryBroadcastSoapClientTest : QueryBroadcastClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            var queryBroadcast = new Broadcast[1];
            BroadcastId = 1;
            BroadcastName = "broadcast";
            BroadcastLastModified = DateTime.Now;
            queryBroadcast[0] = new Broadcast(BroadcastId, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.IVR, null);

            ExpectedQueryBroadcast = new CfQueryBroadcasts(5, 0, CfBroadcastType.Ivr, true, false, "labelName");

            var cfBroadcastQueryResult = new BroadcastQueryResult(1, queryBroadcast);

            BroadcastServiceMock
                .Stub(b => b.QueryBroadcasts(Arg<QueryBroadcasts>.Matches(x => x.MaxResults == ExpectedQueryBroadcast.MaxResults &&
                                                                               x.FirstResult == ExpectedQueryBroadcast.FirstResult &&
                                                                               x.Type == BroadcastType.IVR.ToString() &&
                                                                               x.LabelName == ExpectedQueryBroadcast.LabelName)))
                .Return(cfBroadcastQueryResult);
        }
    }
}
