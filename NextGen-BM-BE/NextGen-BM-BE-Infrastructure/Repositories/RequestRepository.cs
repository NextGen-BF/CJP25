using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
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
            await _dataContext.UserBuildings.AddAsync(userBuildings);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteRepairRequestAsync(int requestId)
        {
            RepairRequest? repairRequestToDelete = await this.GetRepairRequestByIdAsync(requestId);
            if (repairRequestToDelete is not null)
            {
                repairRequestToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                _dataContext.RepairRequests.Update(repairRequestToDelete);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRequestNotesAsync(int requestNotesId)
        {
            RequestNotes? requestNotesToDelete = await _dataContext.RequestNotes.FindAsync(
                requestNotesId
            );
            if (requestNotesToDelete is not null)
            {
                requestNotesToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                _dataContext.RequestNotes.Update(requestNotesToDelete);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<RepairRequest> GetRepairRequestByIdAsync(int requestId)
        {
            throw new NotImplementedException();
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
