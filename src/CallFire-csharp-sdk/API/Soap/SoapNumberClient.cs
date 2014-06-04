using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API.Soap
{
    public class SoapNumberClient : BaseSoapClient, INumberClient
    {
        internal INumberServicePortTypeClient NumberService;

        public SoapNumberClient(string username, string password)
        {
            NumberService = new NumberServicePortTypeClient(GetCustomBinding(), GetEndpointAddress<Number>())
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
        }

        internal SoapNumberClient(INumberServicePortTypeClient client)
        {
            NumberService = client;
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
