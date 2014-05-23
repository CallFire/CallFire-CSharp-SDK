using System;
using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class DaysOfWeekMapper
    {
        private const char Delimiter = ' ';

        internal static CfDaysOfWeek[] FromDaysOfWeek(string source)
        {
            CfDaysOfWeek[] result = null;
            if (source != null)
            {
                var splitString = source.Split(Delimiter);
                result = new CfDaysOfWeek[splitString.Count()];
                for (var i = 0; i < splitString.Count(); i++)
                {
                    result[i] = (CfDaysOfWeek)Enum.Parse(typeof(CfDaysOfWeek), string.Format("{0}{1}", splitString[i].First(), splitString[i].Substring(1).ToLower()));
                }
            }
            return result;
        }
    }
}
