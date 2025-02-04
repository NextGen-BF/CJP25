using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate
{
    public class BuildingExpense
    {
        public int BuildingExpenseId { get; set; }

        [Required]
        public int BuildingId { get; set; }
        public required string Title { get; set; }
        public decimal TotalAmount { get; set; }
        public Enums? SupplierId { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly PaymentDate { get; set; }
        public required string Description { get; set; }
        public bool IsTemplate { get; set; }
        public Enums? RepeatPeriodId { get; set; }
        public string? InvoiceUrl { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public Building? Building { get; set; }
    }
};
