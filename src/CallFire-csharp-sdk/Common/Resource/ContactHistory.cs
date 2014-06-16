using CallFire_csharp_sdk.API.Soap;
using Serializable = System.SerializableAttribute;
using GeneratedCode = System.CodeDom.Compiler.GeneratedCodeAttribute;
using DebuggerStepThrough = System.Diagnostics.DebuggerStepThroughAttribute;
using DesignerCategory = System.ComponentModel.DesignerCategoryAttribute;
using XmlType = System.Xml.Serialization.XmlTypeAttribute;
using XmlElement = System.Xml.Serialization.XmlElementAttribute;

namespace CallFire_csharp_sdk.Common.Resource
{
    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://api.callfire.com/data")]
    public class ContactHistory : object
    {
        [XmlElement("Call", typeof(Call), Order = 1)]
        [XmlElement("Text", typeof(Text), Order = 1)]
        public Action[] ContactHistory1;

        public ContactHistory()
        {
        }

        public ContactHistory(Action[] contactHistory1)
        {
            ContactHistory1 = contactHistory1;
        }
    }
}
