using System.ComponentModel.DataAnnotations;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Entities.RequestAggregate;

public class RepairRequest
{
    public int RepairRequestId { get; set; }
    public required string RequestTitle { get; set; }
    public required int BuildingId { get; set; }
    public required string RequestDescription { get; set; }
    public int RequestStatusId { get; set; }
    public int UserId { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly? DateSettled { get; set; }
    public DateOnly? DeletedDate { get; set; }
    public Building? Building { get; set; }
    public Enums? RequestStatus { get; set; }
    public User? User { get; set; }
    public List<RequestFiles>? Files { get; set; }
    public ICollection<RequestNotes>? Notes { get; set; }
}
