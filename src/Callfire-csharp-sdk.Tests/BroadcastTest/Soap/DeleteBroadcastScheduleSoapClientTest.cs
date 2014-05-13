using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class DeleteBroadcastScheduleSoapClientTest : DeleteBroadcastScheduleClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            BroadcastScheduleId = 1;

            BroadcastServiceMock.Stub(b => b.DeleteBroadcastSchedule(Arg<IdRequest>.Matches(x => x.Id == BroadcastScheduleId)));
        }
    }
}
