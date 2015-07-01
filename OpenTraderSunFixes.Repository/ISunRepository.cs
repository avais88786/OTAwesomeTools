using OpenTraderSunFixes.Model.GeneratedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenTraderSunFixes.Repository
{
    public interface ISunRepository:IRepository<CCTransaction>
    {
        //[Obsolete]
        //XmlDocument GenerateXML(int maxReturn, 
        //                        string bussinessUnit, 
        //                        int resendProcessing, 
        //                        int ccTransactionId, 
        //                        Model.SunTransactionType typeOfTransaction,
        //                        DateTime? PostingDate,
        //                        bool PremiumsEdited);

        XmlDocument GenerateXML(Model.SunFixAttributes sunFixAttributes);

        string GenerateScript(Model.SunFixAttributes sunFixAttributes);

        XmlDocument GenerateXML(string modifiedScript, Model.SunFixAttributes sunFixAttributes);
    }
}
