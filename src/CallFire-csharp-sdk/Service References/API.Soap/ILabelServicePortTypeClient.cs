namespace CallFire_csharp_sdk.API.Soap
{
    internal interface ILabelServicePortTypeClient
    {
        void DeleteLabel(CallFire_csharp_sdk.API.Soap.DeleteLabel DeleteLabel1);
        CallFire_csharp_sdk.API.Soap.LabelQueryResult QueryLabels(CallFire_csharp_sdk.API.Soap.Query QueryLabels1);
        void LabelBroadcast(CallFire_csharp_sdk.API.Soap.IdLabelRequest LabelBroadcast1);
        void UnlabelBroadcast(CallFire_csharp_sdk.API.Soap.IdLabelRequest UnlabelBroadcast1);
        void LabelNumber(CallFire_csharp_sdk.API.Soap.NumberLabelRequest LabelNumber1);
        void UnlabelNumber(CallFire_csharp_sdk.API.Soap.NumberLabelRequest UnlabelNumber1);
    }
}