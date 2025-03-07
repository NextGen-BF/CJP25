using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{

    public sealed class GetAllPropertiesUseCase(IPropertyRepository _propertyRepositories)
    {
        private readonly IPropertyRepository propertyRepository = _propertyRepositories;
        public async Task<IList<Property>> Execute(int? page, int? pageSize)
        {
            var result = await propertyRepository.GetAllPropertiesAsync(page, pageSize);
            return result;
        }
    }
}