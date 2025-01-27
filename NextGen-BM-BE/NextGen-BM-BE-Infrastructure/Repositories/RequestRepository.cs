using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class RequestRepository : IRequestRepository
    {
        public async Task CreateRepairRequestAsync(RepairRequest repairRequest)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRepairRequestNotesAsync(RequestNotes requestNotes)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUserBuildingRequestAsync(UserBuildings userBuildings)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRepairRequestAsync(int requestNotes)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRequestNotesAsync(int requestNotesId)
        {
            throw new NotImplementedException();
        }

        public async Task<RepairRequest> GetRepairRequestByIdAsync(int requestId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBuildings> GetUserBuildingRequestsAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRepairRequestAsync(RepairRequest repairRequest)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRequestNotesAsync(RequestNotes requestNotes)
        {
            throw new NotImplementedException();
        }
    }

}