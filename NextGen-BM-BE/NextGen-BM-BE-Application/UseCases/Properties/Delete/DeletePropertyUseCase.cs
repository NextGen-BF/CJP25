using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Propertys.Delete
{

    public sealed class DeletePropertyUseCase(IPropertyRepository _propertyRepository)
    {
        private readonly IPropertyRepository propertyRepository = _propertyRepository;

        public async Task Execute(int PropertyId)
        {
            await propertyRepository.DeletePropertyAsync(PropertyId);
        }
    }
}