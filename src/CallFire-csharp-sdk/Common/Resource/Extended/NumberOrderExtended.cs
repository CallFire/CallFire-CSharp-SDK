using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class NumberOrder
    {
        public NumberOrder()
        {
        }

        public NumberOrder(CfNumberOrder source)
        {
            Status = EnumeratedMapper.ToSoapEnumerated<OrderStatus>(source.Status.ToString());
            Created = source.Created;
            TotalCost = source.TotalCost;
            LocalNumbers = NumberOrderItemMapper.ToNumberOrderItem(source.LocalNumbers);
            TollFreeNumbers = NumberOrderItemMapper.ToNumberOrderItem(source.TollFreeNumbers);
            Keywords = NumberOrderItemMapper.ToNumberOrderItem(source.Keywords);
            id = source.Id;
        }
    }
}
