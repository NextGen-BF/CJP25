using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IRequestRepository
    {
        Task<RepairRequest> GetRepairRequestByIdAsync(int requestID);
        Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(int buildingID, int? page, int? pageSize);
        Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(int buildingID, int? page, int? pageSize);
        Task CreateRepairRequestAsync(RepairRequest repairRequest);
        Task CreateUserBuildingRequestAsync(UserBuildings userBuildings);
        Task CreateRepairRequestNotesAsync(RequestNotes requestNotes);
        Task UpdateRepairRequestAsync(RepairRequest repairRequest);
        Task UpdateRequestNotesAsync(RequestNotes requestNotes);
        Task DeleteRepairRequestAsync(int requestId);
        Task DeleteRequestNotesAsync(int requestNotesID);
    }
};
