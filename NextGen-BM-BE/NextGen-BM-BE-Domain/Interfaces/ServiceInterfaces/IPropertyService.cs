using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces{
    public interface IPropertyService
    {
        Task<IList<PropertyViewModel>> GetAllPropertiesAsync(); 
        Task CreatePropertyAsync(PropertyViewModel propertyViewModel); 
        Task DeletePropertyAsync(int propertyId); 
        Task UpdatePropertyAsync(PropertyViewModel propertyViewModel);
        Task<PropertyViewModel> GetPropertyByIdAsync(int propertyId);
        Task<IList<PropertyViewModel>> GetPropertyByUserIdAsync(int userId);
        Task<IList<PropertyViewModel>> GetPropertyByBuildingIdAsync(int buildingId);
        Task DeletePropertyResidentAsync(int propertyResidentId);
        Task<IList<PropertyTypeViewModel>> GetPropertyTypesAsync();
    }
}