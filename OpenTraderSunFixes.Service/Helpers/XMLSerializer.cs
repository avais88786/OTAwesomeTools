using OpenTraderSunFixes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTraderSunFixes.DomainService.Helpers
{
    public class XMLSerializer
    {
        public static object DeserializeXML(string p,Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            object o;

            using (TextReader reader = new StringReader(p)){
                o=serializer.Deserialize(reader);
            }

            return o;
        }

        public static string SerializeXML(object o, Type type,XmlSerializerNamespaces namespaceString = null)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            string serializedString="";


            using (TextWriter writer = new StringWriter()){
                serializer.Serialize(writer, o, namespaceString);
                serializedString = writer.ToString();
            }
            return serializedString;
        }


        public static SSC DeserializeSunXML(string generatedXML)
        {
            return (SSC)DeserializeXML(generatedXML, typeof(SSC));
        }


        public static string SerializeSunXML(SSC sunObject)
        {
            return SerializeXML(sunObject, typeof(SSC), sunObject.GetNameSpace());
            #region oldCode
            //XmlSerializer sunXMLSerializer = new XmlSerializer(typeof(SSC));
            //StringBuilder sb = new StringBuilder();

            //XmlWriterSettings xmlSettings = Global.GetSunXMLWriterSettings();

            //using (XmlWriter writer = XmlWriter.Create(sb, xmlSettings))
            //{
            //    sunXMLSerializer.Serialize(writer, sunObject, sunObject.GetNameSpace());
            //}

            //using (TextWriter textWriter = new StringWriter(sb))
            //{
            //    sunXMLSerializer.Serialize(textWriter, sunObject, sunObject.GetNameSpace());
            //}

            //return sb.ToString();
            #endregion 
        }
    }
}
