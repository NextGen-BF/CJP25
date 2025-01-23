using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{
public interface IRequestRepository
{
    Task<RepairRequest> GetRepairRequestByID(int requestID);
    Task<List<RepairRequest>> GetRepairRequestsByBuildingID(int buildingID);
    Task<UserBuildings> GetUserBuildingRequests(int buildingID);
    Task CreateRepairRequest(RepairRequest repairRequest);
    Task CreateUserBuildingRequest(UserBuildings userBuildings);
    Task CreateRepairRequestNotes(RequestNotes requestNotes);
    Task UpdateRepairRequest(RepairRequest repairRequest);
    Task UpdateRequestNotes(RequestNotes requestNotes);
    Task DeleteRepairRequest(int requestNotes);
    Task DeleteRequestNotes(int requestNotesID);
}
};
