using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class ControlBroadcastRestClientTests : ControlBroadcastClientTests
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);
            Id = 1;
            RequestId = "123";
            MaxActive = 5;

            JsonServiceClientMock
                .Stub(j => j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Put),
                    Arg<string>.Is.Equal("/broadcast"),
                    Arg<ControlBroadcast>.Matches(x => x.Id == Id &&
                                                       x.RequestId == RequestId &&
                                                       x.Command == BroadcastCommand.START &&
                                                       x.MaxActive == MaxActive)));
        }
    }
}
