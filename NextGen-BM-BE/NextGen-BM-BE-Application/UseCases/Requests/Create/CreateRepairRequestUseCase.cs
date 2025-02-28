using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Create
{

    public sealed class CreateRepairRequestUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task<RepairRequest> Execute(RepairRequest repairRequest)
        {
            return await requestRepository.CreateRepairRequestAsync(repairRequest);
        }
    }
}