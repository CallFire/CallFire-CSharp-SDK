
namespace CallFire_csharp_sdk.API.Soap
{
    public interface ISubscriptionServicePortTypeClient : IServicePortClient
    {
        long CreateSubscription(SubscriptionRequest createSubscription1);
        SubscriptionQueryResult QuerySubscriptions(Query querySubscriptions1);
        Subscription GetSubscription(IdRequest getSubscription1);
        void UpdateSubscription(SubscriptionRequest updateSubscription1);
        void DeleteSubscription(IdRequest deleteSubscription1);
    }
}
