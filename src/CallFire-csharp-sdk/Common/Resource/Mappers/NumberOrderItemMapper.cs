using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class NumberOrderItemMapper
    {
        internal static CfNumberOrderItem FromNumberOrderItem(NumberOrderItem source)
        {
            return source == null ? null : new CfNumberOrderItem(source.Ordered, source.UnitCost, source.Fulfilled);
        }

        internal static NumberOrderItem ToNumberOrderItem(CfNumberOrderItem source)
        {
            return source == null ? null : new NumberOrderItem(source);
        }
    }
}
