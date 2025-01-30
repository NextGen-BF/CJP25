namespace NextGen_BM_BE_Application.ViewModels{

    public class BuildingExpenseViewModel{
        public int BuildingExpenseId { get; set; }
        public required string Title { get; set; }
        public double TotalAmount { get; set; }
        public required string SupplierName { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly PaymentDate { get; set; }
        public required string Description { get; set; }
        public bool IsTemplate { get; set; }
        public int RepeatPeriod { get; set; }
        public string? InvoiceUrl { get; set; }
    }
}