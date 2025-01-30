namespace NextGen_BM_BE_Application.ViewModels{
    public class PropertyPaymentsViewModel{
        public int PropertyId { get; set; }
        public double AmountOwed { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DateDue { get; set; }
        public required string Status { get; set; }
        public required string PaymentMethod { get; set; }
    }
}