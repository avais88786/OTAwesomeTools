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
using System.Data.SqlClient;
using OpenTraderSunFixes.Helpers;

namespace OpenTraderSunFixes.Controllers
{
    public class ExternalServiceScriptGeneratorController : Controller
    {


        public ActionResult Index()
        {
            ExternalServiceItemsContext dbContext = new ExternalServiceItemsContext();
            ConnectionDetails _connectionDetails = (ConnectionDetails)TempData["ConnectionDetails"];
            var vm = new ExternalServiceScriptViewModel();
            
            if (_connectionDetails != null)
            {
                if (_connectionDetails.IsValid())
                {
                    dbContext = new ExternalServiceItemsContext();
                    dbContext.ChangeDatabase(_connectionDetails, true, "ExternalServiceItems");
                    vm.ConnectionDetails.DataSource = _connectionDetails.DataSource;
                    vm.ConnectionDetails.InitialCatalog = _connectionDetails.InitialCatalog;
                    ModelState.Clear();
                }
            }
            else
            {
                var config = System.Configuration.ConfigurationManager.ConnectionStrings["ExternalServiceItems"];
                var connection = new SqlConnection(config.ConnectionString);
                vm.ConnectionDetails.DataSource = connection.DataSource;
                vm.ConnectionDetails.InitialCatalog = connection.Database;
            }
            var x = dbContext.ExternalServiceTypes;
            var items = x.ToList().Select(x1 =>
            
                new SelectListItem() { Value = x1.ExternalServiceTypeId.ToString(), Text = x1.Name }
            );
            vm.ExternalStypes = items.Cast<SelectListItem>();


            var yy = from eachScheme in dbContext.ExternalServiceItems.GroupBy(esi => esi.SchemeRiskId).ToList()
                     select eachScheme.ToList().Select( es=>{
                         return new Temp
                         {
                             Id1 = dbContext.ExternalServiceVersionings.First(esv => esv.ExternalServiceItemId == es.ExternalServiceItemId).ExternalService.Url,
                             Id2 = dbContext.ExternalServiceVersionings.First(esv => esv.ExternalServiceItemId == es.ExternalServiceItemId).ExternalService.SoapAction
                         };
                       });

            var xx = yy.ToList();
            var count = xx.Count;
            var count2 = xx.Max(uiw => uiw.Count());
            var xyz = new string[count, count2];
            int i=0 , j = 0;
            foreach (var uu in yy){
                foreach(var uu2 in uu){
                    xyz[i,j] = uu2.Id1;
                    j++;
                }
                i++;
                j = 0;
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(ExternalServiceScriptViewModel ViewModel)
        {
            if (ViewModel.HasConnectionChanged)
            {
                TempData["ConnectionDetails"] = ViewModel.ConnectionDetails;
                return RedirectToAction("Index");
            }
            else
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

    public class Temp
    {
        public string Id1;

        public string Id2;
    }

}