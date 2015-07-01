using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace OpenTraderSunFixes.Helpers
{
    public static class Extensions
    {
        public static string IndentAndBeautify(this XmlDocument xmlDoc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = " ";
            xmlSettings.NewLineChars = "\r\n";
            xmlSettings.OmitXmlDeclaration = true;
            xmlSettings.NewLineOnAttributes = true;

            #region option1ToIndent
            //var x = Path.Combine(@"..\",HttpContext.Current.Server.MapPath(null),@"..\App_Data\data.xml");

            //var StringWriter = new StringWriter(sb);
            //using (XmlTextWriter xmlTextWriter = new XmlTextWriter(StringWriter))
            //{ 
            //    xmlTextWriter.Formatting = Formatting.Indented;
            //    xmlDoc.Save(xmlTextWriter);
            //}
            #endregion 

            using (XmlWriter writer = XmlWriter.Create(sb, xmlSettings))
            {

                xmlDoc.Save(writer);
            }

            #region option3toIndent
            //var x = Path.Combine(@"..\",HttpContext.Current.Server.MapPath(null),@"..\App_Data\data.xml");
            //using (XmlWriter writer = XmlWriter.Create(x, xmlSettings))
            //{
            //    writer.WriteString(xmlDoc.Value);
            //    //writer.
            //    writer.Flush();
            //    //xmlDoc.Save(writer);
            //}
            #endregion

            var x2 = sb.ToString();
            //var y = StringWriter.ToString();
            return x2;
        }
    }
}