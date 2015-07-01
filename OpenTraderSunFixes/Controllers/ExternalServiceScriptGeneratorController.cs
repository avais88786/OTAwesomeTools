using OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems;
using OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OpenTraderSunFixes.Controllers
{
    public class ExternalServiceScriptGeneratorController : Controller
    {
        public ActionResult Index()
        {
            var x = new ExternalServiceItemsContext().ExternalServiceTypes;
            
            
            var items = x.ToList().Select(x1 =>
            
                new SelectListItem() { Value = x1.ExternalServiceTypeId.ToString(), Text = x1.Name }
            );
            var vm = new ExternalServiceViewModel();
            vm.ExternalStypes = items.Cast<SelectListItem>();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ExternalServiceViewModel ViewModel)
        {
            var x = PartialView("Script", ViewModel);
            //ViewEngineResult result = ViewEngines.Engines.FindPartialView(this.ControllerContext, "Script");

            //if (result.View != null)
            //{
            //    this.ViewData.Model = ViewModel;
            //    StringBuilder sb = new StringBuilder();
            //    using (StringWriter sw = new StringWriter(sb))
            //    {
            //        using (HtmlTextWriter output = new HtmlTextWriter(sw))
            //        {
            //            ViewContext viewContext = new ViewContext(this.ControllerContext, result.View, this.ViewData, this.TempData, output);
            //            result.View.Render(viewContext, output);
            //        }
            //    }
                
            //    var y = sb.ToString();
            //}

            var externalServiceScriptViewModel = new ExternalServiceScriptViewModel();
            externalServiceScriptViewModel.Description = ViewModel.Description;
            externalServiceScriptViewModel.ExistingDatabaseValues = new ExternalServiceItemsContext();
            externalServiceScriptViewModel.ExternalServiceNames = ViewModel.ExternalServiceNames;
            externalServiceScriptViewModel.ExternalServiceTransform = ViewModel.ExternalServiceTransform;
            externalServiceScriptViewModel.ExternalServiceTypes = ViewModel.ExternalServiceTypes;
            externalServiceScriptViewModel.ExternalStypes = ViewModel.ExternalStypes;
            externalServiceScriptViewModel.OpenRatingEngineId = ViewModel.OpenRatingEngineId;
            externalServiceScriptViewModel.SchemeId = ViewModel.SchemeId;
            externalServiceScriptViewModel.SoapAction = ViewModel.SoapAction;
            externalServiceScriptViewModel.URL = ViewModel.URL;


            return View("Script",externalServiceScriptViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetSchemeName(ExternalServiceViewModel ViewModel)
        {
            return null;
        }


    }
}