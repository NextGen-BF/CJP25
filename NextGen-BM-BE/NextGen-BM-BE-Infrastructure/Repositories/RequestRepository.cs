using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;


namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class RequestRepository : IRequestRepository
    {
        readonly DataContext _dataContext;
        public RequestRepository(DataContext dataContext)
        {
            _dataContext=dataContext;
        } 
        public async Task CreateRepairRequestAsync(RepairRequest repairRequest)
        {
            await _dataContext.RepairRequests.AddAsync(repairRequest);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CreateRepairRequestNotesAsync(RequestNotes requestNotes)
        {
            await _dataContext.RequestNotes.AddAsync(requestNotes);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CreateUserBuildingRequestAsync(UserBuildings userBuildings)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRepairRequestAsync(int requestId)
        {
            await _dataContext.RepairRequests.Where(request=>request.RequestId==requestId).ExecuteDeleteAsync();
        }

        public async Task DeleteRequestNotesAsync(int requestNotesId)
        {
            await _dataContext.RequestNotes.Where(note=>note.RequestNotesId==requestNotesId).ExecuteDeleteAsync();
        }

        public async Task<RepairRequest> GetRepairRequestByIdAsync(int requestId)
        {
            return await _dataContext.RepairRequests.FindAsync(requestId);
        }

        public async Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(int buildingId)
        {
            return await _dataContext.RepairRequests.Where(request=>request.BuildingId==buildingId).ToListAsync();
        }

        public async Task<UserBuildings> GetUserBuildingRequestsAsync(int buildingId)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateRepairRequestAsync(RepairRequest repairRequest)
        {
            _dataContext.RepairRequests.Update(repairRequest);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateRequestNotesAsync(RequestNotes requestNotes)
        {
            _dataContext.RequestNotes.Update(requestNotes);
            await _dataContext.SaveChangesAsync();
        }
    }

}