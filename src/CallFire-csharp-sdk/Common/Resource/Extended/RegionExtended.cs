using CallFire_csharp_sdk.Common.DataManagement;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Region
    {
        public Region()
        {
        }

        public Region(CfRegion source)
        {
            Prefix = source.Prefix;
            City = source.City;
            State = source.State;
            Zipcode = source.Zipcode;
            Country = source.Country;
            Lata = source.Lata;
            RateCenter = source.RateCenter;
            if (source.Latitude.HasValue)
            {
                Latitude = source.Latitude.Value;
                LatitudeSpecified = true;
            }
            if (source.Longitude.HasValue)
            {
                Longitude = source.Longitude.Value;
                LongitudeSpecified = true;
            }
            TimeZone = source.TimeZone;
        }
    }
}
