

using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Services{
    public interface IRequestService
    {
        Task CreateRepairRequestAsync();
        Task CreateRequestNoteAsync();
        Task CreateUserBuildingRequestAsync();
        Task DeleteRepairRequestNoteAsync(int requestNoteId);
        Task DeleteRepairRequestAsync(int requestId);
        Task<IList<RepairRequest>> GetAllRepairRequestsByBuildingIdAsync(int buildingId);
        Task<IList<RepairRequest>> GetRepairRequestByIdAsync(int requestId);
        Task<IList<RepairRequest>> GetUserBuildingRequestsAsync(int buildingId);
        Task UpdateRepairRequestAsync(RepairRequest repairRequest);
    }

}