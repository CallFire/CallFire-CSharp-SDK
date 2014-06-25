using System;
using System.Linq;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API.Rest.Clients
{
    public class RestNumberClient : BaseRestClient<Number>, INumberClient
    {
        public RestNumberClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestNumberClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public CfRegionQueryResult QueryRegions(CfRegionQuery queryRegions)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new RegionQuery(queryRegions),
                new CallfireRestRoute<Number>(null, NumberRestRouteObjects.Regions, null));

            var region = resourceList.Resource == null ? null
                : resourceList.Resource.Select(r => RegionMapper.FromRegion((Region) r)).ToArray();
            return new CfRegionQueryResult(resourceList.TotalResults, region);
        }

        public CfNumberQueryResult QueryNumbers(CfQueryNumbers queryNumbers)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new QueryNumbers(queryNumbers),
                new CallfireRestRoute<Number>());

            var number = resourceList.Resource == null ? null
                : resourceList.Resource.Select(r => NumberMapper.FromNumber((Number)r)).ToArray();
            return new CfNumberQueryResult(resourceList.TotalResults, number);
        }

        public CfNumber GetNumber(string number)
        {
            if (String.IsNullOrEmpty(number))
            {
                return null;
            }
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Number>(long.Parse(number)));
            return NumberMapper.FromNumber((Number)resource.Resources);
        }

        public void ConfigureNumber(CfConfigureNumber configureNumber)
        {
            if (configureNumber != null && !String.IsNullOrEmpty(configureNumber.Number))
            {
                BaseRequest<string>(HttpMethod.Put, new ConfigureNumber(configureNumber),
                    new CallfireRestRoute<Number>(long.Parse(configureNumber.Number)));
            }
        }

        public CfNumberQueryResult SearchAvailableNumbers(CfSearchAvailableNumbers searchAvailableNumbers)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new SearchAvailableNumbers(searchAvailableNumbers),
                new CallfireRestRoute<Number>(null, NumberRestRouteObjects.Search, null));

            var number =  resourceList.Resource == null ? null
                : resourceList.Resource.Select(r => NumberMapper.FromNumber((Number)r)).ToArray();
            return new CfNumberQueryResult(resourceList.TotalResults, number);
        }

        public CfKeywordQueryResult QueryKeywords(CfQuery queryKeywords)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new Query(queryKeywords),
                new CallfireRestRoute<Number>(null, NumberRestRouteObjects.Keyword, null));

            var keyword = resourceList.Resource == null ? null 
                : resourceList.Resource.Select(r => KeywordMapper.FromKeyword((Keyword)r)).ToArray();
            return new CfKeywordQueryResult(resourceList.TotalResults, keyword);
        }

        public CfKeywordQueryResult SearchAvailableKeywords(CfSearchAvailableKeywords searchAvailableKeywords)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new SearchAvailableKeywords(searchAvailableKeywords),
                new CallfireRestRoute<Number>(null, NumberRestRouteObjects.Keyword, NumberRestRouteObjects.Search));

            var keyword = resourceList.Resource == null ? null
                : resourceList.Resource.Select(r => KeywordMapper.FromKeyword((Keyword)r)).ToArray();
            return new CfKeywordQueryResult(resourceList.TotalResults, keyword);
        }

        public long CreateNumberOrder(CfCreateNumberOrder createNumberOrder)
        {
            var resourceReference = BaseRequest<ResourceReference>(HttpMethod.Post, new CreateNumberOrder(createNumberOrder),
                new CallfireRestRoute<Number>(null, NumberRestRouteObjects.Order, null));
            return resourceReference.Id;
        }

        public CfNumberOrder GetNumberOrder(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Number>(id, NumberRestRouteObjects.Order, null));
            return NumberOrderMapper.FromNumberOrder((NumberOrder)resource.Resources);
        }

        public void Release(CfRelease release)
        {
            BaseRequest<string>(HttpMethod.Put, new Release(release), new CallfireRestRoute<Number>(null, NumberRestRouteObjects.Release, null));
        }
    }
}
