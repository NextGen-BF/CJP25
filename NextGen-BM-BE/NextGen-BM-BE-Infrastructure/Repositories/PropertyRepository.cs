using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _dbContext;

        public PropertyRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePropertyAsync(Property property)
        {
            await _dbContext.Properties.AddAsync(property);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePropertyAsync(int propertyId)
        {
            Property? propertyToDelete = await this.GetPropertyByIdAsync(propertyId);
            if (propertyToDelete is not null)
            {
                _dbContext.Properties.Remove(propertyToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _dbContext.Properties.ToListAsync();
        }

        public async Task<List<Property>> GetPropertiesByBuildingIdAsync(int buildingId)
        {
            return await _dbContext.Properties.Where(p => p.BuildingId == buildingId).ToListAsync();
        }

        public async Task<List<Property>> GetPropertiesByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Property> GetPropertyByIdAsync(int propertyId)
        {
            try
            {
                Property? foundProperty = await _dbContext.Properties.FindAsync(propertyId);
                if (foundProperty is null)
                {
                    throw new KeyNotFoundException("The property was not found.");
                }
                return foundProperty;
            }
            catch (Exception ex)
            {
                throw new Exception("GetPropertyByIdAsync threw an error of: ", ex);
            }
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            _dbContext.Properties.Update(property);
            await _dbContext.SaveChangesAsync();
        }
    }
}
