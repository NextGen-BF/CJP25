using AutoMapper;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.UseCases.Requests.Get
{

    public sealed class GetAllRequestsByUserIdUseCase(IRequestRepository requestRepository, IMapper mapper)
    {
        private readonly IRequestRepository _requestRepository = requestRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<IList<RequestsGenericViewModel>> Execute(IList<int> buildingIds)
        {

            List<RequestsGenericViewModel> requests = new();
            var repairRequests = await _requestRepository.GetRepairRequestsByBuildingIdAsync(buildingIds);
            var userBuildingRequests = await _requestRepository.GetUserBuildingRequestsAsync(buildingIds);
            var mappedRepairRequests = _mapper.Map<IList<RequestsGenericViewModel>>(repairRequests);
            requests.AddRange(mappedRepairRequests);
            var mappedUserBuildingRequests = _mapper.Map<IList<RequestsGenericViewModel>>(userBuildingRequests);
            requests.AddRange(mappedUserBuildingRequests);
            return requests;
        }
    }
}