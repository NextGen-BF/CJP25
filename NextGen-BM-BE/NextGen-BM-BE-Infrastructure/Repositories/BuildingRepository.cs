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
            await _dbContext.Buildings.AddAsync(building);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBuildingAsync(int buildingId)
        {
            Building? buildingToDelete = await this.GetBuildingByIdAsync(buildingId);
            if (buildingToDelete is not null)
            {
                buildingToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                _dbContext.Buildings.Update(buildingToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await _dbContext.Buildings.Where(b => b.DeletedDate == null).ToListAsync();
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
                throw new Exception("GetBuildingByIdAsync threw an error of: ", ex);
            }
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            _dbContext.Buildings.Update(building);
            await _dbContext.SaveChangesAsync();
        }
    }
};
