using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class CreateBroadcastRestClientTests : CreateBroadcastClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);
            BroadcastId = 1;
            BroadcastName = "broadcast1";
            BroadcastLastModified = DateTime.Now;

            JsonServiceClientMock
                .Stub(j => j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Post),
                    Arg<string>.Is.Equal("/broadcast"),
                    Arg<Broadcast>.Matches(x => x.id == BroadcastId &&
                                                x.Name == BroadcastName &&
                                                x.LastModified == BroadcastLastModified &&
                                                x.Status == BroadcastStatus.RUNNING &&
                                                x.Type == BroadcastType.TEXT)))
                .Return(BroadcastId);
        }
    }
}
