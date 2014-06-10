// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class NumberLabelRequest
    {
        public NumberLabelRequest()
        {
        }

        public NumberLabelRequest(string number, string labelName)
        {
            Number = number;
            LabelName = labelName;
        }
    }
}
