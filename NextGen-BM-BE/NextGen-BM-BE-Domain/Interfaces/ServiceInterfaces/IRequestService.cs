

using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Services{
    public interface IRequestService
    {
        Task CreateRepairRequestAsync(RepairRequest repairRequest);
        Task CreateRequestNoteAsync(RequestNotes requestNotes);
        Task CreateUserBuildingRequestAsync();
        Task DeleteRepairRequestNoteAsync(int requestNoteId);
        Task DeleteRepairRequestAsync(int requestId);
        Task<IList<RepairRequest>> GetAllRepairRequestsByBuildingIdAsync(int buildingId);
        Task<RepairRequest> GetRepairRequestByIdAsync(int requestId);
        Task<IList<RepairRequest>> GetUserBuildingRequestsAsync(int buildingId);
        Task UpdateRepairRequestAsync(RepairRequest repairRequest);
        Task UpdateRequestNoteAsync(RequestNotes requestNote);
        }

}