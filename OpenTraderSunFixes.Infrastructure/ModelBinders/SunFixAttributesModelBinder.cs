using OpenTraderSunFixes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenTraderSunFixes.Infrastructure.ModelBinders
{
    public class SunFixAttributesModelBinder :IModelBinder //DefaultModelBinder
    {
        //protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //    base.OnModelUpdated(controllerContext, bindingContext);

        //    ForceModelValidation(bindingContext);
        //}

        //private void ForceModelValidation(ModelBindingContext bindingContext)
        //{
        //    var model = bindingContext.Model as IValidatableObject;
        //    //if (model == null) return;

        //    var modelState = bindingContext.ModelState;

        //    var errors = ((IValidatableObject)bindingContext.Model).Validate(new ValidationContext(model, null, null));
        //}
        
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            
            HttpRequestBase request = controllerContext.HttpContext.Request;
            SunFixAttributes sunFixAttr = new SunFixAttributes();
            var x = bindingContext.PropertyMetadata["MemoAmountNew"].GetValidators(controllerContext);
            
                sunFixAttr.CCTransactionId = Convert.ToInt32(request.Form["CCTransactionId"]);
                sunFixAttr.TransactionType = (SunTransactionType)Enum.Parse(typeof(SunTransactionType), (request.Form["TransactionType"]));
                sunFixAttr.BusinessUnit    = request.Form["BusinessUnit"];
                sunFixAttr.PostingDate = DateTime.Parse(request.Form["PostingDate"]);
                sunFixAttr.SunFixType = (SunFixType)Enum.Parse(typeof(SunFixType), (request.Form["SunFixType"]));
                sunFixAttr.PremiumsEdited = Convert.ToBoolean(request.Form["PremiumsEdited"]);
                sunFixAttr.maxReturn = 1;
                sunFixAttr.resendProcessing = 0;

                try
                {
                    var y = x.ElementAt(0).Validate(request.Form["MemoAmountNew"]);
                    var z = x.ElementAt(2).Validate(request.Form["MemoAmountNew"]);
                double memoAmountNew        = Convert.ToDouble(request.Form["MemoAmountNew"]);
              
                    
                double cCAmountNew          = Convert.ToDouble(request.Form["CCAmountNew"]);
                double totalCommNew         = Convert.ToDouble(request.Form["TotalCommNew"]);
                double powerplaceCommNew    = Convert.ToDouble(request.Form["PowerplaceCommNew"]);
                double brokerCommNew        = Convert.ToDouble(request.Form["BrokerCommNew"]);
                double iPTNew               = Convert.ToDouble(request.Form["IPTNew"]);
                char? appendChar;
                if (request.Form["AppendChar"] == null || request.Form["AppendChar"].Length == 0)
                    appendChar = null;
                else
                    appendChar = Convert.ToChar(request.Form["AppendChar"]);

                sunFixAttr.MemoAmountNew = memoAmountNew;
                sunFixAttr.CCAmountNew = cCAmountNew;
                sunFixAttr.TotalCommNew = totalCommNew;
                sunFixAttr.PowerplaceCommNew = powerplaceCommNew;
                sunFixAttr.BrokerCommNew = brokerCommNew;
                sunFixAttr.IPTNew = iPTNew;
                sunFixAttr.AppendChar = appendChar;
           }
           catch(Exception ex){
               bindingContext.ModelState.AddModelError("CCAmountNew", "unable to convert");
            }

            return sunFixAttr;

        }
    }
}
