using AutoMapper;
using NextGen_BM_BE_Domain.DataStructures;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_Application.Services{
    public class PaginationService: IPaginationService{

        private readonly IMapper _mapper;

        public PaginationService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public PagedList<TViewModel> MapPagedResult<TViewModel, TEntity>(PagedList<TEntity> entities)
        {
            var list=new PagedList<TViewModel>{Page=entities.Page,
                                                PageSize=entities.PageSize,
                                                TotalCount=entities.TotalCount};
                list.AddRange(_mapper.Map<PagedList<TViewModel>>(entities));
            return list;
        }
    }
}