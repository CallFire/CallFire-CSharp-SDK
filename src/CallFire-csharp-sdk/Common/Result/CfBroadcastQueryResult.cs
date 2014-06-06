using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfBroadcastQueryResult : CfQueryResult
    {
        /// <summary>
        /// List of Broadcasts
        /// </summary>
        public CfBroadcast[] Broadcast { get; set; }

        public CfBroadcastQueryResult(long totalResults, CfBroadcast[] broadcast)
            : base(totalResults)
        {
            Broadcast = broadcast;
        }
    }
}
