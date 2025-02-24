using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using System.Text.Json;
using NextGen_BM_BE_Domain.ViewModels;
using System.Security.Claims;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class BuildingUpdateHandler : AuthorizationHandler<BuildingManagerRequirement>
    {
        private readonly GetUserBuildingLinkUseCase _getUserBuildingLinkUseCase;
        public BuildingUpdateHandler(GetUserBuildingLinkUseCase getUserBuildingLinkUseCase)
        {
            _getUserBuildingLinkUseCase = getUserBuildingLinkUseCase;

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
                if (!int.TryParse(context.User.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
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