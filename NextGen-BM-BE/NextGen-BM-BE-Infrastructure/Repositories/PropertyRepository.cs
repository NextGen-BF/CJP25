using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class PropertyRepository : IPropertyRepository
    {
        DataContext _dataContext;
        public PropertyRepository(DataContext dataContext)
        {
            _dataContext=dataContext;
        }
        public async Task CreatePropertyAsync(Property property)
        {
            await _dataContext.Properties.AddAsync(property);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeletePropertyAsync(int propertyId)
        {
            await _dataContext.Properties.Where(p=>p.PropertyId==propertyId).ExecuteDeleteAsync();
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _dataContext.Properties.ToListAsync();
        }

        public async Task<List<Property>> GetPropertiesByBuildingIdAsync(int buildingId)
        {
            var properties=await _dataContext.Properties.Where(p=>p.BuildingId==buildingId).ToListAsync();
            return properties;
        }

        public async Task<List<Property>> GetPropertiesByUserIdAsync(int userId)
        {
            return await _dataContext.Properties.Where(p=>p.Users.Any(u=>u.UserId==userId)).ToListAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(int propertyId)
        {
            return await _dataContext.Properties.Where(p=>p.PropertyId==propertyId).FirstOrDefaultAsync();
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            _dataContext.Properties.Update(property);
            await _dataContext.SaveChangesAsync();
        }
    }

}