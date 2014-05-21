using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.Common;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Rest
{
    [TestFixture]
    public class DeleteSubscriptionRestClientTest : DeleteSubscriptionClientTest
    {
        internal HttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<HttpClient>();
            Client = new RestSubscriptionClient(HttpClientMock);

            SubscriptionId = 1;
            
            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/subscription/{0}", SubscriptionId)), Arg<HttpMethod>.Is.Equal(HttpMethod.Delete),
                    Arg<string>.Is.Anything))
                .Return(string.Empty);
        }
    }
}
