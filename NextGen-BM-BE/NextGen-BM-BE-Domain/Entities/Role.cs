using Microsoft.AspNetCore.Identity;

namespace NextGen_BM_BE_Domain.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<UserBuildings>? UserBuildings { get; set; }
    }
}
