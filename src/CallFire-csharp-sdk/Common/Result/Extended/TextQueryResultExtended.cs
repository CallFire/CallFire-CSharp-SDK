// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    partial class TextQueryResult
    {
        public TextQueryResult()
        {
        }
        
        public TextQueryResult(long totalResults, Text[] text)
        {
            TotalResults = totalResults;
            Text = text;
        }
    }
}
