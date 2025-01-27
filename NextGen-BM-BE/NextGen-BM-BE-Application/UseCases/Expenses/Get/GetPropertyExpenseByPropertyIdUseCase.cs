using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{

    public sealed class GetAllPropertyExpenseByPropertyIdUseCase(IExpensesRepository _expensesRepository)
    {
        private readonly IExpensesRepository expensesRepository = _expensesRepository;
        public async Task<IList<PropertyExpense>> Execute(int propertyId)
        {
            var result = await expensesRepository.GetPropertyExpenseByPropertyIdAsync(propertyId);
            return result;
        }
    }
}