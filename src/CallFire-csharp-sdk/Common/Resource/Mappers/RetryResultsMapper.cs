using System;
using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class RetryResultsMapper
    {
        private const char Delimiter1 = ' ';
        private const char Delimiter2 = '_';

        internal static CfResult[] FromRetryResults(string source)
        {
            CfResult[] result = null;
            if (source != null)
            {
                var splitString = source.Split(Delimiter1);
                result = new CfResult[splitString.Count()];
                for (var i = 0; i < splitString.Count(); i++)
                {
                    var words = splitString[i].Split(Delimiter2);
                    var retryResult = string.Empty;
                    for (var j = 0; j < words.Count(); j++)
                    {
                        var stringCapitalLetter = string.Format("{0}{1}", words[j].First(), words[j].Substring(1).ToLower());
                        retryResult = j == 0 ? stringCapitalLetter : string.Format("{0}_{1}", retryResult, stringCapitalLetter);
                    }
                    result[i] = (CfResult)Enum.Parse(typeof(CfResult), retryResult);
                }
            }
            return result;
        }
    }
}
