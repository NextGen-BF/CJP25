using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Application.UseCases.Requests.Update
{

    public sealed class SetRequestStatusUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task Execute(int requestId, int statusId, string requestType)
        {
            
        }
    }
}