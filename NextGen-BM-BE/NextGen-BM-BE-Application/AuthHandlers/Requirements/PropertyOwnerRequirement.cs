using Microsoft.AspNetCore.Authorization;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class PropertyPermissionRequirement:IAuthorizationRequirement
    {
        public readonly string[] AllowedRoles;
        public PropertyPermissionRequirement(params string[] roles)
        {
            AllowedRoles = roles;
        }
    }
}