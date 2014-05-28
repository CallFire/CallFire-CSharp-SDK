using System;
using CallFire_csharp_sdk.Common.Resource;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class GetBroadcastStats
    {
        public GetBroadcastStats(long id, DateTime intervalBegin, DateTime intervalEnd) : base(id)
        {
            IntervalBegin = intervalBegin;
            IntervalEnd = intervalEnd;
        }

        public GetBroadcastStats(CfGetBroadcastStats source)
            : base(source.Id)
        {
            IntervalBegin = source.IntervalBegin;
            IntervalEnd = source.IntervalEnd;
        }

        public GetBroadcastStats()
        {
        }
    }
}
