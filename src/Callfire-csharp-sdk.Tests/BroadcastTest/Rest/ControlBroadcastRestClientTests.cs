using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class ControlBroadcastRestClientTests : ControlBroadcastClientTest
    {
        internal HttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<HttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            ExpectedControlBroadcast = new CfControlBroadcast(1, "123", CfBroadcastCommand.Start, 5);
            
            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal("/broadcast"),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Put),
                    Arg<ControlBroadcast>.Matches(x => x.Id == ExpectedControlBroadcast.Id &&
                                                       x.RequestId == ExpectedControlBroadcast.RequestId &&
                                                       x.Command == BroadcastCommand.START &&
                                                       x.MaxActive == ExpectedControlBroadcast.MaxActive)));
        }
    }
}
