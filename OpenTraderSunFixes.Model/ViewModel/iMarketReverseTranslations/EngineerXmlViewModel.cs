using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenTraderSunFixes.Model.ViewModel.iMarketReverseTranslations
{
    public class EngineerXmlViewModel
    {
        [AllowHtml]
        public string SourceXml { get; set; }

        public List<SelectListItem> MappingTypesAvailable { get; set; }

        public string DestinationType { get; set; }

        [AllowHtml]
        public string DestinationXml { get; set; }

        public double? TimeTaken { get; set; }
    }
}
