using System;
using CallFire_csharp_sdk.API.Rest;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class UpdateBroadcastRestClientTest : UpdateBroadcastClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            BroadcastId = 1;

            JsonServiceClientMock
                .Stub(j => j.Send<string>(Arg<string>.Is.Equal(HttpMethods.Put),
                    Arg<string>.Is.Equal(String.Format("/broadcast/{0}", BroadcastId)),
                    Arg<object>.Is.Null));
        }
    }
}
