using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{

    public interface IPropertyRepository    
    {
        Task CreatePropertyAsync(Property property);
        Task<Property> GetPropertyBIdAsync(int propertId);
        Task<List<Property>> GetAllPropertiesAsync();
        Task<List<Property>> GetPropertiesByUseIdAsync(int useId);
        Task<List<Property>> GetPropertiesByBuildinIdAsync(int buildinId);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int propertId);
    }
}