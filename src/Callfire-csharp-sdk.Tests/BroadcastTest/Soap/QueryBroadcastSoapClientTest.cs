using System;
using CallFire_csharp_sdk.API.Soap;
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

            MaxResult = 5;
            FirstResult = 0;
            LabelName = "labelName";

            var cfBroadcastQueryResult = new BroadcastQueryResult(1, queryBroadcast);

            BroadcastServiceMock
                .Stub(b => b.QueryBroadcasts(Arg<QueryBroadcasts>.Matches(x => x.MaxResults == MaxResult &&
                                                                               x.FirstResult == FirstResult &&
                                                                               x.Type == BroadcastType.IVR.ToString() &&
                                                                               x.LabelName == LabelName)))
                .Return(cfBroadcastQueryResult);
        }
    }
}
