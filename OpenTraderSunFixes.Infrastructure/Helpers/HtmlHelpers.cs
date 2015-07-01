using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenTraderSunFixes.Infrastructure.Helpers
{
    public static class HtmlHelpers
    {
        public static IEnumerable<String> ReadErrors(this HtmlHelper htmlHelper,IEnumerable<String> errors)
        {
            foreach(string error in errors)
                yield return error;
        }
    }
}
