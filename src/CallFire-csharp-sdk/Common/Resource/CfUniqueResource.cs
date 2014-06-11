namespace CallFire_csharp_sdk.Common.Resource
{
    public abstract class CfUniqueResource
    {
        protected CfUniqueResource()
        {
        }

        protected CfUniqueResource(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Unique ID of resource
        /// </summary>
        public long Id { get; set; }
    }
}
