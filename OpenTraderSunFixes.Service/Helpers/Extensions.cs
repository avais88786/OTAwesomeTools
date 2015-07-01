using OpenTraderSunFixes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTraderSunFixes.DomainService.Helpers
{
    public static class Extensions
    {
        public static string IndentAndBeautify(this XmlDocument xmlDoc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xmlSettings = Global.GetSunXMLWriterSettings();

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

            return sb.ToString(); ;
        }


        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                return true;

            return collection.Count() == 0 ? true : false;
        }
        
    }
}