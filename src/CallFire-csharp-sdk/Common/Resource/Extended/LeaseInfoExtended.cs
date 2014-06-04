using CallFire_csharp_sdk.Common.DataManagement;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class LeaseInfo
    {
        public LeaseInfo()
        {
        }
        
        public LeaseInfo(CfLeaseInfo source)
        {
            if (source.LeaseBegin.HasValue)
            {
                LeaseBegin = source.LeaseBegin.Value;
                LeaseBeginSpecified = true;
            }
            if (source.LeaseEnd.HasValue)
            {
                LeaseEnd = source.LeaseEnd.Value;
                LeaseEndSpecified = true;
            }
            AutoRenew = source.AutoRenew;
        }
    }
}
