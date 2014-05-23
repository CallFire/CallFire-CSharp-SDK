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
                    char[] split = { '_' };
                    var words = splitString[i].Split(split);
                    var retryResult = string.Empty;
                    for (var j = 0; j < words.Count(); j++)
                    {
                        var stringCapitalLetter = words[j].Substring(0, 1) + words[j].Substring(1).ToLower();
                        retryResult = j == 0 ? stringCapitalLetter : retryResult + '_' + stringCapitalLetter;
                    }
                    result[i] = (CfResult)Enum.Parse(typeof(CfResult), retryResult);
                }
            }
            return result;
        }
    }
}
