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
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestSubscriptionClient(XmlServiceClientMock);

            SubscriptionId = 1;
            
            XmlServiceClientMock
                .Stub(j => j.Send<string>(Arg<string>.Is.Equal(HttpMethods.Delete),
                    Arg<string>.Is.Equal(String.Format("/subscription/{0}", SubscriptionId)),
                    Arg<object>.Is.Null))
                .Return(string.Empty);
        }
    }
}
