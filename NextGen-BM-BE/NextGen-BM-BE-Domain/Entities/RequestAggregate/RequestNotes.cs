namespace NextGen_BM_BE_Domain.Entities.RequestAggregate;

public class RequestNotes
{
    public int RequestNotesId { get; set; }
    public int RepairRequestId { get; set; }
    public required string NoteText { get; set; }
    public int RequestId { get; set; } = 0;
    public DateOnly CreateDate { get; set; }
    public DateOnly? DeletedDate { get; set; }
    public int CreatedBy { get; set; }
    public User? User { get; set; }
    public RepairRequest? RepairRequest { get; set; }
}
