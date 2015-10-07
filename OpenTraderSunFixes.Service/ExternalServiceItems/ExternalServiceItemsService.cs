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
                         return new CurrentExternalServiceEntries
                         {
                             Url = dbContext.ExternalServiceVersionings.First(esv => esv.ExternalServiceItemId == es.ExternalServiceItemId).ExternalService.Url,
                             SoapAction = dbContext.ExternalServiceVersionings.First(esv => esv.ExternalServiceItemId == es.ExternalServiceItemId).ExternalService.SoapAction,
                             RiskID = dbContext.Risks.Single(r => r.RiskId == es.SchemeRiskId).Description,
                             EndpointName = es.Name,
                             ResponseTypeName = ttt == null ? null : dbContext.imarketResponseTypes
                                                    .Where(imrt => imrt.imarketResponseTypeId == ttt.imarketResponseTypeId)
                                                    .FirstOrDefault().Name,
                             IsLive = dbContext.ExternalServiceVersionings.FirstOrDefault(esv => esv.ExternalServiceItemId == es.ExternalServiceItemId).IsLive
                         };
                     });

            vm.WhatDoIHave = yy;
            return vm;
        }
    }
}
