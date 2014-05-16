using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ISubscriptionClient : IClient
    {
        long CreateSubscription(CfSubscriptionRequest cfCreateSubscription);

        CfSubscriptionQueryResult QuerySubscriptions(CfQuery cfQuerySubscriptions);

        CfSubscription GetSubscription(long id);

        void UpdateSubscription(CfSubscriptionRequest cfUpdateSubscription);

        void DeleteSubscription(long id);
    }
}
