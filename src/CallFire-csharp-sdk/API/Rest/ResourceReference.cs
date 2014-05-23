using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;

[XmlTypeAttribute(AnonymousType = true, Namespace = Namespaces.NamespaceResource)]
[XmlRoot("ResourceReference", Namespace = Namespaces.NamespaceResource, IsNullable = false)]
// ReSharper disable once CheckNamespace
public class ResourceReference
{
    [XmlElement("Id")]
    public long Id { get; set; }

    [XmlElement("Location")]
    public string Location { get; set; }
}

