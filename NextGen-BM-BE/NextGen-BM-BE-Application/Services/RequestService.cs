using AutoMapper;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using NextGen_BM_BE_Application.UseCases.Requests.Create;
using NextGen_BM_BE_Application.UseCases.Requests.Delete;
using NextGen_BM_BE_Application.UseCases.Requests.Get;
using NextGen_BM_BE_Application.UseCases.Requests.Update;
using NextGen_BM_BE_Domain.DataStructures;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Services;
using NextGen_BM_BE_Domain.ViewModels;

public class RequestService : IRequestService
{
    private readonly CreateRepairRequestUseCase _createRepairRequestUseCase;
    private readonly CreateRequestNotesUseCase _createRequestNoteUseCase;
    private readonly CreateUserBuildingRequestUseCase _createUserBuildingRequestUseCase;
    private readonly DeleteRepairRequestNoteUseCase _deleteRepairRequestNoteUseCase;
    private readonly DeleteRepairRequestUseCase _deleteRepairRequestUseCase;
    private readonly GetAllRepairRequestsByBuildingIdUseCase _getAllRepairRequestsByBuildingIdUseCase;
    private readonly GetUserBuildingRequests _getUserBuildingRequests;
    private readonly GetAllRequestsByUserIdUseCase _getAllRequestsByUserIdUserCase;
    private readonly GetBuildingsByUserIdUseCase _getBuildingsByUserIdUseCase;
    private readonly GetRequestByIdUseCase _getRequestByIdUseCase;
    private readonly GetRequestStatuesUseCase _getRequestStatusesUseCase;
    private readonly UpdateRepairRequestUseCase _updateRepairRequestUseCase;
    private readonly UpdateRequestNoteUseCase _updateRequestNoteUseCase;
    private readonly SetRequestStatusUseCase _setRequestStatusUseCase;
    private readonly IMapper _mapper;
    public RequestService(CreateRepairRequestUseCase createRepairRequestUseCase,
                        CreateRequestNotesUseCase createRequestNoteUseCase,
                        CreateUserBuildingRequestUseCase createUserBuildingRequestUseCase,
                        DeleteRepairRequestNoteUseCase deleteRepairRequestNoteUseCase,
                        DeleteRepairRequestUseCase deleteRepairRequestUseCase,
                        GetAllRepairRequestsByBuildingIdUseCase getAllRepairRequestsByBuildingIdUseCase,
                        GetRequestByIdUseCase getRequestByIdUseCase,
                        GetUserBuildingRequests getUserBuildingRequests,
                        GetAllRequestsByUserIdUseCase getAllRequestsByUserIdUseCase,
                        GetBuildingsByUserIdUseCase getBuildingsByUserIdUseCase,
                        UpdateRepairRequestUseCase updateRepairRequestUseCase,
                        UpdateRequestNoteUseCase updateRequestNoteUseCase,
                        SetRequestStatusUseCase setRequestStatusUseCase,
                        GetRequestStatuesUseCase getRequestStatuesUseCase,
                        IMapper mapper)
    {
        _createRepairRequestUseCase = createRepairRequestUseCase;
        _createRequestNoteUseCase = createRequestNoteUseCase;
        _createUserBuildingRequestUseCase = createUserBuildingRequestUseCase;
        _deleteRepairRequestNoteUseCase = deleteRepairRequestNoteUseCase;
        _deleteRepairRequestUseCase = deleteRepairRequestUseCase;
        _getAllRepairRequestsByBuildingIdUseCase = getAllRepairRequestsByBuildingIdUseCase;
        _getRequestByIdUseCase = getRequestByIdUseCase;
        _getAllRequestsByUserIdUserCase = getAllRequestsByUserIdUseCase;
        _getUserBuildingRequests = getUserBuildingRequests;
        _getBuildingsByUserIdUseCase = getBuildingsByUserIdUseCase;
        _updateRepairRequestUseCase = updateRepairRequestUseCase;
        _updateRequestNoteUseCase = updateRequestNoteUseCase;
        _setRequestStatusUseCase = setRequestStatusUseCase;
        _getRequestStatusesUseCase = getRequestStatuesUseCase;
        _mapper = mapper;
    }
    public async Task<RepairRequestViewModel> CreateRepairRequestAsync(RepairRequestViewModel repairRequestViewModel)
    {
        var repairRequest = _mapper.Map<RepairRequest>(repairRequestViewModel);
        var createdRequest = await _createRepairRequestUseCase.Execute(repairRequest);
        return _mapper.Map<RepairRequestViewModel>(createdRequest);
    }

    public async Task<IList<RequestsGenericViewModel>> GetRequestsByUserIdAsync(int userId, int? page, int? pageSize)
    {
        var buildings = await _getBuildingsByUserIdUseCase.Execute(userId, page, pageSize);
        var buildingIds = new List<int>();
        foreach (var building in buildings)
        {
            buildingIds.Add(building.BuildingId);
        }
        return await _getAllRequestsByUserIdUserCase.Execute(buildingIds, page, pageSize);
    }

    public async Task<RequestNotesViewModel> CreateRequestNoteAsync(RequestNotesViewModel requestNotesViewModel)
    {
        var requestNotes = _mapper.Map<RequestNotes>(requestNotesViewModel);
        var createdNote = await _createRequestNoteUseCase.Execute(requestNotes);
        return _mapper.Map<RequestNotesViewModel>(createdNote);
    }

    public async Task CreateUserBuildingRequestAsync(UserBuildingsViewModel userBuildings)
    {
        var userBuildingRequest = _mapper.Map<UserBuildings>(userBuildings);
        await _createUserBuildingRequestUseCase.Execute(userBuildingRequest);
    }

    public async Task DeleteRepairRequestAsync(int requestId)
    {
        await _deleteRepairRequestUseCase.Execute(requestId);
    }

    public async Task DeleteRepairRequestNoteAsync(int requestNoteId)
    {
        await _deleteRepairRequestNoteUseCase.Execute(requestNoteId);
    }

    public async Task<IList<RepairRequestViewModel>> GetAllRepairRequestsByBuildingIdAsync(IList<int> buildingIds, int? page, int? pageSize)
    {
        var buildingRepairRequests = await _getAllRepairRequestsByBuildingIdUseCase.Execute(buildingIds, page, pageSize);
        
        if (page!=null&&pageSize!=null)
        {
            var requestsList=new PagedList<RepairRequestViewModel>{Page=(int)page,
                                                                PageSize=(int)pageSize,
                                                                TotalCount=((PagedList<RequestsGenericViewModel>)buildingRepairRequests).TotalCount};
            requestsList.AddRange(_mapper.Map<PagedList<RepairRequestViewModel>>(buildingRepairRequests));
            return requestsList;
        }
        return _mapper.Map<IList<RepairRequestViewModel>>(buildingRepairRequests);
    }

    public async Task<RepairRequestViewModel> GetRepairRequestByIdAsync(int requestId)
    {
        var repairRequest = await _getRequestByIdUseCase.Execute(requestId);
        return _mapper.Map<RepairRequestViewModel>(repairRequest);
    }

    public async Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(IList<int> buildingIds, int? page, int? pageSize)
    {
        var userBuildingRequests = await _getUserBuildingRequests.Execute(buildingIds, page, pageSize);
        
        if (page!=null&&pageSize!=null)
        {
            var requestsList=new PagedList<UserBuildings>{Page=(int)page,
                                                                PageSize=(int)pageSize,
                                                                TotalCount=((PagedList<UserBuildings>)userBuildingRequests).TotalCount};
            requestsList.AddRange(_mapper.Map<PagedList<UserBuildings>>(userBuildingRequests));
            return requestsList;
        }
        return _mapper.Map<IList<UserBuildings>>(userBuildingRequests);
    }

    public async Task UpdateRepairRequestAsync(RepairRequestViewModel repairRequestViewModel)
    {
        var repairRequest = _mapper.Map<RepairRequest>(repairRequestViewModel);
        await _updateRepairRequestUseCase.Execute(repairRequest);
    }

    public async Task UpdateRequestNoteAsync(RequestNotesViewModel requestNotesViewModel)
    {
        var requestNote = _mapper.Map<RequestNotes>(requestNotesViewModel);
        await _updateRequestNoteUseCase.Execute(requestNote);
    }

    public async Task SetRequestStatusAsync(int requestId, int statusId, string requestType)
    {
        await _setRequestStatusUseCase.Execute(requestId, statusId, requestType);
    }

    public async Task<IList<RequestStatusViewModel>> GetRequestStatusesAsync()
    {
        var statuses = await _getRequestStatusesUseCase.Execute();
        return _mapper.Map<IList<RequestStatusViewModel>>(statuses);
    }
}