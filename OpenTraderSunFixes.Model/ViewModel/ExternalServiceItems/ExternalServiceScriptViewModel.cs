using OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems
{
    public class ExternalServiceScriptViewModel : ExternalServiceViewModel
    {
        public ExternalServiceScriptViewModel()
        {
            ExistingDatabaseValues = new ExternalServiceItemsContext();
        }

        public ExternalServiceItemsContext ExistingDatabaseValues { get
        {
            if (base.ScriptTypeSingleSchemeOnly)
            {
                var x = new ExternalServiceItemsContext();
                x.ExternalServiceTransforms = null;
                x.ExternalServices = null;
                x.ExternalServiceTransforms = null;
                x.ExternalServiceItems = null;
                x.ExternalServiceTypes = null;
                x.ExternalServiceVersionings = null;
                x.imarketExternalServiceItems = null;
                x.imarketExternalServices = null;
                x.imarketResponseTypes = null;
                x.OpenRatingEngines = null;
                return x;
            }
            return new ExternalServiceItemsContext();
        }
            private set { }
        }
    }

}
