﻿using System;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendText : CfSendRequest
    {
        public CfSendText()
        {
            UseDefaultBroadcast = false;
            ScrubBroadcastDuplicates = false;
            BroadcastName = "API Send";
            Type = CfBroadcastType.Text;
        }

        public CfSendText(string requestId, CfBroadcastType type, string broadcastName, CfToNumber[] toNumber, bool scrubBroadcastDuplicates,
            CfTextBroadcastConfig textBroadcastConfig, long? broadcastId, Boolean useDefaultBroadcast)
        {
            RequestId = requestId;
            Type = type;
            BroadcastName = broadcastName;
            ToNumber = toNumber;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
            TextBroadcastConfig = textBroadcastConfig;
            BroadcastId = broadcastId;
            UseDefaultBroadcast = useDefaultBroadcast;
        }

        public CfSendText(string requestId, CfBroadcastType type, string broadcastName, CfToNumber[] toNumber, bool scrubBroadcastDuplicates, string[] labels,
            CfTextBroadcastConfig textBroadcastConfig, long? broadcastId, Boolean useDefaultBroadcast)
        {
            RequestId = requestId;
            Type = type;
            BroadcastName = broadcastName;
            ToNumber = toNumber;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
            TextBroadcastConfig = textBroadcastConfig;
            BroadcastId = broadcastId;
            UseDefaultBroadcast = useDefaultBroadcast;
            Labels = labels;
        }

        /// <summary>
        /// Configuration needed for a Text Broadcast
        /// </summary>
        public CfTextBroadcastConfig TextBroadcastConfig { get; set; }

        /// <summary>
        /// BroadcastId to send message from
        /// </summary>
        public long? BroadcastId { get; set; }

        /// <summary>
        /// If true send text through existing default broadcast (default: false)
        /// </summary>
        public Boolean UseDefaultBroadcast { get; set; }
    }
}
