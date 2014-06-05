using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Soap
{
    [TestFixture]
    public class GetSubscriptionSoapClientTest : GetSubscriptionClientTest
    {
        protected ISubscriptionServicePortTypeClient SubscriptionServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            SubscriptionServiceMock = MockRepository.GenerateStub<ISubscriptionServicePortTypeClient>();
            Client = new SoapSubscriptionClient(SubscriptionServiceMock);

            SubscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            Subscription = new CfSubscription(1, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, SubscriptionFilter);
            GenerateMock(Subscription, 1);

            var subscription = new CfSubscription(2, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, null);
            GenerateMock(subscription, 2);
        }

        private void GenerateMock(CfSubscription subscription, long id)
        {
            SubscriptionServiceMock.Stub(b => b.GetSubscription(Arg<IdRequest>.Matches(x => x.Id == id)))
                .Return(SubscriptionMapper.ToSoapSubscription(subscription));
        }
    }
}
