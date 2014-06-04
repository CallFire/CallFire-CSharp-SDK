using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API.Rest.Clients
{
    public class RestNumberClient : BaseRestClient<Number>, INumberClient
    {
        public RestNumberClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestNumberClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public CfRegionQueryResult QueryRegions(CfRegionQuery queryRegions)
        {
            return null;
        }

        public CfNumberQueryResult QueryNumbers(CfQueryNumbers queryNumbers)
        {
            return null;
        }

        public CfNumber GetNumber(CfGetNumber getNumber)
        {
            return null;
        }

        public void ConfigureNumber(CfConfigureNumber configureNumber)
        {
        }

        public CfNumberQueryResult SearchAvailableNumbers(CfSearchAvailableNumbers searchAvailableNumbers)
        {
            return null;
        }

        public CfKeywordQueryResult QueryKeywords(CfQuery queryKeywords)
        {
            return null;
        }

        public CfKeywordQueryResult SearchAvailableKeywords(CfSearchAvailableKeywords searchAvailableKeywords)
        {
            return null;
        }

        public long CreateNumberOrder(CfCreateNumberOrder createNumberOrder)
        {
            return 0;
        }

        public CfNumberOrder GetNumberOrder(long id)
        {
            return null;
        }

        public void Release(CfRelease release)
        {
        }
    }
}
