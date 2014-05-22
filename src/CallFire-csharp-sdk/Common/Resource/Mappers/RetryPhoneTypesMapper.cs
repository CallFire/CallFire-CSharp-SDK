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
                    result[i] = (CfRetryPhoneType)Enum.Parse(typeof(CfRetryPhoneType), splitString[i]);
                }
            }
            return result;
        }
    }
}
