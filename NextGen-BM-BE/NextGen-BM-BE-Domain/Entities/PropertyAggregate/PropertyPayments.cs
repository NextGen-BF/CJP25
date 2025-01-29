using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate{
public class PropertyPayments{
    [Key]
    public int PaymentId { get; set; }
    public int PropertyId { get; set; }
    public decimal AmountOwed { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly DueDate { get; set; }
    public int PropertyExpenseId { get; set; }
    public int StatusId { get; set; }
    public int PaymentParentId { get; set; }
    public int PaymentMethod { get; set; }
}
};