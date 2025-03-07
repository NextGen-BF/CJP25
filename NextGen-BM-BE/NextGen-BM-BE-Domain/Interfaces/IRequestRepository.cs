using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IRequestRepository
    {
        Task<RepairRequest> GetRepairRequestByIdAsync(int requestId);
        Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(IList<int> buildingIds, int? page, int? pageSize);
        Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(IList<int> buildingId, int? page, int? pageSize);
        Task<IList<Enums>> GetRequestStatusesAsync();
        Task<RepairRequest> CreateRepairRequestAsync(RepairRequest repairRequest);
        Task CreateUserBuildingRequestAsync(UserBuildings userBuildings);
        Task<RequestNotes> CreateRepairRequestNotesAsync(RequestNotes requestNotes);
        Task CreateRequestFilesAsync(int requestId, IList<string> filePaths, string requestType);
        Task UpdateRepairRequestAsync(RepairRequest repairRequest);
        Task UpdateRequestNotesAsync(RequestNotes requestNotes);
        Task SetRequestStatusAsync(int requestId, int statusId, string requestType);
        Task DeleteRepairRequestAsync(int requestId);
        Task DeleteRequestNotesAsync(int requestNotesId);
    }
};
