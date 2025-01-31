using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Get
{

    public sealed class GetUserBuildingRequests(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task<UserBuildings> Execute(int buildingId)
        {
            var result = await requestRepository.GetUserBuildingRequestsAsync(buildingId);
            return result;
        }
    }
}