using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class RequestRepository : IRequestRepository
    {
        public Task CreateRepairRequest(RepairRequest repairRequest)
        {
            throw new NotImplementedException();
        }

        public Task CreateRepairRequestNotes(RequestNotes requestNotes)
        {
            throw new NotImplementedException();
        }

        public Task CreateUserBuildingRequest(UserBuildings userBuildings)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRepairRequest(int requestNotes)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRequestNotes(int requestNotesID)
        {
            throw new NotImplementedException();
        }

        public Task<RepairRequest> GetRepairRequestByID(int requestID)
        {
            throw new NotImplementedException();
        }

        public Task<List<RepairRequest>> GetRepairRequestsByBuildingID(int buildingID)
        {
            throw new NotImplementedException();
        }

        public Task<UserBuildings> GetUserBuildingRequests(int buildingID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRepairRequest(RepairRequest repairRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRequestNotes(RequestNotes requestNotes)
        {
            throw new NotImplementedException();
        }
    }

}