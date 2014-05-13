using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class ControlContactBatchSoapClientTest : ControlContactBatchClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            ControlContactBatchId = 1;
            ExpectedControlContactBatch = new CfControlContactBatch(ControlContactBatchId, "controlContactBatch", false);

            BroadcastServiceMock
                .Stub(b => b.ControlContactBatch(Arg<ControlContactBatch>.Matches(x => x.Id == ExpectedControlContactBatch.Id &&
                                                                                       x.Name == ExpectedControlContactBatch.Name &&
                                                                                       x.Enabled == ExpectedControlContactBatch.Enabled)));
        }
    }
}
