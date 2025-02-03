using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _dataContext;
        public PropertyRepository(DataContext dataContext)
        {
            _dataContext=dataContext;
        }
        public async Task CreatePropertyAsync(Property property)
        {
            try
            {
                await _dataContext.Properties.AddAsync(property);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve datafor this property");
            }
        }

        public async Task DeletePropertyAsync(int propertyId)
        {
            try
            {
                await _dataContext.Properties.Where(p=>p.PropertyId==propertyId).ExecuteDeleteAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't delete this property");
            }
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            try 
            {
                return await _dataContext.Properties.ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for the properties");
            }
        }

        public async Task<List<Property>> GetPropertiesByBuildingIdAsync(int buildingId)
        {
            try 
            {
                var properties=await _dataContext.Properties.Where(p=>p.BuildingId==buildingId).ToListAsync();
                return properties;
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve datafor this building's properties");
            }
        }

        public async Task<List<Property>> GetPropertiesByUserIdAsync(int userId)
        {
            try 
            {
                return await _dataContext.Properties.Where(p=>p.Users.Any(u=>u.UserId==userId)).ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this user's properties");
            }
        }

        public async Task<Property> GetPropertyByIdAsync(int propertyId)
        {
            return await _dataContext.Properties.Where(p=>p.PropertyId==propertyId).FirstOrDefaultAsync();
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            try 
            {
                _dataContext.Properties.Update(property);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Property couldn't be updated with the new data");
            }
        }
    }

}