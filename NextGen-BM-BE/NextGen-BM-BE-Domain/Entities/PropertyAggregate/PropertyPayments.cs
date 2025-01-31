using System.ComponentModel.DataAnnotations;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    public class PropertyPayments
    {
        public int PropertyPaymentsId { get; set; }
        public int PropertyId { get; set; }
        public decimal AmountOwed { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DueDate { get; set; }
        public int PropertyExpenseId { get; set; }
        public int StatusId { get; set; }
        public int PaymentParentId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public required Property Property { get; set; }
        public required PropertyExpense PropertyExpense { get; set; }
        public required Enum Status { get; set; }
        public required Enum PaymentMethod { get; set; }
    }
};
