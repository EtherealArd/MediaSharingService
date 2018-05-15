using System.Web.Mvc;
using CloudAspData;

namespace CloudAsp.Helpers
{
    public static class CurrentUser
    {
        public static MvcHtmlString GetUser(this HtmlHelper html, string userLogin)
        {
            var dbUser = new DataCloud().GetClient(userLogin);
            if (dbUser == null)
                return MvcHtmlString.Create(string.Empty);
            return MvcHtmlString.Create(dbUser.FirstName);
        }
    }
}