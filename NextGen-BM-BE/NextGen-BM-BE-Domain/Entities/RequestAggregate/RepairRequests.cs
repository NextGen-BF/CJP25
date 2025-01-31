using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Entities.RequestAggregate;

public class RepairRequest
{
    public int RepairRequestId { get; set; }
    public int UserId { get; set; }
    public int BuildingId { get; set; }
    public required string RequestDescription { get; set; }
    public int RequestStatusId { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly? DateSettled { get; set; }
    public DateOnly? DeletedDate { get; set; }
    public required Building Building { get; set; }
    public required Enum RequestStatus { get; set; }
    public ICollection<RequestNotes>? Notes { get; set; }
}
