using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using System.Text.Json;
using NextGen_BM_BE_Domain.ViewModels;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class RequestCreateUpdateHandler : AuthorizationHandler<BuildingResidentRequirement>
    {
        private readonly GetUserBuildingLinkUseCase _getUserBuildingLinkUseCase;
        public RequestCreateUpdateHandler(GetUserBuildingLinkUseCase getUserBuildingLinkUseCase)
        {
            _getUserBuildingLinkUseCase = getUserBuildingLinkUseCase;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BuildingResidentRequirement requirement)
        {
            if (context.Resource is HttpContext httpContext)
            {
                string body;
                httpContext.Request.EnableBuffering();
                using (StreamReader streamReader=new StreamReader(httpContext.Request.Body, leaveOpen:true))
                    body=await streamReader.ReadToEndAsync();
                httpContext.Request.Body.Position=0;
                if (body=="") return;

                var request = JsonSerializer.Deserialize<RepairRequestViewModel>(body, 
                                                                                new JsonSerializerOptions{
                                                                                    PropertyNameCaseInsensitive = true,
                                                                                    NumberHandling=JsonNumberHandling.AllowReadingFromString
                                                                                    });
                int buildingId=request.BuildingId, userId;
                if (!int.TryParse(context.User.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
                    return;
                var userBuilding = await _getUserBuildingLinkUseCase.Execute(userId, buildingId);
                //should allow any approved user in building
                if (userBuilding!=null)
                    context.Succeed(requirement);
                else context.Fail();
            }
        }
    }
}