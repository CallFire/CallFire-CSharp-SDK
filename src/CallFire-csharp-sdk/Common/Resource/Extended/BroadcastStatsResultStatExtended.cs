// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastStatsResultStat
    {
        public BroadcastStatsResultStat(string result, int attempts, int actions)
        {
            Result = result;
            Attempts = attempts;
            Actions = actions;
        }

        public BroadcastStatsResultStat()
        {
        }
    }
}
