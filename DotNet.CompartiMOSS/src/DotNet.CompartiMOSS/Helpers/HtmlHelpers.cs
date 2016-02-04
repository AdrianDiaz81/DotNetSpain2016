
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.CompartiMOSS.Helpers
{
    public static class HtmlHelpers
    {
        public static string HTMLActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues)
        {
            var tagActionLink = htmlHelper.ActionLink("[replace]", actionName, controllerName, routeValues).ToString();
            return tagActionLink.Replace("[replace]", linkText);
        }
    }
}
