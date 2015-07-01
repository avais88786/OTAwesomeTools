using OpenTraderSunFixes.Model.GeneratedModel;
using OpenTraderSunFixes.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DomainService
{
    public interface ISunService
    {
        IEnumerable<SearchResultModel> GetCreditControlTransaction(string searchText);
        
        //[Obsolete("Use Model 'SunFixAttributes' as parameter type instead")]
        //string GenerateXML(int maxReturn, string BusinessUnit, int resendProcessing, int CCTransactionId, Model.SunTransactionType TransactionType,DateTime? PostingDate,bool PremiumsEdited);

      //  string ProcessXML(string generatedXML, char? AppendChar);

        string GetFix(Model.SunFixAttributes sunFixAttributes);

        string GenerateXMLFromScript(string scriptToBeExecuted, Model.SunFixAttributes sunFixAttributes);

        CCTransaction GetTransactionByCCTransactionId(int p);

        string ProcessXMLFromStream(System.IO.Stream fileContentStream, Model.SunFixAttributes sunFixAttributes);
    }
}
