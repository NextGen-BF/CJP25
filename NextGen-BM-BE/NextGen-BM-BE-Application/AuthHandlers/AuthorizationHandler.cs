using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class BuildingAccessHandler : AuthorizationHandler<BuildingManagerRequirement>
    {
        private readonly HttpContextAccessor _httpContextAccessor;
        public BuildingAccessHandler(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor=httpContextAccessor;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BuildingManagerRequirement requirement)
        {
            var buildingId = _httpContextAccessor.HttpContext?.GetRouteData().Values["buildingId"];

            context.Succeed(requirement);
        }
    }
}