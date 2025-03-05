using NextGen_BM_BE_Domain.DataStructures;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces{
    public interface IPaginationService{
        PagedList<TViewModel> MapPagedResult<TViewModel, TEntity>(PagedList<TEntity> queryResult);
    }
}