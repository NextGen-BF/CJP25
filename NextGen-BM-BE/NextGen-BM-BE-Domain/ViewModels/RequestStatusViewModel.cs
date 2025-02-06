namespace NextGen_BM_BE_Domain.ViewModels
{
    public class RequestStatusViewModel
    {
        public int StatusId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}