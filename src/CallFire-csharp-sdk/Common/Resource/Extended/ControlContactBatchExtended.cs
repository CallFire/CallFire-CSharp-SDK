using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ControlContactBatch
    {
        public ControlContactBatch()
        {
        }
        
        public ControlContactBatch(CfControlContactBatch cfControlContactBatch)
            : base(cfControlContactBatch.Id)
        {
            Name = cfControlContactBatch.Name;
            if (cfControlContactBatch.Enabled.HasValue)
            {
                Enabled = cfControlContactBatch.Enabled.Value;
                EnabledSpecified = true;
            }
        }
    }
}
