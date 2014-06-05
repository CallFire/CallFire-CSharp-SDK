using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ActionQuery
    {
        public ActionQuery()
        {
        }

        public ActionQuery(CfActionQuery source)
            : base(source.MaxResults, source.FirstResult)
        {
            if (source.BroadcastId.HasValue)
            {
                BroadcastId = source.BroadcastId.Value;
                BroadcastIdSpecified = true;
            }
            if (source.BatchId.HasValue)
            {
                BatchId = source.BatchId.Value;
                BatchIdSpecified = true;
            }
            State = EnumeratedMapper.ToSoapEnumerated(source.State);
            Result = EnumeratedMapper.ToSoapEnumerated(source.Result);
            if (source.Inbound.HasValue)
            {
                Inbound = source.Inbound.Value;
                InboundSpecified = true;
            }
            if (source.IntervalBegin.HasValue)
            {
                IntervalBegin = source.IntervalBegin.Value;
                IntervalBeginSpecified = true;
            }
            if (source.IntervalEnd.HasValue)
            {
                IntervalEnd = source.IntervalEnd.Value;
                IntervalEndSpecified = true;
            }
            FromNumber = source.FromNumber;
            ToNumber = source.ToNumber;
            LabelName = source.LabelName;
        }
    }
}
