using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastStatsMapper
    {
        internal static CfBroadcastStats FromSoapBroadcastStats(BroadcastStats source)
        {
            if (source == null)
            {
                return null;
            }
            return new CfBroadcastStats(UsageStatsMapper.FromSoapBroadcastStatsUsageStats(source.UsageStats),
                ResultStatMapper.FromSoapBroadcastResultStat(source.ResultStat),
                ActionStatisticsMapper.FromSoapBroadcastStatsActionStatistics(source.ActionStatistics));
        }

        internal static BroadcastStats ToSoapBroadcastStats(CfBroadcastStats source)
        {
            if (source == null)
            {
                return null;
            }
            return new BroadcastStats(
                UsageStatsMapper.ToSoapBroadcastStatsUsageStats(source.UsageStats),
                ResultStatMapper.ToSoapBroadcastResultStat(source.ResultStat),
                ActionStatisticsMapper.ToSoapBroadcastStatsActionStatistics(source.ActionStatistics));
        }
    }
}
