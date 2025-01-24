namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate
{
public class BuildingExpense{
    public int BuildingExpenseID { get; set; }
    public int BuildingID { get; set; }
    public string Title { get; set; }
    public double TotalAmount { get; set; }
    public int SupplierID { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly PaymentDate { get; set; }
    public string Description { get; set; }
    public bool isTemplate { get; set; }
    public int RepeatPeriodID { get; set; }
    public string InvoiceURL { get; set; }
}
};