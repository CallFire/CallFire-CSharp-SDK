using System;
using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class RetryPhoneTypesMapper
    {
        internal static CfRetryPhoneType[] FromRetryPhoneType(string source)
        {
            CfRetryPhoneType[] result = null;
            if (source != null)
            {
                char[] delimiter = { ' ' };
                var splitString = source.Split(delimiter);
                result = new CfRetryPhoneType[splitString.Count()];
                for (var i = 0; i < splitString.Count(); i++)
                {
                    char[] split = {'_'};
                    var words = splitString[i].Split(split);
                    var retryPhoneType = string.Empty;
                    for (var j = 0; j < words.Count(); j++)
                    {
                        var stringCapitalLetter = words[j].Substring(0, 1) + words[j].Substring(1).ToLower();
                        retryPhoneType = j == 0 ? stringCapitalLetter : retryPhoneType + '_' + stringCapitalLetter;
                    }
                    result[i] = (CfRetryPhoneType)Enum.Parse(typeof(CfRetryPhoneType), retryPhoneType);
                }
            }
            return result;
        }
    }
}
