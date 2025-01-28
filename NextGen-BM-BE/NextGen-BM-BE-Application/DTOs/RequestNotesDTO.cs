namespace NextGen_BM_BE_Application.DTOs{

    public class RequestNotesDTO{
        public int NoteId { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly CreateDate { get; set; }
        public string NoteText { get; set; }
    }
}