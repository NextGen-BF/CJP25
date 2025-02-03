using System.ComponentModel.DataAnnotations;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    public class PropertyResidents
    {
        public int PropertyResidentsId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int ResidentTypeId { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public DateOnly EnterDate { get; set; }
        public DateOnly? LeaveDate { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public Property? Property { get; set; }
    }
};
