using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace CallFire_csharp_sdk.API.Rest
{
    internal class RestRouteParameters : Dictionary<string, string>
    {
        public RestRouteParameters MaxResults(long maxResults)
        {
            Add("MaxResults", maxResults.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public RestRouteParameters FirstResult(long firstResult)
        {
            Add("FirstResult", firstResult.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public RestRouteParameters Type(string type)
        {
            if (type != null)
            {
                Add("Type", type);
            }
            return this;
        }

        public RestRouteParameters Running(bool? running)
        {
            if (running.HasValue)
            {
                Add("Running", XmlConvert.ToString(running.Value));
            }
            return this;
        }

        public RestRouteParameters LabelName(string labelName)
        {
            if (labelName != null)
            {
                Add("LabelName", labelName);
            }
            return this;
        }

        public RestRouteParameters IntervalBegin(DateTime intervalBegin)
        {
            Add("IntervalBegin", intervalBegin.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public RestRouteParameters IntervalEnd(DateTime intervalEnd)
        {
            Add("IntervalEnd", intervalEnd.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public RestRouteParameters BroadcastId(long broadcastId)
        {
            Add("BroadcastId", broadcastId.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public RestRouteParameters BatchId(long batchId)
        {
            Add("BatchId", batchId.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public RestRouteParameters State(string state)
        {
            if (state != null)
            {
                Add("State", state);
            }
            return this;
        }

        public RestRouteParameters Result(string result)
        {
            if (result != null)
            {
                Add("Result", result);
            }
            return this;
        }

        public RestRouteParameters Inbound(bool? inbound)
        {
            if (inbound.HasValue)
            {
                Add("Inbound", XmlConvert.ToString(inbound.Value));
            }
            return this;
        }

        public RestRouteParameters FromNumber(string fromNumber)
        {
            if (fromNumber != null)
            {
                Add("FromNumber", fromNumber);
            }
            return this;
        }

        public RestRouteParameters ToNumber(string toNumber)
        {
            if (toNumber != null)   
            {
                Add("ToNumber", toNumber);
            }
            return this;
        }
    }
}
