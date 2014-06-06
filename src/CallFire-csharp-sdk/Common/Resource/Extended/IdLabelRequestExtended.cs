// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class IdLabelRequest
    {
        public IdLabelRequest()
        {
        }
        
        public IdLabelRequest(long id, string labelName)
            : base(id)
        {
            LabelName = labelName;
        }
    }
}
