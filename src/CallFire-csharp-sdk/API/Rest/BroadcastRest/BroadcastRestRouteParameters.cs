using System.Collections.Generic;
using System.Globalization;

namespace CallFire_csharp_sdk.API.Rest.BroadcastRest
{
    internal class BroadcastRestRouteParameters : Dictionary<string, string>
    {
        public BroadcastRestRouteParameters MaxResults(long maxResults)
        {
            Add("MaxResults", maxResults.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public BroadcastRestRouteParameters FirstResult(long firstResult)
        {
            Add("FirstResult", firstResult.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public BroadcastRestRouteParameters Type(string type)
        {
            if (type != null)
            {
                Add("Type", type);
            }
            return this;
        }

        public BroadcastRestRouteParameters Running(bool running, bool runningSpecified)
        {
            if (runningSpecified)
            {
                Add("Running", running.ToString());
            }
            return this;
        }

        public BroadcastRestRouteParameters LabelName(string labelName)
        {
            if (labelName != null)
            {
                Add("LabelName", labelName);
            }
            return this;
        }
    }
}
