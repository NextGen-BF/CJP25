using System.ComponentModel.DataAnnotations;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    public class Property
    {
        public int PropertyId { get; set; }
        public int PropertyNumber { get; set; }

        [Required]
        public int BuildingId { get; set; }
        public double Size { get; set; }
        public int Floor { get; set; }
        public double SizeOfIdealParts { get; set; }
        public int PropertyTypeId { get; set; }
        public bool EntranceIsExternal { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public Building? Building { get; set; }
        public ICollection<PropertyUsers>? Users { get; set; }
        public ICollection<PropertyPayments>? Payments { get; set; }
        public ICollection<PropertyResidents>? PropertyResidents { get; set; }
    }
};
