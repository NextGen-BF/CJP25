using Microsoft.AspNetCore.Identity;

namespace NextGen_BM_BE_Domain.Entities
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public ICollection<UserBuildings>? UserBuildings { get; set; }
    }
}
