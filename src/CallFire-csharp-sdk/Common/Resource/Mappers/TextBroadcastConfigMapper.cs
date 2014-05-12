using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class TextBroadcastConfigMapper
    {
        internal static CfTextBroadcastConfig FromSoapTextBroadcastConfig(TextBroadcastConfig source)
        {
            if (source == null)
            {
                return null;
            }
            var localTimeZoneRestriction =
                LocalTimeZoneRestrictionMapper.FromSoapLocalTimeZoneRestriction(source.LocalTimeZoneRestriction);
            var retryConfig = BroadcastConfigRetryConfigMapper.FromBroadcastConfigRetryConfig(source.RetryConfig);
            var bigMessageStrategy = BigMessageStrategyMapper.FromBigMessageStrategy(source.BigMessageStrategy);
            return new CfTextBroadcastConfig(source.id, source.Created, source.FromNumber, localTimeZoneRestriction, retryConfig, source.Message, bigMessageStrategy);
        }

        internal static TextBroadcastConfig ToSoapTextBroadcastConfig(CfTextBroadcastConfig source)
        {
            if (source == null)
            {
                return null;
            }
            var localTimeZoneRestriction =
                LocalTimeZoneRestrictionMapper.ToSoapLocalTimeZoneRestriction(source.LocalTimeZoneRestriction);
            var retryConfig = BroadcastConfigRetryConfigMapper.ToBroadcastConfigRetryConfig(source.RetryConfig);
            var bigMessageStrategy = BigMessageStrategyMapper.ToBigMessageStrategy(source.BigMessageStrategy);
            return new TextBroadcastConfig(source.Id, source.Created, source.FromNumber,
                localTimeZoneRestriction, retryConfig, source.Message, bigMessageStrategy);
        }
    }
}
