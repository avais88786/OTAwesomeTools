using OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems;
using OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTraderSunFixes.DomainService.Helpers;
using System.Data.SqlClient;

namespace OpenTraderSunFixes.DomainService.ExternalServiceItems
{
    public class ExternalServiceItemsService : iExternalServiceItemsService
    {
        public ExternalServiceScriptViewModel GetViewModel(ConnectionDetails connectionDetails)
        {
            ExternalServiceItemsContext dbContext = new ExternalServiceItemsContext();
            var vm = new ExternalServiceScriptViewModel();
            if (connectionDetails != null)
            {
                if (connectionDetails.IsValid())
                {
                    dbContext = new ExternalServiceItemsContext();
                    dbContext.ChangeDatabase(connectionDetails, true, "ExternalServiceItems");
                    vm.ConnectionDetails.DataSource = connectionDetails.DataSource;
                    vm.ConnectionDetails.InitialCatalog = connectionDetails.InitialCatalog;
                }
            }
            else
            {
                var config = System.Configuration.ConfigurationManager.ConnectionStrings["ExternalServiceItems"];
                var connection = new SqlConnection(config.ConnectionString);
                vm.ConnectionDetails.DataSource = connection.DataSource;
                vm.ConnectionDetails.InitialCatalog = connection.Database;
            }

            vm.ListExternalServiceTypes = dbContext.ExternalServiceTypes.ToList();
            var yy = from eachScheme in dbContext.ExternalServiceItems.GroupBy(esi => esi.SchemeRiskId).ToList()
                     select eachScheme.ToList().Select(es =>
                     {
                         var ttt = dbContext.imarketExternalServiceItems.FirstOrDefault(imesi => imesi.ExternalServiceItemId == es.ExternalServiceItemId);
                         var esv = dbContext.ExternalServiceVersionings.FirstOrDefault(esv2 => esv2.ExternalServiceItemId == es.ExternalServiceItemId);
                         var responseType = ttt == null ? null : dbContext.imarketResponseTypes
                                                    .Where(imrt => imrt.imarketResponseTypeId == ttt.imarketResponseTypeId)
                                                    .FirstOrDefault();
                         var riskDetails = dbContext.Risks.Single(r => r.RiskId == es.SchemeRiskId);
                         var parentRisk = dbContext.Risks.SingleOrDefault(pr => pr.RiskId == riskDetails.ParentRiskId);
                         return new CurrentExternalServiceEntries
                         {
                             Url = esv == null ? null : esv.ExternalService.Url,
                             SoapAction = dbContext.ExternalServiceVersionings.First(esv1 => esv1.ExternalServiceItemId == es.ExternalServiceItemId).ExternalService.SoapAction,
                             SchemeName = riskDetails.Description,
                             EndpointName = es.Name,
                             ServiceTypeDescription = es.Description,
                             ResponseTypeName = ttt == null ? null : (responseType == null ? null : responseType.Name),
                             IsLive = esv == null ? false : esv.IsLive,
                             RiskId = es.SchemeRiskId.Value,
                             BusinessLine = parentRisk == null ? null : parentRisk.Description
                         };
                     });
            vm.WhatDoIHave = yy.OrderBy(yyy => yyy.First().RiskId);
            return vm;
        }
    }
}
