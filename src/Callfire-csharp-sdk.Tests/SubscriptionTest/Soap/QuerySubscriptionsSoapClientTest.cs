using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Soap
{
    [TestFixture]
    public class QuerySubscriptionsSoapClientTest : QuerySubscriptionsClientTest
    {protected ISubscriptionServicePortTypeClient SubscriptionServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            SubscriptionServiceMock = MockRepository.GenerateStub<ISubscriptionServicePortTypeClient>();
            Client = new SoapSubscriptionClient(SubscriptionServiceMock);

            Query = new CfQuery(100, 0);

            SubscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            Subscription = new CfSubscription(1, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, SubscriptionFilter);

            var subscriptions = new CfSubscription[1];
            subscriptions[0] = Subscription;
            SubscriptionQueryResult = new CfSubscriptionQueryResult(1, subscriptions);

            GenerateMock(SubscriptionQueryResult, Query);
            
            subscriptions[0] = null;
            var subscriptionQueryResult = new CfSubscriptionQueryResult(1, subscriptions);
            var query = new CfQuery(100, 1);
            GenerateMock(subscriptionQueryResult, query);
        }

        private void GenerateMock(CfSubscriptionQueryResult subscriptionQueryResult, CfQuery query)
        {
            SubscriptionServiceMock.Stub(b => b.QuerySubscriptions(Arg<Query>.Matches(x => x.MaxResults == query.MaxResults &&
                                                                                           x.FirstResult == query.FirstResult)))
                .Return(SubscriptionQueryResultMapper.ToSoapSubscriptionQueryResult(subscriptionQueryResult));
        }
    }
}
