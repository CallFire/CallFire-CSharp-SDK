using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public abstract partial class BroadcastConfig
    {
        protected BroadcastConfig()
        {
        }

        protected BroadcastConfig(long identifier, DateTime created, string fromNumber,
            LocalTimeZoneRestriction localTimeZoneRestriction, BroadcastConfigRetryConfig retryConfig)
        {
            id = identifier;
            Created = created;
            FromNumber = fromNumber;
            LocalTimeZoneRestriction = localTimeZoneRestriction;
            RetryConfig = retryConfig;
        }
    }
}
