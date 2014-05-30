// ReSharper disable once CheckNamespace - This is an estension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastStats
    {
        public BroadcastStats()
        {
        }
        
        public BroadcastStats(BroadcastStatsUsageStats usageStats, BroadcastStatsResultStat[] resultStat, BroadcastStatsActionStatistics actionStatistics)
        {
            UsageStats = usageStats;
            ResultStat = resultStat;
            ActionStatistics = actionStatistics;
        }
    }
}
