using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NextGen_BM_BE_Infrastructure.DataStructures{
    public class PagedList<T>:List<T>
    {
        private int _page;
        private int _pageSize;
        public int TotalPages { 
                get => Count/PageSize; 
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
            var items= await query.Skip((Page-1)*PageSize)
                .Take(PageSize)
                .ToListAsync();
            AddRange(items);
        }
    }
}