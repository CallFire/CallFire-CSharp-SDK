using System;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfActionQuery : CfQuery
    {
        public CfActionQuery(long maxResult, long firstResult, long? broadcastId, long? batchId, CfActionState[] state, CfResult[] result,
            bool? inbound, DateTime? intervalBegin, DateTime? intervalEnd, string fromNumber, string toNumber, string labelName)
            : base (maxResult, firstResult)
        {
            BroadcastId = broadcastId;
            BatchId = batchId;
            State = state;
            Result = result;
            Inbound = inbound;
            IntervalBegin = intervalBegin;
            IntervalEnd = intervalEnd;
            FromNumber = fromNumber;
            ToNumber = toNumber;
            LabelName = labelName;
        }

        public long? BroadcastId { get; set; }

        public long? BatchId { get; set; }

        public CfActionState[] State { get; set; }

        public CfResult[] Result { get; set; }

        public bool? Inbound { get; set; }

        public DateTime? IntervalBegin { get; set; }

        public DateTime? IntervalEnd { get; set; }

        public string FromNumber { get; set; }

        public string ToNumber { get; set; }

        public string LabelName { get; set; }
    }
}
        
     