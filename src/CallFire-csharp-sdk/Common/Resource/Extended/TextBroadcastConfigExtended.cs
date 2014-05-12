using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public partial class TextBroadcastConfig
    {
        public TextBroadcastConfig(long identifier, DateTime created, string fromNumber, LocalTimeZoneRestriction localTimeZoneRestriction, BroadcastConfigRetryConfig retryConfig, string message, BigMessageStrategy bigMessageStrategy)
            : base(identifier, created, fromNumber, localTimeZoneRestriction, retryConfig)
        {
            Message = message;
            BigMessageStrategy = bigMessageStrategy;
        }
    }
}
