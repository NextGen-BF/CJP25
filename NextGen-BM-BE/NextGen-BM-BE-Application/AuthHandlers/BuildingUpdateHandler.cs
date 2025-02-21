using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using System.Text.Json;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class BuildingUpdateHandler : AuthorizationHandler<BuildingManagerRequirement>
    {
        private readonly GetUserBuildingLinkUseCase _getUserBuildingLinkUseCase;
        private readonly UserManager<User> _userManager;
        public BuildingUpdateHandler(GetUserBuildingLinkUseCase getUserBuildingLinkUseCase,
                                    UserManager<User> userManager)
        {
            _getUserBuildingLinkUseCase = getUserBuildingLinkUseCase;
            _userManager=userManager;

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BuildingManagerRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                string body;
                using (StreamReader streamReader=new StreamReader(httpContext.Request.Body))
                    body=await streamReader.ReadToEndAsync();
                
                if (body=="") return;
                var building = JsonSerializer.Deserialize<BuildingViewModel>(body, 
                                                            new JsonSerializerOptions{
                                                                PropertyNameCaseInsensitive = true,
                                                                });
                int buildingId=building.BuildingId, userId;
                if (!int.TryParse(_userManager.GetUserId(context.User), out userId))
                    return;
                var userBuilding = await _getUserBuildingLinkUseCase.Execute(userId, buildingId);
                if (userBuilding?.Role?.Name==requirement.RoleName)
                    context.Succeed(requirement);
                context.Fail();
            }
        }
    }
}