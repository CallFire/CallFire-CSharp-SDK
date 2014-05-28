using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class ToNumberMapper
    {
        internal static CfToNumber[] FromToNumber(ToNumber[] source)
        {
            return source == null ? null : source.Select(FromToNumber).ToArray();
        }

        internal static ToNumber[] ToToNumber(CfToNumber[] source)
        {
            return source == null ? null : source.Select(ToToNumber).ToArray();
        }

        internal static CfToNumber FromToNumber(ToNumber source)
        {
            return source == null ? null : new CfToNumber(source.ClientData, source.AnyAttr, source.Value);
        }

        internal static ToNumber ToToNumber(CfToNumber source)
        {
            return source == null ? null : new ToNumber(source.ClientData, source.AnyAttr, source.Value);
        }
    }
}
