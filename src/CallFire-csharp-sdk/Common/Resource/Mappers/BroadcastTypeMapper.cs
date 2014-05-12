using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class BroadcastTypeMapper
    {
        internal static readonly Dictionary<BroadcastType, CfBroadcastType> DicSoapBroadcastType = new Dictionary
            <BroadcastType, CfBroadcastType>
        {
            {BroadcastType.IVR, CfBroadcastType.Ivr},
            {BroadcastType.TEXT, CfBroadcastType.Text},
            {BroadcastType.VOICE, CfBroadcastType.Voice},
        };

        internal static readonly Dictionary<CfBroadcastType, BroadcastType> DicBroadcastType = new Dictionary
            <CfBroadcastType, BroadcastType>
        {
            {CfBroadcastType.Ivr, BroadcastType.IVR},
            {CfBroadcastType.Text, BroadcastType.TEXT},
            {CfBroadcastType.Voice, BroadcastType.VOICE},
        };

        internal static CfBroadcastType FromSoapBroadcastType(BroadcastType source)
        {
            if (DicSoapBroadcastType.ContainsKey(source))
            {
                return DicSoapBroadcastType[source];
            }
            throw new Exception(string.Format("Exception: Not supported. The source {0} is not validated to be mapped", source));
        }

        internal static BroadcastType ToSoapBroadcastType(CfBroadcastType source)
        {
            if (DicBroadcastType.ContainsKey(source))
            {
                return DicBroadcastType[source];
            }
            throw new Exception(string.Format("Exception: Not supported. The source {0} is not validated to be mapped", source));
        }
    }
}
