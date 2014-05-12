using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    class ControlBroadcastSoapClientTests : ControlBroadcastClientTests
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);
            ExpectedControlBroadcast = new CfControlBroadcast(1, "123", CfBroadcastCommand.Start, 5);

            BroadcastServiceMock
                .Stub(b => b.ControlBroadcast(Arg<ControlBroadcast>.Matches(x => x.Id == ExpectedControlBroadcast.Id &&
                                                                                 x.RequestId == ExpectedControlBroadcast.RequestId &&
                                                                                 x.MaxActive == ExpectedControlBroadcast.MaxActive &&
                                                                                 x.Command == BroadcastCommand.START)));

        }
    }
}
