namespace NextGen_BM_BE_Application.DTOs{
    public class ResidentHistoryDTO{
        public int PropertyResidentsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ResidentType { get; set; }
        public DateOnly EnterDate { get; set; }
        public DateOnly LeaveDate { get; set; }
    }
}