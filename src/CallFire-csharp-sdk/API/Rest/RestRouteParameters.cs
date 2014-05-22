using System;
using System.Collections.Generic;
using System.Globalization;

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
                Add("Running", running.ToString().ToLower());
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
    }
}
