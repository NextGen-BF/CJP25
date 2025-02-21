using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using System.Text.Json;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class PropertyCreateUpdateHandler : AuthorizationHandler<BuildingManagerRequirement>
    {
        private readonly GetUserBuildingLinkUseCase _getUserBuildingLinkUseCase;
        private readonly UserManager<User> _userManager;
        public PropertyCreateUpdateHandler(GetUserBuildingLinkUseCase getUserBuildingLinkUseCase,
                                    UserManager<User> userManager)
        {
            _getUserBuildingLinkUseCase = getUserBuildingLinkUseCase;
            _userManager=userManager;

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BuildingManagerRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                var property = await JsonSerializer.DeserializeAsync<PropertyViewModel>(httpContext.Request.Body, 
                                                                                        new JsonSerializerOptions{
                                                                                            PropertyNameCaseInsensitive = true
                                                                                            });
                int buildingId=property.BuildingId, userId;
                if (!int.TryParse(_userManager.GetUserId(context.User), out userId))
                    return;
                var userBuilding = await _getUserBuildingLinkUseCase.Execute(userId, buildingId);
                if (userBuilding?.Role?.Name=="Super")
                    context.Succeed(requirement);
                context.Fail();
            }
        }
    }
}