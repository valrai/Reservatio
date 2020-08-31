using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Reservatio.Models.Attributes
{
    public class RolesRequirementAttribute : TypeFilterAttribute
    {
        public RolesRequirementAttribute(params RoleType[] Roles) : base(typeof(RequestAuthorizationFilter))
        {
            Arguments = new object[] { Roles };
        }
    }

    public class RequestAuthorizationFilter : IAuthorizationFilter
    {
        private readonly RoleType[] _role;

        public RequestAuthorizationFilter(params RoleType[] role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims
                .Any(c => _role.Any(r => r.ToString().Equals(c.Type)) &&
                          bool.TrueString.Equals(c.Value, StringComparison.CurrentCultureIgnoreCase));
            if (!hasClaim)
                context.Result = new ForbidResult();
        }
    }
}
