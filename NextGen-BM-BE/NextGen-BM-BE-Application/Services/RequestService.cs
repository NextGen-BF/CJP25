using AutoMapper;
using NextGen_BM_BE_Application.UseCases.Requests.Create;
using NextGen_BM_BE_Application.UseCases.Requests.Delete;
using NextGen_BM_BE_Application.UseCases.Requests.Get;
using NextGen_BM_BE_Application.UseCases.Requests.Update;
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
    private readonly GetRequestByIdUseCase _getRequestByIdUseCase;
    private readonly UpdateRepairRequestUseCase _updateRepairRequestUseCase;
    private readonly UpdateRequestNoteUseCase _updateRequestNoteUseCase;
    private readonly IMapper _mapper;
    public RequestService(CreateRepairRequestUseCase createRepairRequestUseCase,
                        CreateRequestNotesUseCase createRequestNoteUseCase,
                        CreateUserBuildingRequestUseCase createUserBuildingRequestUseCase,
                        DeleteRepairRequestNoteUseCase deleteRepairRequestNoteUseCase,
                        DeleteRepairRequestUseCase deleteRepairRequestUseCase,
                        GetAllRepairRequestsByBuildingIdUseCase getAllRepairRequestsByBuildingIdUseCase,
                        GetRequestByIdUseCase getRequestByIdUseCase,
                        UpdateRepairRequestUseCase updateRepairRequestUseCase,
                        UpdateRequestNoteUseCase updateRequestNoteUseCase,
                        GetUserBuildingRequests getUserBuildingRequests,
                        IMapper mapper)
    {
        _createRepairRequestUseCase = createRepairRequestUseCase;
        _createRequestNoteUseCase = createRequestNoteUseCase;
        _createUserBuildingRequestUseCase = createUserBuildingRequestUseCase;
        _deleteRepairRequestNoteUseCase = deleteRepairRequestNoteUseCase;
        _deleteRepairRequestUseCase = deleteRepairRequestUseCase;
        _getAllRepairRequestsByBuildingIdUseCase = getAllRepairRequestsByBuildingIdUseCase;
        _getRequestByIdUseCase = getRequestByIdUseCase;
        _updateRepairRequestUseCase = updateRepairRequestUseCase;
        _updateRequestNoteUseCase = updateRequestNoteUseCase;
        _getUserBuildingRequests = getUserBuildingRequests;
        _mapper = mapper;
    }
    public async Task<RepairRequestViewModel> CreateRepairRequestAsync(RepairRequestViewModel repairRequestViewModel)
    {
        var repairRequest = _mapper.Map<RepairRequest>(repairRequestViewModel);
        var createdRequest = await _createRepairRequestUseCase.Execute(repairRequest);
        return _mapper.Map<RepairRequestViewModel>(createdRequest);
    }

    public async Task<RequestsGenericViewModel> GetAllRequestsByUserId()
    {
        //TODO: call get userbuilding requests and repair request by userId
        return null;
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

    public async Task<IList<RepairRequestViewModel>> GetAllRepairRequestsByBuildingIdAsync(int buildingId)
    {
        var buildingRepairRequests = await _getAllRepairRequestsByBuildingIdUseCase.Execute(buildingId);
        return _mapper.Map<IList<RepairRequestViewModel>>(buildingRepairRequests);
    }

    public async Task<RepairRequestViewModel> GetRepairRequestByIdAsync(int requestId)
    {
        var repairRequest = await _getRequestByIdUseCase.Execute(requestId);
        return _mapper.Map<RepairRequestViewModel>(repairRequest);
    }

    public async Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(int buildingId)
    {
        return await _getUserBuildingRequests.Execute(buildingId);
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
}