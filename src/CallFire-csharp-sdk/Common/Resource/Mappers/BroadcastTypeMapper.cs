using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastTypeMapper
    {
        
        internal static readonly BiDictionary<BroadcastType, CfBroadcastType> DicBroadcastType = new BiDictionary
            <BroadcastType, CfBroadcastType>
        {
            {BroadcastType.IVR, CfBroadcastType.Ivr},
            {BroadcastType.TEXT, CfBroadcastType.Text},
            {BroadcastType.VOICE, CfBroadcastType.Voice},
        };

        internal static CfBroadcastType FromSoapBroadcastType(BroadcastType source)
        {
            if (DicBroadcastType.ContainsKey(source))
            {
                return DicBroadcastType[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static BroadcastType ToSoapBroadcastType(CfBroadcastType source)
        {
            if (DicBroadcastType.ContainsKey(source))
            {
                return DicBroadcastType[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
