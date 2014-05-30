namespace CallFire_csharp_sdk.API.Soap
{
    internal interface ILabelServicePortTypeClient
    {
        void DeleteLabel(DeleteLabel deleteLabel);
        LabelQueryResult QueryLabels(Query queryLabels);
        void LabelBroadcast(IdLabelRequest labelBroadcast);
        void UnlabelBroadcast(IdLabelRequest unlabelBroadcast);
        void LabelNumber(NumberLabelRequest labelNumber);
        void UnlabelNumber(NumberLabelRequest unlabelNumber);
    }
}