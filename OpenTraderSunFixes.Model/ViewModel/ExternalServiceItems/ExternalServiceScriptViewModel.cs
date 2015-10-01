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
    public class ExternalServiceViewModel
    {
        public ExternalServiceViewModel()
        {
            ExternalStypes = new List<SelectListItem>();
            ExternalServiceTypesCheckBox = new List<int>();
            ExternalServiceNames = new List<string>();
            Description = new List<string>();
            SoapAction = new List<string>();
            URL = new List<string>();
            RequestTransforms = new List<string>();
            ResponseTransforms = new List<string>();
            iMarketResponseTypes = new List<string>();
            isLive = new List<bool>();
            ConnectionDetails = new ConnectionDetails();
        }

        public ConnectionDetails ConnectionDetails { get; set; }

        [Display(Name="Scheme Id (Risk Id of Scheme)")]
        //[Remote("GetSchemeName", "ExternalServiceScriptGenerator")]
        public int SchemeId { get; set; }

        public string SchemeName { get; set; }

        [Display(Name = "External Service Types")]
        public List<int> ExternalServiceTypesCheckBox { get; set; }

        public List<int> ExternalServiceTypes { get; set; }

        [Display(Name = "External Service Names")]
        public List<String> ExternalServiceNames { get; set; }

        [Display(Name = "External Service Item Description")]
        public List<String> Description { get; set; }

        [Display(Name = "External Service Url")]
        public List<String> URL { get; set; }

        [Display(Name = "External Service SOAP")]
        public List<String> SoapAction { get; set; }

        [Display(Name = "External Service Request Transform")]
        public List<String> RequestTransforms { get; set; }

        [Display(Name = "External Service Response Transform")]
        public List<String> ResponseTransforms { get; set; }

        [Display(Name = "External Service Transform Config")]
        [AllowHtml]
        public List<String> TransformConfigs { get; set; }

        [Display(Name = "iMarket Response Type Name")]
        public List<String> iMarketResponseTypes { get; set; }

        [Display(Name = "Is Live ?")]
        public List<Boolean> isLive { get; set; }

        public int OpenRatingEngineTypeId { get; set; }

        public DateTime OpenRatingEngineEffectiveDate { get; set; }

        [Display(Name="Script Type")]
        public bool ScriptTypeSingleSchemeOnly { get; set; }

        public string EffectiveDateFormatted
        {
            get
            {
                return OpenRatingEngineEffectiveDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
        }

        [HiddenInput(DisplayValue = false)]
        public IEnumerable<SelectListItem> ExternalStypes { get; set; }
    }

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
