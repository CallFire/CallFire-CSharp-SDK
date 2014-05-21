using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Soap;

[XmlTypeAttribute(AnonymousType = true, Namespace = "http://api.callfire.com/resource")]
[XmlRootAttribute("ResourceList", Namespace = "http://api.callfire.com/resource", IsNullable = false)]
// ReSharper disable once CheckNamespace
public class ResourceList<T>
{
    [XmlAttribute("totalResults")]
    public long TotalResults { get; set; }

    [XmlElementAttribute("Broadcast", typeof (Broadcast), Namespace = "http://api.callfire.com/data", Order = 0)]
    public T[] Resource { get; set; }
}
