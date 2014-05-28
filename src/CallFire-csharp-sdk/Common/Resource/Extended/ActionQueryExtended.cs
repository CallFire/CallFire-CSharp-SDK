using System;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

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

        public ActionQuery(CfQueryText source)
            : base(source.MaxResults, source.FirstResult)
        {
            BroadcastId = source.BroadcastId;
            BatchId = source.BatchId;
            State = EnumeratedMapper.ToSoapEnumerated(source.State);
            Result = EnumeratedMapper.ToSoapEnumerated(source.Result);
            Inbound = source.Inbound;
            IntervalBegin = source.IntervalBegin;
            IntervalEnd = source.IntervalEnd;
            FromNumber = source.FromNumber;
            ToNumber = source.ToNumber;
            LabelName = source.LabelName;
        }

        public ActionQuery()
        {
        }
    }
}
