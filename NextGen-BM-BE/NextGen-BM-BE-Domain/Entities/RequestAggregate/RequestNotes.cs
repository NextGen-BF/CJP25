namespace NextGen_BM_BE_Domain.Entities.RequestAggregate;

public class RequestNotes
{
    public int NoteId { get; set; }
    public int RequestId { get; set; }
    public required string NoteText { get; set; }
    public DateOnly CreateDate { get; set; }
    public int CreatedBy { get; set; }
}
