using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{
public interface IRequestRepository
{
    Task<RepairRequest> GetRepairRequestByIdAsync(int requestID);
    Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(int buildingID);
    Task<UserBuildings> GetUserBuildingRequestsAsync(int buildingID);
    Task CreateRepairRequestAsync(RepairRequest repairRequest);
    Task CreateUserBuildingRequestAsync(UserBuildings userBuildings);
    Task CreateRepairRequestNotesAsync(RequestNotes requestNotes);
    Task UpdateRepairRequestAsync(RepairRequest repairRequest);
    Task UpdateRequestNotesAsync(RequestNotes requestNotes);
    Task DeleteRepairRequestAsync(int requestNotes);
    Task DeleteRequestNotesAsync(int requestNotesID);
}
};
