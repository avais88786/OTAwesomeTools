using OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
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

        public static IEnumerable<T> CheckScriptType<T>(this IEnumerable<T> source) 
        {
            if (source == null)
                return Activator.CreateInstance<List<T>>().AsEnumerable();
            return source;
        }
            // all params are optional
        public static void ChangeDatabase(
            this DbContext source,
            ConnectionDetails connectionDetials,
            bool integratedSecuity = true,
            string configConnectionStringName = "")
        /* this would be used if the
        *  connectionString name varied from 
        *  the base EF class name */
        {
            string initialCatalog = connectionDetials.InitialCatalog;
            string dataSource = connectionDetials.DataSource;
            string userId = connectionDetials.UserName;
            string password = connectionDetials.Password;
            
            try
            {
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;

                // add a reference to System.Configuration
                //var entityCnxStringBuilder = new EntityConnectionStringBuilder
                //    (source.Database.Connection.ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (source.Database.Connection.ConnectionString);

                // only populate parameters with values if added
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;
                sqlCnxStringBuilder.MultipleActiveResultSets = true;

                // set the integrated security status
                sqlCnxStringBuilder.IntegratedSecurity = false;
                sqlCnxStringBuilder.ApplicationName = "EntityFramework";
                sqlCnxStringBuilder.PersistSecurityInfo = true;
                // now flip the properties that were changed
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;

                source.Database.Connection.Open();
            }
            catch (Exception ex)
            {
                // set log item if required
            }
        }
        


    }
}