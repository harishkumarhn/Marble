using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarbaleManagementStudio
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }

            // Check for authorization
            if (HttpContext.Current.Session["UserID"] == null || string.IsNullOrWhiteSpace(HttpContext.Current.Session["UserID"].ToString()))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Marble" },
                                { "Action", "Login" }
                                });
            }

        }
    }
}
