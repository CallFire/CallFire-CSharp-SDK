using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;

[XmlTypeAttribute(AnonymousType = true, Namespace = Namespaces.NamespaceResource)]
[XmlRootAttribute("ResourceException", Namespace = Namespaces.NamespaceResource, IsNullable = false)]
// ReSharper disable once CheckNamespace
public class ResourceException
{
    [XmlElement("message")]
    public string Message { get; set; }
}
