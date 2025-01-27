using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Application.UseCases.Properties.Create
{

    public sealed class CreatePropertyUseCase(IPropertyRepository _PropertyRepository)
    {
        private readonly IPropertyRepository propertyRepository = _PropertyRepository;

        public async Task Execute(Property property)
        {
            await propertyRepository.CreatePropertyAsync(property);
        }
    }
}