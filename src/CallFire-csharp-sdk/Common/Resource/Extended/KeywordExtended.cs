using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Keyword
    {
        public Keyword()
        {
        }

        public Keyword(CfKeyword source)
        {
            ShortCode = source.ShortCode;
            Keyword1 = source.Keyword1;
            if (source.Status.HasValue)
            {
                Status = EnumeratedMapper.ToSoapEnumerated<NumberStatus>(source.Status.ToString());
                StatusSpecified = true;
            }
            LeaseInfo = LeaseInfoMapper.ToLeaseInfo(source.LeaseInfo);
        }
    }
}
