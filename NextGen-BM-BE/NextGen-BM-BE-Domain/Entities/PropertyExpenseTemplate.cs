namespace NextGen_BM_BE_Domain.Entities{
public class PropertyExpenseTemplate{
    public int PropertyExpenseTemplateId { get; set; }
    public required string ExpenseTitle { get; set; }    
    public bool PerResident { get; set; }
    public int RepeatPeriodId { get; set; }
}
};