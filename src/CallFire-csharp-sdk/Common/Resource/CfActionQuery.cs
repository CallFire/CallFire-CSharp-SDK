using System;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfActionQuery : CfQuery
    {
        public CfActionQuery()
        {
        }

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

        /// <summary>
        /// BroadcastId to query on
        /// </summary>
        public long? BroadcastId { get; set; }

        /// <summary>
        /// BatchId to query on
        /// </summary>
        public long? BatchId { get; set; }

        /// <summary>
        /// List of Action States to query on [Ready, Selected, Finished, Dnc, Dup, Invalid, Timeout]
        /// </summary>
        public CfActionState[] State { get; set; }

        /// <summary>
        /// List of Results to query on [La, Am, Busy, Dnc, Xfer, XferLeg, NoAns, Undialed, Sent, 
        /// Received, Dnt, TooBig, InternalError, CarrierError, CarrierTempError]
        /// </summary>
        public CfResult[] Result { get; set; }

        /// <summary>
        /// Is call inbound
        /// </summary>
        public bool? Inbound { get; set; }

        /// <summary>
        /// Beginning of DateTime interval to search on
        /// </summary>
        public DateTime? IntervalBegin { get; set; }

        /// <summary>
        /// End of DateTime interval to search on
        /// </summary>
        public DateTime? IntervalEnd { get; set; }

        /// <summary>
        /// E.164 11 digit number
        /// </summary>
        public string FromNumber { get; set; }

        /// <summary>
        /// E.164 11 digit number
        /// </summary>
        public string ToNumber { get; set; }

        /// <summary>
        /// Label that result must have to be included
        /// </summary>
        public string LabelName { get; set; }
    }
}
        
     