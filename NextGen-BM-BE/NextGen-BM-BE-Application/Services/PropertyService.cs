using AutoMapper;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Properties.Create;
using NextGen_BM_BE_Application.UseCases.Properties.Delete;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

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
        private readonly DeletePropertyResidentUseCase _deletePropertyResidentUseCase;
        private readonly IMapper _mapper;

        public PropertyService(
            GetPropertiesByIdUseCase getPropertiesByIdUseCase,
            GetAllPropertiesUseCase getAllPropertiesUseCase,
            GetPropertiesByBuildingIdUseCase getPropertiesByBuildingIdUseCase,
            GetPropertiesByUserIdUseCase getPropertiesByUserIdUseCase,
            CreatePropertyUseCase createPropertyUseCase,
            DeletePropertyUseCase deletePropertyUseCase,
            UpdatePropertyUseCase updatePropertyUseCase,
            DeletePropertyResidentUseCase deletePropertyResidentUseCase,
            IMapper mapper
        )
        {
            _getPropertiesByIdUseCase = getPropertiesByIdUseCase;
            _getAllPropertiesUseCase = getAllPropertiesUseCase;
            _getPropertiesByBuildingIdUseCase = getPropertiesByBuildingIdUseCase;
            _getPropertiesByUserIdUseCase = getPropertiesByUserIdUseCase;
            _createPropertyUseCase = createPropertyUseCase;
            _deletePropertyUseCase = deletePropertyUseCase;
            _updatePropertyUseCase = updatePropertyUseCase;
            _deletePropertyResidentUseCase = deletePropertyResidentUseCase;
            _mapper = mapper;
        }

        public async Task CreatePropertyAsync(PropertyViewModel propertyViewModel)
        {
            var property = _mapper.Map<Property>(propertyViewModel);
            await _createPropertyUseCase.Execute(property);
        }

        public async Task DeletePropertyAsync(int propertyId)
        {
            await _deletePropertyUseCase.Execute(propertyId);
        }

        public async Task<IList<PropertyViewModel>> GetAllPropertiesAsync(int? page, int? pageSize)
        {
            var properties = await _getAllPropertiesUseCase.Execute(page, pageSize);
            return _mapper.Map<IList<PropertyViewModel>>(properties);
        }

        public async Task UpdatePropertyAsync(PropertyViewModel propertyViewModel)
        {
            var property = _mapper.Map<Property>(propertyViewModel);
            await _updatePropertyUseCase.Execute(property);
        }

        public async Task<PropertyViewModel> GetPropertyByIdAsync(int propertyId)
        {
            var property = await _getPropertiesByIdUseCase.Execute(propertyId);
            return _mapper.Map<PropertyViewModel>(property);
        }

        public async Task<IList<PropertyViewModel>> GetPropertyByUserIdAsync(int userId, int? page, int? pageSize)
        {
            var properties = await _getPropertiesByUserIdUseCase.Execute(userId, page, pageSize);
            return _mapper.Map<IList<PropertyViewModel>>(properties);
        }

        public async Task<IList<PropertyViewModel>> GetPropertyByBuildingIdAsync(int buildingId, int? page, int? pageSize)
        {
            var properties = await _getPropertiesByBuildingIdUseCase.Execute(buildingId, page, pageSize);
            return _mapper.Map<IList<PropertyViewModel>>(properties);
        }

        public async Task DeletePropertyResidentAsync(int propertyResidentId)
        {
            await _deletePropertyResidentUseCase.Execute(propertyResidentId);
        }
    }
}
