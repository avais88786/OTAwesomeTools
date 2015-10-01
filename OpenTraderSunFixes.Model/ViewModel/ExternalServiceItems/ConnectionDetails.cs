using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems
{
    public class ConnectionDetails
    {
        [DisplayName("Data Source:")]
        public string DataSource { get; set; }

        [DisplayName("Database:")]
        public string InitialCatalog { get; set; }

        [DisplayName("Username:")]
        public string UserName { get; set; }

        [DisplayName("Password:")]
        public string Password { get; set; }
    }
}
