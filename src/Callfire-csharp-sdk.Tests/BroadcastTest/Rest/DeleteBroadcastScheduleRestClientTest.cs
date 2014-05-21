using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.Common;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class DeleteBroadcastScheduleRestClientTest : DeleteBroadcastScheduleClientTest
    {
        internal HttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<HttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            BroadcastScheduleId = 1;

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/schedule/{0}", BroadcastScheduleId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Delete),
                    Arg<string>.Is.Anything))
                .Return(string.Empty);
        }
    }
}
