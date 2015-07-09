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
using System.Web.Script.Serialization;

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
            var vm = new ExternalServiceScriptViewModel();
            vm.ExternalStypes = items.Cast<SelectListItem>();
             
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(ExternalServiceScriptViewModel ViewModel)
        {
            return View("Script", ViewModel);
        }

        [AllowAnonymous]
        public JsonResult GetSchemeName(int SchemeId)
        {
            ExternalServiceItemsContext context = new ExternalServiceItemsContext();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var x = context.Risks.Where(r => r.RiskId == SchemeId);
            var y = context.OpenRatingEngines.Where(ore => ore.SchemeRiskID == SchemeId).OrderByDescending(ore =>ore.EffectiveDate).ToList();

            ViewEngineResult result = ViewEngines.Engines.FindPartialView(this.ControllerContext, "_PartialOpenRatingEngines");
            var partialResultView = string.Empty;
            if (result.View != null)
            {
                this.ViewData.Model = y;
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    using (HtmlTextWriter output = new HtmlTextWriter(sw))
                    {
                        ViewContext viewContext = new ViewContext(this.ControllerContext, result.View, this.ViewData, this.TempData, output);
                        result.View.Render(viewContext, output);
                    }
                }

                partialResultView = sb.ToString();
            }
            
            return Json(new {SchemeName = x.First().Description,OpenRatingEnginesView = partialResultView }, JsonRequestBehavior.AllowGet);
        }


    }
}