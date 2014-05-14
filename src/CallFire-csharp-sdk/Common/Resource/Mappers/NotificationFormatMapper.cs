using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class NotificationFormatMapper
    {
        private static readonly Dictionary<NotificationFormat, CfNotificationFormat> DicSoapNotificationFormat = new Dictionary
            <NotificationFormat, CfNotificationFormat>
        {
            {NotificationFormat.EMAIL, CfNotificationFormat.Email},
            {NotificationFormat.JSON, CfNotificationFormat.Json},
            {NotificationFormat.SOAP, CfNotificationFormat.Soap},
            {NotificationFormat.XML, CfNotificationFormat.Xml}
        };

        private static readonly Dictionary<CfNotificationFormat, NotificationFormat> DicNotificationFormat = new Dictionary
            <CfNotificationFormat, NotificationFormat>
        {
            {CfNotificationFormat.Email, NotificationFormat.EMAIL},
            {CfNotificationFormat.Json, NotificationFormat.JSON},
            {CfNotificationFormat.Soap, NotificationFormat.SOAP},
            {CfNotificationFormat.Xml, NotificationFormat.XML}
        };

        internal static CfNotificationFormat FromSoapNotificationFormat(NotificationFormat source)
        {
            if (DicSoapNotificationFormat.ContainsKey(source))
            {
                return DicSoapNotificationFormat[source];
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
