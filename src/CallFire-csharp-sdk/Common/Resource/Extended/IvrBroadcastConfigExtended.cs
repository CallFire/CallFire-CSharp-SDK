using System;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class IvrBroadcastConfig
    {
        public IvrBroadcastConfig(long identifier, DateTime created, string fromNumber, LocalTimeZoneRestriction localTimeZoneRestriction, BroadcastConfigRetryConfig retryConfig, string dialplanXml)
            : base(identifier, created, fromNumber, localTimeZoneRestriction, retryConfig)
        {
            DialplanXml = dialplanXml;
        }

        public IvrBroadcastConfig()
        {
        }
    }
}
