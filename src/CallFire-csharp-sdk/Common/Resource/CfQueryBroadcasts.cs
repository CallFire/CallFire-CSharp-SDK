using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryBroadcasts : CfQuery
    {
        public CfQueryBroadcasts()
        {
        }

        public CfQueryBroadcasts(long maxResult, long firstResult, CfBroadcastType[] type, bool? running, string labelName)
        {
            MaxResults = maxResult;
            FirstResult = firstResult;
            Type = type;
            Running = running;
            LabelName = labelName;
        }

        /// <summary>
        /// List of Broadcast Type [Voice, Ivr, Text]
        /// </summary>
        public CfBroadcastType[] Type { get; set; }

        /// <summary>
        /// Filter on running Broadcasts
        /// </summary>
        public bool? Running;

        /// <summary>
        /// Label that result must have to be included
        /// </summary>
        public string LabelName { get; set; }
    }
}
