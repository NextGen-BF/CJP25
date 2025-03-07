using System.Data.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.DataStructures;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _dataContext;
        public RequestRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<RepairRequest> CreateRepairRequestAsync(RepairRequest repairRequest)
        {
            try
            {
                await _dataContext.RepairRequests.AddAsync(repairRequest);
                await _dataContext.SaveChangesAsync();
                return repairRequest;
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't create this request", exception);
            }
        }

        public async Task<RequestNotes> CreateRepairRequestNotesAsync(RequestNotes requestNotes)
        {
            try
            {
                await _dataContext.RequestNotes.AddAsync(requestNotes);
                await _dataContext.SaveChangesAsync();
                return requestNotes;
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't create this note", exception);
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
                throw new Exception("Couldn't create this request", exception);
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
                throw new Exception("Couldn't delete this request", exception);
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
                throw new Exception("Couldn't delete this note", exception);
            }
        }

        public async Task<RepairRequest> GetRepairRequestByIdAsync(int requestId)
        {
            try
            {
                var request = await _dataContext.RepairRequests
                    .Where(request => request.RepairRequestId == requestId && request.DeletedDate == null)
                    .Include(request => request.Notes)
                    .Include(request => request.RequestStatus)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
                return request;
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this request", exception);
            }
        }

        public async Task<IList<RepairRequest>> GetRepairRequestsByUserId(int userId, int? page, int? pageSize)
        {
            try
            {
                var query = _dataContext.RepairRequests
                .Where(request => request.UserId == userId && request.DeletedDate == null)
                .Include(request => request.Notes);
                if (page!=null&&pageSize!=null)
                {
                    var pagedList=new PagedList<RepairRequest>{Page=(int)page, PageSize=(int)pageSize};
                    await pagedList.Paginate(query);
                    return pagedList;
                }
                return await query
                    .AsNoTracking()
                    .ToListAsync();

            }
            catch (DbException exception)
            {
                throw new Exception("Couldn't retrieve data for this request", exception);

            }
        }

        public async Task<List<RepairRequest>> GetRepairRequestsByBuildingIdAsync(IList<int> buildingIds, int? page, int? pageSize)
        {
            try
            {
                var requestsQuery = _dataContext.RepairRequests
                    .Where(request => buildingIds.Contains(request.BuildingId) && request.DeletedDate == null)
                    .Include(request => request.Notes)
                    .Include(request => request.RequestStatus)
                    .Include(request => request.Building)
                    .Include(request => request.User);
                if (page!=null&&pageSize!=null)
                {
                    var pagedList=new PagedList<RepairRequest>{Page=(int)page, PageSize=(int)pageSize};
                    await pagedList.Paginate(requestsQuery);
                    return pagedList;
                }
                return await requestsQuery
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this building's requests", exception);
            }
        }

        public async Task<IList<UserBuildings>> GetUserBuildingRequestsAsync(IList<int> buildingIds, int? page, int? pageSize)
        {
            try
            {
                var query = _dataContext.UserBuildings
                    .Where(userBuilding => buildingIds.Contains(userBuilding.BuildingId) && userBuilding.DeletedDate == null)
                    .Include(userBuildings => userBuildings.Role)
                    .Include(userBuilding => userBuilding.Building)
                    .Include(request => request.User);
                if (page!=null&&pageSize!=null)
                {
                    var pagedList=new PagedList<UserBuildings>{Page=(int)page, PageSize=(int)pageSize};
                    await pagedList.Paginate(query);
                    return pagedList;
                }
                return await query
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this building's requests", exception);
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
                throw new Exception("Couldn't update this request", exception);
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
                throw new Exception("Couldn't update this note", exception);
            }
        }

        public async Task SetRequestStatusAsync(int requestId, int statusId, string requestType)
        {
            try
            {
                if (requestType == "Repair")
                {
                    var request = await _dataContext.RepairRequests.Where(request => request.RepairRequestId == requestId).FirstOrDefaultAsync() ?? throw new Exception($"Request with id: {requestId} not found.");
                    request.RequestStatusId = statusId;
                    _dataContext.Update(request);
                    await _dataContext.SaveChangesAsync();
                }
                else
                {
                    var request = await _dataContext.UserBuildings.Where(request => request.UserBuildingsId == requestId).FirstOrDefaultAsync() ?? throw new Exception($"Request with id: {requestId} not found.");
                    request.Approved = !request.Approved;
                    _dataContext.Update(request);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not set status for request", ex);
            }
        }

        public Task CreateRequestFilesAsync(int requestId, IList<string> filePaths, string requestType)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Enums>> GetRequestStatusesAsync()
        {
            try
            {
                return await _dataContext.Enums.Where(enums => enums.Type == "RequestStatus").ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get request statuses", ex);
            }
        }
    }
}
