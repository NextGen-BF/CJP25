using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Get
{

    public sealed class GetAllRepairRequestsByBuildingIdUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task<IList<RepairRequest>> Execute(int buildingId)
        {
            var result = await requestRepository.GetRepairRequestsByBuildingIdAsync(buildingId);
            return result;
        }
    }
}