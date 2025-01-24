namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate
{
public class BuildingExpense{
    public int BuildingExpenseId { get; set; }
    public int BuildingId { get; set; }
    public string Title { get; set; }
    public double TotalAmount { get; set; }
    public int SupplierId { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly PaymentDate { get; set; }
    public string Description { get; set; }
    public bool IsTemplate { get; set; }
    public int RepeatPeriodId { get; set; }
    public string InvoiceUrl { get; set; }
}
};