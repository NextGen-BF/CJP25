using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Properties.Create;
using NextGen_BM_BE_Application.UseCases.Properties.Delete;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly GetPropertiesByIdUseCase _getPropertiesByIdUseCase;
        private readonly GetAllPropertiesUseCase _getAllPropertiesUseCase;
        private readonly GetPropertiesByBuildingIdUseCase _getPropertiesByBuildingIdUseCase;
        private readonly GetPropertiesByUserIdUseCase _getPropertiesByUserIdUseCase;
        private readonly CreatePropertyUseCase _createPropertyUseCase;
        private readonly DeletePropertyUseCase _deletePropertyUseCase;
        private readonly UpdatePropertyUseCase _updatePropertyUseCase;

        public PropertyService(
            GetPropertiesByIdUseCase getPropertiesByIdUseCase,
            GetAllPropertiesUseCase getAllPropertiesUseCase,
            GetPropertiesByBuildingIdUseCase getPropertiesByBuildingIdUseCase,
            GetPropertiesByUserIdUseCase getPropertiesByUserIdUseCase,
            CreatePropertyUseCase createPropertyUseCase,
            DeletePropertyUseCase deletePropertyUseCase,
            UpdatePropertyUseCase updatePropertyUseCase
        )
        {
            _getPropertiesByIdUseCase = getPropertiesByIdUseCase;
            _getAllPropertiesUseCase = getAllPropertiesUseCase;
            _getPropertiesByBuildingIdUseCase = getPropertiesByBuildingIdUseCase;
            _getPropertiesByUserIdUseCase = getPropertiesByUserIdUseCase;
            _createPropertyUseCase = createPropertyUseCase;
            _deletePropertyUseCase = deletePropertyUseCase;
            _updatePropertyUseCase = updatePropertyUseCase;
        }

        public async Task CreatePropertyAsync(Property property)
        {
            await _createPropertyUseCase.Execute(property);
        }

        public async Task DeletePropertyAsync(int propertyId)
        {
            await _deletePropertyUseCase.Execute(propertyId);
        }

        public async Task<IList<Property>> GetAllPropertiesAsync()
        {
            return await _getAllPropertiesUseCase.Execute();
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            await _updatePropertyUseCase.Execute(property);
        }

        public async Task<Property> GetPropertyByIdAsync(int propertyId)
        {
            return await _getPropertiesByIdUseCase.Execute(propertyId);
        }

        public async Task<IList<Property>> GetPropertyByUserIdAsync(int userId)
        {
            return await _getPropertiesByUserIdUseCase.Execute(userId);
        }

        public async Task<IList<Property>> GetPropertyByBuildingIdAsync(int buildingId)
        {
            return await _getPropertiesByBuildingIdUseCase.Execute(buildingId);
        }
    }
}
