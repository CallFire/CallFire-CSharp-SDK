using System;
using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class RetryPhoneTypesMapper
    {
        private const char Delimiter1 = ' ';
        private const char Delimiter2 = '_';

        internal static CfRetryPhoneType[] FromRetryPhoneType(string source)
        {
            CfRetryPhoneType[] result = null;
            if (source != null)
            {
                var splitString = source.Split(Delimiter1);
                result = new CfRetryPhoneType[splitString.Count()];
                for (var i = 0; i < splitString.Count(); i++)
                {
                    var words = splitString[i].Split(Delimiter2);
                    var retryPhoneType = string.Empty;
                    for (var j = 0; j < words.Count(); j++)
                    {
                        var stringCapitalLetter = string.Format("{0}{1}", words[j].First(), words[j].Substring(1).ToLower());
                        retryPhoneType = j == 0 ? stringCapitalLetter : string.Format("{0}_{1}", retryPhoneType, stringCapitalLetter);
                    }
                    result[i] = (CfRetryPhoneType)Enum.Parse(typeof(CfRetryPhoneType), retryPhoneType);
                }
            }
            return result;
        }
    }
}
