using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CallFire_csharp_sdk.Common
{
    internal class CustomSerializer : ICustomSerializer
    {
        private const string DateFormat = "yyyy-MM-ddThh:mm:ss";

        public string SerializeToFormData(object o)
        {
            return o == null ? string.Empty : string.Join("&", ToCustomFormatArray(GetProperties(o)));
        }

        internal string[] ToCustomFormatArray(IEnumerable<KeyValuePair<string, string>> properties)
        {
            return properties.Where(v => !string.IsNullOrEmpty(v.Value)).Select(v => string.Format("{0}={1}", v.Key, v.Value)).ToArray();
        }

        internal IEnumerable<KeyValuePair<string, string>> GetProperties(object o)
        {
            var result = new List<KeyValuePair<string, string>>();

            var type = o.GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                var value = propertyInfo.GetValue(o, null);
                if ((value == null) || propertyInfo.Name.EndsWith("Specified") || propertyInfo.Name.EndsWith("ContactId"))
                {
                    continue;
                }
                
                var name = string.Format("{0}{1}", propertyInfo.Name, "Specified");
                if (props.Any(p => p.Name == name && !((bool) p.GetValue(o, null))))
                {
                    continue;
                }

                if (propertyInfo.PropertyType.IsArray)
                {
                    var array = ((Array)value);
                    var arrayValue = string.Join(" ", array.OfType<object>().Select(e => e.ToString()).ToArray());
                    result.Add(new KeyValuePair<string, string>(propertyInfo.Name, HttpUtility.UrlEncode(arrayValue)));
                }
                else if (!IsCustomClass(propertyInfo))
                {
                    var stringValue = value.ToString();

                    if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        stringValue = ((DateTime)value).ToString(DateFormat);
                    }

                    result.Add(new KeyValuePair<string, string>(propertyInfo.Name, HttpUtility.UrlEncode(stringValue)));
                }
                else
                {
                    result.AddRange(GetProperties(value));
                }
            }
            return result;
        }

        private bool IsCustomClass(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType.Namespace != "System";
        }
    }
}
