using OpenTraderSunFixes.Model.ViewModel.iMarketReverseTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DomainService.iMarketReverseTranslations
{
    public interface IimarketReverseEngineerTranslationService
    {
        string ReverseEnginnerTranslatedXmlToDataCapture(string translatedXML, string dataCaptureType);
        List<Type> GetMappingTypesAvailable();
    }
}
