using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface INumberClient : IClient
    {
        CfRegionQueryResult QueryRegions(CfRegionQuery queryRegions);
        
        CfNumberQueryResult QueryNumbers(CfQueryNumbers queryNumbers);
        
        CfNumber GetNumber(CfGetNumber getNumber);
        
        void ConfigureNumber(CfConfigureNumber configureNumber);
        
        CfNumberQueryResult SearchAvailableNumbers(CfSearchAvailableNumbers searchAvailableNumbers);
        
        CfKeywordQueryResult QueryKeywords(CfQuery queryKeywords);
        
        CfKeywordQueryResult SearchAvailableKeywords(CfSearchAvailableKeywords searchAvailableKeywords);
        
        long CreateNumberOrder(CfCreateNumberOrder createNumberOrder);
        
        CfNumberOrder GetNumberOrder(long id);

        void Release(CfRelease release);
    }
}
