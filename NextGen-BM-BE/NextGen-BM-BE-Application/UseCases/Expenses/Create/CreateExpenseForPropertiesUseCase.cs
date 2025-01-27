using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Create
{

    public sealed class CreateExpenseForPropertiesUseCase(IExpensesRepository _ExpensesRepository)
    {
        private readonly IExpensesRepository expensesRepository = _ExpensesRepository;

        public async Task Execute(List<int> propertyIds, int expenseId)
        {
            await expensesRepository.CreateExpenseForPropertiesAsync(propertyIds, expenseId);
        }
    }
}