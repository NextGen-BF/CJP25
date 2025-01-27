using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Get
{

    public sealed class GetRequestByIdUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task<RepairRequest> Execute(int buildingId)
        {
            var result = await requestRepository.GetRepairRequestByIdAsync(buildingId);
            return result;
        }
    }
}