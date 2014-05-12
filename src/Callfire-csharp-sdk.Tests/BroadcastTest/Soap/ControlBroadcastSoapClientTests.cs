using CallFire_csharp_sdk.API.Soap;
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
            Id = 1;
            RequestId = "123";
            MaxActive = 5;

            BroadcastServiceMock
                .Stub(b => b.ControlBroadcast(Arg<ControlBroadcast>.Matches(x => x.Id == Id &&
                                                                                 x.RequestId == RequestId &&
                                                                                 x.MaxActive == MaxActive &&
                                                                                 x.Command == BroadcastCommand.START)));

        }
    }
}
