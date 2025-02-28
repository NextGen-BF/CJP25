

using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Domain.Services{
    public interface IRequestService
    {
        Task CreateRepairRequestAsync(RepairRequestViewModel repairRequest);
        Task CreateRequestNoteAsync(RequestNotesViewModel requestNotes);
        Task CreateUserBuildingRequestAsync(UserBuildingsViewModel userBuildings);
        Task DeleteRepairRequestNoteAsync(int requestNoteId);
        Task DeleteRepairRequestAsync(int requestId);
        Task<IList<RepairRequestViewModel>> GetAllRepairRequestsByBuildingIdAsync(int buildingId, int? page, int? pageSize);
        Task<RepairRequestViewModel> GetRepairRequestByIdAsync(int requestId);
        Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(int buildingId, int? page, int? pageSize);
        Task UpdateRepairRequestAsync(RepairRequestViewModel repairRequest);
        Task UpdateRequestNoteAsync(RequestNotesViewModel requestNote);
        }

}