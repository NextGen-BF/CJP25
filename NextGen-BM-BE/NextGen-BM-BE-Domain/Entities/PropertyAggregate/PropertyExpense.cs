using System.ComponentModel.DataAnnotations;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    public class PropertyExpense
    {
        public int PropertyExpenseId { get; set; }

        [Required]
        public int PropertyExpenseTemplateId { get; set; }

        [Required]
        public int RoleId { get; set; }
        public required string ResponsibleRole { get; set; }
        public decimal Price { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public required string Description { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public Role? Role { get; set; }
        public PropertyExpenseTemplate? PropertyExpenseTemplate { get; set; }
    }
};
