using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
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

            ExpectedBroadcast = new CfBroadcast(1, "broadcast", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, null);

            BroadcastServiceMock
                .Stub(b => b.CreateBroadcast(Arg<BroadcastRequest>.Matches(x => x.Broadcast.id == ExpectedBroadcast.Id &&
                                                                                x.Broadcast.Name == ExpectedBroadcast.Name &&
                                                                                x.Broadcast.LastModified == ExpectedBroadcast.LastModified &&
                                                                                x.Broadcast.Status == BroadcastStatus.RUNNING &&
                                                                                x.Broadcast.Type == BroadcastType.TEXT)))
                .Return(ExpectedBroadcast.Id);
        }
    }
}
