using System;
using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class DaysOfWeekMapper
    {
        internal static CfDaysOfWeek[] FromDaysOfWeek(string source)
        {
            CfDaysOfWeek[] result = null;
            if (source != null)
            {
                char[] delimiter = { ' ' };
                var splitString = source.Split(delimiter);
                result = new CfDaysOfWeek[splitString.Count()];
                for (var i = 0; i < splitString.Count(); i++)
                {
                    result[i] = (CfDaysOfWeek)Enum.Parse(typeof(CfDaysOfWeek), splitString[i].Substring(0, 1) + splitString[i].Substring(1).ToLower());
                }
            }
            return result;
        }
    }
}
