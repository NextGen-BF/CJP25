namespace NextGen_BM_BE_Application.ViewModels{
    public class RepairRequestViewModel{
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public required string RequestDescription { get; set; }
        public required string Status { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DateSettled { get; set; }
        public List<RequestNotesViewModel>? Notes { get; set; }
    }
}