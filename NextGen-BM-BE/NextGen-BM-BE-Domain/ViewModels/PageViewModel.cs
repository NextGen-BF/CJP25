namespace NextGen_BM_BE_Domain.ViewModels
{
    public class PageViewModel<T>
    {
        public required IList<T> Items { get; set; }
        public int PageCount { get; set; }
    }
}
