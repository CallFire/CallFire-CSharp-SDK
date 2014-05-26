using System;
using System.Linq;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class EnumeratedMapper
    {
        private const char Delimiter1 = ' ';
        private const char Delimiter2 = '_';

        internal static T[] FromSoapEnumerated<T>(string source)
        {
            if (source == null)
            {
                return null;
            }

            var splitString = source.Split(Delimiter1);
            var result = new T[splitString.Count()];
            for (var i = 0; i < splitString.Count(); i++)
            {
                var words = splitString[i].Split(Delimiter2);
                var retryPhoneType = string.Empty;
                for (var j = 0; j < words.Count(); j++)
                {
                    var stringCapitalLetter = string.Format("{0}{1}", words[j].First(), words[j].Substring(1).ToLower());
                    retryPhoneType = j == 0 ? stringCapitalLetter : string.Format("{0}_{1}", retryPhoneType, stringCapitalLetter);
                }
                result[i] = (T)Enum.Parse(typeof(T), retryPhoneType);
            }
            return result;
        }

        internal static string ToSoapEnumerated<T>(T[] source)
        {
            var result = string.Empty;
            if (source != null)
            {
                for (var i = 0; i < source.Count(); i++)
                {
                    result = (i == 0) ? source[i].ToString().ToUpper() : string.Format("{0} {1}", result, source[i].ToString().ToUpper());
                }
            }
            return result;
        }
    }
}
