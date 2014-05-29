﻿using System;
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
            return properties.Select(v => string.Format("{0}={1}", v.Key, v.Value)).ToArray();
        }

        internal IEnumerable<KeyValuePair<string, string>> GetProperties(object o)
        {
            var result = new List<KeyValuePair<string, string>>();

            var type = o.GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                var value = propertyInfo.GetValue(o, null);
                if (value == null)
                {
                    continue;
                }

                if (propertyInfo.PropertyType.IsArray)
                {
                    var array = ((Array)value);
                    var arrayValue = string.Join(" ", array.Cast<object>().Select(e=>e.ToString()).ToArray());
                    result.Add(new KeyValuePair<string, string>(propertyInfo.Name, HttpUtility.UrlEncode(arrayValue)));
                }
                else if (!IsCustomClass(propertyInfo))
                {
                    if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        result.Add(
                            new KeyValuePair<string, string>(propertyInfo.Name,
                                HttpUtility.UrlEncode(((DateTime)propertyInfo.GetValue(o, null)).ToString(DateFormat))));
                    }
                    else
                    {
                        result.Add(new KeyValuePair<string, string>(propertyInfo.Name,
                            HttpUtility.UrlEncode(value.ToString())));
                    }
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