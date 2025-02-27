using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IRequestRepository
    {
        Task<RepairRequest> GetRepairRequestByIdAsync(int requestID);
        Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(int buildingID);
        Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(int buildingID);
        Task<RepairRequest> CreateRepairRequestAsync(RepairRequest repairRequest);
        Task CreateUserBuildingRequestAsync(UserBuildings userBuildings);
        Task<RequestNotes> CreateRepairRequestNotesAsync(RequestNotes requestNotes);
        Task UpdateRepairRequestAsync(RepairRequest repairRequest);
        Task UpdateRequestNotesAsync(RequestNotes requestNotes);
        Task DeleteRepairRequestAsync(int requestId);
        Task DeleteRequestNotesAsync(int requestNotesID);
    }
};
