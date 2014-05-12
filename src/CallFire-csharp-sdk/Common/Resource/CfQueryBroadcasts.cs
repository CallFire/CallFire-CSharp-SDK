using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryBroadcasts : CfQuery
    {
        public CfQueryBroadcasts(long maxResult, long firstResult, CfBroadcastType type, bool? running, string labelName)
        {
            MaxResults = maxResult;
            FirstResult = firstResult;
            Type = type;
            Running = running;
            LabelName = labelName;
        }

        public CfBroadcastType Type { get; set; }

        public bool? Running;

        public string LabelName { get; set; }
    }
}
