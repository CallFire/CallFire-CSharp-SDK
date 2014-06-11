using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.Common.Resource
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://api.callfire.com/data")]
    public class ContactHistory : object
    {

        [System.Xml.Serialization.XmlElementAttribute("Call", typeof(Call), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("Text", typeof(Text), Order = 1)]
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
