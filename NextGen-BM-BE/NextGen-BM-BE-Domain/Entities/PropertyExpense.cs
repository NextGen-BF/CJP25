namespace NextGen_BM_BE_Domain.Entities{
public class PropertyExpense{
    public int PropertyExpenseID { get; set; }
    public int PropertyExpenseTemplateID { get; set; }
    public int ResponsibleRoleID { get; set; }
    public double Price { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Description { get; set; }
}
};