namespace CallFire_csharp_sdk.API.Soap
{
    public interface INumberServicePortTypeClient : IServicePortClient
    {
        RegionQueryResult QueryRegions(RegionQuery queryRegions1);
        NumberQueryResult QueryNumbers(QueryNumbers queryNumbers1);
        Number GetNumber(GetNumber getNumber1);
        void ConfigureNumber(ConfigureNumber configureNumber1);
        NumberQueryResult SearchAvailableNumbers(SearchAvailableNumbers searchAvailableNumbers1);
        KeywordQueryResult QueryKeywords(Query queryKeywords1);
        KeywordQueryResult SearchAvailableKeywords(SearchAvailableKeywords searchAvailableKeywords1);
        long CreateNumberOrder(CreateNumberOrder createNumberOrder1);
        NumberOrder GetNumberOrder(IdRequest getNumberOrder1);
        void Release(Release release1);
    }
}
