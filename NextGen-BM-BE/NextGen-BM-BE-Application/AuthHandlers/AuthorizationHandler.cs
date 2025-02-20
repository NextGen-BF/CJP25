using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using NextGen_BM_BE_Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

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
                var buildingId = httpContext?.GetRouteValue("buildingId")?.ToString();
                var userId= _userManager.GetUserId(context.User);
                var userBuilding = await _getUserBuildingLinkUseCase.Execute(int.Parse(userId), int.Parse(buildingId));
                if (userBuilding.Role?.Name=="Super")
                    context.Succeed(requirement);
                context.Fail();
            }
        }
    }
}