namespace NextGen_BM_BE_Application.DTOs{

    public class BuildingExpenseDTO{
        public int BuildingExpenseId { get; set; }
        public string Title { get; set; }
        public double TotalAmount { get; set; }
        public string SupplierName { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly PaymentDate { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public int RepeatPeriod { get; set; }
        public string? InvoiceUrl { get; set; }
    }
}