using OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DomainService.ExternalServiceItems
{
    public interface iExternalServiceItemsService
    {
        ExternalServiceScriptViewModel GetViewModel(ConnectionDetails connectionDetails);
    }
}
