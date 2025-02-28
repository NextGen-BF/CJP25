using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task CreatePropertyAsync(Property property);
        Task<Property> GetPropertyByIdAsync(int propertyId);
        Task<List<Property>> GetAllPropertiesAsync(int? page, int? pageSize);
        Task<List<Property>> GetPropertiesByUserIdAsync(int userId, int? page, int? pageSize);
        Task<List<Property>> GetPropertiesByBuildingIdAsync(int buildingId, int? page, int? pageSize);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int propertyId);
        Task DeletePropertyResidentAsync(int propertyResidentId);
    }
}
