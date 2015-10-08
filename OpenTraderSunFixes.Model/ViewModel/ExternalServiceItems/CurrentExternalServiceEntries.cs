using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.Model.ViewModel.ExternalServiceItems
{
    public class CurrentExternalServiceEntries
    {
        private string _mTAKey = "MTA";
        private string _acceptanceKey = "Accept";
        private string _asyncKey = "Async";

        public string RiskID;

        public string Url;

        public string SoapAction;

        public string ResponseTypeName;

        public bool IsLive;

        public string ServiceTypeDescription;

        public string Type
        {
            get
            {
                var isNB = !ServiceTypeDescription.Contains(_mTAKey);
                var isAcceptance = ServiceTypeDescription.Contains(_acceptanceKey);
                var isAsync = ServiceTypeDescription.Contains(_asyncKey);
                switch (isNB)
                {
                    case true:
                        switch (isAcceptance)
                        {
                            case true:
                                switch (isAsync)
                                {
                                    case true:
                                        return "NB Acc Async";
                                    default:
                                        return "NB Acc";
                                }
                            default:
                                switch (isAsync)
                                {
                                    case true:
                                        return "NB Async";
                                    default:
                                        return "NB";
                                }
                        }
                    default:
                        switch (isAcceptance)
                        {
                            case true:
                                switch (isAsync)
                                {
                                    case true:
                                        return "MTA Acc Async";
                                    default:
                                        return "MTA Acc";
                                }
                            default:
                                switch (isAsync)
                                {
                                    case true:
                                        return "MTA Async";
                                    default:
                                        return "MTA";
                                }
                        }
                }

            }
        }

        public string EndpointName;
    }

}
