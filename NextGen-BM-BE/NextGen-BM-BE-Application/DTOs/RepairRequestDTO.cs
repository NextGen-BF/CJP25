namespace NextGen_BM_BE_Application.DTOs{
    public class RepairRequestDTO{
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string RequestDescription { get; set; }
        public string Status { get; set; }
        public DateOnly DateOpened { get; set; }
        public DateOnly DateSettled { get; set; }
        public List<RequestNotesDTO>? Notes { get; set; }
    }
}