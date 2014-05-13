using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class CreateContactBatchSoapClientTest : CreateContactBatchClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            BroadcastId = 2;
            ExpectedCreateContactBatch = new CfCreateContactBatch("1", BroadcastId, "name", null, false);

            BroadcastServiceMock
                .Stub(b => b.CreateContactBatch(Arg<CreateContactBatch>.Matches(x => x.RequestId == ExpectedCreateContactBatch.RequestId &&
                                                                                x.BroadcastId == ExpectedCreateContactBatch.BroadcastId &&
                                                                                x.Name == ExpectedCreateContactBatch.Name &&
                                                                                x.ScrubBroadcastDuplicates == ExpectedCreateContactBatch.ScrubBroadcastDuplicates)))
                .Return(BroadcastId);
        }
    }
}
