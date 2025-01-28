namespace NextGen_BM_BE_Application.DTOs{
    public class PropertyExpenseDTO{
        public int PropertyExpenseId { get; set; }
        public int PropertyExpenseTemplateId { get; set; }
        public string ResponsibleRole { get; set; }
        public int Price { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Description { get; set; }
    }
}