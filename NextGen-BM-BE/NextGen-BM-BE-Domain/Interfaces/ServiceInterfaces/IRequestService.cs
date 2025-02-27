using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Domain.Services
{
    public interface IRequestService
    {
        Task<RepairRequestViewModel> CreateRepairRequestAsync(RepairRequestViewModel repairRequest);
        Task<RequestNotesViewModel> CreateRequestNoteAsync(RequestNotesViewModel requestNotes);
        Task SetRequestStatusAsync(int requestId, int statusId, string requestType);
        Task<IList<RequestsGenericViewModel>> GetRequestsByUserIdAsync(int userId);
        Task CreateUserBuildingRequestAsync(UserBuildingsViewModel userBuildings);
        Task DeleteRepairRequestNoteAsync(int requestNoteId);
        Task DeleteRepairRequestAsync(int requestId);
        Task<IList<RepairRequestViewModel>> GetAllRepairRequestsByBuildingIdAsync(IList<int> buildingIds);
        Task<RepairRequestViewModel> GetRepairRequestByIdAsync(int requestId);
        Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(IList<int> buildingIds);
        Task UpdateRepairRequestAsync(RepairRequestViewModel repairRequest);
        Task UpdateRequestNoteAsync(RequestNotesViewModel requestNote);
    }

}