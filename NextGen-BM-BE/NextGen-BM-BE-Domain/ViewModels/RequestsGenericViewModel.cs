namespace NextGen_BM_BE_Domain.ViewModels
{
    public class RequestsGenericViewModel
    {
        public int RequestId { get; set; }
        public required string RequestTitle { get; set; }
        public required string RequestType { get; set; }
        public int BuildingId { get; set; }
        public required string BuildingAlias { get; set; }
        public int CreatedBy { get; set; }
        public string? UserFullName { get; set; }
        public string? RequestDescription { get; set; }
        public required string Status { get; set; }
        public string? RequestedRole { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateOnly? DateSettled { get; set; }
        public IList<RequestNotesViewModel>? Notes { get; set; }
    }
}