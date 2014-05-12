using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class BroadcastConfigRetryConfigMapper
    {
        internal static CfBroadcastConfigRetryConfig FromBroadcastConfigRetryConfig(BroadcastConfigRetryConfig source)
        {
            return source == null ? null : new CfBroadcastConfigRetryConfig(source.MaxAttempts, source.MinutesBetweenAttempts, source.RetryResults, source.RetryPhoneTypes);
        }

        internal static BroadcastConfigRetryConfig ToBroadcastConfigRetryConfig(CfBroadcastConfigRetryConfig source)
        {
            return source == null ? null : new BroadcastConfigRetryConfig(source.MaxAttempts, source.MinutesBetweenAttempts, source.RetryResults, source.RetryPhoneTypes);
        }
    }
}
