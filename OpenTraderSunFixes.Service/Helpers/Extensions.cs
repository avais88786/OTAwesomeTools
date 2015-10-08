using OpenGI.MVC.BusinessLines.ViewModels.ViewModels;
using OpenTraderSunFixes.Model;
using OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

        public static object ProcessGroupVisible(this object dataCapture)
        {
            SetGroupVisible(ref dataCapture);
            return dataCapture;
        }

        private static void SetGroupVisible(ref object propertyContents)
        {
            foreach (var propertyInThis in propertyContents.GetType().GetProperties())
            {
                if (propertyInThis.PropertyType.IsSubclassOf(typeof(LogicalGroup)))
                {
                    var propertyValue = ((LogicalGroup)propertyInThis.GetValue(propertyContents));
                    if (propertyValue == null)
                        continue;

                    propertyValue.GroupVisible = true;
                    var objects = (object)propertyValue;
                    SetGroupVisible(ref objects);
                }
                else if (propertyInThis.PropertyType.IsSubclassOf(typeof(RepeatGroupBase)))
                {
                    var propertyValue = ((RepeatGroupBase)propertyInThis.GetValue(propertyContents));
                    if (propertyValue == null)
                        continue;

                    propertyValue.GroupVisible = true;
                    var objects = (object)propertyValue;
                    SetGroupVisible(ref objects);
                }
                else if (propertyInThis.PropertyType.IsClass && !Filter(propertyInThis.PropertyType))
                {
                    if (propertyInThis.PropertyType.IsGenericType && propertyInThis.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var propertyValue = (System.Collections.IList)propertyInThis.GetValue(propertyContents);
                        int i = 0;
                        for (i = 0; i < propertyValue.Count; i++)
                        {
                            var objects = (object)propertyValue[i];
                            ((RepeatGroupBase)objects).GroupVisible = true;
                            SetGroupVisible(ref objects);
                            propertyValue[i] = objects;
                        }
                    }
                    else
                    {
                        var propertyValue = propertyInThis.GetValue(propertyContents);
                        SetGroupVisible(ref propertyValue);
                    }
                }
            }
        }

        static bool Filter(Type type)
        {
            return type.IsPrimitive || NoPrimitiveTypes.Contains(type.Name);
        }

        static readonly HashSet<string> NoPrimitiveTypes = new HashSet<string>() { "String", "DateTime", "Decimal" };

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