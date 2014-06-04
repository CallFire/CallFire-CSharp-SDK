
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class KeywordQueryResult
    {
        public KeywordQueryResult()
        {
        }

        public KeywordQueryResult(long totalResults, Keyword[] keyword)
        {
            TotalResults = totalResults;
            Keyword = keyword;
        }
    }
}
