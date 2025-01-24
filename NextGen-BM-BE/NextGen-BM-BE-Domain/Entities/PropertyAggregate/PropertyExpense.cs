namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate{
public class PropertyExpense{
    public int PropertyExpenseId { get; set; }
    public int PropertyExpenseTemplateId { get; set; }
    public int ResponsibleRoleId { get; set; }
    public double Price { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Description { get; set; }
}
};