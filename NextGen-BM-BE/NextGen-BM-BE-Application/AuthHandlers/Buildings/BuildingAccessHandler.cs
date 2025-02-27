using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using System.Security.Claims;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class BuildingAccessHandler : AuthorizationHandler<BuildingManagerRequirement>
    {
        private readonly GetUserBuildingLinkUseCase _getUserBuildingLinkUseCase;
        public BuildingAccessHandler(GetUserBuildingLinkUseCase getUserBuildingLinkUseCase)
        {
            _getUserBuildingLinkUseCase = getUserBuildingLinkUseCase;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BuildingManagerRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                int buildingId, userId;
                if (!int.TryParse(httpContext?.GetRouteValue("buildingId")?.ToString(), out buildingId)
                    ||!int.TryParse(context.User.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
                    return;
                var userBuilding = await _getUserBuildingLinkUseCase.Execute(userId, buildingId);
                //only allow building supers(managers)
                if (userBuilding?.Role?.Name==requirement.RoleName)
                    context.Succeed(requirement);
                else context.Fail();
            }
        }
    }
}