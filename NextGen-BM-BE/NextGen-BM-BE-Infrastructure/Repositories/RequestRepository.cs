using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Entities.RequestAggregate.Specifications;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _dataContext;
        public RequestRepository(DataContext dataContext)
        {
            _dataContext=dataContext;
        } 
        public async Task CreateRepairRequestAsync(RepairRequest repairRequest)
        {
            try
            {
                await _dataContext.RepairRequests.AddAsync(repairRequest);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't create this request");
            }
        }

        public async Task CreateRepairRequestNotesAsync(RequestNotes requestNotes)
        {
            try
            {   
                await _dataContext.RequestNotes.AddAsync(requestNotes);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't create this note");
            }
        }

        public async Task CreateUserBuildingRequestAsync(UserBuildings userBuildings)
        {
            try
            {
                await _dataContext.UserBuildings.AddAsync(userBuildings);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't create this request");
            }
        }

        public async Task DeleteRepairRequestAsync(int requestId)
        {
            try
            {
                RepairRequest? repairRequestToDelete = await GetRepairRequestByIdAsync(requestId);
                if (repairRequestToDelete is not null)
                {
                    repairRequestToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                    _dataContext.RepairRequests.Update(repairRequestToDelete);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't delete this request");
            }
        }

        public async Task DeleteRequestNotesAsync(int requestNotesId)
        {
            try
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
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't delete this note");
            }
        }

        public async Task<RepairRequest> GetRepairRequestByIdAsync(int requestId)
        {
            try
            {
                return await _dataContext.RepairRequests
                    .Where(request=>request.RepairRequestId==requestId&&request.DeletedDate==null)
                    .Include(request=>request.Notes)
                    .Include(request=>request.RequestStatus)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this request");
            }
        }

        public async Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(int buildingId)
        {
            try
            {
                return await _dataContext.RepairRequests
                    .Where(request=>request.BuildingId==buildingId&&request.DeletedDate==null)
                    .Include(request=>request.Notes)
                    .Include(request=>request.RequestStatus)
                    .ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this building's requests");
            }
        }

        public async Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(int buildingId)
        {
            try
            {
                return await _dataContext.UserBuildings
                    .Where(userBuilding=>userBuilding.BuildingId==buildingId&&userBuilding.DeletedDate==null)
                    .Include(userBuildings=>userBuildings.Role)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this building's requests");
            }
        }

        public async Task UpdateRepairRequestAsync(RepairRequest repairRequest)
        {
            try
            {
                _dataContext.RepairRequests.Update(repairRequest);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't update this request");
            }
        }

        public async Task UpdateRequestNotesAsync(RequestNotes requestNotes)
        {
            try
            {
                _dataContext.RequestNotes.Update(requestNotes);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't update this note");
            }
        }
    }
}
