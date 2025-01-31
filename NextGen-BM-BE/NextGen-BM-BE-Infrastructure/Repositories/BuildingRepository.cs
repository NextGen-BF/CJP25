using Microsoft.EntityFrameworkCore;
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

        public async Task CreateBuildingAsync(Building building)
        {
            try
            {
                await _dbContext.Buildings.AddAsync(building);
                await _dbContext.SaveChangesAsync();
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
                return await _dbContext.Buildings.Where(b => b.DeletedDate == null).ToListAsync();
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
                Building? foundBuilding = await _dbContext.Buildings.FindAsync(buildingId);
                if (foundBuilding is null)
                {
                    throw new KeyNotFoundException("The building was not found.");
                }
                return foundBuilding;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetBuildingByIdAsync)} threw an error of: ", ex);
            }
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            try
            {
                _dbContext.Buildings.Update(building);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(UpdateBuildingAsync)} threw an error of: ", ex);
            }
        }
    }
};
