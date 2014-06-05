using System.Xml.Serialization;

namespace CallFire_csharp_sdk.API.Rest.Data
{
    [XmlType(AnonymousType = true, Namespace = CallfireNamespace.Resource)]
    [XmlRoot("ResourceReference", Namespace = CallfireNamespace.Resource, IsNullable = false)]
    public class ResourceReference
    {
        [XmlElement("Id")]
        public long Id { get; set; }

        [XmlElement("Location")]
        public string Location { get; set; }
    }
}

