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

        /// <summary>
        /// Unique ID of resource
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Beginning of DateTime interval to search on
        /// </summary>
        public DateTime IntervalBegin { get; set; }

        /// <summary>
        /// End of DateTime interval to search on
        /// </summary>
        public DateTime IntervalEnd { get; set; }
    }
}
