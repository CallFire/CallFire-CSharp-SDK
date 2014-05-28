using System.Linq;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Rest
{
    public class RestLabelClient : BaseRestClient<Label>, ILabelClient
    {
        public RestLabelClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestLabelClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public void DeleteLabel(string labelName)
        {
            BaseRequest<string>(HttpMethod.Delete, new { LabelName = labelName }, new CallfireRestRoute<Label>(null));
        }

        public CfLabelQueryResult QueryLabels(CfQuery queryLabels)
        {
            var resource = BaseRequest<ResourceList>(HttpMethod.Get, new Query(queryLabels),
                new CallfireRestRoute<Label>());

            return LabelQueryResultMapper.FromSoapLabelQueryResult(
                new LabelQueryResult
                {
                    TotalResults = resource.TotalResults,
                    Label = resource.Resource.Select(r => (r as Label)).ToArray()
                });
        }

        public void LabelBroadcast(long id, string labelName)
        {
            BaseRequest<string>(HttpMethod.Post, new { LabelName = labelName },
                new CallfireRestRoute<Label>(id, LabelRestRouteObjects.Broadcast, null));
        }

        public void UnlabelBroadcast(long id, string labelName)
        {
            BaseRequest<string>(HttpMethod.Delete, new { LabelName = labelName },
                new CallfireRestRoute<Label>(id, LabelRestRouteObjects.Broadcast, null));
        }

        public void LabelNumber(string number, string labelName)
        {
            BaseRequest<string>(HttpMethod.Post, new { LabelName = labelName },
                new CallfireRestRoute<Label>(null, LabelRestRouteObjects.Number, number));
        }

        public void UnlabelNumber(string number, string labelName)
        {
            BaseRequest<string>(HttpMethod.Delete, new { LabelName = labelName },
                new CallfireRestRoute<Label>(null, LabelRestRouteObjects.Number, number));
        }
    }
}
