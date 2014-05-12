using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryBroadcasts : CfQuery
    {
        public CfQueryBroadcasts(long maxResult, long firstResult, CfBroadcastType type, bool running, bool runningSpecified,
            string labelName)
        {
            MaxResults = maxResult;
            FirstResult = firstResult;
            Type = type;
            Running = running;
            RunningSpecified = runningSpecified;
            LabelName = labelName;
        }

        public CfBroadcastType Type { get; set; }

        private bool _runningField;
        public bool Running {
            get
            {
                return _runningField;
            }
            set
            {
                _runningField = value;
                RunningSpecified = true; 
            }
        }

        public bool RunningSpecified { get; set; }

        public string LabelName { get; set; }
    }
}
