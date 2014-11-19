//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 0.3.5436.30355.
namespace IS24RestApi.Offer.Realtor
{
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// </summary>
    [System.SerializableAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "0.3.5436.30355")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("Realtor", Namespace="http://rest.immobilienscout24.de/schema/offer/realtor/1.0")]
    [System.Xml.Serialization.XmlRootAttribute("realtor", Namespace="http://rest.immobilienscout24.de/schema/offer/realtor/1.0")]
    public partial class Realtor
    {
        
        /// <summary>
        /// <para xml:lang="de-DE">Die Kundennummer des Anbieters wenn er ein Kunde ist.</para>
        /// <para xml:lang="en">The customer number of the realtor if he is a customer.</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("customerNumber", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="string")]
        public string CustomerNumber { get; set; }
        
        /// <summary>
        /// <para xml:lang="de-DE">Ist Firmenprofil / Homepage aktiviert.</para>
        /// <para xml:lang="en">Is the homepage activated.</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("businessCardActivated", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="boolean")]
        public bool BusinessCardActivated { get; set; }
    }
}