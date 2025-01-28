
namespace NextGen_BM_BE_Application.DTOs{

    public class PropertyDTO{
        public int PropertyId { get; set; }
        public int PropertyNumber { get; set; }
        public int BuildingId { get; set; }
        public double Size { get; set; }
        public int Floor { get; set; }
        public double SizeOfIdealParts { get; set; }
        public bool EntranceIsExternal { get; set; }
        public List<PropertyExpenseDTO>? PropertyExpenses { get; set; }
        public List<PropertyPaymentsDTO>? PropertyPayments { get; set; }
        public List<ResidentHistoryDTO>? ResidentHistory { get; set; }
    }
}