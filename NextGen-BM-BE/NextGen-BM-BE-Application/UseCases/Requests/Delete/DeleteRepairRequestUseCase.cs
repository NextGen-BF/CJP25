using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Delete
{

    public sealed class DeleteRepairRequestUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;

        public async Task Execute(int requestId)
        {
            await requestRepository.DeleteRepairRequestAsync(requestId);
        }
    }
}