using System.ComponentModel.DataAnnotations.Schema;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    [Table("PropertyExpense")]
    public class PropertyExpense
    {
        public int PropertyExpenseId { get; set; }
        public int PropertyExpenseTemplateId { get; set; }
        public int RoleId { get; set; }
        public decimal Price { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Description { get; set; }
    }
};
