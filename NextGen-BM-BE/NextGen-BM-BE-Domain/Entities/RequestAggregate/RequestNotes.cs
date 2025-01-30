namespace NextGen_BM_BE_Domain.Entities.RequestAggregate;

public class RequestNotes
{
    public int RequestNotesId { get; set; }
    public int RequestId { get; set; }
    public required string NoteText { get; set; }
    public DateOnly CreateDate { get; set; }
    public int CreatedBy { get; set; }
    public DateOnly DeletedDate { get; set; }
}
