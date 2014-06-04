using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Release
    {
        public Release()
        {
        }

        public Release(CfRelease source)
        {
            Number = source.Number;
            Keyword = source.Keyword;
        }
    }
}
