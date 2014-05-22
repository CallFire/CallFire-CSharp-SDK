using System.Linq;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class EnumeratedMapper
    {
        internal static string ToSoapEnumerated<T>(T[] source)
        {
            var result = string.Empty;
            if (source != null)
            {
                for (var i = 0; i < source.Count(); i++)
                {
                    result = (i == 0) ? source[i].ToString().ToUpper() : result + ' ' + source[i].ToString().ToUpper();
                }
            }
            return result;
        }
    }
}
