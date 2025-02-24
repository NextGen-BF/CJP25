using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using System.Text.Json;
using NextGen_BM_BE_Domain.ViewModels;
using System.Security.Claims;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using Microsoft.AspNetCore.Routing;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class PropertyDeleteHandler : AuthorizationHandler<PropertyPermissionRequirement>
    {
        private readonly GetUserBuildingLinkUseCase _getUserBuildingLinkUseCase;
        private readonly GetPropertiesByIdUseCase _getPropertyByIdUseCase;
        public PropertyDeleteHandler(GetUserBuildingLinkUseCase getUserBuildingLinkUseCase,
                                    GetPropertiesByIdUseCase getPropertyByIdUseCase)
        {
            _getUserBuildingLinkUseCase = getUserBuildingLinkUseCase;
            _getPropertyByIdUseCase=getPropertyByIdUseCase;

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PropertyPermissionRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                int propertyId, userId;
                if (!int.TryParse(httpContext?.GetRouteValue("propertyId")?.ToString(), out propertyId)
                    ||!int.TryParse(context.User.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
                    return;
                    
                var property = await _getPropertyByIdUseCase.Execute(propertyId);
                int buildingId=property.BuildingId;

                var userBuilding = await _getUserBuildingLinkUseCase.Execute(userId, buildingId);
                if (requirement.AllowedRoles.Contains(userBuilding?.Role?.Name))
                    context.Succeed(requirement);
                else context.Fail();
            }
        }
    }
}