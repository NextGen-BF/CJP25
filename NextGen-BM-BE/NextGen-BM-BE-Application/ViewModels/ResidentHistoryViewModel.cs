namespace NextGen_BM_BE_Application.ViewModels{
    public class ResidentHistoryViewModel{
        public int PropertyResidentsId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int ResidentType { get; set; }
        public DateOnly EnterDate { get; set; }
        public DateOnly LeaveDate { get; set; }
    }
}