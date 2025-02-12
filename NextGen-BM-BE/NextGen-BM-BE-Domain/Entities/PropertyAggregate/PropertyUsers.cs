using System.ComponentModel.DataAnnotations;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    public class PropertyUsers
    {
        public int PropertyUsersId { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public decimal PercentOfApartmentOwned { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
        public Property? Property { get; set; }
    }
};
