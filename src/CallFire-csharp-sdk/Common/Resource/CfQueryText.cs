using System;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryText : CfQuery
    {
        public long BroadcastId { get; set; }

        public long BatchId { get; set; }

        public CfActionState State { get; set; }

        public string Result { get; set; }

        public bool Inbound { get; set; }

        public DateTime IntervalBegin { get; set; }

        public DateTime IntervalEnd { get; set; }

        public string FromNumber { get; set; }

        public string ToNumber { get; set; }

        public string LabelName { get; set; }
    }
}
