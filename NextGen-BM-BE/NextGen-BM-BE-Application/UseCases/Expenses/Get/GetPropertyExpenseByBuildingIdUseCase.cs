using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{
    public sealed class GetAllPropertyExpenseByBuildingIdUseCase(
        IExpensesRepository _expensesRepository
    )
    {
        private readonly IExpensesRepository expensesRepository = _expensesRepository;

        public async Task<IList<PropertyExpense>> Execute(int buildingId)
        {
            var result = await expensesRepository.GetPropertyExpenseByBuildingIdAsync(buildingId);
            return result;
        }
    }
}
