namespace NextGen_BM_BE_Application.ViewModels{
    public class PropertyExpenseViewModel{
        public int PropertyExpenseId { get; set; }
        public int PropertyExpenseTemplateId { get; set; }
        public required string ResponsibleRole { get; set; }
        public int Price { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public required string Description { get; set; }
    }
}