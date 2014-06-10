using CallFire_csharp_sdk.Common.DataManagement;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class NumberOrderItem
    {
        public NumberOrderItem()
        {
        }

        public NumberOrderItem(CfNumberOrderItem source)
        {
            Ordered = source.Ordered;
            UnitCost = source.UnitCost;
            Fulfilled = source.Fulfilled;
        }
    }
}
