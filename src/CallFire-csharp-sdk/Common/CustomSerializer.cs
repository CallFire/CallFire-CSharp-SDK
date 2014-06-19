using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;

namespace CallFire_csharp_sdk.Common
{
    internal class CustomSerializer : ICustomSerializer
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private const string TimeFormat = "HH:mm:ss";
        private const string DateFormat = "yyyy-MM-dd";

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
                if (CheckSpecifiedProperties(o, value, propertyInfo, props))
                {
                    continue;
                }

                if (propertyInfo.PropertyType.IsArray)
                {
                    AddEncodedArray(value, propertyInfo, result);
                }
                else if (!IsCustomClass(propertyInfo))
                {
                    AddEncodedValue(value, propertyInfo, result);
                }
                else
                {
                    result.AddRange(GetProperties(value));
                }
            }
            return result;
        }

        private static void AddEncodedValue(object value, PropertyInfo propertyInfo, List<KeyValuePair<string, string>> result)
        {
            var stringValue = value.ToString();

            var attribs = (XmlElementAttribute[])Attribute.GetCustomAttributes(propertyInfo, typeof(XmlElementAttribute));
            if (propertyInfo.PropertyType == typeof (DateTime))
            {
                stringValue = FindDateFormat(value, attribs);
            }

            var elementName = propertyInfo.Name;
            if (attribs.Any(i => i.Type == value.GetType()))
            {
                elementName = attribs.First(i => i.Type == value.GetType()).ElementName;
            }
            result.Add(new KeyValuePair<string, string>(elementName, HttpUtility.UrlEncode(stringValue)));
        }

        private static string FindDateFormat(object value, XmlElementAttribute[] attribs)
        {
            if (attribs.Any())
            {
                var dataType = attribs[0].DataType;
                switch (dataType)
                {
                    case "time":
                        return ((DateTime)value).ToString(TimeFormat);
                    case "date":
                        return ((DateTime)value).ToString(DateFormat);
                    default:
                        return ((DateTime)value).ToString(DateTimeFormat);
                }
            }
            return ((DateTime) value).ToString(DateTimeFormat);
        }

        private void AddEncodedArray(object value, PropertyInfo propertyInfo, List<KeyValuePair<string, string>> result)
        {
            var array = ((Array) value);
            var attribs = (XmlElementAttribute[]) Attribute.GetCustomAttributes(propertyInfo, typeof (XmlElementAttribute));
            if (array.Length <= 0 || attribs.All(i => i.Type != array.GetValue(0).GetType()))
            {
                return;
            }
            var elementName = attribs.First(i => i.Type == array.GetValue(0).GetType()).ElementName;
            if (IsCustomClass(array.GetType().GetElementType()))
            {
                for (var i = 0; i < array.Length; i++)
                {
                    var elementProperties = GetProperties(array.GetValue(i));
                    result.AddRange(elementProperties.Select(a => new KeyValuePair<string, string>
                        (string.Format("{0}[{1}][{2}]", elementName, i, a.Key), a.Value)));
                }
            }
            else
            {
                var arrayValue = string.Join(" ", array.OfType<object>().Select(e => e.ToString()).ToArray());
                result.Add(new KeyValuePair<string, string>(elementName, HttpUtility.UrlEncode(arrayValue)));
            }
        }

        private static bool CheckSpecifiedProperties(object o, object value, PropertyInfo propertyInfo, IEnumerable<PropertyInfo> props)
        {
            const string specified = "Specified";

            if ((value == null) || propertyInfo.Name.EndsWith(specified))
            {
                return true;
            }

            var name = string.Format("{0}{1}", propertyInfo.Name, specified);

            return props.Any(property => property.Name == name && !((bool)property.GetValue(o, null)));
        }

        private bool IsCustomClass(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType.Namespace != "System";
        }

        private bool IsCustomClass(Type type)
        {
            return type.IsClass && type.Namespace != "System";
        }
    }
}
