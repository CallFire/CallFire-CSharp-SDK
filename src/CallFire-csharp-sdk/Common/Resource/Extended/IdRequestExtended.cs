// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class IdRequest
    {
        public IdRequest() : this(0){}

        public IdRequest(long id)
        {
            Id = id;
        }
    }
}
