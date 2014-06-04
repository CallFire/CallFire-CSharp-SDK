// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class NumberQueryResult
    {
        public NumberQueryResult()
        {
        }

        public NumberQueryResult(long totalResults, Number[] number)
        {
            TotalResults = totalResults;
            Number = number;
        }
    }
}
