using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface INumberClient : IClient
    {
        /// <summary>
        /// Queries regions for use in subsequent searches and purchase requests
        /// </summary>
        /// <param name="queryRegions"></param>
        /// <returns></returns>
        CfRegionQueryResult QueryRegions(CfRegionQuery queryRegions);
        
        /// <summary>
        /// Lists numbers owned by your account
        /// </summary>
        /// <param name="queryNumbers"></param>
        /// <returns></returns>
        CfNumberQueryResult QueryNumbers(CfQueryNumbers queryNumbers);
        
        /// <summary>
        /// Get information about a single number owned by your account
        /// </summary>
        /// <param name="number">11 digit telephone number</param>
        /// <returns></returns>
        CfNumber GetNumber(string number);
        
        /// <summary>
        /// Configure a number owned by your account
        /// </summary>
        /// <param name="configureNumber"></param>
        void ConfigureNumber(CfConfigureNumber configureNumber);
        
        /// <summary>
        /// Search for new numbers that are available for purchase
        /// </summary>
        /// <param name="searchAvailableNumbers"></param>
        /// <returns></returns>
        CfNumberQueryResult SearchAvailableNumbers(CfSearchAvailableNumbers searchAvailableNumbers);
        
        /// <summary>
        /// Lists keywords owned by your account
        /// </summary>
        /// <param name="queryKeywords"></param>
        /// <returns></returns>
        CfKeywordQueryResult QueryKeywords(CfQuery queryKeywords);
        
        /// <summary>
        /// Search for keywords available for purchase
        /// </summary>
        /// <param name="searchAvailableKeywords"></param>
        /// <returns></returns>
        CfKeywordQueryResult SearchAvailableKeywords(CfSearchAvailableKeywords searchAvailableKeywords);
        
        /// <summary>
        /// Order new numbers and/or keywords
        /// </summary>
        /// <param name="createNumberOrder"></param>
        /// <returns></returns>
        long CreateNumberOrder(CfCreateNumberOrder createNumberOrder);
        
        /// <summary>
        /// Get the status and results of a previous order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CfNumberOrder GetNumberOrder(long id);

        /// <summary>
        /// Disable auto-renew for a number or keyword
        /// </summary>
        /// <param name="release"></param>
        void Release(CfRelease release);
    }
}
