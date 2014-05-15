using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class NotificationFormatMapper
    {
        private static readonly BiDictionary<NotificationFormat, CfNotificationFormat> DicNotificationFormat = new BiDictionary
            <NotificationFormat, CfNotificationFormat>
        {
            {NotificationFormat.EMAIL, CfNotificationFormat.Email},
            {NotificationFormat.JSON, CfNotificationFormat.Json},
            {NotificationFormat.SOAP, CfNotificationFormat.Soap},
            {NotificationFormat.XML, CfNotificationFormat.Xml}
        };

        internal static CfNotificationFormat FromSoapNotificationFormat(NotificationFormat source)
        {
            if (DicNotificationFormat.ContainsKey(source))
            {
                return DicNotificationFormat[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static NotificationFormat ToSoapNotificationFormat(CfNotificationFormat source)
        {
            if (DicNotificationFormat.ContainsKey(source))
            {
                return DicNotificationFormat[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
