using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Task_Management_System.Filters
{
    public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public RoleAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }
        //OnAuthorization is the method through which we can check Authorizations
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Accounts", null);
                return;
            }
            if (_roles.Any() && !_roles.Any(role => user.IsInRole(role)))
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Accounts", null);
            }
        }
    }
}
