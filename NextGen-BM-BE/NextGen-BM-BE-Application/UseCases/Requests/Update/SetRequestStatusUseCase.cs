using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Update
{

    public sealed class SetRequestStatusUseCase(IRequestRepository requestRepository)
    {
        private readonly IRequestRepository _requestRepository = requestRepository;
        public async Task Execute(int requestId, int statusId, string requestType)
        {
            await _requestRepository.SetRequestStatusAsync(requestId, statusId, requestType);
        }
    }
}