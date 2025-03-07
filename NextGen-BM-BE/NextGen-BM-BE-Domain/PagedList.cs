using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NextGen_BM_BE_Domain.DataStructures{
    public class PagedList<T>:List<T>
    {
        private int _page;
        private int _pageSize;
        public int TotalCount{ get; set; }
        public int TotalPages { 
                get => (int)Math.Ceiling((double)TotalCount/PageSize);
            }
        public int Page {
                get => _page;
                set { _page = value<1 ? 1 : value; }
            }
        public int PageSize {
            get => _pageSize;
            set { _pageSize = value<1 ? 1 : value; }
        }
        public async Task Paginate(IQueryable<T> query)
        {
            var items = await query.Skip((Page-1)*PageSize)
                .Take(PageSize)
                .ToListAsync();
            TotalCount = query.Count();
            AddRange(items);
        }
    }
}