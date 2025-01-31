namespace NextGen_BM_BE_Domain.ViewModels{

    public class PropertyViewModel{
        public int PropertyId { get; set; }
        public int PropertyNumber { get; set; }
        public int BuildingId { get; set; }
        public double Size { get; set; }
        public int Floor { get; set; }
        public double SizeOfIdealParts { get; set; }
        public bool EntranceIsExternal { get; set; }
        public List<PropertyExpenseViewModel>? PropertyExpenses { get; set; }
        public List<PropertyPaymentsViewModel>? PropertyPayments { get; set; }
        public List<ResidentHistoryViewModel>? ResidentHistory { get; set; }
    }
}