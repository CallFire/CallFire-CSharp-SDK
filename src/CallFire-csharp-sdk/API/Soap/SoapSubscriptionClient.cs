using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Soap
{
    class SoapSubscriptionClient : BaseSoapClient, ISubscriptionClient
    {
        internal SoapSubscriptionClient(string username, string password)
            : base(username, password, TypeInterface.Subscription)
        {
        }

        internal SoapSubscriptionClient(ISubscriptionServicePortTypeClient client)
            : base(client)
        {
        }

        public long CreateSubscription(CfSubscriptionRequest cfCreateSubscription)
        {
            return SubscriptionService.CreateSubscription(new SubscriptionRequest(cfCreateSubscription.RequestId,
                    SubscriptionMapper.ToSoapSubscription(cfCreateSubscription.Subscription)));
        }

        public CfSubscriptionQueryResult QuerySubscriptions(CfQuery cfQuerySubscriptions)
        {
            return SubscriptionQueryResultMapper.FromSoapSubscriptionQueryResult(
                    SubscriptionService.QuerySubscriptions(new Query(cfQuerySubscriptions.MaxResults,
                        cfQuerySubscriptions.FirstResult)));
        }

        public CfSubscription GetSubscription(long id)
        {
            return SubscriptionMapper.FromSoapSubscription(SubscriptionService.GetSubscription(new IdRequest(id)));
        }

        public void UpdateSubscription(CfSubscriptionRequest cfUpdateSubscription)
        {
            var subscription = SubscriptionMapper.ToSoapSubscription(cfUpdateSubscription.Subscription);
            SubscriptionService.UpdateSubscription(new SubscriptionRequest(cfUpdateSubscription.RequestId, subscription));
        }

        public void DeleteSubscription(long id)
        {
            SubscriptionService.DeleteSubscription(new IdRequest(id));
        }
    }
}
