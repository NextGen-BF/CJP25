namespace NextGen_BM_BE_Domain;

public class RequestNotes{
    public int NoteID { get; set; }
    public int RequestId { get; set; }
    public string NoteText { get; set; }
    public DateOnly Date { get; set; }
    public int CreatedBy { get; set; }
}