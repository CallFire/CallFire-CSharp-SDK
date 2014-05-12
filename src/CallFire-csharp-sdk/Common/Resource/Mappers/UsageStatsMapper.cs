using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class UsageStatsMapper
    {
        internal static CfBroadcastStatsUsageStats FromSoapBroadcastStatsUsageStats(BroadcastStatsUsageStats source)
        {
            return source == null ? null : new CfBroadcastStatsUsageStats(source.Duration, source.BilledDuration, source.BilledAmount, source.Attempts, source.Actions);
        }

        internal static BroadcastStatsUsageStats ToSoapBroadcastStatsUsageStats(CfBroadcastStatsUsageStats source)
        {
            return source == null ? null : new BroadcastStatsUsageStats(source.Duration, source.BilledDuration, source.BilledAmount, source.Attempts, source.Actions);
        }
    }
}
