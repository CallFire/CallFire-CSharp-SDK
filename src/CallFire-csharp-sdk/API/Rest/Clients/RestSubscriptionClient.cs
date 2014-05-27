using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Rest.Clients
{
    public class RestSubscriptionClient : BaseRestClient<Subscription>, ISubscriptionClient
    {
        public RestSubscriptionClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestSubscriptionClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public long CreateSubscription(CfSubscriptionRequest cfCreateSubscription)
        {
            var subscriptionRequest = new SubscriptionRequest(cfCreateSubscription.RequestId, 
                SubscriptionMapper.ToSoapSubscription(cfCreateSubscription.Subscription));
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, subscriptionRequest, new CallfireRestRoute<Subscription>(null));
            return resource.Id;
        }

        public CfSubscriptionQueryResult QuerySubscriptions(CfQuery cfQuerySubscriptions)
        {
            var resource = BaseRequest<ResourceList>(HttpMethod.Get, null,
                new CallfireRestRoute<Subscription>(null, null, null, new RestRouteParameters()
                    .MaxResults(cfQuerySubscriptions.MaxResults)
                    .FirstResult(cfQuerySubscriptions.FirstResult)));

            var subscription = ResourceListOperations.CastResourceList<Subscription>(resource);
            var subscriptionQueryResult = new SubscriptionQueryResult(resource.TotalResults, subscription);
            return SubscriptionQueryResultMapper.FromSoapSubscriptionQueryResult(subscriptionQueryResult);
        }

        public CfSubscription GetSubscription(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Subscription>(id));
            return SubscriptionMapper.FromSoapSubscription(resource.Resources as Subscription);
        }

        public void UpdateSubscription(CfSubscriptionRequest cfUpdateSubscription)
        {
            var subscription = cfUpdateSubscription.Subscription;
            if (subscription == null)
            {
                return;
            }
            var subscriptionRequest = new SubscriptionRequest(cfUpdateSubscription.RequestId,
                SubscriptionMapper.ToSoapSubscription(subscription));
            BaseRequest<string>(HttpMethod.Put, subscriptionRequest, new CallfireRestRoute<Subscription>(subscription.Id));
        }

        public void DeleteSubscription(long id)
        {
            BaseRequest<string>(HttpMethod.Delete, null, new CallfireRestRoute<Subscription>(id));
        }
    }
}
