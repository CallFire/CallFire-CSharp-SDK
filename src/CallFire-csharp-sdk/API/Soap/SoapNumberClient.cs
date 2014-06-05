using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

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
            var regionQueryResult = NumberService.QueryRegions(new RegionQuery(queryRegions));
            return RegionQueryResultMapper.FromRegionQueryResult(regionQueryResult);
        }

        public CfNumberQueryResult QueryNumbers(CfQueryNumbers queryNumbers)
        {
            var numberQueryResult = NumberService.QueryNumbers(new QueryNumbers(queryNumbers));
            return NumberQueryResultMapper.FromNumberQueryResult(numberQueryResult);
        }

        public CfNumber GetNumber(string number)
        {
            return NumberMapper.FromNumber(NumberService.GetNumber(new GetNumber(number)));
        }

        public void ConfigureNumber(CfConfigureNumber configureNumber)
        {
            NumberService.ConfigureNumber(new ConfigureNumber(configureNumber));
        }

        public CfNumberQueryResult SearchAvailableNumbers(CfSearchAvailableNumbers searchAvailableNumbers)
        {
            var numberQueryResult = NumberService.SearchAvailableNumbers(new SearchAvailableNumbers(searchAvailableNumbers));
            return NumberQueryResultMapper.FromNumberQueryResult(numberQueryResult);
        }

        public CfKeywordQueryResult QueryKeywords(CfQuery queryKeywords)
        {
            var keywordQueryResult = NumberService.QueryKeywords(new Query(queryKeywords));
            return KeywordQueryResultMapper.FromKeywordQueryResult(keywordQueryResult);
        }

        public CfKeywordQueryResult SearchAvailableKeywords(CfSearchAvailableKeywords searchAvailableKeywords)
        {
            var keywordQueryResult = NumberService.SearchAvailableKeywords(new SearchAvailableKeywords(searchAvailableKeywords));
            return KeywordQueryResultMapper.FromKeywordQueryResult(keywordQueryResult);
        }

        public long CreateNumberOrder(CfCreateNumberOrder createNumberOrder)
        {
            return NumberService.CreateNumberOrder(new CreateNumberOrder(createNumberOrder));
        }

        public CfNumberOrder GetNumberOrder(long id)
        {
            return NumberOrderMapper.FromNumberOrder(NumberService.GetNumberOrder(new IdRequest(id)));
        }

        public void Release(CfRelease release)
        {
            NumberService.Release(new Release(release));
        }
    }
}
