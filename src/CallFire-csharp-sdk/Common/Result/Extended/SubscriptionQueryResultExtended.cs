// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    partial class SubscriptionQueryResult
    {
        public SubscriptionQueryResult(long totalResults, Subscription[] subscription)
        {
            TotalResults = totalResults;
            Subscription = subscription;
        }

        public SubscriptionQueryResult()
        {
        }
    }
}
