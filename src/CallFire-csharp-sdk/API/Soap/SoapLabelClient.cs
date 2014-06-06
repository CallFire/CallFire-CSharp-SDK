using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Soap
{
    public class SoapLabelClient : BaseSoapClient, ILabelClient
    {
        internal ILabelServicePortTypeClient LabelService;

        public SoapLabelClient(string username, string password)
        {
            LabelService = new LabelServicePortTypeClient(GetCustomBinding(), GetEndpointAddress<Label>())
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
        }

        internal SoapLabelClient(ILabelServicePortTypeClient client)
        {
            LabelService = client;
        }

        public void DeleteLabel(string labelName)
        {
            LabelService.DeleteLabel(new DeleteLabel { LabelName = labelName });
        }

        public CfLabelQueryResult QueryLabels(CfQuery queryLabels)
        {
            return LabelQueryResultMapper.FromSoapLabelQueryResult(
                LabelService.QueryLabels(new Query(queryLabels.MaxResults, queryLabels.FirstResult)));
        }

        public void LabelBroadcast(long id, string labelName)
        {
            LabelService.LabelBroadcast(new IdLabelRequest(id, labelName));
        }

        public void UnlabelBroadcast(long id, string labelName)
        {
            LabelService.UnlabelBroadcast(new IdLabelRequest(id, labelName));
        }

        public void LabelNumber(string number, string labelName)
        {
            LabelService.LabelNumber(new NumberLabelRequest(number, labelName));
        }

        public void UnlabelNumber(string number, string labelName)
        {
            LabelService.UnlabelNumber(new NumberLabelRequest(number, labelName));
        }
    }
}
