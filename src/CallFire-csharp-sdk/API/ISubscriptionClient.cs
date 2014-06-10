using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ISubscriptionClient : IClient
    {
        /// <summary>
        /// Creates a new subscription for CallFire event notifications
        /// </summary>
        /// <param name="cfCreateSubscription"></param>
        /// <returns>Unique ID of resource</returns>
        long CreateSubscription(CfSubscriptionRequest cfCreateSubscription);

        /// <summary>
        /// Get a list of registered subscriptions
        /// </summary>
        /// <param name="cfQuerySubscriptions"></param>
        /// <returns>List of Subscriptions</returns>
        CfSubscriptionQueryResult QuerySubscriptions(CfQuery cfQuerySubscriptions);

        /// <summary>
        /// Gets an existing individual subscription by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns>Subscription requested</returns>
        CfSubscription GetSubscription(long id);

        /// <summary>
        /// Updates an existing subscription
        /// </summary>
        /// <param name="cfUpdateSubscription"></param>
        void UpdateSubscription(CfSubscriptionRequest cfUpdateSubscription);

        /// <summary>
        /// Deletes a subscription by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        void DeleteSubscription(long id);
    }
}
