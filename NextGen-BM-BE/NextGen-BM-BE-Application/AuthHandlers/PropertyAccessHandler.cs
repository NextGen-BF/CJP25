using Microsoft.AspNetCore.Routing;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using Microsoft.AspNetCore.Http;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class PropertyAccessHandler : AuthorizationHandler<PropertyPermissionRequirement>
    {
        private readonly GetPropertyUserLinkUseCase _getPropertyUserLinkUseCase;
        private readonly UserManager<User> _userManager;
        public PropertyAccessHandler(GetPropertyUserLinkUseCase getPropertyUserLinkUseCase,
                                    UserManager<User> userManager)
        {
            _getPropertyUserLinkUseCase = getPropertyUserLinkUseCase;
            _userManager=userManager;

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PropertyPermissionRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                int propertyId, userId;
                if (!int.TryParse(httpContext?.GetRouteValue("propertyId")?.ToString(), out propertyId)
                    ||!int.TryParse(_userManager.GetUserId(context.User), out userId))
                    return;
                var propertyUser = await _getPropertyUserLinkUseCase.Execute(userId, propertyId);
                if (requirement.AllowedRoles.Contains(propertyUser?.Role?.Name))
                    context.Succeed(requirement);
                context.Fail();
            }
        }
    }
}