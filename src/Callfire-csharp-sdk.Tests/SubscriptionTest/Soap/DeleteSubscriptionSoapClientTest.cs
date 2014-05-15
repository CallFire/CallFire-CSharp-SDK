
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Soap
{
    [TestFixture]
    public class DeleteSubscriptionSoapClientTest : DeleteSubscriptionClientTest
    {
        protected ISubscriptionServicePortTypeClient SubscriptionServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            SubscriptionServiceMock = MockRepository.GenerateStub<ISubscriptionServicePortTypeClient>();
            Client = new SoapSubscriptionClient(SubscriptionServiceMock);

            SubscriptionId = 1;

            SubscriptionServiceMock.Stub(b => b.DeleteSubscription(Arg<IdRequest>.Matches(x => x.Id == SubscriptionId)));
        }
    }
}
