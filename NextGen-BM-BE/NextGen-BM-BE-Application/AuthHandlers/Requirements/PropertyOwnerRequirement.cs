using Microsoft.AspNetCore.Authorization;
using NextGen_BM_BE_Domain.Entities;

namespace NextGen_BM_BE_Application.AuthHandlers{
    public class PropertyOwnerRequirement:IAuthorizationRequirement
    {
        public readonly string[] AllowedRoles;
        public PropertyOwnerRequirement(params string[] roles)
        {
            AllowedRoles = roles;
        }
    }
}