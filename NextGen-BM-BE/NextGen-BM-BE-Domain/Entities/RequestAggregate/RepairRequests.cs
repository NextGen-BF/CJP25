using System.ComponentModel.DataAnnotations;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Entities.RequestAggregate;

public class RepairRequest
{
    public int RepairRequestId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int BuildingId { get; set; }
    public required string RequestDescription { get; set; }

    [Required]
    public int RequestStatusId { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly? DateSettled { get; set; }
    public DateOnly? DeletedDate { get; set; }
    public Building? Building { get; set; }
    public Enum? RequestStatus { get; set; }
    public User? User { get; set; }
    public ICollection<RequestNotes>? Notes { get; set; }
}
