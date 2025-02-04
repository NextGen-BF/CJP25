using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    public class PropertyPayments
    {
        public int PropertyPaymentsId { get; set; }
        [Required]
        public required int PropertyId { get; set; }
        public decimal AmountOwed { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DueDate { get; set; }
        [Required]
        public int PropertyExpenseId { get; set; }
        public int? StatusId { get; set; }
        public Enums? Status { get; set; }
        public int PaymentParentId { get; set; }
        public int? PaymentMethodId { get; set; }
        public Enums? PaymentMethod { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public required Property Property { get; set; }
        public PropertyExpense? PropertyExpense { get; set; }
    }
};
