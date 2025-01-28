namespace NextGen_BM_BE_Application.DTOs{
    public class PropertyPaymentsDTO{
        public int PropertyId { get; set; }
        public double AmountOwed { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DateDue { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
    }
}