namespace CallFire_csharp_sdk.Common
{
    internal interface ICustomSerializer
    {
        string SerializeToFormData(object o);
    }
}
