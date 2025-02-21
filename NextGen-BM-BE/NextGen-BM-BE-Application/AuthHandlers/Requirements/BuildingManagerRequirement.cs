using Microsoft.AspNetCore.Authorization;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class BuildingManagerRequirement:IAuthorizationRequirement
    {
        public readonly string RoleName;
        public BuildingManagerRequirement(string role)
        {
            RoleName = role;
        }
    }
}
 