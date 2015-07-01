using OpenTraderSunFixes.Model.GeneratedModel;
using OpenTraderSunFixes.Repository;
using OpenTraderSunFixes.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OpenTraderSunFixes.DomainService.Helpers;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using OpenTraderSunFixes.Model;
using StructureMap;
using OpenTraderSunFixes.Model.ViewModel;

namespace OpenTraderSunFixes.DomainService
{
    public class SunService : ISunService
    {
        private IRepository<CCOpenTransactionType> ICCOpenTransactionTypeRepo;
        private ICCTransactionRepository ccTransactionRepo;
        private IContainer container;

        public SunService(ICCTransactionRepository _ccTransRepo, IRepository<CCOpenTransactionType> _ccOpenTransRepo,IContainer _container)
        {
            this.ICCOpenTransactionTypeRepo = _ccOpenTransRepo;
            this.ccTransactionRepo = _ccTransRepo;
            this.container = _container;
        }

        //public SunService()
        //{
        //    //ccTransSunRepo = new SunRepository(new SunDBContext());
        //    ccTransactionRepo = new CCTransactionRepository(db);
        //    ICCOpenTransactionTypeRepo = new EFRepository<CCOpenTransactionType>(new SunDBContext());
        //}

        public IEnumerable<SearchResultModel> GetCreditControlTransaction(string searchText)
        {
            int RiskId = 0;
            IEnumerable<SearchResultModel> searchResult = null;
            IEnumerable<CCTransaction> cCTransactionResults = null;
            if (!(searchText == null))
                if (int.TryParse(searchText, out RiskId))
                {
                    CCTransaction ccTran = ccTransactionRepo.GetByRiskId(RiskId);
                    if (!(ccTran == null))
                        cCTransactionResults = GetCreditControlInfoFromPolicyReference(ccTran.Reference);
                }
                else
                {
                    cCTransactionResults = GetCreditControlInfoFromPolicyReference(searchText);

                    if (cCTransactionResults.IsEmpty())
                        cCTransactionResults = GetCreditControlInfoUsingBrokerReference(searchText);
                }


            if ((cCTransactionResults != null) && !cCTransactionResults.IsEmpty()) { 
                cCTransactionResults.AsQueryable()
                                     .Include(c => c.CCExternalTransactionProcess)
                                     .Include(c => c.CCOpenPremiumType)
                                     .Include(c => c.CCOpenTransactionType)
                                     .Include(c => c.CCPaymentType)
                                     .Include(c => c.CCTransactionStatus)
                                     .Include(c => c.BrokerCompany);

                searchResult = SearchResultModel.ConvertCCTransactionsToViewModel(cCTransactionResults.OrderBy(cc=>cc.RiskId));
            }

            //return cCTransactionResults;
            return searchResult;
        }

        private IEnumerable<CCTransaction> GetCreditControlInfoUsingBrokerReference(string searchText)
        {
            return ccTransactionRepo.GetByBrokerReference(searchText);
                              
        }

        private IEnumerable<CCTransaction> GetCreditControlInfoFromPolicyReference(string riskReference)
        {
            return ccTransactionRepo.GetByPowerPlaceReference(riskReference);
                        
        }


        public string GetFix(SunFixAttributes sunFixAttributes)
        {
            try
            {
                SunFixContext sunFix = new SunFixContext(sunFixAttributes.SunFixType,container);
                return sunFix.GenerateFix(sunFixAttributes);
            }
            catch (Exception ex)
            {
                return new StringBuilder("XML/Script Cannot be formed. Please Investigate.\n\nException:\n").Append(ex.Message).ToString();
            }
        }




        public string GenerateXMLFromScript(string scriptToBeExecuted,SunFixAttributes sunFixAttributes)
        {
            SunFixContext sunFixContext = new SunFixContext(SunFixType.Sun, container);
            return sunFixContext.ProcessGeneratedScript(scriptToBeExecuted, sunFixAttributes);
        }


        public CCTransaction GetTransactionByCCTransactionId(int p)
        {
            return ccTransactionRepo.GetById(p);
        }


        public string ProcessXMLFromStream(Stream fileContentStream, Model.SunFixAttributes sunFixAttributes)
        {
            try { 
                    SunFixContext fixContext = new SunFixContext(sunFixAttributes.SunFixType, container);

                    return fixContext.ConvertTestXMLToLive(fileContentStream, sunFixAttributes);
                }
            catch (Exception ex)
            {
                return new StringBuilder("An Error Occured.\n\nException:\n").Append(ex.Message).ToString();
            }

        }
    }
}
