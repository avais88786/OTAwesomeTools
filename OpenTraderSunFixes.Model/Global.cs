using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenTraderSunFixes.Model
{
    public class Global
    {
        public static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

        public static XmlWriterSettings GetSunXMLWriterSettings()
        {
            
            XmlWriterSettings xmlSettings =  new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = " ";
            xmlSettings.NewLineChars = "\r\n";
            xmlSettings.OmitXmlDeclaration = true;
            xmlSettings.NewLineOnAttributes = true;

            return xmlSettings;

        }
    }
}
