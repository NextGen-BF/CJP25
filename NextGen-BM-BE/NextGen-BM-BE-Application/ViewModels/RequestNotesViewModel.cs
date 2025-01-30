namespace NextGen_BM_BE_Application.ViewModels{

    public class RequestNotesViewModel{
        public int NoteId { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly CreateDate { get; set; }
        public required string NoteText { get; set; }
    }
}