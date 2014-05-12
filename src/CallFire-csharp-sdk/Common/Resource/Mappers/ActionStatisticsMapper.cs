using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class ActionStatisticsMapper
    {
        internal static CfBroadcastStatsActionStatistics FromSoapBroadcastStatsActionStatistics(BroadcastStatsActionStatistics source)
        {
            return source == null ? null : new CfBroadcastStatsActionStatistics(source.Unattempted, source.RetryWait,source.Finished);
        }

        internal static BroadcastStatsActionStatistics ToSoapBroadcastStatsActionStatistics(CfBroadcastStatsActionStatistics source)
        {
            return source == null ? null : new BroadcastStatsActionStatistics(source.Unattempted, source.RetryWait, source.Finished);
        }
    }
}
