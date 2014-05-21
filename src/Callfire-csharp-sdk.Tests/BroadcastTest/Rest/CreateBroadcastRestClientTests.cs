using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class CreateBroadcastRestClientTests : CreateBroadcastClientTest
    {
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestBroadcastClient(XmlServiceClientMock);
            ExpectedBroadcast = new CfBroadcast(1, "broadcast", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, null);
            
            XmlServiceClientMock
                .Stub(j => j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Post),
                    Arg<string>.Is.Equal("/broadcast"),
                    Arg<Broadcast>.Matches(x => x.id == ExpectedBroadcast.Id &&
                                                x.Name == ExpectedBroadcast.Name &&
                                                x.LastModified == ExpectedBroadcast.LastModified &&
                                                x.Status == BroadcastStatus.RUNNING &&
                                                x.Type == BroadcastType.TEXT)))
                .Return(ExpectedBroadcast.Id);
        }
    }
}
