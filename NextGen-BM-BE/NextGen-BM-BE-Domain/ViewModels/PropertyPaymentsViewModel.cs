namespace NextGen_BM_BE_Domain.ViewModels
{
    public class PropertyPaymentsViewModel
    {
        public int PropertyId { get; set; }
        public decimal AmountOwed { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DueDate { get; set; }
        public string? Status { get; set; }
        public string? PaymentMethod { get; set; }
        public int? PaymentParentId { get; set; }
    }
}
