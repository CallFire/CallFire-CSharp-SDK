namespace CallFire_csharp_sdk.Common.Resource
{
    public abstract class CfUniqueResource
    {
        protected CfUniqueResource(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
