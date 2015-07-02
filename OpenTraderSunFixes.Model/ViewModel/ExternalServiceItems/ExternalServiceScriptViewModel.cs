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
            ExternalServiceTypes = new List<int>();
            ExternalServiceNames = new List<string>();
            Description = new List<string>();
            SoapAction = new List<string>();
            URL = new List<string>();
            SchemeName = "Change Me Later";
            RequestTransforms = new List<string>();
            ResponseTransforms = new List<string>();
        }

        [Display(Name="Scheme Id (Risk Id of Scheme")]
        [Remote("GetSchemeName", "ExternalServiceScriptGenerator")]
        public int SchemeId { get; set; }

        public string SchemeName { get; set; }

        [Display(Name = "External Service Types")]
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
        public List<String> TransformConfigs { get; set; }

        public int OpenRatingEngineTypeId { get; set; }

        public DateTime OpenRatingEngineEffectiveDate { get; set; }

        public bool IsLive { get; set; }

        [HiddenInput(DisplayValue = false)]
        public IEnumerable<SelectListItem> ExternalStypes { get; set; }
    }

    public class ExternalServiceScriptViewModel : ExternalServiceViewModel
    {
        public ExternalServiceScriptViewModel()
        {
            ExistingDatabaseValues = new ExternalServiceItemsContext();
        }

        public ExternalServiceItemsContext ExistingDatabaseValues { get; set; }
    }

}
