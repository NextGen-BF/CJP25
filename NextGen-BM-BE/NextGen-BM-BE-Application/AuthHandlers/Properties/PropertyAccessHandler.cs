using Microsoft.AspNetCore.Routing;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class PropertyAccessHandler : AuthorizationHandler<PropertyPermissionRequirement>
    {
        private readonly GetPropertyUserLinkUseCase _getPropertyUserLinkUseCase;
        public PropertyAccessHandler(GetPropertyUserLinkUseCase getPropertyUserLinkUseCase)
        {
            _getPropertyUserLinkUseCase = getPropertyUserLinkUseCase;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PropertyPermissionRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                int propertyId, userId;
                if (!int.TryParse(httpContext?.GetRouteValue("propertyId")?.ToString(), out propertyId)
                    ||!int.TryParse(context.User.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
                    return;
                var propertyUser = await _getPropertyUserLinkUseCase.Execute(propertyId, userId);
                //allow multiple roles
                if (requirement.AllowedRoles.Contains(propertyUser?.Role?.Name))
                    context.Succeed(requirement);
                else context.Fail();
            }
        }
    }
}