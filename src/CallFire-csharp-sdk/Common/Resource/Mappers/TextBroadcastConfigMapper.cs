using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class TextBroadcastConfigMapper
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
            var bigMessageStrategy = EnumeratedMapper.EnumFromSoapEnumerated<CfBigMessageStrategy>(source.BigMessageStrategy.ToString());
            return new CfTextBroadcastConfig(source.id, source.Created, source.FromNumber, localTimeZoneRestriction, retryConfig, source.Message, bigMessageStrategy);
        }

        internal static TextBroadcastConfig ToSoapTextBroadcastConfig(CfTextBroadcastConfig source)
        {
            return source == null ? null : new TextBroadcastConfig(source);
        }
    }
}
