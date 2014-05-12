// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastStatsUsageStats
    {
        public BroadcastStatsUsageStats(int duration, int billedDuration, float billedAmount,
        int attempts, int actions)
        {
            Duration = duration;
            BilledDuration = billedDuration;
            BilledAmount = billedAmount;
            Attempts = attempts;
            Actions = actions;
        }
    }
}