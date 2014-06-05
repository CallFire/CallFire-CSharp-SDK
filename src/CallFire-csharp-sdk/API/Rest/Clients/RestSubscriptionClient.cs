using System.Linq;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;

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
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, subscriptionRequest, new CallfireRestRoute<Subscription>());
            return resource.Id;
        }

        public CfSubscriptionQueryResult QuerySubscriptions(CfQuery cfQuerySubscriptions)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new Query(cfQuerySubscriptions),
                new CallfireRestRoute<Subscription>());

            var subscription = resourceList.Resource == null ? null
               : resourceList.Resource.Select(r => SubscriptionMapper.FromSoapSubscription((Subscription)r)).ToArray();
            return new CfSubscriptionQueryResult(resourceList.TotalResults, subscription);
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
