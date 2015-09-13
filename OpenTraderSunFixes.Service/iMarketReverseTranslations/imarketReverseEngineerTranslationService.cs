using AutoMapper;
using OpenGI.MVC.BusinessLines.ViewModels.ViewModels;
using OpenTraderSunFixes.DomainService.Helpers;
using OpenTraderSunFixes.Model.ViewModel.iMarketReverseTranslations;
using OTOMReverseEngineerXML.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DomainService.iMarketReverseTranslations
{
    public class imarketReverseEngineerTranslationService : IimarketReverseEngineerTranslationService
    {
        public string ReverseEnginnerTranslatedXmlToDataCapture(string translatedXML, string dataCaptureType)
        {
            var destinationTypeAssembly = typeof(TabContainer).Assembly;

            var destinationType = destinationTypeAssembly.GetType(dataCaptureType);

            var x2 = Assembly.GetAssembly(typeof(BaseProfile)).GetTypes().Where(x => x.IsSubclassOf(typeof(BaseProfile)));

            var mappedSourceType = Mapper.GetAllTypeMaps().FirstOrDefault(m => m.DestinationType == destinationType);

            if (mappedSourceType == null)
            {
                return null;
            }

            var sourceType = mappedSourceType.SourceType;
                //Assembly.GetAssembly(typeof(BaseProfile)).GetTypes().Where(x => x.IsSubclassOf(typeof(BaseProfile))).Cast<BaseProfile>().Single(s => s.destinationType == destinationType).GetType();
            
            var sourceObject = XMLSerializer.DeserializeXML(translatedXML, sourceType);

            var destinationObject = Mapper.Map(sourceObject, sourceType, destinationType, opt =>
            {
                opt.AfterMap((src, dest) => dest.ProcessGroupVisible());
            });

            var destinationObjectString = XMLSerializer.SerializeXML(destinationObject, destinationType);
            return destinationObjectString;
        }



        public List<Type> GetMappingTypesAvailable()
        {
            return Mapper.GetAllTypeMaps().Where(d => d.DestinationType.IsSubclassOf(typeof(TabContainer))).Select(s => s.DestinationType).ToList();
        }
    }
}
