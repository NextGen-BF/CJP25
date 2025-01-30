using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _dbContext;

        public RequestRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateRepairRequestAsync(RepairRequest repairRequest)
        {
            await _dbContext.RepairRequest.AddAsync(repairRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRepairRequestNotesAsync(RequestNotes requestNotes)
        {
            await _dbContext.RequestNotes.AddAsync(requestNotes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateUserBuildingRequestAsync(UserBuildings userBuildings)
        {
            await _dbContext.UserBuildings.AddAsync(userBuildings);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRepairRequestAsync(int requestId)
        {
            RepairRequest? repairRequestToDelete = await this.GetRepairRequestByIdAsync(requestId);
            if (repairRequestToDelete is not null)
            {
                repairRequestToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                _dbContext.RepairRequest.Update(repairRequestToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRequestNotesAsync(int requestNotesId)
        {
            RequestNotes? requestNotesToDelete = await _dbContext.RequestNotes.FindAsync(
                requestNotesId
            );
            if (requestNotesToDelete is not null)
            {
                requestNotesToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                _dbContext.RequestNotes.Update(requestNotesToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<RepairRequest> GetRepairRequestByIdAsync(int requestId)
        {
            try
            {
                RepairRequest? foundRepairRequest = await _dbContext.RepairRequest.FindAsync(
                    requestId
                );
                if (foundRepairRequest is null)
                {
                    throw new KeyNotFoundException("The repair request was not found.");
                }
                return foundRepairRequest;
            }
            catch (Exception ex)
            {
                throw new Exception("GetRepairRequestByIdAsync threw an error of: ", ex);
            }
        }

        public async Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBuildings> GetUserBuildingRequestsAsync(int buildingId)
        {
            try
            {
                UserBuildings? foundUserBuildings = await _dbContext.UserBuildings.FindAsync(
                    buildingId
                );
                if (foundUserBuildings is null)
                {
                    throw new KeyNotFoundException("The building was not found.");
                }
                return foundUserBuildings;
            }
            catch (Exception ex)
            {
                throw new Exception("GetUserBuildingRequestsAsync threw an error of: ", ex);
            }
        }

        public async Task UpdateRepairRequestAsync(RepairRequest repairRequest)
        {
            _dbContext.RepairRequest.Update(repairRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRequestNotesAsync(RequestNotes requestNotes)
        {
            _dbContext.RequestNotes.Update(requestNotes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
