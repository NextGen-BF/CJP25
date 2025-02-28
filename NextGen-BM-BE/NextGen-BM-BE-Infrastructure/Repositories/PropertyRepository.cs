using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _dataContext;

        public PropertyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreatePropertyAsync(Property property)
        {
            try
            {
                await _dataContext.Property.AddAsync(property);
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
                var propertyToDelete = await GetPropertyByIdAsync(propertyId);
                if (propertyToDelete != null)
                {
                    propertyToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                    _dataContext.Property.Update(propertyToDelete);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't delete this property");
            }
        }

        public async Task<List<Property>> GetAllPropertiesAsync(int? page, int? pageSize)
        {
            try
            {
                return await _dataContext
                    .Property.Where(property => property.DeletedDate == null)
                    .Include(property => property.Users.Where(u => u.DeletedDate == null))
                    .Include(property => property.Payments.Where(p => p.DeletedDate == null))
                    .Include(property =>
                        property.PropertyResidents.Where(r => r.DeletedDate == null)
                    )
                    .ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for the properties");
            }
        }

        public async Task<List<Property>> GetPropertiesByBuildingIdAsync(int buildingId, int? page, int? pageSize)
        {
            try
            {
                var properties = await _dataContext
                    .Property.Where(property =>
                        property.BuildingId == buildingId && property.DeletedDate == null
                    )
                    .Include(property => property.Users.Where(u => u.DeletedDate == null))
                    .Include(property => property.Payments.Where(p => p.DeletedDate == null))
                    .Include(property =>
                        property.PropertyResidents.Where(r => r.DeletedDate == null)
                    )
                    .AsNoTracking()
                    .ToListAsync();
                return properties;
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve datafor this building's properties");
            }
        }

        public async Task<List<Property>> GetPropertiesByUserIdAsync(int userId, int? page, int? pageSize)
        {
            try
            {
                return await _dataContext
                    .Property.Include(property => property.Users.Where(u => u.DeletedDate == null))
                    .Where(property =>
                        property.Users.Any(u => u.User.Id == userId) && property.DeletedDate == null
                    )
                    .Include(property => property.Payments.Where(p => p.DeletedDate == null))
                    .Include(property =>
                        property.PropertyResidents.Where(r => r.DeletedDate == null)
                    )
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this user's properties");
            }
        }

        public async Task<Property> GetPropertyByIdAsync(int propertyId)
        {
            try
            {
                return await _dataContext
                    .Property.Where(property =>
                        property.PropertyId == propertyId && property.DeletedDate == null
                    )
                    .Include(property => property.Users.Where(u => u.DeletedDate == null))
                    .Include(property => property.Payments.Where(p => p.DeletedDate == null))
                    .Include(property =>
                        property.PropertyResidents.Where(r => r.DeletedDate == null)
                    )
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't retrieve data for this property");
            }
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            try
            {
                _dataContext.Property.Update(property);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Property couldn't be updated with the new data");
            }
        }

        public async Task DeletePropertyResidentAsync(int propertyResidentId)
        {
            try
            {
                var propertyResidentToDelete = await _dataContext.PropertyResident.FindAsync(
                    propertyResidentId
                );
                if (propertyResidentToDelete != null)
                {
                    propertyResidentToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                    _dataContext.PropertyResident.Update(propertyResidentToDelete);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (DbException exception)
            {
                //will eventually be replaced by custom one
                throw new Exception("Couldn't delete this property");
            }
        }
    }
}
