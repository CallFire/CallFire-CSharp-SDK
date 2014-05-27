using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ActionQuery
    {
        public ActionQuery(long maxResult, long firstResult, long broadcastId, long batchId, string state, string result, bool inbound, 
            DateTime intervalBegin, DateTime intervalEnd, string fromNumber, string toNumber, string labelName) 
            : base(maxResult, firstResult)
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

        public ActionQuery()
        {
        }
    }
}
