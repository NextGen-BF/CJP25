using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;


namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class BuildingRepository : IBuildingRepository
    {
        private readonly DataContext dbContext;
        public BuildingRepository(DataContext _dbContext)
        {   
            dbContext = _dbContext;
        }
        public async Task CreateBuildingAsync(Building building)
        {
            await dbContext.Buildings.AddAsync(building);
            await dbContext.SaveChangesAsync();        
        }

        public async Task DeleteBuildingAsync(int buildingId)
        {
            Building? buildingToDelete = await this.GetBuildingByIdAsync(buildingId);
            if (buildingToDelete is not null)
            {
                dbContext.Buildings.Remove(buildingToDelete);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await dbContext.Buildings.ToListAsync();
        }

        public async Task<Building> GetBuildingByIdAsync(int buildingId)
        {
            try
            {
                Building? foundBuilding = await dbContext.Buildings.FindAsync(buildingId);
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
            dbContext.Buildings.Update(building);
            await dbContext.SaveChangesAsync();        }
    }
}
;