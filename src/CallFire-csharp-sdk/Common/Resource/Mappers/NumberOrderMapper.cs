using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class NumberOrderMapper
    {
        internal static CfNumberOrder FromNumberOrder(NumberOrder source)
        {
            if (source == null)
            {
                return null;
            }
            var status = EnumeratedMapper.EnumFromSoapEnumerated<CfOrderStatus>(source.Status.ToString());
            var localNumbers = NumberOrderItemMapper.FromNumberOrderItem(source.LocalNumbers);
            var tollFreeNumbers = NumberOrderItemMapper.FromNumberOrderItem(source.TollFreeNumbers);
            var keywords = NumberOrderItemMapper.FromNumberOrderItem(source.Keywords);
            return new CfNumberOrder(status, source.Created, source.TotalCost, localNumbers, tollFreeNumbers, keywords, source.id);
        }

        internal static NumberOrder ToNumberOrder(CfNumberOrder source)
        {
            return source == null ? null : new NumberOrder(source);
        }
    }
}
