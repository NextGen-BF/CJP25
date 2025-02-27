using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly DataContext _dbContext;

        public BuildingRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Building> CreateBuildingAsync(Building building)
        {
            try
            {
                await _dbContext.Buildings.AddAsync(building);
                await _dbContext.SaveChangesAsync();
                return building;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(CreateBuildingAsync)} threw an error of: ", ex);
            }
        }

        public async Task DeleteBuildingAsync(int buildingId)
        {
            try
            {
                Building? buildingToDelete = await this.GetBuildingByIdAsync(buildingId);
                if (buildingToDelete is not null)
                {
                    buildingToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                    _dbContext.Buildings.Update(buildingToDelete);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(DeleteBuildingAsync)} threw an error of: ", ex);
            }
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            try
            {
                return await _dbContext
                    .Buildings.Where(b => b.DeletedDate == null)
                    .Include(b => b.BuildingAddress)
                    .Include(b => b.BuildingExpenses)
                    .Include(b => b.Properties)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetAllBuildingsAsync)} threw an error of: ", ex);
            }
        }

        public async Task<Building> GetBuildingByIdAsync(int buildingId)
        {
            try
            {
                var foundBuilding =
                    await _dbContext
                        .Buildings.Where(b => b.BuildingId == buildingId && b.DeletedDate == null)
                        .Include(b => b.BuildingAddress)
                        .Include(b => b.BuildingExpenses)
                        .Include(b => b.Properties)
                        .AsNoTracking()
                        .FirstOrDefaultAsync()
                    ?? throw new KeyNotFoundException("The building was not found.");
                return foundBuilding;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetBuildingByIdAsync)} threw an error of: ", ex);
            }
        }

        public async Task<List<Building>> GetBuildingsByUserIdAsync(int userId)
        {
            try
            {
                var buildings = await _dbContext
                    .UserBuildings.Where(ub => ub.User.Id == userId && ub.DeletedDate == null)
                    .Include(b => b.Building.BuildingExpenses)
                    .Include(b => b.Building.Properties)
                        .ThenInclude(p => p.PropertyType)
                    .Include(b => b.Building.BuildingAddress)
                    .Select(ub => ub.Building)
                    .AsNoTracking()
                    .ToListAsync();
                return buildings;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error when trying {nameof(GetBuildingsByUserIdAsync)}. Error was: "
                        + ex.Message,
                    ex
                );
            }
        }

        public async Task DeleteUserBuildingLinkAsync(int userId, int buildingId)
        {
            try
            {
                var userBuilding = await _dbContext
                    .UserBuildings.Where(ub =>
                        ub.User.Id == userId
                        && ub.BuildingId == buildingId
                        && ub.DeletedDate == null
                    )
                    .FirstOrDefaultAsync();
                if (userBuilding is not null)
                {
                    userBuilding.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                    _dbContext.UserBuildings.Update(userBuilding);
                    await _dbContext.SaveChangesAsync();
                    return;
                }
                throw new KeyNotFoundException("The user building link was not found.");
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error trying to delete userBuildings. Error was " + ex.Message,
                    ex
                );
            }
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            try
            {
                _dbContext.Entry<Building>(building).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"Building with id of {building.BuildingId} was not found.");
            }
        }

        public async Task<UserBuildings> GetUserBuildingsLink(int userId, int buildingId)
        {
            try
            {
                return await _dbContext.UserBuildings.Where(ub =>
                        ub.User.Id == userId
                        && ub.BuildingId == buildingId
                        && ub.DeletedDate == null
                        && ub.Approved
                    )
                    .Include(ub => ub.Role)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception($"UserBuilding with building id of {buildingId} and user id of {userId} was not found.");
            }
        }
    }
};
