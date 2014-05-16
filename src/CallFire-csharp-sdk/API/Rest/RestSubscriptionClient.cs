using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace CallFire_csharp_sdk.API.Rest
{
    public class RestSubscriptionClient : BaseRestClient<Subscription>, ISubscriptionClient
    {
        public RestSubscriptionClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestSubscriptionClient(JsonServiceClient jsonClient)
            : base(jsonClient)
        {
        }

        public long CreateSubscription(CfSubscriptionRequest cfCreateSubscription)
        {
            var subscriptionRequest = new SubscriptionRequest(cfCreateSubscription.RequestId, 
                SubscriptionMapper.ToSoapSubscription(cfCreateSubscription.Subscription));
            return BaseRequest<long>(HttpMethods.Post, subscriptionRequest, new CallfireRestRoute<Subscription>(null));
        }

        public CfSubscriptionQueryResult QuerySubscriptions(CfQuery cfQuerySubscriptions)
        {
            return SubscriptionQueryResultMapper.FromSoapSubscriptionQueryResult( BaseRequest<SubscriptionQueryResult>(HttpMethods.Get, null,
                        new CallfireRestRoute<Subscription>(null, null, null, new RestRouteParameters()
                            .MaxResults(cfQuerySubscriptions.MaxResults)
                            .FirstResult(cfQuerySubscriptions.FirstResult))));
        }

        public CfSubscription GetSubscription(long id)
        {
            return SubscriptionMapper.FromSoapSubscription(BaseRequest<Subscription>(HttpMethods.Get, null,
                    new CallfireRestRoute<Subscription>(id)));
        }

        public void UpdateSubscription(CfSubscriptionRequest cfUpdateSubscription)
        {
            var subscription = cfUpdateSubscription.Subscription;
            if (subscription == null)
            {
                return;
            }
            var subscriptionRequest = new SubscriptionRequest(cfUpdateSubscription.RequestId,
                SubscriptionMapper.ToSoapSubscription(cfUpdateSubscription.Subscription));
            BaseRequest<string>(HttpMethods.Put, subscriptionRequest, new CallfireRestRoute<Subscription>(subscription.Id));
        }

        public void DeleteSubscription(long id)
        {
            BaseRequest<string>(HttpMethods.Delete, null, new CallfireRestRoute<Subscription>(id));
        }
    }
}
