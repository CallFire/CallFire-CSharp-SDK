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

            MaxResult = 5;
            FirstResult = 0;

            var cfBroadcastQueryResult = new BroadcastQueryResult(1, new Broadcast[1]);

            BroadcastServiceMock
                .Stub(b => b.QueryBroadcasts(Arg<QueryBroadcasts>.Matches(x => x.MaxResults == MaxResult &&
                                                                               x.FirstResult == FirstResult)))
                .Return(cfBroadcastQueryResult);
        }
    }
}
