using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfConfigureNumber
    {
        public CfConfigureNumber()
        {
        }
        
        public CfConfigureNumber(string number, CfNumberConfiguration numberConfiguration)
        {
            Number = number;
            NumberConfiguration = numberConfiguration;
        }

        public string Number { get; set; }

        /// <summary>
        /// Configure Call and Text features
        /// </summary>
        public CfNumberConfiguration NumberConfiguration { get; set; }
    }
}
