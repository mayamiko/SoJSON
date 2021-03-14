using Newtonsoft.Json;
using System;
using System.Collections;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

/*
    Main class for the extension
    Class has a dependency on Newtosoft.Json @https://github.com/JamesNK/Newtonsoft.Json
 */
public static class SoJSON
{
    //Main method used for the transposition
    //Method requires valid SOAP, particular emphasis on defining namespaces
    public static string SOAPToJSON(this string SOAPString)
    {
        try
        {
            XDocument doc = XDocument.Parse(SOAPString);
            doc.RemoveNamespaces();
            return JsonConvert.SerializeXmlNode(doc.ToXmlDocument());
        }catch(Exception ex)
        {
            return ex.Message;
        }
        
    }
    //Method to remove namespaces from the SOAP structure
    private static void RemoveNamespaces(this XDocument document)
    {
        if (document.Root == null) return;

        foreach (var element in document.Root.DescendantsAndSelf())
        {
            element.Name = element.Name.LocalName;
            element.ReplaceAttributes(GetAttributesWithoutNamespace(element));
        }
    }
    //Get the attrbute names only, without the namespaces
    static IEnumerable GetAttributesWithoutNamespace(XElement xElement)
    {
        return xElement.Attributes()
            .Where(x => !x.IsNamespaceDeclaration)
            .Select(x => new XAttribute(x.Name.LocalName, x.Value));
    }
    //Method to convert XDocument to XmlDocument
    //Needed by Newtonsoft.Json to perform the json serialisation
    private static XmlDocument ToXmlDocument(this XDocument xDocument)
    {
        var xmlDocument = new XmlDocument();
        using (var xmlReader = xDocument.CreateReader())
        {
            xmlDocument.Load(xmlReader);
        }
        return xmlDocument;
    }
}

