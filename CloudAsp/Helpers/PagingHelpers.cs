using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CloudAsp.Models;

namespace CloudAsp.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, string actionName, Func<int, object> pageParam, AjaxHelper ajaxHelper, AjaxOptions ajaxOptions)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                if (i == pageInfo.PageNumber)
                    result.Append(ajaxHelper.ActionLink(i.ToString(), actionName, pageParam(i),
                        ajaxOptions, new { @class = "btn btn-primary" }));
                else
                    result.Append(ajaxHelper.ActionLink(i.ToString(), actionName, pageParam(i),
                        ajaxOptions, new { @class = "btn btn-default" }));
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}