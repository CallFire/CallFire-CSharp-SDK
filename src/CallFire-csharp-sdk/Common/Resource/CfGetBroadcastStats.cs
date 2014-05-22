using System;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfGetBroadcastStats
    {
        public CfGetBroadcastStats(long id, DateTime intervalBegin, DateTime intervalEnd)
        {
            Id = id;
            IntervalBegin = intervalBegin;
            IntervalEnd = intervalEnd;
        }

        public long Id { get; set; }

        public DateTime IntervalBegin { get; set; }

        public DateTime IntervalEnd { get; set; }
    }
}
