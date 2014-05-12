using System;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class CreateBroadcastSoapClientTest : CreateBroadcastClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);
            BroadcastId = 1;
            BroadcastName = "broadcast1";
            BroadcastLastModified = DateTime.Now;

            BroadcastServiceMock
                .Stub(b => b.CreateBroadcast(Arg<BroadcastRequest>.Matches(x => x.Broadcast.id == BroadcastId && 
                                                                                x.Broadcast.Name == BroadcastName &&
                                                                                x.Broadcast.LastModified == BroadcastLastModified &&
                                                                                x.Broadcast.Status == BroadcastStatus.RUNNING &&
                                                                                x.Broadcast.Type == BroadcastType.TEXT)))
                .Return(BroadcastId);
        }
    }
}
