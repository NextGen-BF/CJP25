using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Application.UseCases.Requests.Create
{

    public sealed class CreateRepairRequestUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task Execute(RepairRequest repairRequest)
        {
            await requestRepository.CreateRepairRequestAsync(repairRequest);
        }
    }
}