using System.ComponentModel.DataAnnotations.Schema;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Entities
{
    public class Enums
    {
        public int EnumsId { get; set; }
        public required string Description { get; set; }
        public required string Title { get; set; }
        public required string Type { get; set; }
        public int Value { get; set; }
        public DateOnly? DeletedDate { get; set; }

        [InverseProperty("SupplierId")]
        public ICollection<BuildingExpense>? Supplier { get; set; }

        [InverseProperty("RepeatPeriodId")]
        public ICollection<BuildingExpense>? RepeatPeriod { get; set; }
        public ICollection<RepairRequest>? RepairRequests { get; set; }
    }
};
