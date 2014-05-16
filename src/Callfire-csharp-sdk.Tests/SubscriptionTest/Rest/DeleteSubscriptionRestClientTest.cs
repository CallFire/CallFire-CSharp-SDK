using System;
using CallFire_csharp_sdk.API.Rest;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Rest
{
    [TestFixture]
    public class DeleteSubscriptionRestClientTest : DeleteSubscriptionClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestSubscriptionClient(JsonServiceClientMock);

            SubscriptionId = 1;

            JsonServiceClientMock
                .Stub(j => j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Delete),
                    Arg<string>.Is.Equal(String.Format("/subscription/{0}", SubscriptionId)),
                    Arg<object>.Is.Null));
        }
    }
}
