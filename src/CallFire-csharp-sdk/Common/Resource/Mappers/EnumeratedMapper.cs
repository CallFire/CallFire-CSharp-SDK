using System;
using System.Linq;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class EnumeratedMapper
    {
        private const char Space = ' ';
        private const char Underscore = '_';

        internal static T[] FromSoapEnumerated<T>(string source)
        {
            if (source == null)
            {
                return null;
            }

            var splitString = source.Split(Space);
            var result = new T[splitString.Count()];
            for (var i = 0; i < splitString.Count(); i++)
            {
                var actualWord = splitString[i];
                result[i] = (T)Enum.Parse(typeof(T), ToPascalCase(actualWord));
            }
            return result;
        }

        internal static T EnumFromSoapEnumerated<T>(string source)
        {
            return (T)Enum.Parse(typeof(T), ToPascalCase(source));
        }

        internal static string ToPascalCase(string screamingSnakeCase)
        {
            if (string.IsNullOrEmpty(screamingSnakeCase))
            {
                return string.Empty;
            }

            if (screamingSnakeCase.Length < 2)
            {
                return screamingSnakeCase.ToUpper();
            }

            return screamingSnakeCase
                .Split(Underscore)
                .Aggregate(string.Empty,
                           (current, word) => current + (char.ToUpper(word.First()) + word.Substring(1).ToLower()));
        }

        internal static string ScreamingSnakeCase(string pascalCase)
        {
            if (string.IsNullOrEmpty(pascalCase))
            {
                return string.Empty;
            }

            var screamingSnakeCase = string.Empty;

            for (var i = 0; i < pascalCase.Length; i++)
            {
                var actualLetter = pascalCase[i];         
                if (i == 0)
                {
                    screamingSnakeCase = string.Format("{0}", char.ToUpper(actualLetter));
                }
                else if (char.IsUpper(actualLetter))
                {
                    screamingSnakeCase = string.Format("{0}{1}{2}", screamingSnakeCase, Underscore, actualLetter);
                }
                else
                {
                    screamingSnakeCase = string.Format("{0}{1}", screamingSnakeCase, char.ToUpper(actualLetter));
                }
            }

            return screamingSnakeCase;
        }

        internal static string ToSoapEnumerated<T>(T[] source)
        {
            var result = string.Empty;
            if (source != null)
            {
                for (var i = 0; i < source.Count(); i++)
                {
                    result = ScreamingSnakeCase(source[i].ToString());
                }
            }
            return result;
        }

        internal static T ToSoapEnumerated<T>(string source)
        {
            return (T) Enum.Parse(typeof(T), ScreamingSnakeCase(source)); 
        }
    }
}
