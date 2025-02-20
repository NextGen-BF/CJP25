using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class BuildingAccessHandler : AuthorizationHandler<BuildingManagerRequirement>
    {
        private readonly GetUserBuildingLinkUseCase _getUserBuildingLinkUseCase;
        private readonly UserManager<User> _userManager;
        public BuildingAccessHandler(GetUserBuildingLinkUseCase getUserBuildingLinkUseCase,
                                    UserManager<User> userManager)
        {
            _getUserBuildingLinkUseCase = getUserBuildingLinkUseCase;
            _userManager=userManager;

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BuildingManagerRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                int buildingId, userId;
                if (!int.TryParse(httpContext?.GetRouteValue("buildingId")?.ToString(), out buildingId)
                    ||!int.TryParse(_userManager.GetUserId(context.User), out userId))
                    return;
                var userBuilding = await _getUserBuildingLinkUseCase.Execute(userId, buildingId);
                if (userBuilding?.Role?.Name=="Super")
                    context.Succeed(requirement);
                context.Fail();
            }
        }
    }
}