using System.Threading.Tasks;

namespace NextGen_BM_BE_Domain.DataStructures{
    public class PagedList<T>:List<T>
    {
        private int _page;
        private int _pageSize;
        public int TotalCount{ get; set; }
        public int TotalPages { 
                get => TotalCount/PageSize;
            }
        public int Page {
                get => _page;
                set { _page = value; }
            }
        public int PageSize {
            get => _pageSize;
            set { _pageSize = value; }
        }
        public async Task Paginate(IQueryable<T> query)
        {
            var items= query.Skip((Page-1)*PageSize)
                .Take(PageSize)
                .ToList();
            TotalCount = query.Count();
            AddRange(items);
        }
    }
}