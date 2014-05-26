using System;
using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastTypeMapper
    {
        
        internal static readonly TwoWayMapper<BroadcastType, CfBroadcastType> DicBroadcastType = new TwoWayMapper
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

        internal static CfBroadcastType[] FromSoapBroadcastType(BroadcastType[] source)
        {
            CfBroadcastType[] result = null;
            if (source != null)
            {
                result = new CfBroadcastType[source.Count()];
                for (var i = 0; i < source.Count(); i++)
                {
                    if (DicBroadcastType.ContainsKey(source[i]))
                    {
                        result[i] = DicBroadcastType[source[i]];
                    }
                }
            }
            return result;
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
