// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastConfigRetryConfig
    {
        public BroadcastConfigRetryConfig(int maxAttempts, int minutesBetweenAttempts, string retryResults, string retryPhoneTypes)
        {
            MaxAttempts = maxAttempts;
            MinutesBetweenAttempts = minutesBetweenAttempts;
            RetryResults = retryResults;
            RetryPhoneTypes = retryPhoneTypes;
        }
    }
}
