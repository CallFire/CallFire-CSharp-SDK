using System;
using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class RetryResultsMapper
    {
        internal static CfResult[] FromRetryResults(string source)
        {
            CfResult[] result = null;
            if (source != null)
            {
                char[] delimiter = { ' ' };
                var splitString = source.Split(delimiter);
                result = new CfResult[splitString.Count()];
                for (var i = 0; i < splitString.Count(); i++)
                {
                    result[i] = (CfResult)Enum.Parse(typeof(CfResult), splitString[i]);
                }
            }
            return result;
        }
    }
}
