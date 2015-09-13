using OpenTraderSunFixes.DomainService.iMarketReverseTranslations;
using OpenTraderSunFixes.Model.ViewModel.iMarketReverseTranslations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OpenTraderSunFixes.Controllers
{
    public class iMarketReverseEngineerTranslationController : Controller
    {
        private IimarketReverseEngineerTranslationService _translationEngineerService;

        public iMarketReverseEngineerTranslationController(IimarketReverseEngineerTranslationService _service)
        {
            _translationEngineerService = _service;
        }

        public ActionResult Index()
        {
            var avalilableTypes = _translationEngineerService.GetMappingTypesAvailable();
            EngineerXmlViewModel vm = new EngineerXmlViewModel();
            var selectList = new List<SelectListItem>();
            avalilableTypes.ForEach(aT=> 
            {
                selectList.Add(new SelectListItem(){Text = aT.Name,Value=aT.FullName});
            });
            vm.MappingTypesAvailable = selectList;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(EngineerXmlViewModel viewModel)
        {
            ModelState.Clear();
            var watch = Stopwatch.StartNew();
            var destinationXml =_translationEngineerService.ReverseEnginnerTranslatedXmlToDataCapture(viewModel.SourceXml, viewModel.DestinationType);
            watch.Stop();
            var timeTakenForTranslation = watch.ElapsedMilliseconds;
            

            var avalilableTypes = _translationEngineerService.GetMappingTypesAvailable();
            var selectList = new List<SelectListItem>();
            avalilableTypes.ForEach(aT =>
            {
                selectList.Add(new SelectListItem() { Text = aT.Name, Value = aT.FullName });
            });
            

            EngineerXmlViewModel newVM = new EngineerXmlViewModel();
            newVM.SourceXml = viewModel.SourceXml;
            newVM.MappingTypesAvailable = selectList;
            newVM.DestinationXml = destinationXml;
            newVM.DestinationType = viewModel.DestinationType;
            newVM.TimeTaken = TimeSpan.FromMilliseconds(timeTakenForTranslation).TotalSeconds;

            return View(newVM);
        }


        public string EngineerXml(string sourceXml, string dataCaptureType)
        {
            return _translationEngineerService.ReverseEnginnerTranslatedXmlToDataCapture(sourceXml, dataCaptureType);
        }


    }
}