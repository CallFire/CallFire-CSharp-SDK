// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ControlContactBatch
    {
        public ControlContactBatch(long id, string name, bool enabled) : base(id)
        {
            Name = name;
            Enabled = enabled;
        }

        public ControlContactBatch()
        {
        }
    }
}
